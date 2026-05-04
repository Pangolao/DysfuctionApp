using Dysfunction.GUI;
using Dysfunction.GUI.Consult;
using Dysfunction.GUI.Register;
using Dysfunction.Logic;
using Dysfunction.Model;
using System;
using System.Collections.Generic;
using System.Media;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using IWshRuntimeLibrary;
using System.Diagnostics;


namespace Dysfunction
{
    public partial class Dysfunction : Form
    {
        private System.Windows.Forms.Timer notificationTimer;
        private System.Windows.Forms.Timer startupTimer;
        private projectLogic projectLogic = new projectLogic();
        private asignatureLogic asignatureLogic = new asignatureLogic();
        private eventsLogic eventsLogic = new eventsLogic();
        private periodLogic periodLogic = new periodLogic();
        public SoundPlayer parararaa;
        private Form activeForm = null;
        string xmlFilePath = "Start.xml";
        string xmlFilePath1 = "Settings.xml";
        string start;
        public int cache = 0;
        public int notificaciones = 1;
        public int minimizar = 0;
        public int windows = 0;
        public int buttonPeriod = 0;
        public int buttonProject = 0;
        public string buttonNamePeriod;
        public string buttonLinkPeriod;
        public string buttonNameProject;
        public string buttonLinkProject;
        public string userName;


        [DllImport("winmm.dll")]
        private static extern int waveOutSetVolume(IntPtr hwo, uint dwVolume);

        public Dysfunction()
        {
            InitializeComponent();
            ShowIcon = false;
            parararaa = new SoundPlayer(new MemoryStream(Properties.Resources.pararara));
            parararaa.Load();
            SetVolume(25);
            panel7.Visible = false;
            panel8.Visible = false;
            panel9.Visible = false;


            if (!System.IO.File.Exists(xmlFilePath1))
            {
                var xml = new XElement("Settings",
                    new XElement("minimizar", 0),
                    new XElement("notificaciones", 1),
                    new XElement("windows", 0)
                );
                xml.Save(xmlFilePath1);
            }

            if (System.IO.File.Exists(xmlFilePath1))
            {
                var xml = XElement.Load(xmlFilePath1);

                minimizar = (int?)xml.Element("minimizar") ?? 0;
                notificaciones = (int?)xml.Element("notificaciones") ?? 1;
                windows = (int?)xml.Element("windows") ?? 0;
                userName = (string)xml.Element("userName") ?? "";
                buttonPeriod = (int?)xml.Element("buttonPeriod") ?? 0;
                buttonProject = (int?)xml.Element("buttonProject") ?? 0;
                buttonNamePeriod = (string)xml.Element("buttonNamePeriod") ?? "";
                buttonLinkPeriod = (string)xml.Element("buttonLinkPeriod") ?? "";
                buttonNameProject = (string)xml.Element("buttonNameProject") ?? "";
                buttonLinkProject = (string)xml.Element("buttonLinkProject") ?? "";

            }


            iniciar();

            if (System.IO.File.Exists(xmlFilePath))
            {
                var xml = XElement.Load(xmlFilePath);
                start = xml.Element("start")?.Value;

                switch (start)
                {
                    case "Dysfunction":
                        break;
                    case "Period Consult":
                        OpenNewForm(new PeriodConsult(this));
                        panel8.Visible = true;
                        break;
                    case "Calendar":
                        OpenNewForm(new Calendar(this));
                        panel9.Visible = true;
                        break;
                    case "Project Consult":
                        OpenNewForm(new ProjectConsult(this));
                        panel7.Visible = true;
                        break;
                    case "Settings":
                        OpenNewForm(new Settings(this));
                        panel11.Visible = true;
                        break;

                }
            }

            foreach (ComboBox comboBox in this.Controls.OfType<ComboBox>())
            {
                comboBox.BackColor = Color.White;
                comboBox.ForeColor = Color.Black;
                comboBox.FlatStyle = FlatStyle.Standard;
            }
            OpenStartupProjects();
        }




