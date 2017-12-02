namespace GuitarShop
{
    partial class StaffForm
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
            this.FirstName = new System.Windows.Forms.Label();
            this.LastName = new System.Windows.Forms.Label();
            this.EmailAddress = new System.Windows.Forms.Label();
            this.IDNumber = new System.Windows.Forms.Label();
            this.titleComboBox = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.title = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.DateHired = new System.Windows.Forms.Label();
            this.DateOfBirth = new System.Windows.Forms.Label();
            this.EmployeeTypeComboBox = new System.Windows.Forms.ComboBox();
            this.EmployeeType = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.Password = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.AdminPrivilege = new System.Windows.Forms.CheckBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.OverrideCode = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // FirstName
            // 
            this.FirstName.AutoSize = true;
            this.FirstName.Location = new System.Drawing.Point(12, 48);
            this.FirstName.Name = "FirstName";
            this.FirstName.Size = new System.Drawing.Size(57, 13);
            this.FirstName.TabIndex = 0;
            this.FirstName.Text = "First Name";
            // 
            // LastName
            // 
            this.LastName.AutoSize = true;
            this.LastName.Location = new System.Drawing.Point(12, 87);
            this.LastName.Name = "LastName";
            this.LastName.Size = new System.Drawing.Size(58, 13);
            this.LastName.TabIndex = 1;
            this.LastName.Text = "Last Name";
            // 
            // EmailAddress
            // 
            this.EmailAddress.AutoSize = true;
            this.EmailAddress.Location = new System.Drawing.Point(12, 126);
            this.EmailAddress.Name = "EmailAddress";
            this.EmailAddress.Size = new System.Drawing.Size(73, 13);
            this.EmailAddress.TabIndex = 2;
            this.EmailAddress.Text = "Email Address";
            // 
            // IDNumber
            // 
            this.IDNumber.AutoSize = true;
            this.IDNumber.Location = new System.Drawing.Point(12, 9);
            this.IDNumber.Name = "IDNumber";
            this.IDNumber.Size = new System.Drawing.Size(58, 13);
            this.IDNumber.TabIndex = 3;
            this.IDNumber.Text = "ID Number";
            // 
            // titleComboBox
            // 
            this.titleComboBox.FormattingEnabled = true;
            this.titleComboBox.Location = new System.Drawing.Point(118, 24);
            this.titleComboBox.Name = "titleComboBox";
            this.titleComboBox.Size = new System.Drawing.Size(155, 21);
            this.titleComboBox.TabIndex = 4;
            this.titleComboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(15, 25);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(97, 20);
            this.textBox1.TabIndex = 5;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(15, 64);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(258, 20);
            this.textBox2.TabIndex = 6;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(15, 103);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(258, 20);
            this.textBox3.TabIndex = 7;
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Location = new System.Drawing.Point(115, 8);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(27, 13);
            this.title.TabIndex = 8;
            this.title.Text = "Title";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(15, 143);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(258, 20);
            this.textBox4.TabIndex = 9;
            // 
            // DateHired
            // 
            this.DateHired.AutoSize = true;
            this.DateHired.Location = new System.Drawing.Point(289, 10);
            this.DateHired.Name = "DateHired";
            this.DateHired.Size = new System.Drawing.Size(58, 13);
            this.DateHired.TabIndex = 12;
            this.DateHired.Text = "Date Hired";
            // 
            // DateOfBirth
            // 
            this.DateOfBirth.AutoSize = true;
            this.DateOfBirth.Location = new System.Drawing.Point(289, 48);
            this.DateOfBirth.Name = "DateOfBirth";
            this.DateOfBirth.Size = new System.Drawing.Size(66, 13);
            this.DateOfBirth.TabIndex = 13;
            this.DateOfBirth.Text = "Date of Birth";
            // 
            // EmployeeTypeComboBox
            // 
            this.EmployeeTypeComboBox.FormattingEnabled = true;
            this.EmployeeTypeComboBox.Location = new System.Drawing.Point(292, 102);
            this.EmployeeTypeComboBox.Name = "EmployeeTypeComboBox";
            this.EmployeeTypeComboBox.Size = new System.Drawing.Size(236, 21);
            this.EmployeeTypeComboBox.TabIndex = 14;
            this.EmployeeTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.EmployeeTypeComboBox_SelectedIndexChanged);
            // 
            // EmployeeType
            // 
            this.EmployeeType.AutoSize = true;
            this.EmployeeType.Location = new System.Drawing.Point(289, 86);
            this.EmployeeType.Name = "EmployeeType";
            this.EmployeeType.Size = new System.Drawing.Size(80, 13);
            this.EmployeeType.TabIndex = 15;
            this.EmployeeType.Text = "Employee Type";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(334, 182);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 23);
            this.button1.TabIndex = 16;
            this.button1.Text = "Update";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(442, 182);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(86, 23);
            this.Cancel.TabIndex = 17;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            // 
            // Password
            // 
            this.Password.AutoSize = true;
            this.Password.Location = new System.Drawing.Point(12, 166);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(53, 13);
            this.Password.TabIndex = 18;
            this.Password.Text = "Password";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(15, 182);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(258, 20);
            this.textBox5.TabIndex = 19;
            // 
            // AdminPrivilege
            // 
            this.AdminPrivilege.AutoSize = true;
            this.AdminPrivilege.Location = new System.Drawing.Point(293, 143);
            this.AdminPrivilege.Name = "AdminPrivilege";
            this.AdminPrivilege.Size = new System.Drawing.Size(103, 17);
            this.AdminPrivilege.TabIndex = 20;
            this.AdminPrivilege.Text = "Admin Privileges";
            this.AdminPrivilege.UseVisualStyleBackColor = true;
            this.AdminPrivilege.CheckedChanged += new System.EventHandler(this.AdminPrivilege_CheckedChanged);
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(411, 142);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(117, 20);
            this.textBox6.TabIndex = 21;
            // 
            // OverrideCode
            // 
            this.OverrideCode.AutoSize = true;
            this.OverrideCode.Location = new System.Drawing.Point(430, 126);
            this.OverrideCode.Name = "OverrideCode";
            this.OverrideCode.Size = new System.Drawing.Size(75, 13);
            this.OverrideCode.TabIndex = 22;
            this.OverrideCode.Text = "Override Code";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(293, 24);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(235, 20);
            this.textBox7.TabIndex = 23;
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(293, 64);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(235, 20);
            this.textBox8.TabIndex = 24;
            // 
            // Staff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 229);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.OverrideCode);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.AdminPrivilege);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.EmployeeType);
            this.Controls.Add(this.EmployeeTypeComboBox);
            this.Controls.Add(this.DateOfBirth);
            this.Controls.Add(this.DateHired);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.title);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.titleComboBox);
            this.Controls.Add(this.IDNumber);
            this.Controls.Add(this.EmailAddress);
            this.Controls.Add(this.LastName);
            this.Controls.Add(this.FirstName);
            this.Name = "Staff";
            this.Text = "Staff";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label FirstName;
        private System.Windows.Forms.Label LastName;
        private System.Windows.Forms.Label EmailAddress;
        private System.Windows.Forms.Label IDNumber;
        private System.Windows.Forms.ComboBox titleComboBox;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label DateHired;
        private System.Windows.Forms.Label DateOfBirth;
        private System.Windows.Forms.ComboBox EmployeeTypeComboBox;
        private System.Windows.Forms.Label EmployeeType;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Label Password;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.CheckBox AdminPrivilege;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label OverrideCode;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox8;
    }
}