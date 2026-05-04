using Dysfunction.Data;
using Dysfunction.GUI.Consult;
using Dysfunction.Logic;
using Dysfunction.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Dysfunction.GUI.Register
{
    public partial class ProjectScoreRegister : Form
    {
        string asignatureSelection;
        float value;
        string projectSelection;
        string periodSelection;
        projectLogic projectLogic = new projectLogic();
        periodLogic periodLogic = new periodLogic();
        private Dysfunction dysfunctionForm;
        asignatureLogic asignatureLogic = new asignatureLogic();
        string xmlFilePath1 = "Selections.xml";
        public ProjectScoreRegister(Dysfunction dysfunction)
        {
            InitializeComponent();
            dysfunctionForm = dysfunction;
            Thread.CurrentThread.CurrentCulture = CultureInfo.CurrentCulture;
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CurrentCulture;
            hideLabels();
            FullComboPeriod();
            FullComboAsignature();
            FullComboProject();
            LoadSelectionsFromXml();
        }
        private void hideLabels()
        {
            labelAsignature.Visible = false;
            labelProject.Visible = false;
            labelPeriod.Visible = false;
            labelScore.Visible = false;
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
                labelAsignature.Visible = false;
                asignatureSelection = comboBoxAsignature.SelectedItem?.ToString();
            }
            else
            {
                labelAsignature.Visible = true;
            }
        }


        private void FullComboProject()
        {

            List<projectModel> projectModels = projectLogic.Consult();
            comboBoxProject.Items.Clear();
            foreach (var project in projectModels)
            {
                if (project != null && project.Code == asignatureLogic.ObtainCode(asignatureSelection) && project.Period == periodSelection && project.Year == dateTimePicker.Value.Year)
                {
                    comboBoxProject.Items.Add(project.Project);
                }
            }

            if (comboBoxProject.Items.Count > 0)
            {
                if (ProjectConsult.projectName != "")
                {
                    comboBoxProject.SelectedItem = ProjectConsult.projectName;
                }
                projectSelection = comboBoxProject.SelectedItem?.ToString();
                labelProject.Visible = false;
            }
            else
            {
                labelProject.Visible = true;
            }
        }

        private async void buttonSave_Click(object sender, EventArgs e)
        {
            if (projectLogic.ValidNotNull(periodSelection) && projectLogic.ValidNotNull(asignatureLogic.ObtainCode(asignatureSelection)) && projectLogic.ValidNotNull(projectSelection) &&
                projectLogic.ValidFloat(textBoxScore.Text) && projectLogic.ValidNotNull(textBoxScore.Text))
            {

                List<projectModel> projectModels = projectLogic.Consult();
                var selectedProject = projectModels.FirstOrDefault(p => p.Period == periodSelection && p.Code == asignatureLogic.ObtainCode(asignatureSelection) && p.Project == projectSelection && p.Year == dateTimePicker.Value.Year);

                if (selectedProject != null)
                {
                    selectedProject.Score = float.Parse(textBoxScore.Text);
                    asignatureLogic.UpdateFinalScore(asignatureLogic.ObtainCode(asignatureSelection), periodSelection, dateTimePicker.Value.Year);
                    projectLogic.updateProject(selectedProject);

                    textBoxScore.Text = "";
                    buttonSave.ForeColor = Color.LightGreen;
                    buttonSave.Text = "Saved";
                    await Task.Delay(2000);
                    buttonSave.ForeColor = Color.White;
                    buttonSave.Text = "Save";


                    hideLabels();
                }

            }
            else
            {
                

                if (!projectLogic.ValidNotNull(periodSelection))
                {
                    labelPeriod.Visible = true;
                }

                if (!projectLogic.ValidNotNull(asignatureLogic.ObtainCode(asignatureSelection)))
                {
                    labelAsignature.Visible = true;
                }
                if (!projectLogic.ValidNotNull(projectSelection))
                {
                    labelProject.Visible = true;
                }
                if (!projectLogic.ValidFloat(textBoxScore.Text))
                {
                    labelScore.Visible = true;
                }
                buttonSave.ForeColor = Color.Red;
                await Task.Delay(2000);
                buttonSave.ForeColor = Color.White;
            }
        }
        private void textBoxScore_TextChanged(object sender, EventArgs e)
        {
            textBoxScore.Text = textBoxScore.Text.Replace(',', '.');

            textBoxScore.SelectionStart = textBoxScore.Text.Length;

            if (!projectLogic.ValidFloat(textBoxScore.Text))
            {
                textBoxScore.ForeColor = Color.Red;
                labelScore.Visible = true;
            }
            else
            {
                buttonSave.ForeColor = Color.White;
                labelScore.Visible = false;
                textBoxScore.ForeColor = Color.White;
            }
        }
        private void textBoxScore_Click(object sender, EventArgs e)
        {
            buttonSave.ForeColor = Color.White;
            labelScore.Visible = false;
        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            FullComboPeriod();
            FullComboAsignature();
            FullComboProject();
            buttonSave.ForeColor = Color.White;
        }

        private void comboBoxPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            periodSelection = comboBoxPeriod.SelectedItem?.ToString();
            FullComboAsignature();
            FullComboProject();
            buttonSave.ForeColor = Color.White;
        }

        private void comboBoxAsignature_SelectedIndexChanged(object sender, EventArgs e)
        {
            asignatureSelection = comboBoxAsignature.SelectedItem?.ToString();
            FullComboProject();
            buttonSave.ForeColor = Color.White;
        }

        private void comboBoxProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            projectSelection = comboBoxProject.SelectedItem?.ToString();
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
            ctrl.Top = (this.ClientSize.Height - ctrl.Height) / 2 - 30 ;
        }

        private void ProjectScoreRegister_Resize(object sender, EventArgs e)
        {
            CenterControl(panel2);
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
                // Si el archivo XML no existe, seleccionar el primer elemento disponible en ambos ComboBox
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
    }
}