        private async void iniciar()
        {
            if (minimizar == 1)
            {
                this.WindowState = FormWindowState.Minimized;
                await Task.Delay(1);
                this.Hide();
                notifyIcon1.Visible = true;
            }
            if (notificaciones > 0)
            {
                startupTimer = new System.Windows.Forms.Timer();
                startupTimer.Interval = 3000;
                startupTimer.Tick += (s, e) => ShowStartupNotification();
                startupTimer.Start();
            }

        }

        private void OpenStartupProjects()
        {
            string xmlFilePath2 = "ProjectStartUp.xml";

            if (System.IO.File.Exists(xmlFilePath2))
            {
                var xml = XElement.Load(xmlFilePath2);
                var projects = xml.Elements("Project").Select(p => p.Value).ToList();

                foreach (var projectId in projects)
                {
                    // El formato es: NombreProyecto_CodigoAsignatura_Periodo_Año
                    var parts = projectId.Split('_');
                    if (parts.Length == 4)
                    {
                        string projectName = parts[0];
                        string projectCode = parts[1];
                        string projectPeriod = parts[2];
                        int projectYear = int.Parse(parts[3]);

                        // Construir el nombre del archivo del proyecto
                        string fileNameBase = $"{projectName}_{projectCode}_{projectLogic.deleteSpaces(projectPeriod)}_{projectYear}";
                        string targetDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Project", $"{projectCode}_{projectLogic.deleteSpaces(projectPeriod)}_{projectYear}");

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

                        fileNameBase = $"Indication_{projectName}_{projectCode}_{projectLogic.deleteSpaces(projectPeriod)}_{projectYear}";
                        targetDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Indication", $"{projectCode}_{projectLogic.deleteSpaces(projectPeriod)}_{projectYear}");

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


        private void SetVolume(int volume)
        {
            // Asegúrate de que el volumen esté en el rango correcto (0-100)
            volume = Math.Max(0, Math.Min(100, volume));

            // Convertir el volumen a un valor entre 0 y 65535
            uint volumeValue = (uint)(volume / 100.0 * 65535);

            // Combinar el volumen de los canales izquierdo y derecho
            uint fullVolume = (volumeValue & 0xFFFF) | (volumeValue << 16);

            // Establecer el volumen
            waveOutSetVolume(IntPtr.Zero, fullVolume);
        }

        private void ShowStartupNotification()
        {
            // Detener el temporizador para que no se repita
            startupTimer.Stop();
            SetupNotificationSystem();
        }

        public void SetupNotificationSystem()
        {
            notifyIcon1.Visible = true;

            // Configurar temporizador de verificación
            notificationTimer = new System.Windows.Forms.Timer();

            if (notificaciones == 1)
            {
                notificationTimer.Interval = 3600000 * 12;
            }
            else if (notificaciones == 2)
            {
                notificationTimer.Interval = 3600000 * 6;
            }
            else if (notificaciones == 3)
            {
                notificationTimer.Interval = 3600000 * 3;
            }
            else if (notificaciones == 4)
            {
                notificationTimer.Interval = 3600000;
            }


            notificationTimer.Tick += (s, e) => CheckAndShowNotifications();
            notificationTimer.Start();

            CheckAndShowNotifications();
        }

        private void CheckAndShowNotifications()
        {
            var today = DateTime.Today;
            var notifications = new List<string>();

            // Verificar eventos
            var events = eventsLogic.Consult();
            foreach (var ev in events.Where(e => e != null))
            {
                int daysUntilStart = (ev.StartDate.Date - today).Days;

                // Notificación para eventos que comienzan hoy
                if (daysUntilStart == 0)
                {
                    if (ev.Hour != null && !string.IsNullOrEmpty(ev.Hour.ToString())) // Validar si tiene hora establecida
                    {
                        notifications.Add($" Event {ev.Name} starts today at {ev.Hour}");
                    }
                    else
                    {
                        notifications.Add($" Event {ev.Name} starts today");
                    }
                }
                // Notificación para eventos que comienzan en 8 días o menos
                else if (daysUntilStart > 0 && daysUntilStart <= 8)
                {
                    if (daysUntilStart < 2)
                    {
                        notifications.Add($" Event {ev.Name} starts in {daysUntilStart} day");
                    }
                    else
                    {
                        notifications.Add($" Event {ev.Name} starts in {daysUntilStart} days");
                    }

                }
            }

            // Verificar proyectos
            var projects = projectLogic.Consult();
            foreach (var project in projects.Where(p => p != null))
            {
                string asignatureName = asignatureLogic.ObtainName(project.Code);
                int daysRemaining = (project.LimitDate.Date - today).Days;

                if (daysRemaining == 0)
                {
                    notifications.Add($" Today is the limite date for {project.Project} ({asignatureName})");
                }
                else if (daysRemaining > 0 && daysRemaining <= 8) // 8 días o menos
                {
                    if (daysRemaining < 2)
                    {

                        notifications.Add($" {project.Project} ({asignatureName}) {daysRemaining} day remaining");
                    }
                    else
                    {
                        notifications.Add($" {project.Project} ({asignatureName}) {daysRemaining} days remaining");
                    }

                }
            }

            // Verificar períodos
            var periods = periodLogic.Consult();
            foreach (var period in periods.Where(p => p != null))
            {
                int daysUntilStart = (period.StartDate.Date - today).Days;

                // Notificación para períodos que comienzan hoy
                if (daysUntilStart == 0)
                {
                    notifications.Add($" Period {period.Period} starts today");
                }
                // Notificación para períodos que comienzan en 8 días o menos
                else if (daysUntilStart > 0 && daysUntilStart <= 8)
                {
                    if (daysUntilStart < 2)
                    {
                        notifications.Add($" {period.Period} starts in {daysUntilStart} day");
                    }
                    else
                    {
                        notifications.Add($" {period.Period} starts in {daysUntilStart} days");
                    }
                }
            }

            // Mostrar notificación si hay eventos, proyectos o períodos próximos
            if (notifications.Count > 0)
            {
                ShowNotification("Reminders", string.Join("\n\n", notifications));
            }
        }

        private void ShowNotification(string title, string message)
        {

            parararaa.Play();
            notifyIcon1.BalloonTipTitle = title;
            notifyIcon1.BalloonTipText = message;
            notifyIcon1.ShowBalloonTip(30000);
        }


        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            notifyIcon1.Visible = true;
            WindowState = FormWindowState.Normal;
        }

        private void Dysfunction_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                // this.Hide();
                //notifyIcon1.Visible = true;

            }
            else if (FormWindowState.Normal == this.WindowState)
            {
                // notifyIcon1.Visible = false;
            }
        }


        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
                notifyIcon1.Visible = true;
                return;
            }
            base.OnFormClosing(e);
        }



