namespace GuitarShop
{
    partial class OrderItemSelection
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
            this.cmb_orderItemSelect = new System.Windows.Forms.ComboBox();
            this.lbl_quantity = new System.Windows.Forms.Label();
            this.lbl_item = new System.Windows.Forms.Label();
            this.num_quantity = new System.Windows.Forms.NumericUpDown();
            this.btn_add = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.lbl_promo = new System.Windows.Forms.Label();
            this.txtb_promoCode = new System.Windows.Forms.TextBox();
            this.lbl_validation = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.num_quantity)).BeginInit();
            this.SuspendLayout();
            // 
            // cmb_orderItemSelect
            // 
            this.cmb_orderItemSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_orderItemSelect.FormattingEnabled = true;
            this.cmb_orderItemSelect.Location = new System.Drawing.Point(12, 25);
            this.cmb_orderItemSelect.Margin = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.cmb_orderItemSelect.Name = "cmb_orderItemSelect";
            this.cmb_orderItemSelect.Size = new System.Drawing.Size(380, 21);
            this.cmb_orderItemSelect.TabIndex = 0;
            this.cmb_orderItemSelect.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // lbl_quantity
            // 
            this.lbl_quantity.AutoSize = true;
            this.lbl_quantity.Location = new System.Drawing.Point(9, 52);
            this.lbl_quantity.Name = "lbl_quantity";
            this.lbl_quantity.Size = new System.Drawing.Size(46, 13);
            this.lbl_quantity.TabIndex = 2;
            this.lbl_quantity.Text = "Quantity";
            // 
            // lbl_item
            // 
            this.lbl_item.AutoSize = true;
            this.lbl_item.Location = new System.Drawing.Point(9, 9);
            this.lbl_item.Name = "lbl_item";
            this.lbl_item.Size = new System.Drawing.Size(27, 13);
            this.lbl_item.TabIndex = 2;
            this.lbl_item.Text = "Item";
            // 
            // num_quantity
            // 
            this.num_quantity.Location = new System.Drawing.Point(12, 68);
            this.num_quantity.Margin = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.num_quantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_quantity.Name = "num_quantity";
            this.num_quantity.Size = new System.Drawing.Size(380, 20);
            this.num_quantity.TabIndex = 3;
            this.num_quantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btn_add
            // 
            this.btn_add.Enabled = false;
            this.btn_add.Location = new System.Drawing.Point(236, 167);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(75, 23);
            this.btn_add.TabIndex = 4;
            this.btn_add.Text = "Add";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(317, 167);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 5;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // lbl_promo
            // 
            this.lbl_promo.AutoSize = true;
            this.lbl_promo.Location = new System.Drawing.Point(9, 94);
            this.lbl_promo.Name = "lbl_promo";
            this.lbl_promo.Size = new System.Drawing.Size(65, 13);
            this.lbl_promo.TabIndex = 6;
            this.lbl_promo.Text = "Promo Code";
            // 
            // txtb_promoCode
            // 
            this.txtb_promoCode.Enabled = false;
            this.txtb_promoCode.Location = new System.Drawing.Point(12, 110);
            this.txtb_promoCode.MaxLength = 3;
            this.txtb_promoCode.Name = "txtb_promoCode";
            this.txtb_promoCode.Size = new System.Drawing.Size(380, 20);
            this.txtb_promoCode.TabIndex = 7;
            this.txtb_promoCode.TextChanged += new System.EventHandler(this.txtb_promoCode_TextChanged);
            // 
            // lbl_validation
            // 
            this.lbl_validation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_validation.ForeColor = System.Drawing.Color.Maroon;
            this.lbl_validation.Location = new System.Drawing.Point(12, 133);
            this.lbl_validation.Name = "lbl_validation";
            this.lbl_validation.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbl_validation.Size = new System.Drawing.Size(380, 17);
            this.lbl_validation.TabIndex = 8;
            this.lbl_validation.Text = "The code entered is not valid. Please remove or try again.";
            this.lbl_validation.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // OrderItemSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 202);
            this.Controls.Add(this.lbl_validation);
            this.Controls.Add(this.txtb_promoCode);
            this.Controls.Add(this.lbl_promo);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.num_quantity);
            this.Controls.Add(this.lbl_item);
            this.Controls.Add(this.lbl_quantity);
            this.Controls.Add(this.cmb_orderItemSelect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OrderItemSelection";
            this.Text = "Select Order Item";
            ((System.ComponentModel.ISupportInitialize)(this.num_quantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmb_orderItemSelect;
        private System.Windows.Forms.Label lbl_quantity;
        private System.Windows.Forms.Label lbl_item;
        private System.Windows.Forms.NumericUpDown num_quantity;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Label lbl_promo;
        private System.Windows.Forms.TextBox txtb_promoCode;
        private System.Windows.Forms.Label lbl_validation;
    }
}