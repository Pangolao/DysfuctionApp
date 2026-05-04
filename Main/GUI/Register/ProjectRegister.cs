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

namespace Dysfunction.GUI.Register
{
    public partial class ProjectRegister : Form
    {
        string asignatureSelection;
        string periodSelection;
        private Dysfunction dysfunctionForm;
        string xmlFilePath1 = "Selections.xml";
        projectLogic projectLogic = new projectLogic();
        periodLogic periodLogic = new periodLogic();
        asignatureLogic asignatureLogic = new asignatureLogic();

        bool picked1 = false;
        bool picked2 = false;
        private List<string> tempPDFPathsInd = new List<string>();
        private List<string> tempPDFPathsPro = new List<string>();
        public ProjectRegister(Dysfunction dysfunction)
        {
            InitializeComponent();
            dysfunctionForm = dysfunction;
            dysfunction.cache = 0;
            Thread.CurrentThread.CurrentCulture = CultureInfo.CurrentCulture;
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CurrentCulture;
            hideLabels();
            FullComboPeriod();
            FullComboAsignature();
            LoadSelectionsFromXml();
            panelPlus1.Hide();
            panelPlus2.Hide();
            picturePlus1.Hide();
            picturePlus2.Hide();
        }
        private void hideLabels()
        {
            labelAsignature.Visible = false;
            labelProject.Visible = false;
            labelValue.Visible = false;
            labelPeriod.Visible = false;
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
                }
            }


            if (comboBoxPeriod.Items.Count > 0)
            {
                comboBoxPeriod.SelectedIndex = 0;
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


            foreach (var period in periodModels)
            {
                if (period != null && period.Year == dateTimePicker.Value.Year && period.Period == periodSelection)
                {
                    foreach (var asignature in asignatureModels)
                    {
                        if (asignature != null && period.Asignatures.Contains(asignature.Code))
                        {
                            comboBoxAsignature.Items.Add(asignature.Asignature);
                        }
                    }
                }
            }

            if (comboBoxAsignature.Items.Count > 0)
            {
                comboBoxAsignature.SelectedIndex = 0;
                asignatureSelection = comboBoxAsignature.SelectedItem?.ToString();
                labelAsignature.Visible = false;
            }
            else
            {
                labelAsignature.Visible = true;
            }
        }

        private async void buttonSave_Click(object sender, EventArgs e)
        {

            if (projectLogic.ValidNotNull(periodSelection) && projectLogic.ValidNotNull(asignatureLogic.ObtainCode(asignatureSelection)) && projectLogic.ValidNotNull(textBoxProject.Text) &&
                  projectLogic.ValidFloat(textBoxValue.Text))
            {
                if (string.IsNullOrEmpty(textBoxValue.Text))
                {
                    projectModel projectModel = new projectModel(dateTimePicker.Value.Year, periodSelection, asignatureLogic.ObtainCode(asignatureSelection), textBoxProject.Text, 0, 0, dateTimePickerLimit.Value);
                    projectLogic.NewObject(projectModel);
                }
                else
                {
                    projectModel projectModel = new projectModel(dateTimePicker.Value.Year, periodSelection, asignatureLogic.ObtainCode(asignatureSelection), textBoxProject.Text, float.Parse(textBoxValue.Text), 0, dateTimePickerLimit.Value);
                    projectLogic.NewObject(projectModel);
                }

                // Guardar archivos de indicaciones (múltiples)
                if (tempPDFPathsInd.Count > 0)
                {
                    projectLogic.SaveIndMultiple(
                        textBoxProject.Text,
                        asignatureLogic.ObtainCode(asignatureSelection),
                        projectLogic.deleteSpaces(periodSelection),
                        dateTimePicker.Value.Year,
                        tempPDFPathsInd
                    );
                }
                // Guardar archivos de proyecto (múltiples)
                if (tempPDFPathsPro.Count > 0)
                {
                    projectLogic.SaveProMultiple(
                        textBoxProject.Text,
                        asignatureLogic.ObtainCode(asignatureSelection),
                        projectLogic.deleteSpaces(periodSelection),
                        dateTimePicker.Value.Year,
                        tempPDFPathsPro
                    );
                }

                textBoxProject.Text = "";
                textBoxValue.Text = "";
                labelPDFIndications.Text = "     Select or Drag a File ";
                tempPDFPathsInd.Clear();
                labelPDFProject.Text = "     Select or Drag a File";
                tempPDFPathsPro.Clear();
                picked1 = false;
                picked2 = false;
                hideLabels();
                panelPlus1.Hide();
                picturePlus1.Hide();
                panelPlus2.Hide();
                picturePlus2.Hide();
                buttonSave.ForeColor = Color.LightGreen;
                buttonSave.Text = "Saved";
                await Task.Delay(2000);
                buttonSave.ForeColor = Color.White;
                buttonSave.Text = "Save";

            }
            else
            {

                if (!projectLogic.ValidNotNull(periodSelection))
                {
                    labelPeriod.Visible = true;
                }

                if (!projectLogic.ValidNotNull(asignatureSelection))
                {
                    labelAsignature.Visible = true;
                }
                if (!projectLogic.ValidNotNull(textBoxProject.Text))
                {
                    labelProject.Visible = true;
                }
                if (!projectLogic.ValidFloat(textBoxValue.Text))
                {
                    labelValue.Visible = true;
                }
                buttonSave.ForeColor = Color.Red;
                await Task.Delay(2000);
                buttonSave.ForeColor = Color.White;


            }


        }


