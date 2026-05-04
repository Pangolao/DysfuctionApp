using Dysfunction.GUI.Register;
using Dysfunction.Logic;
using Dysfunction.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Dysfunction.GUI.Consult
{
    public partial class PeriodConsult : Form
    {
        periodLogic periodLogic = new periodLogic();
        asignatureLogic asignatureLogic = new asignatureLogic();
        bool selected = true;
        private Dysfunction dysfunctionForm;
        string URL;
        int buttonPeriod;
        public string buttonNamePeriod;
        public string buttonLinkPeriod;

        string xmlFilePath = "Settings.xml";

        public PeriodConsult(Dysfunction dysfunction)
        {
            InitializeComponent();
            dataGridView.RowTemplate.Height = 32;
            dysfunctionForm = dysfunction;
            Thread.CurrentThread.CurrentCulture = CultureInfo.CurrentCulture;
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CurrentCulture;
            dataGridView.DefaultCellStyle.SelectionBackColor = Color.White;
            dataGridView.DefaultCellStyle.SelectionForeColor = Color.Black;
            dataGridView.Columns[8].DefaultCellStyle.SelectionBackColor = Color.Black;
            dataGridView.Columns[8].DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridView.Columns[9].DefaultCellStyle.SelectionBackColor = Color.Black;
            dataGridView.Columns[9].DefaultCellStyle.SelectionForeColor = Color.White;
            LoadDataToGrid();
            FullComboPeriod();

            foreach (DataGridViewColumn col in dataGridView.Columns)
            {
                col.DefaultCellStyle.SelectionBackColor = Color.FromArgb(45, 50, 50);
                col.DefaultCellStyle.SelectionForeColor = Color.White;
            }

            if (System.IO.File.Exists(xmlFilePath))
            {
                var xml = XElement.Load(xmlFilePath);
                buttonPeriod = (int?)xml.Element("buttonPeriod") ?? 0;
                buttonNamePeriod = (string)xml.Element("buttonNamePeriod") ?? "";
                buttonLinkPeriod = (string)xml.Element("buttonLinkPeriod") ?? "";

            }

            labelPeriodButton.Text = buttonNamePeriod;

            if (buttonPeriod == 0)
            {
                panel5.Visible = false;
            }
            else
            {
                panel5.Visible = true;
            }


        }

        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (selected)
            {
                dataGridView.ClearSelection();
                return;
            }

        }
        private async void FullComboPeriod()
        {
            comboBoxPeriod.Items.Clear();
            List<periodModel> periodModels = periodLogic.Consult();
            foreach (var model in periodModels)
            {
                if (model != null && model.Year == dateTimePicker.Value.Year)
                {
                    comboBoxPeriod.Items.Add(model.Period);
                    await Task.Delay(1);
                    comboBoxPeriod.SelectedIndex = 0;
                }
            }
        }
        private void LoadDataToGrid()
        {
            dataGridView.Rows.Clear();

            List<periodModel> periodModels = periodLogic.Consult();
            List<asignatureModel> asignatureModels = asignatureLogic.Consult();

            foreach (var period in periodModels)
            {
                if (period != null)
                {
                    foreach (var asignature in asignatureModels)
                    {
                        if (asignature != null && period.Asignatures.Contains(asignature.Code))
                        {
                            // Calcular el subdirectorio y el nombre base con deleteSpaces
                            string deletedPeriod = periodLogic.deleteSpaces(period.Period);
                            string subDir = $"{asignature.Code}_{deletedPeriod}_{period.Year}";

                            // Directorio de Material con subdirectorio
                            string materialDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Material", subDir);
                            bool materialDirExists = Directory.Exists(materialDirectory);

                            // Directorio de Orientation con subdirectorio
                            string orientationDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Orientation", subDir);
                            bool orientationDirExists = Directory.Exists(orientationDirectory);

                            // Nombre base para archivos (usando deletedPeriod)
                            string materialFileNameBase = $"Material_{asignature.Code}_{deletedPeriod}_{period.Year}";
                            string oriFileNameBase = $"Orientation_{asignature.Code}_{deletedPeriod}_{period.Year}";

                            // Estado del archivo de Material (busca todos los archivos coincidentes, incluyendo múltiples con _1, _2, etc.)
                            string materialStatus = "None";
                            if (materialDirExists)
                            {
                                string[] materialFiles = Directory.GetFiles(materialDirectory, $"{materialFileNameBase}*.*");
                                materialStatus = materialFiles.Length > 0 ? "Click to open" : "None";
                            }

                            // Estado del archivo de Orientation (busca todos los archivos coincidentes)
                            string oriStatus = "None";
                            if (orientationDirExists)
                            {
                                string[] oriFiles = Directory.GetFiles(orientationDirectory, $"{oriFileNameBase}*.*");
                                oriStatus = oriFiles.Length > 0 ? "Click to open" : "None";
                            }

                            // Agregar la fila al DataGridView
                            if (asignatureLogic.ObtainFinalScore(asignature.Code, period.Period, period.Year) > 6.74)
                            {
                                dataGridView.Rows.Add(period.Year, period.Period, asignature.Code, asignature.Asignature, asignature.Teacher, asignature.Group, asignatureLogic.ObtainFinalScore(asignature.Code, period.Period, period.Year), "✓", oriStatus, materialStatus);
                            }
                            else
                            {
                                dataGridView.Rows.Add(period.Year, period.Period, asignature.Code, asignature.Asignature, asignature.Teacher, asignature.Group, asignatureLogic.ObtainFinalScore(asignature.Code, period.Period, period.Year), "X", oriStatus, materialStatus);
                            }
                        }
                    }
                }
            }
        }

        private async void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            OpenOrientationPDF(e);
            OpenMaterialPDF(e);
            await Task.Delay(500);
            dataGridView.ClearSelection();
        }

        private void OpenMaterialPDF(DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 9) // Columna de "Material"
            {
                var selectedRow = dataGridView.Rows[e.RowIndex];

                if (selectedRow.Cells[9].Value != null && !string.IsNullOrWhiteSpace(selectedRow.Cells[9].Value.ToString()))
                {
                    string code = selectedRow.Cells[2].Value.ToString();
                    string period = selectedRow.Cells[1].Value.ToString();
                    string year = selectedRow.Cells[0].Value.ToString();
                    string deletedPeriod = periodLogic.deleteSpaces(period);

                    // Nombre base del archivo sin extensión (usando deletedPeriod)
                    string fileNameBase = $"Material_{code}_{deletedPeriod}_{year}";
                    string subDir = $"{code}_{deletedPeriod}_{year}";
                    string targetDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Material", subDir);

                    if (Directory.Exists(targetDirectory))
                    {
                        // Buscar cualquier archivo que coincida con el nombre base (incluyendo _1, _2, etc.)
                        string[] matchingFiles = Directory.GetFiles(targetDirectory, $"{fileNameBase}*.*");

                        if (matchingFiles.Length > 0)
                        {
                            foreach (var file in matchingFiles)
                            {
                                try
                                {
                                    // Intentar abrir cada archivo
                                    Process.Start(new ProcessStartInfo(file) { UseShellExecute = true });
                                }
                                catch (Exception ex)
                                {
                                    // Si no se puede abrir, seleccionar en el explorador (solo el primero para simplicidad)
                                    Process.Start("explorer.exe", $"/select, \"{matchingFiles[0]}\"");
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void OpenOrientationPDF(DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 8) // Columna de "Orientation"
            {
                var selectedRow = dataGridView.Rows[e.RowIndex];

                if (selectedRow.Cells[8].Value != null && !string.IsNullOrWhiteSpace(selectedRow.Cells[8].Value.ToString()))
                {
                    string code = selectedRow.Cells[2].Value.ToString();
                    string period = selectedRow.Cells[1].Value.ToString();
                    string year = selectedRow.Cells[0].Value.ToString();
                    string deletedPeriod = periodLogic.deleteSpaces(period);

                    // Nombre base del archivo sin extensión (usando deletedPeriod)
                    string fileNameBase = $"Orientation_{code}_{deletedPeriod}_{year}";
                    string subDir = $"{code}_{deletedPeriod}_{year}";
                    string targetDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Orientation", subDir);

                    if (Directory.Exists(targetDirectory))
                    {
                        // Buscar cualquier archivo que coincida con el nombre base (incluyendo _1, _2, etc.)
                        string[] matchingFiles = Directory.GetFiles(targetDirectory, $"{fileNameBase}*.*");

                        if (matchingFiles.Length > 0)
                        {
                            foreach (var file in matchingFiles)
                            {
                                try
                                {
                                    // Intentar abrir cada archivo
                                    Process.Start(new ProcessStartInfo(file) { UseShellExecute = true });
                                }
                                catch (Exception ex)
                                {
                                    // Si no se puede abrir, seleccionar en el explorador (solo el primero para simplicidad)
                                    Process.Start("explorer.exe", $"/select, \"{matchingFiles[0]}\"");
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void PeriodConsult_Click(object sender, EventArgs e)
        {
            dataGridView.ClearSelection();

        }
        private void dataGridView_MouseClick(object sender, MouseEventArgs e)
        {
            var hit = dataGridView.HitTest(e.X, e.Y);

            if (hit.Type == DataGridViewHitTestType.None)
            {
                LoadDataToGrid();
            }
        }

        private void comboBoxPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView.Rows.Clear();
            selected = true;
            List<periodModel> periodModels = periodLogic.Consult();
            List<asignatureModel> asignatureModels = asignatureLogic.Consult();

            foreach (var period in periodModels)
            {
                if (period != null && period.Period == comboBoxPeriod.SelectedItem?.ToString() && period.Year == dateTimePicker.Value.Year)
                {
                    foreach (var asignature in asignatureModels)
                    {
                        if (asignature != null && period.Asignatures.Contains(asignature.Code))
                        {
                            // Calcular el subdirectorio y el nombre base con deleteSpaces
                            string deletedPeriod = periodLogic.deleteSpaces(period.Period);
                            string subDir = $"{asignature.Code}_{deletedPeriod}_{period.Year}";

                            // Directorio de Material con subdirectorio
                            string materialDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Material", subDir);
                            bool materialDirExists = Directory.Exists(materialDirectory);

                            // Directorio de Orientation con subdirectorio
                            string orientationDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Orientation", subDir);
                            bool orientationDirExists = Directory.Exists(orientationDirectory);

                            // Nombre base para archivos (usando deletedPeriod)
                            string materialFileNameBase = $"Material_{asignature.Code}_{deletedPeriod}_{period.Year}";
                            string oriFileNameBase = $"Orientation_{asignature.Code}_{deletedPeriod}_{period.Year}";

                            // Estado del archivo de Material (busca todos los archivos coincidentes)
                            string materialStatus = "None";
                            if (materialDirExists)
                            {
                                string[] materialFiles = Directory.GetFiles(materialDirectory, $"{materialFileNameBase}*.*");
                                materialStatus = materialFiles.Length > 0 ? "Click to open" : "None";
                            }

                            // Estado del archivo de Orientation (busca todos los archivos coincidentes)
                            string oriStatus = "None";
                            if (orientationDirExists)
                            {
                                string[] oriFiles = Directory.GetFiles(orientationDirectory, $"{oriFileNameBase}*.*");
                                oriStatus = oriFiles.Length > 0 ? "Click to open" : "None";
                            }

                            // Agregar la fila al DataGridView
                            if (asignatureLogic.ObtainFinalScore(asignature.Code, period.Period, period.Year) > 6.74)
                            {
                                dataGridView.Rows.Add(period.Year, period.Period, asignature.Code, asignature.Asignature, asignature.Teacher, asignature.Group, asignatureLogic.ObtainFinalScore(asignature.Code, period.Period, period.Year), "✓", oriStatus, materialStatus);
                            }
                            else
                            {
                                dataGridView.Rows.Add(period.Year, period.Period, asignature.Code, asignature.Asignature, asignature.Teacher, asignature.Group, asignatureLogic.ObtainFinalScore(asignature.Code, period.Period, period.Year), "X", oriStatus, materialStatus);
                            }
                        }
                    }
                }
            }

            if (selected)
            {
                dataGridView.ClearSelection();
            }
            selected = false;
        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            FullComboPeriod();
        }

        private async void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            dysfunctionForm.OpenNewForm(new PeriodRegister(dysfunctionForm));
            panel2.BorderStyle = BorderStyle.FixedSingle;
            await Task.Delay(100);
            panel2.BorderStyle = BorderStyle.None;
        }

        private void panel2_MouseEnter(object sender, EventArgs e)
        {
            panel2.BackColor = Color.FromArgb(20, 20, 20);

        }

        private void panel2_MouseLeave(object sender, EventArgs e)
        {
            panel2.BackColor = Color.FromArgb(0, 0, 0);
        }

        private void ProjectConsult_MouseEnter(object sender, EventArgs e)
        {
            panel2.BackColor = Color.FromArgb(0, 0, 0);
            panel1.BackColor = Color.FromArgb(0, 0, 0);
        }

        private async void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            dysfunctionForm.OpenNewForm(new PeriodEdit(dysfunctionForm));
            panel1.BorderStyle = BorderStyle.FixedSingle;
            await Task.Delay(100);
            panel1.BorderStyle = BorderStyle.None;
        }

        private void panel1_MouseEnter(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(20, 20, 20);
        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(0, 0, 0);
        }

        private async void dataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                await Task.Delay(500);
                dataGridView.ClearSelection();
            }


            // Lógica original para mostrar el menú contextual si corresponde
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && (e.ColumnIndex == 8 || e.ColumnIndex == 9))
            {
                var selectedRow = dataGridView.Rows[e.RowIndex];
                string code = selectedRow.Cells[2].Value?.ToString();
                string period = selectedRow.Cells[1].Value?.ToString();
                string year = selectedRow.Cells[0].Value?.ToString();
                string deletedPeriod = periodLogic.deleteSpaces(period);

                string fileNameBase;
                string subDir = $"{code}_{deletedPeriod}_{year}";
                string targetDirectory;
                if (e.ColumnIndex == 8) // Orientation
                {
                    fileNameBase = $"Orientation_{code}_{deletedPeriod}_{year}";
                    targetDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Orientation", subDir);
                }
                else // Material
                {
                    fileNameBase = $"Material_{code}_{deletedPeriod}_{year}";
                    targetDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Material", subDir);
                }

                if (Directory.Exists(targetDirectory))
                {
                    string[] matchingFiles = Directory.GetFiles(targetDirectory, $"{fileNameBase}*.*");
                    if (matchingFiles.Length > 1)
                    {
                        dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
                        ContextMenuStrip menu = new ContextMenuStrip();
                        var showAllItem = new ToolStripMenuItem("Show them all");
                        showAllItem.Click += (s, args) =>
                        {
                            try
                            {
                                label5.Focus(); // Cambiar el foco a otro control para evitar problemas de enfoque
                                dataGridView.ClearSelection();
                                Process.Start("explorer.exe", targetDirectory);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Error opening folder: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        };
                        menu.Items.Add(showAllItem);

                        var position = dataGridView.PointToScreen(dataGridView.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).Location);
                        position.X += e.X;
                        position.Y += e.Y;
                        menu.Show(position);
                    }
                }
            }
        }

        private void panel5_MouseDown(object sender, MouseEventArgs e)
        {
            string link = buttonLinkPeriod;
            if (!string.IsNullOrWhiteSpace(link) &&
                !link.StartsWith("http://", StringComparison.OrdinalIgnoreCase) &&
                !link.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
            {
                link = "https://" + link;
            }

            Process.Start(new ProcessStartInfo
            {
                FileName = link,
                UseShellExecute = true
            });
        }

        private void panel5_MouseEnter(object sender, EventArgs e)
        {
            panel5.BackColor = Color.FromArgb(20, 20, 20);
        }
        private void panel5_MouseLeave(object sender, EventArgs e)
        {
            panel5.BackColor = Color.FromArgb(0, 0, 0);
        }

        private void dataGridView_MouseDown(object sender, MouseEventArgs e)
        {
            dataGridView.ClearSelection();
        }
    }
}