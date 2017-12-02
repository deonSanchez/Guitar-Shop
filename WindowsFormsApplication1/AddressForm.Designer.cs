namespace GuitarShop
{
    partial class AddressForm
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
            this.txt_state = new System.Windows.Forms.TextBox();
            this.txt_zip = new System.Windows.Forms.TextBox();
            this.txt_addrLine2 = new System.Windows.Forms.TextBox();
            this.txt_addrLine1 = new System.Windows.Forms.TextBox();
            this.txt_city = new System.Windows.Forms.TextBox();
            this.txt_phone = new System.Windows.Forms.TextBox();
            this.lbl_addrLine2 = new System.Windows.Forms.Label();
            this.lvl_zip = new System.Windows.Forms.Label();
            this.lbl__state = new System.Windows.Forms.Label();
            this.lbl_city = new System.Windows.Forms.Label();
            this.lbl_addrLine1 = new System.Windows.Forms.Label();
            this.lbl_phone = new System.Windows.Forms.Label();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_add = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt_state
            // 
            this.txt_state.Location = new System.Drawing.Point(301, 109);
            this.txt_state.Margin = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.txt_state.MaxLength = 2;
            this.txt_state.Name = "txt_state";
            this.txt_state.Size = new System.Drawing.Size(114, 20);
            this.txt_state.TabIndex = 31;
            // 
            // txt_zip
            // 
            this.txt_zip.Location = new System.Drawing.Point(15, 151);
            this.txt_zip.Margin = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.txt_zip.MaxLength = 5;
            this.txt_zip.Name = "txt_zip";
            this.txt_zip.Size = new System.Drawing.Size(74, 20);
            this.txt_zip.TabIndex = 30;
            // 
            // txt_addrLine2
            // 
            this.txt_addrLine2.Location = new System.Drawing.Point(15, 67);
            this.txt_addrLine2.Margin = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.txt_addrLine2.MaxLength = 255;
            this.txt_addrLine2.Name = "txt_addrLine2";
            this.txt_addrLine2.Size = new System.Drawing.Size(400, 20);
            this.txt_addrLine2.TabIndex = 29;
            // 
            // txt_addrLine1
            // 
            this.txt_addrLine1.Location = new System.Drawing.Point(15, 25);
            this.txt_addrLine1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.txt_addrLine1.MaxLength = 255;
            this.txt_addrLine1.Name = "txt_addrLine1";
            this.txt_addrLine1.Size = new System.Drawing.Size(400, 20);
            this.txt_addrLine1.TabIndex = 28;
            // 
            // txt_city
            // 
            this.txt_city.Location = new System.Drawing.Point(15, 109);
            this.txt_city.Margin = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.txt_city.MaxLength = 255;
            this.txt_city.Name = "txt_city";
            this.txt_city.Size = new System.Drawing.Size(280, 20);
            this.txt_city.TabIndex = 27;
            // 
            // txt_phone
            // 
            this.txt_phone.Location = new System.Drawing.Point(95, 151);
            this.txt_phone.Margin = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.txt_phone.MaxLength = 10;
            this.txt_phone.Name = "txt_phone";
            this.txt_phone.Size = new System.Drawing.Size(142, 20);
            this.txt_phone.TabIndex = 26;
            // 
            // lbl_addrLine2
            // 
            this.lbl_addrLine2.AutoSize = true;
            this.lbl_addrLine2.Location = new System.Drawing.Point(12, 51);
            this.lbl_addrLine2.Name = "lbl_addrLine2";
            this.lbl_addrLine2.Size = new System.Drawing.Size(77, 13);
            this.lbl_addrLine2.TabIndex = 25;
            this.lbl_addrLine2.Text = "Address Line 2";
            // 
            // lvl_zip
            // 
            this.lvl_zip.AutoSize = true;
            this.lvl_zip.Location = new System.Drawing.Point(12, 135);
            this.lvl_zip.Name = "lvl_zip";
            this.lvl_zip.Size = new System.Drawing.Size(50, 13);
            this.lvl_zip.TabIndex = 24;
            this.lvl_zip.Text = "Zip Code";
            // 
            // lbl__state
            // 
            this.lbl__state.AutoSize = true;
            this.lbl__state.Location = new System.Drawing.Point(298, 93);
            this.lbl__state.Name = "lbl__state";
            this.lbl__state.Size = new System.Drawing.Size(32, 13);
            this.lbl__state.TabIndex = 23;
            this.lbl__state.Text = "State";
            // 
            // lbl_city
            // 
            this.lbl_city.AutoSize = true;
            this.lbl_city.Location = new System.Drawing.Point(12, 93);
            this.lbl_city.Name = "lbl_city";
            this.lbl_city.Size = new System.Drawing.Size(24, 13);
            this.lbl_city.TabIndex = 22;
            this.lbl_city.Text = "City";
            // 
            // lbl_addrLine1
            // 
            this.lbl_addrLine1.AutoSize = true;
            this.lbl_addrLine1.Location = new System.Drawing.Point(12, 9);
            this.lbl_addrLine1.Name = "lbl_addrLine1";
            this.lbl_addrLine1.Size = new System.Drawing.Size(77, 13);
            this.lbl_addrLine1.TabIndex = 21;
            this.lbl_addrLine1.Text = "Address Line 1";
            // 
            // lbl_phone
            // 
            this.lbl_phone.AutoSize = true;
            this.lbl_phone.Location = new System.Drawing.Point(92, 135);
            this.lbl_phone.Name = "lbl_phone";
            this.lbl_phone.Size = new System.Drawing.Size(78, 13);
            this.lbl_phone.TabIndex = 20;
            this.lbl_phone.Text = "Phone Number";
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(340, 187);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 33;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = true;
            // 
            // btn_add
            // 
            this.btn_add.Location = new System.Drawing.Point(259, 187);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(75, 23);
            this.btn_add.TabIndex = 32;
            this.btn_add.Text = "Add";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // AddressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 222);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.txt_state);
            this.Controls.Add(this.txt_zip);
            this.Controls.Add(this.txt_addrLine2);
            this.Controls.Add(this.txt_addrLine1);
            this.Controls.Add(this.txt_city);
            this.Controls.Add(this.txt_phone);
            this.Controls.Add(this.lbl_addrLine2);
            this.Controls.Add(this.lvl_zip);
            this.Controls.Add(this.lbl__state);
            this.Controls.Add(this.lbl_city);
            this.Controls.Add(this.lbl_addrLine1);
            this.Controls.Add(this.lbl_phone);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddressForm";
            this.Text = "New Address";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_state;
        private System.Windows.Forms.TextBox txt_zip;
        private System.Windows.Forms.TextBox txt_addrLine2;
        private System.Windows.Forms.TextBox txt_addrLine1;
        private System.Windows.Forms.TextBox txt_city;
        private System.Windows.Forms.TextBox txt_phone;
        private System.Windows.Forms.Label lbl_addrLine2;
        private System.Windows.Forms.Label lvl_zip;
        private System.Windows.Forms.Label lbl__state;
        private System.Windows.Forms.Label lbl_city;
        private System.Windows.Forms.Label lbl_addrLine1;
        private System.Windows.Forms.Label lbl_phone;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_add;
    }
}