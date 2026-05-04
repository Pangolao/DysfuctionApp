namespace Dysfunction.GUI.Register
{
    partial class ProjectRegister
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectRegister));
            buttonSave = new Button();
            label3 = new Label();
            label1 = new Label();
            textBoxProject = new TextBox();
            dateTimePickerLimit = new DateTimePicker();
            label2 = new Label();
            textBoxValue = new TextBox();
            label4 = new Label();
            comboBoxAsignature = new ComboBox();
            labelAsignature = new Label();
            labelProject = new Label();
            labelValue = new Label();
            labelPeriod = new Label();
            label5 = new Label();
            comboBoxPeriod = new ComboBox();
            label6 = new Label();
            panelIndications = new Panel();
            labelPDFIndications = new Label();
            dateTimePicker = new DateTimePicker();
            label8 = new Label();
            panel2 = new Panel();
            label7 = new Label();
            panelProject = new Panel();
            labelPDFProject = new Label();
            pictureBox1 = new PictureBox();
            label9 = new Label();
            panel1 = new Panel();
            label10 = new Label();
            panel4 = new Panel();
            panelPlus1 = new Panel();
            picturePlus1 = new PictureBox();
            panelPlus2 = new Panel();
            picturePlus2 = new PictureBox();
            panel7 = new Panel();
            panel5 = new Panel();
            panel6 = new Panel();
            panelIndications.SuspendLayout();
            panelProject.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            panel4.SuspendLayout();
            panelPlus1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picturePlus1).BeginInit();
            panelPlus2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picturePlus2).BeginInit();
            SuspendLayout();
            // 
            // buttonSave
            // 
            buttonSave.Anchor = AnchorStyles.Top;
            buttonSave.FlatAppearance.BorderColor = Color.FromArgb(64, 64, 64);
            buttonSave.FlatAppearance.MouseDownBackColor = Color.FromArgb(20, 20, 20);
            buttonSave.FlatAppearance.MouseOverBackColor = Color.FromArgb(20, 20, 20);
            buttonSave.FlatStyle = FlatStyle.Flat;
            buttonSave.ForeColor = Color.White;
            buttonSave.Location = new Point(145, 318);
            buttonSave.Margin = new Padding(3, 2, 3, 2);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(195, 35);
            buttonSave.TabIndex = 15;
            buttonSave.Text = "Save Project";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top;
            label3.AutoSize = true;
            label3.ForeColor = Color.White;
            label3.Location = new Point(41, 199);
            label3.Name = "label3";
            label3.Size = new Size(61, 15);
            label3.TabIndex = 14;
            label3.Text = "Limit Date";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.ForeColor = Color.White;
            label1.Location = new Point(41, 111);
            label1.Name = "label1";
            label1.Size = new Size(44, 15);
            label1.TabIndex = 12;
            label1.Text = "Project";
            // 
            // textBoxProject
            // 
            textBoxProject.Anchor = AnchorStyles.Top;
            textBoxProject.BackColor = Color.Black;
            textBoxProject.BorderStyle = BorderStyle.FixedSingle;
            textBoxProject.ForeColor = Color.White;
            textBoxProject.Location = new Point(41, 128);
            textBoxProject.Margin = new Padding(3, 2, 3, 2);
            textBoxProject.Name = "textBoxProject";
            textBoxProject.PlaceholderText = "Give it a name";
            textBoxProject.Size = new Size(413, 23);
            textBoxProject.TabIndex = 9;
            textBoxProject.Click += textBoxProject_Click;
            textBoxProject.TextChanged += textBoxProject_TextChanged;
            // 
            // dateTimePickerLimit
            // 
            dateTimePickerLimit.Anchor = AnchorStyles.Top;
            dateTimePickerLimit.Format = DateTimePickerFormat.Short;
            dateTimePickerLimit.Location = new Point(40, 222);
            dateTimePickerLimit.Margin = new Padding(3, 2, 3, 2);
            dateTimePickerLimit.Name = "dateTimePickerLimit";
            dateTimePickerLimit.Size = new Size(414, 23);
            dateTimePickerLimit.TabIndex = 10;
            dateTimePickerLimit.ValueChanged += dateTimePickerLimit_ValueChanged;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.AutoSize = true;
            label2.ForeColor = Color.White;
            label2.Location = new Point(40, 155);
            label2.Name = "label2";
            label2.Size = new Size(35, 15);
            label2.TabIndex = 17;
            label2.Text = "Value";
            // 
            // textBoxValue
            // 
            textBoxValue.Anchor = AnchorStyles.Top;
            textBoxValue.BackColor = Color.Black;
            textBoxValue.BorderStyle = BorderStyle.FixedSingle;
            textBoxValue.ForeColor = Color.White;
            textBoxValue.Location = new Point(41, 174);
            textBoxValue.Margin = new Padding(3, 2, 3, 2);
            textBoxValue.Name = "textBoxValue";
            textBoxValue.PlaceholderText = "Between 0 and 10";
            textBoxValue.Size = new Size(413, 23);
            textBoxValue.TabIndex = 16;
            textBoxValue.Click += textBoxValue_Click;
            textBoxValue.TextChanged += textBoxValue_TextChanged;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top;
            label4.AutoSize = true;
            label4.ForeColor = Color.White;
            label4.Location = new Point(39, 63);
            label4.Name = "label4";
            label4.Size = new Size(64, 15);
            label4.TabIndex = 19;
            label4.Text = "Asignature";
            // 
            // comboBoxAsignature
            // 
            comboBoxAsignature.Anchor = AnchorStyles.Top;
            comboBoxAsignature.BackColor = Color.White;
            comboBoxAsignature.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxAsignature.ForeColor = Color.Black;
            comboBoxAsignature.FormattingEnabled = true;
            comboBoxAsignature.Location = new Point(39, 80);
            comboBoxAsignature.Margin = new Padding(3, 2, 3, 2);
            comboBoxAsignature.Name = "comboBoxAsignature";
            comboBoxAsignature.Size = new Size(414, 23);
            comboBoxAsignature.TabIndex = 18;
            comboBoxAsignature.SelectedIndexChanged += comboBoxAsignature_SelectedIndexChanged;
            // 
            // labelAsignature
            // 
            labelAsignature.Anchor = AnchorStyles.Top;
            labelAsignature.AutoSize = true;
            labelAsignature.BackColor = Color.Black;
            labelAsignature.Font = new Font("Arial Narrow", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            labelAsignature.ForeColor = Color.White;
            labelAsignature.Location = new Point(20, 80);
            labelAsignature.Name = "labelAsignature";
            labelAsignature.Size = new Size(14, 23);
            labelAsignature.TabIndex = 20;
            labelAsignature.Text = "!";
            // 
            // labelProject
            // 
            labelProject.Anchor = AnchorStyles.Top;
            labelProject.AutoSize = true;
            labelProject.BackColor = Color.Black;
            labelProject.Font = new Font("Arial Narrow", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            labelProject.ForeColor = Color.White;
            labelProject.Location = new Point(21, 128);
            labelProject.Name = "labelProject";
            labelProject.Size = new Size(14, 23);
            labelProject.TabIndex = 21;
            labelProject.Text = "!";
            // 
            // labelValue
            // 
            labelValue.Anchor = AnchorStyles.Top;
            labelValue.AutoSize = true;
            labelValue.BackColor = Color.Black;
            labelValue.Font = new Font("Arial Narrow", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            labelValue.ForeColor = Color.White;
            labelValue.Location = new Point(21, 174);
            labelValue.Name = "labelValue";
            labelValue.Size = new Size(14, 23);
            labelValue.TabIndex = 22;
            labelValue.Text = "!";
            // 
            // labelPeriod
            // 
            labelPeriod.Anchor = AnchorStyles.Top;
            labelPeriod.AutoSize = true;
            labelPeriod.BackColor = Color.Black;
            labelPeriod.Font = new Font("Arial Narrow", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            labelPeriod.ForeColor = Color.White;
            labelPeriod.Location = new Point(241, 35);
            labelPeriod.Name = "labelPeriod";
            labelPeriod.Size = new Size(14, 23);
            labelPeriod.TabIndex = 29;
            labelPeriod.Text = "!";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top;
            label5.AutoSize = true;
            label5.ForeColor = Color.White;
            label5.Location = new Point(253, 16);
            label5.Name = "label5";
            label5.Size = new Size(41, 15);
            label5.TabIndex = 28;
            label5.Text = "Period";
            // 
            // comboBoxPeriod
            // 
            comboBoxPeriod.Anchor = AnchorStyles.Top;
            comboBoxPeriod.BackColor = Color.White;
            comboBoxPeriod.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxPeriod.ForeColor = Color.Black;
            comboBoxPeriod.FormattingEnabled = true;
            comboBoxPeriod.Location = new Point(257, 35);
            comboBoxPeriod.Margin = new Padding(3, 2, 3, 2);
            comboBoxPeriod.Name = "comboBoxPeriod";
            comboBoxPeriod.Size = new Size(196, 23);
            comboBoxPeriod.TabIndex = 27;
            comboBoxPeriod.SelectedIndexChanged += comboBoxPeriod_SelectedIndexChanged;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top;
            label6.AutoSize = true;
            label6.ForeColor = Color.White;
            label6.Location = new Point(38, 247);
            label6.Name = "label6";
            label6.Size = new Size(65, 15);
            label6.TabIndex = 31;
            label6.Text = "Indications";
            // 
            // panelIndications
            // 
            panelIndications.AllowDrop = true;
            panelIndications.Anchor = AnchorStyles.Top;
            panelIndications.BackColor = Color.FromArgb(20, 20, 20);
            panelIndications.Controls.Add(labelPDFIndications);
            panelIndications.Location = new Point(40, 266);
            panelIndications.Margin = new Padding(3, 2, 3, 2);
            panelIndications.Name = "panelIndications";
            panelIndications.Size = new Size(199, 41);
            panelIndications.TabIndex = 30;
            panelIndications.Click += panelIndications_Click;
            panelIndications.DragDrop += panelIndications_DragDrop;
            panelIndications.DragEnter += panelIndications_DragEnter;
            panelIndications.DragLeave += panelIndications_DragLeave;
            panelIndications.MouseEnter += panelIndications_MouseEnter;
            panelIndications.MouseLeave += panelIndications_MouseLeave;
            // 
            // labelPDFIndications
            // 
            labelPDFIndications.AllowDrop = true;
            labelPDFIndications.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelPDFIndications.AutoSize = true;
            labelPDFIndications.Font = new Font("Segoe UI", 9.6F, FontStyle.Regular, GraphicsUnit.Point);
            labelPDFIndications.ForeColor = Color.White;
            labelPDFIndications.Location = new Point(20, 11);
            labelPDFIndications.Name = "labelPDFIndications";
            labelPDFIndications.Size = new Size(146, 17);
            labelPDFIndications.TabIndex = 34;
            labelPDFIndications.Text = "     Select or Drag a File";
            labelPDFIndications.TextAlign = ContentAlignment.MiddleCenter;
            labelPDFIndications.Click += panelIndications_Click;
            labelPDFIndications.DragDrop += panelIndications_DragDrop;
            labelPDFIndications.DragEnter += panelIndications_DragEnter;
            labelPDFIndications.DragLeave += panelIndications_DragLeave;
            labelPDFIndications.MouseEnter += panelIndications_MouseEnter;
            labelPDFIndications.MouseLeave += panelIndications_MouseLeave;
            // 
            // dateTimePicker
            // 
            dateTimePicker.Anchor = AnchorStyles.Top;
            dateTimePicker.CustomFormat = "yyyy";
            dateTimePicker.Format = DateTimePickerFormat.Custom;
            dateTimePicker.Location = new Point(39, 35);
            dateTimePicker.Margin = new Padding(3, 2, 3, 2);
            dateTimePicker.Name = "dateTimePicker";
            dateTimePicker.ShowUpDown = true;
            dateTimePicker.Size = new Size(196, 23);
            dateTimePicker.TabIndex = 34;
            dateTimePicker.ValueChanged += dateTimePicker_ValueChanged;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Top;
            label8.AutoSize = true;
            label8.ForeColor = Color.White;
            label8.Location = new Point(32, 17);
            label8.Name = "label8";
            label8.Size = new Size(29, 15);
            label8.TabIndex = 35;
            label8.Text = "Year";
            // 
            // panel2
            // 
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(920, 1);
            panel2.TabIndex = 36;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top;
            label7.AutoSize = true;
            label7.ForeColor = Color.White;
            label7.Location = new Point(253, 248);
            label7.Name = "label7";
            label7.Size = new Size(44, 15);
            label7.TabIndex = 38;
            label7.Text = "Project";
            // 
            // panelProject
            // 
            panelProject.AllowDrop = true;
            panelProject.Anchor = AnchorStyles.Top;
            panelProject.BackColor = Color.FromArgb(20, 20, 20);
            panelProject.Controls.Add(labelPDFProject);
            panelProject.Location = new Point(253, 266);
            panelProject.Margin = new Padding(3, 2, 3, 2);
            panelProject.Name = "panelProject";
            panelProject.Size = new Size(200, 41);
            panelProject.TabIndex = 37;
            panelProject.Click += panelProject_Click;
            panelProject.DragDrop += panelProject_DragDrop;
            panelProject.DragEnter += panelProject_DragEnter;
            panelProject.DragLeave += panelProject_DragLeave;
            panelProject.MouseEnter += panel3_MouseEnter;
            panelProject.MouseLeave += panel3_MouseLeave;
            // 
            // labelPDFProject
            // 
            labelPDFProject.AllowDrop = true;
            labelPDFProject.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelPDFProject.AutoSize = true;
            labelPDFProject.Font = new Font("Segoe UI", 9.6F, FontStyle.Regular, GraphicsUnit.Point);
            labelPDFProject.ForeColor = Color.White;
            labelPDFProject.Location = new Point(25, 11);
            labelPDFProject.Name = "labelPDFProject";
            labelPDFProject.Size = new Size(146, 17);
            labelPDFProject.TabIndex = 34;
            labelPDFProject.Text = "     Select or Drag a File";
            labelPDFProject.TextAlign = ContentAlignment.MiddleCenter;
            labelPDFProject.Click += panelProject_Click;
            labelPDFProject.DragDrop += panelProject_DragDrop;
            labelPDFProject.DragEnter += panelProject_DragEnter;
            labelPDFProject.DragLeave += panelProject_DragLeave;
            labelPDFProject.MouseEnter += panel3_MouseEnter;
            labelPDFProject.MouseLeave += panel3_MouseLeave;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Location = new Point(10, 41);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(38, 32);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.MouseDown += pictureBox1_MouseDown;
            pictureBox1.MouseEnter += pictureBox1_MouseEnter;
            pictureBox1.MouseLeave += pictureBox1_MouseLeave;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label9.ForeColor = Color.White;
            label9.Location = new Point(10, 7);
            label9.Name = "label9";
            label9.Size = new Size(115, 28);
            label9.TabIndex = 42;
            label9.Text = "Add Project";
            // 
            // panel1
            // 
            panel1.AllowDrop = true;
            panel1.Controls.Add(label10);
            panel1.Controls.Add(panel4);
            panel1.Location = new Point(222, 64);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(492, 401);
            panel1.TabIndex = 43;
            panel1.DragEnter += ProjectRegister_DragEnter;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            label10.ForeColor = Color.White;
            label10.Location = new Point(27, 7);
            label10.Name = "label10";
            label10.Size = new Size(175, 25);
            label10.TabIndex = 45;
            label10.Text = "  Project Information";
            // 
            // panel4
            // 
            panel4.AllowDrop = true;
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Controls.Add(panelPlus1);
            panel4.Controls.Add(panelPlus2);
            panel4.Controls.Add(panel7);
            panel4.Controls.Add(panel5);
            panel4.Controls.Add(label7);
            panel4.Controls.Add(panelProject);
            panel4.Controls.Add(labelProject);
            panel4.Controls.Add(label6);
            panel4.Controls.Add(labelValue);
            panel4.Controls.Add(panelIndications);
            panel4.Controls.Add(label8);
            panel4.Controls.Add(buttonSave);
            panel4.Controls.Add(label2);
            panel4.Controls.Add(label3);
            panel4.Controls.Add(textBoxValue);
            panel4.Controls.Add(dateTimePickerLimit);
            panel4.Controls.Add(label1);
            panel4.Controls.Add(textBoxProject);
            panel4.Controls.Add(dateTimePicker);
            panel4.Controls.Add(labelPeriod);
            panel4.Controls.Add(label5);
            panel4.Controls.Add(comboBoxPeriod);
            panel4.Controls.Add(labelAsignature);
            panel4.Controls.Add(comboBoxAsignature);
            panel4.Controls.Add(label4);
            panel4.Location = new Point(3, 26);
            panel4.Name = "panel4";
            panel4.Size = new Size(486, 369);
            panel4.TabIndex = 39;
            panel4.DragEnter += ProjectRegister_DragEnter;
            // 
            // panelPlus1
            // 
            panelPlus1.AllowDrop = true;
            panelPlus1.BackColor = Color.FromArgb(20, 20, 20);
            panelPlus1.Controls.Add(picturePlus1);
            panelPlus1.Location = new Point(14, 266);
            panelPlus1.Name = "panelPlus1";
            panelPlus1.Size = new Size(25, 41);
            panelPlus1.TabIndex = 49;
            panelPlus1.DragDrop += panelPlus1_DragDrop;
            panelPlus1.DragEnter += panelPlus1_DragEnter;
            panelPlus1.DragLeave += panelPlus1_DragLeave;
            panelPlus1.MouseDown += panelPlus1_MouseDown;
            panelPlus1.MouseEnter += panelPlus1_MouseEnter;
            panelPlus1.MouseLeave += panelPlus1_MouseLeave;
            // 
            // picturePlus1
            // 
            picturePlus1.BackgroundImage = (Image)resources.GetObject("picturePlus1.BackgroundImage");
            picturePlus1.BackgroundImageLayout = ImageLayout.Stretch;
            picturePlus1.Location = new Point(1, 9);
            picturePlus1.Margin = new Padding(3, 2, 3, 2);
            picturePlus1.Name = "picturePlus1";
            picturePlus1.Size = new Size(24, 22);
            picturePlus1.TabIndex = 0;
            picturePlus1.TabStop = false;
            picturePlus1.DragDrop += panelPlus1_DragDrop;
            picturePlus1.DragEnter += panelPlus1_DragEnter;
            picturePlus1.DragLeave += panelPlus1_DragLeave;
            picturePlus1.MouseDown += panelPlus1_MouseDown;
            picturePlus1.MouseEnter += panelPlus1_MouseEnter;
            picturePlus1.MouseLeave += panelPlus1_MouseLeave;
            // 
            // panelPlus2
            // 
            panelPlus2.AllowDrop = true;
            panelPlus2.BackColor = Color.FromArgb(20, 20, 20);
            panelPlus2.Controls.Add(picturePlus2);
            panelPlus2.Location = new Point(454, 266);
            panelPlus2.Name = "panelPlus2";
            panelPlus2.Size = new Size(25, 41);
            panelPlus2.TabIndex = 48;
            panelPlus2.DragDrop += panelPlus2_DragDrop;
            panelPlus2.DragEnter += panelPlus2_DragEnter;
            panelPlus2.DragLeave += panelPlus2_DragLeave;
            panelPlus2.MouseDown += panelPlus2_MouseDown;
            panelPlus2.MouseEnter += panelPlus2_MouseEnter;
            panelPlus2.MouseLeave += panelPlus2_MouseLeave;
            // 
            // picturePlus2
            // 
            picturePlus2.BackgroundImage = (Image)resources.GetObject("picturePlus2.BackgroundImage");
            picturePlus2.BackgroundImageLayout = ImageLayout.Stretch;
            picturePlus2.Location = new Point(1, 9);
            picturePlus2.Margin = new Padding(3, 2, 3, 2);
            picturePlus2.Name = "picturePlus2";
            picturePlus2.Size = new Size(24, 22);
            picturePlus2.TabIndex = 0;
            picturePlus2.TabStop = false;
            picturePlus2.DragDrop += panelPlus2_DragDrop;
            picturePlus2.DragEnter += panelPlus2_DragEnter;
            picturePlus2.DragLeave += panelPlus2_DragLeave;
            picturePlus2.MouseDown += panelPlus2_MouseDown;
            picturePlus2.MouseEnter += panelPlus2_MouseEnter;
            picturePlus2.MouseLeave += panelPlus2_MouseLeave;
            // 
            // panel7
            // 
            panel7.AllowDrop = true;
            panel7.Dock = DockStyle.Bottom;
            panel7.Location = new Point(0, 358);
            panel7.Name = "panel7";
            panel7.Size = new Size(484, 8);
            panel7.TabIndex = 40;
            panel7.DragEnter += ProjectRegister_DragEnter;
            // 
            // panel5
            // 
            panel5.Dock = DockStyle.Bottom;
            panel5.Location = new Point(0, 366);
            panel5.Name = "panel5";
            panel5.Size = new Size(484, 1);
            panel5.TabIndex = 39;
            // 
            // panel6
            // 
            panel6.Dock = DockStyle.Bottom;
            panel6.Location = new Point(0, 592);
            panel6.Name = "panel6";
            panel6.Size = new Size(920, 8);
            panel6.TabIndex = 44;
            // 
            // ProjectRegister
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(920, 600);
            Controls.Add(pictureBox1);
            Controls.Add(panel6);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Controls.Add(label9);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "ProjectRegister";
            Text = "ProjectRegister";
            DragDrop += ProjectRegister_DragDrop;
            DragEnter += ProjectRegister_DragEnter;
            MouseEnter += ProjectRegister_MouseEnter;
            Resize += ProjectRegister_Resize;
            panelIndications.ResumeLayout(false);
            panelIndications.PerformLayout();
            panelProject.ResumeLayout(false);
            panelProject.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panelPlus1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picturePlus1).EndInit();
            panelPlus2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picturePlus2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonSave;
        private Label label3;
        private Label label1;
        private TextBox textBoxProject;
        private DateTimePicker dateTimePickerLimit;
        private Label label2;
        private TextBox textBoxValue;
        private Label label4;
        private ComboBox comboBoxAsignature;
        private Label labelAsignature;
        private Label labelProject;
        private Label labelValue;
        private Label labelPeriod;
        private Label label5;
        private ComboBox comboBoxPeriod;
        private Label label6;
        private Panel panelIndications;
        private Label labelPDFIndications;
        private DateTimePicker dateTimePicker;
        private Label label8;
        private Panel panel2;
        private Label label7;
        private Panel panelProject;
        private Label labelPDFProject;
        private PictureBox pictureBox1;
        private Label label9;
        private Panel panel1;
        private Label label10;
        private Panel panel4;
        private Panel panel5;
        private Panel panel7;
        private Panel panel6;
        private Panel panelPlus2;
        private PictureBox picturePlus2;
        private Panel panelPlus1;
        private PictureBox picturePlus1;
    }
}