using Dysfunction.Data;
using Dysfunction.Logic;
using Dysfunction.Model;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace Dysfunction.GUI.Register
{
    public partial class AsignatureEdit : Form
    {
        asignatureLogic asignatureLogic = new asignatureLogic();
        private Dysfunction dysfunctionForm;
        string codeSelection = null;
        private bool openedFromPeriodEdit;
        int contador = 0;

        public AsignatureEdit(Dysfunction dysfunction, bool openedFromPeriodEdit)
        {
            InitializeComponent();
            dysfunctionForm = dysfunction;
            Thread.CurrentThread.CurrentCulture = CultureInfo.CurrentCulture;
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CurrentCulture;
            hideLabels();
            FullComboCode();
            this.openedFromPeriodEdit = openedFromPeriodEdit;
        }
        private void hideLabels()
        {
            labelAsignature.Visible = false;
            labelCode.Visible = false;
        }
        private void FullComboCode()
        {
            comboBoxCode.Items.Clear();
            List<asignatureModel> asignatureModels = asignatureLogic.Consult();

            foreach (var asignature in asignatureModels)
            {
                if (asignature != null)
                {
                    comboBoxCode.Items.Add($"{asignature.Code}, {asignature.Asignature}");
                    comboBoxCode.SelectedItem = 0;
                }
            }
        }

        private async void buttonSaveEdit_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(codeSelection) && !string.IsNullOrEmpty(textBoxAsignature.Text))
            {
                List<asignatureModel> asignatureModels = asignatureLogic.Consult();
                var asignatureSelected = asignatureModels.FirstOrDefault(asignature =>
                    asignature.Code == codeSelection);

                if (asignatureSelected != null)
                {
                    asignatureSelected.Asignature = textBoxAsignature.Text;
                    asignatureSelected.Teacher = textBoxTeacher.Text;
                    asignatureSelected.Group = textBoxGroup.Text;

                    asignatureLogic.EditObject(asignatureSelected);
                    textBoxAsignature.Text = "";
                    textBoxTeacher.Text = "";
                    textBoxGroup.Text = "";
                    comboBoxCode.SelectedIndex = -1;
                    labelAsignature.Visible = false;
                    textBoxAsignature.Enabled = false;
                    textBoxTeacher.Enabled = false;
                    textBoxGroup.Enabled = false;
                    hideLabels();
                    buttonEdit.ForeColor = Color.LightGreen;
                    buttonEdit.Text = "Saved";
                    await Task.Delay(2000);
                    buttonEdit.ForeColor = Color.White;
                    buttonEdit.Text = "Save Edit";
                    FullComboCode();

                }
            }
            else
            {
                buttonEdit.ForeColor = Color.Red;
                await Task.Delay(2000);
                buttonEdit.ForeColor = Color.White;
                if (string.IsNullOrEmpty(codeSelection))
                {
                    labelCode.Visible = true;
                }
                if (string.IsNullOrEmpty(textBoxAsignature.Text))
                {
                    labelAsignature.Visible = true;
                }
            }
        }
        private async void buttonDelete_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(codeSelection) && !asignatureLogic.ValidAsignatureInPeriod(codeSelection))
            {
                List<asignatureModel> asignatureModels = asignatureLogic.Consult();
                var asignatureSelected = asignatureModels.FirstOrDefault(asignature =>
                    asignature.Code == codeSelection);

                if (asignatureSelected != null)
                {
                    contador++;
                    if (contador == 1)
                    {
                        buttonDelete.ForeColor = Color.Yellow;
                        buttonDelete.FlatAppearance.MouseOverBackColor = Color.Black;
                        buttonDelete.Text = "Are you sure? Click again";

                        buttonEdit.FlatAppearance.BorderColor = Color.White;
                        await Task.Delay(2000);
                        buttonEdit.FlatAppearance.BorderColor = Color.FromArgb(64,64,64);
                        await Task.Delay(2000);
                        buttonEdit.FlatAppearance.BorderColor = Color.White;
                        await Task.Delay(2000);
                        buttonEdit.FlatAppearance.BorderColor = Color.FromArgb(64, 64, 64);
                        await Task.Delay(2000);
                        buttonEdit.FlatAppearance.BorderColor = Color.White;
                        await Task.Delay(2000);
                        buttonEdit.FlatAppearance.BorderColor = Color.FromArgb(64, 64, 64);

                    }

                    if (contador == 2)
                    {
                        contador = 0;
                        asignatureLogic.DeleteObject(asignatureSelected);
                        textBoxAsignature.Text = "";
                        textBoxTeacher.Text = "";
                        textBoxGroup.Text = "";
                        comboBoxCode.SelectedIndex = -1;
                        labelAsignature.Visible = false;
                        labelCode.Visible = false;
                        textBoxAsignature.Enabled = false;
                        textBoxTeacher.Enabled = false;
                        textBoxGroup.Enabled = false;
                        buttonDelete.ForeColor = Color.LightGreen;
                        buttonDelete.Text = "Deleted";
                        FullComboCode();
                        await Task.Delay(2000);
                        buttonDelete.ForeColor = Color.White;
                        buttonDelete.Text = "Delete";
                        buttonDelete.FlatAppearance.MouseOverBackColor = Color.FromArgb(20, 20, 20);
                    }

                }
            }
            else
            {
                if (string.IsNullOrEmpty(codeSelection))
                {
                    labelCode.Visible = true;
                }
                if (string.IsNullOrEmpty(textBoxAsignature.Text))
                {
                    labelAsignature.Visible = true;
                }

                buttonDelete.ForeColor = Color.Red;


                if (asignatureLogic.ValidAsignatureInPeriod(codeSelection))
                {
                    buttonDelete.Text = "That asignature is in a period";
                }

                await Task.Delay(2000);
                buttonDelete.ForeColor = Color.White;
                buttonDelete.Text = "Delete";


            }

        }
        private void textBoxAsignature_TextChanged(object sender, EventArgs e)
        {
            if (!asignatureLogic.ValidNotNull(textBoxAsignature.Text))
            {
                labelAsignature.Visible = true;
                
            }
            else
            {
                buttonEdit.ForeColor = Color.White;
                buttonDelete.ForeColor = Color.White;
                labelAsignature.Visible = false;
                textBoxAsignature.Text = textBoxAsignature.Text.Replace(',', '.');
                textBoxAsignature.SelectionStart = textBoxAsignature.Text.Length;
            }
        }
        private void textBoxAsignature_Click(object sender, EventArgs e)
        {
            buttonEdit.ForeColor = Color.White;
            labelAsignature.Visible = false;
            buttonDelete.ForeColor = Color.White;
        }

        private void textBoxTeacher_Click(object sender, EventArgs e)
        {
            buttonEdit.ForeColor = Color.White;
            buttonDelete.ForeColor = Color.White;
        }

        private void textBoxGroup_Click(object sender, EventArgs e)
        {
            buttonEdit.ForeColor = Color.White;
            buttonDelete.ForeColor = Color.White;
        }


        private void comboBoxCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = comboBoxCode.SelectedItem?.ToString();
            textBoxAsignature.Enabled = true;
            textBoxTeacher.Enabled = true;
            textBoxGroup.Enabled = true;
            buttonEdit.ForeColor = Color.White;
            buttonDelete.ForeColor = Color.White;

            if (!string.IsNullOrEmpty(selectedItem))
            {
                codeSelection = selectedItem.Split(',')[0].Trim();

                labelCode.Visible = false;
                buttonEdit.ForeColor = Color.White;
                buttonDelete.ForeColor = Color.White;

                List<asignatureModel> asignatureModels = asignatureLogic.Consult();
                var asignatureSelected = asignatureModels.FirstOrDefault(asignature =>
                    asignature.Code == codeSelection);

                if (asignatureSelected != null)
                {
                    textBoxAsignature.Text = asignatureSelected.Asignature;
                    textBoxTeacher.Text = asignatureSelected.Teacher;
                    textBoxGroup.Text = asignatureSelected.Group;
                }
            }
            else
            {
                labelCode.Visible = true;
            }
        }
        private void textBoxTeacher_TextChanged(object sender, EventArgs e)
        {
            buttonEdit.ForeColor = Color.White;
            buttonDelete.ForeColor = Color.White;
        }

        private void textBoxGroup_TextChanged(object sender, EventArgs e)
        {
            buttonEdit.ForeColor = Color.White;
            buttonDelete.ForeColor = Color.White;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (openedFromPeriodEdit)
            {
                dysfunctionForm.OpenNewForm(new PeriodEdit(dysfunctionForm));
            }
            else
            {
                dysfunctionForm.OpenNewForm(new PeriodRegister(dysfunctionForm));
            }
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.FromArgb(20, 20, 20);
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.FromArgb(0, 0, 0);
        }

        private void AsignatureEdit_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.FromArgb(0, 0, 0);
        }
        private void CenterControl(Control ctrl)
        {
            ctrl.Left = (this.ClientSize.Width - ctrl.Width) / 2;
            ctrl.Top = (this.ClientSize.Height - ctrl.Height) / 2;
        }
        private void AsignatureEdit_Resize(object sender, EventArgs e)
        {
            CenterControl(panel2);
        }
    }
}
  