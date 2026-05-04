using Dysfunction.GUI.Consult;
using Dysfunction.GUI.Register;
using Dysfunction.Logic;
using Dysfunction.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace Dysfunction.GUI
{
    public partial class PeriodRegister : Form
    {
        periodLogic periodLogic = new periodLogic();
        asignatureLogic asignatureLogic = new asignatureLogic();
        private Dysfunction dysfunctionForm;
        string periodSelection;
        string asignatureSelection;
        int comboBoxAsignatureIndex;
        private List<string> tempPDFPathsOri = new List<string>();
        private List<string> tempPDFPathsMat = new List<string>();
        List<List<string>> pdfOri = new List<List<string>>();
        List<List<string>> pdfMat = new List<List<string>>();
        bool picked1 = false;
        bool picked2 = false;

        public PeriodRegister(Dysfunction dysfunction)
        {
            InitializeComponent();
            dysfunctionForm = dysfunction;
            dysfunction.cache = 0;
            Thread.CurrentThread.CurrentCulture = CultureInfo.CurrentCulture;
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CurrentCulture;

            FullCombo();
            FullCombo1();
            hide();
            panel1.AllowDrop = true;
            panel2.AllowDrop = true;
            panelPlus1.Hide();
            panelPlus2.Hide();
            picturePlus1.Hide();
            picturePlus2.Hide();
        }

        private void hide()
        {
            labelPeriod.Visible = false;
            if (listBox.Items.Count < 1)
            {
                listBox.Visible = false;
                labelList.Visible = false;
            }
            labelAsignature.Visible = false;
        }

        private void FullCombo()
        {
            int yearSelected = dateTimePickerYear.Value.Year;

            List<string> predefined = new List<string> { "I Period", "II Period", "III Period" };

            List<periodModel> registeredPeriods = periodLogic.Consult();

            foreach (var periodo in registeredPeriods)
            {
                if (periodo.Year == yearSelected && predefined.Contains(periodo.Period))
                {
                    predefined.Remove(periodo.Period);
                }
            }
            comboBoxPeriod.Items.Clear();
            comboBoxPeriod.Items.AddRange(predefined.ToArray());
            if (comboBoxPeriod.Items.Count > 0)
            {
                comboBoxPeriod.SelectedIndex = 0;
                periodSelection = comboBoxPeriod.SelectedItem?.ToString();
            }
            else
            {
                comboBoxPeriod.SelectedIndex = -1;
            }
        }

        private void FullCombo1()
        {
            List<asignatureModel> asignatureModels = asignatureLogic.Consult();

            foreach (var model in asignatureModels)
            {
                if (model != null && model.Approved == false)
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
                List<string> asignaturesSelected = listBox.Items.Cast<string>()
                    .Select(item => item.Split(new[] { " - " }, StringSplitOptions.None)[1])
                    .ToList();

                List<string> codes = new List<string>();

                foreach (var asignature in asignaturesSelected)
                {
                    codes.Add(asignatureLogic.ObtainCode(asignature));
                }
                periodModel periodModel = new periodModel(dateTimePickerYear.Value.Year, periodSelection, dateTimePickerStartDate.Value, dateTimePickerEndDate.Value, codes);
                periodLogic.NewObject(periodModel);

                for (int i = 0; i < codes.Count; i++)
                {
                    string code = codes[i];
                    if (i < pdfOri.Count && pdfOri[i].Count > 0)
                    {
                        periodLogic.SaveOri(code, periodSelection, dateTimePickerYear.Value.Year, pdfOri[i]);
                    }
                    if (i < pdfMat.Count && pdfMat[i].Count > 0)
                    {
                        periodLogic.SaveMat(code, periodSelection, dateTimePickerYear.Value.Year, pdfMat[i]);
                    }
                }

                pdfOri.Clear();
                pdfMat.Clear();
                listBox.Items.Clear();
                labelPeriod.Visible = false;
                listBox.Visible = false;
                labelList.Visible = false;
                FullCombo();
                comboBoxAsignature.Items.Clear();
                FullCombo1();
                tempPDFPathsOri.Clear();
                tempPDFPathsMat.Clear();
                labelPDF.Text = "Select or Drag a File ";
                labelPDFMat.Text = "Select or Drag a File ";
                picked1 = false;
                picked2 = false;
                panelPlus1.Hide();
                panelPlus2.Hide();
                picturePlus1.Hide();
                picturePlus2.Hide();
                buttonSave.ForeColor = Color.LightGreen;
                buttonSave.Text = "Saved";
                await Task.Delay(2000);
                buttonSave.ForeColor = Color.White;
                buttonSave.Text = "Save";
                await Task.Delay(10);
                labelAsignature.Visible = false;
            }
            else
            {
                if (!periodLogic.ValidNotNull(periodSelection))
                {
                    labelPeriod.Visible = true;
                }

                if (listBox.Items.Count <= 0)
                {
                    buttonSave.ForeColor = Color.Red;
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
                    await Task.Delay(1000);
                    buttonSave.ForeColor = Color.White;
                }
            }
        }

        private async void buttonAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(asignatureSelection) && !string.IsNullOrEmpty(periodSelection))
            {
                buttonSave.ForeColor = Color.Empty;
                listBox.Visible = true;
                labelList.Visible = true;
                string asignatureSelected = comboBoxAsignature.SelectedItem?.ToString();

                if (!string.IsNullOrEmpty(asignatureSelected) && !listBox.Items.Contains(asignatureSelected))
                {
                    comboBoxAsignatureIndex = comboBoxAsignature.SelectedIndex;
                    string item = asignatureLogic.ObtainCode(asignatureSelected) + " - " + asignatureSelected;

                    if (!listBox.Items.Contains(item))
                    {
                        listBox.Items.Add(item);
                    }

                    pdfOri.Add(new List<string>(tempPDFPathsOri));
                    pdfMat.Add(new List<string>(tempPDFPathsMat));

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
                labelPDF.Text = "Select or Drag a File ";
                labelPDFMat.Text = "Select or Drag a File ";
                picked1 = false;
                picked2 = false;
                panelPlus1.Hide();
                panelPlus2.Hide();
                picturePlus1.Hide();
                picturePlus2.Hide();
            }
            else
            {
                labelAsignature.Visible = true;
                buttonAdd.ForeColor = Color.Red;
                await Task.Delay(2000);
                buttonAdd.ForeColor = Color.White;
            }
        }

        private void listBox_MouseClick(object sender, MouseEventArgs e)
        {
            int index = listBox.IndexFromPoint(e.Location);
            buttonSave.ForeColor = Color.White;
            if (index != ListBox.NoMatches)
            {
                string deletedAsignature = listBox.Items[index].ToString();

                string[] parts = deletedAsignature.Split(new[] { " - " }, StringSplitOptions.None);
                if (parts.Length > 1)
                {
                    listBox.Items.RemoveAt(index);

                    if (index < pdfOri.Count)
                    {
                        pdfOri.RemoveAt(index);
                    }
                    if (index < pdfMat.Count)
                    {
                        pdfMat.RemoveAt(index);
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
                listBox.Visible = false;
                labelList.Visible = false;
            }
        }

        private void dateTimePickerStartDate_ValueChanged(object sender, EventArgs e)
        {
            FullCombo();
            if (dateTimePickerStartDate.Value < dateTimePickerEndDate.Value)
            {
                  dateTimePickerStartDate.Value = dateTimePickerEndDate.Value;
            }

            buttonSave.ForeColor = Color.White;
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
                        labelPDF.Text = periodLogic.GetShortenedFileName(Path.GetFileName(tempPDFPathsOri[0]));
                    }
                    else if (tempPDFPathsOri.Count > 1)
                    {
                        labelPDF.Text = $"{periodLogic.GetShortenedFileName(Path.GetFileName(tempPDFPathsOri[0]))} and {tempPDFPathsOri.Count - 1} more";
                    }
                    else
                    {
                        labelPDF.Text = "Select or Drag a File ";
                    }
                    picked1 = true;
                    buttonAdd.ForeColor = Color.White;
                    buttonSave.ForeColor = Color.White;
                    panelPlus1.Show();
                    picturePlus1.Show();
                }
            }
            else
            {
                if (tempPDFPathsOri.Count > 0)
                {
                    tempPDFPathsOri.RemoveAt(tempPDFPathsOri.Count - 1);
                }

                if (tempPDFPathsOri.Count > 0)
                {
                    if (tempPDFPathsOri.Count == 1)
                    {
                        labelPDF.Text = periodLogic.GetShortenedFileName(Path.GetFileName(tempPDFPathsOri[0]));
                    }
                    else
                    {
                        labelPDF.Text = $"{periodLogic.GetShortenedFileName(Path.GetFileName(tempPDFPathsOri[0]))} and {tempPDFPathsOri.Count - 1} more";
                    }
                    panelPlus1.Show();
                    picturePlus1.Show();
                    picked1 = true;
                }
                else
                {
                    labelPDF.Text = "Select or Drag a File ";
                    picked1 = false;
                    panelPlus1.Hide();
                    picturePlus1.Hide();
                }
                buttonAdd.ForeColor = Color.White;
                buttonSave.ForeColor = Color.White;
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
                    buttonSave.ForeColor = Color.White;
                    panelPlus2.Show();
                    picturePlus2.Show();
                }
            }
            else
            {
                if (tempPDFPathsMat.Count > 0)
                {
                    tempPDFPathsMat.RemoveAt(tempPDFPathsMat.Count - 1);
                }

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
                buttonAdd.ForeColor = Color.White;
                buttonSave.ForeColor = Color.White;
            }
        }

        private void panelInteractive1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            tempPDFPathsOri.Clear();
            tempPDFPathsOri.AddRange(files);
            if (tempPDFPathsOri.Count == 1)
            {
                labelPDF.Text = periodLogic.GetShortenedFileName(Path.GetFileName(tempPDFPathsOri[0]));
            }
            else if (tempPDFPathsOri.Count > 1)
            {
                labelPDF.Text = $"{periodLogic.GetShortenedFileName(Path.GetFileName(tempPDFPathsOri[0]))} and {tempPDFPathsOri.Count - 1} more";
            }
            else
            {
                labelPDF.Text = "Select or Drag a File ";
            }
            picked1 = true;
            buttonSave.ForeColor = Color.White;
            panelPlus1.Show();
            picturePlus1.Show();
        }

        private void panelInteractive2_DragDrop(object sender, DragEventArgs e)
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
            buttonSave.ForeColor = Color.White;
            panelPlus2.Show();
            picturePlus2.Show();
        }

        private void panel_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            if (sender == panel1 || sender == labelPDF)
            {
                panel1.BackColor = Color.FromArgb(40, 40, 40);
            }
            else if (sender == panel2 || sender == labelPDFMat)
            {
                panel2.BackColor = Color.FromArgb(40, 40, 40);
            }
        }

        private void panel_DragLeave(object sender, EventArgs e)
        {
            if (sender == panel1 || sender == labelPDF)
            {
                panel1.BackColor = Color.FromArgb(20, 20, 20);
            }
            else if (sender == panel2 || sender == labelPDFMat)
            {
                panel2.BackColor = Color.FromArgb(20, 20, 20);
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
                    if (!tempPDFPathsOri.Contains(file))
                        tempPDFPathsOri.Add(file);
                }
                if (tempPDFPathsOri.Count == 1)
                {
                    labelPDF.Text = periodLogic.GetShortenedFileName(Path.GetFileName(tempPDFPathsOri[0]));
                }
                else if (tempPDFPathsOri.Count > 1)
                {
                    labelPDF.Text = $"{periodLogic.GetShortenedFileName(Path.GetFileName(tempPDFPathsOri[0]))} and {tempPDFPathsOri.Count - 1} more";
                }
                else
                {
                    labelPDF.Text = "Select or Drag a File ";
                }
                buttonSave.ForeColor = Color.White;
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
                labelPDF.Text = periodLogic.GetShortenedFileName(Path.GetFileName(tempPDFPathsOri[0]));
            }
            else if (tempPDFPathsOri.Count > 1)
            {
                labelPDF.Text = $"{periodLogic.GetShortenedFileName(Path.GetFileName(tempPDFPathsOri[0]))} and {tempPDFPathsOri.Count - 1} more";
            }
            else
            {
                labelPDF.Text = "Select or Drag a File ";
            }
            buttonSave.ForeColor = Color.White;
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
                buttonSave.ForeColor = Color.White;
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
                buttonSave.ForeColor = Color.White;
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
            buttonSave.ForeColor = Color.White;
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
                buttonSave.ForeColor = Color.White;
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

        private void comboBoxPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            periodSelection = comboBoxPeriod.SelectedItem?.ToString();
            buttonSave.ForeColor = Color.White;
        }

        private void dateTimePickerEndDate_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePickerStartDate.Value < dateTimePickerEndDate.Value)
            {
                 dateTimePickerEndDate.Value = dateTimePickerStartDate.Value ;
            }
            FullCombo();
            buttonSave.ForeColor = Color.White;
        }

        private void comboBoxAsignature_SelectedIndexChanged(object sender, EventArgs e)
        {
            asignatureSelection = comboBoxAsignature.SelectedItem?.ToString();
            buttonSave.ForeColor = Color.White;
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

        private void PeriodRegister_MouseEnter(object sender, EventArgs e)
        {
            panel5.BackColor = Color.FromArgb(0, 0, 0);
            panel7.BackColor = Color.FromArgb(0, 0, 0);
        }

        private void panel5_MouseDown(object sender, MouseEventArgs e)
        {
            dysfunctionForm.OpenNewForm(new AsignatureRegister(dysfunctionForm, false));
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
            dysfunctionForm.OpenNewForm(new AsignatureEdit(dysfunctionForm, false));
        }

        private void panel7_MouseEnter(object sender, EventArgs e)
        {
            panel7.BackColor = Color.FromArgb(20, 20, 20);
        }

        private void panel7_MouseLeave(object sender, EventArgs e)
        {
            panel7.BackColor = Color.FromArgb(0, 0, 0);
        }

        private void CenterControl(Control ctrl)
        {
            ctrl.Left = (this.ClientSize.Width - ctrl.Width) / 2;
            ctrl.Top = (this.ClientSize.Height - ctrl.Height) / 2;
        }

        private void PeriodRegister_Resize(object sender, EventArgs e)
        {
            CenterControl(panel8);
        }

        private void panel1_MouseEnter(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(40, 40, 40);
        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(20, 20, 20);
        }

        private void panel2_MouseEnter(object sender, EventArgs e)
        {
            panel2.BackColor = Color.FromArgb(40, 40, 40);
        }

        private void panel2_MouseLeave(object sender, EventArgs e)
        {
            panel2.BackColor = Color.FromArgb(20, 20, 20);
        }

        private void buttonContinue_Click(object sender, EventArgs e)
        {
        }

        private void dateTimePickerYear_ValueChanged(object sender, EventArgs e)
        {
            FullCombo();
            buttonSave.ForeColor = Color.White;
        }

        private void PeriodRegister_Load(object sender, EventArgs e)
        {
        }

        private void panel1_DragLeave(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(20, 20, 20);
        }

        private void panel2_DragLeave(object sender, EventArgs e)
        {
            panel2.BackColor = Color.FromArgb(20, 20, 20);
        }

        private void panelAsignatures_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
                buttonSave.ForeColor = Color.White;
                buttonAdd.ForeColor = Color.White;
            }
        }

        private void PeriodRegister_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
                buttonSave.ForeColor = Color.White;
                buttonAdd.ForeColor = Color.White;
            }
        }

        private void panelPeriod_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
                buttonSave.ForeColor = Color.White;
                buttonAdd.ForeColor = Color.White;
            }
        }

        private void panel8_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
                buttonSave.ForeColor = Color.White;
                buttonAdd.ForeColor = Color.White;
            }
        }

        private void labelPDF_DragLeave(object sender, EventArgs e)
        {
            
        }

        private void labelPDF_DragEnter(object sender, DragEventArgs e)
        {
            panel1.BackColor = Color.FromArgb(20, 20, 20);
        }
    }
}