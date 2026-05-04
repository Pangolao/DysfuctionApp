using Dysfunction.Data;
using Dysfunction.Logic;
using Dysfunction.Model;
using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Dysfunction.GUI.Register
{
    public partial class AsignatureRegister : Form
    {
        asignatureLogic asignatureLogic = new asignatureLogic();
        string xmlFilePath = "AsignatureSelections.xml";
        private Dysfunction dysfunctionForm;
        private bool openedFromPeriodEdit;


        public AsignatureRegister(Dysfunction dysfunction, bool openedFromPeriodEdit)
        {
            InitializeComponent();
            dysfunctionForm = dysfunction;
            Thread.CurrentThread.CurrentCulture = CultureInfo.CurrentCulture;
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CurrentCulture;
            hideLabels();
            LoadSelectionsFromXml();
            this.openedFromPeriodEdit = openedFromPeriodEdit;
        }

        private void hideLabels()
        {
            labelAsignature.Visible = false;
            labelCode.Visible = false;
        }

        private async void buttonSave_Click(object sender, EventArgs e)
        {
            if (asignatureLogic.ValidNotNull(textBoxCode.Text) && asignatureLogic.ValidUniqueCode(textBoxCode.Text) &&
                asignatureLogic.ValidNotNull(textBoxAsignature.Text) && asignatureLogic.ValidUniqueName(textBoxAsignature.Text))
            {
                asignatureModel asignatureModel = new asignatureModel(null, textBoxCode.Text, textBoxAsignature.Text, textBoxTeacher.Text, textBoxGroup.Text, false);
                asignatureLogic.NewObject(asignatureModel);

                textBoxAsignature.Text = "";
                textBoxTeacher.Text = "";
                textBoxGroup.Text = "";
                textBoxCode.Text = "";
                SaveSelectionsToXml();
                hideLabels();
                buttonSave.ForeColor = Color.LightGreen;
                buttonSave.Text = "Saved";
                await Task.Delay(2000);
                buttonSave.Text = "Save";
                buttonSave.ForeColor = Color.White;
            }
            else
            { 
                if (!asignatureLogic.ValidNotNull(textBoxCode.Text) || !asignatureLogic.ValidUniqueCode(textBoxCode.Text))
                {
                    labelCode.Visible = true;
                }
                if (!asignatureLogic.ValidNotNull(textBoxAsignature.Text) || !asignatureLogic.ValidUniqueName(textBoxAsignature.Text))
                {
                    labelAsignature.Visible = true;
                }
                buttonSave.ForeColor = Color.Red;
                await Task.Delay(2000);
                buttonSave.ForeColor = Color.White;

               
            }
        }

        private void textBoxAsignature_TextChanged(object sender, EventArgs e)
        {
            if (!asignatureLogic.ValidNotNull(textBoxAsignature.Text) || !asignatureLogic.ValidUniqueName(textBoxAsignature.Text))
            {
                labelAsignature.Visible = true;
            }
            else
            {
                buttonSave.ForeColor = Color.White;
                labelAsignature.Visible = false;
                textBoxAsignature.Text= textBoxAsignature.Text.Replace(',', '.');
                textBoxAsignature.SelectionStart = textBoxAsignature.Text.Length;
            }
            SaveSelectionsToXml();
        }

        private void textBoxAsignature_Click(object sender, EventArgs e)
        {
            buttonSave.ForeColor = Color.White;
            labelAsignature.Visible = false;

        }

        private void textBoxTeacher_Click(object sender, EventArgs e)
        {
            buttonSave.ForeColor = Color.White;
        }

        private void textBoxGroup_Click(object sender, EventArgs e)
        {
            buttonSave.ForeColor = Color.White;
        }

        private void textBoxCode_TextChanged(object sender, EventArgs e)
        {
            if (!asignatureLogic.ValidNotNull(textBoxCode.Text) || !asignatureLogic.ValidUniqueCode(textBoxCode.Text))
            {
                labelCode.Visible = true;
            }
            else
            {
                buttonSave.ForeColor = Color.White;
                labelCode.Visible = false;
                textBoxCode.Text= textBoxCode.Text.Replace(',', '.');
                textBoxCode.SelectionStart = textBoxCode.Text.Length;
            }
            SaveSelectionsToXml();
        }

        private void textBoxCode_Click(object sender, EventArgs e)
        {
            buttonSave.ForeColor = Color.White;
            labelCode.Visible = false;
        }

        private void textBoxTeacher_TextChanged(object sender, EventArgs e)
        {
            buttonSave.ForeColor = Color.White;
            SaveSelectionsToXml();
        }

        private void textBoxGroup_TextChanged(object sender, EventArgs e)
        {
            buttonSave.ForeColor = Color.White;
            SaveSelectionsToXml();
        }

        private void SaveSelectionsToXml()
        {
            var xml = new XElement("Selections",
                new XElement("Asignature", textBoxAsignature.Text),
                new XElement("Code", textBoxCode.Text),
                new XElement("Teacher", textBoxTeacher.Text),
                new XElement("Group", textBoxGroup.Text)
            );
            xml.Save(xmlFilePath);
        }

        private void LoadSelectionsFromXml()
        {
            if (File.Exists(xmlFilePath))
            {
                var xml = XElement.Load(xmlFilePath);
                textBoxAsignature.Text = xml.Element("Asignature")?.Value ?? string.Empty;
                textBoxCode.Text = xml.Element("Code")?.Value ?? string.Empty;
                textBoxTeacher.Text = xml.Element("Teacher")?.Value ?? string.Empty;
                textBoxGroup.Text = xml.Element("Group")?.Value ?? string.Empty;
            }
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


        private void AsignatureRegister_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.FromArgb(0, 0, 0);
        }

        private void AsignatureRegister_Load(object sender, EventArgs e)
        {

        }

        private void CenterControl(Control ctrl)
        {
            ctrl.Left = (this.ClientSize.Width - ctrl.Width) / 2;
            ctrl.Top = (this.ClientSize.Height - ctrl.Height) / 2  ;
        }

        private void AsignatureRegister_Resize(object sender, EventArgs e)
        {
            CenterControl(panel2);
        }
    }
}
