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
            this.cmb_Item.Name = "cmb_Item";
            this.cmb_Item.Size = new System.Drawing.Size(257, 21);
            this.cmb_Item.TabIndex = 2;
            // 
            // RepairItemSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.cmb_Item);
            this.Controls.Add(this.lbl_Item);
            this.Name = "RepairItemSelection";
            this.Text = "RepairItemSelection";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbl_Item;
        private System.Windows.Forms.ComboBox cmb_Item;
    }
}