using Dysfunction.Data;
using Dysfunction.GUI.Register;
using Dysfunction.Logic;
using Dysfunction.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.Xml;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Dysfunction.GUI.Consult
{
    public partial class ProjectConsult : Form
    {
        periodLogic periodLogic = new periodLogic();
        asignatureLogic asignatureLogic = new asignatureLogic();
        projectLogic projectLogic = new projectLogic();
        private Dysfunction dysfunctionForm;
        string periodSelection;
        public static string projectName;
        public static string asignatureName;
        string asignatureSelection;
        bool selected = true;
        string xmlFilePath1 = "Selections.xml";
        string xmlFilePath2 = "ProjectStartUp.xml";
        int buttonProject;
        public string buttonNameProject;
        public string buttonLinkProject;
        string xmlFilePath = "Settings.xml";
        public static List<string> ProjectOnStartUp = new List<string>();
        private ContextMenuStrip cellContextMenu;
        private bool isLeftClickSelection = false;

        public ProjectConsult(Dysfunction dysfunction)
        {
            InitializeComponent();
            dataGridView.RowTemplate.Height = 32;
            dysfunctionForm = dysfunction;
            Thread.CurrentThread.CurrentCulture = CultureInfo.CurrentCulture;
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CurrentCulture;
            dataGridView.DefaultCellStyle.SelectionBackColor = Color.White;
            dataGridView.DefaultCellStyle.SelectionForeColor = Color.Black;

            foreach (DataGridViewColumn col in dataGridView.Columns)
            {
                col.DefaultCellStyle.SelectionBackColor = Color.FromArgb(45, 50, 50);
                col.DefaultCellStyle.SelectionForeColor = Color.White;
            }

            // Prevent column 6 from changing color when selected
            dataGridView.Columns[6].DefaultCellStyle.SelectionBackColor = dataGridView.Columns[6].DefaultCellStyle.BackColor;
            dataGridView.Columns[6].DefaultCellStyle.SelectionForeColor = dataGridView.Columns[6].DefaultCellStyle.ForeColor;

            FullComboPeriod();
            FullComboAsignature();
            LoadSelectionsFromXml();
            LoadDataToGrid();

            if (System.IO.File.Exists(xmlFilePath))
            {
                var xml = XElement.Load(xmlFilePath);
                buttonProject = (int?)xml.Element("buttonProject") ?? 0;
                buttonNameProject = (string)xml.Element("buttonNameProject") ?? "";
                buttonLinkProject = (string)xml.Element("buttonLinkProject") ?? "";
            }
            if (buttonProject == 0)
            {
                panel5.Visible = false;
            }
            else
            {
                panel5.Visible = true;
            }
            labelProject.Text = buttonNameProject;
            CreateCellContextMenu();
            dataGridView.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dataGridView.MultiSelect = false;
            dataGridView.ShowCellToolTips = false;
        }

        private void FullComboPeriod()
        {
            comboBoxPeriod.Items.Clear();
            List<periodModel> periodModels = periodLogic.Consult();
            foreach (var model in periodModels)
            {
                if (model != null && model.Year == dateTimePicker.Value.Year)
                {
                    comboBoxPeriod.Items.Add(model.Period);
                }
            }
        }

        private void FullComboAsignature()
        {
            comboBoxAsignature.Items.Clear();
            List<asignatureModel> asignatureModels = asignatureLogic.Consult();
            List<periodModel> periodModels = periodLogic.Consult();

            foreach (var period in periodModels)
            {
                if (period != null && period.Period == periodSelection && period.Year == dateTimePicker.Value.Year)
                {
                    foreach (var asignature in asignatureModels)
                    {
                        if (asignature != null && period.Asignatures.Contains(asignature.Code))
                        {
                            comboBoxAsignature.Items.Add(asignature.Asignature);
                        }
                    }
                    if (comboBoxAsignature.Items.Count < 1)
                    {
                        comboBoxAsignature.SelectedIndex = 0;
                    }
                }
            }
        }

        private void LoadDataToGrid()
        {
            dataGridView.Rows.Clear();
            selected = true;

            if (!string.IsNullOrEmpty(periodSelection) && !string.IsNullOrEmpty(asignatureSelection))
            {
                List<projectModel> projectModels = projectLogic.Consult();

                var filteredProjects = projectModels.Where(p =>
                    p.Year == dateTimePicker.Value.Year &&
                    p.Period == periodSelection &&
                    p.Code == asignatureLogic.ObtainCode(asignatureSelection)).ToList();

                // Verificar si el directorio "Indication" existe
                string indicationDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Indication");
                bool indicationDirExists = Directory.Exists(indicationDirectory);

                // Cargar los proyectos seleccionados del XML
                LoadProjectsSelectionsFromXml();

                foreach (var project in filteredProjects)
                {
                    // Nombre base del archivo sin extensión, con período sin espacios para coincidir con archivos reales
                    string cleanedPeriod = projectLogic.deleteSpaces(project.Period);
                    string fileNameBase = $"Indication_{project.Project}_{project.Code}_{cleanedPeriod}_{project.Year}";

                    // Determinar el estado del archivo
                    string materialStatus = "None";
                    if (indicationDirExists)
                    {
                        // Buscar recursivamente en todas las subcarpetas de "Indication"
                        string[] allFiles = Directory.GetFiles(indicationDirectory, "*.*", SearchOption.AllDirectories);

                        // Filtrar archivos que coincidan con el nombre base del proyecto (incluyendo sufijos como _2, _3)
                        string pattern = $"^{Regex.Escape(fileNameBase)}(_[0-9]+)?\\.[^.]+$";
                        Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);

                        string[] matchingFiles = allFiles
                            .Where(file => regex.IsMatch(Path.GetFileName(file)))
                            .ToArray();

                        materialStatus = matchingFiles.Length > 0 ? "Click to open" : "None";
                    }

                    // Formatear la fecha de inicio
                    string formattedStartDate = project.LimitDate.ToString("dd/MM/yyyy");

                    // Crear identificador único para el proyecto (mantiene el período original para consistencia con XML)
                    string projectIdentifier = $"{project.Project}_{project.Code}_{cleanedPeriod}_{project.Year}";

                    // Verificar si el proyecto está en la lista de proyectos seleccionados
                    bool isSelected = ProjectOnStartUp.Contains(projectIdentifier);

                    // Agregar la fila al DataGridView
                    dataGridView.Rows.Add(project.Project, materialStatus, formattedStartDate, project.Value, project.Score,
                        projectLogic.MakeItReal(project.Score, project.Value, 10), isSelected);
                }
            }
        }

        private void comboBoxPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            periodSelection = comboBoxPeriod.SelectedItem?.ToString();
            SaveSelectionsToXml();
            FullComboAsignature();
            LoadDataToGrid();
        }

        private void comboBoxAsignature_SelectedIndexChanged(object sender, EventArgs e)
        {
            asignatureSelection = comboBoxAsignature.SelectedItem?.ToString();
            SaveSelectionsToXml();
            LoadDataToGrid();
        }

        private async void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 1) // Columna de "Indication"
            {
                var selectedRow = dataGridView.Rows[e.RowIndex];
                if (selectedRow.Cells[1].Value != null && !string.IsNullOrWhiteSpace(selectedRow.Cells[1].Value.ToString()))
                {
                    string projectName = selectedRow.Cells[0].Value.ToString();
                    string code = asignatureLogic.ObtainCode(asignatureSelection);
                    string period = periodSelection;
                    int year = dateTimePicker.Value.Year;
                    string fileNameBase = $"Indication_{projectName}_{code}_{projectLogic.deleteSpaces(period)}_{year}";
                    string targetDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Indication", $"{code}_{projectLogic.deleteSpaces(period)}_{year}");

                    if (Directory.Exists(targetDirectory))
                    {
                        string[] matchingFiles = Directory.GetFiles(targetDirectory, $"{fileNameBase}.*");
                        if (matchingFiles.Length > 0)
                        {
                            // Check if there is only one file for the project
                            if (projectLogic.IndicationExist(projectName, code, projectLogic.deleteSpaces(period), year))
                            {
                                // If only one file exists, open it directly
                                try
                                {
                                    Process.Start(new ProcessStartInfo(matchingFiles[0]) { UseShellExecute = true });
                                }
                                catch (Exception ex)
                                {
                                    Process.Start("explorer.exe", $"/select, \"{matchingFiles[0]}\"");
                                }
                            }
                        }
                    }
                }
            }

            if (e.RowIndex >= 0 && e.ColumnIndex == 0) // Columna de "Project"
            {
                var selectedRow = dataGridView.Rows[e.RowIndex];
                if (selectedRow.Cells[0].Value != null && !string.IsNullOrWhiteSpace(selectedRow.Cells[0].Value.ToString()))
                {
                    string projectName = selectedRow.Cells[0].Value.ToString();
                    string code = asignatureLogic.ObtainCode(asignatureSelection);
                    string period = periodSelection;
                    int year = dateTimePicker.Value.Year;
                    string fileNameBase = $"{projectName}_{code}_{projectLogic.deleteSpaces(period)}_{year}";
                    string targetDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Project", $"{code}_{projectLogic.deleteSpaces(period)}_{year}");

                    if (Directory.Exists(targetDirectory))
                    {
                        string[] matchingFiles = Directory.GetFiles(targetDirectory, $"{fileNameBase}.*");
                        if (matchingFiles.Length > 0)
                        {
                            // Check if there is only one file for the project
                            if (projectLogic.ProjectExist(projectName, code, projectLogic.deleteSpaces(period), year))
                            {
                                // If only one file exists, open it directly
                                try
                                {
                                    Process.Start(new ProcessStartInfo(matchingFiles[0]) { UseShellExecute = true });
                                }
                                catch (Exception ex)
                                {
                                    Process.Start("explorer.exe", $"/select, \"{matchingFiles[0]}\"");
                                }
                            }
                        }
                    }
                }
            }

            await Task.Delay(100);
            dataGridView.ClearSelection();
        }

        private void SaveSelectionsToXml()
        {
            var xml = new XElement("Selections",
                new XElement("Period", periodSelection ?? string.Empty),
                new XElement("Asignature", asignatureSelection ?? string.Empty)
            );
            xml.Save(xmlFilePath1);
        }

        private void LoadSelectionsFromXml()
        {
            if (File.Exists(xmlFilePath1))
            {
                var xml = XElement.Load(xmlFilePath1);
                periodSelection = xml.Element("Period")?.Value;
                asignatureSelection = xml.Element("Asignature")?.Value;

                if (string.IsNullOrEmpty(periodSelection) && comboBoxPeriod.Items.Count > 0)
                {
                    comboBoxPeriod.SelectedIndex = 0;
                    periodSelection = comboBoxPeriod.SelectedItem?.ToString();
                }
                else if (!string.IsNullOrEmpty(periodSelection) && comboBoxPeriod.Items.Contains(periodSelection))
                {
                    comboBoxPeriod.SelectedItem = periodSelection;
                }

                if (string.IsNullOrEmpty(asignatureSelection) && comboBoxAsignature.Items.Count > 0)
                {
                    comboBoxAsignature.SelectedIndex = 0;
                    asignatureSelection = comboBoxAsignature.SelectedItem?.ToString();
                }
                else if (!string.IsNullOrEmpty(asignatureSelection) && comboBoxAsignature.Items.Contains(asignatureSelection))
                {
                    comboBoxAsignature.SelectedItem = asignatureSelection;
                }
            }
            else
            {
                if (comboBoxPeriod.Items.Count > 0)
                {
                    comboBoxPeriod.SelectedIndex = 0;
                    periodSelection = comboBoxPeriod.SelectedItem?.ToString();
                }

                if (comboBoxAsignature.Items.Count > 0)
                {
                    comboBoxAsignature.SelectedIndex = 0;
                    asignatureSelection = comboBoxAsignature.SelectedItem?.ToString();
                }
            }
        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            SaveSelectionsToXml();
            FullComboPeriod();
            FullComboAsignature();
            LoadDataToGrid();
        }

        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (selected)
            {
                dataGridView.ClearSelection();
            }
            selected = false;
        }

        private void ProjectScoreConsult_Click(object sender, EventArgs e)
        {
            LoadDataToGrid();
        }

        private void dataGridView_MouseClick(object sender, MouseEventArgs e)
        {
            var hit = dataGridView.HitTest(e.X, e.Y);
            if (hit.Type == DataGridViewHitTestType.None)
            {
                LoadDataToGrid();
            }
        }

        private async void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            dysfunctionForm.OpenNewForm(new ProjectRegister(dysfunctionForm));
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
            panel3.BackColor = Color.FromArgb(0, 0, 0);
        }

        private async void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            dysfunctionForm.OpenNewForm(new ProjectEdit(dysfunctionForm));
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

        private async void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            dysfunctionForm.OpenNewForm(new ProjectScoreRegister(dysfunctionForm));
            panel3.BorderStyle = BorderStyle.FixedSingle;
            await Task.Delay(100);
            panel3.BorderStyle = BorderStyle.None;
        }

        private void panel3_MouseEnter(object sender, EventArgs e)
        {
            panel3.BackColor = Color.FromArgb(20, 20, 20);
        }

        private void panel3_MouseLeave(object sender, EventArgs e)
        {
            panel3.BackColor = Color.FromArgb(0, 0, 0);
        }

        private void panel5_MouseDown(object sender, MouseEventArgs e)
        {
            string link = buttonLinkProject;
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

        private void dataGridView_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridView.CurrentCell.ColumnIndex == 6)
            {
                dataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6 && e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView.Rows[e.RowIndex];
                bool isChecked = (bool)row.Cells[6].Value;
                string projectName = row.Cells[0].Value.ToString();
                string projectIdentifier = $"{projectName}_{asignatureLogic.ObtainCode(asignatureSelection)}_{projectLogic.deleteSpaces(periodSelection)}_{dateTimePicker.Value.Year}";

                if (isChecked)
                {
                    if (!ProjectOnStartUp.Contains(projectIdentifier))
                    {
                        ProjectOnStartUp.Add(projectIdentifier);
                    }
                }
                else
                {
                    if (ProjectOnStartUp.Contains(projectIdentifier))
                    {
                        ProjectOnStartUp.Remove(projectIdentifier);
                    }
                }

                SaveProjectsSelectionsToXml();
            }
        }

        private void SaveProjectsSelectionsToXml()
        {
            ProjectOnStartUp.Clear();
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (row.Cells[6].Value != null && (bool)row.Cells[6].Value)
                {
                    string projectIdentifier = $"{row.Cells[0].Value}_{asignatureLogic.ObtainCode(asignatureSelection)}_{projectLogic.deleteSpaces(periodSelection)}_{dateTimePicker.Value.Year}";
                    ProjectOnStartUp.Add(projectIdentifier);
                }
            }

            var xml = new XElement("ProjectsOnStartUp",
                ProjectOnStartUp.Select(project => new XElement("Project", project))
            );
            xml.Save(xmlFilePath2);
        }

        private void LoadProjectsSelectionsFromXml()
        {
            if (File.Exists(xmlFilePath2))
            {
                ProjectOnStartUp.Clear();
                var xml = XElement.Load(xmlFilePath2);
                foreach (var element in xml.Elements("Project"))
                {
                    ProjectOnStartUp.Add(element.Value);
                }
            }
        }

        private void dataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                isLeftClickSelection = true;
            }
            else
            {
                isLeftClickSelection = false;
            }

            if (e.RowIndex >= 0 && e.Button == MouseButtons.Right)
            {
                var selectedRow = dataGridView.Rows[e.RowIndex];
                projectName = selectedRow.Cells[0].Value?.ToString();
                asignatureName = asignatureSelection;

                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                    row.DefaultCellStyle.ForeColor = Color.Black;
                }

                selectedRow.DefaultCellStyle.BackColor = Color.FromArgb(95, 100, 100);
                selectedRow.DefaultCellStyle.ForeColor = Color.Black;

                dataGridView.ClearSelection();
                dataGridView.CurrentCell = selectedRow.Cells[e.ColumnIndex];
                selectedRow.Cells[e.ColumnIndex].Selected = true;

                string projectNameLocal = selectedRow.Cells[0].Value.ToString();  // Renombrado para claridad
                string code = asignatureLogic.ObtainCode(asignatureSelection);
                string period = periodSelection;
                int year = dateTimePicker.Value.Year;
                string fileNameBase = $"{projectNameLocal}_{code}_{projectLogic.deleteSpaces(period)}_{year}";
                string targetDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Project", $"{code}_{projectLogic.deleteSpaces(period)}_{year}"); ;
                bool isProjectColumn = (e.ColumnIndex == 0);
                bool hasMultipleFiles = false;

                // Lógica unificada para columna 0 o 1
                if (isProjectColumn)
                {
                    targetDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Project", $"{code}_{projectLogic.deleteSpaces(period)}_{year}");
                    hasMultipleFiles = projectLogic.ProjectExist2(projectNameLocal, code, projectLogic.deleteSpaces(period), year);
                }
                else if (e.ColumnIndex == 1)
                {
                    targetDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Indication", $"{code}_{projectLogic.deleteSpaces(period)}_{year}");
                    hasMultipleFiles = projectLogic.IndicationExist2(projectNameLocal, code, projectLogic.deleteSpaces(period), year);
                }
                else
                {
                    // Para otras columnas, no agregar "Show them all"
                    hasMultipleFiles = false;
                }

                // Crear menú base (común para columna 0 y 1)
                ContextMenuStrip menu = new ContextMenuStrip();
                var editItem = new ToolStripMenuItem("Edit");
                editItem.Click += (s, args) => { dysfunctionForm.OpenNewForm(new ProjectEdit(dysfunctionForm)); };
                menu.Items.Add(editItem);

                // Agregar "Convert To PDF" solo para proyectos (columna 0) si hay .docx
                if (isProjectColumn && Directory.Exists(targetDirectory))
                {
                    string[] docxFiles = Directory.GetFiles(targetDirectory, $"{fileNameBase}.docx");
                    if (docxFiles.Length > 0)
                    {
                        var convertItem = new ToolStripMenuItem("Convert To PDF");
                        convertItem.Click += toolStripMenuItemReady;
                        menu.Items.Add(convertItem);
                    }
                }
                hasMultipleFiles = true;
                // Agregar "Show them all" si hay múltiples archivos (para columna 0 o 1)
                if ((isProjectColumn || e.ColumnIndex == 1) && hasMultipleFiles && Directory.Exists(targetDirectory))
                {
                    var openCarpet = new ToolStripMenuItem("Show them all");
                    openCarpet.Click += (s, args) =>
                    {
                        try
                        {
                            dataGridView.ClearSelection();

                            foreach (DataGridViewRow row in dataGridView.Rows)
                            {
                                row.DefaultCellStyle.BackColor = Color.White;
                                row.DefaultCellStyle.ForeColor = Color.Black;
                            }
                            label5.Focus();

                            Process.Start("explorer.exe", targetDirectory);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error opening folder: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    };
                    menu.Items.Add(openCarpet);
                }

                // Mostrar el menú (solo si es columna 0 o 1; para otras, manejar por separado)
                if (isProjectColumn || e.ColumnIndex == 1)
                {
                    var position = dataGridView.PointToScreen(dataGridView.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).Location);
                    position.X += e.X;
                    position.Y += e.Y;
                    menu.Show(position);
                }
                else if (e.ColumnIndex == 4)
                {
                    // Menú para columna 4 (Score) - sin cambios
                    ContextMenuStrip scoreMenu = new ContextMenuStrip();
                    var editItemScore = new ToolStripMenuItem("Edit");
                    editItemScore.Click += (s, args) => { dysfunctionForm.OpenNewForm(new ProjectEdit(dysfunctionForm)); };
                    scoreMenu.Items.Add(editItemScore);

                    var gradesItem = new ToolStripMenuItem("Grades");
                    gradesItem.Click += (s, args) => { dysfunctionForm.OpenNewForm(new ProjectScoreRegister(dysfunctionForm)); };
                    scoreMenu.Items.Add(gradesItem);

                    var position = dataGridView.PointToScreen(dataGridView.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).Location);
                    position.X += e.X;
                    position.Y += e.Y;
                    scoreMenu.Show(position);
                }
                else
                {
                    // Menú genérico para otras columnas - sin cambios
                    ContextMenuStrip otherMenu = new ContextMenuStrip();
                    var otherItem = new ToolStripMenuItem("Edit");
                    otherItem.Click += (s, args) => { dysfunctionForm.OpenNewForm(new ProjectEdit(dysfunctionForm)); };
                    otherMenu.Items.Add(otherItem);

                    var position = dataGridView.PointToScreen(dataGridView.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).Location);
                    position.X += e.X;
                    position.Y += e.Y;
                    otherMenu.Show(position);
                }
            }
        }

        private void CreateCellContextMenu()
        {
            cellContextMenu = new ContextMenuStrip();
            var openItem = new ToolStripMenuItem("Convert To PDF");
            openItem.Click += toolStripMenuItemReady;
            cellContextMenu.Items.Add(openItem);
        }

        private void toolStripMenuItemReady(object sender, EventArgs e)
        {
            if (dataGridView.CurrentCell != null && dataGridView.CurrentCell.RowIndex >= 0)
            {
                var selectedRow = dataGridView.Rows[dataGridView.CurrentCell.RowIndex];
                string projectName = selectedRow.Cells[0].Value?.ToString();

                if (!string.IsNullOrEmpty(projectName))
                {
                    string code = asignatureLogic.ObtainCode(asignatureSelection);
                    string period = periodSelection;
                    int year = dateTimePicker.Value.Year;
                    string fileNameBase = $"{projectName}_{code}_{projectLogic.deleteSpaces(period)}_{year}";
                    string projectDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Project", $"{code}_{projectLogic.deleteSpaces(period)}_{year}");

                    if (Directory.Exists(projectDirectory))
                    {
                        string[] matchingFiles = Directory.GetFiles(projectDirectory, $"{fileNameBase}.*");
                        if (matchingFiles.Length > 0)
                        {
                            string sourceFile = matchingFiles[0];
                            if (Path.GetExtension(sourceFile).Equals(".docx", StringComparison.OrdinalIgnoreCase))
                            {
                                SaveFileDialog saveFileDialog = new SaveFileDialog();
                                saveFileDialog.Filter = "PDF Files (*.pdf)|*.pdf";
                                saveFileDialog.Title = "Save PDF File";
                                saveFileDialog.FileName = $"{projectLogic.deleteSpaces(dysfunctionForm.userName)}_{projectName}_{code}.pdf";
                                saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                                {
                                    try
                                    {
                                        string tempFile = Path.Combine(Path.GetTempPath(), Path.GetFileName(sourceFile));
                                        File.Copy(sourceFile, tempFile, true);
                                        ConvertDocxToPdf(tempFile, saveFileDialog.FileName);
                                        File.Delete(tempFile);

                                        dataGridView.ClearSelection();

                                        foreach (DataGridViewRow row in dataGridView.Rows)
                                        {
                                            row.DefaultCellStyle.BackColor = Color.White;
                                            row.DefaultCellStyle.ForeColor = Color.Black;
                                        }
                                        label5.Focus();
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show($"Error converting file: {ex.Message}", "Error",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("The selected file is not a DOCX document.", "Information",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
        }

        private void ConvertDocxToPdf(string sourcePath, string destinationPath)
        {
            Microsoft.Office.Interop.Word.Application wordApp = null;
            Microsoft.Office.Interop.Word.Document doc = null;

            try
            {
                wordApp = new Microsoft.Office.Interop.Word.Application();
                wordApp.Visible = false;
                doc = wordApp.Documents.Open(sourcePath);
                doc.SaveAs2(destinationPath, Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatPDF);
            }
            finally
            {
                if (doc != null)
                {
                    doc.Close(false);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(doc);
                }

                if (wordApp != null)
                {
                    wordApp.Quit();
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(wordApp);
                }
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            
        }

        private void OpenIndicationsOnStartup()
        {
            string indicationDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Indication");
            foreach (var projectIdentifier in ProjectOnStartUp)
            {
                // Parse projectIdentifier: Project_Code_Period_Year
                var parts = projectIdentifier.Split('_');
                if (parts.Length < 4) continue;
                string project = parts[0];
                string code = parts[1];
                string period = parts[2];
                string year = parts[3];

                string fileNameBase = $"Indication_{project}_{code}_{projectLogic.deleteSpaces(period)}_{year}";
                string targetDirectory = Path.Combine(indicationDirectory, $"{code}_{projectLogic.deleteSpaces(period)}_{year}");

                if (Directory.Exists(targetDirectory))
                {
                    string[] matchingFiles = Directory.GetFiles(targetDirectory, $"{fileNameBase}.*");
                    if (matchingFiles.Length > 0)
                    {
                        try
                        {
                            Process.Start(new ProcessStartInfo(matchingFiles[0]) { UseShellExecute = true });
                        }
                        catch
                        {
                            Process.Start("explorer.exe", $"/select, \"{matchingFiles[0]}\"");
                        }
                    }
                }
            }
        }
    }
}