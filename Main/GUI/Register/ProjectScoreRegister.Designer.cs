namespace Dysfunction.GUI.Register
{
    partial class ProjectScoreRegister
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectScoreRegister));
            comboBoxAsignature = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            comboBoxProject = new ComboBox();
            label3 = new Label();
            buttonSave = new Button();
            textBoxScore = new TextBox();
            labelAsignature = new Label();
            labelProject = new Label();
            labelScore = new Label();
            labelPeriod = new Label();
            label4 = new Label();
            comboBoxPeriod = new ComboBox();
            label8 = new Label();
            dateTimePicker = new DateTimePicker();
            panel1 = new Panel();
            label9 = new Label();
            pictureBox1 = new PictureBox();
            panel2 = new Panel();
            label10 = new Label();
            panel3 = new Panel();
            panel4 = new Panel();
            panel5 = new Panel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // comboBoxAsignature
            // 
            comboBoxAsignature.Anchor = AnchorStyles.Top;
            comboBoxAsignature.BackColor = Color.White;
            comboBoxAsignature.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxAsignature.ForeColor = Color.Black;
            comboBoxAsignature.FormattingEnabled = true;
            comboBoxAsignature.Location = new Point(26, 88);
            comboBoxAsignature.Margin = new Padding(3, 2, 3, 2);
            comboBoxAsignature.Name = "comboBoxAsignature";
            comboBoxAsignature.Size = new Size(414, 23);
            comboBoxAsignature.TabIndex = 1;
            comboBoxAsignature.SelectedIndexChanged += comboBoxAsignature_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.ForeColor = Color.White;
            label1.Location = new Point(27, 71);
            label1.Name = "label1";
            label1.Size = new Size(64, 15);
            label1.TabIndex = 2;
            label1.Text = "Asignature";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.AutoSize = true;
            label2.ForeColor = Color.White;
            label2.Location = new Point(26, 113);
            label2.Name = "label2";
            label2.Size = new Size(44, 15);
            label2.TabIndex = 4;
            label2.Text = "Project";
            // 
            // comboBoxProject
            // 
            comboBoxProject.Anchor = AnchorStyles.Top;
            comboBoxProject.BackColor = Color.White;
            comboBoxProject.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxProject.ForeColor = Color.Black;
            comboBoxProject.FormattingEnabled = true;
            comboBoxProject.Location = new Point(28, 130);
            comboBoxProject.Margin = new Padding(3, 2, 3, 2);
            comboBoxProject.Name = "comboBoxProject";
            comboBoxProject.Size = new Size(414, 23);
            comboBoxProject.TabIndex = 3;
            comboBoxProject.SelectedIndexChanged += comboBoxProject_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top;
            label3.AutoSize = true;
            label3.ForeColor = Color.White;
            label3.Location = new Point(24, 157);
            label3.Name = "label3";
            label3.Size = new Size(36, 15);
            label3.TabIndex = 6;
            label3.Text = "Score";
            // 
            // buttonSave
            // 
            buttonSave.Anchor = AnchorStyles.Top;
            buttonSave.FlatAppearance.BorderColor = Color.FromArgb(64, 64, 64);
            buttonSave.FlatAppearance.MouseDownBackColor = Color.FromArgb(20, 20, 20);
            buttonSave.FlatAppearance.MouseOverBackColor = Color.FromArgb(20, 20, 20);
            buttonSave.FlatStyle = FlatStyle.Flat;
            buttonSave.ForeColor = Color.White;
            buttonSave.Location = new Point(136, 207);
            buttonSave.Margin = new Padding(3, 2, 3, 2);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(195, 35);
            buttonSave.TabIndex = 10;
            buttonSave.Text = "Save Score";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // textBoxScore
            // 
            textBoxScore.Anchor = AnchorStyles.Top;
            textBoxScore.BackColor = Color.Black;
            textBoxScore.BorderStyle = BorderStyle.FixedSingle;
            textBoxScore.ForeColor = Color.White;
            textBoxScore.Location = new Point(26, 174);
            textBoxScore.Margin = new Padding(3, 2, 3, 2);
            textBoxScore.Name = "textBoxScore";
            textBoxScore.PlaceholderText = "Between 0 and 10";
            textBoxScore.Size = new Size(414, 23);
            textBoxScore.TabIndex = 11;
            textBoxScore.Click += textBoxScore_Click;
            textBoxScore.TextChanged += textBoxScore_TextChanged;
            // 
            // labelAsignature
            // 
            labelAsignature.Anchor = AnchorStyles.Top;
            labelAsignature.AutoSize = true;
            labelAsignature.BackColor = Color.Black;
            labelAsignature.Font = new Font("Arial Narrow", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            labelAsignature.ForeColor = Color.White;
            labelAsignature.Location = new Point(7, 88);
            labelAsignature.Name = "labelAsignature";
            labelAsignature.Size = new Size(14, 23);
            labelAsignature.TabIndex = 21;
            labelAsignature.Text = "!";
            // 
            // labelProject
            // 
            labelProject.Anchor = AnchorStyles.Top;
            labelProject.AutoSize = true;
            labelProject.BackColor = Color.Black;
            labelProject.Font = new Font("Arial Narrow", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            labelProject.ForeColor = Color.White;
            labelProject.Location = new Point(6, 128);
            labelProject.Name = "labelProject";
            labelProject.Size = new Size(14, 23);
            labelProject.TabIndex = 22;
            labelProject.Text = "!";
            // 
            // labelScore
            // 
            labelScore.Anchor = AnchorStyles.Top;
            labelScore.AutoSize = true;
            labelScore.BackColor = Color.Black;
            labelScore.Font = new Font("Arial Narrow", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            labelScore.ForeColor = Color.White;
            labelScore.Location = new Point(7, 174);
            labelScore.Name = "labelScore";
            labelScore.Size = new Size(14, 23);
            labelScore.TabIndex = 23;
            labelScore.Text = "!";
            // 
            // labelPeriod
            // 
            labelPeriod.Anchor = AnchorStyles.Top;
            labelPeriod.AutoSize = true;
            labelPeriod.BackColor = Color.Black;
            labelPeriod.Font = new Font("Arial Narrow", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            labelPeriod.ForeColor = Color.White;
            labelPeriod.Location = new Point(7, 42);
            labelPeriod.Name = "labelPeriod";
            labelPeriod.Size = new Size(14, 23);
            labelPeriod.TabIndex = 26;
            labelPeriod.Text = "!";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top;
            label4.AutoSize = true;
            label4.ForeColor = Color.White;
            label4.Location = new Point(27, 25);
            label4.Name = "label4";
            label4.Size = new Size(41, 15);
            label4.TabIndex = 25;
            label4.Text = "Period";
            // 
            // comboBoxPeriod
            // 
            comboBoxPeriod.Anchor = AnchorStyles.Top;
            comboBoxPeriod.BackColor = Color.White;
            comboBoxPeriod.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxPeriod.ForeColor = Color.Black;
            comboBoxPeriod.FormattingEnabled = true;
            comboBoxPeriod.Location = new Point(26, 42);
            comboBoxPeriod.Margin = new Padding(3, 2, 3, 2);
            comboBoxPeriod.Name = "comboBoxPeriod";
            comboBoxPeriod.Size = new Size(196, 23);
            comboBoxPeriod.TabIndex = 24;
            comboBoxPeriod.SelectedIndexChanged += comboBoxPeriod_SelectedIndexChanged;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Top;
            label8.AutoSize = true;
            label8.ForeColor = Color.White;
            label8.Location = new Point(244, 25);
            label8.Name = "label8";
            label8.Size = new Size(29, 15);
            label8.TabIndex = 37;
            label8.Text = "Year";
            // 
            // dateTimePicker
            // 
            dateTimePicker.Anchor = AnchorStyles.Top;
            dateTimePicker.CustomFormat = "yyyy";
            dateTimePicker.Format = DateTimePickerFormat.Custom;
            dateTimePicker.Location = new Point(244, 42);
            dateTimePicker.Margin = new Padding(3, 2, 3, 2);
            dateTimePicker.Name = "dateTimePicker";
            dateTimePicker.ShowUpDown = true;
            dateTimePicker.Size = new Size(196, 23);
            dateTimePicker.TabIndex = 36;
            dateTimePicker.ValueChanged += dateTimePicker_ValueChanged;
            // 
            // panel1
            // 
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(920, 1);
            panel1.TabIndex = 38;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label9.ForeColor = Color.White;
            label9.Location = new Point(10, 7);
            label9.Name = "label9";
            label9.Size = new Size(73, 28);
            label9.TabIndex = 44;
            label9.Text = "Grades";
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(10, 41);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(38, 32);
            pictureBox1.TabIndex = 43;
            pictureBox1.TabStop = false;
            pictureBox1.MouseDown += pictureBox1_MouseDown;
            pictureBox1.MouseEnter += pictureBox1_MouseEnter;
            pictureBox1.MouseLeave += pictureBox1_MouseLeave;
            // 
            // panel2
            // 
            panel2.Controls.Add(label10);
            panel2.Controls.Add(panel3);
            panel2.Location = new Point(223, 135);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(474, 277);
            panel2.TabIndex = 45;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            label10.ForeColor = Color.White;
            label10.Location = new Point(28, 5);
            label10.Name = "label10";
            label10.Size = new Size(175, 25);
            label10.TabIndex = 46;
            label10.Text = "  Project Information";
            // 
            // panel3
            // 
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(panel4);
            panel3.Controls.Add(label8);
            panel3.Controls.Add(comboBoxPeriod);
            panel3.Controls.Add(labelAsignature);
            panel3.Controls.Add(dateTimePicker);
            panel3.Controls.Add(label1);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(comboBoxProject);
            panel3.Controls.Add(labelProject);
            panel3.Controls.Add(buttonSave);
            panel3.Controls.Add(label4);
            panel3.Controls.Add(labelScore);
            panel3.Controls.Add(labelPeriod);
            panel3.Controls.Add(textBoxScore);
            panel3.Controls.Add(comboBoxAsignature);
            panel3.Controls.Add(label2);
            panel3.Location = new Point(3, 23);
            panel3.Name = "panel3";
            panel3.Size = new Size(468, 250);
            panel3.TabIndex = 47;
            // 
            // panel4
            // 
            panel4.Dock = DockStyle.Bottom;
            panel4.Location = new Point(0, 247);
            panel4.Name = "panel4";
            panel4.Size = new Size(466, 1);
            panel4.TabIndex = 38;
            // 
            // panel5
            // 
            panel5.Dock = DockStyle.Bottom;
            panel5.Location = new Point(0, 592);
            panel5.Name = "panel5";
            panel5.Size = new Size(920, 8);
            panel5.TabIndex = 46;
            // 
            // ProjectScoreRegister
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(920, 600);
            Controls.Add(panel5);
            Controls.Add(label9);
            Controls.Add(pictureBox1);
            Controls.Add(panel1);
            Controls.Add(panel2);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "ProjectScoreRegister";
            Text = "ProjectScoreRegister";
            MouseEnter += ProjectRegister_MouseEnter;
            Resize += ProjectScoreRegister_Resize;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBoxAsignature;
        private Label label1;
        private Label label2;
        private ComboBox comboBoxProject;
        private Label label3;
        private Button buttonSave;
        private TextBox textBoxScore;
        private Label labelAsignature;
        private Label labelProject;
        private Label labelScore;
        private Label labelPeriod;
        private Label label4;
        private ComboBox comboBoxPeriod;
        private Label label8;
        private DateTimePicker dateTimePicker;
        private Panel panel1;
        private Label label9;
        private PictureBox pictureBox1;
        private Panel panel2;
        private Label label10;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
    }
}