namespace GuitarShop
{
    partial class PromotionForm
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
            this.lbl_product = new System.Windows.Forms.Label();
            this.cmb_product = new System.Windows.Forms.ComboBox();
            this.lbl_discountAmount = new System.Windows.Forms.Label();
            this.num_discountAmount = new System.Windows.Forms.NumericUpDown();
            this.lbl_description = new System.Windows.Forms.Label();
            this.txt_description = new System.Windows.Forms.TextBox();
            this.lbl_start = new System.Windows.Forms.Label();
            this.dt_start = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dt_end = new System.Windows.Forms.DateTimePicker();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_add = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.num_discountAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_product
            // 
            this.lbl_product.AutoSize = true;
            this.lbl_product.Location = new System.Drawing.Point(12, 9);
            this.lbl_product.Name = "lbl_product";
            this.lbl_product.Size = new System.Drawing.Size(44, 13);
            this.lbl_product.TabIndex = 0;
            this.lbl_product.Text = "Product";
            // 
            // cmb_product
            // 
            this.cmb_product.FormattingEnabled = true;
            this.cmb_product.Location = new System.Drawing.Point(15, 25);
            this.cmb_product.Margin = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.cmb_product.Name = "cmb_product";
            this.cmb_product.Size = new System.Drawing.Size(257, 21);
            this.cmb_product.TabIndex = 1;
            this.cmb_product.SelectedIndexChanged += new System.EventHandler(this.cmb_product_SelectedIndexChanged);
            // 
            // lbl_discountAmount
            // 
            this.lbl_discountAmount.AutoSize = true;
            this.lbl_discountAmount.Location = new System.Drawing.Point(12, 52);
            this.lbl_discountAmount.Name = "lbl_discountAmount";
            this.lbl_discountAmount.Size = new System.Drawing.Size(88, 13);
            this.lbl_discountAmount.TabIndex = 3;
            this.lbl_discountAmount.Text = "Discount Amount";
            // 
            // num_discountAmount
            // 
            this.num_discountAmount.DecimalPlaces = 2;
            this.num_discountAmount.Location = new System.Drawing.Point(15, 68);
            this.num_discountAmount.Margin = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.num_discountAmount.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.num_discountAmount.Name = "num_discountAmount";
            this.num_discountAmount.Size = new System.Drawing.Size(257, 20);
            this.num_discountAmount.TabIndex = 4;
            this.num_discountAmount.ValueChanged += new System.EventHandler(this.num_discountAmount_ValueChanged);
            // 
            // lbl_description
            // 
            this.lbl_description.AutoSize = true;
            this.lbl_description.Location = new System.Drawing.Point(12, 94);
            this.lbl_description.Name = "lbl_description";
            this.lbl_description.Size = new System.Drawing.Size(60, 13);
            this.lbl_description.TabIndex = 5;
            this.lbl_description.Text = "Description";
            // 
            // txt_description
            // 
            this.txt_description.Location = new System.Drawing.Point(15, 110);
            this.txt_description.Margin = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.txt_description.Multiline = true;
            this.txt_description.Name = "txt_description";
            this.txt_description.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_description.Size = new System.Drawing.Size(257, 75);
            this.txt_description.TabIndex = 6;
            this.txt_description.TextChanged += new System.EventHandler(this.txt_description_TextChanged);
            // 
            // lbl_start
            // 
            this.lbl_start.AutoSize = true;
            this.lbl_start.Location = new System.Drawing.Point(12, 191);
            this.lbl_start.Name = "lbl_start";
            this.lbl_start.Size = new System.Drawing.Size(55, 13);
            this.lbl_start.TabIndex = 7;
            this.lbl_start.Text = "Start Date";
            // 
            // dt_start
            // 
            this.dt_start.Location = new System.Drawing.Point(15, 207);
            this.dt_start.Margin = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.dt_start.Name = "dt_start";
            this.dt_start.Size = new System.Drawing.Size(257, 20);
            this.dt_start.TabIndex = 8;
            this.dt_start.ValueChanged += new System.EventHandler(this.dt_start_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 233);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "End Date";
            // 
            // dt_end
            // 
            this.dt_end.Location = new System.Drawing.Point(15, 249);
            this.dt_end.Margin = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.dt_end.Name = "dt_end";
            this.dt_end.Size = new System.Drawing.Size(257, 20);
            this.dt_end.TabIndex = 10;
            this.dt_end.ValueChanged += new System.EventHandler(this.dt_end_ValueChanged);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(197, 308);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 12;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_add
            // 
            this.btn_add.Enabled = false;
            this.btn_add.Location = new System.Drawing.Point(116, 308);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(75, 23);
            this.btn_add.TabIndex = 11;
            this.btn_add.Text = "Add";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // PromotionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 343);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.dt_end);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dt_start);
            this.Controls.Add(this.lbl_start);
            this.Controls.Add(this.txt_description);
            this.Controls.Add(this.lbl_description);
            this.Controls.Add(this.num_discountAmount);
            this.Controls.Add(this.lbl_discountAmount);
            this.Controls.Add(this.cmb_product);
            this.Controls.Add(this.lbl_product);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PromotionForm";
            this.Text = "Promotions";
            ((System.ComponentModel.ISupportInitialize)(this.num_discountAmount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_product;
        private System.Windows.Forms.ComboBox cmb_product;
        private System.Windows.Forms.Label lbl_discountAmount;
        private System.Windows.Forms.NumericUpDown num_discountAmount;
        private System.Windows.Forms.Label lbl_description;
        private System.Windows.Forms.TextBox txt_description;
        private System.Windows.Forms.Label lbl_start;
        private System.Windows.Forms.DateTimePicker dt_start;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dt_end;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_add;
    }
}