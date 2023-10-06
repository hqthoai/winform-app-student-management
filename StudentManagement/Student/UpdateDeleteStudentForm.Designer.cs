namespace StudentManagement
{
    partial class UpdateDeleteStudentForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateDeleteStudentForm));
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.comboBoxDpt = new System.Windows.Forms.ComboBox();
            this.textBoxMajor = new System.Windows.Forms.TextBox();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.pictureBoxSt = new System.Windows.Forms.PictureBox();
            this.textBoxAdrs = new System.Windows.Forms.TextBox();
            this.textBoxPhone = new System.Windows.Forms.TextBox();
            this.buttonUpload = new System.Windows.Forms.Button();
            this.groupBoxGender = new System.Windows.Forms.GroupBox();
            this.radioButtonFemale = new System.Windows.Forms.RadioButton();
            this.radioButtonMale = new System.Windows.Forms.RadioButton();
            this.dateTimePickerBday = new System.Windows.Forms.DateTimePicker();
            this.textBoxLN = new System.Windows.Forms.TextBox();
            this.textBoxFN = new System.Windows.Forms.TextBox();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.labelMajor = new System.Windows.Forms.Label();
            this.labelDpt = new System.Windows.Forms.Label();
            this.labelEmail = new System.Windows.Forms.Label();
            this.labelPic = new System.Windows.Forms.Label();
            this.labelAdrs = new System.Windows.Forms.Label();
            this.labelPhone = new System.Windows.Forms.Label();
            this.labelGender = new System.Windows.Forms.Label();
            this.labelBDay = new System.Windows.Forms.Label();
            this.labelLN = new System.Windows.Forms.Label();
            this.labelFN = new System.Windows.Forms.Label();
            this.labelID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxHometown = new System.Windows.Forms.TextBox();
            this.buttonAddCourse = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSt)).BeginInit();
            this.groupBoxGender.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.BackColor = System.Drawing.Color.Lime;
            this.buttonUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonUpdate.Location = new System.Drawing.Point(796, 476);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(159, 46);
            this.buttonUpdate.TabIndex = 79;
            this.buttonUpdate.Text = "Update";
            this.buttonUpdate.UseVisualStyleBackColor = false;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // buttonRemove
            // 
            this.buttonRemove.BackColor = System.Drawing.Color.Red;
            this.buttonRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRemove.Location = new System.Drawing.Point(621, 476);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(159, 46);
            this.buttonRemove.TabIndex = 77;
            this.buttonRemove.Text = "Remove";
            this.buttonRemove.UseVisualStyleBackColor = false;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // comboBoxDpt
            // 
            this.comboBoxDpt.ForeColor = System.Drawing.SystemColors.WindowText;
            this.comboBoxDpt.FormattingEnabled = true;
            this.comboBoxDpt.Items.AddRange(new object[] {
            "FACULTY FOR HIGH QUALITY TRAINING",
            "FACULTY OF INFORMATION TECHNOLOGY",
            "FACULTY OF ENGINEERING ",
            "FACULTY OF ECONOMICS",
            "FACULTY OF FASHION AND TOURISM"});
            this.comboBoxDpt.Location = new System.Drawing.Point(662, 299);
            this.comboBoxDpt.Name = "comboBoxDpt";
            this.comboBoxDpt.Size = new System.Drawing.Size(293, 24);
            this.comboBoxDpt.TabIndex = 76;
            this.comboBoxDpt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBoxDpt_KeyDown);
            // 
            // textBoxMajor
            // 
            this.textBoxMajor.Location = new System.Drawing.Point(662, 352);
            this.textBoxMajor.Name = "textBoxMajor";
            this.textBoxMajor.Size = new System.Drawing.Size(293, 22);
            this.textBoxMajor.TabIndex = 75;
            this.textBoxMajor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxMajor_KeyPress);
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(163, 275);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(293, 22);
            this.textBoxEmail.TabIndex = 74;
            // 
            // pictureBoxSt
            // 
            this.pictureBoxSt.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBoxSt.Location = new System.Drawing.Point(662, 10);
            this.pictureBoxSt.Name = "pictureBoxSt";
            this.pictureBoxSt.Size = new System.Drawing.Size(293, 233);
            this.pictureBoxSt.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxSt.TabIndex = 73;
            this.pictureBoxSt.TabStop = false;
            // 
            // textBoxAdrs
            // 
            this.textBoxAdrs.Location = new System.Drawing.Point(162, 332);
            this.textBoxAdrs.Multiline = true;
            this.textBoxAdrs.Name = "textBoxAdrs";
            this.textBoxAdrs.Size = new System.Drawing.Size(293, 82);
            this.textBoxAdrs.TabIndex = 72;
            // 
            // textBoxPhone
            // 
            this.textBoxPhone.Location = new System.Drawing.Point(163, 230);
            this.textBoxPhone.Name = "textBoxPhone";
            this.textBoxPhone.Size = new System.Drawing.Size(293, 22);
            this.textBoxPhone.TabIndex = 71;
            this.textBoxPhone.TextChanged += new System.EventHandler(this.textBoxPhone_TextChanged);
            // 
            // buttonUpload
            // 
            this.buttonUpload.BackColor = System.Drawing.SystemColors.Info;
            this.buttonUpload.Location = new System.Drawing.Point(662, 249);
            this.buttonUpload.Name = "buttonUpload";
            this.buttonUpload.Size = new System.Drawing.Size(293, 29);
            this.buttonUpload.TabIndex = 78;
            this.buttonUpload.Text = "Upload Image";
            this.buttonUpload.UseVisualStyleBackColor = false;
            this.buttonUpload.Click += new System.EventHandler(this.buttonUpload_Click);
            // 
            // groupBoxGender
            // 
            this.groupBoxGender.Controls.Add(this.radioButtonFemale);
            this.groupBoxGender.Controls.Add(this.radioButtonMale);
            this.groupBoxGender.Location = new System.Drawing.Point(163, 174);
            this.groupBoxGender.Name = "groupBoxGender";
            this.groupBoxGender.Size = new System.Drawing.Size(289, 39);
            this.groupBoxGender.TabIndex = 70;
            this.groupBoxGender.TabStop = false;
            // 
            // radioButtonFemale
            // 
            this.radioButtonFemale.AutoSize = true;
            this.radioButtonFemale.Location = new System.Drawing.Point(177, 13);
            this.radioButtonFemale.Name = "radioButtonFemale";
            this.radioButtonFemale.Size = new System.Drawing.Size(74, 20);
            this.radioButtonFemale.TabIndex = 1;
            this.radioButtonFemale.TabStop = true;
            this.radioButtonFemale.Text = "Female";
            this.radioButtonFemale.UseVisualStyleBackColor = true;
            // 
            // radioButtonMale
            // 
            this.radioButtonMale.AutoSize = true;
            this.radioButtonMale.Location = new System.Drawing.Point(40, 13);
            this.radioButtonMale.Name = "radioButtonMale";
            this.radioButtonMale.Size = new System.Drawing.Size(58, 20);
            this.radioButtonMale.TabIndex = 0;
            this.radioButtonMale.TabStop = true;
            this.radioButtonMale.Text = "Male";
            this.radioButtonMale.UseVisualStyleBackColor = true;
            // 
            // dateTimePickerBday
            // 
            this.dateTimePickerBday.CustomFormat = "dd--MM-yyyy";
            this.dateTimePickerBday.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerBday.Location = new System.Drawing.Point(163, 132);
            this.dateTimePickerBday.MaxDate = new System.DateTime(9998, 12, 30, 0, 0, 0, 0);
            this.dateTimePickerBday.Name = "dateTimePickerBday";
            this.dateTimePickerBday.Size = new System.Drawing.Size(289, 22);
            this.dateTimePickerBday.TabIndex = 69;
            this.dateTimePickerBday.Value = new System.DateTime(2023, 2, 28, 0, 0, 0, 0);
            // 
            // textBoxLN
            // 
            this.textBoxLN.Location = new System.Drawing.Point(160, 94);
            this.textBoxLN.Name = "textBoxLN";
            this.textBoxLN.Size = new System.Drawing.Size(293, 22);
            this.textBoxLN.TabIndex = 68;
            this.textBoxLN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxLN_KeyPress);
            // 
            // textBoxFN
            // 
            this.textBoxFN.Location = new System.Drawing.Point(162, 53);
            this.textBoxFN.Name = "textBoxFN";
            this.textBoxFN.Size = new System.Drawing.Size(293, 22);
            this.textBoxFN.TabIndex = 67;
            this.textBoxFN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxFN_KeyPress);
            // 
            // textBoxID
            // 
            this.textBoxID.Location = new System.Drawing.Point(162, 11);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.ReadOnly = true;
            this.textBoxID.Size = new System.Drawing.Size(293, 22);
            this.textBoxID.TabIndex = 66;
            // 
            // labelMajor
            // 
            this.labelMajor.AutoSize = true;
            this.labelMajor.BackColor = System.Drawing.Color.Transparent;
            this.labelMajor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMajor.ForeColor = System.Drawing.Color.White;
            this.labelMajor.Location = new System.Drawing.Point(537, 352);
            this.labelMajor.Name = "labelMajor";
            this.labelMajor.Size = new System.Drawing.Size(64, 22);
            this.labelMajor.TabIndex = 65;
            this.labelMajor.Text = "Major :";
            // 
            // labelDpt
            // 
            this.labelDpt.AutoSize = true;
            this.labelDpt.BackColor = System.Drawing.Color.Transparent;
            this.labelDpt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDpt.ForeColor = System.Drawing.Color.White;
            this.labelDpt.Location = new System.Drawing.Point(535, 301);
            this.labelDpt.Name = "labelDpt";
            this.labelDpt.Size = new System.Drawing.Size(108, 22);
            this.labelDpt.TabIndex = 64;
            this.labelDpt.Text = "Department:";
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.BackColor = System.Drawing.Color.Transparent;
            this.labelEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEmail.ForeColor = System.Drawing.Color.White;
            this.labelEmail.Location = new System.Drawing.Point(42, 277);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(64, 22);
            this.labelEmail.TabIndex = 63;
            this.labelEmail.Text = "Email :";
            // 
            // labelPic
            // 
            this.labelPic.AutoSize = true;
            this.labelPic.BackColor = System.Drawing.Color.Transparent;
            this.labelPic.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPic.ForeColor = System.Drawing.Color.White;
            this.labelPic.Location = new System.Drawing.Point(536, 11);
            this.labelPic.Name = "labelPic";
            this.labelPic.Size = new System.Drawing.Size(76, 22);
            this.labelPic.TabIndex = 62;
            this.labelPic.Text = "Picture :";
            // 
            // labelAdrs
            // 
            this.labelAdrs.AutoSize = true;
            this.labelAdrs.BackColor = System.Drawing.Color.Transparent;
            this.labelAdrs.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAdrs.ForeColor = System.Drawing.Color.White;
            this.labelAdrs.Location = new System.Drawing.Point(41, 338);
            this.labelAdrs.Name = "labelAdrs";
            this.labelAdrs.Size = new System.Drawing.Size(86, 22);
            this.labelAdrs.TabIndex = 61;
            this.labelAdrs.Text = "Address :";
            // 
            // labelPhone
            // 
            this.labelPhone.AutoSize = true;
            this.labelPhone.BackColor = System.Drawing.Color.Transparent;
            this.labelPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPhone.ForeColor = System.Drawing.Color.White;
            this.labelPhone.Location = new System.Drawing.Point(42, 232);
            this.labelPhone.Name = "labelPhone";
            this.labelPhone.Size = new System.Drawing.Size(67, 22);
            this.labelPhone.TabIndex = 60;
            this.labelPhone.Text = "Phone:";
            // 
            // labelGender
            // 
            this.labelGender.AutoSize = true;
            this.labelGender.BackColor = System.Drawing.Color.Transparent;
            this.labelGender.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGender.ForeColor = System.Drawing.Color.White;
            this.labelGender.Location = new System.Drawing.Point(42, 186);
            this.labelGender.Name = "labelGender";
            this.labelGender.Size = new System.Drawing.Size(80, 22);
            this.labelGender.TabIndex = 59;
            this.labelGender.Text = "Gender :";
            // 
            // labelBDay
            // 
            this.labelBDay.AutoSize = true;
            this.labelBDay.BackColor = System.Drawing.Color.Transparent;
            this.labelBDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBDay.ForeColor = System.Drawing.Color.White;
            this.labelBDay.Location = new System.Drawing.Point(42, 134);
            this.labelBDay.Name = "labelBDay";
            this.labelBDay.Size = new System.Drawing.Size(95, 22);
            this.labelBDay.TabIndex = 58;
            this.labelBDay.Text = "BirthDate :";
            // 
            // labelLN
            // 
            this.labelLN.AutoSize = true;
            this.labelLN.BackColor = System.Drawing.Color.Transparent;
            this.labelLN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLN.ForeColor = System.Drawing.Color.White;
            this.labelLN.Location = new System.Drawing.Point(42, 96);
            this.labelLN.Name = "labelLN";
            this.labelLN.Size = new System.Drawing.Size(96, 22);
            this.labelLN.TabIndex = 57;
            this.labelLN.Text = "LastName:";
            // 
            // labelFN
            // 
            this.labelFN.AutoSize = true;
            this.labelFN.BackColor = System.Drawing.Color.Transparent;
            this.labelFN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFN.ForeColor = System.Drawing.Color.White;
            this.labelFN.Location = new System.Drawing.Point(44, 59);
            this.labelFN.Name = "labelFN";
            this.labelFN.Size = new System.Drawing.Size(97, 22);
            this.labelFN.TabIndex = 56;
            this.labelFN.Text = "FirstName:";
            // 
            // labelID
            // 
            this.labelID.AutoSize = true;
            this.labelID.BackColor = System.Drawing.Color.Transparent;
            this.labelID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelID.ForeColor = System.Drawing.Color.White;
            this.labelID.Location = new System.Drawing.Point(41, 12);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(99, 22);
            this.labelID.TabIndex = 55;
            this.labelID.Text = "Student ID:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(535, 403);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 22);
            this.label1.TabIndex = 80;
            this.label1.Text = "Place of birth:";
            // 
            // textBoxHometown
            // 
            this.textBoxHometown.Location = new System.Drawing.Point(662, 403);
            this.textBoxHometown.Name = "textBoxHometown";
            this.textBoxHometown.Size = new System.Drawing.Size(293, 22);
            this.textBoxHometown.TabIndex = 81;
            // 
            // buttonAddCourse
            // 
            this.buttonAddCourse.BackColor = System.Drawing.Color.Aqua;
            this.buttonAddCourse.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddCourse.Location = new System.Drawing.Point(163, 476);
            this.buttonAddCourse.Name = "buttonAddCourse";
            this.buttonAddCourse.Size = new System.Drawing.Size(159, 46);
            this.buttonAddCourse.TabIndex = 82;
            this.buttonAddCourse.Text = "Add Course";
            this.buttonAddCourse.UseVisualStyleBackColor = false;
            this.buttonAddCourse.Click += new System.EventHandler(this.buttonAddCourse_Click);
            // 
            // UpdateDeleteStudentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(989, 558);
            this.Controls.Add(this.buttonAddCourse);
            this.Controls.Add(this.textBoxHometown);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.buttonRemove);
            this.Controls.Add(this.comboBoxDpt);
            this.Controls.Add(this.textBoxMajor);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.pictureBoxSt);
            this.Controls.Add(this.textBoxAdrs);
            this.Controls.Add(this.textBoxPhone);
            this.Controls.Add(this.buttonUpload);
            this.Controls.Add(this.groupBoxGender);
            this.Controls.Add(this.dateTimePickerBday);
            this.Controls.Add(this.textBoxLN);
            this.Controls.Add(this.textBoxFN);
            this.Controls.Add(this.textBoxID);
            this.Controls.Add(this.labelMajor);
            this.Controls.Add(this.labelDpt);
            this.Controls.Add(this.labelEmail);
            this.Controls.Add(this.labelPic);
            this.Controls.Add(this.labelAdrs);
            this.Controls.Add(this.labelPhone);
            this.Controls.Add(this.labelGender);
            this.Controls.Add(this.labelBDay);
            this.Controls.Add(this.labelLN);
            this.Controls.Add(this.labelFN);
            this.Controls.Add(this.labelID);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UpdateDeleteStudentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UpdateDeleteStudentForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSt)).EndInit();
            this.groupBoxGender.ResumeLayout(false);
            this.groupBoxGender.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonUpload;
        private System.Windows.Forms.GroupBox groupBoxGender;
        private System.Windows.Forms.Label labelMajor;
        private System.Windows.Forms.Label labelDpt;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.Label labelPic;
        private System.Windows.Forms.Label labelAdrs;
        private System.Windows.Forms.Label labelPhone;
        private System.Windows.Forms.Label labelGender;
        private System.Windows.Forms.Label labelBDay;
        private System.Windows.Forms.Label labelLN;
        private System.Windows.Forms.Label labelFN;
        private System.Windows.Forms.Label labelID;
        internal System.Windows.Forms.ComboBox comboBoxDpt;
        internal System.Windows.Forms.TextBox textBoxMajor;
        internal System.Windows.Forms.TextBox textBoxEmail;
        internal System.Windows.Forms.TextBox textBoxAdrs;
        internal System.Windows.Forms.TextBox textBoxPhone;
        internal System.Windows.Forms.RadioButton radioButtonFemale;
        internal System.Windows.Forms.RadioButton radioButtonMale;
        internal System.Windows.Forms.DateTimePicker dateTimePickerBday;
        internal System.Windows.Forms.TextBox textBoxLN;
        internal System.Windows.Forms.TextBox textBoxFN;
        internal System.Windows.Forms.TextBox textBoxID;
        internal System.Windows.Forms.PictureBox pictureBoxSt;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox textBoxHometown;
        private System.Windows.Forms.Button buttonAddCourse;
        internal System.Windows.Forms.Button buttonRemove;
    }
}