namespace Dysfunction.GUI.Register
{
    partial class ProjectEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectEdit));
            buttonEdit = new Button();
            label3 = new Label();
            label1 = new Label();
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
            labelPDF = new Label();
            dateTimePicker = new DateTimePicker();
            label8 = new Label();
            buttonDelete = new Button();
            comboBoxProject = new ComboBox();
            panel2 = new Panel();
            label7 = new Label();
            panelProject = new Panel();
            labelPDFProject = new Label();
            label9 = new Label();
            backButton = new PictureBox();
            panel4 = new Panel();
            label10 = new Label();
            panel5 = new Panel();
            panelPlus2 = new Panel();
            picturePlus2 = new PictureBox();
            panelPlus1 = new Panel();
            picturePlus1 = new PictureBox();
            panel6 = new Panel();
            panelIndications.SuspendLayout();
            panelProject.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)backButton).BeginInit();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            panelPlus2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picturePlus2).BeginInit();
            panelPlus1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picturePlus1).BeginInit();
            SuspendLayout();
            // 
            // buttonEdit
            // 
            buttonEdit.Anchor = AnchorStyles.Top;
            buttonEdit.BackColor = Color.Black;
            buttonEdit.FlatAppearance.BorderColor = Color.FromArgb(64, 64, 64);
            buttonEdit.FlatAppearance.MouseDownBackColor = Color.FromArgb(20, 20, 20);
            buttonEdit.FlatAppearance.MouseOverBackColor = Color.FromArgb(20, 20, 20);
            buttonEdit.FlatStyle = FlatStyle.Flat;
            buttonEdit.ForeColor = Color.White;
            buttonEdit.Location = new Point(173, 302);
            buttonEdit.Margin = new Padding(3, 2, 3, 2);
            buttonEdit.Name = "buttonEdit";
            buttonEdit.Size = new Size(195, 34);
            buttonEdit.TabIndex = 15;
            buttonEdit.Text = "Save Edit";
            buttonEdit.UseVisualStyleBackColor = false;
            buttonEdit.Click += buttonSave_Click;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top;
            label3.AutoSize = true;
            label3.ForeColor = Color.White;
            label3.Location = new Point(63, 193);
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
            label1.Location = new Point(63, 110);
            label1.Name = "label1";
            label1.Size = new Size(44, 15);
            label1.TabIndex = 12;
            label1.Text = "Project";
            // 
            // dateTimePickerLimit
            // 
            dateTimePickerLimit.Anchor = AnchorStyles.Top;
            dateTimePickerLimit.Enabled = false;
            dateTimePickerLimit.Format = DateTimePickerFormat.Short;
            dateTimePickerLimit.Location = new Point(65, 210);
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
            label2.Location = new Point(63, 151);
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
            textBoxValue.Enabled = false;
            textBoxValue.ForeColor = Color.White;
            textBoxValue.Location = new Point(66, 169);
            textBoxValue.Margin = new Padding(3, 2, 3, 2);
            textBoxValue.Name = "textBoxValue";
            textBoxValue.PlaceholderText = "Between 0 and10";
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
            label4.Location = new Point(63, 63);
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
            comboBoxAsignature.Location = new Point(65, 82);
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
            labelAsignature.Location = new Point(43, 82);
            labelAsignature.Name = "labelAsignature";
            labelAsignature.Size = new Size(14, 23);
            labelAsignature.TabIndex = 20;
            labelAsignature.Text = "!";
            labelAsignature.Visible = false;
            // 
            // labelProject
            // 
            labelProject.Anchor = AnchorStyles.Top;
            labelProject.AutoSize = true;
            labelProject.BackColor = Color.Black;
            labelProject.Font = new Font("Arial Narrow", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            labelProject.ForeColor = Color.White;
            labelProject.Location = new Point(42, 126);
            labelProject.Name = "labelProject";
            labelProject.Size = new Size(14, 23);
            labelProject.TabIndex = 21;
            labelProject.Text = "!";
            labelProject.Visible = false;
            // 
            // labelValue
            // 
            labelValue.Anchor = AnchorStyles.Top;
            labelValue.AutoSize = true;
            labelValue.BackColor = Color.Black;
            labelValue.Font = new Font("Arial Narrow", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            labelValue.ForeColor = Color.White;
            labelValue.Location = new Point(42, 169);
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
            labelPeriod.Location = new Point(265, 34);
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
            label5.Location = new Point(280, 19);
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
            comboBoxPeriod.Location = new Point(283, 36);
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
            label6.Location = new Point(63, 234);
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
            panelIndications.Controls.Add(labelPDF);
            panelIndications.Location = new Point(63, 251);
            panelIndications.Margin = new Padding(3, 2, 3, 2);
            panelIndications.Name = "panelIndications";
            panelIndications.Size = new Size(200, 43);
            panelIndications.TabIndex = 30;
            panelIndications.Click += panelIndications_Click;
            panelIndications.DragDrop += panelIndications_DragDrop;
            panelIndications.DragEnter += panelIndications_DragEnter;
            panelIndications.MouseEnter += panelIndications_MouseEnter;
            panelIndications.MouseLeave += panelIndications_MouseLeave;
            // 
            // labelPDF
            // 
            labelPDF.AllowDrop = true;
            labelPDF.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelPDF.AutoSize = true;
            labelPDF.Font = new Font("Segoe UI", 9.6F, FontStyle.Regular, GraphicsUnit.Point);
            labelPDF.ForeColor = Color.White;
            labelPDF.Location = new Point(33, 13);
            labelPDF.Name = "labelPDF";
            labelPDF.Size = new Size(121, 17);
            labelPDF.TabIndex = 34;
            labelPDF.Text = "Select or Drag Files";
            labelPDF.TextAlign = ContentAlignment.MiddleCenter;
            labelPDF.Click += panelIndications_Click;
            labelPDF.DragDrop += panelIndications_DragDrop;
            labelPDF.DragEnter += panelIndications_DragEnter;
            labelPDF.MouseEnter += panelIndications_MouseEnter;
            labelPDF.MouseLeave += panelIndications_MouseLeave;
            // 
            // dateTimePicker
            // 
            dateTimePicker.Anchor = AnchorStyles.Top;
            dateTimePicker.CustomFormat = "yyyy";
            dateTimePicker.Format = DateTimePickerFormat.Custom;
            dateTimePicker.Location = new Point(66, 38);
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
            label8.Location = new Point(63, 19);
            label8.Name = "label8";
            label8.Size = new Size(29, 15);
            label8.TabIndex = 35;
            label8.Text = "Year";
            // 
            // buttonDelete
            // 
            buttonDelete.Anchor = AnchorStyles.Top;
            buttonDelete.BackColor = Color.Black;
            buttonDelete.FlatAppearance.BorderColor = Color.FromArgb(64, 64, 64);
            buttonDelete.FlatAppearance.MouseDownBackColor = Color.FromArgb(20, 20, 20);
            buttonDelete.FlatAppearance.MouseOverBackColor = Color.FromArgb(20, 20, 20);
            buttonDelete.FlatStyle = FlatStyle.Flat;
            buttonDelete.ForeColor = Color.White;
            buttonDelete.Location = new Point(173, 349);
            buttonDelete.Margin = new Padding(3, 2, 3, 2);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(195, 33);
            buttonDelete.TabIndex = 36;
            buttonDelete.Text = "Delete Project";
            buttonDelete.UseVisualStyleBackColor = false;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // comboBoxProject
            // 
            comboBoxProject.Anchor = AnchorStyles.Top;
            comboBoxProject.BackColor = Color.White;
            comboBoxProject.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxProject.ForeColor = Color.Black;
            comboBoxProject.FormattingEnabled = true;
            comboBoxProject.Location = new Point(65, 128);
            comboBoxProject.Margin = new Padding(3, 2, 3, 2);
            comboBoxProject.Name = "comboBoxProject";
            comboBoxProject.Size = new Size(414, 23);
            comboBoxProject.TabIndex = 37;
            comboBoxProject.SelectedIndexChanged += comboBoxProject_SelectedIndexChanged;
            // 
            // panel2
            // 
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(960, 1);
            panel2.TabIndex = 38;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top;
            label7.AutoSize = true;
            label7.ForeColor = Color.White;
            label7.Location = new Point(277, 234);
            label7.Name = "label7";
            label7.Size = new Size(44, 15);
            label7.TabIndex = 40;
            label7.Text = "Project";
            // 
            // panelProject
            // 
            panelProject.AllowDrop = true;
            panelProject.Anchor = AnchorStyles.Top;
            panelProject.BackColor = Color.FromArgb(20, 20, 20);
            panelProject.Controls.Add(labelPDFProject);
            panelProject.Location = new Point(277, 251);
            panelProject.Margin = new Padding(3, 2, 3, 2);
            panelProject.Name = "panelProject";
            panelProject.Size = new Size(200, 43);
            panelProject.TabIndex = 39;
            panelProject.Click += panelProject_Click;
            panelProject.DragDrop += panelProject_DragDrop;
            panelProject.DragEnter += panelProject_DragEnter;
            panelProject.MouseEnter += panelProject_MouseEnter;
            panelProject.MouseLeave += panelProject_MouseLeave;
            // 
            // labelPDFProject
            // 
            labelPDFProject.AllowDrop = true;
            labelPDFProject.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelPDFProject.AutoSize = true;
            labelPDFProject.Font = new Font("Segoe UI", 9.6F, FontStyle.Regular, GraphicsUnit.Point);
            labelPDFProject.ForeColor = Color.White;
            labelPDFProject.Location = new Point(32, 13);
            labelPDFProject.Name = "labelPDFProject";
            labelPDFProject.Size = new Size(126, 17);
            labelPDFProject.TabIndex = 34;
            labelPDFProject.Text = "Select or Drag a File";
            labelPDFProject.TextAlign = ContentAlignment.MiddleCenter;
            labelPDFProject.Click += panelProject_Click;
            labelPDFProject.DragDrop += panelProject_DragDrop;
            labelPDFProject.DragEnter += panelProject_DragEnter;
            labelPDFProject.MouseEnter += panelProject_MouseEnter;
            labelPDFProject.MouseLeave += panelProject_MouseLeave;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label9.ForeColor = Color.White;
            label9.Location = new Point(10, 7);
            label9.Name = "label9";
            label9.Size = new Size(112, 28);
            label9.TabIndex = 44;
            label9.Text = "Edit Project";
            // 
            // backButton
            // 
            backButton.BackgroundImage = (Image)resources.GetObject("backButton.BackgroundImage");
            backButton.BackgroundImageLayout = ImageLayout.Stretch;
            backButton.Location = new Point(10, 41);
            backButton.Margin = new Padding(3, 2, 3, 2);
            backButton.Name = "backButton";
            backButton.Size = new Size(38, 32);
            backButton.TabIndex = 43;
            backButton.TabStop = false;
            backButton.MouseDown += backButton_MouseDown;
            backButton.MouseEnter += backButton_MouseEnter;
            backButton.MouseLeave += backButton_MouseLeave;
            // 
            // panel4
            // 
            panel4.Controls.Add(label10);
            panel4.Controls.Add(panel5);
            panel4.Location = new Point(212, 63);
            panel4.Margin = new Padding(3, 2, 3, 2);
            panel4.Name = "panel4";
            panel4.Size = new Size(544, 446);
            panel4.TabIndex = 45;
            panel4.Click += panel4_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            label10.ForeColor = Color.White;
            label10.Location = new Point(29, 12);
            label10.Name = "label10";
            label10.Size = new Size(180, 25);
            label10.TabIndex = 46;
            label10.Text = "   Project Information";
            // 
            // panel5
            // 
            panel5.BorderStyle = BorderStyle.FixedSingle;
            panel5.Controls.Add(panelPlus2);
            panel5.Controls.Add(panelPlus1);
            panel5.Controls.Add(label7);
            panel5.Controls.Add(panelProject);
            panel5.Controls.Add(comboBoxProject);
            panel5.Controls.Add(buttonDelete);
            panel5.Controls.Add(labelProject);
            panel5.Controls.Add(label6);
            panel5.Controls.Add(labelValue);
            panel5.Controls.Add(panelIndications);
            panel5.Controls.Add(label8);
            panel5.Controls.Add(buttonEdit);
            panel5.Controls.Add(label2);
            panel5.Controls.Add(label3);
            panel5.Controls.Add(textBoxValue);
            panel5.Controls.Add(dateTimePickerLimit);
            panel5.Controls.Add(label1);
            panel5.Controls.Add(dateTimePicker);
            panel5.Controls.Add(labelPeriod);
            panel5.Controls.Add(label5);
            panel5.Controls.Add(comboBoxPeriod);
            panel5.Controls.Add(labelAsignature);
            panel5.Controls.Add(comboBoxAsignature);
            panel5.Controls.Add(label4);
            panel5.Location = new Point(1, 27);
            panel5.Name = "panel5";
            panel5.Size = new Size(543, 397);
            panel5.TabIndex = 41;
            panel5.Click += panel4_Click;
            // 
            // panelPlus2
            // 
            panelPlus2.AllowDrop = true;
            panelPlus2.BackColor = Color.FromArgb(20, 20, 20);
            panelPlus2.Controls.Add(picturePlus2);
            panelPlus2.Location = new Point(478, 251);
            panelPlus2.Name = "panelPlus2";
            panelPlus2.Size = new Size(25, 43);
            panelPlus2.TabIndex = 51;
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
            picturePlus2.Location = new Point(1, 10);
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
            // panelPlus1
            // 
            panelPlus1.AllowDrop = true;
            panelPlus1.BackColor = Color.FromArgb(20, 20, 20);
            panelPlus1.Controls.Add(picturePlus1);
            panelPlus1.Location = new Point(37, 251);
            panelPlus1.Name = "panelPlus1";
            panelPlus1.Size = new Size(25, 43);
            panelPlus1.TabIndex = 50;
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
            picturePlus1.Location = new Point(1, 10);
            picturePlus1.Margin = new Padding(3, 2, 3, 2);
            picturePlus1.Name = "picturePlus1";
            picturePlus1.Size = new Size(24, 22);
            picturePlus1.TabIndex = 0;
            picturePlus1.TabStop = false;
            picturePlus1.DragDrop += panelPlus1_DragDrop;
            picturePlus1.DragEnter += panelPlus1_DragEnter;
            picturePlus1.DragLeave += panelPlus1_MouseLeave;
            picturePlus1.MouseDown += panelPlus1_MouseDown;
            picturePlus1.MouseEnter += panelPlus1_MouseEnter;
            picturePlus1.MouseLeave += panelPlus1_MouseLeave;
            // 
            // panel6
            // 
            panel6.Dock = DockStyle.Bottom;
            panel6.Location = new Point(0, 599);
            panel6.Name = "panel6";
            panel6.Size = new Size(960, 1);
            panel6.TabIndex = 46;
            // 
            // ProjectEdit
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(960, 600);
            Controls.Add(panel6);
            Controls.Add(backButton);
            Controls.Add(panel2);
            Controls.Add(panel4);
            Controls.Add(label9);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "ProjectEdit";
            Text = "ProjectRegister";
            Click += panel4_Click;
            MouseEnter += ProjectRegister_MouseEnter;
            Resize += ProjectEdit_Resize;
            panelIndications.ResumeLayout(false);
            panelIndications.PerformLayout();
            panelProject.ResumeLayout(false);
            panelProject.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)backButton).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panelPlus2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picturePlus2).EndInit();
            panelPlus1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picturePlus1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonEdit;
        private Label label3;
        private Label label1;
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
        private Label labelPDF;
        private DateTimePicker dateTimePicker;
        private Label label8;
        private Button buttonDelete;
        private ComboBox comboBoxProject;
        private Panel panel2;
        private Label label7;
        private Panel panelProject;
        private Label labelPDFProject;
        private Label label9;
        private PictureBox backButton;
        private Panel panel4;
        private Label label10;
        private Panel panel5;
        private Panel panel6;
        private Panel panelPlus1;
        private PictureBox picturePlus1;
        private Panel panelPlus2;
        private PictureBox picturePlus2;
    }
}