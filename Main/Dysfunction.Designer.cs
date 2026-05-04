using System.Windows.Forms;

namespace Dysfunction
{
    partial class Dysfunction
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dysfunction));
            panelForm = new Panel();
            Nav = new Panel();
            panel4 = new Panel();
            panel9 = new Panel();
            label3 = new Label();
            pictureBox3 = new PictureBox();
            panel2 = new Panel();
            panel7 = new Panel();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            panel3 = new Panel();
            panel8 = new Panel();
            label2 = new Label();
            pictureBox2 = new PictureBox();
            panel1 = new Panel();
            pictureBox4 = new PictureBox();
            panel11 = new Panel();
            panel12 = new Panel();
            label4 = new Label();
            pictureBox5 = new PictureBox();
            panel13 = new Panel();
            panel5 = new Panel();
            panel6 = new Panel();
            panel10 = new Panel();
            notifyIcon1 = new NotifyIcon(components);
            contextMenuStrip1 = new ContextMenuStrip(components);
            closeToolStripMenuItem = new ToolStripMenuItem();
            Nav.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            panel11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // panelForm
            // 
            panelForm.AllowDrop = true;
            panelForm.BackColor = Color.Black;
            panelForm.Dock = DockStyle.Fill;
            panelForm.Location = new Point(58, 0);
            panelForm.Margin = new Padding(3, 2, 3, 2);
            panelForm.Name = "panelForm";
            panelForm.Size = new Size(902, 561);
            panelForm.TabIndex = 1;
            panelForm.MouseEnter += panelForm_MouseEnter;
            // 
            // Nav
            // 
            Nav.AllowDrop = true;
            Nav.Controls.Add(panel4);
            Nav.Controls.Add(panel2);
            Nav.Controls.Add(panel3);
            Nav.Controls.Add(panel1);
            Nav.Controls.Add(panel11);
            Nav.Controls.Add(panel13);
            Nav.Dock = DockStyle.Left;
            Nav.Location = new Point(1, 0);
            Nav.Margin = new Padding(3, 2, 3, 2);
            Nav.Name = "Nav";
            Nav.Size = new Size(56, 561);
            Nav.TabIndex = 2;
            Nav.DragEnter += Nav_DragEnter;
            Nav.MouseEnter += Nav_MouseEnter;
            // 
            // panel4
            // 
            panel4.Controls.Add(panel9);
            panel4.Controls.Add(label3);
            panel4.Controls.Add(pictureBox3);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 156);
            panel4.Margin = new Padding(3, 2, 3, 2);
            panel4.Name = "panel4";
            panel4.Size = new Size(56, 54);
            panel4.TabIndex = 3;
            panel4.MouseDown += panel4_MouseDown;
            panel4.MouseEnter += panel4_MouseEnter;
            panel4.MouseLeave += panel4_MouseLeave;
            // 
            // panel9
            // 
            panel9.BackColor = SystemColors.AppWorkspace;
            panel9.Location = new Point(4, 11);
            panel9.Margin = new Padding(3, 2, 3, 2);
            panel9.Name = "panel9";
            panel9.Size = new Size(3, 15);
            panel9.TabIndex = 3;
            panel9.MouseDown += panel4_MouseDown;
            panel9.MouseEnter += panel4_MouseEnter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 7.9F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = Color.White;
            label3.Location = new Point(1, 31);
            label3.Name = "label3";
            label3.Size = new Size(53, 13);
            label3.TabIndex = 1;
            label3.Text = "Calendar";
            label3.MouseDown += panel4_MouseDown;
            label3.MouseEnter += panel4_MouseEnter;
            // 
            // pictureBox3
            // 
            pictureBox3.BackgroundImage = (Image)resources.GetObject("pictureBox3.BackgroundImage");
            pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox3.Location = new Point(10, 4);
            pictureBox3.Margin = new Padding(3, 2, 3, 2);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(34, 28);
            pictureBox3.TabIndex = 0;
            pictureBox3.TabStop = false;
            pictureBox3.MouseDown += panel4_MouseDown;
            pictureBox3.MouseEnter += panel4_MouseEnter;
            // 
            // panel2
            // 
            panel2.Controls.Add(panel7);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(pictureBox1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 102);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(56, 54);
            panel2.TabIndex = 1;
            panel2.MouseDown += panel2_MouseDown;
            panel2.MouseEnter += panel2_MouseEnter;
            panel2.MouseLeave += panel2_MouseLeave;
            // 
            // panel7
            // 
            panel7.BackColor = SystemColors.AppWorkspace;
            panel7.Location = new Point(4, 18);
            panel7.Margin = new Padding(3, 2, 3, 2);
            panel7.Name = "panel7";
            panel7.Size = new Size(3, 15);
            panel7.TabIndex = 2;
            panel7.MouseDown += panel2_MouseDown;
            panel7.MouseEnter += panel2_MouseEnter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(4, 35);
            label1.Name = "label1";
            label1.Size = new Size(47, 13);
            label1.TabIndex = 1;
            label1.Text = "Projects";
            label1.MouseDown += panel2_MouseDown;
            label1.MouseEnter += panel2_MouseEnter;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(12, 8);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(32, 27);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.MouseDown += panel2_MouseDown;
            pictureBox1.MouseEnter += panel2_MouseEnter;
            // 
            // panel3
            // 
            panel3.Controls.Add(panel8);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(pictureBox2);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 48);
            panel3.Margin = new Padding(3, 2, 3, 2);
            panel3.Name = "panel3";
            panel3.Size = new Size(56, 54);
            panel3.TabIndex = 2;
            panel3.MouseDown += panel3_MouseDown;
            panel3.MouseEnter += panel3_MouseEnter;
            panel3.MouseLeave += panel3_MouseLeave;
            // 
            // panel8
            // 
            panel8.BackColor = SystemColors.AppWorkspace;
            panel8.Location = new Point(4, 20);
            panel8.Margin = new Padding(3, 2, 3, 2);
            panel8.Name = "panel8";
            panel8.Size = new Size(3, 15);
            panel8.TabIndex = 3;
            panel8.MouseDown += panel3_MouseDown;
            panel8.MouseEnter += panel2_MouseLeave;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(6, 37);
            label2.Name = "label2";
            label2.Size = new Size(45, 13);
            label2.TabIndex = 1;
            label2.Text = "Periods";
            label2.MouseDown += panel3_MouseDown;
            label2.MouseEnter += panel3_MouseEnter;
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImage = (Image)resources.GetObject("pictureBox2.BackgroundImage");
            pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox2.Location = new Point(9, 7);
            pictureBox2.Margin = new Padding(3, 2, 3, 2);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(36, 28);
            pictureBox2.TabIndex = 0;
            pictureBox2.TabStop = false;
            pictureBox2.MouseDown += panel3_MouseDown;
            pictureBox2.MouseEnter += panel3_MouseEnter;
            // 
            // panel1
            // 
            panel1.Controls.Add(pictureBox4);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(56, 48);
            panel1.TabIndex = 0;
            panel1.MouseEnter += panel1_MouseEnter;
            // 
            // pictureBox4
            // 
            pictureBox4.BackgroundImage = (Image)resources.GetObject("pictureBox4.BackgroundImage");
            pictureBox4.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox4.Location = new Point(8, 4);
            pictureBox4.Margin = new Padding(3, 2, 3, 2);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(39, 39);
            pictureBox4.TabIndex = 0;
            pictureBox4.TabStop = false;
            pictureBox4.MouseDown += pictureBox4_MouseDown;
            // 
            // panel11
            // 
            panel11.Controls.Add(panel12);
            panel11.Controls.Add(label4);
            panel11.Controls.Add(pictureBox5);
            panel11.Dock = DockStyle.Bottom;
            panel11.Location = new Point(0, 499);
            panel11.Margin = new Padding(3, 2, 3, 2);
            panel11.Name = "panel11";
            panel11.Size = new Size(56, 54);
            panel11.TabIndex = 4;
            panel11.MouseDown += panel11_MouseDown;
            panel11.MouseEnter += panel11_MouseEnter;
            panel11.MouseLeave += panel11_MouseLeave;
            // 
            // panel12
            // 
            panel12.BackColor = SystemColors.AppWorkspace;
            panel12.Location = new Point(4, 16);
            panel12.Margin = new Padding(3, 2, 3, 2);
            panel12.Name = "panel12";
            panel12.Size = new Size(3, 15);
            panel12.TabIndex = 3;
            panel12.Visible = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = Color.White;
            label4.Location = new Point(5, 35);
            label4.Name = "label4";
            label4.Size = new Size(49, 13);
            label4.TabIndex = 1;
            label4.Text = "Settings";
            label4.MouseDown += panel11_MouseDown;
            label4.MouseEnter += panel11_MouseEnter;
            // 
            // pictureBox5
            // 
            pictureBox5.BackgroundImage = (Image)resources.GetObject("pictureBox5.BackgroundImage");
            pictureBox5.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox5.Location = new Point(12, 5);
            pictureBox5.Margin = new Padding(3, 2, 3, 2);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(33, 26);
            pictureBox5.TabIndex = 0;
            pictureBox5.TabStop = false;
            pictureBox5.MouseDown += panel11_MouseDown;
            pictureBox5.MouseEnter += panel11_MouseEnter;
            // 
            // panel13
            // 
            panel13.Dock = DockStyle.Bottom;
            panel13.Location = new Point(0, 553);
            panel13.Margin = new Padding(3, 2, 3, 2);
            panel13.Name = "panel13";
            panel13.Size = new Size(56, 8);
            panel13.TabIndex = 5;
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(20, 20, 20);
            panel5.Dock = DockStyle.Left;
            panel5.Location = new Point(57, 0);
            panel5.Margin = new Padding(3, 2, 3, 2);
            panel5.Name = "panel5";
            panel5.Size = new Size(1, 561);
            panel5.TabIndex = 3;
            panel5.MouseEnter += panel5_MouseEnter;
            // 
            // panel6
            // 
            panel6.Dock = DockStyle.Left;
            panel6.Location = new Point(0, 0);
            panel6.Margin = new Padding(3, 2, 3, 2);
            panel6.Name = "panel6";
            panel6.Size = new Size(1, 561);
            panel6.TabIndex = 4;
            panel6.MouseEnter += panel6_MouseEnter;
            // 
            // panel10
            // 
            panel10.BackColor = Color.FromArgb(20, 20, 20);
            panel10.Dock = DockStyle.Top;
            panel10.Location = new Point(58, 0);
            panel10.Margin = new Padding(3, 2, 3, 2);
            panel10.Name = "panel10";
            panel10.Size = new Size(902, 1);
            panel10.TabIndex = 5;
            // 
            // notifyIcon1
            // 
            notifyIcon1.ContextMenuStrip = contextMenuStrip1;
            notifyIcon1.Icon = (Icon)resources.GetObject("notifyIcon1.Icon");
            notifyIcon1.Text = "Dysfunction";
            notifyIcon1.Visible = true;
            notifyIcon1.MouseDoubleClick += notifyIcon1_MouseDoubleClick;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.BackColor = SystemColors.ControlText;
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { closeToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(104, 26);
            contextMenuStrip1.Opening += contextMenuStrip1_Opening;
            // 
            // closeToolStripMenuItem
            // 
            closeToolStripMenuItem.BackColor = Color.White;
            closeToolStripMenuItem.ForeColor = Color.Black;
            closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            closeToolStripMenuItem.Size = new Size(103, 22);
            closeToolStripMenuItem.Text = "Close";
            closeToolStripMenuItem.Click += closeToolStripMenuItem_Click;
            // 
            // Dysfunction
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(960, 561);
            Controls.Add(panel10);
            Controls.Add(panelForm);
            Controls.Add(panel5);
            Controls.Add(Nav);
            Controls.Add(panel6);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            MinimumSize = new Size(16, 92);
            Name = "Dysfunction";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Dysfunction";
            Resize += Dysfunction_Resize;
            Nav.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            panel11.ResumeLayout(false);
            panel11.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel panelForm;
        private Panel Nav;
        private Panel panel2;
        private Panel panel1;
        private PictureBox pictureBox1;
        private Label label1;
        private Panel panel4;
        private Label label3;
        private PictureBox pictureBox3;
        private Panel panel3;
        private Label label2;
        private PictureBox pictureBox2;
        private PictureBox pictureBox4;
        private Panel panel5;
        private Panel panel6;
        private Panel panel7;
        private Panel panel9;
        private Panel panel8;
        private Panel panel10;
        private NotifyIcon notifyIcon1;
        private Panel panel11;
        private Panel panel12;
        private Label label4;
        private PictureBox pictureBox5;
        private Panel panel13;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem closeToolStripMenuItem;
    }
}