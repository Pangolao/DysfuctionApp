namespace Dysfunction.GUI.Register
{
    partial class AsignatureEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AsignatureEdit));
            textBoxAsignature = new TextBox();
            label2 = new Label();
            textBoxTeacher = new TextBox();
            label3 = new Label();
            buttonEdit = new Button();
            textBoxGroup = new TextBox();
            label4 = new Label();
            labelAsignature = new Label();
            label6 = new Label();
            labelCode = new Label();
            comboBoxCode = new ComboBox();
            buttonDelete = new Button();
            panel1 = new Panel();
            label9 = new Label();
            pictureBox1 = new PictureBox();
            panel2 = new Panel();
            label1 = new Label();
            panel4 = new Panel();
            panel3 = new Panel();
            panel5 = new Panel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // textBoxAsignature
            // 
            textBoxAsignature.Anchor = AnchorStyles.Top;
            textBoxAsignature.BackColor = Color.Black;
            textBoxAsignature.BorderStyle = BorderStyle.FixedSingle;
            textBoxAsignature.Enabled = false;
            textBoxAsignature.ForeColor = Color.White;
            textBoxAsignature.Location = new Point(34, 79);
            textBoxAsignature.Margin = new Padding(3, 2, 3, 2);
            textBoxAsignature.Name = "textBoxAsignature";
            textBoxAsignature.PlaceholderText = "If u can";
            textBoxAsignature.Size = new Size(414, 23);
            textBoxAsignature.TabIndex = 2;
            textBoxAsignature.Click += textBoxAsignature_Click;
            textBoxAsignature.TextChanged += textBoxAsignature_TextChanged;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.AutoSize = true;
            label2.ForeColor = Color.White;
            label2.Location = new Point(35, 62);
            label2.Name = "label2";
            label2.Size = new Size(97, 15);
            label2.TabIndex = 3;
            label2.Text = "Asignature name";
            // 
            // textBoxTeacher
            // 
            textBoxTeacher.Anchor = AnchorStyles.Top;
            textBoxTeacher.BackColor = Color.Black;
            textBoxTeacher.BorderStyle = BorderStyle.FixedSingle;
            textBoxTeacher.Enabled = false;
            textBoxTeacher.ForeColor = Color.White;
            textBoxTeacher.Location = new Point(34, 125);
            textBoxTeacher.Margin = new Padding(3, 2, 3, 2);
            textBoxTeacher.Name = "textBoxTeacher";
            textBoxTeacher.PlaceholderText = "Optional";
            textBoxTeacher.Size = new Size(414, 23);
            textBoxTeacher.TabIndex = 4;
            textBoxTeacher.Click += textBoxTeacher_Click;
            textBoxTeacher.TextChanged += textBoxTeacher_TextChanged;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top;
            label3.AutoSize = true;
            label3.ForeColor = Color.White;
            label3.Location = new Point(35, 108);
            label3.Name = "label3";
            label3.Size = new Size(48, 15);
            label3.TabIndex = 5;
            label3.Text = "Teacher";
            // 
            // buttonEdit
            // 
            buttonEdit.Anchor = AnchorStyles.Top;
            buttonEdit.FlatAppearance.BorderColor = Color.FromArgb(64, 64, 64);
            buttonEdit.FlatAppearance.MouseDownBackColor = Color.FromArgb(20, 20, 20);
            buttonEdit.FlatAppearance.MouseOverBackColor = Color.FromArgb(20, 20, 20);
            buttonEdit.FlatStyle = FlatStyle.Flat;
            buttonEdit.ForeColor = Color.White;
            buttonEdit.Location = new Point(136, 213);
            buttonEdit.Margin = new Padding(3, 2, 3, 2);
            buttonEdit.Name = "buttonEdit";
            buttonEdit.Size = new Size(212, 30);
            buttonEdit.TabIndex = 26;
            buttonEdit.Text = "Save Edit";
            buttonEdit.UseVisualStyleBackColor = true;
            buttonEdit.Click += buttonSaveEdit_Click;
            // 
            // textBoxGroup
            // 
            textBoxGroup.Anchor = AnchorStyles.Top;
            textBoxGroup.BackColor = Color.Black;
            textBoxGroup.BorderStyle = BorderStyle.FixedSingle;
            textBoxGroup.Enabled = false;
            textBoxGroup.ForeColor = Color.White;
            textBoxGroup.Location = new Point(34, 177);
            textBoxGroup.Margin = new Padding(3, 2, 3, 2);
            textBoxGroup.Name = "textBoxGroup";
            textBoxGroup.PlaceholderText = "Optional";
            textBoxGroup.Size = new Size(414, 23);
            textBoxGroup.TabIndex = 11;
            textBoxGroup.Click += textBoxGroup_Click;
            textBoxGroup.TextChanged += textBoxGroup_TextChanged;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top;
            label4.AutoSize = true;
            label4.ForeColor = Color.White;
            label4.Location = new Point(35, 155);
            label4.Name = "label4";
            label4.Size = new Size(40, 15);
            label4.TabIndex = 12;
            label4.Text = "Group";
            // 
            // labelAsignature
            // 
            labelAsignature.Anchor = AnchorStyles.Top;
            labelAsignature.AutoSize = true;
            labelAsignature.BackColor = Color.Black;
            labelAsignature.Font = new Font("Arial Narrow", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            labelAsignature.ForeColor = Color.White;
            labelAsignature.Location = new Point(4, 79);
            labelAsignature.Name = "labelAsignature";
            labelAsignature.Size = new Size(14, 23);
            labelAsignature.TabIndex = 14;
            labelAsignature.Text = "!";
            labelAsignature.Visible = false;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top;
            label6.AutoSize = true;
            label6.ForeColor = Color.White;
            label6.Location = new Point(35, 15);
            label6.Name = "label6";
            label6.Size = new Size(35, 15);
            label6.TabIndex = 19;
            label6.Text = "Code";
            // 
            // labelCode
            // 
            labelCode.Anchor = AnchorStyles.Top;
            labelCode.AutoSize = true;
            labelCode.BackColor = Color.Black;
            labelCode.Font = new Font("Arial Narrow", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            labelCode.ForeColor = Color.White;
            labelCode.Location = new Point(4, 33);
            labelCode.Name = "labelCode";
            labelCode.Size = new Size(14, 23);
            labelCode.TabIndex = 20;
            labelCode.Text = "!";
            // 
            // comboBoxCode
            // 
            comboBoxCode.Anchor = AnchorStyles.Top;
            comboBoxCode.BackColor = Color.White;
            comboBoxCode.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCode.ForeColor = Color.Black;
            comboBoxCode.FormattingEnabled = true;
            comboBoxCode.Location = new Point(34, 32);
            comboBoxCode.Margin = new Padding(3, 2, 3, 2);
            comboBoxCode.Name = "comboBoxCode";
            comboBoxCode.Size = new Size(414, 23);
            comboBoxCode.TabIndex = 25;
            comboBoxCode.SelectedIndexChanged += comboBoxCode_SelectedIndexChanged;
            // 
            // buttonDelete
            // 
            buttonDelete.Anchor = AnchorStyles.Top;
            buttonDelete.FlatAppearance.BorderColor = Color.FromArgb(64, 64, 64);
            buttonDelete.FlatAppearance.MouseDownBackColor = Color.FromArgb(20, 20, 20);
            buttonDelete.FlatAppearance.MouseOverBackColor = Color.FromArgb(20, 20, 20);
            buttonDelete.FlatStyle = FlatStyle.Flat;
            buttonDelete.ForeColor = Color.White;
            buttonDelete.Location = new Point(136, 248);
            buttonDelete.Margin = new Padding(3, 2, 3, 2);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(212, 30);
            buttonDelete.TabIndex = 26;
            buttonDelete.Text = "Delete";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // panel1
            // 
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(960, 7);
            panel1.TabIndex = 27;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label9.ForeColor = Color.White;
            label9.Location = new Point(10, 7);
            label9.Name = "label9";
            label9.Size = new Size(145, 28);
            label9.TabIndex = 45;
            label9.Text = "Edit Asignature";
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(10, 41);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(38, 32);
            pictureBox1.TabIndex = 44;
            pictureBox1.TabStop = false;
            pictureBox1.MouseDown += pictureBox1_MouseDown;
            pictureBox1.MouseEnter += pictureBox1_MouseEnter;
            pictureBox1.MouseLeave += pictureBox1_MouseLeave;
            // 
            // panel2
            // 
            panel2.Controls.Add(label1);
            panel2.Controls.Add(panel4);
            panel2.Controls.Add(panel3);
            panel2.Location = new Point(234, 90);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(492, 339);
            panel2.TabIndex = 46;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(39, 15);
            label1.Name = "label1";
            label1.Size = new Size(201, 25);
            label1.TabIndex = 45;
            label1.Text = " Asignature Information";
            // 
            // panel4
            // 
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Controls.Add(buttonDelete);
            panel4.Controls.Add(comboBoxCode);
            panel4.Controls.Add(buttonEdit);
            panel4.Controls.Add(textBoxTeacher);
            panel4.Controls.Add(label3);
            panel4.Controls.Add(textBoxGroup);
            panel4.Controls.Add(label4);
            panel4.Controls.Add(textBoxAsignature);
            panel4.Controls.Add(label2);
            panel4.Controls.Add(labelAsignature);
            panel4.Controls.Add(labelCode);
            panel4.Controls.Add(label6);
            panel4.Location = new Point(3, 34);
            panel4.Name = "panel4";
            panel4.Size = new Size(484, 291);
            panel4.TabIndex = 47;
            // 
            // panel3
            // 
            panel3.Dock = DockStyle.Bottom;
            panel3.Location = new Point(0, 331);
            panel3.Name = "panel3";
            panel3.Size = new Size(492, 8);
            panel3.TabIndex = 46;
            // 
            // panel5
            // 
            panel5.Dock = DockStyle.Bottom;
            panel5.Location = new Point(0, 592);
            panel5.Name = "panel5";
            panel5.Size = new Size(960, 8);
            panel5.TabIndex = 47;
            // 
            // AsignatureEdit
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(960, 600);
            Controls.Add(panel5);
            Controls.Add(panel2);
            Controls.Add(label9);
            Controls.Add(pictureBox1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "AsignatureEdit";
            Text = "AsignatureRegister";
            MouseEnter += AsignatureEdit_MouseEnter;
            Resize += AsignatureEdit_Resize;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxAsignature;
        private Label label2;
        private TextBox textBoxTeacher;
        private Label label3;
        private Button buttonEdit;
        private TextBox textBoxGroup;
        private Label label4;
        private Label labelAsignature;
        private Label label6;
        private Label labelCode;
        private ComboBox comboBoxCode;
        private Button buttonDelete;
        private Panel panel1;
        private Label label9;
        private PictureBox pictureBox1;
        private Panel panel2;
        private Label label1;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
    }
}