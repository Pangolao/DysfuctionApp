namespace Dysfunction.GUI.Register
{
    partial class EventsEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EventsEdit));
            panel2 = new Panel();
            label5 = new Label();
            pictureBox1 = new PictureBox();
            label6 = new Label();
            labelName = new Label();
            label3 = new Label();
            dateTimePickerStartDate = new DateTimePicker();
            label2 = new Label();
            checkBoxEndDate = new CheckBox();
            textBoxDescription = new TextBox();
            panel1 = new Panel();
            panel7 = new Panel();
            buttonDelete = new Button();
            panel6 = new Panel();
            panel8 = new Panel();
            buttonEdit = new Button();
            panel5 = new Panel();
            panel3 = new Panel();
            dateTimePickerEndDate = new DateTimePicker();
            label4 = new Label();
            panel4 = new Panel();
            dateTimePickerHour = new DateTimePicker();
            label1 = new Label();
            checkBoxHour = new CheckBox();
            comboBoxName = new ComboBox();
            panel9 = new Panel();
            label7 = new Label();
            panel10 = new Panel();
            panel11 = new Panel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            panel7.SuspendLayout();
            panel8.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel9.SuspendLayout();
            panel11.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(960, 1);
            panel2.TabIndex = 31;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            label5.ForeColor = Color.White;
            label5.Location = new Point(10, 7);
            label5.Name = "label5";
            label5.Size = new Size(108, 30);
            label5.TabIndex = 46;
            label5.Text = "Edit Event";
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(10, 41);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(38, 32);
            pictureBox1.TabIndex = 45;
            pictureBox1.TabStop = false;
            pictureBox1.MouseDown += pictureBox1_MouseDown;
            pictureBox1.MouseEnter += pictureBox1_MouseEnter;
            pictureBox1.MouseLeave += pictureBox1_MouseLeave;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top;
            label6.AutoSize = true;
            label6.ForeColor = Color.White;
            label6.Location = new Point(30, 68);
            label6.Name = "label6";
            label6.Size = new Size(67, 15);
            label6.TabIndex = 19;
            label6.Text = "Description";
            // 
            // labelName
            // 
            labelName.Anchor = AnchorStyles.Top;
            labelName.AutoSize = true;
            labelName.BackColor = Color.Black;
            labelName.Font = new Font("Arial Narrow", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            labelName.ForeColor = Color.White;
            labelName.Location = new Point(7, 44);
            labelName.Name = "labelName";
            labelName.Size = new Size(14, 23);
            labelName.TabIndex = 20;
            labelName.Text = "!";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top;
            label3.AutoSize = true;
            label3.ForeColor = Color.White;
            label3.Location = new Point(30, 107);
            label3.Name = "label3";
            label3.Size = new Size(58, 15);
            label3.TabIndex = 5;
            label3.Text = "Start Date";
            // 
            // dateTimePickerStartDate
            // 
            dateTimePickerStartDate.Anchor = AnchorStyles.Top;
            dateTimePickerStartDate.Enabled = false;
            dateTimePickerStartDate.Format = DateTimePickerFormat.Short;
            dateTimePickerStartDate.Location = new Point(27, 123);
            dateTimePickerStartDate.Margin = new Padding(3, 2, 3, 2);
            dateTimePickerStartDate.Name = "dateTimePickerStartDate";
            dateTimePickerStartDate.Size = new Size(414, 23);
            dateTimePickerStartDate.TabIndex = 25;
            dateTimePickerStartDate.ValueChanged += dateTimePickerStarDate_ValueChanged;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.AutoSize = true;
            label2.ForeColor = Color.White;
            label2.Location = new Point(30, 27);
            label2.Name = "label2";
            label2.Size = new Size(39, 15);
            label2.TabIndex = 3;
            label2.Text = "Name";
            // 
            // checkBoxEndDate
            // 
            checkBoxEndDate.Anchor = AnchorStyles.Top;
            checkBoxEndDate.AutoSize = true;
            checkBoxEndDate.Font = new Font("Arial", 9.4F, FontStyle.Bold, GraphicsUnit.Point);
            checkBoxEndDate.ForeColor = Color.White;
            checkBoxEndDate.Location = new Point(160, 170);
            checkBoxEndDate.Margin = new Padding(3, 2, 3, 2);
            checkBoxEndDate.Name = "checkBoxEndDate";
            checkBoxEndDate.Size = new Size(140, 20);
            checkBoxEndDate.TabIndex = 26;
            checkBoxEndDate.Text = "Need an End Date";
            checkBoxEndDate.UseVisualStyleBackColor = true;
            checkBoxEndDate.CheckedChanged += checkBox_CheckedChanged;
            // 
            // textBoxDescription
            // 
            textBoxDescription.Anchor = AnchorStyles.Top;
            textBoxDescription.BackColor = Color.Black;
            textBoxDescription.Enabled = false;
            textBoxDescription.ForeColor = Color.White;
            textBoxDescription.Location = new Point(27, 85);
            textBoxDescription.Margin = new Padding(3, 2, 3, 2);
            textBoxDescription.Name = "textBoxDescription";
            textBoxDescription.Size = new Size(414, 23);
            textBoxDescription.TabIndex = 2;
            textBoxDescription.Click += textBoxDescription_Click;
            textBoxDescription.TextChanged += textBoxDescription_TextChanged;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top;
            panel1.Controls.Add(panel7);
            panel1.Controls.Add(panel6);
            panel1.Controls.Add(panel8);
            panel1.Controls.Add(panel5);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel4);
            panel1.Location = new Point(27, 184);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(413, 170);
            panel1.TabIndex = 28;
            // 
            // panel7
            // 
            panel7.Controls.Add(buttonDelete);
            panel7.Dock = DockStyle.Top;
            panel7.Location = new Point(0, 137);
            panel7.Margin = new Padding(3, 2, 3, 2);
            panel7.Name = "panel7";
            panel7.Size = new Size(413, 27);
            panel7.TabIndex = 33;
            // 
            // buttonDelete
            // 
            buttonDelete.BackColor = Color.Black;
            buttonDelete.FlatAppearance.BorderColor = Color.FromArgb(64, 64, 64);
            buttonDelete.FlatAppearance.MouseDownBackColor = Color.FromArgb(20, 20, 20);
            buttonDelete.FlatAppearance.MouseOverBackColor = Color.FromArgb(20, 20, 20);
            buttonDelete.FlatStyle = FlatStyle.Flat;
            buttonDelete.ForeColor = SystemColors.Control;
            buttonDelete.Location = new Point(113, 0);
            buttonDelete.Margin = new Padding(3, 2, 3, 2);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(195, 24);
            buttonDelete.TabIndex = 31;
            buttonDelete.Text = "Delete";
            buttonDelete.UseVisualStyleBackColor = false;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // panel6
            // 
            panel6.Dock = DockStyle.Top;
            panel6.Location = new Point(0, 124);
            panel6.Margin = new Padding(3, 2, 3, 2);
            panel6.Name = "panel6";
            panel6.Size = new Size(413, 13);
            panel6.TabIndex = 32;
            // 
            // panel8
            // 
            panel8.Controls.Add(buttonEdit);
            panel8.Dock = DockStyle.Top;
            panel8.Location = new Point(0, 97);
            panel8.Margin = new Padding(3, 2, 3, 2);
            panel8.Name = "panel8";
            panel8.Size = new Size(413, 27);
            panel8.TabIndex = 34;
            // 
            // buttonEdit
            // 
            buttonEdit.FlatAppearance.BorderColor = Color.FromArgb(64, 64, 64);
            buttonEdit.FlatAppearance.MouseDownBackColor = Color.FromArgb(20, 20, 20);
            buttonEdit.FlatAppearance.MouseOverBackColor = Color.FromArgb(20, 20, 20);
            buttonEdit.FlatStyle = FlatStyle.Flat;
            buttonEdit.ForeColor = Color.White;
            buttonEdit.Location = new Point(113, 1);
            buttonEdit.Margin = new Padding(3, 2, 3, 2);
            buttonEdit.Name = "buttonEdit";
            buttonEdit.Size = new Size(195, 24);
            buttonEdit.TabIndex = 9;
            buttonEdit.Text = "Save Edit";
            buttonEdit.UseVisualStyleBackColor = true;
            buttonEdit.Click += buttonSave_Click;
            // 
            // panel5
            // 
            panel5.Dock = DockStyle.Top;
            panel5.Location = new Point(0, 83);
            panel5.Margin = new Padding(3, 2, 3, 2);
            panel5.Name = "panel5";
            panel5.Size = new Size(413, 14);
            panel5.TabIndex = 30;
            // 
            // panel3
            // 
            panel3.Controls.Add(dateTimePickerEndDate);
            panel3.Controls.Add(label4);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 43);
            panel3.Margin = new Padding(3, 2, 3, 2);
            panel3.Name = "panel3";
            panel3.Size = new Size(413, 40);
            panel3.TabIndex = 28;
            // 
            // dateTimePickerEndDate
            // 
            dateTimePickerEndDate.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dateTimePickerEndDate.Enabled = false;
            dateTimePickerEndDate.Format = DateTimePickerFormat.Short;
            dateTimePickerEndDate.Location = new Point(0, 17);
            dateTimePickerEndDate.Margin = new Padding(3, 2, 3, 2);
            dateTimePickerEndDate.Name = "dateTimePickerEndDate";
            dateTimePickerEndDate.Size = new Size(414, 23);
            dateTimePickerEndDate.TabIndex = 27;
            dateTimePickerEndDate.ValueChanged += dateTimePickerEndDate_ValueChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.White;
            label4.Location = new Point(3, 0);
            label4.Name = "label4";
            label4.Size = new Size(54, 15);
            label4.TabIndex = 12;
            label4.Text = "End Date";
            // 
            // panel4
            // 
            panel4.Controls.Add(dateTimePickerHour);
            panel4.Controls.Add(label1);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 0);
            panel4.Margin = new Padding(3, 2, 3, 2);
            panel4.Name = "panel4";
            panel4.Size = new Size(413, 43);
            panel4.TabIndex = 29;
            // 
            // dateTimePickerHour
            // 
            dateTimePickerHour.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dateTimePickerHour.CustomFormat = "HH:mm";
            dateTimePickerHour.Enabled = false;
            dateTimePickerHour.Format = DateTimePickerFormat.Custom;
            dateTimePickerHour.Location = new Point(0, 17);
            dateTimePickerHour.Margin = new Padding(3, 2, 3, 2);
            dateTimePickerHour.Name = "dateTimePickerHour";
            dateTimePickerHour.Size = new Size(414, 23);
            dateTimePickerHour.TabIndex = 29;
            dateTimePickerHour.ValueChanged += dateTimePickerHour_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.White;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(34, 15);
            label1.TabIndex = 28;
            label1.Text = "Hour";
            // 
            // checkBoxHour
            // 
            checkBoxHour.Anchor = AnchorStyles.Top;
            checkBoxHour.AutoSize = true;
            checkBoxHour.Font = new Font("Arial", 9.4F, FontStyle.Bold, GraphicsUnit.Point);
            checkBoxHour.ForeColor = Color.White;
            checkBoxHour.Location = new Point(174, 148);
            checkBoxHour.Margin = new Padding(3, 2, 3, 2);
            checkBoxHour.Name = "checkBoxHour";
            checkBoxHour.Size = new Size(113, 20);
            checkBoxHour.TabIndex = 29;
            checkBoxHour.Text = "Need an Hour";
            checkBoxHour.UseVisualStyleBackColor = true;
            checkBoxHour.CheckedChanged += checkBoxHour_CheckedChanged;
            // 
            // comboBoxName
            // 
            comboBoxName.Anchor = AnchorStyles.Top;
            comboBoxName.BackColor = Color.Black;
            comboBoxName.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxName.ForeColor = Color.White;
            comboBoxName.FormattingEnabled = true;
            comboBoxName.Location = new Point(27, 44);
            comboBoxName.Margin = new Padding(3, 2, 3, 2);
            comboBoxName.Name = "comboBoxName";
            comboBoxName.Size = new Size(414, 23);
            comboBoxName.TabIndex = 30;
            comboBoxName.SelectedIndexChanged += comboBoxName_SelectedIndexChanged;
            // 
            // panel9
            // 
            panel9.BorderStyle = BorderStyle.FixedSingle;
            panel9.Controls.Add(comboBoxName);
            panel9.Controls.Add(checkBoxHour);
            panel9.Controls.Add(panel1);
            panel9.Controls.Add(textBoxDescription);
            panel9.Controls.Add(checkBoxEndDate);
            panel9.Controls.Add(label2);
            panel9.Controls.Add(label6);
            panel9.Controls.Add(dateTimePickerStartDate);
            panel9.Controls.Add(labelName);
            panel9.Controls.Add(label3);
            panel9.Location = new Point(1, 27);
            panel9.Margin = new Padding(3, 2, 3, 2);
            panel9.Name = "panel9";
            panel9.Size = new Size(463, 369);
            panel9.TabIndex = 47;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            label7.ForeColor = Color.White;
            label7.Location = new Point(29, 10);
            label7.Name = "label7";
            label7.Size = new Size(159, 25);
            label7.TabIndex = 46;
            label7.Text = " Event Information";
            // 
            // panel10
            // 
            panel10.Dock = DockStyle.Bottom;
            panel10.Location = new Point(0, 592);
            panel10.Name = "panel10";
            panel10.Size = new Size(960, 8);
            panel10.TabIndex = 48;
            // 
            // panel11
            // 
            panel11.Controls.Add(label7);
            panel11.Controls.Add(panel9);
            panel11.Location = new Point(247, 56);
            panel11.Name = "panel11";
            panel11.Size = new Size(467, 402);
            panel11.TabIndex = 49;
            // 
            // EventsEdit
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(960, 600);
            Controls.Add(panel10);
            Controls.Add(label5);
            Controls.Add(pictureBox1);
            Controls.Add(panel2);
            Controls.Add(panel11);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "EventsEdit";
            Text = "EventsRegister";
            MouseEnter += ProjectRegister_MouseEnter;
            Resize += EventsEdit_Resize;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel7.ResumeLayout(false);
            panel8.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel9.ResumeLayout(false);
            panel9.PerformLayout();
            panel11.ResumeLayout(false);
            panel11.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox textBoxGroup;
        private Label labelGroup;
        private Panel panel2;
        private Label label5;
        private PictureBox pictureBox1;
        private Label label6;
        private Label labelName;
        private Label label3;
        private DateTimePicker dateTimePickerStartDate;
        private Label label2;
        private CheckBox checkBoxEndDate;
        private TextBox textBoxDescription;
        private Panel panel1;
        private Panel panel7;
        private Button buttonEdit;
        private Panel panel6;
        private Panel panel8;
        private Button buttonDelete;
        private Panel panel5;
        private Panel panel3;
        private DateTimePicker dateTimePickerEndDate;
        private Label label4;
        private Panel panel4;
        private DateTimePicker dateTimePickerHour;
        private Label label1;
        private CheckBox checkBoxHour;
        private ComboBox comboBoxName;
        private Panel panel9;
        private Label label7;
        private Panel panel10;
        private Panel panel11;
    }
}