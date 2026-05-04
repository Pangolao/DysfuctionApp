using Dysfunction.GUI.Consult;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using IWshRuntimeLibrary;
using System.Runtime.InteropServices;

namespace Dysfunction
{
    public partial class Settings : Form
    {
        private SoundPlayer parararaa;
        private SoundPlayer parararaa1;
        private Dysfunction dysfunctionForm;
        string xmlFilePath = "Settings.xml";
        string start;

        public Settings(Dysfunction dysfunction)
        {
            InitializeComponent();

            dysfunctionForm = dysfunction;

            loadSettings();
            atStart();
        }

        private void loadSettings()
        {
            if (System.IO.File.Exists(xmlFilePath))
            {
                var xml = XElement.Load(xmlFilePath);

                dysfunctionForm.minimizar = (int?)xml.Element("minimizar") ?? 0;
                dysfunctionForm.notificaciones = (int?)xml.Element("notificaciones") ?? 1;
                dysfunctionForm.windows = (int?)xml.Element("windows") ?? 0;
                dysfunctionForm.userName = (string)xml.Element("userName") ?? "";
                dysfunctionForm.buttonPeriod = (int?)xml.Element("buttonPeriod") ?? 0;
                dysfunctionForm.buttonProject = (int?)xml.Element("buttonProject") ?? 0;
                dysfunctionForm.buttonNamePeriod = (string)xml.Element("buttonNamePeriod") ?? "";
                dysfunctionForm.buttonLinkPeriod = (string)xml.Element("buttonLinkPeriod") ?? "";
                dysfunctionForm.buttonNameProject = (string)xml.Element("buttonNameProject") ?? "";
                dysfunctionForm.buttonLinkProject = (string)xml.Element("buttonLinkProject") ?? "";

            }
        }

        private void atStart()
        {

            if (string.IsNullOrEmpty(dysfunctionForm.buttonNamePeriod))
            {
                textBoxNamePeriod.Text = "University";
            }
            else
            {
                textBoxNamePeriod.Text = dysfunctionForm.buttonNamePeriod;
            }
            if (string.IsNullOrEmpty(dysfunctionForm.buttonNameProject))
            {
                textBoxNameProject.Text = "Platform";
            }
            else
            {
                textBoxNameProject.Text = dysfunctionForm.buttonNameProject;
            }

            textBoxLinkPeriod.Text = dysfunctionForm.buttonLinkPeriod;
            textBoxLinkProject.Text = dysfunctionForm.buttonLinkProject;
            textBoxName.Text = dysfunctionForm.userName;



            if (dysfunctionForm.minimizar == 1)
            {
                checkBox1.Checked = true;
            }
            else
            {
                checkBox1.Checked = false;
            }

            if (dysfunctionForm.buttonPeriod == 1)
            {
                checkBoxPeriod.Checked = true;
                panelPeriod.Visible = true;
            }
            else
            {
                checkBoxPeriod.Checked = false;
                panelPeriod.Visible = false;
            }
            if (dysfunctionForm.buttonProject == 1)
            {
                checkBoxProject.Checked = true;
                panelProject.Visible = true;
            }
            else
            {
                checkBoxProject.Checked = false;
                panelProject.Visible = false;
            }
            if (dysfunctionForm.notificaciones == 0)
            {
                checkBox2.Checked = false;
                checkBox4.Visible = checkBox2.Checked;
                checkBox5.Visible = checkBox2.Checked;
                label7.Visible = checkBox2.Checked;

            }
            else if (dysfunctionForm.notificaciones == 1)
            {
                checkBox2.Checked = true;
                checkBox4.Checked = true;
            }
            else if (dysfunctionForm.notificaciones == 2)
            {
                checkBox2.Checked = true;
                checkBox5.Checked = true;
            }
            else if (dysfunctionForm.notificaciones == 3)
            {
                checkBox2.Checked = true;
            }
            else if (dysfunctionForm.notificaciones == 4)
            {
                checkBox2.Checked = true;
            }

            if (dysfunctionForm.windows == 1)
            {
                checkBox3.Checked = true;
            }
            else
            {
                checkBox3.Checked = false;
            }
        }

        private void CreateStartupShortcut()
        {
            try
            {
                string startupFolder = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
                string shortcutPath = Path.Combine(startupFolder, "Dysfunction.lnk");
                string exePath = Application.ExecutablePath;

                WshShell shell = new WshShell();
                IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutPath);

                shortcut.TargetPath = exePath;
                shortcut.WorkingDirectory = Path.GetDirectoryName(exePath);
                shortcut.Description = "Iniciar Dysfunction al arrancar";
                shortcut.Save();

                Marshal.ReleaseComObject(shortcut);
                Marshal.ReleaseComObject(shell);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creando acceso directo: {ex.Message}");
            }
        }

