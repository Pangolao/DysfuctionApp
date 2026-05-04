using Dysfunction.Data;
using Dysfunction.GUI.Consult;
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
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Microsoft.VisualBasic.FileIO;

namespace Dysfunction.GUI.Register
{
    public partial class ProjectEdit : Form
    {
        string asignatureSelection;
        string periodSelection;
        string projectSelection;
        private List<string> tempPDFPathsInd = new List<string>();
        private List<string> tempPDFPathsPro = new List<string>();
        private List<string> filesToDeleteInd = new List<string>();
        private List<string> filesToDeletePro = new List<string>();
        int contador = 0;
        int pickedwfile1 = 0;
        int pickedwfile2 = 0;
        projectLogic projectLogic = new projectLogic();
        periodLogic periodLogic = new periodLogic();
        asignatureLogic asignatureLogic = new asignatureLogic();
        private Dysfunction dysfunctionForm;
        bool picked1 = false;
        bool picked2 = false;
        string xmlFilePath1 = "Selections.xml";
        bool showPlus1;
        bool showPlus2;

        public ProjectEdit(Dysfunction dysfunction)
        {
            InitializeComponent();
            dysfunction.cache = 0;
            dysfunctionForm = dysfunction;
            Thread.CurrentThread.CurrentCulture = CultureInfo.CurrentCulture;
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CurrentCulture;
            hideLabels();
            FullComboPeriod();
            FullComboAsignature();
            dateTimePicker.Format = DateTimePickerFormat.Custom;
            dateTimePicker.CustomFormat = "yyyy";
            dateTimePickerLimit.Format = DateTimePickerFormat.Custom;
            LoadSelectionsFromXml();

            if (!string.IsNullOrEmpty(ProjectConsult.projectName) && comboBoxProject.Items.Contains(ProjectConsult.projectName))
            {
                comboBoxProject.SelectedItem = ProjectConsult.projectName;  // Preselect the clicked project
                projectSelection = ProjectConsult.projectName;  // Update internal var

                // Optionally trigger the changed event to load data immediately
                comboBoxProject_SelectedIndexChanged(null, null);

                // Clear the static to avoid reuse on next open (optional, for safety)
                ProjectConsult.projectName = null;
            }

            if (!string.IsNullOrEmpty(ProjectConsult.asignatureName) && comboBoxAsignature.Items.Contains(ProjectConsult.asignatureName))
            {
                comboBoxAsignature.SelectedItem = ProjectConsult.asignatureName;
                asignatureSelection = ProjectConsult.asignatureName;
            }
        }
        private void hideLabels()
        {
            labelAsignature.Visible = false;
            labelProject.Visible = false;
            labelValue.Visible = false;
            labelPeriod.Visible = false;
        }
        private void CenterControl(Control ctrl)
        {
           ctrl.Left = (this.ClientSize.Width - ctrl.Width) / 2;
           ctrl.Top = (this.ClientSize.Height - ctrl.Height) / 2;
        }
        private void ProjectEdit_Resize(object sender, EventArgs e)
        {
            CenterControl(panel4);
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


        private void FullComboPeriod()
        {
            comboBoxPeriod.Items.Clear();
            List<periodModel> periodModels = periodLogic.Consult();

            foreach (var period in periodModels)
            {
                if (period != null && period.Year == dateTimePicker.Value.Year)
                {
                    comboBoxPeriod.Items.Add(period.Period);
                    comboBoxPeriod.SelectedIndex = 0;
                }
            }

            if (comboBoxPeriod.Items.Count > 0)
            {
                periodSelection = comboBoxPeriod.SelectedItem?.ToString();
                labelPeriod.Visible = false;
            }
            else
            {
                labelPeriod.Visible = true;
            }
        }
        private void FullComboAsignature()
        {
            comboBoxAsignature.Items.Clear();

            List<asignatureModel> asignatureModels = asignatureLogic.Consult();
            List<periodModel> periodModels = periodLogic.Consult();
            projectLogic.Consult();
            foreach (var period in periodModels)
            {
                if (period != null && period.Year == dateTimePicker.Value.Year && period.Period == periodSelection)
                {
                    foreach (var asignature in asignatureModels)
                    {
                        if (asignature != null && period.Asignatures.Contains(asignature.Code))
                        {
                            comboBoxAsignature.Items.Add(asignature.Asignature);
                            comboBoxAsignature.SelectedIndex = 0;
                        }
                    }
                }
            }

            if (comboBoxAsignature.Items.Count > 0)
            {
                asignatureSelection = comboBoxAsignature.SelectedItem?.ToString();
                labelAsignature.Visible = false;
            }
            else
            {
                if (comboBoxPeriod.Items.Count < 1)
                {
                    labelAsignature.Visible = true;
                }
            }
        }
        private void FullComboProject()
        {
            comboBoxProject.Items.Clear();
            List<projectModel> projectModels = projectLogic.Consult();

            foreach (var project in projectModels)
            {
                if (project != null && project.Code == asignatureLogic.ObtainCode(asignatureSelection) &&
                    project.Period == periodSelection && project.Year == dateTimePicker.Value.Year)
                {
                    comboBoxProject.Items.Add(project.Project);
                    comboBoxProject.SelectedIndex = 0;
                }
            }
        }
        private async void buttonSave_Click(object sender, EventArgs e)
        {
            if (projectLogic.ValidNotNull(periodSelection) && projectLogic.ValidNotNull(asignatureLogic.ObtainCode(asignatureSelection)) && projectLogic.ValidNotNull(projectSelection) &&
                  projectLogic.ValidFloat(textBoxValue.Text))
            {
                List<projectModel> projectModels = projectLogic.Consult();
                var SelectedObject = projectModels.FirstOrDefault(p => p.Project == projectSelection && p.Code == asignatureLogic.ObtainCode(asignatureSelection) && p.Period == periodSelection && p.Year == dateTimePicker.Value.Year);

                if (!string.IsNullOrEmpty(textBoxValue.Text))
                {
                    SelectedObject.Value = float.Parse(textBoxValue.Text);
                }
                else
                {
                    SelectedObject.Value = 0;
                }

                SelectedObject.LimitDate = dateTimePickerLimit.Value;

                projectLogic.EditObject(SelectedObject);

                // Eliminar solo archivos marcados que estén en directorios permitidos
                string baseDir = Directory.GetCurrentDirectory();
                string tempDir = Path.GetTempPath();
                foreach (var file in filesToDeleteInd.ToList())
                {
                    if (File.Exists(file) && (file.StartsWith(Path.Combine(baseDir, "Indication")) || file.StartsWith(tempDir)))
                    {
                        projectLogic.DeleteSpecificFile(file);
                    }
                    else
                    {
                        filesToDeleteInd.Remove(file); // Evitar procesar archivos no permitidos
                    }
                }
                foreach (var file in filesToDeletePro.ToList())
                {
                    if (File.Exists(file) && (file.StartsWith(Path.Combine(baseDir, "Project")) || file.StartsWith(tempDir)))
                    {
                        projectLogic.DeleteSpecificFile(file);
                    }
                    else
                    {
                        filesToDeletePro.Remove(file); // Evitar procesar archivos no permitidos
                    }
                }

                projectLogic.SaveIndMultiple(projectSelection, asignatureLogic.ObtainCode(asignatureSelection), periodSelection, dateTimePicker.Value.Year, tempPDFPathsInd);
                projectLogic.SaveProMultiple(projectSelection, asignatureLogic.ObtainCode(asignatureSelection), periodSelection, dateTimePicker.Value.Year, tempPDFPathsPro);

                textBoxValue.Text = "";
                dateTimePickerLimit.Value = DateTime.Now;
                textBoxValue.Enabled = false;
                dateTimePickerLimit.Enabled = false;
                labelPDF.Text = "Select or Drag a File ";
                tempPDFPathsInd.Clear();
                filesToDeleteInd.Clear();
                labelPDFProject.Text = "Select or Drag a File";
                tempPDFPathsPro.Clear();
                filesToDeletePro.Clear();
                picked1 = false;
                picked2 = false;
                pickedwfile1 = 0;
                pickedwfile2 = 0;
                comboBoxProject.SelectedIndex = -1;
                panelPlus1.Hide();
                picturePlus1.Hide();
                panelPlus2.Hide();
                picturePlus2.Hide();

                hideLabels();
                buttonEdit.ForeColor = Color.Green;
                buttonEdit.Text = "Saved";
                await Task.Delay(2000);
                buttonEdit.ForeColor = Color.White;
                buttonEdit.Text = "Save Edit";
            }
            else
            {
                buttonEdit.ForeColor = Color.Red;
                await Task.Delay(2000);
                buttonEdit.ForeColor = Color.White;

                if (!projectLogic.ValidNotNull(periodSelection))
                {
                    labelPeriod.Visible = true;
                }

                if (!projectLogic.ValidNotNull(asignatureSelection))
                {
                    labelAsignature.Visible = true;
                }
                if (!projectLogic.ValidNotNull(projectSelection))
                {
                    labelProject.Visible = true;
                }
            }
        }
        private async void buttonDelete_Click(object sender, EventArgs e)
        {
            List<projectModel> projectModels = projectLogic.Consult();
            var SelectedObject = projectModels.FirstOrDefault(p => p.Project == projectSelection && p.Code == asignatureLogic.ObtainCode(asignatureSelection) && p.Period == periodSelection && p.Year == dateTimePicker.Value.Year);
            if (SelectedObject != null)
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
                    projectLogic.Delete(SelectedObject);
                    projectLogic.DeleteProFile(SelectedObject.Project, SelectedObject.Code, SelectedObject.Period, SelectedObject.Year);
                    projectLogic.DeleteIndFile(SelectedObject.Project, SelectedObject.Code, SelectedObject.Period, SelectedObject.Year);

                    textBoxValue.Text = "";
                    dateTimePickerLimit.Value = DateTime.Now;
                    textBoxValue.Enabled = false;
                    dateTimePickerLimit.Enabled = false;
                    labelPDF.Text = "Select or Drag a File ";
                    tempPDFPathsInd.Clear();
                    filesToDeleteInd.Clear();
                    labelPDFProject.Text = "Select or Drag a File";
                    tempPDFPathsPro.Clear();
                    filesToDeletePro.Clear();
                    picked1 = false;
                    picked2 = false;
                    pickedwfile1 = 0;
                    pickedwfile2 = 0;
                    panelPlus1.Hide();
                    picturePlus1.Hide();
                    panelPlus2.Hide();
                    picturePlus2.Hide();

                    FullComboProject();
                    hideLabels();
                    buttonDelete.ForeColor = Color.LightGreen;
                    buttonDelete.Text = "Deleted";
                    await Task.Delay(2000);
                    buttonDelete.ForeColor = Color.White;
                    buttonDelete.Text = "Delete";
                    buttonDelete.FlatAppearance.MouseOverBackColor = Color.FromArgb(20, 20, 20);
                }
            }
            else
            {
                buttonDelete.ForeColor = Color.Red;
                await Task.Delay(2000);
                buttonDelete.ForeColor = Color.White;
            }
        }
        private void comboBoxAsignature_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonEdit.ForeColor = Color.White;
            buttonDelete.ForeColor = Color.White;
            labelAsignature.Visible = false;
            textBoxValue.Text = "";
            dateTimePickerLimit.Value = DateTime.Now;
            textBoxValue.Enabled = false;
            dateTimePickerLimit.Enabled = false;
            asignatureSelection = comboBoxAsignature.SelectedItem?.ToString();
            FullComboProject();
            List<projectModel> projectModels = projectLogic.Consult();
            var SelectedObject = projectModels.FirstOrDefault(p => p.Project == projectSelection && p.Code == asignatureLogic.ObtainCode(asignatureSelection) && p.Period == periodSelection && p.Year == dateTimePicker.Value.Year);

