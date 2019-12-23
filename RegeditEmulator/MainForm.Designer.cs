namespace RegeditEmulator
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
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.keysView = new System.Windows.Forms.ListView();
            this.keyName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.keyType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.keyData = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.treeView = new System.Windows.Forms.TreeView();
            this.NodeContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addNodeItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addKeyItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renameNodeItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeNodeItem = new System.Windows.Forms.ToolStripMenuItem();
            this.KeyContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NodeContextMenu.SuspendLayout();
            this.KeyContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // keysView
            // 
            this.keysView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.keysView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.keyName,
            this.keyType,
            this.keyData});
            this.keysView.FullRowSelect = true;
            this.keysView.GridLines = true;
            this.keysView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.keysView.HideSelection = false;
            this.keysView.Location = new System.Drawing.Point(326, 13);
            this.keysView.MultiSelect = false;
            this.keysView.Name = "keysView";
            this.keysView.Size = new System.Drawing.Size(462, 425);
            this.keysView.TabIndex = 3;
            this.keysView.UseCompatibleStateImageBehavior = false;
            this.keysView.View = System.Windows.Forms.View.Details;
            this.keysView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.keysView_MouseClick);
            // 
            // keyName
            // 
            this.keyName.Text = "Name";
            this.keyName.Width = 112;
            // 
            // keyType
            // 
            this.keyType.Text = "Type";
            this.keyType.Width = 108;
            // 
            // keyData
            // 
            this.keyData.Text = "Data";
            this.keyData.Width = 234;
            // 
            // treeView
            // 
            this.treeView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeView.Location = new System.Drawing.Point(13, 13);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(306, 425);
            this.treeView.TabIndex = 2;
            this.treeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView_NodeMouseClick);
            // 
            // NodeContextMenu
            // 
            this.NodeContextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.NodeContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNodeItem,
            this.addKeyItem,
            this.renameNodeItem,
            this.removeNodeItem});
            this.NodeContextMenu.Name = "NodeContextMenu";
            this.NodeContextMenu.Size = new System.Drawing.Size(146, 100);
            // 
            // addNodeItem
            // 
            this.addNodeItem.Name = "addNodeItem";
            this.addNodeItem.Size = new System.Drawing.Size(210, 24);
            this.addNodeItem.Text = "New key";
            this.addNodeItem.Click += new System.EventHandler(this.addNodeItem_Click);
            // 
            // addKeyItem
            // 
            this.addKeyItem.Name = "addKeyItem";
            this.addKeyItem.Size = new System.Drawing.Size(210, 24);
            this.addKeyItem.Text = "Add value";
            this.addKeyItem.Click += new System.EventHandler(this.addKeyItem_Click);
            // 
            // renameNodeItem
            // 
            this.renameNodeItem.Name = "renameNodeItem";
            this.renameNodeItem.Size = new System.Drawing.Size(210, 24);
            this.renameNodeItem.Text = "Rename";
            this.renameNodeItem.Click += new System.EventHandler(this.renameNodeItem_Click);
            // 
            // removeNodeItem
            // 
            this.removeNodeItem.Name = "removeNodeItem";
            this.removeNodeItem.Size = new System.Drawing.Size(210, 24);
            this.removeNodeItem.Text = "Remove";
            this.removeNodeItem.Click += new System.EventHandler(this.removeNodeItem_Click);
            // 
            // KeyContextMenu
            // 
            this.KeyContextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.KeyContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.removeToolStripMenuItem});
            this.KeyContextMenu.Name = "KeyContextMenu";
            this.KeyContextMenu.Size = new System.Drawing.Size(211, 80);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.removeToolStripMenuItem.Text = "Remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.keysView);
            this.Controls.Add(this.treeView);
            this.Name = "MainForm";
            this.Text = "Regedit Emulator";
            this.NodeContextMenu.ResumeLayout(false);
            this.KeyContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView keysView;
        private System.Windows.Forms.ColumnHeader keyName;
        private System.Windows.Forms.ColumnHeader keyType;
        private System.Windows.Forms.ColumnHeader keyData;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.ContextMenuStrip NodeContextMenu;
        private System.Windows.Forms.ToolStripMenuItem addNodeItem;
        private System.Windows.Forms.ToolStripMenuItem addKeyItem;
        private System.Windows.Forms.ToolStripMenuItem renameNodeItem;
        private System.Windows.Forms.ToolStripMenuItem removeNodeItem;
        private System.Windows.Forms.ContextMenuStrip KeyContextMenu;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
    }
}

