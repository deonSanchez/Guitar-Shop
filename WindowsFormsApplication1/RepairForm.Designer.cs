namespace GuitarShop
{
    partial class RepairForm
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
            this.cmb_customer = new System.Windows.Forms.ComboBox();
            this.lbl_customer = new System.Windows.Forms.Label();
            this.datetimePickCompleted = new System.Windows.Forms.DateTimePicker();
            this.lbl_dateCompleted = new System.Windows.Forms.Label();
            this.txt_description = new System.Windows.Forms.TextBox();
            this.lbl_description = new System.Windows.Forms.Label();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_add = new System.Windows.Forms.Button();
            this.lbl_repairItems = new System.Windows.Forms.Label();
            this.lv_repairItems = new System.Windows.Forms.ListView();
            this.btn_repairItemsAdd = new System.Windows.Forms.Button();
            this.btn_repairItemsRemove = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmb_customer
            // 
            this.cmb_customer.FormattingEnabled = true;
            this.cmb_customer.ItemHeight = 13;
            this.cmb_customer.Location = new System.Drawing.Point(12, 25);
            this.cmb_customer.Margin = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.cmb_customer.Name = "cmb_customer";
            this.cmb_customer.Size = new System.Drawing.Size(414, 21);
            this.cmb_customer.TabIndex = 3;
            this.cmb_customer.SelectedIndexChanged += new System.EventHandler(this.cmb_customer_SelectedIndexChanged_1);
            // 
            // lbl_customer
            // 
            this.lbl_customer.AutoSize = true;
            this.lbl_customer.Location = new System.Drawing.Point(9, 9);
            this.lbl_customer.Name = "lbl_customer";
            this.lbl_customer.Size = new System.Drawing.Size(51, 13);
            this.lbl_customer.TabIndex = 2;
            this.lbl_customer.Text = "Customer";
            // 
            // datetimePickCompleted
            // 
            this.datetimePickCompleted.Location = new System.Drawing.Point(12, 68);
            this.datetimePickCompleted.Margin = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.datetimePickCompleted.Name = "datetimePickCompleted";
            this.datetimePickCompleted.Size = new System.Drawing.Size(414, 20);
            this.datetimePickCompleted.TabIndex = 4;
            this.datetimePickCompleted.ValueChanged += new System.EventHandler(this.datetimePickCompleted_ValueChanged);
            // 
            // lbl_dateCompleted
            // 
            this.lbl_dateCompleted.AutoSize = true;
            this.lbl_dateCompleted.Location = new System.Drawing.Point(9, 52);
            this.lbl_dateCompleted.Name = "lbl_dateCompleted";
            this.lbl_dateCompleted.Size = new System.Drawing.Size(83, 13);
            this.lbl_dateCompleted.TabIndex = 5;
            this.lbl_dateCompleted.Text = "Date Completed";
            // 
            // txt_description
            // 
            this.txt_description.Location = new System.Drawing.Point(12, 110);
            this.txt_description.Margin = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.txt_description.Multiline = true;
            this.txt_description.Name = "txt_description";
            this.txt_description.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_description.Size = new System.Drawing.Size(414, 88);
            this.txt_description.TabIndex = 6;
            this.txt_description.TextChanged += new System.EventHandler(this.txt_description_TextChanged);
            // 
            // lbl_description
            // 
            this.lbl_description.AutoSize = true;
            this.lbl_description.Location = new System.Drawing.Point(9, 94);
            this.lbl_description.Name = "lbl_description";
            this.lbl_description.Size = new System.Drawing.Size(60, 13);
            this.lbl_description.TabIndex = 7;
            this.lbl_description.Text = "Description";
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(351, 429);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 37;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = true;
            // 
            // btn_add
            // 
            this.btn_add.Enabled = false;
            this.btn_add.Location = new System.Drawing.Point(270, 429);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(75, 23);
            this.btn_add.TabIndex = 36;
            this.btn_add.Text = "Create";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // lbl_repairItems
            // 
            this.lbl_repairItems.AutoSize = true;
            this.lbl_repairItems.Location = new System.Drawing.Point(9, 204);
            this.lbl_repairItems.Name = "lbl_repairItems";
            this.lbl_repairItems.Size = new System.Drawing.Size(66, 13);
            this.lbl_repairItems.TabIndex = 38;
            this.lbl_repairItems.Text = "Repair Items";
            // 
            // lv_repairItems
            // 
            this.lv_repairItems.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.lv_repairItems.CheckBoxes = true;
            this.lv_repairItems.Location = new System.Drawing.Point(12, 220);
            this.lv_repairItems.Name = "lv_repairItems";
            this.lv_repairItems.Size = new System.Drawing.Size(414, 97);
            this.lv_repairItems.TabIndex = 42;
            this.lv_repairItems.UseCompatibleStateImageBehavior = false;
            this.lv_repairItems.View = System.Windows.Forms.View.Details;
            // 
            // btn_repairItemsAdd
            // 
            this.btn_repairItemsAdd.Location = new System.Drawing.Point(270, 323);
            this.btn_repairItemsAdd.Name = "btn_repairItemsAdd";
            this.btn_repairItemsAdd.Size = new System.Drawing.Size(75, 23);
            this.btn_repairItemsAdd.TabIndex = 40;
            this.btn_repairItemsAdd.Text = "Add";
            this.btn_repairItemsAdd.UseVisualStyleBackColor = true;
            this.btn_repairItemsAdd.Click += new System.EventHandler(this.btn_orderItemsAdd_Click);
            // 
            // btn_repairItemsRemove
            // 
            this.btn_repairItemsRemove.Enabled = false;
            this.btn_repairItemsRemove.Location = new System.Drawing.Point(351, 323);
            this.btn_repairItemsRemove.Name = "btn_repairItemsRemove";
            this.btn_repairItemsRemove.Size = new System.Drawing.Size(75, 23);
            this.btn_repairItemsRemove.TabIndex = 41;
            this.btn_repairItemsRemove.Text = "Remove";
            this.btn_repairItemsRemove.UseVisualStyleBackColor = true;
            this.btn_repairItemsRemove.Click += new System.EventHandler(this.btn_repairItemsRemove_Click);
            // 
            // RepairForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 464);
            this.Controls.Add(this.lv_repairItems);
            this.Controls.Add(this.btn_repairItemsAdd);
            this.Controls.Add(this.btn_repairItemsRemove);
            this.Controls.Add(this.lbl_repairItems);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.lbl_description);
            this.Controls.Add(this.txt_description);
            this.Controls.Add(this.lbl_dateCompleted);
            this.Controls.Add(this.datetimePickCompleted);
            this.Controls.Add(this.cmb_customer);
            this.Controls.Add(this.lbl_customer);
            this.Name = "RepairForm";
            this.Text = "Repairs";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmb_customer;
        private System.Windows.Forms.Label lbl_customer;
        private System.Windows.Forms.DateTimePicker datetimePickCompleted;
        private System.Windows.Forms.Label lbl_dateCompleted;
        private System.Windows.Forms.TextBox txt_description;
        private System.Windows.Forms.Label lbl_description;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Label lbl_repairItems;
        private System.Windows.Forms.ListView lv_repairItems;
        private System.Windows.Forms.Button btn_repairItemsAdd;
        private System.Windows.Forms.Button btn_repairItemsRemove;
    }
}