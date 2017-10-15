using System;

namespace GuitarShop
{
    partial class OrderForm
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
            this.lbl_customer = new System.Windows.Forms.Label();
            this.cmb_customer = new System.Windows.Forms.ComboBox();
            this.btn_customerCreate = new System.Windows.Forms.Button();
            this.lbl_cardType = new System.Windows.Forms.Label();
            this.cmb_cardType = new System.Windows.Forms.ComboBox();
            this.lbl_cardNumber = new System.Windows.Forms.Label();
            this.txtb_cardNumber = new System.Windows.Forms.TextBox();
            this.lbl_orderItems = new System.Windows.Forms.Label();
            this.lv_orderItems = new System.Windows.Forms.ListView();
            this.btn_orderItemsRemove = new System.Windows.Forms.Button();
            this.btn_orderItemsAdd = new System.Windows.Forms.Button();
            this.lbl_subtotal = new System.Windows.Forms.Label();
            this.txtb_subtotal = new System.Windows.Forms.TextBox();
            this.txtb_tax = new System.Windows.Forms.TextBox();
            this.lbl_tax = new System.Windows.Forms.Label();
            this.txtb_shipping = new System.Windows.Forms.TextBox();
            this.lbl_shipping = new System.Windows.Forms.Label();
            this.txtb_orderTotal = new System.Windows.Forms.TextBox();
            this.lbl_orderTotal = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_customer
            // 
            this.lbl_customer.AutoSize = true;
            this.lbl_customer.Location = new System.Drawing.Point(12, 9);
            this.lbl_customer.Name = "lbl_customer";
            this.lbl_customer.Size = new System.Drawing.Size(51, 13);
            this.lbl_customer.TabIndex = 0;
            this.lbl_customer.Text = "Customer";
            // 
            // cmb_customer
            // 
            this.cmb_customer.FormattingEnabled = true;
            this.cmb_customer.ItemHeight = 13;
            this.cmb_customer.Location = new System.Drawing.Point(15, 25);
            this.cmb_customer.Margin = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.cmb_customer.Name = "cmb_customer";
            this.cmb_customer.Size = new System.Drawing.Size(559, 21);
            this.cmb_customer.TabIndex = 1;
            this.cmb_customer.SelectedIndexChanged += new System.EventHandler(this.cmb_customer_SelectedIndexChanged);
            // 
            // btn_customerCreate
            // 
            this.btn_customerCreate.Location = new System.Drawing.Point(580, 25);
            this.btn_customerCreate.Name = "btn_customerCreate";
            this.btn_customerCreate.Size = new System.Drawing.Size(75, 23);
            this.btn_customerCreate.TabIndex = 2;
            this.btn_customerCreate.Text = "Create new";
            this.btn_customerCreate.UseVisualStyleBackColor = true;
            this.btn_customerCreate.Click += new System.EventHandler(this.btn_customerCreate_Click);
            // 
            // lbl_cardType
            // 
            this.lbl_cardType.AutoSize = true;
            this.lbl_cardType.Location = new System.Drawing.Point(12, 52);
            this.lbl_cardType.Name = "lbl_cardType";
            this.lbl_cardType.Size = new System.Drawing.Size(56, 13);
            this.lbl_cardType.TabIndex = 0;
            this.lbl_cardType.Text = "Card Type";
            // 
            // cmb_cardType
            // 
            this.cmb_cardType.FormattingEnabled = true;
            this.cmb_cardType.ItemHeight = 13;
            this.cmb_cardType.Location = new System.Drawing.Point(15, 68);
            this.cmb_cardType.Margin = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.cmb_cardType.Name = "cmb_cardType";
            this.cmb_cardType.Size = new System.Drawing.Size(640, 21);
            this.cmb_cardType.TabIndex = 1;
            // 
            // lbl_cardNumber
            // 
            this.lbl_cardNumber.AutoSize = true;
            this.lbl_cardNumber.Location = new System.Drawing.Point(12, 95);
            this.lbl_cardNumber.Name = "lbl_cardNumber";
            this.lbl_cardNumber.Size = new System.Drawing.Size(69, 13);
            this.lbl_cardNumber.TabIndex = 0;
            this.lbl_cardNumber.Text = "Card Number";
            this.lbl_cardNumber.Click += new System.EventHandler(this.label3_Click);
            // 
            // txtb_cardNumber
            // 
            this.txtb_cardNumber.Location = new System.Drawing.Point(15, 111);
            this.txtb_cardNumber.Margin = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.txtb_cardNumber.Name = "txtb_cardNumber";
            this.txtb_cardNumber.Size = new System.Drawing.Size(640, 20);
            this.txtb_cardNumber.TabIndex = 3;
            // 
            // lbl_orderItems
            // 
            this.lbl_orderItems.AutoSize = true;
            this.lbl_orderItems.Location = new System.Drawing.Point(12, 137);
            this.lbl_orderItems.Name = "lbl_orderItems";
            this.lbl_orderItems.Size = new System.Drawing.Size(61, 13);
            this.lbl_orderItems.TabIndex = 0;
            this.lbl_orderItems.Text = "Order Items";
            this.lbl_orderItems.Click += new System.EventHandler(this.label3_Click);
            // 
            // lv_orderItems
            // 
            this.lv_orderItems.Location = new System.Drawing.Point(15, 153);
            this.lv_orderItems.Name = "lv_orderItems";
            this.lv_orderItems.Size = new System.Drawing.Size(640, 97);
            this.lv_orderItems.TabIndex = 4;
            this.lv_orderItems.UseCompatibleStateImageBehavior = false;
            // 
            // btn_orderItemsRemove
            // 
            this.btn_orderItemsRemove.Location = new System.Drawing.Point(580, 256);
            this.btn_orderItemsRemove.Name = "btn_orderItemsRemove";
            this.btn_orderItemsRemove.Size = new System.Drawing.Size(75, 23);
            this.btn_orderItemsRemove.TabIndex = 2;
            this.btn_orderItemsRemove.Text = "Remove";
            this.btn_orderItemsRemove.UseVisualStyleBackColor = true;
            this.btn_orderItemsRemove.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn_orderItemsAdd
            // 
            this.btn_orderItemsAdd.Location = new System.Drawing.Point(499, 256);
            this.btn_orderItemsAdd.Name = "btn_orderItemsAdd";
            this.btn_orderItemsAdd.Size = new System.Drawing.Size(75, 23);
            this.btn_orderItemsAdd.TabIndex = 2;
            this.btn_orderItemsAdd.Text = "Add";
            this.btn_orderItemsAdd.UseVisualStyleBackColor = true;
            this.btn_orderItemsAdd.Click += new System.EventHandler(this.button2_Click);
            // 
            // lbl_subtotal
            // 
            this.lbl_subtotal.AutoSize = true;
            this.lbl_subtotal.Location = new System.Drawing.Point(503, 320);
            this.lbl_subtotal.Name = "lbl_subtotal";
            this.lbl_subtotal.Size = new System.Drawing.Size(46, 13);
            this.lbl_subtotal.TabIndex = 0;
            this.lbl_subtotal.Text = "Subtotal";
            this.lbl_subtotal.Click += new System.EventHandler(this.label5_Click);
            // 
            // txtb_subtotal
            // 
            this.txtb_subtotal.Location = new System.Drawing.Point(555, 317);
            this.txtb_subtotal.Name = "txtb_subtotal";
            this.txtb_subtotal.Size = new System.Drawing.Size(100, 20);
            this.txtb_subtotal.TabIndex = 5;
            // 
            // txtb_tax
            // 
            this.txtb_tax.Location = new System.Drawing.Point(555, 343);
            this.txtb_tax.Name = "txtb_tax";
            this.txtb_tax.Size = new System.Drawing.Size(100, 20);
            this.txtb_tax.TabIndex = 5;
            // 
            // lbl_tax
            // 
            this.lbl_tax.AutoSize = true;
            this.lbl_tax.Location = new System.Drawing.Point(524, 346);
            this.lbl_tax.Name = "lbl_tax";
            this.lbl_tax.Size = new System.Drawing.Size(25, 13);
            this.lbl_tax.TabIndex = 0;
            this.lbl_tax.Text = "Tax";
            // 
            // txtb_shipping
            // 
            this.txtb_shipping.Location = new System.Drawing.Point(555, 369);
            this.txtb_shipping.Name = "txtb_shipping";
            this.txtb_shipping.Size = new System.Drawing.Size(100, 20);
            this.txtb_shipping.TabIndex = 5;
            // 
            // lbl_shipping
            // 
            this.lbl_shipping.AutoSize = true;
            this.lbl_shipping.Location = new System.Drawing.Point(501, 372);
            this.lbl_shipping.Name = "lbl_shipping";
            this.lbl_shipping.Size = new System.Drawing.Size(48, 13);
            this.lbl_shipping.TabIndex = 0;
            this.lbl_shipping.Text = "Shipping";
            // 
            // txtb_orderTotal
            // 
            this.txtb_orderTotal.Location = new System.Drawing.Point(555, 395);
            this.txtb_orderTotal.Name = "txtb_orderTotal";
            this.txtb_orderTotal.Size = new System.Drawing.Size(100, 20);
            this.txtb_orderTotal.TabIndex = 5;
            // 
            // lbl_orderTotal
            // 
            this.lbl_orderTotal.AutoSize = true;
            this.lbl_orderTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_orderTotal.Location = new System.Drawing.Point(478, 398);
            this.lbl_orderTotal.Name = "lbl_orderTotal";
            this.lbl_orderTotal.Size = new System.Drawing.Size(71, 13);
            this.lbl_orderTotal.TabIndex = 0;
            this.lbl_orderTotal.Text = "Order Total";
            // 
            // OrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 477);
            this.Controls.Add(this.txtb_orderTotal);
            this.Controls.Add(this.txtb_shipping);
            this.Controls.Add(this.txtb_tax);
            this.Controls.Add(this.txtb_subtotal);
            this.Controls.Add(this.lv_orderItems);
            this.Controls.Add(this.txtb_cardNumber);
            this.Controls.Add(this.btn_orderItemsAdd);
            this.Controls.Add(this.btn_orderItemsRemove);
            this.Controls.Add(this.btn_customerCreate);
            this.Controls.Add(this.cmb_cardType);
            this.Controls.Add(this.cmb_customer);
            this.Controls.Add(this.lbl_orderItems);
            this.Controls.Add(this.lbl_cardNumber);
            this.Controls.Add(this.lbl_cardType);
            this.Controls.Add(this.lbl_shipping);
            this.Controls.Add(this.lbl_orderTotal);
            this.Controls.Add(this.lbl_tax);
            this.Controls.Add(this.lbl_subtotal);
            this.Controls.Add(this.lbl_customer);
            this.Name = "OrderForm";
            this.Text = "Create New Order";
            this.Load += new System.EventHandler(this.OrderForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void label5_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.Label lbl_customer;
        private System.Windows.Forms.ComboBox cmb_customer;
        private System.Windows.Forms.Button btn_customerCreate;
        private System.Windows.Forms.Label lbl_cardType;
        private System.Windows.Forms.ComboBox cmb_cardType;
        private System.Windows.Forms.Label lbl_cardNumber;
        private System.Windows.Forms.TextBox txtb_cardNumber;
        private System.Windows.Forms.Label lbl_orderItems;
        private System.Windows.Forms.ListView lv_orderItems;
        private System.Windows.Forms.Button btn_orderItemsRemove;
        private System.Windows.Forms.Button btn_orderItemsAdd;
        private System.Windows.Forms.Label lbl_subtotal;
        private System.Windows.Forms.TextBox txtb_subtotal;
        private System.Windows.Forms.TextBox txtb_tax;
        private System.Windows.Forms.Label lbl_tax;
        private System.Windows.Forms.TextBox txtb_shipping;
        private System.Windows.Forms.Label lbl_shipping;
        private System.Windows.Forms.TextBox txtb_orderTotal;
        private System.Windows.Forms.Label lbl_orderTotal;
    }
}