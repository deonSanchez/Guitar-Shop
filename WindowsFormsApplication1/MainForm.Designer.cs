namespace GuitarShop
{
    partial class MainForm
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Orders");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Repairs");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Promotions");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Categories");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Instruments");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Parts");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Customers");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Suppliers");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Administrators");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Employees");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.scMain = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.lvProducts = new System.Windows.Forms.ListView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripNew = new System.Windows.Forms.ToolStripButton();
            this.toolStripEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripDelete = new System.Windows.Forms.ToolStripButton();
            this.btn_init = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).BeginInit();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // scMain
            // 
            this.scMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scMain.Location = new System.Drawing.Point(12, 28);
            this.scMain.Name = "scMain";
            // 
            // scMain.Panel1
            // 
            this.scMain.Panel1.Controls.Add(this.treeView1);
            // 
            // scMain.Panel2
            // 
            this.scMain.Panel2.Controls.Add(this.lvProducts);
            this.scMain.Size = new System.Drawing.Size(889, 553);
            this.scMain.SplitterDistance = 138;
            this.scMain.TabIndex = 4;
            // 
            // treeView1
            // 
            this.treeView1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.FullRowSelect = true;
            this.treeView1.HotTracking = true;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "nodeOrders";
            treeNode1.Text = "Orders";
            treeNode2.Name = "Node3";
            treeNode2.Text = "Repairs";
            treeNode3.Name = "Promotions";
            treeNode3.Text = "Promotions";
            treeNode4.Name = "Node4";
            treeNode4.Text = "Categories";
            treeNode5.Name = "Node5";
            treeNode5.Text = "Instruments";
            treeNode6.Name = "Node6";
            treeNode6.Text = "Parts";
            treeNode7.Name = "Node0";
            treeNode7.Text = "Customers";
            treeNode8.Name = "Node0";
            treeNode8.Text = "Suppliers";
            treeNode9.Name = "Node0";
            treeNode9.Text = "Administrators";
            treeNode10.Name = "Node0";
            treeNode10.Text = "Employees";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7,
            treeNode8,
            treeNode9,
            treeNode10});
            this.treeView1.Size = new System.Drawing.Size(138, 553);
            this.treeView1.TabIndex = 3;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // lvProducts
            // 
            this.lvProducts.CheckBoxes = true;
            this.lvProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvProducts.FullRowSelect = true;
            this.lvProducts.GridLines = true;
            this.lvProducts.HideSelection = false;
            this.lvProducts.Location = new System.Drawing.Point(0, 0);
            this.lvProducts.Name = "lvProducts";
            this.lvProducts.Size = new System.Drawing.Size(747, 553);
            this.lvProducts.TabIndex = 0;
            this.lvProducts.UseCompatibleStateImageBehavior = false;
            this.lvProducts.View = System.Windows.Forms.View.Details;
            this.lvProducts.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lvProducts_ItemChecked);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_init,
            this.toolStripNew,
            this.toolStripEdit,
            this.toolStripDelete});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(913, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripNew
            // 
            this.toolStripNew.Image = global::GuitarShop.Properties.Resources.NewFile_6276_24;
            this.toolStripNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripNew.Name = "toolStripNew";
            this.toolStripNew.Size = new System.Drawing.Size(78, 22);
            this.toolStripNew.Text = "New Item";
            this.toolStripNew.Click += new System.EventHandler(this.toolStripNew_Click);
            // 
            // toolStripEdit
            // 
            this.toolStripEdit.Enabled = false;
            this.toolStripEdit.Image = global::GuitarShop.Properties.Resources.PencilTool_206;
            this.toolStripEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripEdit.Name = "toolStripEdit";
            this.toolStripEdit.Size = new System.Drawing.Size(74, 22);
            this.toolStripEdit.Text = "Edit Item";
            this.toolStripEdit.Click += new System.EventHandler(this.toolStripEdit_Click);
            // 
            // toolStripDelete
            // 
            this.toolStripDelete.Enabled = false;
            this.toolStripDelete.Image = global::GuitarShop.Properties.Resources.DeleteTablefromDatabase_270_24;
            this.toolStripDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDelete.Name = "toolStripDelete";
            this.toolStripDelete.Size = new System.Drawing.Size(107, 22);
            this.toolStripDelete.Text = "Delete Selected";
            this.toolStripDelete.Click += new System.EventHandler(this.toolStripDelete_Click);
            // 
            // btn_init
            // 
            this.btn_init.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btn_init.Image = ((System.Drawing.Image)(resources.GetObject("btn_init.Image")));
            this.btn_init.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_init.Name = "btn_init";
            this.btn_init.Size = new System.Drawing.Size(119, 22);
            this.btn_init.Text = "Initialize Connection";
            this.btn_init.Click += new System.EventHandler(this.btn_init_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 593);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.scMain);
            this.Name = "MainForm";
            this.Text = "Guitar Shop Management";
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).EndInit();
            this.scMain.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.SplitContainer scMain;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripNew;
        private System.Windows.Forms.ToolStripButton toolStripDelete;
        private System.Windows.Forms.ToolStripButton toolStripEdit;
        private System.Windows.Forms.ListView lvProducts;
        private System.Windows.Forms.ToolStripButton btn_init;
    }
}

