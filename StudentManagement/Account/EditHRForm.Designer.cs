namespace StudentManagement.Account
{
    partial class EditHRForm
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
            this.bt_UploadImage = new System.Windows.Forms.Button();
            this.pictureBoxHRImage = new System.Windows.Forms.PictureBox();
            this.bt_Cancel = new System.Windows.Forms.Button();
            this.bt_Edit = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txb_Fname = new System.Windows.Forms.TextBox();
            this.txb_Lname = new System.Windows.Forms.TextBox();
            this.txb_UserID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txb_UserName = new System.Windows.Forms.TextBox();
            this.txb_PassWord = new System.Windows.Forms.TextBox();
            this.txb_ConfirmPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHRImage)).BeginInit();
            this.SuspendLayout();
            // 
            // bt_UploadImage
            // 
            this.bt_UploadImage.Location = new System.Drawing.Point(475, 246);
            this.bt_UploadImage.Name = "bt_UploadImage";
            this.bt_UploadImage.Size = new System.Drawing.Size(261, 44);
            this.bt_UploadImage.TabIndex = 92;
            this.bt_UploadImage.Text = "Upload Image";
            this.bt_UploadImage.UseVisualStyleBackColor = true;
            this.bt_UploadImage.Click += new System.EventHandler(this.bt_UploadImage_Click);
            // 
            // pictureBoxHRImage
            // 
            this.pictureBoxHRImage.Location = new System.Drawing.Point(512, 76);
            this.pictureBoxHRImage.Name = "pictureBoxHRImage";
            this.pictureBoxHRImage.Size = new System.Drawing.Size(189, 164);
            this.pictureBoxHRImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxHRImage.TabIndex = 91;
            this.pictureBoxHRImage.TabStop = false;
            // 
            // bt_Cancel
            // 
            this.bt_Cancel.BackColor = System.Drawing.Color.Red;
            this.bt_Cancel.Location = new System.Drawing.Point(326, 340);
            this.bt_Cancel.Name = "bt_Cancel";
            this.bt_Cancel.Size = new System.Drawing.Size(111, 57);
            this.bt_Cancel.TabIndex = 90;
            this.bt_Cancel.Text = "Cancel";
            this.bt_Cancel.UseVisualStyleBackColor = false;
            this.bt_Cancel.Click += new System.EventHandler(this.bt_Cancel_Click);
            // 
            // bt_Edit
            // 
            this.bt_Edit.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.bt_Edit.ForeColor = System.Drawing.Color.MintCream;
            this.bt_Edit.Location = new System.Drawing.Point(124, 340);
            this.bt_Edit.Name = "bt_Edit";
            this.bt_Edit.Size = new System.Drawing.Size(110, 57);
            this.bt_Edit.TabIndex = 89;
            this.bt_Edit.Text = "Edit";
            this.bt_Edit.UseVisualStyleBackColor = false;
            this.bt_Edit.Click += new System.EventHandler(this.bt_Edit_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(127, 99);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(108, 20);
            this.label9.TabIndex = 88;
            this.label9.Text = "First Name:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(128, 141);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 20);
            this.label8.TabIndex = 87;
            this.label8.Text = "Last Name:";
            // 
            // txb_Fname
            // 
            this.txb_Fname.Location = new System.Drawing.Point(260, 97);
            this.txb_Fname.Name = "txb_Fname";
            this.txb_Fname.Size = new System.Drawing.Size(167, 22);
            this.txb_Fname.TabIndex = 78;
            // 
            // txb_Lname
            // 
            this.txb_Lname.Location = new System.Drawing.Point(260, 141);
            this.txb_Lname.Name = "txb_Lname";
            this.txb_Lname.Size = new System.Drawing.Size(167, 22);
            this.txb_Lname.TabIndex = 79;
            // 
            // txb_UserID
            // 
            this.txb_UserID.Enabled = false;
            this.txb_UserID.Location = new System.Drawing.Point(260, 53);
            this.txb_UserID.Name = "txb_UserID";
            this.txb_UserID.ReadOnly = true;
            this.txb_UserID.Size = new System.Drawing.Size(167, 22);
            this.txb_UserID.TabIndex = 77;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(139, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 20);
            this.label5.TabIndex = 86;
            this.label5.Text = "User\'s ID:";
            // 
            // txb_UserName
            // 
            this.txb_UserName.Location = new System.Drawing.Point(260, 177);
            this.txb_UserName.Name = "txb_UserName";
            this.txb_UserName.Size = new System.Drawing.Size(167, 22);
            this.txb_UserName.TabIndex = 80;
            // 
            // txb_PassWord
            // 
            this.txb_PassWord.Location = new System.Drawing.Point(260, 220);
            this.txb_PassWord.Name = "txb_PassWord";
            this.txb_PassWord.Size = new System.Drawing.Size(167, 22);
            this.txb_PassWord.TabIndex = 81;
            // 
            // txb_ConfirmPassword
            // 
            this.txb_ConfirmPassword.Location = new System.Drawing.Point(260, 262);
            this.txb_ConfirmPassword.Name = "txb_ConfirmPassword";
            this.txb_ConfirmPassword.Size = new System.Drawing.Size(167, 22);
            this.txb_ConfirmPassword.TabIndex = 82;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(65, 262);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(169, 20);
            this.label3.TabIndex = 85;
            this.label3.Text = "Confirm Password:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(139, 220);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 20);
            this.label2.TabIndex = 84;
            this.label2.Text = "Password:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(131, 179);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 20);
            this.label1.TabIndex = 83;
            this.label1.Text = "UserName:";
            // 
            // EditHRForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.bt_UploadImage);
            this.Controls.Add(this.pictureBoxHRImage);
            this.Controls.Add(this.bt_Cancel);
            this.Controls.Add(this.bt_Edit);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txb_Fname);
            this.Controls.Add(this.txb_Lname);
            this.Controls.Add(this.txb_UserID);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txb_UserName);
            this.Controls.Add(this.txb_PassWord);
            this.Controls.Add(this.txb_ConfirmPassword);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "EditHRForm";
            this.Text = "EditHRForm";
            this.Load += new System.EventHandler(this.EditHRForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHRImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_UploadImage;
        private System.Windows.Forms.PictureBox pictureBoxHRImage;
        internal System.Windows.Forms.Button bt_Cancel;
        internal System.Windows.Forms.Button bt_Edit;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txb_Fname;
        private System.Windows.Forms.TextBox txb_Lname;
        private System.Windows.Forms.TextBox txb_UserID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txb_UserName;
        private System.Windows.Forms.TextBox txb_PassWord;
        private System.Windows.Forms.TextBox txb_ConfirmPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}