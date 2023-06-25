
namespace Files_Hider
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panelForMainForm = new System.Windows.Forms.Panel();
            this.panelForMiddleSeperator = new System.Windows.Forms.Panel();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.hiddenFilesListbox = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.separatorOfPanelOne = new System.Windows.Forms.Label();
            this.hiddenFilesLabel = new System.Windows.Forms.Label();
            this.panelRight = new System.Windows.Forms.Panel();
            this.hiddenFoldersListBox = new System.Windows.Forms.ListBox();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addFoldersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeFoldersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.separatorOfPanelTwo = new System.Windows.Forms.Label();
            this.hiddenFoldersLabel = new System.Windows.Forms.Label();
            this.panelSeperator = new System.Windows.Forms.Panel();
            this.panelForTitleBar = new System.Windows.Forms.Panel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.titleBar = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelForMainForm.SuspendLayout();
            this.panelLeft.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.panelRight.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.panelForTitleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelForMainForm
            // 
            this.panelForMainForm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelForMainForm.Controls.Add(this.panelForMiddleSeperator);
            this.panelForMainForm.Controls.Add(this.panelLeft);
            this.panelForMainForm.Controls.Add(this.panelRight);
            this.panelForMainForm.Controls.Add(this.panelSeperator);
            this.panelForMainForm.Controls.Add(this.panelForTitleBar);
            this.panelForMainForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelForMainForm.Location = new System.Drawing.Point(0, 0);
            this.panelForMainForm.Name = "panelForMainForm";
            this.panelForMainForm.Size = new System.Drawing.Size(667, 289);
            this.panelForMainForm.TabIndex = 0;
            // 
            // panelForMiddleSeperator
            // 
            this.panelForMiddleSeperator.BackColor = System.Drawing.Color.Black;
            this.panelForMiddleSeperator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelForMiddleSeperator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelForMiddleSeperator.Location = new System.Drawing.Point(331, 36);
            this.panelForMiddleSeperator.Name = "panelForMiddleSeperator";
            this.panelForMiddleSeperator.Size = new System.Drawing.Size(2, 251);
            this.panelForMiddleSeperator.TabIndex = 31;
            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.Color.White;
            this.panelLeft.Controls.Add(this.hiddenFilesListbox);
            this.panelLeft.Controls.Add(this.separatorOfPanelOne);
            this.panelLeft.Controls.Add(this.hiddenFilesLabel);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 36);
            this.panelLeft.Margin = new System.Windows.Forms.Padding(2);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(331, 251);
            this.panelLeft.TabIndex = 30;
            // 
            // hiddenFilesListbox
            // 
            this.hiddenFilesListbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.hiddenFilesListbox.ContextMenuStrip = this.contextMenuStrip1;
            this.hiddenFilesListbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hiddenFilesListbox.FormattingEnabled = true;
            this.hiddenFilesListbox.Location = new System.Drawing.Point(0, 21);
            this.hiddenFilesListbox.Margin = new System.Windows.Forms.Padding(2);
            this.hiddenFilesListbox.Name = "hiddenFilesListbox";
            this.hiddenFilesListbox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.hiddenFilesListbox.Size = new System.Drawing.Size(331, 230);
            this.hiddenFilesListbox.TabIndex = 3;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addFilesToolStripMenuItem,
            this.removeFilesToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(144, 48);
            // 
            // addFilesToolStripMenuItem
            // 
            this.addFilesToolStripMenuItem.Name = "addFilesToolStripMenuItem";
            this.addFilesToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.addFilesToolStripMenuItem.Text = "Add Files";
            this.addFilesToolStripMenuItem.Click += new System.EventHandler(this.AddFilesToolStripMenuItem_Click);
            // 
            // removeFilesToolStripMenuItem
            // 
            this.removeFilesToolStripMenuItem.Name = "removeFilesToolStripMenuItem";
            this.removeFilesToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.removeFilesToolStripMenuItem.Text = "Remove Files";
            this.removeFilesToolStripMenuItem.Click += new System.EventHandler(this.RemoveFilesToolStripMenuItem_Click);
            // 
            // separatorOfPanelOne
            // 
            this.separatorOfPanelOne.BackColor = System.Drawing.Color.Black;
            this.separatorOfPanelOne.Dock = System.Windows.Forms.DockStyle.Top;
            this.separatorOfPanelOne.ForeColor = System.Drawing.Color.White;
            this.separatorOfPanelOne.Location = new System.Drawing.Point(0, 20);
            this.separatorOfPanelOne.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.separatorOfPanelOne.Name = "separatorOfPanelOne";
            this.separatorOfPanelOne.Size = new System.Drawing.Size(331, 1);
            this.separatorOfPanelOne.TabIndex = 2;
            this.separatorOfPanelOne.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // hiddenFilesLabel
            // 
            this.hiddenFilesLabel.BackColor = System.Drawing.Color.White;
            this.hiddenFilesLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.hiddenFilesLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hiddenFilesLabel.ForeColor = System.Drawing.Color.Black;
            this.hiddenFilesLabel.Location = new System.Drawing.Point(0, 0);
            this.hiddenFilesLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.hiddenFilesLabel.Name = "hiddenFilesLabel";
            this.hiddenFilesLabel.Size = new System.Drawing.Size(331, 20);
            this.hiddenFilesLabel.TabIndex = 1;
            this.hiddenFilesLabel.Text = "Hidden Files";
            this.hiddenFilesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelRight
            // 
            this.panelRight.BackColor = System.Drawing.Color.White;
            this.panelRight.Controls.Add(this.hiddenFoldersListBox);
            this.panelRight.Controls.Add(this.separatorOfPanelTwo);
            this.panelRight.Controls.Add(this.hiddenFoldersLabel);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.Location = new System.Drawing.Point(333, 36);
            this.panelRight.Margin = new System.Windows.Forms.Padding(2);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(332, 251);
            this.panelRight.TabIndex = 29;
            // 
            // hiddenFoldersListBox
            // 
            this.hiddenFoldersListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.hiddenFoldersListBox.ContextMenuStrip = this.contextMenuStrip2;
            this.hiddenFoldersListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hiddenFoldersListBox.FormattingEnabled = true;
            this.hiddenFoldersListBox.Location = new System.Drawing.Point(0, 21);
            this.hiddenFoldersListBox.Margin = new System.Windows.Forms.Padding(2);
            this.hiddenFoldersListBox.Name = "hiddenFoldersListBox";
            this.hiddenFoldersListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.hiddenFoldersListBox.Size = new System.Drawing.Size(332, 230);
            this.hiddenFoldersListBox.TabIndex = 4;
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addFoldersToolStripMenuItem,
            this.removeFoldersToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(159, 48);
            // 
            // addFoldersToolStripMenuItem
            // 
            this.addFoldersToolStripMenuItem.Name = "addFoldersToolStripMenuItem";
            this.addFoldersToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.addFoldersToolStripMenuItem.Text = "Add Folders";
            this.addFoldersToolStripMenuItem.Click += new System.EventHandler(this.AddFolderToolStripMenuItem_Click);
            // 
            // removeFoldersToolStripMenuItem
            // 
            this.removeFoldersToolStripMenuItem.Name = "removeFoldersToolStripMenuItem";
            this.removeFoldersToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.removeFoldersToolStripMenuItem.Text = "Remove Folders";
            this.removeFoldersToolStripMenuItem.Click += new System.EventHandler(this.RemoveFolderToolStripMenuItem_Click);
            // 
            // separatorOfPanelTwo
            // 
            this.separatorOfPanelTwo.BackColor = System.Drawing.Color.Black;
            this.separatorOfPanelTwo.Dock = System.Windows.Forms.DockStyle.Top;
            this.separatorOfPanelTwo.ForeColor = System.Drawing.Color.White;
            this.separatorOfPanelTwo.Location = new System.Drawing.Point(0, 20);
            this.separatorOfPanelTwo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.separatorOfPanelTwo.Name = "separatorOfPanelTwo";
            this.separatorOfPanelTwo.Size = new System.Drawing.Size(332, 1);
            this.separatorOfPanelTwo.TabIndex = 2;
            this.separatorOfPanelTwo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // hiddenFoldersLabel
            // 
            this.hiddenFoldersLabel.BackColor = System.Drawing.Color.White;
            this.hiddenFoldersLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.hiddenFoldersLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hiddenFoldersLabel.ForeColor = System.Drawing.Color.Black;
            this.hiddenFoldersLabel.Location = new System.Drawing.Point(0, 0);
            this.hiddenFoldersLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.hiddenFoldersLabel.Name = "hiddenFoldersLabel";
            this.hiddenFoldersLabel.Size = new System.Drawing.Size(332, 20);
            this.hiddenFoldersLabel.TabIndex = 1;
            this.hiddenFoldersLabel.Text = "Hidden Folders";
            this.hiddenFoldersLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelSeperator
            // 
            this.panelSeperator.BackColor = System.Drawing.Color.Black;
            this.panelSeperator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSeperator.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSeperator.Location = new System.Drawing.Point(0, 35);
            this.panelSeperator.Name = "panelSeperator";
            this.panelSeperator.Size = new System.Drawing.Size(665, 1);
            this.panelSeperator.TabIndex = 1;
            // 
            // panelForTitleBar
            // 
            this.panelForTitleBar.Controls.Add(this.pictureBox1);
            this.panelForTitleBar.Controls.Add(this.checkBox1);
            this.panelForTitleBar.Controls.Add(this.titleBar);
            this.panelForTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelForTitleBar.Location = new System.Drawing.Point(0, 0);
            this.panelForTitleBar.Name = "panelForTitleBar";
            this.panelForTitleBar.Size = new System.Drawing.Size(665, 35);
            this.panelForTitleBar.TabIndex = 0;
            // 
            // checkBox1
            // 
            this.checkBox1.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox1.BackColor = System.Drawing.Color.Black;
            this.checkBox1.FlatAppearance.BorderSize = 0;
            this.checkBox1.FlatAppearance.CheckedBackColor = System.Drawing.Color.Black;
            this.checkBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.ForeColor = System.Drawing.Color.White;
            this.checkBox1.Location = new System.Drawing.Point(630, 5);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(30, 25);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "X";
            this.checkBox1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.checkBox1.UseVisualStyleBackColor = false;
            this.checkBox1.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // titleBar
            // 
            this.titleBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.titleBar.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleBar.Location = new System.Drawing.Point(0, 0);
            this.titleBar.Name = "titleBar";
            this.titleBar.Size = new System.Drawing.Size(665, 35);
            this.titleBar.TabIndex = 0;
            this.titleBar.Text = "Files Hider By Ravikant Asoliya";
            this.titleBar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.titleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TitleBar_MouseDown);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(11, -4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(68, 47);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(667, 289);
            this.Controls.Add(this.panelForMainForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Files Hider";
            this.panelForMainForm.ResumeLayout(false);
            this.panelLeft.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.panelRight.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.panelForTitleBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelForMainForm;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.ListBox hiddenFilesListbox;
        private System.Windows.Forms.Label separatorOfPanelOne;
        private System.Windows.Forms.Label hiddenFilesLabel;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.ListBox hiddenFoldersListBox;
        private System.Windows.Forms.Label separatorOfPanelTwo;
        private System.Windows.Forms.Label hiddenFoldersLabel;
        private System.Windows.Forms.Panel panelSeperator;
        private System.Windows.Forms.Panel panelForTitleBar;
        private System.Windows.Forms.Label titleBar;
        private System.Windows.Forms.Panel panelForMiddleSeperator;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeFilesToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem addFoldersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeFoldersToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

