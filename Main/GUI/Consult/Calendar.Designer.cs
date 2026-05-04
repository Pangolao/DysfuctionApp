namespace Dysfunction.GUI.Consult
{
    partial class Calendar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Calendar));
            monthCalendar = new MonthCalendar();
            listBoxWeek = new ListBox();
            listBoxDay = new ListBox();
            panel2 = new Panel();
            label4 = new Label();
            pictureBox2 = new PictureBox();
            panel3 = new Panel();
            label3 = new Label();
            pictureBox1 = new PictureBox();
            label5 = new Label();
            panel4 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel4.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // monthCalendar
            // 
            monthCalendar.AccessibleDescription = "";
            monthCalendar.Anchor = AnchorStyles.Top;
            monthCalendar.BackColor = Color.FromArgb(50, 50, 50);
            monthCalendar.Cursor = Cursors.Hand;
            monthCalendar.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            monthCalendar.ForeColor = Color.White;
            monthCalendar.Location = new Point(377, 11);
            monthCalendar.Margin = new Padding(8, 7, 8, 7);
            monthCalendar.MaxDate = new DateTime(2069, 9, 17, 0, 0, 0, 0);
            monthCalendar.MaxSelectionCount = 1;
            monthCalendar.MinDate = new DateTime(1971, 12, 19, 0, 0, 0, 0);
            monthCalendar.Name = "monthCalendar";
            monthCalendar.TabIndex = 0;
            monthCalendar.TitleBackColor = Color.White;
            monthCalendar.TrailingForeColor = Color.Gray;
            monthCalendar.DateChanged += monthCalendar_DateChanged;
            // 
            // listBoxWeek
            // 
            listBoxWeek.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listBoxWeek.BackColor = Color.Black;
            listBoxWeek.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            listBoxWeek.ForeColor = Color.White;
            listBoxWeek.FormattingEnabled = true;
            listBoxWeek.ItemHeight = 18;
            listBoxWeek.Location = new Point(3, 2);
            listBoxWeek.Margin = new Padding(3, 2, 3, 2);
            listBoxWeek.Name = "listBoxWeek";
            listBoxWeek.Size = new Size(399, 400);
            listBoxWeek.TabIndex = 1;
            // 
            // listBoxDay
            // 
            listBoxDay.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listBoxDay.BackColor = Color.Black;
            listBoxDay.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            listBoxDay.ForeColor = Color.White;
            listBoxDay.FormattingEnabled = true;
            listBoxDay.ItemHeight = 18;
            listBoxDay.Location = new Point(408, 2);
            listBoxDay.Margin = new Padding(3, 2, 3, 2);
            listBoxDay.Name = "listBoxDay";
            listBoxDay.Size = new Size(379, 400);
            listBoxDay.TabIndex = 2;
            // 
            // panel2
            // 
            panel2.Controls.Add(label4);
            panel2.Controls.Add(pictureBox2);
            panel2.Location = new Point(59, 12);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(52, 41);
            panel2.TabIndex = 42;
            panel2.MouseDown += panel2_MouseDown;
            panel2.MouseEnter += panel2_MouseEnter;
            panel2.MouseLeave += panel2_MouseLeave;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = Color.White;
            label4.Location = new Point(1, 28);
            label4.Name = "label4";
            label4.Size = new Size(48, 12);
            label4.TabIndex = 1;
            label4.Text = "Edit Event";
            label4.MouseDown += panel2_MouseDown;
            label4.MouseEnter += panel2_MouseEnter;
            label4.MouseLeave += panel2_MouseLeave;
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
            pictureBox2.MouseDown += panel2_MouseDown;
            pictureBox2.MouseEnter += panel2_MouseEnter;
            pictureBox2.MouseLeave += panel2_MouseLeave;
            // 
            // panel3
            // 
            panel3.Controls.Add(label3);
            panel3.Controls.Add(pictureBox1);
            panel3.Location = new Point(3, 12);
            panel3.Margin = new Padding(3, 2, 3, 2);
            panel3.Name = "panel3";
            panel3.Size = new Size(52, 41);
            panel3.TabIndex = 41;
            panel3.MouseDown += panel3_MouseDown;
            panel3.MouseEnter += panel3_MouseEnter;
            panel3.MouseLeave += panel3_MouseLeave;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = Color.White;
            label3.Location = new Point(0, 28);
            label3.Name = "label3";
            label3.Size = new Size(50, 12);
            label3.TabIndex = 1;
            label3.Text = "Add Event";
            label3.MouseDown += panel3_MouseDown;
            label3.MouseEnter += panel3_MouseEnter;
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
            pictureBox1.MouseDown += panel3_MouseDown;
            pictureBox1.MouseEnter += panel3_MouseEnter;
            pictureBox1.MouseLeave += panel3_MouseLeave;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            label5.ForeColor = Color.White;
            label5.Location = new Point(10, 7);
            label5.Name = "label5";
            label5.Size = new Size(99, 30);
            label5.TabIndex = 43;
            label5.Text = "Calendar";
            // 
            // panel4
            // 
            panel4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel4.Controls.Add(panel2);
            panel4.Controls.Add(panel3);
            panel4.Location = new Point(838, -1);
            panel4.Margin = new Padding(3, 2, 3, 2);
            panel4.Name = "panel4";
            panel4.Size = new Size(119, 62);
            panel4.TabIndex = 44;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            tableLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 385F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 18F));
            tableLayoutPanel1.Controls.Add(listBoxDay, 1, 0);
            tableLayoutPanel1.Controls.Add(listBoxWeek, 0, 0);
            tableLayoutPanel1.Location = new Point(87, 185);
            tableLayoutPanel1.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 15F));
            tableLayoutPanel1.Size = new Size(790, 405);
            tableLayoutPanel1.TabIndex = 45;
            // 
            // Calendar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(960, 600);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(monthCalendar);
            Controls.Add(panel4);
            Controls.Add(label5);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "Calendar";
            Text = "Calendar";
            MouseDown += Calendar_MouseDown;
            MouseEnter += ProjectConsult_MouseEnter;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel4.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MonthCalendar monthCalendar;
        private ListBox listBoxWeek;
        private ListBox listBoxDay;
        private Panel panel2;
        private Label label4;
        private PictureBox pictureBox2;
        private Panel panel3;
        private Label label3;
        private PictureBox pictureBox1;
        private Label label5;
        private Panel panel4;
        private TableLayoutPanel tableLayoutPanel1;
    }
}