        private void SaveSelectionsToXml(string start)
        {
            var xml = new XElement("Start",
                new XElement("start", start ?? string.Empty)
            );
            xml.Save(xmlFilePath);
        }


        public void OpenNewForm(Form newForm)
        {
            if (activeForm != null && activeForm.GetType() == newForm.GetType())
            {
                return;
            }

            if (activeForm != null)
            {
                activeForm.Close();
                activeForm.Dispose();
                panelForm.Controls.Remove(activeForm);

                GC.Collect();
                GC.WaitForPendingFinalizers();
            }

            activeForm = newForm;

            this.Size = new System.Drawing.Size(newForm.Width + 18 + 66, newForm.Height + 72);

            newForm.TopLevel = false;
            newForm.FormBorderStyle = FormBorderStyle.None;
            newForm.Dock = DockStyle.Fill;
            panelForm.Controls.Add(newForm);
            panelForm.Tag = newForm;
            newForm.BringToFront();
            newForm.Show();
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_MOUSEMENU = 0xF093;

            if (m.Msg == WM_SYSCOMMAND)
            {
                if (m.WParam.ToInt32() == SC_MOUSEMENU)
                {
                    if (activeForm != null)
                    {
                        this.Text = "Dysfunction";
                        activeForm.Close();
                        panelForm.Controls.Remove(activeForm);
                        activeForm = null;
                        SaveSelectionsToXml(this.Text);
                    }
                    return;
                }
            }
            base.WndProc(ref m);
        }
        [DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, DwmWindowAttribute dwAttribute, ref int pvAttribute, int cbAttribute);

