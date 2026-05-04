using Dysfunction.GUI.Consult;
using Dysfunction.GUI.Register;
using Dysfunction.Logic;
using Dysfunction.Model;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Forms;


namespace Dysfunction.GUI
{
    public partial class PeriodEdit : Form
    {
        periodLogic periodLogic = new periodLogic();
        asignatureLogic asignatureLogic = new asignatureLogic();
        projectLogic projectLogic = new projectLogic();
        private Dysfunction dysfunctionForm;
        string periodSelection;
        string asignatureSelection;
        int comboBoxAsignatureIndex;
        private List<string> tempPDFPathsOri = new List<string>();
        private List<string> tempPDFPathsMat = new List<string>();
        static public bool cache = false;
        int contador = 0;
        Dictionary<string, List<string>> pdfOri = new Dictionary<string, List<string>>();
        Dictionary<string, List<string>> pdfMat = new Dictionary<string, List<string>>();
        bool picked1 = false;
        bool picked2 = false;
        int pickedwfile1 = 0;
        int pickedwfile2 = 0;
        int existingOriCount = 0;
        int existingMatCount = 0;
        private List<string> pendingDeleteOri = new List<string>();
        private List<string> pendingDeleteMat = new List<string>();

        public PeriodEdit(Dysfunction dysfunction)
        {
            InitializeComponent();
            dysfunctionForm = dysfunction;
            Thread.CurrentThread.CurrentCulture = CultureInfo.CurrentCulture;
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CurrentCulture;

            FullCombo();
            FullCombo1();
            hide();
            panelPlus1.Hide();
            panelPlus2.Hide();
            picturePlus1.Hide();
            picturePlus2.Hide();
        }

