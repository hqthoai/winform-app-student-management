namespace StudentManagement.Contact
{
    partial class EditContactForm
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
            this.bt_SelectContact = new System.Windows.Forms.Button();
            this.txb_ID = new System.Windows.Forms.TextBox();
            this.label = new System.Windows.Forms.Label();
            this.cbb_Group = new System.Windows.Forms.ComboBox();
            this.PicBox_ContactImage = new System.Windows.Forms.PictureBox();
            this.bt_UploadImage = new System.Windows.Forms.Button();
            this.bt_Cancel = new System.Windows.Forms.Button();
            this.bt_EditContact = new System.Windows.Forms.Button();
            this.txb_Email = new System.Windows.Forms.TextBox();
            this.txb_Phone = new System.Windows.Forms.TextBox();
            this.txb_Address = new System.Windows.Forms.TextBox();
            this.txb_Lname = new System.Windows.Forms.TextBox();
            this.txb_Fname = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PicBox_ContactImage)).BeginInit();
            this.SuspendLayout();
            // 
            // bt_SelectContact
            // 
            this.bt_SelectContact.BackColor = System.Drawing.Color.OliveDrab;
            this.bt_SelectContact.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.bt_SelectContact.Location = new System.Drawing.Point(593, 30);
            this.bt_SelectContact.Name = "bt_SelectContact";
            this.bt_SelectContact.Size = new System.Drawing.Size(194, 34);
            this.bt_SelectContact.TabIndex = 84;
            this.bt_SelectContact.Text = "Select Contact";
            this.bt_SelectContact.UseVisualStyleBackColor = false;
            this.bt_SelectContact.Click += new System.EventHandler(this.bt_SelectContact_Click);
            // 
            // txb_ID
            // 
            this.txb_ID.Location = new System.Drawing.Point(353, 39);
            this.txb_ID.Name = "txb_ID";
            this.txb_ID.Size = new System.Drawing.Size(225, 22);
            this.txb_ID.TabIndex = 82;
            this.txb_ID.TextChanged += new System.EventHandler(this.txb_ID_TextChanged);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label.Location = new System.Drawing.Point(249, 26);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(46, 35);
            this.label.TabIndex = 83;
            this.label.Text = "ID:";
            // 
            // cbb_Group
            // 
            this.cbb_Group.FormattingEnabled = true;
            this.cbb_Group.Location = new System.Drawing.Point(353, 194);
            this.cbb_Group.Name = "cbb_Group";
            this.cbb_Group.Size = new System.Drawing.Size(434, 24);
            this.cbb_Group.TabIndex = 67;
            // 
            // PicBox_ContactImage
            // 
            this.PicBox_ContactImage.BackColor = System.Drawing.Color.White;
            this.PicBox_ContactImage.Location = new System.Drawing.Point(353, 497);
            this.PicBox_ContactImage.Name = "PicBox_ContactImage";
            this.PicBox_ContactImage.Size = new System.Drawing.Size(225, 169);
            this.PicBox_ContactImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PicBox_ContactImage.TabIndex = 81;
            this.PicBox_ContactImage.TabStop = false;
            // 
            // bt_UploadImage
            // 
            this.bt_UploadImage.Location = new System.Drawing.Point(353, 672);
            this.bt_UploadImage.Name = "bt_UploadImage";
            this.bt_UploadImage.Size = new System.Drawing.Size(225, 29);
            this.bt_UploadImage.TabIndex = 71;
            this.bt_UploadImage.Text = "Upload Image";
            this.bt_UploadImage.UseVisualStyleBackColor = true;
            this.bt_UploadImage.Click += new System.EventHandler(this.bt_UploadImage_Click);
            // 
            // bt_Cancel
            // 
            this.bt_Cancel.BackColor = System.Drawing.Color.Red;
            this.bt_Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Cancel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.bt_Cancel.Location = new System.Drawing.Point(571, 754);
            this.bt_Cancel.Name = "bt_Cancel";
            this.bt_Cancel.Size = new System.Drawing.Size(255, 70);
            this.bt_Cancel.TabIndex = 73;
            this.bt_Cancel.Text = "Cancel";
            this.bt_Cancel.UseVisualStyleBackColor = false;
            this.bt_Cancel.Click += new System.EventHandler(this.bt_Cancel_Click);
            // 
            // bt_EditContact
            // 
            this.bt_EditContact.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.bt_EditContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_EditContact.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_EditContact.Location = new System.Drawing.Point(207, 754);
            this.bt_EditContact.Name = "bt_EditContact";
            this.bt_EditContact.Size = new System.Drawing.Size(255, 70);
            this.bt_EditContact.TabIndex = 72;
            this.bt_EditContact.Text = "Edit";
            this.bt_EditContact.UseVisualStyleBackColor = false;
            this.bt_EditContact.Click += new System.EventHandler(this.bt_EditContact_Click);
            // 
            // txb_Email
            // 
            this.txb_Email.Location = new System.Drawing.Point(353, 309);
            this.txb_Email.Multiline = true;
            this.txb_Email.Name = "txb_Email";
            this.txb_Email.Size = new System.Drawing.Size(434, 38);
            this.txb_Email.TabIndex = 69;
            // 
            // txb_Phone
            // 
            this.txb_Phone.Location = new System.Drawing.Point(353, 247);
            this.txb_Phone.Multiline = true;
            this.txb_Phone.Name = "txb_Phone";
            this.txb_Phone.Size = new System.Drawing.Size(434, 35);
            this.txb_Phone.TabIndex = 68;
            // 
            // txb_Address
            // 
            this.txb_Address.Location = new System.Drawing.Point(353, 372);
            this.txb_Address.Multiline = true;
            this.txb_Address.Name = "txb_Address";
            this.txb_Address.Size = new System.Drawing.Size(434, 90);
            this.txb_Address.TabIndex = 70;
            // 
            // txb_Lname
            // 
            this.txb_Lname.Location = new System.Drawing.Point(353, 137);
            this.txb_Lname.Multiline = true;
            this.txb_Lname.Name = "txb_Lname";
            this.txb_Lname.Size = new System.Drawing.Size(434, 37);
            this.txb_Lname.TabIndex = 66;
            // 
            // txb_Fname
            // 
            this.txb_Fname.Location = new System.Drawing.Point(353, 78);
            this.txb_Fname.Multiline = true;
            this.txb_Fname.Name = "txb_Fname";
            this.txb_Fname.Size = new System.Drawing.Size(434, 36);
            this.txb_Fname.TabIndex = 65;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label8.Location = new System.Drawing.Point(194, 488);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(101, 35);
            this.label8.TabIndex = 80;
            this.label8.Text = "Picture:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label7.Location = new System.Drawing.Point(186, 372);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(112, 35);
            this.label7.TabIndex = 79;
            this.label7.Text = "Address:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new System.Drawing.Point(201, 247);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 35);
            this.label6.TabIndex = 78;
            this.label6.Text = "Phone:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(206, 194);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 35);
            this.label4.TabIndex = 77;
            this.label4.Text = "Group:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(155, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 35);
            this.label3.TabIndex = 76;
            this.label3.Text = "Last Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(151, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 35);
            this.label2.TabIndex = 75;
            this.label2.Text = "First Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(215, 312);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 35);
            this.label1.TabIndex = 74;
            this.label1.Text = "Email:";
            // 
            // EditContactForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(985, 899);
            this.Controls.Add(this.bt_SelectContact);
            this.Controls.Add(this.txb_ID);
            this.Controls.Add(this.label);
            this.Controls.Add(this.cbb_Group);
            this.Controls.Add(this.PicBox_ContactImage);
            this.Controls.Add(this.bt_UploadImage);
            this.Controls.Add(this.bt_Cancel);
            this.Controls.Add(this.bt_EditContact);
            this.Controls.Add(this.txb_Email);
            this.Controls.Add(this.txb_Phone);
            this.Controls.Add(this.txb_Address);
            this.Controls.Add(this.txb_Lname);
            this.Controls.Add(this.txb_Fname);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "EditContactForm";
            this.Text = "EditContactForm";
            this.Load += new System.EventHandler(this.EditContactForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PicBox_ContactImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_SelectContact;
        private System.Windows.Forms.TextBox txb_ID;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.ComboBox cbb_Group;
        private System.Windows.Forms.PictureBox PicBox_ContactImage;
        private System.Windows.Forms.Button bt_UploadImage;
        private System.Windows.Forms.Button bt_Cancel;
        private System.Windows.Forms.Button bt_EditContact;
        private System.Windows.Forms.TextBox txb_Email;
        private System.Windows.Forms.TextBox txb_Phone;
        private System.Windows.Forms.TextBox txb_Address;
        private System.Windows.Forms.TextBox txb_Lname;
        private System.Windows.Forms.TextBox txb_Fname;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}