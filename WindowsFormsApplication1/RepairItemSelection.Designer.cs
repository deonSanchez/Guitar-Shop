namespace GuitarShop
{
    partial class RepairItemSelection
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
            this.lbl_Item = new System.Windows.Forms.Label();
            this.cmb_Item = new System.Windows.Forms.ComboBox();
            this.lbl_repairType = new System.Windows.Forms.Label();
            this.txt_repairType = new System.Windows.Forms.TextBox();
            this.lbl_labor = new System.Windows.Forms.Label();
            this.updn_labor = new System.Windows.Forms.NumericUpDown();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_add = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.updn_labor)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_Item
            // 
            this.lbl_Item.AutoSize = true;
            this.lbl_Item.Location = new System.Drawing.Point(12, 9);
            this.lbl_Item.Name = "lbl_Item";
            this.lbl_Item.Size = new System.Drawing.Size(27, 13);
            this.lbl_Item.TabIndex = 1;
            this.lbl_Item.Text = "Item";
            // 
            // cmb_Item
            // 
            this.cmb_Item.FormattingEnabled = true;
            this.cmb_Item.Location = new System.Drawing.Point(15, 25);
            this.cmb_Item.Margin = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.cmb_Item.Name = "cmb_Item";
            this.cmb_Item.Size = new System.Drawing.Size(257, 21);
            this.cmb_Item.TabIndex = 2;
            this.cmb_Item.SelectedIndexChanged += new System.EventHandler(this.cmb_Item_SelectedIndexChanged);
            // 
            // lbl_repairType
            // 
            this.lbl_repairType.AutoSize = true;
            this.lbl_repairType.Location = new System.Drawing.Point(12, 52);
            this.lbl_repairType.Name = "lbl_repairType";
            this.lbl_repairType.Size = new System.Drawing.Size(65, 13);
            this.lbl_repairType.TabIndex = 3;
            this.lbl_repairType.Text = "Repair Type";
            // 
            // txt_repairType
            // 
            this.txt_repairType.Location = new System.Drawing.Point(15, 68);
            this.txt_repairType.Margin = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.txt_repairType.Name = "txt_repairType";
            this.txt_repairType.Size = new System.Drawing.Size(257, 20);
            this.txt_repairType.TabIndex = 4;
            this.txt_repairType.TextChanged += new System.EventHandler(this.txt_repairType_TextChanged);
            // 
            // lbl_labor
            // 
            this.lbl_labor.AutoSize = true;
            this.lbl_labor.Location = new System.Drawing.Point(12, 94);
            this.lbl_labor.Name = "lbl_labor";
            this.lbl_labor.Size = new System.Drawing.Size(58, 13);
            this.lbl_labor.TabIndex = 5;
            this.lbl_labor.Text = "Labor Cost";
            // 
            // updn_labor
            // 
            this.updn_labor.DecimalPlaces = 2;
            this.updn_labor.Location = new System.Drawing.Point(15, 110);
            this.updn_labor.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.updn_labor.Name = "updn_labor";
            this.updn_labor.Size = new System.Drawing.Size(257, 20);
            this.updn_labor.TabIndex = 6;
            this.updn_labor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.updn_labor.ThousandsSeparator = true;
            this.updn_labor.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(197, 166);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 8;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_add
            // 
            this.btn_add.Enabled = false;
            this.btn_add.Location = new System.Drawing.Point(116, 166);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(75, 23);
            this.btn_add.TabIndex = 7;
            this.btn_add.Text = "Add";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // RepairItemSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 200);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.updn_labor);
            this.Controls.Add(this.lbl_labor);
            this.Controls.Add(this.txt_repairType);
            this.Controls.Add(this.lbl_repairType);
            this.Controls.Add(this.cmb_Item);
            this.Controls.Add(this.lbl_Item);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RepairItemSelection";
            this.Text = "Repair Items";
            ((System.ComponentModel.ISupportInitialize)(this.updn_labor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbl_Item;
        private System.Windows.Forms.ComboBox cmb_Item;
        private System.Windows.Forms.Label lbl_repairType;
        private System.Windows.Forms.TextBox txt_repairType;
        private System.Windows.Forms.Label lbl_labor;
        private System.Windows.Forms.NumericUpDown updn_labor;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_add;
    }
}