        private enum DwmWindowAttribute
        {
            DWMWA_USE_IMMERSIVE_DARK_MODE = 20,
            DWMWA_CAPTION_COLOR = 35
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            ApplyDarkTitleBar();
        }

        private void ApplyDarkTitleBar()
        {
            if (IsWindows10OrLater())
            {
                // Activar modo oscuro
                int darkMode = 1;
                DwmSetWindowAttribute(this.Handle, DwmWindowAttribute.DWMWA_USE_IMMERSIVE_DARK_MODE,
                    ref darkMode, sizeof(int));

                // Establecer color de la barra de título a negro (formato BGR 0x00BBGGRR)
                int captionColor = 0x000000;
                DwmSetWindowAttribute(this.Handle, DwmWindowAttribute.DWMWA_CAPTION_COLOR,
                    ref captionColor, sizeof(int));
            }
        }

        private bool IsWindows10OrLater()
        {
            return Environment.OSVersion.Platform == PlatformID.Win32NT &&
                   Environment.OSVersion.Version.Major >= 10;
        }


        // Todo lo de acá acabo es para los proyectos


        private async void panel2_MouseDown(object sender, MouseEventArgs e)
        {

            panel3.BorderStyle = BorderStyle.None;
            panel4.BorderStyle = BorderStyle.None;
            panel11.BorderStyle = BorderStyle.None;
            panel8.Visible = false;
            panel9.Visible = false;
            panel12.Visible = false;

            if (cache != 1)
            {
                panel7.Visible = true;
                OpenNewForm(new ProjectConsult(this));
                SaveSelectionsToXml("Project Consult");
                cache = 1;
            }


            panel2.BorderStyle = BorderStyle.FixedSingle;
            await Task.Delay(100);
            panel2.BorderStyle = BorderStyle.None;
        }






        //Todo lo de abajo es para la consulta de periodos



        private async void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            panel2.BorderStyle = BorderStyle.None;
            panel4.BorderStyle = BorderStyle.None;
            panel11.BorderStyle = BorderStyle.None;
            panel7.Visible = false;
            panel9.Visible = false;
            panel12.Visible = false;
            if (cache != 2)
            {
                panel8.Visible = true;
                OpenNewForm(new PeriodConsult(this));
                SaveSelectionsToXml("Period Consult");
                cache = 2;
            }