        private void DeleteStartupShortcut()
        {
            try
            {
                string startupFolder = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
                string shortcutPath = Path.Combine(startupFolder, "Dysfunction.lnk");

                if (System.IO.File.Exists(shortcutPath))
                {
                    System.IO.File.Delete(shortcutPath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error eliminando acceso directo: {ex.Message}");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            dysfunctionForm.minimizar = checkBox1.Checked ? 1 : 0;
            SaveSelectionsToXml();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            dysfunctionForm.notificaciones = checkBox2.Checked ? 1 : 0;
            SaveSelectionsToXml();
            checkBox4.Visible = checkBox2.Checked;
            checkBox5.Visible = checkBox2.Checked;
            label7.Visible = checkBox2.Checked;


        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            dysfunctionForm.windows = checkBox3.Checked ? 1 : 0;
            SaveSelectionsToXml();

            if (dysfunctionForm.windows == 1)
            {
                CreateStartupShortcut();
            }
            else
            {
                DeleteStartupShortcut();
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                dysfunctionForm.notificaciones = 1;
                SaveSelectionsToXml();
                checkBox5.Checked = false;
            }


        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked)
            {
                dysfunctionForm.notificaciones = 2;
                SaveSelectionsToXml();
                checkBox4.Checked = false;
            }
        }

        private void SaveSelectionsToXml()
        {
            var xml = new XElement("Settings",
                new XElement("minimizar", dysfunctionForm.minimizar),
                new XElement("notificaciones", dysfunctionForm.notificaciones),
                new XElement("windows", dysfunctionForm.windows),
                new XElement("userName", dysfunctionForm.userName),
                new XElement("buttonPeriod", dysfunctionForm.buttonPeriod),
                new XElement("buttonProject", dysfunctionForm.buttonProject),
                new XElement("buttonNamePeriod", dysfunctionForm.buttonNamePeriod),
                new XElement("buttonLinkPeriod", dysfunctionForm.buttonLinkPeriod),
                new XElement("buttonNameProject", dysfunctionForm.buttonNameProject),
                new XElement("buttonLinkProject", dysfunctionForm.buttonLinkProject)
            );
            xml.Save(xmlFilePath);
        }

        private void textBoxNamePeriod_TextChanged(object sender, EventArgs e)
        {
            dysfunctionForm.buttonNamePeriod = textBoxNamePeriod.Text;
            SaveSelectionsToXml();
        }

        private void textBoxNameProject_TextChanged(object sender, EventArgs e)
        {
            dysfunctionForm.buttonNameProject = textBoxNameProject.Text;
            SaveSelectionsToXml();
        }

        private void textBoxLinkPeriod_TextChanged(object sender, EventArgs e)
        {
            dysfunctionForm.buttonLinkPeriod = textBoxLinkPeriod.Text;
            SaveSelectionsToXml();
        }

        private void textBoxLinkProject_TextChanged(object sender, EventArgs e)
        {
            dysfunctionForm.buttonLinkProject = textBoxLinkProject.Text;
            SaveSelectionsToXml();
        }

        private void textBoxNamePeriod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                this.ActiveControl = null;

                e.SuppressKeyPress = true;
            }
        }

        private void textBoxNameProject_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                this.ActiveControl = null;

                e.SuppressKeyPress = true;
            }
        }

        private void textBoxLinkPeriod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.ActiveControl = null;

                e.SuppressKeyPress = true;
            }
        }

        private void textBoxLinkProject_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Eliminar el enfoque del TextBox
                this.ActiveControl = null;

                // Prevenir el sonido "ding"
                e.SuppressKeyPress = true;
            }
        }

        private void checkBoxPeriod_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPeriod.Checked)
            {
                dysfunctionForm.buttonPeriod = 1;
                panelPeriod.Visible = true;
                SaveSelectionsToXml();
            }
            else
            {
                dysfunctionForm.buttonPeriod = 0;
                panelPeriod.Visible = false;
                SaveSelectionsToXml();
            }
        }

        private void checkBoxProject_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxProject.Checked)
            {
                dysfunctionForm.buttonProject = 1;
                panelProject.Visible = true;
                SaveSelectionsToXml();
            }
            else
            {
                dysfunctionForm.buttonProject = 0;
                panelProject.Visible = false;
                SaveSelectionsToXml();
            }
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            dysfunctionForm.userName = textBoxName.Text;
            SaveSelectionsToXml();
        }

        private void textBoxName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.ActiveControl = null;

                e.SuppressKeyPress = true;
            }
        }

    }
}
