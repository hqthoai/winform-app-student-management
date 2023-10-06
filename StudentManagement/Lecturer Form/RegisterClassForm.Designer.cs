namespace StudentManagement.Lecturer_Form
{
    partial class RegisterClassForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxSelectCourse = new System.Windows.Forms.ComboBox();
            this.buttonRegisterClass = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select Course:";
            // 
            // comboBoxSelectCourse
            // 
            this.comboBoxSelectCourse.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxSelectCourse.FormattingEnabled = true;
            this.comboBoxSelectCourse.Location = new System.Drawing.Point(183, 41);
            this.comboBoxSelectCourse.Name = "comboBoxSelectCourse";
            this.comboBoxSelectCourse.Size = new System.Drawing.Size(255, 33);
            this.comboBoxSelectCourse.TabIndex = 1;
            // 
            // buttonRegisterClass
            // 
            this.buttonRegisterClass.Location = new System.Drawing.Point(466, 41);
            this.buttonRegisterClass.Name = "buttonRegisterClass";
            this.buttonRegisterClass.Size = new System.Drawing.Size(152, 33);
            this.buttonRegisterClass.TabIndex = 2;
            this.buttonRegisterClass.Text = "Register Teaching";
            this.buttonRegisterClass.UseVisualStyleBackColor = true;
            this.buttonRegisterClass.Click += new System.EventHandler(this.buttonRegisterClass_Click);
            // 
            // RegisterClassForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 213);
            this.Controls.Add(this.buttonRegisterClass);
            this.Controls.Add(this.comboBoxSelectCourse);
            this.Controls.Add(this.label1);
            this.Name = "RegisterClassForm";
            this.Text = "RegisterClassForm";
            this.Load += new System.EventHandler(this.RegisterClassForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxSelectCourse;
        private System.Windows.Forms.Button buttonRegisterClass;
    }
}