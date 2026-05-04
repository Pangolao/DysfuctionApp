namespace Dysfunction.GUI.Register
{
    partial class EventsRegister
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EventsRegister));
            textBoxDescription = new TextBox();
            label2 = new Label();
            label3 = new Label();
            buttonSave = new Button();
            label4 = new Label();
            textBoxName = new TextBox();
            label6 = new Label();
            labelName = new Label();
            checkBoxHour = new CheckBox();
            panel1 = new Panel();
            panel6 = new Panel();
            panel5 = new Panel();
            panel3 = new Panel();
            dateTimePickerEndDate = new DateTimePicker();
            panel4 = new Panel();
            dateTimePickerHour = new DateTimePicker();
            label1 = new Label();
            checkBoxEndDate = new CheckBox();
            dateTimePickerStartDate = new DateTimePicker();
            panel2 = new Panel();
            pictureBox1 = new PictureBox();
            label5 = new Label();
            label7 = new Label();
            panel7 = new Panel();
            panel8 = new Panel();
            panel9 = new Panel();
            panel1.SuspendLayout();
            panel6.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel7.SuspendLayout();
            panel8.SuspendLayout();
            SuspendLayout();
            // 
            // textBoxDescription
            // 
            textBoxDescription.Anchor = AnchorStyles.Top;
            textBoxDescription.BackColor = Color.Black;
            textBoxDescription.BorderStyle = BorderStyle.FixedSingle;
            textBoxDescription.ForeColor = Color.White;
            textBoxDescription.Location = new Point(28, 82);
            textBoxDescription.Margin = new Padding(3, 2, 3, 2);
            textBoxDescription.Name = "textBoxDescription";
            textBoxDescription.PlaceholderText = "Yeah, a description";
            textBoxDescription.Size = new Size(413, 23);
            textBoxDescription.TabIndex = 2;
            textBoxDescription.Click += textBoxDescription_Click;
            textBoxDescription.TextChanged += textBoxDescription_TextChanged;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.AutoSize = true;
            label2.ForeColor = Color.White;
            label2.Location = new Point(28, 23);
            label2.Name = "label2";
            label2.Size = new Size(39, 15);
            label2.TabIndex = 3;
            label2.Text = "Name";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top;
            label3.AutoSize = true;
            label3.ForeColor = Color.White;
            label3.Location = new Point(28, 110);
            label3.Name = "label3";
            label3.Size = new Size(58, 15);
            label3.TabIndex = 5;
            label3.Text = "Start Date";
            // 
            // buttonSave
            // 
            buttonSave.FlatAppearance.BorderColor = Color.FromArgb(64, 64, 64);
            buttonSave.FlatAppearance.MouseDownBackColor = Color.FromArgb(20, 20, 20);
            buttonSave.FlatAppearance.MouseOverBackColor = Color.FromArgb(20, 20, 20);
            buttonSave.FlatStyle = FlatStyle.Flat;
            buttonSave.ForeColor = Color.White;
            buttonSave.Location = new Point(109, 0);
            buttonSave.Margin = new Padding(3, 2, 3, 2);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(195, 24);
            buttonSave.TabIndex = 9;
            buttonSave.Text = "Save";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
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
            // textBoxName
            // 
            textBoxName.Anchor = AnchorStyles.Top;
            textBoxName.BackColor = Color.Black;
            textBoxName.BorderStyle = BorderStyle.FixedSingle;
            textBoxName.ForeColor = Color.White;
            textBoxName.Location = new Point(28, 40);
            textBoxName.Margin = new Padding(3, 2, 3, 2);
            textBoxName.Name = "textBoxName";
            textBoxName.PlaceholderText = "Give it a name";
            textBoxName.Size = new Size(413, 23);
            textBoxName.TabIndex = 18;
            textBoxName.Click += textBoxName_Click;
            textBoxName.TextChanged += textBoxName_TextChanged;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top;
            label6.AutoSize = true;
            label6.ForeColor = Color.White;
            label6.Location = new Point(28, 64);
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
            labelName.Location = new Point(8, 40);
            labelName.Name = "labelName";
            labelName.Size = new Size(14, 23);
            labelName.TabIndex = 20;
            labelName.Text = "!";
            // 
            // checkBoxHour
            // 
            checkBoxHour.Anchor = AnchorStyles.Top;
            checkBoxHour.AutoSize = true;
            checkBoxHour.Font = new Font("Arial", 9.4F, FontStyle.Bold, GraphicsUnit.Point);
            checkBoxHour.ForeColor = Color.White;
            checkBoxHour.Location = new Point(175, 152);
            checkBoxHour.Margin = new Padding(3, 2, 3, 2);
            checkBoxHour.Name = "checkBoxHour";
            checkBoxHour.Size = new Size(113, 20);
            checkBoxHour.TabIndex = 29;
            checkBoxHour.Text = "Need an Hour";
            checkBoxHour.UseVisualStyleBackColor = true;
            checkBoxHour.CheckedChanged += checkBoxHour_CheckedChanged;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top;
            panel1.Controls.Add(panel6);
            panel1.Controls.Add(panel5);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel4);
            panel1.Location = new Point(28, 195);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(413, 118);
            panel1.TabIndex = 28;
            // 
            // panel6
            // 
            panel6.Controls.Add(buttonSave);
            panel6.Dock = DockStyle.Top;
            panel6.Location = new Point(0, 91);
            panel6.Margin = new Padding(3, 2, 3, 2);
            panel6.Name = "panel6";
            panel6.Size = new Size(413, 26);
            panel6.TabIndex = 31;
            // 
            // panel5
            // 
            panel5.Dock = DockStyle.Top;
            panel5.Location = new Point(0, 83);
            panel5.Margin = new Padding(3, 2, 3, 2);
            panel5.Name = "panel5";
            panel5.Size = new Size(413, 8);
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
            dateTimePickerEndDate.Location = new Point(0, 17);
            dateTimePickerEndDate.Margin = new Padding(3, 2, 3, 2);
            dateTimePickerEndDate.Name = "dateTimePickerEndDate";
            dateTimePickerEndDate.Size = new Size(414, 23);
            dateTimePickerEndDate.TabIndex = 27;
            dateTimePickerEndDate.ValueChanged += dateTimePickerEndDate_ValueChanged;
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
            // checkBoxEndDate
            // 
            checkBoxEndDate.Anchor = AnchorStyles.Top;
            checkBoxEndDate.AutoSize = true;
            checkBoxEndDate.Font = new Font("Arial", 9.4F, FontStyle.Bold, GraphicsUnit.Point);
            checkBoxEndDate.ForeColor = Color.White;
            checkBoxEndDate.Location = new Point(161, 173);
            checkBoxEndDate.Margin = new Padding(3, 2, 3, 2);
            checkBoxEndDate.Name = "checkBoxEndDate";
            checkBoxEndDate.Size = new Size(140, 20);
            checkBoxEndDate.TabIndex = 26;
            checkBoxEndDate.Text = "Need an End Date";
            checkBoxEndDate.UseVisualStyleBackColor = true;
            checkBoxEndDate.CheckedChanged += checkBox_CheckedChanged;
            // 
            // dateTimePickerStartDate
            // 
            dateTimePickerStartDate.Anchor = AnchorStyles.Top;
            dateTimePickerStartDate.Format = DateTimePickerFormat.Short;
            dateTimePickerStartDate.Location = new Point(28, 127);
            dateTimePickerStartDate.Margin = new Padding(3, 2, 3, 2);
            dateTimePickerStartDate.Name = "dateTimePickerStartDate";
            dateTimePickerStartDate.Size = new Size(414, 23);
            dateTimePickerStartDate.TabIndex = 25;
            dateTimePickerStartDate.ValueChanged += dateTimePickerStarDate_ValueChanged;
            // 
            // panel2
            // 
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(960, 1);
            panel2.TabIndex = 30;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(10, 41);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(38, 32);
            pictureBox1.TabIndex = 31;
            pictureBox1.TabStop = false;
            pictureBox1.MouseDown += pictureBox1_MouseDown;
            pictureBox1.MouseEnter += pictureBox1_MouseEnter;
            pictureBox1.MouseLeave += pictureBox1_MouseLeave;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            label5.ForeColor = Color.White;
            label5.Location = new Point(10, 7);
            label5.Name = "label5";
            label5.Size = new Size(112, 30);
            label5.TabIndex = 44;
            label5.Text = "Add Event";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            label7.ForeColor = Color.White;
            label7.Location = new Point(32, 21);
            label7.Name = "label7";
            label7.Size = new Size(159, 25);
            label7.TabIndex = 45;
            label7.Text = " Event Information";
            // 
            // panel7
            // 
            panel7.BorderStyle = BorderStyle.FixedSingle;
            panel7.Controls.Add(checkBoxHour);
            panel7.Controls.Add(textBoxName);
            panel7.Controls.Add(panel1);
            panel7.Controls.Add(textBoxDescription);
            panel7.Controls.Add(checkBoxEndDate);
            panel7.Controls.Add(label2);
            panel7.Controls.Add(dateTimePickerStartDate);
            panel7.Controls.Add(label3);
            panel7.Controls.Add(labelName);
            panel7.Controls.Add(label6);
            panel7.Location = new Point(3, 37);
            panel7.Margin = new Padding(3, 2, 3, 2);
            panel7.Name = "panel7";
            panel7.Size = new Size(469, 344);
            panel7.TabIndex = 46;
            // 
            // panel8
            // 
            panel8.Controls.Add(label7);
            panel8.Controls.Add(panel7);
            panel8.Location = new Point(243, 75);
            panel8.Name = "panel8";
            panel8.Size = new Size(475, 388);
            panel8.TabIndex = 47;
            // 
            // panel9
            // 
            panel9.Dock = DockStyle.Bottom;
            panel9.Location = new Point(0, 590);
            panel9.Name = "panel9";
            panel9.Size = new Size(960, 10);
            panel9.TabIndex = 48;
            // 
            // EventsRegister
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(960, 600);
            Controls.Add(panel9);
            Controls.Add(panel8);
            Controls.Add(label5);
            Controls.Add(pictureBox1);
            Controls.Add(panel2);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "EventsRegister";
            Text = "EventsRegister";
            Resize += EventsRegister_Resize;
            panel1.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxDescription;
        private Label label2;
        private Label label3;
        private Button buttonSave;
        private TextBox textBoxGroup;
        private Label label4;
        private Label labelGroup;
        private TextBox textBoxName;
        private Label label6;
        private Label labelName;
        private DateTimePicker dateTimePickerEndDate;
        private CheckBox checkBoxEndDate;
        private DateTimePicker dateTimePickerStartDate;
        private Panel panel1;
        private Panel panel3;
        private CheckBox checkBoxHour;
        private Panel panel4;
        private DateTimePicker dateTimePickerHour;
        private Label label1;
        private Panel panel5;
        private Panel panel2;
        private Panel panel6;
        private PictureBox pictureBox1;
        private Label label5;
        private Label label7;
        private Panel panel7;
        private Panel panel8;
        private Panel panel9;
    }
}