namespace Dysfunction.GUI.Consult
{
    partial class PeriodConsult
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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PeriodConsult));
            dataGridView = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewTextBoxColumn();
            Column10 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column7 = new DataGridViewTextBoxColumn();
            Column8 = new DataGridViewTextBoxColumn();
            Column9 = new DataGridViewTextBoxColumn();
            label8 = new Label();
            dateTimePicker = new DateTimePicker();
            label1 = new Label();
            comboBoxPeriod = new ComboBox();
            label5 = new Label();
            panel1 = new Panel();
            label4 = new Label();
            pictureBox2 = new PictureBox();
            panel2 = new Panel();
            label3 = new Label();
            pictureBox1 = new PictureBox();
            panel3 = new Panel();
            panel4 = new Panel();
            panel5 = new Panel();
            labelPeriodButton = new Label();
            pictureBox4 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            SuspendLayout();
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.BackgroundColor = Color.Black;
            dataGridView.BorderStyle = BorderStyle.None;
            dataGridView.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.Black;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { Column1, Column6, Column10, Column3, Column2, Column5, Column4, Column7, Column8, Column9 });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dataGridView.DefaultCellStyle = dataGridViewCellStyle3;
            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.GridColor = Color.FromArgb(20, 20, 20);
            dataGridView.Location = new Point(11, 126);
            dataGridView.Margin = new Padding(3, 2, 3, 2);
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.Black;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = Color.White;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridView.RowHeadersVisible = false;
            dataGridView.RowHeadersWidth = 102;
            dataGridView.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dataGridView.ShowCellToolTips = false;
            dataGridView.Size = new Size(940, 463);
            dataGridView.TabIndex = 5;
            dataGridView.CellContentClick += dataGridView_CellContentClick;
            dataGridView.CellMouseClick += dataGridView_CellMouseClick;
            dataGridView.SelectionChanged += dataGridView_SelectionChanged;
            dataGridView.MouseDown += dataGridView_MouseDown;
            // 
            // Column1
            // 
            Column1.FillWeight = 60F;
            Column1.HeaderText = "Year";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            // 
            // Column6
            // 
            Column6.FillWeight = 80F;
            Column6.HeaderText = "Period";
            Column6.MinimumWidth = 6;
            Column6.Name = "Column6";
            Column6.ReadOnly = true;
            // 
            // Column10
            // 
            Column10.FillWeight = 70F;
            Column10.HeaderText = "Code";
            Column10.MinimumWidth = 6;
            Column10.Name = "Column10";
            Column10.ReadOnly = true;
            // 
            // Column3
            // 
            Column3.FillWeight = 200F;
            Column3.HeaderText = "Asignature";
            Column3.MinimumWidth = 6;
            Column3.Name = "Column3";
            Column3.ReadOnly = true;
            // 
            // Column2
            // 
            Column2.FillWeight = 175F;
            Column2.HeaderText = "Teacher";
            Column2.MinimumWidth = 6;
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            // 
            // Column5
            // 
            Column5.FillWeight = 50F;
            Column5.HeaderText = "Group";
            Column5.MinimumWidth = 6;
            Column5.Name = "Column5";
            Column5.ReadOnly = true;
            // 
            // Column4
            // 
            Column4.FillWeight = 50F;
            Column4.HeaderText = "Score";
            Column4.MinimumWidth = 6;
            Column4.Name = "Column4";
            Column4.ReadOnly = true;
            // 
            // Column7
            // 
            Column7.FillWeight = 50F;
            Column7.HeaderText = "State";
            Column7.MinimumWidth = 6;
            Column7.Name = "Column7";
            Column7.ReadOnly = true;
            // 
            // Column8
            // 
            Column8.FillWeight = 90F;
            Column8.HeaderText = "Orientation";
            Column8.MinimumWidth = 6;
            Column8.Name = "Column8";
            Column8.ReadOnly = true;
            // 
            // Column9
            // 
            Column9.FillWeight = 90F;
            Column9.HeaderText = "Material";
            Column9.MinimumWidth = 6;
            Column9.Name = "Column9";
            Column9.ReadOnly = true;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Top;
            label8.AutoSize = true;
            label8.ForeColor = Color.White;
            label8.Location = new Point(271, 63);
            label8.Name = "label8";
            label8.Size = new Size(29, 15);
            label8.TabIndex = 41;
            label8.Text = "Year";
            // 
            // dateTimePicker
            // 
            dateTimePicker.Anchor = AnchorStyles.Top;
            dateTimePicker.CalendarForeColor = Color.White;
            dateTimePicker.CalendarMonthBackground = Color.Black;
            dateTimePicker.CalendarTitleBackColor = SystemColors.AppWorkspace;
            dateTimePicker.CalendarTitleForeColor = Color.White;
            dateTimePicker.CustomFormat = "yyyy";
            dateTimePicker.Format = DateTimePickerFormat.Custom;
            dateTimePicker.Location = new Point(271, 80);
            dateTimePicker.Margin = new Padding(3, 2, 3, 2);
            dateTimePicker.Name = "dateTimePicker";
            dateTimePicker.ShowUpDown = true;
            dateTimePicker.Size = new Size(190, 23);
            dateTimePicker.TabIndex = 40;
            dateTimePicker.ValueChanged += dateTimePicker_ValueChanged;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.ForeColor = Color.White;
            label1.Location = new Point(506, 63);
            label1.Name = "label1";
            label1.Size = new Size(41, 15);
            label1.TabIndex = 39;
            label1.Text = "Period";
            // 
            // comboBoxPeriod
            // 
            comboBoxPeriod.Anchor = AnchorStyles.Top;
            comboBoxPeriod.BackColor = Color.White;
            comboBoxPeriod.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxPeriod.ForeColor = Color.Black;
            comboBoxPeriod.FormattingEnabled = true;
            comboBoxPeriod.Location = new Point(506, 80);
            comboBoxPeriod.Margin = new Padding(3, 2, 3, 2);
            comboBoxPeriod.Name = "comboBoxPeriod";
            comboBoxPeriod.Size = new Size(190, 23);
            comboBoxPeriod.TabIndex = 38;
            comboBoxPeriod.SelectedIndexChanged += comboBoxPeriod_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            label5.ForeColor = Color.White;
            label5.Location = new Point(10, 7);
            label5.Name = "label5";
            label5.Size = new Size(84, 30);
            label5.TabIndex = 42;
            label5.Text = "Periods";
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel1.Controls.Add(label4);
            panel1.Controls.Add(pictureBox2);
            panel1.Location = new Point(129, 2);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(52, 41);
            panel1.TabIndex = 44;
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
            label4.Location = new Point(8, 28);
            label4.Name = "label4";
            label4.Size = new Size(27, 12);
            label4.TabIndex = 1;
            label4.Text = "  Edit";
            label4.MouseDown += panel1_MouseDown;
            label4.MouseEnter += panel1_MouseEnter;
            label4.MouseLeave += panel1_MouseLeave;
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImage = (Image)resources.GetObject("pictureBox2.BackgroundImage");
            pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox2.Location = new Point(12, 2);
            pictureBox2.Margin = new Padding(3, 2, 3, 2);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(26, 22);
            pictureBox2.TabIndex = 0;
            pictureBox2.TabStop = false;
            pictureBox2.MouseDown += panel1_MouseDown;
            pictureBox2.MouseEnter += panel1_MouseEnter;
            pictureBox2.MouseLeave += panel1_MouseLeave;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel2.Controls.Add(label3);
            panel2.Controls.Add(pictureBox1);
            panel2.Location = new Point(73, 2);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(52, 41);
            panel2.TabIndex = 43;
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
            label3.Location = new Point(12, 28);
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
            pictureBox1.Location = new Point(12, 2);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(30, 26);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.MouseDown += panel2_MouseDown;
            pictureBox1.MouseEnter += panel2_MouseEnter;
            pictureBox1.MouseLeave += panel2_MouseLeave;
            // 
            // panel3
            // 
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(960, 1);
            panel3.TabIndex = 45;
            // 
            // panel4
            // 
            panel4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel4.Controls.Add(panel5);
            panel4.Controls.Add(panel1);
            panel4.Controls.Add(panel2);
            panel4.Location = new Point(761, 9);
            panel4.Margin = new Padding(3, 2, 3, 2);
            panel4.Name = "panel4";
            panel4.Size = new Size(188, 49);
            panel4.TabIndex = 46;
            // 
            // panel5
            // 
            panel5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel5.Controls.Add(labelPeriodButton);
            panel5.Controls.Add(pictureBox4);
            panel5.Location = new Point(6, 2);
            panel5.Margin = new Padding(3, 2, 3, 2);
            panel5.Name = "panel5";
            panel5.Size = new Size(61, 41);
            panel5.TabIndex = 50;
            panel5.MouseDown += panel5_MouseDown;
            panel5.MouseEnter += panel5_MouseEnter;
            panel5.MouseLeave += panel5_MouseLeave;
            // 
            // labelPeriodButton
            // 
            labelPeriodButton.AutoSize = true;
            labelPeriodButton.BackColor = Color.Transparent;
            labelPeriodButton.Font = new Font("Segoe UI", 6.5F, FontStyle.Regular, GraphicsUnit.Point);
            labelPeriodButton.ForeColor = Color.White;
            labelPeriodButton.Location = new Point(11, 28);
            labelPeriodButton.Name = "labelPeriodButton";
            labelPeriodButton.Size = new Size(43, 12);
            labelPeriodButton.TabIndex = 1;
            labelPeriodButton.Text = "University";
            labelPeriodButton.TextAlign = ContentAlignment.MiddleCenter;
            labelPeriodButton.MouseDown += panel5_MouseDown;
            labelPeriodButton.MouseEnter += panel5_MouseEnter;
            labelPeriodButton.MouseLeave += panel5_MouseLeave;
            // 
            // pictureBox4
            // 
            pictureBox4.BackgroundImage = (Image)resources.GetObject("pictureBox4.BackgroundImage");
            pictureBox4.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox4.Location = new Point(11, 2);
            pictureBox4.Margin = new Padding(3, 2, 3, 2);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(40, 30);
            pictureBox4.TabIndex = 0;
            pictureBox4.TabStop = false;
            pictureBox4.MouseDown += panel5_MouseDown;
            pictureBox4.MouseEnter += panel5_MouseEnter;
            pictureBox4.MouseLeave += panel5_MouseLeave;
            // 
            // PeriodConsult
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(960, 600);
            Controls.Add(dataGridView);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(label8);
            Controls.Add(dateTimePicker);
            Controls.Add(label1);
            Controls.Add(comboBoxPeriod);
            Controls.Add(label5);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "PeriodConsult";
            Text = "PeriodConsult";
            Click += PeriodConsult_Click;
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel4.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView dataGridView;
        private Label label8;
        private DateTimePicker dateTimePicker;
        private Label label1;
        private ComboBox comboBoxPeriod;
        private Label label5;
        private Panel panel1;
        private Label label4;
        private PictureBox pictureBox2;
        private Panel panel2;
        private Label label3;
        private PictureBox pictureBox1;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private Label labelPeriodButton;
        private PictureBox pictureBox4;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn Column10;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column7;
        private DataGridViewTextBoxColumn Column8;
        private DataGridViewTextBoxColumn Column9;
    }
}