            if (SelectedObject != null)
            {
                textBoxValue.Text = SelectedObject.Value.ToString();
                dateTimePickerLimit.Value = SelectedObject.LimitDate;
            }
        }
        private void textBoxValue_TextChanged(object sender, EventArgs e)
        {
            textBoxValue.Text = textBoxValue.Text.Replace(',', '.');

            textBoxValue.SelectionStart = textBoxValue.Text.Length;

            if (!projectLogic.ValidFloat(textBoxValue.Text))
            {
                labelValue.Visible = true;
                textBoxValue.ForeColor = Color.Red;
            }
            else
            {
                buttonEdit.ForeColor = Color.White;
                buttonDelete.ForeColor = Color.White;
                labelValue.Visible = false;
                textBoxValue.ForeColor = Color.White;
            }
        }
        private void textBoxValue_Click(object sender, EventArgs e)
        {
            buttonEdit.ForeColor = Color.White;
            labelValue.Visible = false;
        }

        private void UpdateIndLabel()
        {
            if (tempPDFPathsInd.Count == 0)
            {
                labelPDF.Text = "Select or Drag a File ";
                pickedwfile1 = 0;
                panelPlus1.Hide();
                picturePlus1.Hide();
            }
            else if (tempPDFPathsInd.Count == 1)
            {
                labelPDF.Text = projectLogic.GetShortenedFileName(Path.GetFileName(tempPDFPathsInd[0]));
                pickedwfile1 = 1;
                panelPlus1.Show();
                picturePlus1.Show();
            }
            else
            {
                labelPDF.Text = $"{projectLogic.GetShortenedFileName(Path.GetFileName(tempPDFPathsInd[0]))} and {tempPDFPathsInd.Count - 1} more";
                pickedwfile1 = 1;
                panelPlus1.Show();
                picturePlus1.Show();
            }
        }
        private void UpdateProLabel()
        {
            if (tempPDFPathsPro.Count == 0)
            {
                labelPDFProject.Text = "Select or Drag a File";
                pickedwfile2 = 0;
                panelPlus2.Hide();
                picturePlus2.Hide();
            }
            else if (tempPDFPathsPro.Count == 1)
            {
                labelPDFProject.Text = projectLogic.GetShortenedFileName(Path.GetFileName(tempPDFPathsPro[0]));
                pickedwfile2 = 1;
                panelPlus2.Show();
                picturePlus2.Show();
            }
            else
            {
                labelPDFProject.Text = $"{projectLogic.GetShortenedFileName(Path.GetFileName(tempPDFPathsPro[0]))} and {tempPDFPathsPro.Count - 1} more";
                pickedwfile2 = 1;
                panelPlus2.Show();
                picturePlus2.Show();
            }
        }
        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            FullComboPeriod();
            FullComboAsignature();
            FullComboProject();
            textBoxValue.Text = "";
            dateTimePickerLimit.Value = DateTime.Now;
            textBoxValue.Enabled = false;
            dateTimePickerLimit.Enabled = false;
            buttonEdit.ForeColor = Color.White;
            buttonDelete.ForeColor = Color.White;
        }
        private void comboBoxPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            periodSelection = comboBoxPeriod.SelectedItem?.ToString();
            buttonEdit.ForeColor = Color.White;
            buttonDelete.ForeColor = Color.White;
            FullComboAsignature();
            FullComboProject();
            textBoxValue.Text = "";
            dateTimePickerLimit.Value = DateTime.Now;
            textBoxValue.Enabled = false;
            dateTimePickerLimit.Enabled = false;
            List<projectModel> projectModels = projectLogic.Consult();
            var SelectedObject = projectModels.FirstOrDefault(p => p.Project == projectSelection && p.Code == asignatureLogic.ObtainCode(asignatureSelection) && p.Period == periodSelection && p.Year == dateTimePicker.Value.Year);

            if (SelectedObject != null)
            {
                textBoxValue.Text = SelectedObject.Value.ToString();
                dateTimePickerLimit.Value = SelectedObject.LimitDate;
            }
        }
        private void comboBoxProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            projectSelection = comboBoxProject.SelectedItem?.ToString();
            textBoxValue.Enabled = true;
            dateTimePickerLimit.Enabled = true;
            buttonEdit.ForeColor = Color.White;
            buttonDelete.ForeColor = Color.White;

            // Check for existing files and update panel visibility
            tempPDFPathsInd = projectLogic.GetExistingIndFiles(projectSelection, asignatureLogic.ObtainCode(asignatureSelection), periodSelection, dateTimePicker.Value.Year);
            filesToDeleteInd.Clear();
            UpdateIndLabel();
            picked1 = tempPDFPathsInd.Count > 0;

            tempPDFPathsPro = projectLogic.GetExistingProFiles(projectSelection, asignatureLogic.ObtainCode(asignatureSelection), periodSelection, dateTimePicker.Value.Year);
            filesToDeletePro.Clear();
            UpdateProLabel();
            picked2 = tempPDFPathsPro.Count > 0;

            List<projectModel> projectModels = projectLogic.Consult();
            var SelectedObject = projectModels.FirstOrDefault(p => p.Project == projectSelection && p.Code == asignatureLogic.ObtainCode(asignatureSelection) && p.Period == periodSelection && p.Year == dateTimePicker.Value.Year);

            if (SelectedObject != null)
            {
                textBoxValue.Text = SelectedObject.Value.ToString();
                dateTimePickerLimit.Value = SelectedObject.LimitDate;
            }

            this.Refresh();
        }
        private void dateTimePickerLimit_ValueChanged(object sender, EventArgs e)
        {
            buttonEdit.ForeColor = Color.White;
            buttonDelete.ForeColor = Color.White;
        }
        private void backButton_MouseDown(object sender, MouseEventArgs e)
        {
            dysfunctionForm.OpenNewForm(new ProjectConsult(dysfunctionForm));
        }
        private void backButton_MouseEnter(object sender, EventArgs e)
        {
            backButton.BackColor = Color.FromArgb(20, 20, 20);
        }
        private void backButton_MouseLeave(object sender, EventArgs e)
        {
            backButton.BackColor = Color.FromArgb(0, 0, 0);
        }
        private void panel4_Click(object sender, EventArgs e)
        {
            if (pickedwfile2 == 2)
            {
                if (projectLogic.ProjectExist(projectSelection, asignatureLogic.ObtainCode(asignatureSelection), periodSelection, dateTimePicker.Value.Year))
                {
                    tempPDFPathsPro = projectLogic.GetExistingProFiles(projectSelection, asignatureLogic.ObtainCode(asignatureSelection), periodSelection, dateTimePicker.Value.Year);
                    UpdateProLabel();
                    picked2 = true;
                    labelPDFProject.Location = new Point(labelPDFProject.Location.X + 13, labelPDFProject.Location.Y);
                    pickedwfile2 = 1;
                    panelPlus2.Show();
                    picturePlus2.Show();
                }
            }

            if (pickedwfile1 == 2)
            {
                if (projectLogic.IndicationExist(projectSelection, asignatureLogic.ObtainCode(asignatureSelection), periodSelection, dateTimePicker.Value.Year))
                {
                    tempPDFPathsInd = projectLogic.GetExistingIndFiles(projectSelection, asignatureLogic.ObtainCode(asignatureSelection), periodSelection, dateTimePicker.Value.Year);
                    UpdateIndLabel();
                    picked1 = true;
                    labelPDF.Location = new Point(labelPDF.Location.X + 13, labelPDF.Location.Y);
                    pickedwfile1 = 1;
                    panelPlus1.Show();
                    picturePlus1.Show();
                }
            }
        }

       private void panelIndications_Click(object sender, EventArgs e)
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
            tempPDFPathsInd.AddRange(openFileDialog.FileNames);
            UpdateIndLabel();
            picked1 = true;
            buttonEdit.ForeColor = Color.White;
            buttonDelete.ForeColor = Color.White;
            panelPlus1.Show();
            picturePlus1.Show();
        }
    }
    // This block is likely unreachable (see explanation), but if you want non-confirmation deletes, adjust conditions.
    else if (pickedwfile1 == 0)
    {
        if (tempPDFPathsInd.Count > 0)
        {
            filesToDeleteInd.Add(tempPDFPathsInd[tempPDFPathsInd.Count - 1]);
            tempPDFPathsInd.RemoveAt(tempPDFPathsInd.Count - 1);
            UpdateIndLabel();
            if (tempPDFPathsInd.Count == 0)
            {
                picked1 = false;
                panelPlus1.Hide();
                picturePlus1.Hide();
            }
        }
    }
    else if (pickedwfile1 == 1)
    {
        panelIndications.BackColor = Color.FromArgb(255, 255, 255);
        labelPDF.ForeColor = Color.FromArgb(0, 0, 0);
        labelPDF.Text = "Are you sure? Click again";
        labelPDF.Location = new Point(labelPDF.Location.X - 13, labelPDF.Location.Y);
        pickedwfile1 = 2;
        // FIX: Target the last file in the list (most recent/newest) instead of highest suffix.
        if (tempPDFPathsInd.Count > 0)
        {
            string fileToDelete = tempPDFPathsInd.Last();
            if (!filesToDeleteInd.Contains(fileToDelete))
            {
                filesToDeleteInd.Add(fileToDelete);
            }
        }
    }
    else if (pickedwfile1 == 2)
    {
        labelPDF.Visible = false;
        labelPDF.ForeColor = Color.FromArgb(255, 255, 255);
        labelPDF.Text = "Select or Drag a File";
        panelPlus1.Hide();
        picturePlus1.Hide();
        panelIndications.BackColor = Color.FromArgb(40, 40, 40);
        pickedwfile1 = 0;
        picked1 = tempPDFPathsInd.Count > 0;
        labelPDF.Location = new Point(labelPDF.Location.X + 13, labelPDF.Location.Y);
        if (tempPDFPathsInd.Count > 0)
        {
            tempPDFPathsInd.Remove(filesToDeleteInd.Last());
            UpdateIndLabel();
        }
        panelPlus1.Visible = picked1;
        picturePlus1.Visible = picked1;
        labelPDF.Visible = true;
    }

    if (tempPDFPathsInd.Count > 0)
    {
        panelPlus1.Show();
        picturePlus1.Show();
    } 
    else
    {
        panelPlus1.Hide();
        picturePlus1.Hide();
    }
}
        private void panelProject_Click(object sender, EventArgs e)
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
                    tempPDFPathsPro.AddRange(openFileDialog.FileNames);
                    UpdateProLabel();
                    picked2 = true;
                    buttonEdit.ForeColor = Color.White;
                    buttonDelete.ForeColor = Color.White;
                    panelPlus2.Show();
                    picturePlus2.Show();
                }
            }
            else if (pickedwfile2 == 0)
            {
                if (tempPDFPathsPro.Count > 0)
                {
                    filesToDeletePro.Add(tempPDFPathsPro[tempPDFPathsPro.Count - 1]);
                    tempPDFPathsPro.RemoveAt(tempPDFPathsPro.Count - 1);
                    UpdateProLabel();
                    if (tempPDFPathsPro.Count == 0)
                    {
                        picked2 = false;
                        panelPlus2.Hide();
                        picturePlus2.Hide();
                    }
                }
            }
            else if (pickedwfile2 == 1)
            {
                panelProject.BackColor = Color.FromArgb(255, 255, 255);
                labelPDFProject.ForeColor = Color.FromArgb(0, 0, 0);
                labelPDFProject.Text = "Are you sure? Click again";
                labelPDFProject.Location = new Point(labelPDFProject.Location.X - 13, labelPDFProject.Location.Y);
                pickedwfile2 = 2;
                // Add the file with the highest suffix to filesToDeletePro
                if (tempPDFPathsPro.Count > 0)
                {
                    string fileToDelete = tempPDFPathsPro.OrderByDescending(f => projectLogic.GetFileSuffix(f, $"{projectSelection}_{asignatureLogic.ObtainCode(asignatureSelection)}_{projectLogic.deleteSpaces(periodSelection)}_{dateTimePicker.Value.Year}")).First();
                    if (!filesToDeletePro.Contains(fileToDelete))
                    {
                        filesToDeletePro.Add(fileToDelete);
                    }
                }
            }
            else if (pickedwfile2 == 2)
            {
                labelPDFProject.Visible = false;
                labelPDFProject.ForeColor = Color.FromArgb(255, 255, 255);
                labelPDFProject.Text = "Select or Drag a File";

                panelPlus2.Hide();
                picturePlus2.Hide();
                panelProject.BackColor = Color.FromArgb(40, 40, 40);
                pickedwfile2 = 0;
                picked2 = tempPDFPathsPro.Count > 0;
                labelPDFProject.Location = new Point(labelPDFProject.Location.X + 13, labelPDFProject.Location.Y);
                if (tempPDFPathsPro.Count > 0)
                {
                    tempPDFPathsPro.Remove(filesToDeletePro.Last());
                    UpdateProLabel();
                }
                panelPlus2.Visible = picked2;
                picturePlus2.Visible = picked2;
                labelPDFProject.Visible = true;
            }
        }
        private void panelIndications_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
                buttonEdit.ForeColor = Color.White;
            }
        }
        private void panelIndications_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            // Replace existing files with the dragged ones
            tempPDFPathsInd.Clear();
            tempPDFPathsInd.AddRange(files);
            UpdateIndLabel();
            picked1 = tempPDFPathsInd.Count > 0;
            buttonEdit.ForeColor = Color.White;
            buttonDelete.ForeColor = Color.White;
            panelPlus1.Show();
            picturePlus1.Show();
        }
        private void panelProject_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            // Replace existing files with the dragged ones
            tempPDFPathsPro.Clear();
            tempPDFPathsPro.AddRange(files);
            UpdateProLabel();
            picked2 = tempPDFPathsPro.Count > 0;
            buttonEdit.ForeColor = Color.White;
            buttonDelete.ForeColor = Color.White;
            panelPlus2.Show();
            picturePlus2.Show();
        }
        private void panelProject_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
                buttonEdit.ForeColor = Color.White;
            }
        }
        private void ProjectRegister_MouseEnter(object sender, EventArgs e)
        {
            backButton.BackColor = Color.FromArgb(0, 0, 0);
        }
        private void panelProject_MouseEnter(object sender, EventArgs e)
        {
            panelProject.BackColor = Color.FromArgb(40, 40, 40);
            labelPDFProject.ForeColor = Color.FromArgb(255, 255, 255);
            if (pickedwfile2 == 2)
            {
                panelProject.BackColor = Color.FromArgb(255, 255, 255);
                labelPDFProject.ForeColor = Color.FromArgb(0, 0, 0);
            }
        }
        private void panelProject_MouseLeave(object sender, EventArgs e)
        {
            panelProject.BackColor = Color.FromArgb(20, 20, 20);
            labelPDFProject.ForeColor = Color.FromArgb(255, 255, 255);
            if (pickedwfile2 == 2)
            {
                panelProject.BackColor = Color.FromArgb(20, 20, 20);
                labelPDFProject.ForeColor = Color.FromArgb(255, 255, 255);
            }
        }
        private void panelIndications_MouseEnter(object sender, EventArgs e)
        {
            panelIndications.BackColor = Color.FromArgb(40, 40, 40);
            labelPDF.ForeColor = Color.FromArgb(255, 255, 255);
            if (pickedwfile1 == 2)
            {
                panelIndications.BackColor = Color.FromArgb(255, 255, 255);
                labelPDF.ForeColor = Color.FromArgb(0, 0, 0);
            }
        }
        private void panelIndications_MouseLeave(object sender, EventArgs e)
        {
            panelIndications.BackColor = Color.FromArgb(20, 20, 20);
            labelPDF.ForeColor = Color.FromArgb(255, 255, 255);
            if (pickedwfile1 == 2)
            {
                panelIndications.BackColor = Color.FromArgb(20, 20, 20);
                labelPDF.ForeColor = Color.FromArgb(255, 255, 255);
            }
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
                    if (!tempPDFPathsInd.Contains(file))
                        tempPDFPathsInd.Add(file);
                }
                UpdateIndLabel();
                buttonEdit.ForeColor = Color.White;
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
                if (!tempPDFPathsInd.Contains(file))
                    tempPDFPathsInd.Add(file);
            }
            UpdateIndLabel();
            buttonEdit.ForeColor = Color.White;
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
                    if (!tempPDFPathsPro.Contains(file))
                        tempPDFPathsPro.Add(file);
                }
                UpdateProLabel();
                buttonEdit.ForeColor = Color.White;
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
                if (!tempPDFPathsPro.Contains(file))
                    tempPDFPathsPro.Add(file);
            }
            UpdateProLabel();
            buttonEdit.ForeColor = Color.White;
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
            }
            panelPlus2.BackColor = Color.FromArgb(40, 40, 40);
            picturePlus2.BackColor = Color.FromArgb(40, 40, 40);
        }
        private void panelPlus2_DragLeave(object sender, EventArgs e)
        {
            panelPlus2.BackColor = Color.FromArgb(20, 20, 20);
            picturePlus2.BackColor = Color.FromArgb(20, 20, 20);
        }
    }
}