        private void hide()
        {
            labelPeriod.Visible = false;
            labelAsignature.Visible = false;

            if (listBox.Items.Count < 1)
            {
                panel8.Visible = false;
            }
        }
        private void FullCombo()
        {

            comboBoxPeriod.Items.Clear();
            List<periodModel> periodModels = periodLogic.Consult();


            foreach (var period in periodModels)
            {
                if (period != null && period.Year == dateTimePicker.Value.Year)
                {
                    comboBoxPeriod.Items.Add(period.Period);
                    labelPeriod.Visible = false;
                    comboBoxPeriod.SelectedIndex = 0;
                }
            }


        }
        private void FullCombo1()
        {
            comboBoxAsignature.Items.Clear();
            List<asignatureModel> asignatureModels = asignatureLogic.Consult();

            // Obtener nombres de asignaturas existentes en el ListBox
            List<string> existingAsignatures = listBox.Items.Cast<string>()
                .Select(item =>
                {
                    string[] parts = item.Split(new[] { " - " }, StringSplitOptions.None);
                    return parts.Length > 1 ? parts[1] : "";
                })
                .Where(name => !string.IsNullOrEmpty(name))
                .ToList();

            foreach (var model in asignatureModels)
            {
                if (model != null && model.Approved == false && !existingAsignatures.Contains(model.Asignature))
                {
                    comboBoxAsignature.Items.Add(model.Asignature);
                }
            }

            if (comboBoxAsignature.Items.Count > 0)
            {
                comboBoxAsignature.SelectedIndex = 0;
                asignatureSelection = comboBoxAsignature.SelectedItem?.ToString();
            }
            else
            {
                labelAsignature.Visible = true;
            }
        }
        private async void buttonSave_Click(object sender, EventArgs e)
        {
            if (periodLogic.ValidNotNull(periodSelection) && listBox.Items.Count > 0)
            {


                // Obtener los códigos de las materias seleccionadas
                List<string> codes = listBox.Items.Cast<string>()
                .Select(item => item.Split(new[] { " - " }, StringSplitOptions.None)[0])
                .ToList();

                // Obtener el periodo actual
                List<periodModel> periodModels = periodLogic.Consult();
                var filteredPeriods = periodModels.FirstOrDefault(p => p.Period == periodSelection && p.Year == dateTimePicker.Value.Year);

                if (filteredPeriods != null)
                {
                    // Comparar las materias actuales con las seleccionadas
                    foreach (var code in filteredPeriods.Asignatures.ToList()) // Usar ToList() para evitar modificar la colección mientras se itera
                    {
                        if (!codes.Contains(code))
                        {
                            // Eliminar proyectos asociados a materias que ya no están en el periodo
                            projectLogic.DeleteSpecs(dateTimePicker.Value.Year, periodSelection, code);
                            projectLogic.DeletePros(code, periodSelection, dateTimePicker.Value.Year);
                            projectLogic.DeleteInds(code, periodSelection, dateTimePicker.Value.Year);
                            periodLogic.DeleteOriFile(code, periodSelection, dateTimePicker.Value.Year);
                            periodLogic.DeleteMatFile(code, periodSelection, dateTimePicker.Value.Year);

                        }
                    }

                    // Actualizar el periodo con las nuevas materias seleccionadas
                    filteredPeriods.StartDate = dateTimePickerStartDate.Value;
                    filteredPeriods.EndDate = dateTimePickerEndDate.Value;
                    filteredPeriods.Asignatures = codes; // Actualizar la lista de materias
                    dateTimePickerStartDate.Enabled = false;
                    dateTimePickerEndDate.Enabled = false;

                    // Guardar los cambios en el periodo
                    periodLogic.EditObject(filteredPeriods);

                    // Guardar los PDFs asociados a las materias
                    foreach (var code in codes)
                    {
                        if (pdfOri.ContainsKey(code) && pdfOri[code] != null && pdfOri[code].Count > 0)
                        {
                            periodLogic.SaveOri(code, periodSelection, dateTimePickerStartDate.Value.Year, pdfOri[code]);
                        }

                        if (pdfMat.ContainsKey(code) && pdfMat[code] != null && pdfMat[code].Count > 0)
                        {
                            periodLogic.SaveMat(code, periodSelection, dateTimePickerStartDate.Value.Year, pdfMat[code]);
                        }
                    }

                    // Elimina archivos pendientes antes de guardar los nuevos
                    foreach (var code in pendingDeleteOri)
                    {
                        periodLogic.DeleteOriFile(code, periodSelection, dateTimePicker.Value.Year);
                    }
                    foreach (var code in pendingDeleteMat)
                    {
                        periodLogic.DeleteMatFile(code, periodSelection, dateTimePicker.Value.Year);
                    }
                    pendingDeleteOri.Clear();
                    pendingDeleteMat.Clear();

                    // Limpiar las listas y controles
                    codes.Clear();
                    pdfOri.Clear();
                    pdfMat.Clear();
                    listBox.Items.Clear();
                    labelPeriod.Visible = false;
                    listBox.Visible = false;
                    labelList.Visible = false;

                    buttonEdit.ForeColor = Color.White;
                    FullCombo();
                    comboBoxAsignature.Items.Clear();
                    FullCombo1();
                    comboBoxPeriod.SelectedIndex = -1;
                    dateTimePicker.Value = DateTime.Now;
                    dateTimePickerStartDate.Value = DateTime.Now;
                    dateTimePickerEndDate.Value = DateTime.Now;

                    // Mostrar mensaje de éxito
                    buttonEdit.ForeColor = Color.LightGreen;
                    buttonEdit.Text = "Saved";
                    await Task.Delay(1);
                    labelAsignature.Visible = false;
                    await Task.Delay(2000);
                    buttonEdit.ForeColor = Color.White;
                    buttonEdit.Text = "Save Edit";
                    picked1 = false;
                    picked2 = false;
                }
            }
            else
            {
                // Mostrar mensajes de error si no se cumplen las validaciones
                buttonEdit.ForeColor = Color.Red;
                if (!periodLogic.ValidNotNull(comboBoxAsignature.Text))
                {
                    labelPeriod.Visible = true;
                }
                if (!periodLogic.ValidNotNull(periodSelection))
                {
                    labelAsignature.Visible = true;
                }
                if (listBox.Items.Count <= 0)
                {
                    buttonAdd.FlatAppearance.BorderColor = Color.White;
                    await Task.Delay(100);
                    buttonAdd.FlatAppearance.BorderColor = Color.FromArgb(64, 64, 64);
                    await Task.Delay(100);
                    buttonAdd.FlatAppearance.BorderColor = Color.White;
                    await Task.Delay(100);
                    buttonAdd.FlatAppearance.BorderColor = Color.FromArgb(64, 64, 64);
                    await Task.Delay(100);
                    buttonAdd.FlatAppearance.BorderColor = Color.White;
                    await Task.Delay(100);
                    buttonAdd.FlatAppearance.BorderColor = Color.FromArgb(64, 64, 64);
                    await Task.Delay(100);
                    buttonAdd.FlatAppearance.BorderColor = Color.White;
                    await Task.Delay(100);
                    buttonAdd.FlatAppearance.BorderColor = Color.FromArgb(64, 64, 64);
                    await Task.Delay(1500);
                    buttonEdit.ForeColor = Color.White;
                }
            }
        }
        private async void buttonDelete_Click(object sender, EventArgs e)
        {
            if (periodLogic.ValidNotNull(periodSelection))
            {

                contador++;
                if (contador == 1)
                {
                    buttonDelete.ForeColor = Color.Yellow;
                    buttonDelete.FlatAppearance.MouseOverBackColor = Color.Black;
                    buttonDelete.Text = "Are you sure? Click again";
                    buttonDelete.FlatAppearance.BorderColor = Color.White;
                    await Task.Delay(100);
                    buttonDelete.FlatAppearance.BorderColor = Color.FromArgb(64, 64, 64);
                    await Task.Delay(100);
                    buttonDelete.FlatAppearance.BorderColor = Color.White;
                    await Task.Delay(100);
                    buttonDelete.FlatAppearance.BorderColor = Color.FromArgb(64, 64, 64);
                    await Task.Delay(100);
                    buttonDelete.FlatAppearance.BorderColor = Color.White;
                    await Task.Delay(100);
                    buttonDelete.FlatAppearance.BorderColor = Color.FromArgb(64, 64, 64);

                }
                if (contador == 2)
                {
                    contador = 0;
                    List<periodModel> periodModels = periodLogic.Consult();
                    var filteredPeriods = periodModels.FirstOrDefault(p => p.Period == periodSelection && p.Year == dateTimePicker.Value.Year);

                    if (filteredPeriods != null)
                    {
                        foreach (var asignature in filteredPeriods.Asignatures)
                        {
                            string code = asignatureLogic.ObtainCode(asignature);
                            projectLogic.DeleteSpecs(dateTimePicker.Value.Year, periodSelection, code);
                            projectLogic.DeletePros(code, periodSelection, dateTimePicker.Value.Year);
                            projectLogic.DeleteInds(code, periodSelection, dateTimePicker.Value.Year);
                            periodLogic.DeleteOriFile(code, periodSelection, dateTimePicker.Value.Year);
                            periodLogic.DeleteMatFile(code, periodSelection, dateTimePicker.Value.Year);

                        }
                        projectLogic.DeleteAllProsForPeriod(periodSelection, dateTimePicker.Value.Year);
                        projectLogic.DeleteAllIndsForPeriod(periodSelection, dateTimePicker.Value.Year);
                        periodLogic.DeleteObject(filteredPeriods);

                        comboBoxPeriod.SelectedIndex = -1;
                        dateTimePicker.Value = DateTime.Now;
                        dateTimePickerStartDate.Value = DateTime.Now;
                        dateTimePickerEndDate.Value = DateTime.Now;
                        FullCombo();
                        buttonDelete.Text = "Deleted";
                        buttonDelete.ForeColor = Color.LightGreen;
                        dateTimePickerStartDate.Enabled = false;
                        dateTimePickerEndDate.Enabled = false;
                        picked1 = false;
                        picked2 = false;
                        if (listBox.Items.Count > 0)
                        {
                            panel8.Visible = true;
                        }
                        await Task.Delay(2000);
                        buttonDelete.ForeColor = Color.White;
                        buttonDelete.FlatAppearance.MouseOverBackColor = Color.FromArgb(20, 20, 20);
                        buttonDelete.Text = "Delete";
                        await Task.Delay(10);
                        labelAsignature.Visible = false;

                    }
                }
            }
            else
            {

                buttonDelete.ForeColor = Color.Red;

                labelPeriod.Visible = true;
                await Task.Delay(2000);
                buttonDelete.ForeColor = Color.White;
            }
        }
        private async void buttonAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(asignatureSelection) && !string.IsNullOrEmpty(periodSelection))
            {
                panel8.Visible = true;
                buttonEdit.ForeColor = Color.White;
                buttonDelete.ForeColor = Color.White;
                labelPDFOri.Text = "Select or Drag a File ";
                labelPDFMat.Text = "Select or Drag a File ";
                picked1 = false;
                picked2 = false;
                panelPlus1.Hide();
                panelPlus2.Hide();
                picturePlus1.Hide();
                picturePlus2.Hide();
                string asignatureSelected = comboBoxAsignature.SelectedItem?.ToString();
                string asignatureCode = asignatureLogic.ObtainCode(asignatureSelected);

                if (!string.IsNullOrEmpty(asignatureSelected) && !listBox.Items.Contains(asignatureSelected))
                {
                    comboBoxAsignatureIndex = comboBoxAsignature.SelectedIndex;
                    string item = asignatureCode + " - " + asignatureSelected;

                    if (!listBox.Items.Contains(item))
                    { listBox.Items.Add(item); }

                    string oriPath = tempPDFPathsOri.Count == 0 ? "null" : string.Join(";", tempPDFPathsOri);
                    string matPath = tempPDFPathsMat.Count == 0 ? "null" : string.Join(";", tempPDFPathsMat);

                    pdfOri[asignatureCode] = tempPDFPathsOri.Count > 0 ? new List<string>(tempPDFPathsOri) : null;
                    pdfMat[asignatureCode] = tempPDFPathsMat.Count > 0 ? new List<string>(tempPDFPathsMat) : null;

                    comboBoxAsignature.Items.Remove(asignatureSelected);

                    if (comboBoxAsignature.Items.Count > 0)
                    {
                        comboBoxAsignature.SelectedIndex = Math.Min(comboBoxAsignatureIndex, comboBoxAsignature.Items.Count - 1);
                    }
                    else
                    {
                        comboBoxAsignature.SelectedIndex = -1;
                    }
                }

                tempPDFPathsOri.Clear();
                tempPDFPathsMat.Clear();
            }
            else
            {

                labelAsignature.Visible = true;

                if (comboBoxPeriod.Items.Count > 0)
                {
                    labelPeriod.Visible = true;
                }

                buttonAdd.ForeColor = Color.Red;
                await Task.Delay(2000);
                buttonAdd.ForeColor = Color.White;
            }
        }
        private void listBox_MouseClick(object sender, MouseEventArgs e)
        {
            int index = listBox.IndexFromPoint(e.Location);
            buttonEdit.ForeColor = Color.White;
            buttonDelete.ForeColor = Color.White;
            if (index != ListBox.NoMatches)
            {
                string deletedAsignature = listBox.Items[index].ToString();
                string[] parts = deletedAsignature.Split(new[] { " - " }, StringSplitOptions.None);

                if (parts.Length > 1)
                {
                    string asignatureCode = parts[0];
                    listBox.Items.RemoveAt(index);

                    if (pdfOri.ContainsKey(asignatureCode))
                    {
                        pdfOri.Remove(asignatureCode);
                    }
                    if (pdfMat.ContainsKey(asignatureCode))
                    {
                        pdfMat.Remove(asignatureCode);
                    }

                    string asignatureName = parts[1];
                    if (!comboBoxAsignature.Items.Contains(asignatureName))
                    {
                        if (comboBoxAsignatureIndex >= 0 && comboBoxAsignatureIndex <= comboBoxAsignature.Items.Count)
                        {
                            comboBoxAsignature.Items.Insert(comboBoxAsignatureIndex, asignatureName);
                            comboBoxAsignature.SelectedIndex = comboBoxAsignatureIndex;
                        }
                        else
                        {
                            comboBoxAsignature.Items.Add(asignatureName);
                            comboBoxAsignature.SelectedIndex = comboBoxAsignature.Items.Count - 1;
                        }
                    }
                }
            }

            if (listBox.Items.Count < 1)
            {
                panel8.Visible = false;
            }
        }
        private void comboBoxPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox.Items.Clear();
            buttonEdit.ForeColor = Color.White;
            buttonDelete.ForeColor = Color.White;
            periodSelection = comboBoxPeriod.SelectedItem?.ToString();

            List<periodModel> periodModels = periodLogic.Consult();
            var filteredPeriods = periodModels.FirstOrDefault(p => p.Period == periodSelection && p.Year == dateTimePicker.Value.Year);
            if (filteredPeriods != null)
            {
                dateTimePickerStartDate.Enabled = true;
                dateTimePickerEndDate.Enabled = true;
                dateTimePickerStartDate.Value = filteredPeriods.StartDate;
                dateTimePickerEndDate.Value = filteredPeriods.EndDate;

                // Load existing files into dictionaries if Asignatures is not null
                if (filteredPeriods.Asignatures != null)
                {
                    foreach (var asignature in filteredPeriods.Asignatures)
                    {
                        string code = asignature;  // Assuming 'asignature' is the code here
                        var existingOri = periodLogic.GetExistingOriFiles(code, periodSelection, dateTimePicker.Value.Year);
                        pdfOri[code] = existingOri.Count > 0 ? new List<string>(existingOri) : null;

                        var existingMat = periodLogic.GetExistingMatFiles(code, periodSelection, dateTimePicker.Value.Year);
                        pdfMat[code] = existingMat.Count > 0 ? new List<string>(existingMat) : null;
                    }
                }
            }
            else
            {
                dateTimePickerStartDate.Enabled = false;
            }

            List<string> asignaturesInPeriod = new List<string>();

            foreach (var period in periodModels)
            {
                if (period != null && period.Year == dateTimePicker.Value.Year && period.Period == periodSelection)
                {
                    if (period.Asignatures != null && period.Asignatures.Count > 0)
                    {
                        foreach (var asignature in period.Asignatures)
                        {
                            string asignatureName = asignatureLogic.ObtainName(asignature);

                            if (!listBox.Items.Contains(asignatureName))
                            {
                                listBox.Items.Add(asignatureLogic.ObtainCode(asignatureName) + " - " + asignatureName);
                                asignaturesInPeriod.Add(asignatureName);
                            }
                        }
                    }
                }
            }

            FullCombo1();

            foreach (var asignatureInPeriod in asignaturesInPeriod)
            {
                if (comboBoxAsignature.Items.Contains(asignatureInPeriod))
                {
                    comboBoxAsignature.Items.Remove(asignatureInPeriod);
                }
            }
            if (comboBoxAsignature.Items.Count > 0)
            {
                comboBoxAsignature.SelectedIndex = 0;
            }

            listBox.Visible = true;
            labelList.Visible = true;
        }
        private void panel1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            tempPDFPathsOri.Clear();
            tempPDFPathsOri.AddRange(files);
            if (tempPDFPathsOri.Count == 1)
            {
                labelPDFOri.Text = periodLogic.GetShortenedFileName(Path.GetFileName(tempPDFPathsOri[0]));
            }
            else if (tempPDFPathsOri.Count > 1)
            {
                labelPDFOri.Text = $"{periodLogic.GetShortenedFileName(Path.GetFileName(tempPDFPathsOri[0]))} and {tempPDFPathsOri.Count - 1} more";
            }
            else
            {
                labelPDFOri.Text = "Select or Drag a File ";
            }
            picked1 = true;
            buttonEdit.ForeColor = Color.White;
            panelPlus1.Show();
            picturePlus1.Show();

        }
        private void panel2_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            tempPDFPathsMat.Clear();
            tempPDFPathsMat.AddRange(files);

            if (tempPDFPathsMat.Count == 1)
            {
                labelPDFMat.Text = periodLogic.GetShortenedFileName(Path.GetFileName(tempPDFPathsMat[0]));
            }
            else if (tempPDFPathsMat.Count > 1)
            {
                labelPDFMat.Text = $"{periodLogic.GetShortenedFileName(Path.GetFileName(tempPDFPathsMat[0]))} and {tempPDFPathsMat.Count - 1} more";
            }
            else
            {
                labelPDFMat.Text = "Select or Drag a File ";
            }
            picked2 = true;
            buttonEdit.ForeColor = Color.White;
            panelPlus2.Show();
            picturePlus2.Show();
        }
        private void panel_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files.Length > 0)
                {
                    e.Effect = DragDropEffects.Copy;
                }
                else
                {
                    e.Effect = DragDropEffects.None;
                }
            }

        }
        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            buttonDelete.ForeColor = Color.White;
            buttonEdit.ForeColor = Color.White;
            FullCombo();

            // If a period is selected, update everything as if the period changed
            if (comboBoxPeriod.SelectedIndex >= 0)
            {
                comboBoxPeriod_SelectedIndexChanged(comboBoxPeriod, EventArgs.Empty);
            }
            else
            {
                // Optionally clear controls if no period is selected
                listBox.Items.Clear();
                listBox.Visible = false;
                labelList.Visible = false;
                dateTimePickerStartDate.Enabled = false;
                dateTimePickerEndDate.Enabled = false;
                comboBoxAsignature.Items.Clear();
                labelAsignature.Visible = true;
            }
        }
        private void dateTimePickerStartDate_ValueChanged(object sender, EventArgs e)
        {
            FullCombo();
            if (dateTimePickerStartDate.Value < dateTimePickerEndDate.Value)
            {
                dateTimePickerStartDate.Value = dateTimePickerEndDate.Value;
            }
            buttonEdit.ForeColor = Color.White;
            buttonDelete.ForeColor = Color.White;
        }
        private void dateTimePickerEndDate_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePickerStartDate.Value < dateTimePickerEndDate.Value)
            {
                dateTimePickerEndDate.Value = dateTimePickerStartDate.Value;
            }
            buttonEdit.ForeColor = Color.White;
            buttonDelete.ForeColor = Color.White;
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            dysfunctionForm.OpenNewForm(new PeriodConsult(dysfunctionForm));
        }
        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.FromArgb(20, 20, 20);

        }
        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.FromArgb(0, 0, 0);
        }
        private void ProjectRegister_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.FromArgb(0, 0, 0);
        }
        private void panel5_MouseDown(object sender, MouseEventArgs e)
        {
            dysfunctionForm.OpenNewForm(new AsignatureRegister(dysfunctionForm, true));
        }
        private void panel5_MouseEnter(object sender, EventArgs e)
        {
            panel5.BackColor = Color.FromArgb(20, 20, 20);
        }
        private void panel5_MouseLeave(object sender, EventArgs e)
        {
            panel5.BackColor = Color.FromArgb(0, 0, 0);
        }
        private void panel7_MouseDown(object sender, MouseEventArgs e)
        {
            dysfunctionForm.OpenNewForm(new AsignatureEdit(dysfunctionForm, true));

        }
        private void panel7_MouseEnter(object sender, EventArgs e)
        {
            panel7.BackColor = Color.FromArgb(20, 20, 20);
        }
        private void panel7_MouseLeave(object sender, EventArgs e)
        {
            panel7.BackColor = Color.FromArgb(0, 0, 0);
        }
        private void PeriodRegister_MouseEnter(object sender, EventArgs e)
        {
            panel5.BackColor = Color.FromArgb(0, 0, 0);
            panel7.BackColor = Color.FromArgb(0, 0, 0);
        }
        private void CenterControl(Control ctrl)
        {
            ctrl.Left = (this.ClientSize.Width - ctrl.Width) / 2;
            ctrl.Top = (this.ClientSize.Height - ctrl.Height) / 2;  // Mueve 30 píxeles arriba
        }
        private void PeriodEdit_Resize(object sender, EventArgs e)
        {
            CenterControl(panel4);
        }

        private void comboBoxAsignature_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonEdit.ForeColor = Color.White;
            buttonDelete.ForeColor = Color.White;
            if (comboBoxAsignature.Items.Count > 0)
            {
                asignatureSelection = comboBoxAsignature.SelectedItem?.ToString();
                labelAsignature.Visible = false;
            }
            if (periodLogic.oriExist(asignatureLogic.ObtainCode(asignatureSelection), periodSelection, dateTimePicker.Value.Year))
            {
                periodLogic.GetExistingOriFiles(asignatureLogic.ObtainCode(asignatureSelection), periodSelection, dateTimePicker.Value.Year);

                tempPDFPathsOri = periodLogic.GetExistingOriFiles(asignatureLogic.ObtainCode(asignatureSelection), periodSelection, dateTimePicker.Value.Year);
                existingOriCount = tempPDFPathsOri.Count;  // Nuevo: rastrea cuántos son existentes
                if (tempPDFPathsOri.Count == 1)
                {
                    labelPDFOri.Text = periodLogic.GetShortenedFileName(Path.GetFileName(tempPDFPathsOri[0]));
                    panelPlus1.Show();
                    picturePlus1.Show();
                }
                else if (tempPDFPathsOri.Count > 1)
                {
                    labelPDFOri.Text = $"{periodLogic.GetShortenedFileName(Path.GetFileName(tempPDFPathsOri[0]))} and {tempPDFPathsOri.Count - 1} more";
                    panelPlus1.Show();
                    picturePlus1.Show();
                }
                else
                {
                    labelPDFOri.Text = "Select or Drag a File ";
                    panelPlus1.Hide();
                    picturePlus1.Hide();
                }
                picked1 = true;
                pickedwfile1 = 1;
            }
            else
            {
                existingOriCount = 0;  // Nuevo: si no existen, contador en 0
            }

            if (periodLogic.matExist(asignatureLogic.ObtainCode(asignatureSelection), periodSelection, dateTimePicker.Value.Year))
            {
                periodLogic.GetExistingMatFiles(asignatureLogic.ObtainCode(asignatureSelection), periodSelection, dateTimePicker.Value.Year);
                tempPDFPathsMat = periodLogic.GetExistingMatFiles(asignatureLogic.ObtainCode(asignatureSelection), periodSelection, dateTimePicker.Value.Year);
                existingMatCount = tempPDFPathsMat.Count;  // Nuevo: mismo para Mat
                if (tempPDFPathsMat.Count == 1)
                {
                    labelPDFMat.Text = periodLogic.GetShortenedFileName(Path.GetFileName(tempPDFPathsMat[0]));
                    panelPlus2.Show();
                    picturePlus2.Show();
                }
                else if (tempPDFPathsMat.Count > 1)
                {
                    labelPDFMat.Text = $"{periodLogic.GetShortenedFileName(Path.GetFileName(tempPDFPathsMat[0]))} and {tempPDFPathsMat.Count - 1} more";
                    panelPlus2.Show();
                    picturePlus2.Show();
                }
                else
                {
                    labelPDFMat.Text = "Select or Drag a File ";
                    panelPlus2.Hide();
                    picturePlus2.Hide();
                }
                picked2 = true;
                pickedwfile2 = 1;
            }
            else
            {
                existingMatCount = 0;  // Nuevo
            }
        }
        private void panel1_Click(object sender, EventArgs e)
        {
            if (!picked1)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Filter = "All Files|*.*",
                    Multiselect = true
                };

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    tempPDFPathsOri.AddRange(openFileDialog.FileNames);
                    if (tempPDFPathsOri.Count == 1)
                    {
                        labelPDFOri.Text = periodLogic.GetShortenedFileName(Path.GetFileName(tempPDFPathsOri[0]));
                    }
                    else if (tempPDFPathsOri.Count > 1)
                    {
                        labelPDFOri.Text = $"{periodLogic.GetShortenedFileName(Path.GetFileName(tempPDFPathsOri[0]))} and {tempPDFPathsOri.Count - 1} more";
                    }
                    else
                    {
                        labelPDFOri.Text = "Select or Drag a File ";
                    }
                    picked1 = true;
                    buttonAdd.ForeColor = Color.White;
                    buttonEdit.ForeColor = Color.White;
                    panelPlus1.Show();
                    picturePlus1.Show();
                }
            }
            else
            {
                // Eliminado: el if (tempPDFPathsOri.Count > 0) { update label... } redundante

                buttonAdd.ForeColor = Color.White;
                buttonEdit.ForeColor = Color.White;

                if (pickedwfile1 < 2)
                {
                    panel1.BackColor = Color.FromArgb(255, 255, 255);
                    labelPDFOri.ForeColor = Color.FromArgb(0, 0, 0);
                    labelPDFOri.Text = "Are you sure? Click again";
                    pickedwfile1 = 2;
                    return;
                }
                pickedwfile1 = 1;
                if (tempPDFPathsOri.Count > 0)
                {
                    tempPDFPathsOri.RemoveAt(tempPDFPathsOri.Count - 1);
                    panel1.BackColor = Color.FromArgb(20, 20, 20);
                    labelPDFOri.ForeColor = Color.FromArgb(255, 255, 255);
                    // Actualiza etiqueta y estado basado en el nuevo conteo
                    if (tempPDFPathsOri.Count > 0)
                    {
                        if (tempPDFPathsOri.Count == 1)
                        {
                            labelPDFOri.Text = periodLogic.GetShortenedFileName(Path.GetFileName(tempPDFPathsOri[0]));
                        }
                        else
                        {
                            labelPDFOri.Text = $"{periodLogic.GetShortenedFileName(Path.GetFileName(tempPDFPathsOri[0]))} and {tempPDFPathsOri.Count - 1} more";
                        }
                        panelPlus1.Show();
                        picturePlus1.Show();
                        picked1 = true;
                    }
                    else
                    {
                        labelPDFOri.Text = "Select or Drag a File ";
                        picked1 = false;
                        panelPlus1.Hide();
                        picturePlus1.Hide();
                    }

                    // Nuevo: solo borra de DB si se eliminó un existente
                    if (existingOriCount > 0 && tempPDFPathsOri.Count < existingOriCount)
                    {
                        pendingDeleteOri.Add(asignatureLogic.ObtainCode(asignatureSelection));
                        existingOriCount--;
                    }
                }
            }
        }


        private void panel2_Click(object sender, EventArgs e)
        {
            if (!picked2)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Filter = "All Files|*.*",
                    Multiselect = true
                };

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    tempPDFPathsMat.AddRange(openFileDialog.FileNames);
                    if (tempPDFPathsMat.Count == 1)
                    {
                        labelPDFMat.Text = periodLogic.GetShortenedFileName(Path.GetFileName(tempPDFPathsMat[0]));
                    }
                    else if (tempPDFPathsMat.Count > 1)
                    {
                        labelPDFMat.Text = $"{periodLogic.GetShortenedFileName(Path.GetFileName(tempPDFPathsMat[0]))} and {tempPDFPathsMat.Count - 1} more";
                    }
                    else
                    {
                        labelPDFMat.Text = "Select or Drag a File ";
                    }
                    picked2 = true;
                    buttonAdd.ForeColor = Color.White;
                    buttonEdit.ForeColor = Color.White;
                    panelPlus2.Show();
                    picturePlus2.Show();
                }
            }
            else
            {
                // Eliminado: el if redundante al inicio

                buttonAdd.ForeColor = Color.White;
                buttonEdit.ForeColor = Color.White;

                if (pickedwfile2 < 2)
                {
                    panel2.BackColor = Color.FromArgb(20, 20, 20);
                    labelPDFMat.ForeColor = Color.FromArgb(0, 0, 0);
                    labelPDFMat.Text = "Are you sure? Click again";
                    pickedwfile2 = 2;
                    return;
                }
                pickedwfile2 = 1;
                if (tempPDFPathsMat.Count > 0)
                {
                    tempPDFPathsMat.RemoveAt(tempPDFPathsMat.Count - 1);

                    // Actualiza etiqueta y estado basado en el nuevo conteo
                    if (tempPDFPathsMat.Count > 0)
                    {
                        panel2.BackColor = Color.FromArgb(255, 255, 255);
                        labelPDFMat.ForeColor = Color.FromArgb(0, 0, 0);

                        if (tempPDFPathsMat.Count == 1)
                        {
                            labelPDFMat.Text = periodLogic.GetShortenedFileName(Path.GetFileName(tempPDFPathsMat[0]));
                        }
                        else
                        {
                            labelPDFMat.Text = $"{periodLogic.GetShortenedFileName(Path.GetFileName(tempPDFPathsMat[0]))} and {tempPDFPathsMat.Count - 1} more";
                        }
                        panelPlus2.Show();
                        picturePlus2.Show();
                        picked2 = true;
                    }
                    else
                    {
                        labelPDFMat.Text = "Select or Drag a File ";
                        picked2 = false;
                        panelPlus2.Hide();
                        picturePlus2.Hide();
                    }

                    // Nuevo: solo borra de DB si se eliminó un existente
                    if (existingMatCount > 0 && tempPDFPathsMat.Count < existingMatCount)
                    {
                        pendingDeleteMat.Add(asignatureLogic.ObtainCode(asignatureSelection));
                        existingMatCount--;
                    }
                }
            }
        }
        private void panel1_MouseEnter(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(40, 40, 40);
            labelPDFOri.ForeColor = Color.FromArgb(255, 255, 255);
            if (pickedwfile1 == 2)
            {
                panel1.BackColor = Color.FromArgb(255, 255, 255);
                labelPDFOri.ForeColor = Color.FromArgb(0, 0, 0);
            }
        }
        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(20, 20, 20);
            labelPDFOri.ForeColor = Color.FromArgb(255, 255, 255);

            if (pickedwfile1 == 2)
            {
                panel1.BackColor = Color.FromArgb(20, 20, 20);
                labelPDFOri.ForeColor = Color.FromArgb(255, 255, 255);
            }
        }
        private void panel2_MouseEnter(object sender, EventArgs e)
        {
            panel2.BackColor = Color.FromArgb(40, 40, 40);
            labelPDFMat.ForeColor = Color.FromArgb(255, 255, 255);
            if (pickedwfile2 == 2)
            {
                panel2.BackColor = Color.FromArgb(255, 255, 255);
                labelPDFMat.ForeColor = Color.FromArgb(0, 0, 0);
            }
        }
        private void panel2_MouseLeave(object sender, EventArgs e)
        {
            panel2.BackColor = Color.FromArgb(20, 20, 20);
            labelPDFMat.ForeColor = Color.FromArgb(255, 255, 255);

            if (pickedwfile2 == 2)
            {
                panel2.BackColor = Color.FromArgb(20, 20, 20);
                labelPDFMat.ForeColor = Color.FromArgb(255, 255, 255);
            }
        }

        private void panel1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void panel2_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void panel4_Click(object sender, EventArgs e)
        {
            if (pickedwfile1 == 2)
            {
                if (periodLogic.oriExist(asignatureLogic.ObtainCode(asignatureSelection), periodSelection, dateTimePicker.Value.Year))
                {


                    if (tempPDFPathsOri.Count > 0)
                    {
                        if (tempPDFPathsOri.Count == 1)
                        {
                            labelPDFOri.Text = periodLogic.GetShortenedFileName(Path.GetFileName(tempPDFPathsOri[0]));
                        }
                        else
                        {
                            labelPDFOri.Text = $"{periodLogic.GetShortenedFileName(Path.GetFileName(tempPDFPathsOri[0]))} and {tempPDFPathsOri.Count - 1} more";
                        }
                        panelPlus1.Show();
                        picturePlus1.Show();
                        picked1 = true;
                    }
                    else
                    {
                        labelPDFOri.Text = "Select or Drag a File ";
                        picked1 = false;
                        panelPlus1.Hide();
                        picturePlus1.Hide();
                    }
                    picked1 = true;
                    pickedwfile1 = 1;

                }

            }
            if (pickedwfile2 == 2)
            {
                if (periodLogic.matExist(asignatureLogic.ObtainCode(asignatureSelection), periodSelection, dateTimePicker.Value.Year))
                {
                    if (tempPDFPathsMat.Count > 0)
                    {
                        if (tempPDFPathsMat.Count == 1)
                        {
                            labelPDFMat.Text = periodLogic.GetShortenedFileName(Path.GetFileName(tempPDFPathsMat[0]));
                        }
                        else
                        {
                            labelPDFMat.Text = $"{periodLogic.GetShortenedFileName(Path.GetFileName(tempPDFPathsMat[0]))} and {tempPDFPathsMat.Count - 1} more";
                        }
                        panelPlus2.Show();
                        picturePlus2.Show();
                        picked2 = true;
                    }
                    else
                    {
                        labelPDFMat.Text = "Select or Drag a File ";
                        picked2 = false;
                        panelPlus2.Hide();
                        picturePlus2.Hide();
                    }
                    picked2 = true;
                    pickedwfile2 = 1;
                }
            }
        }

        private void PeriodEdit_Load(object sender, EventArgs e)
        {

        }
        private async void panelPlus1_MouseDown(object sender, MouseEventArgs e)
        {
            panelPlus1.BackColor = Color.FromArgb(20, 20, 20);
            picturePlus1.BackColor = Color.FromArgb(20, 20, 20);
            await Task.Delay(100);
            panelPlus1.BackColor = Color.FromArgb(40, 40, 40);
            picturePlus1.BackColor = Color.FromArgb(40, 40, 40);

            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "All Files|*.*",
                Multiselect = true
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (var file in openFileDialog.FileNames)
                {
                    if (!tempPDFPathsOri.Contains(file))
                        tempPDFPathsOri.Add(file);
                }
                if (tempPDFPathsOri.Count == 1)
                {
                    labelPDFOri.Text = periodLogic.GetShortenedFileName(Path.GetFileName(tempPDFPathsOri[0]));
                }
                else if (tempPDFPathsOri.Count > 1)
                {
                    labelPDFOri.Text = $"{periodLogic.GetShortenedFileName(Path.GetFileName(tempPDFPathsOri[0]))} and {tempPDFPathsOri.Count - 1} more";
                }
                else
                {
                    labelPDFOri.Text = "Select or Drag a File ";
                }
                buttonEdit.ForeColor = Color.White;
                buttonAdd.ForeColor = Color.White;
                panelPlus1.Show();
                picturePlus1.Show();
                picked1 = true;
            }
        }

        private void panelPlus1_MouseEnter(object sender, EventArgs e)
        {
            panelPlus1.BackColor = Color.FromArgb(40, 40, 40);
            picturePlus1.BackColor = Color.FromArgb(40, 40, 40);
        }

        private void panelPlus1_MouseLeave(object sender, EventArgs e)
        {
            panelPlus1.BackColor = Color.FromArgb(20, 20, 20);
            picturePlus1.BackColor = Color.FromArgb(20, 20, 20);
        }

        private void panelPlus1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (var file in files)
            {
                if (!tempPDFPathsOri.Contains(file))
                    tempPDFPathsOri.Add(file);
            }
            if (tempPDFPathsOri.Count == 1)
            {
                labelPDFOri.Text = periodLogic.GetShortenedFileName(Path.GetFileName(tempPDFPathsOri[0]));
            }
            else if (tempPDFPathsOri.Count > 1)
            {
                labelPDFOri.Text = $"{periodLogic.GetShortenedFileName(Path.GetFileName(tempPDFPathsOri[0]))} and {tempPDFPathsOri.Count - 1} more";
            }
            else
            {
                labelPDFOri.Text = "Select or Drag a File ";
            }
            buttonEdit.ForeColor = Color.White;
            buttonAdd.ForeColor = Color.White;
            panelPlus1.Show();
            picturePlus1.Show();
            picked1 = true;
        }

        private void panelPlus1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
                buttonEdit.ForeColor = Color.White;
                buttonAdd.ForeColor = Color.White;
            }
            panelPlus1.BackColor = Color.FromArgb(40, 40, 40);
            picturePlus1.BackColor = Color.FromArgb(40, 40, 40);
        }

        private void panelPlus1_DragLeave(object sender, EventArgs e)
        {
            panelPlus1.BackColor = Color.FromArgb(20, 20, 20);
            picturePlus1.BackColor = Color.FromArgb(20, 20, 20);
        }

        private async void panelPlus2_MouseDown(object sender, MouseEventArgs e)
        {
            panelPlus2.BackColor = Color.FromArgb(20, 20, 20);
            picturePlus2.BackColor = Color.FromArgb(20, 20, 20);
            await Task.Delay(100);
            panelPlus2.BackColor = Color.FromArgb(40, 40, 40);
            picturePlus2.BackColor = Color.FromArgb(40, 40, 40);

            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "All Files|*.*",
                Multiselect = true
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (var file in openFileDialog.FileNames)
                {
                    if (!tempPDFPathsMat.Contains(file))
                        tempPDFPathsMat.Add(file);
                }
                if (tempPDFPathsMat.Count == 1)
                {
                    labelPDFMat.Text = periodLogic.GetShortenedFileName(Path.GetFileName(tempPDFPathsMat[0]));
                }
                else if (tempPDFPathsMat.Count > 1)
                {
                    labelPDFMat.Text = $"{periodLogic.GetShortenedFileName(Path.GetFileName(tempPDFPathsMat[0]))} and {tempPDFPathsMat.Count - 1} more";
                }
                else
                {
                    labelPDFMat.Text = "Select or Drag a File ";
                }
                buttonEdit.ForeColor = Color.White;
                buttonAdd.ForeColor = Color.White;
                panelPlus2.Show();
                picturePlus2.Show();
                picked2 = true;
            }
        }

        private void panelPlus2_MouseEnter(object sender, EventArgs e)
        {
            panelPlus2.BackColor = Color.FromArgb(40, 40, 40);
            picturePlus2.BackColor = Color.FromArgb(40, 40, 40);
        }

        private void panelPlus2_MouseLeave(object sender, EventArgs e)
        {
            panelPlus2.BackColor = Color.FromArgb(20, 20, 20);
            picturePlus2.BackColor = Color.FromArgb(20, 20, 20);
        }

        private void panelPlus2_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (var file in files)
            {
                if (!tempPDFPathsMat.Contains(file))
                    tempPDFPathsMat.Add(file);
            }
            if (tempPDFPathsMat.Count == 1)
            {
                labelPDFMat.Text = periodLogic.GetShortenedFileName(Path.GetFileName(tempPDFPathsMat[0]));
            }
            else if (tempPDFPathsMat.Count > 1)
            {
                labelPDFMat.Text = $"{periodLogic.GetShortenedFileName(Path.GetFileName(tempPDFPathsMat[0]))} and {tempPDFPathsMat.Count - 1} more";
            }
            else
            {
                labelPDFMat.Text = "Select or Drag a File ";
            }
            buttonEdit.ForeColor = Color.White;
            buttonAdd.ForeColor = Color.White;
            panelPlus2.Show();
            picturePlus2.Show();
            picked2 = true;
        }

        private void panelPlus2_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
                buttonEdit.ForeColor = Color.White;
                buttonAdd.ForeColor = Color.White;
            }
            panelPlus2.BackColor = Color.FromArgb(40, 40, 40);
            picturePlus2.BackColor = Color.FromArgb(40, 40, 40);
        }

        private void panelPlus2_DragLeave(object sender, EventArgs e)
        {
            panelPlus2.BackColor = Color.FromArgb(20, 20, 20);
            picturePlus2.BackColor = Color.FromArgb(20, 20, 20);
        }


        private void panel1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
                buttonEdit.ForeColor = Color.White;
                buttonAdd.ForeColor = Color.White;
            }
            panel1.BackColor = Color.FromArgb(40, 40, 40);
        }

        private void panel1_DragLeave(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(20, 20, 20);
        }

        private void panel2_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
                buttonEdit.ForeColor = Color.White;
                buttonAdd.ForeColor = Color.White;
            }
            panel2.BackColor = Color.FromArgb(40, 40, 40);
        }

        private void panel2_DragLeave(object sender, EventArgs e)
        {
            panel2.BackColor = Color.FromArgb(20, 20, 20);
        }

        private void PeriodEdit_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
                buttonEdit.ForeColor = Color.White;
                buttonAdd.ForeColor = Color.White;
            }
        }

        private void panel4_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
                buttonEdit.ForeColor = Color.White;
                buttonAdd.ForeColor = Color.White;
            }
        }

        private void panel6_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
                buttonEdit.ForeColor = Color.White;
                buttonAdd.ForeColor = Color.White;
            }
        }

        private void panel11_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
                buttonEdit.ForeColor = Color.White;
                buttonAdd.ForeColor = Color.White;
            }
        }
    }
}