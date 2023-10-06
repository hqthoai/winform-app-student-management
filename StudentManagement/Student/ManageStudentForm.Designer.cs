namespace StudentManagement
{
    partial class ManageStudentForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageStudentForm));
            this.textBoxHometown = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.comboBoxDpt = new System.Windows.Forms.ComboBox();
            this.textBoxMajor = new System.Windows.Forms.TextBox();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
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
            this.pictureBoxSt = new System.Windows.Forms.PictureBox();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.buttonDownload = new System.Windows.Forms.Button();
            this.dataGridViewManagement = new System.Windows.Forms.DataGridView();
            this.mssvDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firstnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bdayDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.genderDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phoneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addressDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pictureDataGridViewImageColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.departmentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.majorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hometownDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.selectedCourse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.studentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.qLSVStudent = new StudentManagement.QLSVStudent();
            this.studentBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.qLSVnewBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.qLSVnew = new StudentManagement.QLSVnew();
            this.labelTotal = new System.Windows.Forms.Label();
            this.studentBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.studentTableAdapter1 = new StudentManagement.QLSVnewTableAdapters.StudentTableAdapter();
            this.studentTableAdapter = new StudentManagement.QLSVStudentTableAdapters.StudentTableAdapter();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.groupBoxGender.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewManagement)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLSVStudent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLSVnewBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLSVnew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxHometown
            // 
            this.textBoxHometown.Location = new System.Drawing.Point(152, 548);
            this.textBoxHometown.Name = "textBoxHometown";
            this.textBoxHometown.Size = new System.Drawing.Size(293, 22);
            this.textBoxHometown.TabIndex = 82;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(31, 548);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 20);
            this.label1.TabIndex = 81;
            this.label1.Text = "Place of birth";
            // 
            // buttonAdd
            // 
            this.buttonAdd.BackColor = System.Drawing.Color.Lime;
            this.buttonAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAdd.ForeColor = System.Drawing.Color.Black;
            this.buttonAdd.Location = new System.Drawing.Point(34, 632);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(133, 43);
            this.buttonAdd.TabIndex = 80;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = false;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
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
            this.comboBoxDpt.Location = new System.Drawing.Point(152, 587);
            this.comboBoxDpt.Name = "comboBoxDpt";
            this.comboBoxDpt.Size = new System.Drawing.Size(293, 24);
            this.comboBoxDpt.TabIndex = 77;
            // 
            // textBoxMajor
            // 
            this.textBoxMajor.Location = new System.Drawing.Point(151, 506);
            this.textBoxMajor.Name = "textBoxMajor";
            this.textBoxMajor.Size = new System.Drawing.Size(294, 22);
            this.textBoxMajor.TabIndex = 78;
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(151, 230);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(293, 22);
            this.textBoxEmail.TabIndex = 73;
            // 
            // textBoxAdrs
            // 
            this.textBoxAdrs.Location = new System.Drawing.Point(152, 268);
            this.textBoxAdrs.Multiline = true;
            this.textBoxAdrs.Name = "textBoxAdrs";
            this.textBoxAdrs.Size = new System.Drawing.Size(293, 82);
            this.textBoxAdrs.TabIndex = 74;
            // 
            // textBoxPhone
            // 
            this.textBoxPhone.Location = new System.Drawing.Point(152, 196);
            this.textBoxPhone.Name = "textBoxPhone";
            this.textBoxPhone.Size = new System.Drawing.Size(293, 22);
            this.textBoxPhone.TabIndex = 72;
            // 
            // buttonUpload
            // 
            this.buttonUpload.BackColor = System.Drawing.SystemColors.Info;
            this.buttonUpload.Location = new System.Drawing.Point(152, 462);
            this.buttonUpload.Name = "buttonUpload";
            this.buttonUpload.Size = new System.Drawing.Size(120, 29);
            this.buttonUpload.TabIndex = 76;
            this.buttonUpload.Text = "Upload Image";
            this.buttonUpload.UseVisualStyleBackColor = false;
            this.buttonUpload.Click += new System.EventHandler(this.buttonUpload_Click);
            // 
            // groupBoxGender
            // 
            this.groupBoxGender.Controls.Add(this.radioButtonFemale);
            this.groupBoxGender.Controls.Add(this.radioButtonMale);
            this.groupBoxGender.Location = new System.Drawing.Point(152, 142);
            this.groupBoxGender.Name = "groupBoxGender";
            this.groupBoxGender.Size = new System.Drawing.Size(289, 39);
            this.groupBoxGender.TabIndex = 71;
            this.groupBoxGender.TabStop = false;
            // 
            // radioButtonFemale
            // 
            this.radioButtonFemale.AutoSize = true;
            this.radioButtonFemale.Location = new System.Drawing.Point(177, 13);
            this.radioButtonFemale.Name = "radioButtonFemale";
            this.radioButtonFemale.Size = new System.Drawing.Size(74, 20);
            this.radioButtonFemale.TabIndex = 2;
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
            this.radioButtonMale.TabIndex = 1;
            this.radioButtonMale.TabStop = true;
            this.radioButtonMale.Text = "Male";
            this.radioButtonMale.UseVisualStyleBackColor = true;
            // 
            // dateTimePickerBday
            // 
            this.dateTimePickerBday.CustomFormat = "dd--MM--yyyy";
            this.dateTimePickerBday.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerBday.Location = new System.Drawing.Point(148, 113);
            this.dateTimePickerBday.Name = "dateTimePickerBday";
            this.dateTimePickerBday.Size = new System.Drawing.Size(297, 22);
            this.dateTimePickerBday.TabIndex = 70;
            this.dateTimePickerBday.Value = new System.DateTime(2023, 2, 28, 0, 0, 0, 0);
            // 
            // textBoxLN
            // 
            this.textBoxLN.Location = new System.Drawing.Point(148, 79);
            this.textBoxLN.Name = "textBoxLN";
            this.textBoxLN.Size = new System.Drawing.Size(293, 22);
            this.textBoxLN.TabIndex = 69;
            // 
            // textBoxFN
            // 
            this.textBoxFN.Location = new System.Drawing.Point(148, 45);
            this.textBoxFN.Name = "textBoxFN";
            this.textBoxFN.Size = new System.Drawing.Size(293, 22);
            this.textBoxFN.TabIndex = 68;
            // 
            // textBoxID
            // 
            this.textBoxID.Location = new System.Drawing.Point(148, 12);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.Size = new System.Drawing.Size(293, 22);
            this.textBoxID.TabIndex = 67;
            // 
            // labelMajor
            // 
            this.labelMajor.AutoSize = true;
            this.labelMajor.BackColor = System.Drawing.Color.Transparent;
            this.labelMajor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMajor.ForeColor = System.Drawing.Color.White;
            this.labelMajor.Location = new System.Drawing.Point(31, 506);
            this.labelMajor.Name = "labelMajor";
            this.labelMajor.Size = new System.Drawing.Size(51, 20);
            this.labelMajor.TabIndex = 66;
            this.labelMajor.Text = "Major";
            // 
            // labelDpt
            // 
            this.labelDpt.AutoSize = true;
            this.labelDpt.BackColor = System.Drawing.Color.Transparent;
            this.labelDpt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDpt.ForeColor = System.Drawing.Color.White;
            this.labelDpt.Location = new System.Drawing.Point(30, 591);
            this.labelDpt.Name = "labelDpt";
            this.labelDpt.Size = new System.Drawing.Size(102, 20);
            this.labelDpt.TabIndex = 65;
            this.labelDpt.Text = "Department:";
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.BackColor = System.Drawing.Color.Transparent;
            this.labelEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEmail.ForeColor = System.Drawing.Color.White;
            this.labelEmail.Location = new System.Drawing.Point(23, 232);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(51, 20);
            this.labelEmail.TabIndex = 64;
            this.labelEmail.Text = "Email";
            // 
            // labelPic
            // 
            this.labelPic.AutoSize = true;
            this.labelPic.BackColor = System.Drawing.Color.Transparent;
            this.labelPic.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPic.ForeColor = System.Drawing.Color.White;
            this.labelPic.Location = new System.Drawing.Point(29, 383);
            this.labelPic.Name = "labelPic";
            this.labelPic.Size = new System.Drawing.Size(67, 20);
            this.labelPic.TabIndex = 63;
            this.labelPic.Text = "Picture:";
            // 
            // labelAdrs
            // 
            this.labelAdrs.AutoSize = true;
            this.labelAdrs.BackColor = System.Drawing.Color.Transparent;
            this.labelAdrs.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAdrs.ForeColor = System.Drawing.Color.White;
            this.labelAdrs.Location = new System.Drawing.Point(29, 281);
            this.labelAdrs.Name = "labelAdrs";
            this.labelAdrs.Size = new System.Drawing.Size(71, 20);
            this.labelAdrs.TabIndex = 62;
            this.labelAdrs.Text = "Address";
            // 
            // labelPhone
            // 
            this.labelPhone.AutoSize = true;
            this.labelPhone.BackColor = System.Drawing.Color.Transparent;
            this.labelPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPhone.ForeColor = System.Drawing.Color.White;
            this.labelPhone.Location = new System.Drawing.Point(24, 196);
            this.labelPhone.Name = "labelPhone";
            this.labelPhone.Size = new System.Drawing.Size(61, 20);
            this.labelPhone.TabIndex = 61;
            this.labelPhone.Text = "Phone:";
            // 
            // labelGender
            // 
            this.labelGender.AutoSize = true;
            this.labelGender.BackColor = System.Drawing.Color.Transparent;
            this.labelGender.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGender.ForeColor = System.Drawing.Color.White;
            this.labelGender.Location = new System.Drawing.Point(24, 145);
            this.labelGender.Name = "labelGender";
            this.labelGender.Size = new System.Drawing.Size(64, 20);
            this.labelGender.TabIndex = 60;
            this.labelGender.Text = "Gender";
            // 
            // labelBDay
            // 
            this.labelBDay.AutoSize = true;
            this.labelBDay.BackColor = System.Drawing.Color.Transparent;
            this.labelBDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBDay.ForeColor = System.Drawing.Color.White;
            this.labelBDay.Location = new System.Drawing.Point(24, 115);
            this.labelBDay.Name = "labelBDay";
            this.labelBDay.Size = new System.Drawing.Size(81, 20);
            this.labelBDay.TabIndex = 59;
            this.labelBDay.Text = "BirthDate";
            // 
            // labelLN
            // 
            this.labelLN.AutoSize = true;
            this.labelLN.BackColor = System.Drawing.Color.Transparent;
            this.labelLN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLN.ForeColor = System.Drawing.Color.White;
            this.labelLN.Location = new System.Drawing.Point(24, 81);
            this.labelLN.Name = "labelLN";
            this.labelLN.Size = new System.Drawing.Size(86, 20);
            this.labelLN.TabIndex = 58;
            this.labelLN.Text = "LastName";
            // 
            // labelFN
            // 
            this.labelFN.AutoSize = true;
            this.labelFN.BackColor = System.Drawing.Color.Transparent;
            this.labelFN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFN.ForeColor = System.Drawing.Color.White;
            this.labelFN.Location = new System.Drawing.Point(24, 47);
            this.labelFN.Name = "labelFN";
            this.labelFN.Size = new System.Drawing.Size(87, 20);
            this.labelFN.TabIndex = 57;
            this.labelFN.Text = "FirstName";
            // 
            // labelID
            // 
            this.labelID.AutoSize = true;
            this.labelID.BackColor = System.Drawing.Color.Transparent;
            this.labelID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelID.ForeColor = System.Drawing.Color.White;
            this.labelID.Location = new System.Drawing.Point(24, 12);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(93, 20);
            this.labelID.TabIndex = 56;
            this.labelID.Text = "Student ID:";
            // 
            // pictureBoxSt
            // 
            this.pictureBoxSt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.pictureBoxSt.Location = new System.Drawing.Point(152, 376);
            this.pictureBoxSt.Name = "pictureBoxSt";
            this.pictureBoxSt.Size = new System.Drawing.Size(293, 80);
            this.pictureBoxSt.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxSt.TabIndex = 75;
            this.pictureBoxSt.TabStop = false;
            // 
            // buttonEdit
            // 
            this.buttonEdit.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.buttonEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEdit.ForeColor = System.Drawing.Color.White;
            this.buttonEdit.Location = new System.Drawing.Point(230, 632);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(126, 43);
            this.buttonEdit.TabIndex = 83;
            this.buttonEdit.Text = "Edit";
            this.buttonEdit.UseVisualStyleBackColor = false;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonReset
            // 
            this.buttonReset.BackColor = System.Drawing.Color.Navy;
            this.buttonReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonReset.ForeColor = System.Drawing.Color.White;
            this.buttonReset.Location = new System.Drawing.Point(605, 632);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(132, 43);
            this.buttonReset.TabIndex = 85;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = false;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(532, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(306, 25);
            this.label2.TabIndex = 86;
            this.label2.Text = "Search FName, LName, Address:";
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSearch.Location = new System.Drawing.Point(859, 16);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(260, 30);
            this.textBoxSearch.TabIndex = 87;
            // 
            // buttonSearch
            // 
            this.buttonSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.buttonSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSearch.Location = new System.Drawing.Point(1151, 16);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(106, 33);
            this.buttonSearch.TabIndex = 88;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = false;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // buttonDownload
            // 
            this.buttonDownload.BackColor = System.Drawing.SystemColors.Info;
            this.buttonDownload.Location = new System.Drawing.Point(325, 462);
            this.buttonDownload.Name = "buttonDownload";
            this.buttonDownload.Size = new System.Drawing.Size(120, 29);
            this.buttonDownload.TabIndex = 89;
            this.buttonDownload.Text = "Download Image";
            this.buttonDownload.UseVisualStyleBackColor = false;
            this.buttonDownload.Click += new System.EventHandler(this.buttonDownload_Click);
            // 
            // dataGridViewManagement
            // 
            this.dataGridViewManagement.AutoGenerateColumns = false;
            this.dataGridViewManagement.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewManagement.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewManagement.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.mssvDataGridViewTextBoxColumn,
            this.firstnameDataGridViewTextBoxColumn,
            this.lastnameDataGridViewTextBoxColumn,
            this.bdayDataGridViewTextBoxColumn,
            this.genderDataGridViewTextBoxColumn,
            this.phoneDataGridViewTextBoxColumn,
            this.emailDataGridViewTextBoxColumn,
            this.addressDataGridViewTextBoxColumn,
            this.pictureDataGridViewImageColumn,
            this.departmentDataGridViewTextBoxColumn,
            this.majorDataGridViewTextBoxColumn,
            this.hometownDataGridViewTextBoxColumn,
            this.selectedCourse});
            this.dataGridViewManagement.DataSource = this.studentBindingSource;
            this.dataGridViewManagement.Location = new System.Drawing.Point(500, 80);
            this.dataGridViewManagement.Name = "dataGridViewManagement";
            this.dataGridViewManagement.RowHeadersWidth = 51;
            this.dataGridViewManagement.RowTemplate.Height = 24;
            this.dataGridViewManagement.Size = new System.Drawing.Size(880, 530);
            this.dataGridViewManagement.TabIndex = 90;
            this.dataGridViewManagement.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewManagement_CellClick);
            this.dataGridViewManagement.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewManagement_CellDoubleClick);
            // 
            // mssvDataGridViewTextBoxColumn
            // 
            this.mssvDataGridViewTextBoxColumn.DataPropertyName = "mssv";
            this.mssvDataGridViewTextBoxColumn.HeaderText = "MSSV";
            this.mssvDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.mssvDataGridViewTextBoxColumn.Name = "mssvDataGridViewTextBoxColumn";
            // 
            // firstnameDataGridViewTextBoxColumn
            // 
            this.firstnameDataGridViewTextBoxColumn.DataPropertyName = "firstname";
            this.firstnameDataGridViewTextBoxColumn.HeaderText = "First Name";
            this.firstnameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.firstnameDataGridViewTextBoxColumn.Name = "firstnameDataGridViewTextBoxColumn";
            // 
            // lastnameDataGridViewTextBoxColumn
            // 
            this.lastnameDataGridViewTextBoxColumn.DataPropertyName = "lastname";
            this.lastnameDataGridViewTextBoxColumn.HeaderText = "Last Name";
            this.lastnameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.lastnameDataGridViewTextBoxColumn.Name = "lastnameDataGridViewTextBoxColumn";
            // 
            // bdayDataGridViewTextBoxColumn
            // 
            this.bdayDataGridViewTextBoxColumn.DataPropertyName = "bday";
            this.bdayDataGridViewTextBoxColumn.HeaderText = "Birthday";
            this.bdayDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.bdayDataGridViewTextBoxColumn.Name = "bdayDataGridViewTextBoxColumn";
            // 
            // genderDataGridViewTextBoxColumn
            // 
            this.genderDataGridViewTextBoxColumn.DataPropertyName = "gender";
            this.genderDataGridViewTextBoxColumn.HeaderText = "Gender";
            this.genderDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.genderDataGridViewTextBoxColumn.Name = "genderDataGridViewTextBoxColumn";
            // 
            // phoneDataGridViewTextBoxColumn
            // 
            this.phoneDataGridViewTextBoxColumn.DataPropertyName = "phone";
            this.phoneDataGridViewTextBoxColumn.HeaderText = "Phone";
            this.phoneDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.phoneDataGridViewTextBoxColumn.Name = "phoneDataGridViewTextBoxColumn";
            // 
            // emailDataGridViewTextBoxColumn
            // 
            this.emailDataGridViewTextBoxColumn.DataPropertyName = "email";
            this.emailDataGridViewTextBoxColumn.HeaderText = "Email";
            this.emailDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
            // 
            // addressDataGridViewTextBoxColumn
            // 
            this.addressDataGridViewTextBoxColumn.DataPropertyName = "address";
            this.addressDataGridViewTextBoxColumn.HeaderText = "Address";
            this.addressDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.addressDataGridViewTextBoxColumn.Name = "addressDataGridViewTextBoxColumn";
            // 
            // pictureDataGridViewImageColumn
            // 
            this.pictureDataGridViewImageColumn.DataPropertyName = "picture";
            this.pictureDataGridViewImageColumn.HeaderText = "Picture";
            this.pictureDataGridViewImageColumn.MinimumWidth = 6;
            this.pictureDataGridViewImageColumn.Name = "pictureDataGridViewImageColumn";
            // 
            // departmentDataGridViewTextBoxColumn
            // 
            this.departmentDataGridViewTextBoxColumn.DataPropertyName = "department";
            this.departmentDataGridViewTextBoxColumn.HeaderText = "Department";
            this.departmentDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.departmentDataGridViewTextBoxColumn.Name = "departmentDataGridViewTextBoxColumn";
            // 
            // majorDataGridViewTextBoxColumn
            // 
            this.majorDataGridViewTextBoxColumn.DataPropertyName = "major";
            this.majorDataGridViewTextBoxColumn.HeaderText = "Major";
            this.majorDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.majorDataGridViewTextBoxColumn.Name = "majorDataGridViewTextBoxColumn";
            // 
            // hometownDataGridViewTextBoxColumn
            // 
            this.hometownDataGridViewTextBoxColumn.DataPropertyName = "hometown";
            this.hometownDataGridViewTextBoxColumn.HeaderText = "Place of birth";
            this.hometownDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.hometownDataGridViewTextBoxColumn.Name = "hometownDataGridViewTextBoxColumn";
            // 
            // selectedCourse
            // 
            this.selectedCourse.DataPropertyName = "selectedCourse";
            this.selectedCourse.HeaderText = "Selected Course";
            this.selectedCourse.MinimumWidth = 6;
            this.selectedCourse.Name = "selectedCourse";
            // 
            // studentBindingSource
            // 
            this.studentBindingSource.DataMember = "Student";
            this.studentBindingSource.DataSource = this.qLSVStudent;
            // 
            // qLSVStudent
            // 
            this.qLSVStudent.DataSetName = "QLSVStudent";
            this.qLSVStudent.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // studentBindingSource2
            // 
            this.studentBindingSource2.DataMember = "Student";
            this.studentBindingSource2.DataSource = this.qLSVnewBindingSource;
            // 
            // qLSVnewBindingSource
            // 
            this.qLSVnewBindingSource.DataSource = this.qLSVnew;
            this.qLSVnewBindingSource.Position = 0;
            // 
            // qLSVnew
            // 
            this.qLSVnew.DataSetName = "QLSVnew";
            this.qLSVnew.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // labelTotal
            // 
            this.labelTotal.BackColor = System.Drawing.Color.Transparent;
            this.labelTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotal.ForeColor = System.Drawing.Color.White;
            this.labelTotal.Location = new System.Drawing.Point(1026, 616);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(281, 23);
            this.labelTotal.TabIndex = 91;
            this.labelTotal.Text = "Total student:";
            this.labelTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // studentBindingSource1
            // 
            this.studentBindingSource1.DataMember = "Student";
            this.studentBindingSource1.DataSource = this.qLSVnewBindingSource;
            // 
            // studentTableAdapter1
            // 
            this.studentTableAdapter1.ClearBeforeFill = true;
            // 
            // studentTableAdapter
            // 
            this.studentTableAdapter.ClearBeforeFill = true;
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.BackColor = System.Drawing.Color.Lime;
            this.buttonRefresh.Location = new System.Drawing.Point(945, 616);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(99, 32);
            this.buttonRefresh.TabIndex = 92;
            this.buttonRefresh.Text = "Refresh";
            this.buttonRefresh.UseVisualStyleBackColor = false;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // ManageStudentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1404, 690);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.labelTotal);
            this.Controls.Add(this.dataGridViewManagement);
            this.Controls.Add(this.buttonDownload);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.textBoxHometown);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonAdd);
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
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ManageStudentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ManageStudentForm";
            this.Load += new System.EventHandler(this.ManageStudentForm_Load);
            this.groupBoxGender.ResumeLayout(false);
            this.groupBoxGender.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewManagement)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLSVStudent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLSVnewBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLSVnew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxHometown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.ComboBox comboBoxDpt;
        private System.Windows.Forms.TextBox textBoxMajor;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.PictureBox pictureBoxSt;
        private System.Windows.Forms.TextBox textBoxAdrs;
        private System.Windows.Forms.TextBox textBoxPhone;
        private System.Windows.Forms.Button buttonUpload;
        private System.Windows.Forms.GroupBox groupBoxGender;
        private System.Windows.Forms.RadioButton radioButtonFemale;
        private System.Windows.Forms.RadioButton radioButtonMale;
        private System.Windows.Forms.DateTimePicker dateTimePickerBday;
        private System.Windows.Forms.TextBox textBoxLN;
        private System.Windows.Forms.TextBox textBoxFN;
        private System.Windows.Forms.TextBox textBoxID;
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
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Button buttonDownload;
        private System.Windows.Forms.DataGridView dataGridViewManagement;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.BindingSource qLSVnewBindingSource;
        private QLSVnew qLSVnew;
        private System.Windows.Forms.BindingSource studentBindingSource1;
        private QLSVnewTableAdapters.StudentTableAdapter studentTableAdapter1;
        private System.Windows.Forms.BindingSource studentBindingSource2;
        private QLSVStudent qLSVStudent;
        private System.Windows.Forms.BindingSource studentBindingSource;
        private QLSVStudentTableAdapters.StudentTableAdapter studentTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn mssvDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bdayDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn genderDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn phoneDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn addressDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewImageColumn pictureDataGridViewImageColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn departmentDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn majorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hometownDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn selectedCourse;
        private System.Windows.Forms.Button buttonRefresh;
    }
}