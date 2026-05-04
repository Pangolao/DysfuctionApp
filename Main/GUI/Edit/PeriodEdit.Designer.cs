namespace Dysfunction.GUI
{
    partial class PeriodEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PeriodEdit));
            dateTimePickerStartDate = new DateTimePicker();
            dateTimePickerEndDate = new DateTimePicker();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            buttonEdit = new Button();
            labelPeriod = new Label();
            comboBoxPeriod = new ComboBox();
            labelAsignature = new Label();
            label4 = new Label();
            comboBoxAsignature = new ComboBox();
            buttonAdd = new Button();
            listBox = new ListBox();
            label5 = new Label();
            panel1 = new Panel();
            labelPDFOri = new Label();
            labelList = new Label();
            label6 = new Label();
            panel2 = new Panel();
            labelPDFMat = new Label();
            buttonDelete = new Button();
            label8 = new Label();
            dateTimePicker = new DateTimePicker();
            panel3 = new Panel();
            label9 = new Label();
            pictureBox1 = new PictureBox();
            panel7 = new Panel();
            pictureBox3 = new PictureBox();
            label7 = new Label();
            panel5 = new Panel();
            label10 = new Label();
            pictureBox2 = new PictureBox();
            panel4 = new Panel();
            label11 = new Label();
            label12 = new Label();
            panel11 = new Panel();
            panel6 = new Panel();
            panelPlus2 = new Panel();
            picturePlus2 = new PictureBox();
            panelPlus1 = new Panel();
            picturePlus1 = new PictureBox();
            panel10 = new Panel();
            panel9 = new Panel();
            panel8 = new Panel();
            panel12 = new Panel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel4.SuspendLayout();
            panel11.SuspendLayout();
            panel6.SuspendLayout();
            panelPlus2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picturePlus2).BeginInit();
            panelPlus1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picturePlus1).BeginInit();
            panel10.SuspendLayout();
            panel9.SuspendLayout();
            panel8.SuspendLayout();
            SuspendLayout();
            // 
            // dateTimePickerStartDate
            // 
            dateTimePickerStartDate.Anchor = AnchorStyles.Top;
            dateTimePickerStartDate.CustomFormat = "dd/MM";
            dateTimePickerStartDate.Enabled = false;
            dateTimePickerStartDate.Format = DateTimePickerFormat.Custom;
            dateTimePickerStartDate.Location = new Point(51, 114);
            dateTimePickerStartDate.Margin = new Padding(3, 2, 3, 2);
            dateTimePickerStartDate.Name = "dateTimePickerStartDate";
            dateTimePickerStartDate.Size = new Size(199, 23);
            dateTimePickerStartDate.TabIndex = 2;
            dateTimePickerStartDate.ValueChanged += dateTimePickerStartDate_ValueChanged;
            // 
            // dateTimePickerEndDate
            // 
            dateTimePickerEndDate.Anchor = AnchorStyles.Top;
            dateTimePickerEndDate.CustomFormat = "dd/MM";
            dateTimePickerEndDate.Enabled = false;
            dateTimePickerEndDate.Format = DateTimePickerFormat.Custom;
            dateTimePickerEndDate.Location = new Point(268, 114);
            dateTimePickerEndDate.Margin = new Padding(3, 2, 3, 2);
            dateTimePickerEndDate.Name = "dateTimePickerEndDate";
            dateTimePickerEndDate.Size = new Size(199, 23);
            dateTimePickerEndDate.TabIndex = 3;
            dateTimePickerEndDate.ValueChanged += dateTimePickerEndDate_ValueChanged;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.ForeColor = Color.White;
            label1.Location = new Point(149, 58);
            label1.Name = "label1";
            label1.Size = new Size(41, 15);
            label1.TabIndex = 4;
            label1.Text = "Period";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.AutoSize = true;
            label2.ForeColor = Color.White;
            label2.Location = new Point(272, 97);
            label2.Name = "label2";
            label2.Size = new Size(54, 15);
            label2.TabIndex = 5;
            label2.Text = "End Date";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top;
            label3.AutoSize = true;
            label3.ForeColor = Color.White;
            label3.Location = new Point(52, 97);
            label3.Name = "label3";
            label3.Size = new Size(58, 15);
            label3.TabIndex = 6;
            label3.Text = "Start Date";
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
            buttonEdit.Location = new Point(104, 8);
            buttonEdit.Margin = new Padding(3, 2, 3, 2);
            buttonEdit.Name = "buttonEdit";
            buttonEdit.Size = new Size(195, 34);
            buttonEdit.TabIndex = 8;
            buttonEdit.Text = "Save Edit";
            buttonEdit.UseVisualStyleBackColor = false;
            buttonEdit.Click += buttonSave_Click;
            // 
            // labelPeriod
            // 
            labelPeriod.Anchor = AnchorStyles.Top;
            labelPeriod.AutoSize = true;
            labelPeriod.BackColor = Color.Black;
            labelPeriod.Font = new Font("Arial Narrow", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            labelPeriod.ForeColor = Color.White;
            labelPeriod.Location = new Point(132, 74);
            labelPeriod.Name = "labelPeriod";
            labelPeriod.Size = new Size(14, 23);
            labelPeriod.TabIndex = 9;
            labelPeriod.Text = "!";
            // 
            // comboBoxPeriod
            // 
            comboBoxPeriod.Anchor = AnchorStyles.Top;
            comboBoxPeriod.BackColor = Color.White;
            comboBoxPeriod.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxPeriod.ForeColor = Color.Black;
            comboBoxPeriod.FormattingEnabled = true;
            comboBoxPeriod.Items.AddRange(new object[] { "I Period", "II Period", "III Period" });
            comboBoxPeriod.Location = new Point(150, 73);
            comboBoxPeriod.Margin = new Padding(3, 2, 3, 2);
            comboBoxPeriod.Name = "comboBoxPeriod";
            comboBoxPeriod.Size = new Size(196, 23);
            comboBoxPeriod.TabIndex = 10;
            comboBoxPeriod.SelectedIndexChanged += comboBoxPeriod_SelectedIndexChanged;
            // 
            // labelAsignature
            // 
            labelAsignature.Anchor = AnchorStyles.Top;
            labelAsignature.AutoSize = true;
            labelAsignature.BackColor = Color.Black;
            labelAsignature.Font = new Font("Arial Narrow", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            labelAsignature.ForeColor = Color.White;
            labelAsignature.Location = new Point(40, 44);
            labelAsignature.Name = "labelAsignature";
            labelAsignature.Size = new Size(14, 23);
            labelAsignature.TabIndex = 24;
            labelAsignature.Text = "!";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top;
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.ForeColor = Color.White;
            label4.Location = new Point(59, 26);
            label4.Name = "label4";
            label4.Size = new Size(64, 15);
            label4.TabIndex = 23;
            label4.Text = "Asignature";
            // 
            // comboBoxAsignature
            // 
            comboBoxAsignature.Anchor = AnchorStyles.Top;
            comboBoxAsignature.BackColor = Color.White;
            comboBoxAsignature.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxAsignature.ForeColor = Color.Black;
            comboBoxAsignature.FormattingEnabled = true;
            comboBoxAsignature.Location = new Point(60, 47);
            comboBoxAsignature.Margin = new Padding(3, 2, 3, 2);
            comboBoxAsignature.Name = "comboBoxAsignature";
            comboBoxAsignature.Size = new Size(414, 23);
            comboBoxAsignature.TabIndex = 22;
            comboBoxAsignature.SelectedIndexChanged += comboBoxAsignature_SelectedIndexChanged;
            // 
            // buttonAdd
            // 
            buttonAdd.Anchor = AnchorStyles.Top;
            buttonAdd.BackColor = Color.Black;
            buttonAdd.FlatAppearance.BorderColor = Color.FromArgb(64, 64, 64);
            buttonAdd.FlatAppearance.MouseDownBackColor = Color.FromArgb(20, 20, 20);
            buttonAdd.FlatAppearance.MouseOverBackColor = Color.FromArgb(20, 20, 20);
            buttonAdd.FlatStyle = FlatStyle.Flat;
            buttonAdd.ForeColor = Color.White;
            buttonAdd.Location = new Point(163, 153);
            buttonAdd.Margin = new Padding(3, 2, 3, 2);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(195, 32);
            buttonAdd.TabIndex = 25;
            buttonAdd.Text = "Add Asignature";
            buttonAdd.UseVisualStyleBackColor = false;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // listBox
            // 
            listBox.BackColor = Color.Black;
            listBox.BorderStyle = BorderStyle.FixedSingle;
            listBox.Dock = DockStyle.Bottom;
            listBox.ForeColor = Color.White;
            listBox.FormattingEnabled = true;
            listBox.ItemHeight = 15;
            listBox.Location = new Point(0, 22);
            listBox.Margin = new Padding(3, 2, 3, 2);
            listBox.Name = "listBox";
            listBox.Size = new Size(413, 77);
            listBox.TabIndex = 26;
            listBox.MouseClick += listBox_MouseClick;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top;
            label5.AutoSize = true;
            label5.ForeColor = Color.White;
            label5.Location = new Point(59, 82);
            label5.Name = "label5";
            label5.Size = new Size(67, 15);
            label5.TabIndex = 28;
            label5.Text = "Orientation";
            // 
            // panel1
            // 
            panel1.AllowDrop = true;
            panel1.Anchor = AnchorStyles.Top;
            panel1.BackColor = Color.FromArgb(20, 20, 20);
            panel1.Controls.Add(labelPDFOri);
            panel1.Location = new Point(60, 99);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(199, 41);
            panel1.TabIndex = 27;
            panel1.Click += panel1_Click;
            panel1.DragDrop += panel1_DragDrop;
            panel1.DragEnter += panel1_DragEnter;
            panel1.DragLeave += panel1_DragLeave;
            panel1.MouseDoubleClick += panel1_MouseDoubleClick;
            panel1.MouseEnter += panel1_MouseEnter;
            panel1.MouseLeave += panel1_MouseLeave;
            // 
            // labelPDFOri
            // 
            labelPDFOri.AllowDrop = true;
            labelPDFOri.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelPDFOri.AutoSize = true;
            labelPDFOri.Font = new Font("Segoe UI", 9.6F, FontStyle.Regular, GraphicsUnit.Point);
            labelPDFOri.ForeColor = Color.White;
            labelPDFOri.Location = new Point(33, 10);
            labelPDFOri.Name = "labelPDFOri";
            labelPDFOri.Size = new Size(133, 17);
            labelPDFOri.TabIndex = 0;
            labelPDFOri.Text = "Select or Drag a PDF ";
            labelPDFOri.TextAlign = ContentAlignment.MiddleCenter;
            labelPDFOri.Click += panel1_Click;
            labelPDFOri.DragDrop += panel1_DragDrop;
            labelPDFOri.DragEnter += panel1_DragEnter;
            labelPDFOri.DragLeave += panel1_DragLeave;
            labelPDFOri.MouseDoubleClick += panel1_MouseDoubleClick;
            labelPDFOri.MouseEnter += panel1_MouseEnter;
            labelPDFOri.MouseLeave += panel1_MouseLeave;
            // 
            // labelList
            // 
            labelList.Anchor = AnchorStyles.Top;
            labelList.AutoSize = true;
            labelList.BackColor = Color.Transparent;
            labelList.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            labelList.ForeColor = Color.White;
            labelList.Location = new Point(-1, 0);
            labelList.Name = "labelList";
            labelList.Size = new Size(147, 20);
            labelList.TabIndex = 30;
            labelList.Text = "Asignatures Selected";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top;
            label6.AutoSize = true;
            label6.ForeColor = Color.White;
            label6.Location = new Point(274, 82);
            label6.Name = "label6";
            label6.Size = new Size(50, 15);
            label6.TabIndex = 33;
            label6.Text = "Material";
            // 
            // panel2
            // 
            panel2.AllowDrop = true;
            panel2.Anchor = AnchorStyles.Top;
            panel2.BackColor = Color.FromArgb(20, 20, 20);
            panel2.Controls.Add(labelPDFMat);
            panel2.Location = new Point(275, 99);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(199, 41);
            panel2.TabIndex = 32;
            panel2.Click += panel2_Click;
            panel2.DragDrop += panel2_DragDrop;
            panel2.DragEnter += panel2_DragEnter;
            panel2.DragLeave += panel2_DragLeave;
            panel2.MouseDoubleClick += panel2_MouseDoubleClick;
            panel2.MouseEnter += panel2_MouseEnter;
            panel2.MouseLeave += panel2_MouseLeave;
            // 
            // labelPDFMat
            // 
            labelPDFMat.AllowDrop = true;
            labelPDFMat.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelPDFMat.AutoSize = true;
            labelPDFMat.Font = new Font("Segoe UI", 9.6F, FontStyle.Regular, GraphicsUnit.Point);
            labelPDFMat.ForeColor = Color.White;
            labelPDFMat.Location = new Point(33, 10);
            labelPDFMat.Name = "labelPDFMat";
            labelPDFMat.Size = new Size(133, 17);
            labelPDFMat.TabIndex = 0;
            labelPDFMat.Text = "Select or Drag a PDF ";
            labelPDFMat.TextAlign = ContentAlignment.MiddleCenter;
            labelPDFMat.Click += panel2_Click;
            labelPDFMat.DragDrop += panel2_DragDrop;
            labelPDFMat.DragEnter += panel2_DragEnter;
            labelPDFMat.DragLeave += panel2_DragLeave;
            labelPDFMat.MouseDoubleClick += panel2_MouseDoubleClick;
            labelPDFMat.MouseEnter += panel2_MouseEnter;
            labelPDFMat.MouseLeave += panel2_MouseLeave;
            // 
            // buttonDelete
            // 
            buttonDelete.Anchor = AnchorStyles.Top;
            buttonDelete.FlatAppearance.BorderColor = Color.FromArgb(64, 64, 64);
            buttonDelete.FlatAppearance.MouseDownBackColor = Color.FromArgb(20, 20, 20);
            buttonDelete.FlatAppearance.MouseOverBackColor = Color.FromArgb(20, 20, 20);
            buttonDelete.FlatStyle = FlatStyle.Flat;
            buttonDelete.ForeColor = Color.White;
            buttonDelete.Location = new Point(104, 48);
            buttonDelete.Margin = new Padding(3, 2, 3, 2);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(195, 30);
            buttonDelete.TabIndex = 34;
            buttonDelete.Text = "Delete";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Top;
            label8.AutoSize = true;
            label8.ForeColor = Color.White;
            label8.Location = new Point(150, 17);
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
            dateTimePicker.Location = new Point(150, 36);
            dateTimePicker.Margin = new Padding(3, 2, 3, 2);
            dateTimePicker.Name = "dateTimePicker";
            dateTimePicker.ShowUpDown = true;
            dateTimePicker.Size = new Size(196, 23);
            dateTimePicker.TabIndex = 36;
            dateTimePicker.ValueChanged += dateTimePicker_ValueChanged;
            // 
            // panel3
            // 
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 0);
            panel3.Margin = new Padding(3, 2, 3, 2);
            panel3.Name = "panel3";
            panel3.Size = new Size(960, 1);
            panel3.TabIndex = 38;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label9.ForeColor = Color.White;
            label9.Location = new Point(10, 7);
            label9.Name = "label9";
            label9.Size = new Size(107, 28);
            label9.TabIndex = 46;
            label9.Text = "Edit Period";
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
            // panel7
            // 
            panel7.Anchor = AnchorStyles.Top;
            panel7.Controls.Add(pictureBox3);
            panel7.Controls.Add(label7);
            panel7.Location = new Point(422, 2);
            panel7.Margin = new Padding(3, 2, 3, 2);
            panel7.Name = "panel7";
            panel7.Size = new Size(52, 38);
            panel7.TabIndex = 48;
            panel7.MouseDown += panel7_MouseDown;
            panel7.MouseEnter += panel7_MouseEnter;
            panel7.MouseLeave += panel7_MouseLeave;
            // 
            // pictureBox3
            // 
            pictureBox3.BackgroundImage = (Image)resources.GetObject("pictureBox3.BackgroundImage");
            pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox3.Location = new Point(14, 0);
            pictureBox3.Margin = new Padding(3, 2, 3, 2);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(26, 22);
            pictureBox3.TabIndex = 2;
            pictureBox3.TabStop = false;
            pictureBox3.MouseDown += panel7_MouseDown;
            pictureBox3.MouseEnter += panel7_MouseEnter;
            pictureBox3.MouseLeave += panel7_MouseLeave;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            label7.ForeColor = Color.White;
            label7.Location = new Point(15, 25);
            label7.Name = "label7";
            label7.Size = new Size(21, 12);
            label7.TabIndex = 1;
            label7.Text = "Edit";
            label7.MouseDown += panel7_MouseDown;
            // 
            // panel5
            // 
            panel5.Anchor = AnchorStyles.Top;
            panel5.Controls.Add(label10);
            panel5.Controls.Add(pictureBox2);
            panel5.Location = new Point(367, 2);
            panel5.Margin = new Padding(3, 2, 3, 2);
            panel5.Name = "panel5";
            panel5.Size = new Size(52, 38);
            panel5.TabIndex = 47;
            panel5.MouseDown += panel5_MouseDown;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.Transparent;
            label10.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            label10.ForeColor = Color.White;
            label10.Location = new Point(14, 25);
            label10.Name = "label10";
            label10.Size = new Size(24, 12);
            label10.TabIndex = 1;
            label10.Text = "New";
            label10.MouseDown += panel5_MouseDown;
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImage = (Image)resources.GetObject("pictureBox2.BackgroundImage");
            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox2.Location = new Point(11, 0);
            pictureBox2.Margin = new Padding(3, 2, 3, 2);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(30, 26);
            pictureBox2.TabIndex = 0;
            pictureBox2.TabStop = false;
            pictureBox2.MouseDown += panel5_MouseDown;
            pictureBox2.MouseEnter += panel5_MouseEnter;
            pictureBox2.MouseLeave += panel5_MouseLeave;
            // 
            // panel4
            // 
            panel4.AllowDrop = true;
            panel4.Controls.Add(label11);
            panel4.Controls.Add(label12);
            panel4.Controls.Add(panel11);
            panel4.Controls.Add(panel6);
            panel4.Location = new Point(208, 7);
            panel4.Margin = new Padding(3, 2, 3, 2);
            panel4.Name = "panel4";
            panel4.Size = new Size(531, 608);
            panel4.TabIndex = 49;
            panel4.Click += panel4_Click;
            panel4.DragEnter += panel4_DragEnter;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label11.ForeColor = Color.White;
            label11.Location = new Point(52, 2);
            label11.Name = "label11";
            label11.Size = new Size(170, 25);
            label11.TabIndex = 51;
            label11.Text = "Period Information";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label12.ForeColor = Color.White;
            label12.Location = new Point(51, 194);
            label12.Name = "label12";
            label12.Size = new Size(187, 25);
            label12.TabIndex = 52;
            label12.Text = "Asignatures Selected";
            // 
            // panel11
            // 
            panel11.BorderStyle = BorderStyle.FixedSingle;
            panel11.Controls.Add(dateTimePicker);
            panel11.Controls.Add(label8);
            panel11.Controls.Add(dateTimePickerStartDate);
            panel11.Controls.Add(dateTimePickerEndDate);
            panel11.Controls.Add(label1);
            panel11.Controls.Add(label2);
            panel11.Controls.Add(label3);
            panel11.Controls.Add(labelPeriod);
            panel11.Controls.Add(comboBoxPeriod);
            panel11.Location = new Point(3, 19);
            panel11.Name = "panel11";
            panel11.Size = new Size(525, 162);
            panel11.TabIndex = 55;
            panel11.Click += panel4_Click;
            panel11.DragEnter += panel11_DragEnter;
            // 
            // panel6
            // 
            panel6.AllowDrop = true;
            panel6.BorderStyle = BorderStyle.FixedSingle;
            panel6.Controls.Add(panelPlus2);
            panel6.Controls.Add(panelPlus1);
            panel6.Controls.Add(panel10);
            panel6.Controls.Add(panel7);
            panel6.Controls.Add(panel5);
            panel6.Controls.Add(label6);
            panel6.Controls.Add(panel2);
            panel6.Controls.Add(label5);
            panel6.Controls.Add(panel1);
            panel6.Controls.Add(buttonAdd);
            panel6.Controls.Add(labelAsignature);
            panel6.Controls.Add(label4);
            panel6.Controls.Add(comboBoxAsignature);
            panel6.Location = new Point(3, 211);
            panel6.Name = "panel6";
            panel6.Size = new Size(525, 382);
            panel6.TabIndex = 54;
            panel6.Click += panel4_Click;
            panel6.DragEnter += panel6_DragEnter;
            // 
            // panelPlus2
            // 
            panelPlus2.AllowDrop = true;
            panelPlus2.BackColor = Color.FromArgb(20, 20, 20);
            panelPlus2.Controls.Add(picturePlus2);
            panelPlus2.Location = new Point(475, 99);
            panelPlus2.Name = "panelPlus2";
            panelPlus2.Size = new Size(25, 41);
            panelPlus2.TabIndex = 55;
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
            // panelPlus1
            // 
            panelPlus1.AllowDrop = true;
            panelPlus1.BackColor = Color.FromArgb(20, 20, 20);
            panelPlus1.Controls.Add(picturePlus1);
            panelPlus1.Location = new Point(34, 99);
            panelPlus1.Name = "panelPlus1";
            panelPlus1.Size = new Size(25, 41);
            panelPlus1.TabIndex = 54;
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
            // panel10
            // 
            panel10.Controls.Add(panel9);
            panel10.Controls.Add(panel8);
            panel10.Location = new Point(59, 196);
            panel10.Margin = new Padding(3, 2, 3, 2);
            panel10.Name = "panel10";
            panel10.Size = new Size(413, 182);
            panel10.TabIndex = 53;
            // 
            // panel9
            // 
            panel9.Controls.Add(buttonDelete);
            panel9.Controls.Add(buttonEdit);
            panel9.Dock = DockStyle.Top;
            panel9.Location = new Point(0, 99);
            panel9.Margin = new Padding(3, 2, 3, 2);
            panel9.Name = "panel9";
            panel9.Size = new Size(413, 81);
            panel9.TabIndex = 36;
            // 
            // panel8
            // 
            panel8.Controls.Add(labelList);
            panel8.Controls.Add(listBox);
            panel8.Dock = DockStyle.Top;
            panel8.Location = new Point(0, 0);
            panel8.Margin = new Padding(3, 2, 3, 2);
            panel8.Name = "panel8";
            panel8.Size = new Size(413, 99);
            panel8.TabIndex = 35;
            // 
            // panel12
            // 
            panel12.Dock = DockStyle.Bottom;
            panel12.Location = new Point(0, 592);
            panel12.Name = "panel12";
            panel12.Size = new Size(960, 8);
            panel12.TabIndex = 50;
            // 
            // PeriodEdit
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(960, 600);
            Controls.Add(panel12);
            Controls.Add(pictureBox1);
            Controls.Add(panel3);
            Controls.Add(panel4);
            Controls.Add(label9);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "PeriodEdit";
            Text = "PeriodRegister";
            Load += PeriodEdit_Load;
            Click += panel4_Click;
            DragEnter += PeriodEdit_DragEnter;
            MouseEnter += PeriodRegister_MouseEnter;
            Resize += PeriodEdit_Resize;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel11.ResumeLayout(false);
            panel11.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panelPlus2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picturePlus2).EndInit();
            panelPlus1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picturePlus1).EndInit();
            panel10.ResumeLayout(false);
            panel9.ResumeLayout(false);
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DateTimePicker dateTimePickerStartDate;
        private DateTimePicker dateTimePickerEndDate;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button buttonEdit;
        private Label labelPeriod;
        private ComboBox comboBoxPeriod;
        private Label labelAsignature;
        private Label label4;
        private ComboBox comboBoxAsignature;
        private Button buttonAdd;
        private ListBox listBox;
        private Label label5;
        private Panel panel1;
        private Label labelPDFOri;
        private Label labelList;
        private Label label6;
        private Panel panel2;
        private Label labelPDFMat;
        private Button buttonDelete;
        private Label label8;
        private DateTimePicker dateTimePicker;
        private Panel panel3;
        private Label label9;
        private PictureBox pictureBox1;
        private Panel panel7;
        private PictureBox pictureBox3;
        private Label label7;
        private Panel panel5;
        private Label label10;
        private PictureBox pictureBox2;
        private Panel panel4;
        private Panel panel9;
        private Panel panel8;
        private Label label12;
        private Label label11;
        private Panel panel10;
        private Panel panel6;
        private Panel panel11;
        private Panel panel12;
        private Panel panelPlus1;
        private PictureBox picturePlus1;
        private Panel panelPlus2;
        private PictureBox picturePlus2;
    }
}