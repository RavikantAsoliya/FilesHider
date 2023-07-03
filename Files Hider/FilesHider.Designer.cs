namespace Files_Hider
{
    partial class FilesHider
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FilesHider));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.backButton = new System.Windows.Forms.ToolStripButton();
            this.forwardButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.addressBar = new System.Windows.Forms.ToolStripComboBox();
            this.refreshButton = new System.Windows.Forms.ToolStripButton();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelFullPath = new System.Windows.Forms.ToolStripStatusLabel();
            this.listView = new System.Windows.Forms.ListView();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addFilesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.addFoldersToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.propertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.BackColor = System.Drawing.Color.White;
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backButton,
            this.forwardButton,
            this.toolStripSeparator1,
            this.toolStripButton3,
            this.toolStripButton2,
            this.toolStripButton1,
            this.toolStripButton4,
            this.toolStripSeparator2,
            this.addressBar,
            this.refreshButton});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(684, 39);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "toolStrip1";
            // 
            // backButton
            // 
            this.backButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.backButton.Enabled = false;
            this.backButton.Image = global::Files_Hider.Properties.Resources.back_arrow;
            this.backButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.backButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(36, 36);
            this.backButton.Text = "Back";
            this.backButton.ToolTipText = "Back";
            this.backButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // forwardButton
            // 
            this.forwardButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.forwardButton.Enabled = false;
            this.forwardButton.Image = global::Files_Hider.Properties.Resources.forward_arrow;
            this.forwardButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.forwardButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.forwardButton.Name = "forwardButton";
            this.forwardButton.Size = new System.Drawing.Size(36, 36);
            this.forwardButton.Text = "Forward";
            this.forwardButton.ToolTipText = "Forward";
            this.forwardButton.Click += new System.EventHandler(this.ForwardButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.BackColor = System.Drawing.Color.Black;
            this.toolStripSeparator1.ForeColor = System.Drawing.Color.Black;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = global::Files_Hider.Properties.Resources.add_file;
            this.toolStripButton3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(36, 36);
            this.toolStripButton3.Text = "Add Files";
            this.toolStripButton3.Click += new System.EventHandler(this.AddFilesToolStripMenuItem_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::Files_Hider.Properties.Resources.add_folder;
            this.toolStripButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(36, 36);
            this.toolStripButton2.Text = "Add Folders";
            this.toolStripButton2.Click += new System.EventHandler(this.AddFoldersToolStripMenuItem_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::Files_Hider.Properties.Resources.remove_file_folder;
            this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(36, 36);
            this.toolStripButton1.Text = "Remove";
            this.toolStripButton1.Click += new System.EventHandler(this.RemoveToolStripMenuItem_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = global::Files_Hider.Properties.Resources.properties;
            this.toolStripButton4.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(36, 36);
            this.toolStripButton4.Text = "Properties";
            this.toolStripButton4.Click += new System.EventHandler(this.PropertiesToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.BackColor = System.Drawing.Color.Black;
            this.toolStripSeparator2.ForeColor = System.Drawing.Color.Black;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // addressBar
            // 
            this.addressBar.Name = "addressBar";
            this.addressBar.Size = new System.Drawing.Size(300, 39);
            this.addressBar.ToolTipText = "AddressBar";
            // 
            // refreshButton
            // 
            this.refreshButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.refreshButton.Image = global::Files_Hider.Properties.Resources.refresh_icon;
            this.refreshButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.refreshButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(36, 36);
            this.refreshButton.Text = "Refresh";
            this.refreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.BackColor = System.Drawing.Color.White;
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelFullPath});
            this.statusStrip.Location = new System.Drawing.Point(0, 289);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(684, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabelFullPath
            // 
            this.toolStripStatusLabelFullPath.Name = "toolStripStatusLabelFullPath";
            this.toolStripStatusLabelFullPath.Size = new System.Drawing.Size(40, 17);
            this.toolStripStatusLabelFullPath.Text = "Path : ";
            // 
            // listView
            // 
            this.listView.AllowDrop = true;
            this.listView.BackColor = System.Drawing.Color.White;
            this.listView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView.ContextMenuStrip = this.contextMenuStrip;
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView.HideSelection = false;
            this.listView.LargeImageList = this.imageList;
            this.listView.Location = new System.Drawing.Point(0, 39);
            this.listView.Name = "listView";
            this.listView.ShowItemToolTips = true;
            this.listView.Size = new System.Drawing.Size(684, 250);
            this.listView.TabIndex = 3;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.ItemActivate += new System.EventHandler(this.ListView_ItemActivate);
            this.listView.ItemMouseHover += new System.Windows.Forms.ListViewItemMouseHoverEventHandler(this.ListView_ItemMouseHover);
            this.listView.SelectedIndexChanged += new System.EventHandler(this.ListView_SelectedIndexChanged);
            this.listView.DragDrop += new System.Windows.Forms.DragEventHandler(this.ListView_DragDrop);
            this.listView.DragEnter += new System.Windows.Forms.DragEventHandler(this.ListView_DragEnter);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addFilesToolStripMenuItem1,
            this.addFoldersToolStripMenuItem1,
            this.removeToolStripMenuItem1,
            this.refreshToolStripMenuItem,
            this.propertiesToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip1";
            this.contextMenuStrip.Size = new System.Drawing.Size(138, 114);
            // 
            // addFilesToolStripMenuItem1
            // 
            this.addFilesToolStripMenuItem1.Image = global::Files_Hider.Properties.Resources.add_file;
            this.addFilesToolStripMenuItem1.Name = "addFilesToolStripMenuItem1";
            this.addFilesToolStripMenuItem1.Size = new System.Drawing.Size(137, 22);
            this.addFilesToolStripMenuItem1.Text = "Add Files";
            this.addFilesToolStripMenuItem1.Click += new System.EventHandler(this.AddFilesToolStripMenuItem_Click);
            // 
            // addFoldersToolStripMenuItem1
            // 
            this.addFoldersToolStripMenuItem1.Image = global::Files_Hider.Properties.Resources.add_folder;
            this.addFoldersToolStripMenuItem1.Name = "addFoldersToolStripMenuItem1";
            this.addFoldersToolStripMenuItem1.Size = new System.Drawing.Size(137, 22);
            this.addFoldersToolStripMenuItem1.Text = "Add Folders";
            this.addFoldersToolStripMenuItem1.Click += new System.EventHandler(this.AddFoldersToolStripMenuItem_Click);
            // 
            // removeToolStripMenuItem1
            // 
            this.removeToolStripMenuItem1.Image = global::Files_Hider.Properties.Resources.remove_file_folder;
            this.removeToolStripMenuItem1.Name = "removeToolStripMenuItem1";
            this.removeToolStripMenuItem1.Size = new System.Drawing.Size(137, 22);
            this.removeToolStripMenuItem1.Text = "Remove";
            this.removeToolStripMenuItem1.Click += new System.EventHandler(this.RemoveToolStripMenuItem_Click);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("refreshToolStripMenuItem.Image")));
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // propertiesToolStripMenuItem
            // 
            this.propertiesToolStripMenuItem.Image = global::Files_Hider.Properties.Resources.properties;
            this.propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem";
            this.propertiesToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.propertiesToolStripMenuItem.Text = "Properties";
            this.propertiesToolStripMenuItem.Click += new System.EventHandler(this.PropertiesToolStripMenuItem_Click);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "large-file-icon.png");
            this.imageList.Images.SetKeyName(1, "large-folder-icon.png");
            // 
            // FilesHider
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(684, 311);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.toolStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FilesHider";
            this.Text = "Files Hider";
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelFullPath;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem addFilesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem addFoldersToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem1;
        private System.Windows.Forms.ToolStripButton backButton;
        private System.Windows.Forms.ToolStripButton forwardButton;
        private System.Windows.Forms.ToolStripComboBox addressBar;
        private System.Windows.Forms.ToolStripButton refreshButton;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem propertiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
    }
}