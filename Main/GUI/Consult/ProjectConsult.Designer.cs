namespace Dysfunction.GUI.Consult
{
    partial class ProjectConsult
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectConsult));
            dataGridView = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column7 = new DataGridViewCheckBoxColumn();
            comboBoxPeriod = new ComboBox();
            comboBoxAsignature = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label8 = new Label();
            dateTimePicker = new DateTimePicker();
            panel2 = new Panel();
            label3 = new Label();
            pictureBox1 = new PictureBox();
            label5 = new Label();
            panel3 = new Panel();
            label6 = new Label();
            pictureBox3 = new PictureBox();
            panel4 = new Panel();
            panel6 = new Panel();
            panel5 = new Panel();
            labelProject = new Label();
            pictureBox4 = new PictureBox();
            panel1 = new Panel();
            label4 = new Label();
            pictureBox2 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            panel6.SuspendLayout();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.BackgroundColor = Color.Black;
            dataGridView.BorderStyle = BorderStyle.None;
            dataGridView.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.Black;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { Column1, Column6, Column3, Column2, Column5, Column4, Column7 });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.GridColor = Color.FromArgb(20, 20, 20);
            dataGridView.Location = new Point(10, 160);
            dataGridView.Margin = new Padding(3, 2, 3, 2);
            dataGridView.Name = "dataGridView";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridView.RowHeadersVisible = false;
            dataGridView.RowHeadersWidth = 102;
            dataGridView.Size = new Size(941, 431);
            dataGridView.TabIndex = 0;
            dataGridView.CellClick += dataGridView_CellContentClick;
            dataGridView.CellMouseClick += dataGridView_CellMouseClick;
            dataGridView.CellValueChanged += dataGridView_CellValueChanged;
            dataGridView.CurrentCellDirtyStateChanged += dataGridView_CurrentCellDirtyStateChanged;
            dataGridView.SelectionChanged += dataGridView_SelectionChanged;
            dataGridView.MouseClick += dataGridView_MouseClick;
            // 
            // Column1
            // 
            Column1.HeaderText = "Project";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            // 
            // Column6
            // 
            Column6.HeaderText = "Indications";
            Column6.MinimumWidth = 6;
            Column6.Name = "Column6";
            Column6.ReadOnly = true;
            // 
            // Column3
            // 
            Column3.HeaderText = "Limit date";
            Column3.MinimumWidth = 6;
            Column3.Name = "Column3";
            Column3.ReadOnly = true;
            // 
            // Column2
            // 
            Column2.HeaderText = "Value";
            Column2.MinimumWidth = 6;
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            // 
            // Column5
            // 
            Column5.HeaderText = "Score";
            Column5.MinimumWidth = 6;
            Column5.Name = "Column5";
            Column5.ReadOnly = true;
            // 
            // Column4
            // 
            Column4.HeaderText = "Real Score";
            Column4.MinimumWidth = 6;
            Column4.Name = "Column4";
            Column4.ReadOnly = true;
            // 
            // Column7
            // 
            Column7.HeaderText = "Open on Startup";
            Column7.Name = "Column7";
            // 
            // comboBoxPeriod
            // 
            comboBoxPeriod.Anchor = AnchorStyles.Top;
            comboBoxPeriod.BackColor = Color.White;
            comboBoxPeriod.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxPeriod.ForeColor = Color.Black;
            comboBoxPeriod.FormattingEnabled = true;
            comboBoxPeriod.Location = new Point(500, 74);
            comboBoxPeriod.Margin = new Padding(3, 2, 3, 2);
            comboBoxPeriod.Name = "comboBoxPeriod";
            comboBoxPeriod.Size = new Size(190, 23);
            comboBoxPeriod.TabIndex = 1;
            comboBoxPeriod.SelectedIndexChanged += comboBoxPeriod_SelectedIndexChanged;
            // 
            // comboBoxAsignature
            // 
            comboBoxAsignature.Anchor = AnchorStyles.Top;
            comboBoxAsignature.BackColor = Color.White;
            comboBoxAsignature.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxAsignature.FlatStyle = FlatStyle.System;
            comboBoxAsignature.ForeColor = Color.Black;
            comboBoxAsignature.FormattingEnabled = true;
            comboBoxAsignature.Location = new Point(275, 119);
            comboBoxAsignature.Margin = new Padding(3, 2, 3, 2);
            comboBoxAsignature.Name = "comboBoxAsignature";
            comboBoxAsignature.Size = new Size(414, 23);
            comboBoxAsignature.TabIndex = 2;
            comboBoxAsignature.SelectedIndexChanged += comboBoxAsignature_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.ForeColor = Color.White;
            label1.Location = new Point(500, 56);
            label1.Name = "label1";
            label1.Size = new Size(41, 15);
            label1.TabIndex = 3;
            label1.Text = "Period";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.AutoSize = true;
            label2.ForeColor = Color.White;
            label2.Location = new Point(275, 102);
            label2.Name = "label2";
            label2.Size = new Size(64, 15);
            label2.TabIndex = 4;
            label2.Text = "Asignature";
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Top;
            label8.AutoSize = true;
            label8.ForeColor = Color.White;
            label8.Location = new Point(275, 56);
            label8.Name = "label8";
            label8.Size = new Size(29, 15);
            label8.TabIndex = 37;
            label8.Text = "Year";
            // 
            // dateTimePicker
            // 
            dateTimePicker.Anchor = AnchorStyles.Top;
            dateTimePicker.CalendarForeColor = Color.White;
            dateTimePicker.CalendarMonthBackground = Color.Black;
            dateTimePicker.CustomFormat = "yyyy";
            dateTimePicker.Format = DateTimePickerFormat.Custom;
            dateTimePicker.Location = new Point(275, 74);
            dateTimePicker.Margin = new Padding(3, 2, 3, 2);
            dateTimePicker.Name = "dateTimePicker";
            dateTimePicker.ShowUpDown = true;
            dateTimePicker.Size = new Size(190, 23);
            dateTimePicker.TabIndex = 36;
            dateTimePicker.ValueChanged += dateTimePicker_ValueChanged;
            // 
            // panel2
            // 
            panel2.Controls.Add(label3);
            panel2.Controls.Add(pictureBox1);
            panel2.Location = new Point(66, 2);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(52, 41);
            panel2.TabIndex = 39;
            panel2.MouseDown += panel2_MouseDown;
            panel2.MouseEnter += panel2_MouseEnter;
            panel2.MouseLeave += panel2_MouseLeave;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = Color.White;
            label3.Location = new Point(11, 28);
            label3.Name = "label3";
            label3.Size = new Size(26, 12);
            label3.TabIndex = 1;
            label3.Text = " Add";
            label3.MouseDown += panel2_MouseDown;
            label3.MouseEnter += panel2_MouseEnter;
            label3.MouseLeave += panel2_MouseLeave;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(11, 2);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(30, 26);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.MouseDown += panel2_MouseDown;
            pictureBox1.MouseEnter += panel2_MouseEnter;
            pictureBox1.MouseLeave += panel2_MouseLeave;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            label5.ForeColor = Color.White;
            label5.Location = new Point(10, 7);
            label5.Name = "label5";
            label5.Size = new Size(89, 30);
            label5.TabIndex = 41;
            label5.Text = "Projects";
            // 
            // panel3
            // 
            panel3.Controls.Add(label6);
            panel3.Controls.Add(pictureBox3);
            panel3.Location = new Point(122, 2);
            panel3.Margin = new Padding(3, 2, 3, 2);
            panel3.Name = "panel3";
            panel3.Size = new Size(52, 41);
            panel3.TabIndex = 40;
            panel3.MouseDown += panel3_MouseDown;
            panel3.MouseEnter += panel3_MouseEnter;
            panel3.MouseLeave += panel3_MouseLeave;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            label6.ForeColor = Color.White;
            label6.Location = new Point(11, 28);
            label6.Name = "label6";
            label6.Size = new Size(31, 12);
            label6.TabIndex = 1;
            label6.Text = "Grade";
            label6.MouseDown += panel3_MouseDown;
            label6.MouseEnter += panel3_MouseEnter;
            label6.MouseLeave += panel3_MouseLeave;
            // 
            // pictureBox3
            // 
            pictureBox3.BackgroundImage = (Image)resources.GetObject("pictureBox3.BackgroundImage");
            pictureBox3.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox3.Location = new Point(11, 2);
            pictureBox3.Margin = new Padding(3, 2, 3, 2);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(30, 26);
            pictureBox3.TabIndex = 0;
            pictureBox3.TabStop = false;
            pictureBox3.MouseDown += panel3_MouseDown;
            pictureBox3.MouseEnter += panel3_MouseEnter;
            pictureBox3.MouseLeave += panel3_MouseLeave;
            // 
            // panel4
            // 
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(960, 1);
            panel4.TabIndex = 46;
            // 
            // panel6
            // 
            panel6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel6.Controls.Add(panel5);
            panel6.Controls.Add(panel1);
            panel6.Controls.Add(panel3);
            panel6.Controls.Add(panel2);
            panel6.Location = new Point(840, 7);
            panel6.Margin = new Padding(3, 2, 3, 2);
            panel6.Name = "panel6";
            panel6.Size = new Size(236, 48);
            panel6.TabIndex = 48;
            // 
            // panel5
            // 
            panel5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel5.Controls.Add(labelProject);
            panel5.Controls.Add(pictureBox4);
            panel5.Location = new Point(3, 2);
            panel5.Margin = new Padding(3, 2, 3, 2);
            panel5.Name = "panel5";
            panel5.Size = new Size(61, 41);
            panel5.TabIndex = 49;
            panel5.MouseDown += panel5_MouseDown;
            panel5.MouseEnter += panel5_MouseEnter;
            panel5.MouseLeave += panel5_MouseLeave;
            // 
            // labelProject
            // 
            labelProject.AutoSize = true;
            labelProject.BackColor = Color.Transparent;
            labelProject.Font = new Font("Segoe UI", 6.5F, FontStyle.Regular, GraphicsUnit.Point);
            labelProject.ForeColor = Color.White;
            labelProject.Location = new Point(8, 28);
            labelProject.Name = "labelProject";
            labelProject.Size = new Size(11, 12);
            labelProject.TabIndex = 1;
            labelProject.Text = "A";
            labelProject.TextAlign = ContentAlignment.MiddleCenter;
            labelProject.MouseDown += panel5_MouseDown;
            labelProject.MouseEnter += panel5_MouseEnter;
            labelProject.MouseLeave += panel5_MouseLeave;
            // 
            // pictureBox4
            // 
            pictureBox4.BackgroundImage = (Image)resources.GetObject("pictureBox4.BackgroundImage");
            pictureBox4.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox4.Location = new Point(13, 2);
            pictureBox4.Margin = new Padding(3, 2, 3, 2);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(35, 30);
            pictureBox4.TabIndex = 0;
            pictureBox4.TabStop = false;
            pictureBox4.MouseDown += panel5_MouseDown;
            pictureBox4.MouseEnter += panel5_MouseEnter;
            pictureBox4.MouseLeave += panel5_MouseLeave;
            // 
            // panel1
            // 
            panel1.Controls.Add(label4);
            panel1.Controls.Add(pictureBox2);
            panel1.Location = new Point(178, 2);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(52, 41);
            panel1.TabIndex = 40;
            panel1.MouseDown += panel1_MouseDown;
            panel1.MouseEnter += panel1_MouseEnter;
            panel1.MouseLeave += panel1_MouseLeave;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = Color.White;
            label4.Location = new Point(14, 28);
            label4.Name = "label4";
            label4.Size = new Size(24, 12);
            label4.TabIndex = 1;
            label4.Text = " Edit";
            label4.MouseDown += panel1_MouseDown;
            label4.MouseEnter += panel1_MouseEnter;
            label4.MouseLeave += panel1_MouseLeave;
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImage = (Image)resources.GetObject("pictureBox2.BackgroundImage");
            pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox2.Location = new Point(14, 2);
            pictureBox2.Margin = new Padding(3, 2, 3, 2);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(26, 22);
            pictureBox2.TabIndex = 0;
            pictureBox2.TabStop = false;
            pictureBox2.MouseDown += panel1_MouseDown;
            pictureBox2.MouseEnter += panel1_MouseEnter;
            pictureBox2.MouseLeave += panel1_MouseLeave;
            // 
            // ProjectConsult
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(960, 600);
            Controls.Add(panel6);
            Controls.Add(label8);
            Controls.Add(dateTimePicker);
            Controls.Add(label2);
            Controls.Add(dataGridView);
            Controls.Add(label1);
            Controls.Add(comboBoxAsignature);
            Controls.Add(panel4);
            Controls.Add(comboBoxPeriod);
            Controls.Add(label5);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "ProjectConsult";
            Text = " ";
            Click += ProjectScoreConsult_Click;
            MouseEnter += ProjectConsult_MouseEnter;
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            panel6.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView;
        private ComboBox comboBoxPeriod;
        private ComboBox comboBoxAsignature;
        private Label label1;
        private Label label2;
        private Label label8;
        private DateTimePicker dateTimePicker;
        private Panel panel2;
        private Label label3;
        private PictureBox pictureBox1;
        private Label label5;
        private Panel panel3;
        private Label label6;
        private PictureBox pictureBox3;
        private Panel panel4;
        private Panel panel6;
        private Panel panel5;
        private Label labelProject;
        private PictureBox pictureBox4;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewCheckBoxColumn Column7;
        private Panel panel1;
        private Label label4;
        private PictureBox pictureBox2;
    }
}