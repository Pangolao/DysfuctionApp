namespace Dysfunction.GUI
{
    partial class PeriodRegister
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PeriodRegister));
            dateTimePickerStartDate = new DateTimePicker();
            dateTimePickerEndDate = new DateTimePicker();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            buttonSave = new Button();
            labelPeriod = new Label();
            comboBoxPeriod = new ComboBox();
            labelAsignature = new Label();
            label4 = new Label();
            comboBoxAsignature = new ComboBox();
            buttonAdd = new Button();
            listBox = new ListBox();
            label5 = new Label();
            panel1 = new Panel();
            labelPDF = new Label();
            labelList = new Label();
            label6 = new Label();
            panel2 = new Panel();
            labelPDFMat = new Label();
            panel3 = new Panel();
            panel6 = new Panel();
            panelList = new Panel();
            label9 = new Label();
            pictureBox1 = new PictureBox();
            panel5 = new Panel();
            label7 = new Label();
            pictureBox2 = new PictureBox();
            panel7 = new Panel();
            pictureBox3 = new PictureBox();
            label8 = new Label();
            label10 = new Label();
            dateTimePickerYear = new DateTimePicker();
            panel8 = new Panel();
            label11 = new Label();
            label12 = new Label();
            panelAsignatures = new Panel();
            panelPlus1 = new Panel();
            picturePlus1 = new PictureBox();
            panelPlus2 = new Panel();
            picturePlus2 = new PictureBox();
            panelPeriod = new Panel();
            panel4 = new Panel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel6.SuspendLayout();
            panelList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            panel8.SuspendLayout();
            panelAsignatures.SuspendLayout();
            panelPlus1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picturePlus1).BeginInit();
            panelPlus2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picturePlus2).BeginInit();
            panelPeriod.SuspendLayout();
            SuspendLayout();
            // 
            // dateTimePickerStartDate
            // 
            dateTimePickerStartDate.Anchor = AnchorStyles.Top;
            dateTimePickerStartDate.CustomFormat = "dd/MM";
            dateTimePickerStartDate.Format = DateTimePickerFormat.Custom;
            dateTimePickerStartDate.Location = new Point(256, 126);
            dateTimePickerStartDate.Margin = new Padding(3, 2, 3, 2);
            dateTimePickerStartDate.Name = "dateTimePickerStartDate";
            dateTimePickerStartDate.Size = new Size(201, 23);
            dateTimePickerStartDate.TabIndex = 2;
            dateTimePickerStartDate.ValueChanged += dateTimePickerEndDate_ValueChanged;
            // 
            // dateTimePickerEndDate
            // 
            dateTimePickerEndDate.Anchor = AnchorStyles.Top;
            dateTimePickerEndDate.CustomFormat = "dd/MM";
            dateTimePickerEndDate.Format = DateTimePickerFormat.Custom;
            dateTimePickerEndDate.Location = new Point(37, 126);
            dateTimePickerEndDate.Margin = new Padding(3, 2, 3, 2);
            dateTimePickerEndDate.Name = "dateTimePickerEndDate";
            dateTimePickerEndDate.Size = new Size(201, 23);
            dateTimePickerEndDate.TabIndex = 3;
            dateTimePickerEndDate.ValueChanged += dateTimePickerStartDate_ValueChanged;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.ForeColor = Color.White;
            label1.Location = new Point(139, 58);
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
            label2.Location = new Point(256, 109);
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
            label3.Location = new Point(37, 109);
            label3.Name = "label3";
            label3.Size = new Size(58, 15);
            label3.TabIndex = 6;
            label3.Text = "Start Date";
            // 
            // buttonSave
            // 
            buttonSave.BackColor = Color.Black;
            buttonSave.FlatAppearance.BorderColor = Color.FromArgb(64, 64, 64);
            buttonSave.FlatAppearance.MouseDownBackColor = Color.FromArgb(20, 20, 20);
            buttonSave.FlatAppearance.MouseOverBackColor = Color.FromArgb(20, 20, 20);
            buttonSave.FlatStyle = FlatStyle.Flat;
            buttonSave.ForeColor = Color.White;
            buttonSave.Location = new Point(105, 9);
            buttonSave.Margin = new Padding(3, 2, 3, 2);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(195, 29);
            buttonSave.TabIndex = 8;
            buttonSave.Text = "Save a Period";
            buttonSave.UseVisualStyleBackColor = false;
            buttonSave.Click += buttonSave_Click;
            // 
            // labelPeriod
            // 
            labelPeriod.AutoSize = true;
            labelPeriod.BackColor = Color.FromArgb(50, 50, 50);
            labelPeriod.Font = new Font("Arial Narrow", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            labelPeriod.ForeColor = Color.White;
            labelPeriod.Location = new Point(-16, 154);
            labelPeriod.Name = "labelPeriod";
            labelPeriod.Size = new Size(14, 23);
            labelPeriod.TabIndex = 9;
            labelPeriod.Text = "!";
            // 
            // comboBoxPeriod
            // 
            comboBoxPeriod.Anchor = AnchorStyles.Top;
            comboBoxPeriod.BackColor = Color.Black;
            comboBoxPeriod.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxPeriod.ForeColor = Color.White;
            comboBoxPeriod.FormattingEnabled = true;
            comboBoxPeriod.Items.AddRange(new object[] { "I Period", "II Period", "III Period" });
            comboBoxPeriod.Location = new Point(142, 75);
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
            labelAsignature.Location = new Point(25, 56);
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
            label4.Location = new Point(47, 42);
            label4.Name = "label4";
            label4.Size = new Size(64, 15);
            label4.TabIndex = 23;
            label4.Text = "Asignature";
            // 
            // comboBoxAsignature
            // 
            comboBoxAsignature.Anchor = AnchorStyles.Top;
            comboBoxAsignature.BackColor = Color.Black;
            comboBoxAsignature.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxAsignature.ForeColor = Color.White;
            comboBoxAsignature.FormattingEnabled = true;
            comboBoxAsignature.Location = new Point(45, 59);
            comboBoxAsignature.Margin = new Padding(3, 2, 3, 2);
            comboBoxAsignature.Name = "comboBoxAsignature";
            comboBoxAsignature.Size = new Size(414, 23);
            comboBoxAsignature.TabIndex = 22;
            comboBoxAsignature.SelectedIndexChanged += comboBoxAsignature_SelectedIndexChanged;
            // 
            // buttonAdd
            // 
            buttonAdd.Anchor = AnchorStyles.Top;
            buttonAdd.FlatAppearance.BorderColor = Color.FromArgb(64, 64, 64);
            buttonAdd.FlatAppearance.MouseDownBackColor = Color.FromArgb(20, 20, 20);
            buttonAdd.FlatAppearance.MouseOverBackColor = Color.FromArgb(20, 20, 20);
            buttonAdd.FlatStyle = FlatStyle.Flat;
            buttonAdd.ForeColor = Color.White;
            buttonAdd.Location = new Point(141, 165);
            buttonAdd.Margin = new Padding(3, 2, 3, 2);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(195, 29);
            buttonAdd.TabIndex = 25;
            buttonAdd.Text = "Add Asignature";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // listBox
            // 
            listBox.BackColor = Color.Black;
            listBox.BorderStyle = BorderStyle.FixedSingle;
            listBox.Dock = DockStyle.Top;
            listBox.ForeColor = Color.White;
            listBox.FormattingEnabled = true;
            listBox.ItemHeight = 15;
            listBox.Location = new Point(0, 20);
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
            label5.Location = new Point(45, 90);
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
            panel1.Controls.Add(labelPDF);
            panel1.Location = new Point(45, 108);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(198, 41);
            panel1.TabIndex = 27;
            panel1.Click += panel1_Click;
            panel1.DragDrop += panelInteractive1_DragDrop;
            panel1.DragEnter += panel_DragEnter;
            panel1.DragLeave += panel1_DragLeave;
            panel1.MouseEnter += panel1_MouseEnter;
            panel1.MouseLeave += panel1_MouseLeave;
            // 
            // labelPDF
            // 
            labelPDF.AllowDrop = true;
            labelPDF.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelPDF.AutoSize = true;
            labelPDF.Font = new Font("Segoe UI", 9.6F, FontStyle.Regular, GraphicsUnit.Point);
            labelPDF.ForeColor = Color.White;
            labelPDF.Location = new Point(38, 12);
            labelPDF.Name = "labelPDF";
            labelPDF.Size = new Size(133, 17);
            labelPDF.TabIndex = 0;
            labelPDF.Text = "Select or Drag a PDF ";
            labelPDF.TextAlign = ContentAlignment.MiddleCenter;
            labelPDF.Click += panel1_Click;
            labelPDF.DragDrop += panelInteractive1_DragDrop;
            labelPDF.DragEnter += panel_DragEnter;
            labelPDF.DragLeave += panel1_DragLeave;
            labelPDF.MouseEnter += panel1_MouseEnter;
            labelPDF.MouseLeave += panel1_MouseLeave;
            // 
            // labelList
            // 
            labelList.AutoSize = true;
            labelList.BackColor = Color.Transparent;
            labelList.Dock = DockStyle.Top;
            labelList.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            labelList.ForeColor = Color.White;
            labelList.Location = new Point(0, 0);
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
            label6.Location = new Point(254, 90);
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
            panel2.Location = new Point(258, 108);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(199, 41);
            panel2.TabIndex = 32;
            panel2.Click += panel2_Click;
            panel2.DragDrop += panelInteractive2_DragDrop;
            panel2.DragEnter += panel_DragEnter;
            panel2.DragLeave += panel2_DragLeave;
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
            labelPDFMat.Location = new Point(36, 12);
            labelPDFMat.Name = "labelPDFMat";
            labelPDFMat.Size = new Size(133, 17);
            labelPDFMat.TabIndex = 0;
            labelPDFMat.Text = "Select or Drag a PDF ";
            labelPDFMat.TextAlign = ContentAlignment.MiddleCenter;
            labelPDFMat.Click += panel2_Click;
            labelPDFMat.DragDrop += panelInteractive2_DragDrop;
            labelPDFMat.DragEnter += panel_DragEnter;
            labelPDFMat.DragLeave += panel_DragLeave;
            labelPDFMat.MouseEnter += panel2_MouseEnter;
            labelPDFMat.MouseLeave += panel2_MouseLeave;
            // 
            // panel3
            // 
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 0);
            panel3.Margin = new Padding(3, 2, 3, 2);
            panel3.Name = "panel3";
            panel3.Size = new Size(960, 1);
            panel3.TabIndex = 34;
            // 
            // panel6
            // 
            panel6.Controls.Add(buttonSave);
            panel6.Dock = DockStyle.Top;
            panel6.Location = new Point(0, 97);
            panel6.Margin = new Padding(3, 2, 3, 2);
            panel6.Name = "panel6";
            panel6.Size = new Size(413, 40);
            panel6.TabIndex = 37;
            // 
            // panelList
            // 
            panelList.Controls.Add(panel6);
            panelList.Controls.Add(listBox);
            panelList.Controls.Add(labelList);
            panelList.Location = new Point(36, 209);
            panelList.Margin = new Padding(3, 2, 3, 2);
            panelList.Name = "panelList";
            panelList.Size = new Size(413, 137);
            panelList.TabIndex = 36;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label9.ForeColor = Color.White;
            label9.Location = new Point(10, 7);
            label9.Name = "label9";
            label9.Size = new Size(110, 28);
            label9.TabIndex = 44;
            label9.Text = "Add Period";
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
            // panel5
            // 
            panel5.Anchor = AnchorStyles.Top;
            panel5.Controls.Add(label7);
            panel5.Controls.Add(pictureBox2);
            panel5.Location = new Point(351, 9);
            panel5.Margin = new Padding(3, 2, 3, 2);
            panel5.Name = "panel5";
            panel5.Size = new Size(52, 38);
            panel5.TabIndex = 45;
            panel5.MouseDown += panel5_MouseDown;
            panel5.MouseEnter += panel5_MouseEnter;
            panel5.MouseLeave += panel5_MouseLeave;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            label7.ForeColor = Color.White;
            label7.Location = new Point(14, 26);
            label7.Name = "label7";
            label7.Size = new Size(24, 12);
            label7.TabIndex = 1;
            label7.Text = "New";
            label7.MouseDown += panel5_MouseDown;
            label7.MouseEnter += panel5_MouseEnter;
            label7.MouseLeave += panel5_MouseLeave;
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
            // panel7
            // 
            panel7.Anchor = AnchorStyles.Top;
            panel7.Controls.Add(pictureBox3);
            panel7.Controls.Add(label8);
            panel7.Location = new Point(406, 9);
            panel7.Margin = new Padding(3, 2, 3, 2);
            panel7.Name = "panel7";
            panel7.Size = new Size(52, 38);
            panel7.TabIndex = 46;
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
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            label8.ForeColor = Color.White;
            label8.Location = new Point(15, 26);
            label8.Name = "label8";
            label8.Size = new Size(21, 12);
            label8.TabIndex = 1;
            label8.Text = "Edit";
            label8.MouseDown += panel7_MouseDown;
            label8.MouseEnter += panel7_MouseEnter;
            label8.MouseLeave += panel7_MouseLeave;
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.Top;
            label10.AutoSize = true;
            label10.ForeColor = Color.White;
            label10.Location = new Point(142, 18);
            label10.Name = "label10";
            label10.Size = new Size(29, 15);
            label10.TabIndex = 48;
            label10.Text = "Year";
            // 
            // dateTimePickerYear
            // 
            dateTimePickerYear.Anchor = AnchorStyles.Top;
            dateTimePickerYear.CustomFormat = "yyyy";
            dateTimePickerYear.Format = DateTimePickerFormat.Custom;
            dateTimePickerYear.Location = new Point(142, 35);
            dateTimePickerYear.Margin = new Padding(3, 2, 3, 2);
            dateTimePickerYear.Name = "dateTimePickerYear";
            dateTimePickerYear.ShowUpDown = true;
            dateTimePickerYear.Size = new Size(196, 23);
            dateTimePickerYear.TabIndex = 47;
            dateTimePickerYear.ValueChanged += dateTimePickerYear_ValueChanged;
            // 
            // panel8
            // 
            panel8.AllowDrop = true;
            panel8.Anchor = AnchorStyles.None;
            panel8.Controls.Add(label11);
            panel8.Controls.Add(label12);
            panel8.Controls.Add(panelAsignatures);
            panel8.Controls.Add(panelPeriod);
            panel8.Location = new Point(235, 11);
            panel8.Margin = new Padding(3, 2, 3, 2);
            panel8.Name = "panel8";
            panel8.Size = new Size(499, 560);
            panel8.TabIndex = 49;
            panel8.DragEnter += panel8_DragEnter;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label11.ForeColor = Color.White;
            label11.Location = new Point(35, 0);
            label11.Name = "label11";
            label11.Size = new Size(170, 25);
            label11.TabIndex = 49;
            label11.Text = "Period Information";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label12.ForeColor = Color.White;
            label12.Location = new Point(35, 185);
            label12.Name = "label12";
            label12.Size = new Size(193, 25);
            label12.TabIndex = 50;
            label12.Text = "Asignatures Selection";
            // 
            // panelAsignatures
            // 
            panelAsignatures.AllowDrop = true;
            panelAsignatures.Anchor = AnchorStyles.None;
            panelAsignatures.BorderStyle = BorderStyle.FixedSingle;
            panelAsignatures.Controls.Add(panelPlus1);
            panelAsignatures.Controls.Add(panelPlus2);
            panelAsignatures.Controls.Add(panelList);
            panelAsignatures.Controls.Add(panel7);
            panelAsignatures.Controls.Add(panel5);
            panelAsignatures.Controls.Add(buttonAdd);
            panelAsignatures.Controls.Add(label6);
            panelAsignatures.Controls.Add(panel2);
            panelAsignatures.Controls.Add(label5);
            panelAsignatures.Controls.Add(panel1);
            panelAsignatures.Controls.Add(labelAsignature);
            panelAsignatures.Controls.Add(label4);
            panelAsignatures.Controls.Add(comboBoxAsignature);
            panelAsignatures.Location = new Point(3, 201);
            panelAsignatures.Margin = new Padding(3, 2, 3, 2);
            panelAsignatures.Name = "panelAsignatures";
            panelAsignatures.Size = new Size(496, 357);
            panelAsignatures.TabIndex = 52;
            panelAsignatures.DragEnter += panelAsignatures_DragEnter;
            // 
            // panelPlus1
            // 
            panelPlus1.AllowDrop = true;
            panelPlus1.BackColor = Color.FromArgb(20, 20, 20);
            panelPlus1.Controls.Add(picturePlus1);
            panelPlus1.Location = new Point(19, 108);
            panelPlus1.Name = "panelPlus1";
            panelPlus1.Size = new Size(25, 41);
            panelPlus1.TabIndex = 48;
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
            panelPlus2.Location = new Point(458, 108);
            panelPlus2.Name = "panelPlus2";
            panelPlus2.Size = new Size(25, 41);
            panelPlus2.TabIndex = 47;
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
            // 
            // panelPeriod
            // 
            panelPeriod.Anchor = AnchorStyles.None;
            panelPeriod.BorderStyle = BorderStyle.FixedSingle;
            panelPeriod.Controls.Add(label10);
            panelPeriod.Controls.Add(comboBoxPeriod);
            panelPeriod.Controls.Add(dateTimePickerYear);
            panelPeriod.Controls.Add(label3);
            panelPeriod.Controls.Add(label2);
            panelPeriod.Controls.Add(label1);
            panelPeriod.Controls.Add(dateTimePickerEndDate);
            panelPeriod.Controls.Add(dateTimePickerStartDate);
            panelPeriod.Location = new Point(3, 15);
            panelPeriod.Margin = new Padding(3, 2, 3, 2);
            panelPeriod.Name = "panelPeriod";
            panelPeriod.Size = new Size(496, 164);
            panelPeriod.TabIndex = 51;
            panelPeriod.DragEnter += panelPeriod_DragEnter;
            // 
            // panel4
            // 
            panel4.Dock = DockStyle.Bottom;
            panel4.Location = new Point(0, 592);
            panel4.Name = "panel4";
            panel4.Size = new Size(960, 8);
            panel4.TabIndex = 50;
            // 
            // PeriodRegister
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(960, 600);
            Controls.Add(pictureBox1);
            Controls.Add(panel4);
            Controls.Add(panel8);
            Controls.Add(label9);
            Controls.Add(panel3);
            Controls.Add(labelPeriod);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "PeriodRegister";
            Text = "PeriodRegister";
            Load += PeriodRegister_Load;
            DragEnter += PeriodRegister_DragEnter;
            MouseEnter += PeriodRegister_MouseEnter;
            Resize += PeriodRegister_Resize;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel6.ResumeLayout(false);
            panelList.ResumeLayout(false);
            panelList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            panelAsignatures.ResumeLayout(false);
            panelAsignatures.PerformLayout();
            panelPlus1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picturePlus1).EndInit();
            panelPlus2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picturePlus2).EndInit();
            panelPeriod.ResumeLayout(false);
            panelPeriod.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DateTimePicker dateTimePickerStartDate;
        private DateTimePicker dateTimePickerEndDate;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button buttonSave;
        private Label labelPeriod;
        private ComboBox comboBoxPeriod;
        private Label labelAsignature;
        private Label label4;
        private ComboBox comboBoxAsignature;
        private Button buttonAdd;
        private ListBox listBox;
        private Label label5;
        private Panel panel1;
        private Label labelPDF;
        private Label labelList;
        private Label label6;
        private Panel panel2;
        private Label labelPDFMat;
        private Panel panel3;
        private Panel panel6;
        private Panel panelList;
        private Label label9;
        private PictureBox pictureBox1;
        private Panel panel5;
        private Label label7;
        private PictureBox pictureBox2;
        private Panel panel7;
        private Label label8;
        private PictureBox pictureBox3;
        private Label label10;
        private DateTimePicker dateTimePickerYear;
        private Panel panel8;
        private Label label11;
        private Label label12;
        private Panel panelPeriod;
        private Panel panelAsignatures;
        private Panel panel4;
        private PictureBox picturePlus2;
        private Panel panelPlus2;
        private Panel panelPlus1;
        private PictureBox picturePlus1;
    }
}