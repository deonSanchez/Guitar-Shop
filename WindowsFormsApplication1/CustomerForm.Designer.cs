namespace GuitarShop
{
    partial class CustomerForm
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
            this.lbl_firstName = new System.Windows.Forms.Label();
            this.lbl_lastName = new System.Windows.Forms.Label();
            this.txt_firstName = new System.Windows.Forms.TextBox();
            this.btn_add = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txt_lastName = new System.Windows.Forms.TextBox();
            this.lbl_email = new System.Windows.Forms.Label();
            this.txt_email = new System.Windows.Forms.TextBox();
            this.txt_password = new System.Windows.Forms.TextBox();
            this.lbl_password = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lv_addresses = new System.Windows.Forms.ListView();
            this.lbl_employeeContact = new System.Windows.Forms.Label();
            this.btn_addressAdd = new System.Windows.Forms.Button();
            this.btn_addressRemove = new System.Windows.Forms.Button();
            this.cmb_employeeContact = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lbl_firstName
            // 
            this.lbl_firstName.AutoSize = true;
            this.lbl_firstName.Location = new System.Drawing.Point(12, 9);
            this.lbl_firstName.Name = "lbl_firstName";
            this.lbl_firstName.Size = new System.Drawing.Size(57, 13);
            this.lbl_firstName.TabIndex = 0;
            this.lbl_firstName.Text = "First Name";
            // 
            // lbl_lastName
            // 
            this.lbl_lastName.AutoSize = true;
            this.lbl_lastName.Location = new System.Drawing.Point(12, 51);
            this.lbl_lastName.Name = "lbl_lastName";
            this.lbl_lastName.Size = new System.Drawing.Size(58, 13);
            this.lbl_lastName.TabIndex = 1;
            this.lbl_lastName.Text = "Last Name";
            // 
            // txt_firstName
            // 
            this.txt_firstName.Location = new System.Drawing.Point(15, 25);
            this.txt_firstName.Margin = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.txt_firstName.MaxLength = 255;
            this.txt_firstName.Name = "txt_firstName";
            this.txt_firstName.Size = new System.Drawing.Size(376, 20);
            this.txt_firstName.TabIndex = 11;
            // 
            // btn_add
            // 
            this.btn_add.Location = new System.Drawing.Point(211, 382);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(85, 23);
            this.btn_add.TabIndex = 22;
            this.btn_add.Text = "Submit";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_submit);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(302, 382);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(89, 23);
            this.btnCancel.TabIndex = 23;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btn_cancel);
            // 
            // txt_lastName
            // 
            this.txt_lastName.Location = new System.Drawing.Point(15, 67);
            this.txt_lastName.Margin = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.txt_lastName.MaxLength = 255;
            this.txt_lastName.Name = "txt_lastName";
            this.txt_lastName.Size = new System.Drawing.Size(376, 20);
            this.txt_lastName.TabIndex = 24;
            // 
            // lbl_email
            // 
            this.lbl_email.AutoSize = true;
            this.lbl_email.Location = new System.Drawing.Point(12, 93);
            this.lbl_email.Name = "lbl_email";
            this.lbl_email.Size = new System.Drawing.Size(73, 13);
            this.lbl_email.TabIndex = 25;
            this.lbl_email.Text = "Email Address";
            // 
            // txt_email
            // 
            this.txt_email.Location = new System.Drawing.Point(15, 109);
            this.txt_email.Margin = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.txt_email.MaxLength = 255;
            this.txt_email.Name = "txt_email";
            this.txt_email.Size = new System.Drawing.Size(376, 20);
            this.txt_email.TabIndex = 26;
            // 
            // txt_password
            // 
            this.txt_password.Location = new System.Drawing.Point(15, 151);
            this.txt_password.Margin = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.txt_password.MaxLength = 255;
            this.txt_password.Name = "txt_password";
            this.txt_password.Size = new System.Drawing.Size(376, 20);
            this.txt_password.TabIndex = 27;
            // 
            // lbl_password
            // 
            this.lbl_password.AutoSize = true;
            this.lbl_password.Location = new System.Drawing.Point(12, 135);
            this.lbl_password.Name = "lbl_password";
            this.lbl_password.Size = new System.Drawing.Size(53, 13);
            this.lbl_password.TabIndex = 28;
            this.lbl_password.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 177);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "Addresses";
            // 
            // lv_addresses
            // 
            this.lv_addresses.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.lv_addresses.CheckBoxes = true;
            this.lv_addresses.Location = new System.Drawing.Point(15, 193);
            this.lv_addresses.Margin = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.lv_addresses.Name = "lv_addresses";
            this.lv_addresses.Size = new System.Drawing.Size(376, 97);
            this.lv_addresses.TabIndex = 30;
            this.lv_addresses.UseCompatibleStateImageBehavior = false;
            this.lv_addresses.View = System.Windows.Forms.View.Details;
            this.lv_addresses.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lv_addresses_ItemChecked);
            // 
            // lbl_employeeContact
            // 
            this.lbl_employeeContact.AutoSize = true;
            this.lbl_employeeContact.Location = new System.Drawing.Point(12, 325);
            this.lbl_employeeContact.Name = "lbl_employeeContact";
            this.lbl_employeeContact.Size = new System.Drawing.Size(93, 13);
            this.lbl_employeeContact.TabIndex = 31;
            this.lbl_employeeContact.Text = "Employee Contact";
            // 
            // btn_addressAdd
            // 
            this.btn_addressAdd.Location = new System.Drawing.Point(235, 299);
            this.btn_addressAdd.Name = "btn_addressAdd";
            this.btn_addressAdd.Size = new System.Drawing.Size(75, 23);
            this.btn_addressAdd.TabIndex = 32;
            this.btn_addressAdd.Text = "Add";
            this.btn_addressAdd.UseVisualStyleBackColor = true;
            this.btn_addressAdd.Click += new System.EventHandler(this.btn_addressAdd_Click);
            // 
            // btn_addressRemove
            // 
            this.btn_addressRemove.Enabled = false;
            this.btn_addressRemove.Location = new System.Drawing.Point(316, 299);
            this.btn_addressRemove.Name = "btn_addressRemove";
            this.btn_addressRemove.Size = new System.Drawing.Size(75, 23);
            this.btn_addressRemove.TabIndex = 33;
            this.btn_addressRemove.Text = "Remove";
            this.btn_addressRemove.UseVisualStyleBackColor = true;
            this.btn_addressRemove.Click += new System.EventHandler(this.btn_addressRemove_Click);
            // 
            // cmb_employeeContact
            // 
            this.cmb_employeeContact.FormattingEnabled = true;
            this.cmb_employeeContact.Location = new System.Drawing.Point(15, 341);
            this.cmb_employeeContact.Margin = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.cmb_employeeContact.Name = "cmb_employeeContact";
            this.cmb_employeeContact.Size = new System.Drawing.Size(376, 21);
            this.cmb_employeeContact.TabIndex = 34;
            this.cmb_employeeContact.SelectedIndexChanged += new System.EventHandler(this.cmb_employeeContact_SelectedIndexChanged);
            // 
            // CustomerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 417);
            this.Controls.Add(this.cmb_employeeContact);
            this.Controls.Add(this.btn_addressAdd);
            this.Controls.Add(this.btn_addressRemove);
            this.Controls.Add(this.lbl_employeeContact);
            this.Controls.Add(this.lv_addresses);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_password);
            this.Controls.Add(this.txt_password);
            this.Controls.Add(this.txt_email);
            this.Controls.Add(this.lbl_email);
            this.Controls.Add(this.txt_lastName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.txt_firstName);
            this.Controls.Add(this.lbl_lastName);
            this.Controls.Add(this.lbl_firstName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomerForm";
            this.Text = "New Customer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_firstName;
        private System.Windows.Forms.Label lbl_lastName;
        private System.Windows.Forms.TextBox txt_firstName;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txt_lastName;
        private System.Windows.Forms.Label lbl_email;
        private System.Windows.Forms.TextBox txt_email;
        private System.Windows.Forms.TextBox txt_password;
        private System.Windows.Forms.Label lbl_password;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lv_addresses;
        private System.Windows.Forms.Label lbl_employeeContact;
        private System.Windows.Forms.Button btn_addressAdd;
        private System.Windows.Forms.Button btn_addressRemove;
        private System.Windows.Forms.ComboBox cmb_employeeContact;
    }
}