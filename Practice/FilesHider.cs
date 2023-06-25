using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Practice
{
    public partial class FilesHider : Form
    {
        public FilesHider()
        {
            InitializeComponent();
        }

        private void FilesHider_Load(object sender, EventArgs e)
        {
            PopulateTreeView();
        }

        private void PopulateTreeView()
        {
            this.driveTreeView.Nodes.Clear();
            foreach (var drive in DriveInfo.GetDrives())
            {
                if (drive.IsReady)
                {
                    TreeNode treeNode = new TreeNode(drive.Name)
                    {
                        Tag = drive.RootDirectory
                    };
                    driveTreeView.Nodes.Add(treeNode);
                    PopulateChildNodes(treeNode);
                }
            }
        }
        private async void PopulateChildNodes(TreeNode parentNode)
        {
            parentNode.Nodes.Clear();
            var directory = (DirectoryInfo)parentNode.Tag;
            try
            {
                foreach (var subDirectory in directory.GetDirectories())
                {

                    // For Getting only system and hidden directories
                    if (Directory.Exists(subDirectory.FullName))
                    {
                        FileAttributes attributes = File.GetAttributes(subDirectory.FullName);

                        if ((attributes & (FileAttributes.System | FileAttributes.Hidden)) == (FileAttributes.System | FileAttributes.Hidden))
                        {
                            var childNode = new TreeNode(subDirectory.Name)
                            {
                                Tag = subDirectory,
                            };
                            parentNode.Nodes.Add(childNode);
                            childNode.Nodes.Add("Loading...");
                        }
                        else
                        {
                            if (await HasSystemHiddenItems(subDirectory.FullName))
                            {
                                var childNode = new TreeNode(subDirectory.Name)
                                {
                                    Tag = subDirectory,
                                };
                                parentNode.Nodes.Add(childNode);
                                childNode.Nodes.Add("Loading...");
                            }
                        }
                    }

                    //var childNode = new TreeNode(subDirectory.Name)
                    //{
                    //    Tag = subDirectory,
                    //};
                    //parentNode.Nodes.Add(childNode);
                    //childNode.Nodes.Add("Loading...");
                }
            }
            catch (UnauthorizedAccessException)
            {
                // If access to the directory is denied, add a node indicating the access denial
                parentNode.Nodes.Add("Access Denied");
            }
        }

        private void DriveTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag is DirectoryInfo directory)
            {
                PopulateListView(directory.FullName);
            }
        }

        private void DriveTreeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            var parentNode = e.Node;
            parentNode.Nodes.Clear();
            PopulateChildNodes(parentNode);
        }

        public async void PopulateListView(string path)
        {
            // start data update
            listView.BeginUpdate();

            // clear listview
            listView.Items.Clear();
            try
            {
                // Get directories and files in the specified path
                DirectoryInfo directoryInfo = new DirectoryInfo(path);
                DirectoryInfo[] directoryInfos = directoryInfo.GetDirectories();
                FileInfo[] fileInfos = directoryInfo.GetFiles();

                // Add directories to list view
                foreach (DirectoryInfo dirInfo in directoryInfos)
                {
                    // Check if the directory has both System and Hidden attributes
                    FileAttributes attributes = File.GetAttributes(dirInfo.FullName);
                    if ((attributes & (FileAttributes.System | FileAttributes.Hidden)) == (FileAttributes.System | FileAttributes.Hidden))
                    {
                        ListViewItem item = listView.Items.Add(dirInfo.Name, 3);

                        // Set tag for the item
                        item.Tag = new Dictionary<string, string>
                        {
                            {"FullName", dirInfo.FullName},
                            {"Type", "Folder" }
                        };

                        // Add sub-items
                        item.SubItems.Add("Folder");
                        item.SubItems.Add("");
                        item.SubItems.Add("Hidden");
                    }
                    else
                    {
                        // Check if the directory contains any files or folders with System and Hidden attributes in its subdirectories
                        if (await HasSystemHiddenItems(dirInfo.FullName))
                        {
                            ListViewItem item = listView.Items.Add(dirInfo.Name, 3);

                            // Set tag for the item
                            item.Tag = new Dictionary<string, string>
                            {
                                {"FullName", dirInfo.FullName},
                                {"Type", "Folder" }
                            };

                            // Add sub-items
                            item.SubItems.Add("Folder");
                            item.SubItems.Add("");
                            item.SubItems.Add("Contains Hidden");
                        }
                    }
                }

                // Add files to list view
                foreach (FileInfo fileInfo in fileInfos)
                {
                    // Check if the file has both System and Hidden attributes
                    FileAttributes attributes = File.GetAttributes(fileInfo.FullName);
                    if ((attributes & (FileAttributes.System | FileAttributes.Hidden)) == (FileAttributes.System | FileAttributes.Hidden))
                    {
                        ListViewItem item = listView.Items.Add(fileInfo.Name);

                        // Set tag for the item
                        item.Tag = new Dictionary<string, string>
                        {
                            {"FullName", fileInfo.FullName},
                            {"Type", "File" }
                        };

                        // Add sub-items
                        item.SubItems.Add(fileInfo.Extension.ToString());
                        item.SubItems.Add(fileInfo.Length.ToString());
                        item.SubItems.Add("Hidden");
                    }
                }
            }
            catch (Exception e)
            {
                // Display error message
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // End Data Update
            listView.EndUpdate();
        }


        public async Task<bool> HasSystemHiddenItems(string folderPath)
        {
            try
            {
                bool hasSystemHiddenItems = false;

                await Task.Run(() =>
                {
                    try
                    {
                        // Iterate over all files in the folder and its subdirectories
                        Parallel.ForEach(Directory.EnumerateFiles(folderPath, "*", SearchOption.AllDirectories), (file, state) =>
                        {
                            try
                            {
                                // Check if the file has system and hidden attributes
                                FileAttributes attributes = File.GetAttributes(file);
                                if ((attributes & (FileAttributes.System | FileAttributes.Hidden)) == (FileAttributes.System | FileAttributes.Hidden))
                                {
                                    // Set the flag to true if a file with system and hidden attributes is found
                                    hasSystemHiddenItems = true;
                                    // Exit the loop if a match is found
                                    state.Break();
                                }
                            }
                            catch (Exception ex)
                            {
                                // Handle any exceptions that occur during file processing
                                Console.WriteLine($"Error: {ex.Message}");
                            }
                        });
                    }
                    catch (Exception ex)
                    {
                        // Handle any exceptions that occur during folder enumeration
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                });

                return hasSystemHiddenItems;
            }
            catch (Exception)
            {
                return false;
            }
        }




        private void listView_ItemActivate(object sender, EventArgs e)
        {
            try
            {
                if (listView.SelectedItems[0].Tag is Dictionary<string, string> itemTag)
                {
                    string selectedItemPath = itemTag["FullName"]; //fileListView.SelectedItems[0].Tag.ToString();

                    if (File.Exists(selectedItemPath))
                        Process.Start(selectedItemPath);
                    else
                    {
                        PopulateListView(selectedItemPath);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while opening the file or directory: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
