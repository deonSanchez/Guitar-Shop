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
            this.txt_firstname = new System.Windows.Forms.TextBox();
            this.txt_lastname = new System.Windows.Forms.TextBox();
            this.title = new System.Windows.Forms.Label();
            this.txt_email = new System.Windows.Forms.TextBox();
            this.DateHired = new System.Windows.Forms.Label();
            this.DateOfBirth = new System.Windows.Forms.Label();
            this.cmb_type = new System.Windows.Forms.ComboBox();
            this.EmployeeType = new System.Windows.Forms.Label();
            this.btn_add = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.Password = new System.Windows.Forms.Label();
            this.txt_pass = new System.Windows.Forms.TextBox();
            this.txt_code = new System.Windows.Forms.TextBox();
            this.OverrideCode = new System.Windows.Forms.Label();
            this.dt_hired = new System.Windows.Forms.DateTimePicker();
            this.dt_birth = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.cmb_priv = new System.Windows.Forms.ComboBox();
            this.txt_title = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // FirstName
            // 
            this.FirstName.AutoSize = true;
            this.FirstName.Location = new System.Drawing.Point(13, 51);
            this.FirstName.Name = "FirstName";
            this.FirstName.Size = new System.Drawing.Size(57, 13);
            this.FirstName.TabIndex = 0;
            this.FirstName.Text = "First Name";
            // 
            // LastName
            // 
            this.LastName.AutoSize = true;
            this.LastName.Location = new System.Drawing.Point(12, 93);
            this.LastName.Name = "LastName";
            this.LastName.Size = new System.Drawing.Size(58, 13);
            this.LastName.TabIndex = 1;
            this.LastName.Text = "Last Name";
            // 
            // EmailAddress
            // 
            this.EmailAddress.AutoSize = true;
            this.EmailAddress.Location = new System.Drawing.Point(12, 135);
            this.EmailAddress.Name = "EmailAddress";
            this.EmailAddress.Size = new System.Drawing.Size(73, 13);
            this.EmailAddress.TabIndex = 2;
            this.EmailAddress.Text = "Email Address";
            // 
            // txt_firstname
            // 
            this.txt_firstname.Location = new System.Drawing.Point(16, 67);
            this.txt_firstname.Margin = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.txt_firstname.Name = "txt_firstname";
            this.txt_firstname.Size = new System.Drawing.Size(528, 20);
            this.txt_firstname.TabIndex = 6;
            this.txt_firstname.TextChanged += new System.EventHandler(this.txt_firstname_TextChanged);
            // 
            // txt_lastname
            // 
            this.txt_lastname.Location = new System.Drawing.Point(16, 109);
            this.txt_lastname.Margin = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.txt_lastname.Name = "txt_lastname";
            this.txt_lastname.Size = new System.Drawing.Size(528, 20);
            this.txt_lastname.TabIndex = 7;
            this.txt_lastname.TextChanged += new System.EventHandler(this.txt_lastname_TextChanged);
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Location = new System.Drawing.Point(13, 8);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(27, 13);
            this.title.TabIndex = 8;
            this.title.Text = "Title";
            // 
            // txt_email
            // 
            this.txt_email.Location = new System.Drawing.Point(16, 151);
            this.txt_email.Margin = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.txt_email.Name = "txt_email";
            this.txt_email.Size = new System.Drawing.Size(528, 20);
            this.txt_email.TabIndex = 9;
            this.txt_email.TextChanged += new System.EventHandler(this.txt_email_TextChanged);
            // 
            // DateHired
            // 
            this.DateHired.AutoSize = true;
            this.DateHired.Location = new System.Drawing.Point(13, 219);
            this.DateHired.Name = "DateHired";
            this.DateHired.Size = new System.Drawing.Size(58, 13);
            this.DateHired.TabIndex = 12;
            this.DateHired.Text = "Date Hired";
            // 
            // DateOfBirth
            // 
            this.DateOfBirth.AutoSize = true;
            this.DateOfBirth.Location = new System.Drawing.Point(12, 261);
            this.DateOfBirth.Name = "DateOfBirth";
            this.DateOfBirth.Size = new System.Drawing.Size(66, 13);
            this.DateOfBirth.TabIndex = 13;
            this.DateOfBirth.Text = "Date of Birth";
            // 
            // cmb_type
            // 
            this.cmb_type.FormattingEnabled = true;
            this.cmb_type.Location = new System.Drawing.Point(16, 319);
            this.cmb_type.Margin = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.cmb_type.Name = "cmb_type";
            this.cmb_type.Size = new System.Drawing.Size(528, 21);
            this.cmb_type.TabIndex = 14;
            this.cmb_type.SelectedIndexChanged += new System.EventHandler(this.cmb_type_SelectedIndexChanged);
            // 
            // EmployeeType
            // 
            this.EmployeeType.AutoSize = true;
            this.EmployeeType.Location = new System.Drawing.Point(13, 303);
            this.EmployeeType.Name = "EmployeeType";
            this.EmployeeType.Size = new System.Drawing.Size(80, 13);
            this.EmployeeType.TabIndex = 15;
            this.EmployeeType.Text = "Employee Type";
            // 
            // btn_add
            // 
            this.btn_add.Enabled = false;
            this.btn_add.Location = new System.Drawing.Point(360, 457);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(92, 23);
            this.btn_add.TabIndex = 16;
            this.btn_add.Text = "Add";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(458, 457);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(86, 23);
            this.Cancel.TabIndex = 17;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // Password
            // 
            this.Password.AutoSize = true;
            this.Password.Location = new System.Drawing.Point(12, 177);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(53, 13);
            this.Password.TabIndex = 18;
            this.Password.Text = "Password";
            // 
            // txt_pass
            // 
            this.txt_pass.Location = new System.Drawing.Point(16, 193);
            this.txt_pass.Margin = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.txt_pass.Name = "txt_pass";
            this.txt_pass.Size = new System.Drawing.Size(528, 20);
            this.txt_pass.TabIndex = 19;
            this.txt_pass.TextChanged += new System.EventHandler(this.txt_pass_TextChanged);
            // 
            // txt_code
            // 
            this.txt_code.Enabled = false;
            this.txt_code.Location = new System.Drawing.Point(16, 405);
            this.txt_code.Margin = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.txt_code.Name = "txt_code";
            this.txt_code.Size = new System.Drawing.Size(528, 20);
            this.txt_code.TabIndex = 21;
            this.txt_code.TextChanged += new System.EventHandler(this.txt_code_TextChanged);
            // 
            // OverrideCode
            // 
            this.OverrideCode.AutoSize = true;
            this.OverrideCode.Location = new System.Drawing.Point(13, 389);
            this.OverrideCode.Name = "OverrideCode";
            this.OverrideCode.Size = new System.Drawing.Size(75, 13);
            this.OverrideCode.TabIndex = 22;
            this.OverrideCode.Text = "Override Code";
            // 
            // dt_hired
            // 
            this.dt_hired.Location = new System.Drawing.Point(16, 235);
            this.dt_hired.Margin = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.dt_hired.Name = "dt_hired";
            this.dt_hired.Size = new System.Drawing.Size(528, 20);
            this.dt_hired.TabIndex = 25;
            this.dt_hired.ValueChanged += new System.EventHandler(this.dt_hired_ValueChanged);
            // 
            // dt_birth
            // 
            this.dt_birth.Location = new System.Drawing.Point(16, 277);
            this.dt_birth.Margin = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.dt_birth.Name = "dt_birth";
            this.dt_birth.Size = new System.Drawing.Size(528, 20);
            this.dt_birth.TabIndex = 26;
            this.dt_birth.ValueChanged += new System.EventHandler(this.dt_birth_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 346);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Privilege Level";
            // 
            // cmb_priv
            // 
            this.cmb_priv.FormattingEnabled = true;
            this.cmb_priv.Location = new System.Drawing.Point(16, 362);
            this.cmb_priv.Margin = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.cmb_priv.Name = "cmb_priv";
            this.cmb_priv.Size = new System.Drawing.Size(528, 21);
            this.cmb_priv.TabIndex = 28;
            this.cmb_priv.SelectedIndexChanged += new System.EventHandler(this.cmb_priv_SelectedIndexChanged);
            // 
            // txt_title
            // 
            this.txt_title.Location = new System.Drawing.Point(16, 24);
            this.txt_title.Name = "txt_title";
            this.txt_title.Size = new System.Drawing.Size(528, 20);
            this.txt_title.TabIndex = 29;
            this.txt_title.TextChanged += new System.EventHandler(this.txt_title_TextChanged);
            // 
            // StaffForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 496);
            this.Controls.Add(this.txt_title);
            this.Controls.Add(this.cmb_priv);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dt_birth);
            this.Controls.Add(this.dt_hired);
            this.Controls.Add(this.OverrideCode);
            this.Controls.Add(this.txt_code);
            this.Controls.Add(this.txt_pass);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.EmployeeType);
            this.Controls.Add(this.cmb_type);
            this.Controls.Add(this.DateOfBirth);
            this.Controls.Add(this.DateHired);
            this.Controls.Add(this.txt_email);
            this.Controls.Add(this.title);
            this.Controls.Add(this.txt_lastname);
            this.Controls.Add(this.txt_firstname);
            this.Controls.Add(this.EmailAddress);
            this.Controls.Add(this.LastName);
            this.Controls.Add(this.FirstName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StaffForm";
            this.Text = "Staff";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label FirstName;
        private System.Windows.Forms.Label LastName;
        private System.Windows.Forms.Label EmailAddress;
        private System.Windows.Forms.TextBox txt_firstname;
        private System.Windows.Forms.TextBox txt_lastname;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.TextBox txt_email;
        private System.Windows.Forms.Label DateHired;
        private System.Windows.Forms.Label DateOfBirth;
        private System.Windows.Forms.ComboBox cmb_type;
        private System.Windows.Forms.Label EmployeeType;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Label Password;
        private System.Windows.Forms.TextBox txt_pass;
        private System.Windows.Forms.TextBox txt_code;
        private System.Windows.Forms.Label OverrideCode;
        private System.Windows.Forms.DateTimePicker dt_hired;
        private System.Windows.Forms.DateTimePicker dt_birth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb_priv;
        private System.Windows.Forms.TextBox txt_title;
    }
}