        private void comboBoxAsignature_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonSave.ForeColor = Color.White;
            labelAsignature.Visible = false;
            asignatureSelection = comboBoxAsignature.SelectedItem?.ToString();
        }
        private void textBoxProject_TextChanged(object sender, EventArgs e)
        {
            if (!projectLogic.ValidNotNull(textBoxProject.Text))
            {
                labelProject.Visible = true;
            }
            else
            {
                buttonSave.ForeColor = Color.White;
                labelProject.Visible = false;
            }
        }
        private void textBoxProject_Click(object sender, EventArgs e)
        {
            buttonSave.ForeColor = Color.White;
            labelProject.Visible = false;

        }
        private void textBoxValue_TextChanged(object sender, EventArgs e)
        {
            textBoxValue.Text = textBoxValue.Text.Replace(',', '.');

            textBoxValue.SelectionStart = textBoxValue.Text.Length;

            if (textBoxValue.Text == "")
            {
                labelValue.Visible = true;
            }
            else if (!projectLogic.ValidNotNull(textBoxValue.Text) || !projectLogic.ValidFloat(textBoxValue.Text))
            {
                labelValue.Visible = true;
                textBoxValue.ForeColor = Color.Red;
            }
            else
            {
                buttonSave.ForeColor = Color.White;
                labelValue.Visible = false;
                textBoxValue.ForeColor = Color.White;
            }
        }
        private void textBoxValue_Click(object sender, EventArgs e)
        {
            buttonSave.ForeColor = Color.White;
            labelValue.Visible = false;
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
                    if (tempPDFPathsInd.Count == 1)
                    {
                        labelPDFIndications.Text = projectLogic.GetShortenedFileName(Path.GetFileName(tempPDFPathsInd[0]));
                    }
                    else if (tempPDFPathsInd.Count > 1)
                    {
                        labelPDFIndications.Text = $"{projectLogic.GetShortenedFileName(Path.GetFileName(tempPDFPathsInd[0]))} and {tempPDFPathsInd.Count - 1} more";
                    }
                    else
                    {
                        labelPDFIndications.Text = "     Select or Drag a File ";
                    }
                    buttonSave.ForeColor = Color.White;
                    panelPlus1.Show();
                    picturePlus1.Show();
                    picked1 = true;
                }
            }
            else
            {
                if (tempPDFPathsInd.Count > 0)
                {
                    tempPDFPathsInd.RemoveAt(tempPDFPathsInd.Count - 1);
                }

                if (tempPDFPathsInd.Count > 0)
                {
                    if (tempPDFPathsInd.Count == 1)
                    {
                        labelPDFIndications.Text = projectLogic.GetShortenedFileName(Path.GetFileName(tempPDFPathsInd[0]));
                    }
                    else if (tempPDFPathsInd.Count > 1)
                    {
                        labelPDFIndications.Text = $"{projectLogic.GetShortenedFileName(Path.GetFileName(tempPDFPathsInd[0]))} and {tempPDFPathsInd.Count - 1} more";
                    }
                    else
                    {
                        labelPDFIndications.Text = "     Select or Drag a File ";
                    }
                    buttonSave.ForeColor = Color.White;
                    panelPlus1.Show();
                    picturePlus1.Show();
                    picked1 = true;
                }
                else
                {
                    labelPDFIndications.Text = "     Select or Drag a File ";
                    buttonSave.ForeColor = Color.White;
                    picked1 = false;
                    panelPlus1.Hide();
                    picturePlus1.Hide();
                }
            }
        }
        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            FullComboPeriod();
            FullComboAsignature();
            buttonSave.ForeColor = Color.White;
        }
        private void comboBoxPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            periodSelection = comboBoxPeriod.SelectedItem?.ToString();
            buttonSave.ForeColor = Color.White;
            FullComboAsignature();
        }
        private void panelIndications_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            tempPDFPathsInd.Clear();
            tempPDFPathsInd.AddRange(files);
            if (tempPDFPathsInd.Count == 1)
            {
                labelPDFIndications.Text = projectLogic.GetShortenedFileName(Path.GetFileName(tempPDFPathsInd[0]));
            }
            else if (tempPDFPathsInd.Count > 1)
            {
                labelPDFIndications.Text = $"{projectLogic.GetShortenedFileName(Path.GetFileName(tempPDFPathsInd[0]))} and {tempPDFPathsInd.Count - 1} more";
            }
            buttonSave.ForeColor = Color.White;
            panelPlus1.Show();
            picturePlus1.Show();
            picked1 = true;
        }

        private void panelIndications_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
                buttonSave.ForeColor = Color.White;
            }
            panelIndications.BackColor = Color.FromArgb(40, 40, 40);
        }
        private void panelIndications_DragLeave(object sender, EventArgs e)
        {
            panelIndications.BackColor = Color.FromArgb(20, 20, 20);
        }

        private void panelProject_DragDrop(object sender, DragEventArgs e)
        {

            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            tempPDFPathsPro.Clear();
            tempPDFPathsPro.AddRange(files);

            if (tempPDFPathsPro.Count == 1)
            {
                labelPDFProject.Text = projectLogic.GetShortenedFileName(Path.GetFileName(tempPDFPathsPro[0]));
            }
            else if (tempPDFPathsPro.Count > 1)
            {
                labelPDFProject.Text = $"{projectLogic.GetShortenedFileName(Path.GetFileName(tempPDFPathsPro[0]))} and {tempPDFPathsPro.Count - 1} more";
            }

            buttonSave.ForeColor = Color.White;
            panelPlus2.Show();
            picturePlus2.Show();
            picked2 = true;



        }

        private void panelProject_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
                buttonSave.ForeColor = Color.White;
            }
            panelProject.BackColor = Color.FromArgb(40, 40, 40);

        }
        private void panelProject_DragLeave(object sender, EventArgs e)
        {
            panelProject.BackColor = Color.FromArgb(20, 20, 20);
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
                    if (tempPDFPathsPro.Count == 1)
                    {
                        labelPDFProject.Text = projectLogic.GetShortenedFileName(Path.GetFileName(tempPDFPathsPro[0]));
                    }
                    else if (tempPDFPathsPro.Count > 1)
                    {
                        labelPDFProject.Text = $"{projectLogic.GetShortenedFileName(Path.GetFileName(tempPDFPathsPro[0]))} and {tempPDFPathsPro.Count - 1} more";
                    }
                    else
                    {
                        labelPDFProject.Text = "     Select or Drag a File";
                    }
                    buttonSave.ForeColor = Color.White;
                    panelPlus2.Show();
                    picturePlus2.Show();
                    picked2 = true;
                }
            }
            else
            {
                if (tempPDFPathsPro.Count > 0)
                {
                    tempPDFPathsPro.RemoveAt(tempPDFPathsPro.Count - 1);
                }

                if (tempPDFPathsPro.Count > 0)
                {
                    if (tempPDFPathsPro.Count == 1)
                    {
                        labelPDFProject.Text = projectLogic.GetShortenedFileName(Path.GetFileName(tempPDFPathsPro[0]));
                    }
                    else if (tempPDFPathsPro.Count > 1)
                    {
                        labelPDFProject.Text = $"{projectLogic.GetShortenedFileName(Path.GetFileName(tempPDFPathsPro[0]))} and {tempPDFPathsPro.Count - 1} more";
                    }
                    else
                    {
                        labelPDFProject.Text = "     Select or Drag a File";
                    }
                    buttonSave.ForeColor = Color.White;
                    panelPlus2.Show();
                    picturePlus2.Show();
                    picked2 = true;
                }
                else
                {
                    labelPDFProject.Text = "     Select or Drag a File";
                    buttonSave.ForeColor = Color.White;
                    picked2 = false;
                    panelPlus2.Hide();
                    picturePlus2.Hide();
                }
            }
        }

        private void dateTimePickerLimit_ValueChanged(object sender, EventArgs e)
        {
            buttonSave.ForeColor = Color.White;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            dysfunctionForm.OpenNewForm(new ProjectConsult(dysfunctionForm));
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
        private void CenterControl(Control ctrl)
        {
            ctrl.Left = (this.ClientSize.Width - ctrl.Width) / 2;
            ctrl.Top = (this.ClientSize.Height - ctrl.Height) / 2 - 20;
        }
        private void ProjectRegister_Resize(object sender, EventArgs e)
        {
            CenterControl(panel1);
        }

        private void panel3_MouseEnter(object sender, EventArgs e)
        {
            panelProject.BackColor = Color.FromArgb(40, 40, 40);
        }
        private void panel3_MouseLeave(object sender, EventArgs e)
        {
            panelProject.BackColor = Color.FromArgb(20, 20, 20);
        }
        private void panelIndications_MouseEnter(object sender, EventArgs e)
        {
            panelIndications.BackColor = Color.FromArgb(40, 40, 40);

        }
        private void panelIndications_MouseLeave(object sender, EventArgs e)
        {
            panelIndications.BackColor = Color.FromArgb(20, 20, 20);
        }
        private void LoadSelectionsFromXml()
        {
            if (File.Exists(xmlFilePath1))
            {
                var xml = XElement.Load(xmlFilePath1);
                periodSelection = xml.Element("Period")?.Value;
                asignatureSelection = xml.Element("Asignature")?.Value;

                // Si no hay una selección guardada para el período, seleccionar el primer elemento disponible
                if (string.IsNullOrEmpty(periodSelection) && comboBoxPeriod.Items.Count > 0)
                {
                    comboBoxPeriod.SelectedIndex = 0;
                    periodSelection = comboBoxPeriod.SelectedItem?.ToString();
                }
                else if (!string.IsNullOrEmpty(periodSelection) && comboBoxPeriod.Items.Contains(periodSelection))
                {
                    comboBoxPeriod.SelectedItem = periodSelection;
                }

                // Si no hay una selección guardada para la asignatura, seleccionar el primer elemento disponible
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
                if (tempPDFPathsInd.Count == 1)
                {
                    labelPDFIndications.Text = projectLogic.GetShortenedFileName(Path.GetFileName(tempPDFPathsInd[0]));
                }
                else if (tempPDFPathsInd.Count > 1)
                {
                    labelPDFIndications.Text = $"{projectLogic.GetShortenedFileName(Path.GetFileName(tempPDFPathsInd[0]))} and {tempPDFPathsInd.Count - 1} more";
                }
                else
                {
                    labelPDFIndications.Text = "     Select or Drag a File ";
                }
                buttonSave.ForeColor = Color.White;
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
            if (tempPDFPathsInd.Count == 1)
            {
                labelPDFIndications.Text = projectLogic.GetShortenedFileName(Path.GetFileName(tempPDFPathsInd[0]));
            }
            else if (tempPDFPathsInd.Count > 1)
            {
                labelPDFIndications.Text = $"{projectLogic.GetShortenedFileName(Path.GetFileName(tempPDFPathsInd[0]))} and {tempPDFPathsInd.Count - 1} more";
            }
            else
            {
                labelPDFIndications.Text = "     Select or Drag a File ";
            }
            buttonSave.ForeColor = Color.White;
            panelPlus1.Show();
            picturePlus1.Show();
            picked1 = true;
        }

        private void panelPlus1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
                buttonSave.ForeColor = Color.White;
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
                if (tempPDFPathsPro.Count == 1)
                {
                    labelPDFProject.Text = projectLogic.GetShortenedFileName(Path.GetFileName(tempPDFPathsPro[0]));
                }
                else if (tempPDFPathsPro.Count > 1)
                {
                    labelPDFProject.Text = $"{projectLogic.GetShortenedFileName(Path.GetFileName(tempPDFPathsPro[0]))} and {tempPDFPathsPro.Count - 1} more";
                }
                else
                {
                    labelPDFProject.Text = "     Select or Drag a File ";
                }
                buttonSave.ForeColor = Color.White;
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


            if (tempPDFPathsPro.Count == 1)
            {
                labelPDFProject.Text = projectLogic.GetShortenedFileName(Path.GetFileName(tempPDFPathsPro[0]));
            }
            else if (tempPDFPathsPro.Count > 1)
            {
                labelPDFProject.Text = $"{projectLogic.GetShortenedFileName(Path.GetFileName(tempPDFPathsPro[0]))} and {tempPDFPathsPro.Count - 1} more";
            }
            else
            {
                labelPDFProject.Text = "     Select or Drag a File ";
            }
            buttonSave.ForeColor = Color.White;
            panelPlus2.Show();
            picturePlus2.Show();
            picked2 = true;
        }

        private void panelPlus2_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
                buttonSave.ForeColor = Color.White;
            }
            panelPlus2.BackColor = Color.FromArgb(40, 40, 40);
            picturePlus2.BackColor = Color.FromArgb(40, 40, 40);
        }

        private void panelPlus2_DragLeave(object sender, EventArgs e)
        {
            panelPlus2.BackColor = Color.FromArgb(20, 20, 20);
            picturePlus2.BackColor = Color.FromArgb(20, 20, 20);
        }

        private void ProjectRegister_DragDrop(object sender, DragEventArgs e)
        {

        }

        private void ProjectRegister_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }
    }
}