            panel3.BorderStyle = BorderStyle.FixedSingle;
            await Task.Delay(100);
            panel3.BorderStyle = BorderStyle.None;

        }




        //Todo lo de abajo es para el calendario


        private async void panel4_MouseDown(object sender, MouseEventArgs e)
        {
            panel2.BorderStyle = BorderStyle.None;
            panel3.BorderStyle = BorderStyle.None;
            panel11.BorderStyle = BorderStyle.None;
            panel7.Visible = false;
            panel8.Visible = false;
            panel12.Visible = false;
            if (cache != 3)
            {
                panel9.Visible = true;
                OpenNewForm(new Calendar(this));
                SaveSelectionsToXml("Calendar");
                cache = 3;
            }

            panel4.BorderStyle = BorderStyle.FixedSingle;
            await Task.Delay(100);
            panel4.BorderStyle = BorderStyle.None;
        }



        private async void panel11_MouseDown(object sender, MouseEventArgs e)
        {
            panel2.BorderStyle = BorderStyle.None;
            panel3.BorderStyle = BorderStyle.None;
            panel4.BorderStyle = BorderStyle.None;
            panel7.Visible = false;
            panel8.Visible = false;
            panel9.Visible = false;

            if (cache != 4)
            {
                panel12.Visible = true;
                OpenNewForm(new Settings(this));
                SaveSelectionsToXml("Settings");
                cache = 4;
            }

            panel11.BorderStyle = BorderStyle.FixedSingle;
            await Task.Delay(100);
            panel11.BorderStyle = BorderStyle.None;
        }
















        // Estatico, nada de aca importa más

        private void Nav_MouseEnter(object sender, EventArgs e)
        {
            panel2.BackColor = Color.FromArgb(0, 0, 0);
            panel3.BackColor = Color.FromArgb(0, 0, 0);
            panel4.BackColor = Color.FromArgb(0, 0, 0);
            panel11.BackColor = Color.FromArgb(0, 0, 0);
        }
        private void panelForm_MouseEnter(object sender, EventArgs e)
        {
            panel2.BackColor = Color.FromArgb(0, 0, 0);
            panel3.BackColor = Color.FromArgb(0, 0, 0);
            panel4.BackColor = Color.FromArgb(0, 0, 0);
            panel11.BackColor = Color.FromArgb(0, 0, 0);
        }
        private void panel1_MouseEnter(object sender, EventArgs e)
        {
            panel2.BackColor = Color.FromArgb(0, 0, 0);
            panel3.BackColor = Color.FromArgb(0, 0, 0);
            panel4.BackColor = Color.FromArgb(0, 0, 0);
            panel11.BackColor = Color.FromArgb(0, 0, 0);

        }
        private void panel2_MouseEnter(object sender, EventArgs e)
        {
            panel2.BackColor = Color.FromArgb(20, 20, 20);
            panel3.BackColor = Color.FromArgb(0, 0, 0);
            panel4.BackColor = Color.FromArgb(0, 0, 0);
            panel11.BackColor = Color.FromArgb(0, 0, 0);
        }

        private void panel2_MouseLeave(object sender, EventArgs e)
        {
            panel2.BackColor = Color.FromArgb(0, 0, 0);
        }

        private void panel3_MouseEnter(object sender, EventArgs e)
        {
            panel3.BackColor = Color.FromArgb(20, 20, 20);
            panel2.BackColor = Color.FromArgb(0, 0, 0);
            panel4.BackColor = Color.FromArgb(0, 0, 0);
            panel11.BackColor = Color.FromArgb(0, 0, 0);
        }

        private void panel3_MouseLeave(object sender, EventArgs e)
        {
            panel3.BackColor = Color.FromArgb(0, 0, 0);
        }

        private void panel4_MouseEnter(object sender, EventArgs e)
        {
            panel4.BackColor = Color.FromArgb(20, 20, 20);
            panel2.BackColor = Color.FromArgb(0, 0, 0);
            panel3.BackColor = Color.FromArgb(0, 0, 0);
            panel11.BackColor = Color.FromArgb(0, 0, 0);
        }
        private void panel11_MouseEnter(object sender, EventArgs e)
        {
            panel11.BackColor = Color.FromArgb(20, 20, 20);
            panel2.BackColor = Color.FromArgb(0, 0, 0);
            panel3.BackColor = Color.FromArgb(0, 0, 0);
            panel4.BackColor = Color.FromArgb(0, 0, 0);
        }
        private void panel11_MouseLeave(object sender, EventArgs e)
        {
            panel11.BackColor = Color.FromArgb(0, 0, 0);
        }
        private void panel4_MouseLeave(object sender, EventArgs e)
        {
            panel4.BackColor = Color.FromArgb(0, 0, 0);
        }

        private void panel5_MouseEnter(object sender, EventArgs e)
        {
            panel2.BackColor = Color.FromArgb(0, 0, 0);
            panel3.BackColor = Color.FromArgb(0, 0, 0);
            panel4.BackColor = Color.FromArgb(0, 0, 0);
        }

        private void panel6_MouseEnter(object sender, EventArgs e)
        {
            panel2.BackColor = Color.FromArgb(0, 0, 0);
            panel3.BackColor = Color.FromArgb(0, 0, 0);
            panel4.BackColor = Color.FromArgb(0, 0, 0);
        }

        private void pictureBox4_MouseDown(object sender, MouseEventArgs e)
        {
            SetVolume(25);
            parararaa.Play();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void Nav_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }
    }
}
