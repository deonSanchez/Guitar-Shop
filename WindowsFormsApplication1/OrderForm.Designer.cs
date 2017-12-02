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
            this.lbl_cardType = new System.Windows.Forms.Label();
            this.cmb_cardType = new System.Windows.Forms.ComboBox();
            this.lbl_orderItems = new System.Windows.Forms.Label();
            this.lv_orderItems = new System.Windows.Forms.ListView();
            this.btn_orderItemsRemove = new System.Windows.Forms.Button();
            this.btn_orderItemsAdd = new System.Windows.Forms.Button();
            this.lbl_subtotal = new System.Windows.Forms.Label();
            this.txtb_subtotal = new System.Windows.Forms.TextBox();
            this.txtb_tax = new System.Windows.Forms.TextBox();
            this.lbl_tax = new System.Windows.Forms.Label();
            this.lbl_shipping = new System.Windows.Forms.Label();
            this.txtb_orderTotal = new System.Windows.Forms.TextBox();
            this.lbl_orderTotal = new System.Windows.Forms.Label();
            this.btn_sumbit = new System.Windows.Forms.Button();
            this.updn_shipping = new System.Windows.Forms.NumericUpDown();
            this.lbl_cardNumber = new System.Windows.Forms.Label();
            this.txtb_cardNumber = new System.Windows.Forms.TextBox();
            this.lbl_billingAddress = new System.Windows.Forms.Label();
            this.cmb_billlingAddress = new System.Windows.Forms.ComboBox();
            this.lbl_shippingAddress = new System.Windows.Forms.Label();
            this.cmb_shippingAddress = new System.Windows.Forms.ComboBox();
            this.lbl_shipDate = new System.Windows.Forms.Label();
            this.dt_ship = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.updn_shipping)).BeginInit();
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
            this.cmb_customer.Size = new System.Drawing.Size(640, 21);
            this.cmb_customer.TabIndex = 1;
            this.cmb_customer.SelectedIndexChanged += new System.EventHandler(this.cmb_customer_SelectedIndexChanged);
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
            this.cmb_cardType.Size = new System.Drawing.Size(144, 21);
            this.cmb_cardType.TabIndex = 1;
            this.cmb_cardType.SelectedIndexChanged += new System.EventHandler(this.cmb_cardType_SelectedIndexChanged);
            // 
            // lbl_orderItems
            // 
            this.lbl_orderItems.AutoSize = true;
            this.lbl_orderItems.Location = new System.Drawing.Point(12, 223);
            this.lbl_orderItems.Name = "lbl_orderItems";
            this.lbl_orderItems.Size = new System.Drawing.Size(61, 13);
            this.lbl_orderItems.TabIndex = 0;
            this.lbl_orderItems.Text = "Order Items";
            // 
            // lv_orderItems
            // 
            this.lv_orderItems.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.lv_orderItems.CheckBoxes = true;
            this.lv_orderItems.Location = new System.Drawing.Point(15, 239);
            this.lv_orderItems.Name = "lv_orderItems";
            this.lv_orderItems.Size = new System.Drawing.Size(640, 97);
            this.lv_orderItems.TabIndex = 4;
            this.lv_orderItems.UseCompatibleStateImageBehavior = false;
            this.lv_orderItems.View = System.Windows.Forms.View.Details;
            this.lv_orderItems.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lv_orderItems_ItemChecked);
            // 
            // btn_orderItemsRemove
            // 
            this.btn_orderItemsRemove.Enabled = false;
            this.btn_orderItemsRemove.Location = new System.Drawing.Point(580, 342);
            this.btn_orderItemsRemove.Name = "btn_orderItemsRemove";
            this.btn_orderItemsRemove.Size = new System.Drawing.Size(75, 23);
            this.btn_orderItemsRemove.TabIndex = 2;
            this.btn_orderItemsRemove.Text = "Remove";
            this.btn_orderItemsRemove.UseVisualStyleBackColor = true;
            this.btn_orderItemsRemove.Click += new System.EventHandler(this.btn_orderItemsRemove_Click);
            // 
            // btn_orderItemsAdd
            // 
            this.btn_orderItemsAdd.Location = new System.Drawing.Point(499, 342);
            this.btn_orderItemsAdd.Name = "btn_orderItemsAdd";
            this.btn_orderItemsAdd.Size = new System.Drawing.Size(75, 23);
            this.btn_orderItemsAdd.TabIndex = 2;
            this.btn_orderItemsAdd.Text = "Add";
            this.btn_orderItemsAdd.UseVisualStyleBackColor = true;
            this.btn_orderItemsAdd.Click += new System.EventHandler(this.btn_orderItemsAdd_Click);
            // 
            // lbl_subtotal
            // 
            this.lbl_subtotal.AutoSize = true;
            this.lbl_subtotal.Location = new System.Drawing.Point(503, 392);
            this.lbl_subtotal.Name = "lbl_subtotal";
            this.lbl_subtotal.Size = new System.Drawing.Size(46, 13);
            this.lbl_subtotal.TabIndex = 0;
            this.lbl_subtotal.Text = "Subtotal";
            this.lbl_subtotal.Click += new System.EventHandler(this.label5_Click);
            // 
            // txtb_subtotal
            // 
            this.txtb_subtotal.Location = new System.Drawing.Point(555, 389);
            this.txtb_subtotal.Name = "txtb_subtotal";
            this.txtb_subtotal.ReadOnly = true;
            this.txtb_subtotal.Size = new System.Drawing.Size(100, 20);
            this.txtb_subtotal.TabIndex = 5;
            this.txtb_subtotal.Text = "0";
            this.txtb_subtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtb_tax
            // 
            this.txtb_tax.Location = new System.Drawing.Point(555, 415);
            this.txtb_tax.Name = "txtb_tax";
            this.txtb_tax.ReadOnly = true;
            this.txtb_tax.Size = new System.Drawing.Size(100, 20);
            this.txtb_tax.TabIndex = 5;
            this.txtb_tax.Text = "0";
            this.txtb_tax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbl_tax
            // 
            this.lbl_tax.AutoSize = true;
            this.lbl_tax.Location = new System.Drawing.Point(524, 418);
            this.lbl_tax.Name = "lbl_tax";
            this.lbl_tax.Size = new System.Drawing.Size(25, 13);
            this.lbl_tax.TabIndex = 0;
            this.lbl_tax.Text = "Tax";
            // 
            // lbl_shipping
            // 
            this.lbl_shipping.AutoSize = true;
            this.lbl_shipping.Location = new System.Drawing.Point(501, 444);
            this.lbl_shipping.Name = "lbl_shipping";
            this.lbl_shipping.Size = new System.Drawing.Size(48, 13);
            this.lbl_shipping.TabIndex = 0;
            this.lbl_shipping.Text = "Shipping";
            // 
            // txtb_orderTotal
            // 
            this.txtb_orderTotal.Location = new System.Drawing.Point(555, 467);
            this.txtb_orderTotal.Name = "txtb_orderTotal";
            this.txtb_orderTotal.ReadOnly = true;
            this.txtb_orderTotal.Size = new System.Drawing.Size(100, 20);
            this.txtb_orderTotal.TabIndex = 5;
            this.txtb_orderTotal.Text = "0";
            this.txtb_orderTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbl_orderTotal
            // 
            this.lbl_orderTotal.AutoSize = true;
            this.lbl_orderTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_orderTotal.Location = new System.Drawing.Point(478, 470);
            this.lbl_orderTotal.Name = "lbl_orderTotal";
            this.lbl_orderTotal.Size = new System.Drawing.Size(71, 13);
            this.lbl_orderTotal.TabIndex = 0;
            this.lbl_orderTotal.Text = "Order Total";
            // 
            // btn_sumbit
            // 
            this.btn_sumbit.Enabled = false;
            this.btn_sumbit.Location = new System.Drawing.Point(580, 509);
            this.btn_sumbit.Name = "btn_sumbit";
            this.btn_sumbit.Size = new System.Drawing.Size(75, 23);
            this.btn_sumbit.TabIndex = 6;
            this.btn_sumbit.Text = "Submit";
            this.btn_sumbit.UseVisualStyleBackColor = true;
            this.btn_sumbit.Click += new System.EventHandler(this.btn_sumbit_Click);
            // 
            // updn_shipping
            // 
            this.updn_shipping.DecimalPlaces = 2;
            this.updn_shipping.Location = new System.Drawing.Point(555, 441);
            this.updn_shipping.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.updn_shipping.Name = "updn_shipping";
            this.updn_shipping.Size = new System.Drawing.Size(100, 20);
            this.updn_shipping.TabIndex = 7;
            this.updn_shipping.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.updn_shipping.ThousandsSeparator = true;
            this.updn_shipping.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.updn_shipping.ValueChanged += new System.EventHandler(this.updn_shipping_ValueChanged);
            // 
            // lbl_cardNumber
            // 
            this.lbl_cardNumber.AutoSize = true;
            this.lbl_cardNumber.Location = new System.Drawing.Point(162, 52);
            this.lbl_cardNumber.Name = "lbl_cardNumber";
            this.lbl_cardNumber.Size = new System.Drawing.Size(69, 13);
            this.lbl_cardNumber.TabIndex = 0;
            this.lbl_cardNumber.Text = "Card Number";
            // 
            // txtb_cardNumber
            // 
            this.txtb_cardNumber.Location = new System.Drawing.Point(165, 69);
            this.txtb_cardNumber.Margin = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.txtb_cardNumber.MaxLength = 16;
            this.txtb_cardNumber.Name = "txtb_cardNumber";
            this.txtb_cardNumber.Size = new System.Drawing.Size(490, 20);
            this.txtb_cardNumber.TabIndex = 3;
            this.txtb_cardNumber.TextChanged += new System.EventHandler(this.txtb_cardNumber_TextChanged);
            // 
            // lbl_billingAddress
            // 
            this.lbl_billingAddress.AutoSize = true;
            this.lbl_billingAddress.Location = new System.Drawing.Point(12, 95);
            this.lbl_billingAddress.Name = "lbl_billingAddress";
            this.lbl_billingAddress.Size = new System.Drawing.Size(75, 13);
            this.lbl_billingAddress.TabIndex = 8;
            this.lbl_billingAddress.Text = "Billing Address";
            // 
            // cmb_billlingAddress
            // 
            this.cmb_billlingAddress.Enabled = false;
            this.cmb_billlingAddress.FormattingEnabled = true;
            this.cmb_billlingAddress.ItemHeight = 13;
            this.cmb_billlingAddress.Location = new System.Drawing.Point(15, 111);
            this.cmb_billlingAddress.Margin = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.cmb_billlingAddress.Name = "cmb_billlingAddress";
            this.cmb_billlingAddress.Size = new System.Drawing.Size(640, 21);
            this.cmb_billlingAddress.TabIndex = 9;
            this.cmb_billlingAddress.SelectedIndexChanged += new System.EventHandler(this.cmb_billlingAddress_SelectedIndexChanged);
            // 
            // lbl_shippingAddress
            // 
            this.lbl_shippingAddress.AutoSize = true;
            this.lbl_shippingAddress.Location = new System.Drawing.Point(12, 138);
            this.lbl_shippingAddress.Name = "lbl_shippingAddress";
            this.lbl_shippingAddress.Size = new System.Drawing.Size(89, 13);
            this.lbl_shippingAddress.TabIndex = 10;
            this.lbl_shippingAddress.Text = "Shipping Address";
            // 
            // cmb_shippingAddress
            // 
            this.cmb_shippingAddress.Enabled = false;
            this.cmb_shippingAddress.FormattingEnabled = true;
            this.cmb_shippingAddress.ItemHeight = 13;
            this.cmb_shippingAddress.Location = new System.Drawing.Point(15, 154);
            this.cmb_shippingAddress.Margin = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.cmb_shippingAddress.Name = "cmb_shippingAddress";
            this.cmb_shippingAddress.Size = new System.Drawing.Size(640, 21);
            this.cmb_shippingAddress.TabIndex = 11;
            this.cmb_shippingAddress.SelectedIndexChanged += new System.EventHandler(this.cmb_shippingAddress_SelectedIndexChanged);
            // 
            // lbl_shipDate
            // 
            this.lbl_shipDate.AutoSize = true;
            this.lbl_shipDate.Location = new System.Drawing.Point(12, 181);
            this.lbl_shipDate.Name = "lbl_shipDate";
            this.lbl_shipDate.Size = new System.Drawing.Size(54, 13);
            this.lbl_shipDate.TabIndex = 12;
            this.lbl_shipDate.Text = "Ship Date";
            // 
            // dt_ship
            // 
            this.dt_ship.Location = new System.Drawing.Point(15, 197);
            this.dt_ship.Margin = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.dt_ship.Name = "dt_ship";
            this.dt_ship.Size = new System.Drawing.Size(640, 20);
            this.dt_ship.TabIndex = 13;
            this.dt_ship.ValueChanged += new System.EventHandler(this.dt_ship_ValueChanged);
            // 
            // OrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 544);
            this.Controls.Add(this.dt_ship);
            this.Controls.Add(this.lbl_shipDate);
            this.Controls.Add(this.cmb_shippingAddress);
            this.Controls.Add(this.lbl_shippingAddress);
            this.Controls.Add(this.cmb_billlingAddress);
            this.Controls.Add(this.lbl_billingAddress);
            this.Controls.Add(this.updn_shipping);
            this.Controls.Add(this.btn_sumbit);
            this.Controls.Add(this.txtb_orderTotal);
            this.Controls.Add(this.txtb_tax);
            this.Controls.Add(this.txtb_subtotal);
            this.Controls.Add(this.lv_orderItems);
            this.Controls.Add(this.txtb_cardNumber);
            this.Controls.Add(this.btn_orderItemsAdd);
            this.Controls.Add(this.btn_orderItemsRemove);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "OrderForm";
            this.Text = "Create New Order";
            ((System.ComponentModel.ISupportInitialize)(this.updn_shipping)).EndInit();
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
        private System.Windows.Forms.Label lbl_cardType;
        private System.Windows.Forms.ComboBox cmb_cardType;
        private System.Windows.Forms.Label lbl_orderItems;
        private System.Windows.Forms.ListView lv_orderItems;
        private System.Windows.Forms.Button btn_orderItemsRemove;
        private System.Windows.Forms.Button btn_orderItemsAdd;
        private System.Windows.Forms.Label lbl_subtotal;
        private System.Windows.Forms.TextBox txtb_subtotal;
        private System.Windows.Forms.TextBox txtb_tax;
        private System.Windows.Forms.Label lbl_tax;
        private System.Windows.Forms.Label lbl_shipping;
        private System.Windows.Forms.TextBox txtb_orderTotal;
        private System.Windows.Forms.Label lbl_orderTotal;
        private System.Windows.Forms.Button btn_sumbit;
        private System.Windows.Forms.NumericUpDown updn_shipping;
        private System.Windows.Forms.Label lbl_cardNumber;
        private System.Windows.Forms.TextBox txtb_cardNumber;
        private System.Windows.Forms.Label lbl_billingAddress;
        private System.Windows.Forms.ComboBox cmb_billlingAddress;
        private System.Windows.Forms.Label lbl_shippingAddress;
        private System.Windows.Forms.ComboBox cmb_shippingAddress;
        private System.Windows.Forms.Label lbl_shipDate;
        private System.Windows.Forms.DateTimePicker dt_ship;
    }
}