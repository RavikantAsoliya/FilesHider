using Files_Hider.Helper;
using Microsoft.WindowsAPICodePack.Dialogs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Files_Hider
{
    public partial class FilesHider : Form
    {
        /// <summary>
        /// Represents the file path of a JSON file.
        /// </summary>
        private readonly string JsonFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "data.json");

        /// <summary>
        /// Holds the data loaded from the JSON file.
        /// </summary>
        private List<Dictionary<string, string>> jsonData;

        /// <summary>
        /// Keeps track of previously visited directories for backward navigation.
        /// </summary>
        private readonly Stack<string> backStack = new Stack<string>();

        /// <summary>
        /// Keeps track of directories navigated forward from the current directory.
        /// </summary>
        private readonly Stack<string> forwardStack = new Stack<string>();

        /// <summary>
        /// Represents the path of the current directory being displayed.
        /// </summary>
        private string currentDirectory = "home";


        public FilesHider()
        {
            InitializeComponent();
            LoadData();     
        }

        /// <summary>
        /// Loads data from a JSON file and populates the ListView control.
        /// </summary>
        private void LoadData()
        {
            // Clear the items in the ListView.
            listView.Items.Clear();

            // Set the text of the addressBar to "Home".
            addressBar.Text = "Home";

            // Clear the text of the toolStripStatusLabelFullPath.
            toolStripStatusLabelFullPath.Text = "";

            try
            {
                // Check if the JSON file exists.
                if (File.Exists(JsonFilePath))
                {
                    // Read the JSON content from the file.
                    string jsonContent = File.ReadAllText(JsonFilePath);

                    // Deserialize the JSON content into a list of dictionaries.
                    jsonData = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(jsonContent);

                    // Iterate over each dictionary representing a file or folder.
                    foreach (Dictionary<string, string> path in jsonData)
                    {
                        // Check if the path corresponds to a directory.
                        if (Directory.Exists(path["FullPath"]))
                        {
                            // Create a ListViewItem for a directory.
                            ListViewItem item = listView.Items.Add(new DirectoryInfo(path["FullPath"]).Name);

                            // Set the image index to indicate a directory.
                            item.ImageIndex = 1;

                            // Store the full path as the tag for the ListViewItem.
                            item.Tag = path["FullPath"];
                        }
                        // Check if the path corresponds to a file.
                        else if (File.Exists(path["FullPath"]))
                        {
                            // Create a ListViewItem for a file.
                            ListViewItem item = listView.Items.Add(new FileInfo(path["FullPath"]).Name);

                            // Set the image index to indicate a file.
                            item.ImageIndex = 0;

                            // Store the full path as the tag for the ListViewItem.
                            item.Tag = path["FullPath"];

                            // Set the tooltip text to include the file size and indicate the status is hidden.
                            item.ToolTipText = $"Type: {FileTypeChecker.GetFileTypeByExtension(Path.GetExtension(path["FullPath"]))}\n" +
                            $"Size: {SizeManager.FormatSize(new FileInfo(path["FullPath"]).Length)}\n" +
                            $"Date Modified: {new FileInfo(path["FullPath"]).LastWriteTime}";
                        }

                    }
                }
                else
                {
                    // If the JSON file does not exist, initialize an empty list.
                    jsonData = new List<Dictionary<string, string>>();
                }
            }
            catch (Exception ex)
            {
                // Display an error message if an exception occurs during loading data.
                MessageBox.Show($"An error occurred while loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// Saves the data stored in the jsonData list to a JSON file.
        /// </summary>
        private void SaveData()
        {
            try
            {
                // Serialize the jsonData list to JSON format with indented formatting.
                string jsonContent = JsonConvert.SerializeObject(jsonData, Formatting.Indented);

                // Write the JSON content to the specified JSON file path.
                File.WriteAllText(JsonFilePath, jsonContent);
            }
            catch (Exception ex)
            {
                // Display an error message box if an exception occurs while saving data.
                MessageBox.Show($"An error occurred while saving data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// Removes the selected items from the listView and updates the jsonData list and JSON file accordingly.
        /// </summary>
        private void RemoveSelectedItems()
        {
            try
            {
                // Iterate over the selected items in the listView.
                foreach (ListViewItem selectedItem in listView.SelectedItems)
                {
                    // Get the path of the selected item.
                    string itemPath = selectedItem.Tag.ToString();

                    // Get the current attributes of the file/directory.
                    FileAttributes currentAttributes = File.GetAttributes(itemPath);

                    // Remove the System and Hidden attributes from the current attributes.
                    FileAttributes newAttributes = currentAttributes & ~(FileAttributes.System | FileAttributes.Hidden);

                    // Set the new attributes for the file/directory.
                    File.SetAttributes(itemPath, newAttributes);

                    // Remove the selected item from the listView.
                    selectedItem.Remove();

                    // Remove the item from the jsonData list.
                    RemoveItemFromJsonData(itemPath);
                }

                // Save the updated jsonData to the JSON file.
                SaveData();
            }
            catch (Exception ex)
            {
                // Display an error message box if an exception occurs while removing items.
                MessageBox.Show($"An error occurred while removing items: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// Adds files or folders to the listView based on the specified flag.
        /// </summary>
        /// <param name="onlyFolder">Flag indicating whether only folders should be added.</param>
        private void AddFilesOrFolders(bool onlyFolder)
        {
            // Create a CommonOpenFileDialog instance.
            CommonOpenFileDialog openFileDialog = new CommonOpenFileDialog
            {
                Multiselect = true,     // Allow multiple file selection.
                IsFolderPicker = onlyFolder     // Set whether only folders should be selected.
            };

            // Check if the file dialog was opened successfully and the user made a selection.
            if (openFileDialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                try
                {
                    // Iterate over the selected file paths.
                    foreach (string filePath in openFileDialog.FileNames)
                    {
                        // Set system and hidden attributes for the file or folder.
                        SetSystemAndHiddenAttributes(filePath);

                        // Create a FileSystemInfo object based on the file or folder type.
                        FileSystemInfo fileInfo = onlyFolder ? (FileSystemInfo)new DirectoryInfo(filePath) : new FileInfo(filePath);

                        // Create a new ListViewItem for the file or folder.
                        ListViewItem item = new ListViewItem(fileInfo.Name);

                        // Add sub-items based on whether it's a folder or file.
                        item.SubItems.Add(onlyFolder ? "Folder" : "File");

                        // Add file size sub-item if it's a file, otherwise leave it empty for folders.
                        item.SubItems.Add(onlyFolder ? "" : ((FileInfo)fileInfo).Length.ToString());

                        // Set the 'Hidden' sub-item value for all items.
                        item.SubItems.Add("Hidden");

                        // Set the image index based on whether it's a folder or file.
                        item.ImageIndex = onlyFolder ? 1 : 0;

                        // Set the tag property to store the full path of the item.
                        item.Tag = fileInfo.FullName;

                        // Add the item to the ListView control.
                        listView.Items.Add(item);

                        // Add the item to the jsonData.
                        AddItemToJsonData(fileInfo.FullName, onlyFolder ? "Folder" : "File");
                    }

                    // Save the updated jsonData.
                    SaveData();
                }
                catch (Exception ex)
                {
                    // Display an error message if an exception occurs.
                    MessageBox.Show($"An error occurred while adding files or folders: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        /// <summary>
        /// Sets the system and hidden attributes for the specified file or folder.
        /// </summary>
        /// <param name="filePath">The path of the file or folder.</param>
        private void SetSystemAndHiddenAttributes(string filePath)
        {
            try
            {
                // Get the current attributes of the file or folder.
                FileAttributes attributes = File.GetAttributes(filePath);

                // Set the system and hidden attributes.
                attributes |= FileAttributes.System | FileAttributes.Hidden;

                // Update the attributes of the file or folder.
                File.SetAttributes(filePath, attributes);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while setting system and hidden attributes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// Adds an item to the JSON data list.
        /// </summary>
        /// <param name="fullPath">The full path of the item.</param>
        /// <param name="type">The type of the item (e.g., "Folder" or "File").</param>
        private void AddItemToJsonData(string fullPath, string type)
        {
            try
            {
                // Create a new dictionary representing the item.
                Dictionary<string, string> newItem = new Dictionary<string, string>
                {
                    // Add the full path of the item to the dictionary.
                    { "FullPath", fullPath },

                    // Add the type of the item (e.g., "Folder" or "File") to the dictionary.
                    { "Type", type }
                };

                // Add the item to the JSON data list.
                jsonData.Add(newItem);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while adding an item to JSON data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// Removes an item from the JSON data based on its full path.
        /// </summary>
        /// <param name="fullPath">The full path of the item to be removed.</param>
        private void RemoveItemFromJsonData(string fullPath)
        {
            try
            {
                // Remove the item from the JSON data list using a lambda expression to match the full path.
                jsonData.RemoveAll(item => item["FullPath"] == fullPath);
            }
            catch (Exception ex)
            {
                // Display an error message if an exception occurs while removing the item.
                MessageBox.Show($"An error occurred while removing an item from JSON data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// Allowing navigation to the previous directory.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if there are items in the backStack.
                if (backStack.Count > 0)
                {
                    // Push the currentDirectory onto the forwardStack.
                    forwardStack.Push(currentDirectory);

                    // Update the currentDirectory and addressBar with the popped item from the backStack.
                    addressBar.Text = currentDirectory = backStack.Pop();

                    // Check if the currentDirectory is "home" to determine the action.
                    if (currentDirectory == "home")
                        LoadData(); // Load data for the home directory.
                    else
                        PopulateListView(currentDirectory); // Populate the ListView with items from the current directory.

                    // Enable the forwardButton since there is a previous directory in the forwardStack.
                    forwardButton.Enabled = true;
                }

                // Enable or disable the backButton based on the number of items in the backStack.
                backButton.Enabled = backStack.Count > 0;
            }
            catch (Exception ex)
            {
                // Display an error message if an exception occurs while navigating back.
                MessageBox.Show($"An error occurred while navigating back: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// Allowing navigation to the next directory.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ForwardButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if there are items in the forwardStack.
                if (forwardStack.Count > 0)
                {
                    // Push the currentDirectory onto the backStack.
                    backStack.Push(currentDirectory);

                    // Update the currentDirectory and addressBar with the popped item from the forwardStack.
                    addressBar.Text = currentDirectory = forwardStack.Pop();

                    // Populate the ListView with items from the current directory.
                    PopulateListView(currentDirectory);

                    // Enable the backButton since there is a next directory in the backStack.
                    backButton.Enabled = true;
                }

                // Enable or disable the forwardButton based on the number of items in the forwardStack.
                forwardButton.Enabled = forwardStack.Count > 0;
            }
            catch (Exception ex)
            {
                // Display an error message if an exception occurs while navigating forward.
                MessageBox.Show($"An error occurred while navigating forward: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// Navigates to the specified directory.
        /// </summary>
        /// <param name="path">The path of the directory to navigate to.</param>
        private void NavigateToDirectory(string path)
        {
            try
            {
                // Check if the currentDirectory is not empty or null.
                if (!string.IsNullOrEmpty(currentDirectory))
                {
                    // Push the currentDirectory onto the backStack.
                    backStack.Push(currentDirectory);

                    // Enable the backButton since there is a previous directory in the backStack.
                    backButton.Enabled = true;
                }

                // Update the currentDirectory and addressBar with the specified path.
                addressBar.Text = currentDirectory = path;

                // Clear the forwardStack
                forwardStack.Clear();
                // disable the forwardButton
                forwardButton.Enabled = false;

                // Populate the ListView with items from the current directory.
                PopulateListView(currentDirectory);
            }
            catch (Exception ex)
            {
                // Display an error message if an exception occurs while navigating to the directory.
                MessageBox.Show($"An error occurred while navigating to the directory: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// Populates the ListView with items from the specified directory path.
        /// </summary>
        /// <param name="path">The path of the directory to populate the ListView with.</param>
        public void PopulateListView(string path)
        {
            // Begin updating the ListView to improve performance.
            listView.BeginUpdate();

            // Clear existing items in the ListView.
            listView.Items.Clear();

            // Clear the full path status label.
            toolStripStatusLabelFullPath.Text = "";

            try
            {
                // Create a DirectoryInfo object for the specified path.
                DirectoryInfo directoryInfo = new DirectoryInfo(path);

                // Get the directories and files within the specified directory.
                DirectoryInfo[] directories = directoryInfo.GetDirectories();
                FileInfo[] files = directoryInfo.GetFiles();

                // Iterate through the directories and add them as ListView items.
                foreach (DirectoryInfo directory in directories)
                {
                    // Create a new ListViewItem with the directory name.
                    ListViewItem item = listView.Items.Add(directory.Name);

                    // Set the tag to the full directory path.
                    item.Tag = directory.FullName;

                    // Set the image index for displaying the folder icon.
                    item.ImageIndex = 1;

                    // Check if the directory has hidden and system attributes.
                    FileAttributes attributes = File.GetAttributes(directory.FullName);
                    bool hasHiddenAndSystemAttributes = (attributes & (FileAttributes.Hidden | FileAttributes.System)) ==
                                                        (FileAttributes.Hidden | FileAttributes.System);

                    // Set the tooltip text with size and status information.
                    item.ToolTipText = $"Size: N/A\nStatus: {(hasHiddenAndSystemAttributes ? "Hidden" : "Visible")}";
                }

                // Iterate through the files and add them as ListView items.
                foreach (FileInfo file in files)
                {
                    // Create a new ListViewItem with the file name.
                    ListViewItem item = listView.Items.Add(file.Name);

                    // Set the tag to the full file path.
                    item.Tag = file.FullName;

                    // Set the image index based on the file extension.
                    item.ImageIndex = 0;

                    // Check if the file has hidden and system attributes.
                    FileAttributes attributes = File.GetAttributes(file.FullName);
                    bool hasHiddenAndSystemAttributes = (attributes & (FileAttributes.Hidden | FileAttributes.System)) ==
                                                        (FileAttributes.Hidden | FileAttributes.System);

                    // Set the tooltip text with size and status information.
                    item.ToolTipText = $"Size: {SizeManager.FormatSize(file.Length)}\nStatus: {(hasHiddenAndSystemAttributes ? "Hidden" : "Visible")}";
                }
            }
            catch (Exception e)
            {
                // Display an error message if an exception occurs during the population process.
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // End updating the ListView and apply the changes.
            listView.EndUpdate();
        }


        /// <summary>
        /// Event handler for the "Add Files" menu item click event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Call the AddFilesOrFolders method to add files (only files, not folders).
            AddFilesOrFolders(false);
        }


        /// <summary>
        /// Event handler for the "Add Folders" menu item click event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddFoldersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Call the AddFilesOrFolders method to add folders (only folders, not files).
            AddFilesOrFolders(true);
        }


        /// <summary>
        /// Event handler for the "Remove" menu item click event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Call the RemoveSelectedItems method to remove the selected items.
            RemoveSelectedItems();
        }


        /// <summary>
        /// Event handler for the "Refresh" button click event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RefreshButton_Click(object sender, EventArgs e)
        {
            // Check the current directory and refresh the view accordingly.
            if (currentDirectory == "home")
            {
                // If the current directory is "home", call the LoadData method to reload the data.
                LoadData();
            }
            else
            {
                // If the current directory is not "home", call the PopulateListView method to refresh the view.
                PopulateListView(currentDirectory);
            }
        }


        /// <summary>
        /// Displays the full path of a selected item in the status bar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // Cast the sender object to a ListView
                ListView listView = sender as ListView;

                // Check the number of selected items in the ListView
                if (listView.SelectedItems.Count == 1)
                {
                    // Retrieve the selected item
                    ListViewItem selectedItem = listView.SelectedItems[0];

                    // Display the full path of the selected item in the status bar
                    toolStripStatusLabelFullPath.Text = $"Path: {selectedItem.Tag}";
                }
                else
                {
                    // If no item or multiple items are selected, clear the status bar
                    toolStripStatusLabelFullPath.Text = "";
                }
            }
            catch (Exception ex)
            {
                // Display an error message box if an exception occurs
                MessageBox.Show($"Error in Select Index Changed: {ex.Message}", "Error");
            }
        }


        /// <summary>
        /// Opens the selected file or navigates to the selected directory.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListView_ItemActivate(object sender, EventArgs e)
        {
            try
            {
                // Cast the sender object to a ListView
                ListView listView = sender as ListView;

                // Check if an item is selected and retrieve its associated path
                if (listView.SelectedItems[0].Tag is string path)
                {
                    // Check if the path corresponds to a file
                    if (File.Exists(path))
                    {
                        // Open the file using the default program associated with its file type
                        Process.Start(path);
                    }
                    else
                    {
                        // Navigate to the selected directory
                        NavigateToDirectory(path);
                        // Update the address bar text with the selected directory path
                        addressBar.Text = path;
                    }
                }
            }
            catch (Exception ex)
            {
                // Display an error message box if an exception occurs
                MessageBox.Show($"An error occurred while opening the file or directory: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// Sets the drag-and-drop effect to Copy if file data is being dragged.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void ListView_DragEnter(object sender, DragEventArgs e)
        {
            // Check if file data is being dragged
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // Set the drag-and-drop effect to Copy
                e.Effect = DragDropEffects.Copy;
            }
        }


        /// <summary>
        /// Handles the dropping of files and folders onto the ListView.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListView_DragDrop(object sender, DragEventArgs e)
        {
            // Retrieve the array of files and folders being dropped
            string[] filesAndFolders = (string[])e.Data.GetData(DataFormats.FileDrop);

            // Iterate through each file or folder
            foreach (string file in filesAndFolders)
            {
                // If the item is a file
                if (File.Exists(file))
                {
                    SetSystemAndHiddenAttributes(file); // Set system and hidden attributes of the file
                    AddItemToJsonData(file, "File"); // Add the file to JSON data
                }
                // If the item is a folder
                else if (Directory.Exists(file))
                {
                    SetSystemAndHiddenAttributes(file); // Set system and hidden attributes of the folder
                    AddItemToJsonData(file, "Folder"); // Add the folder to JSON data
                }

                // Save the updated JSON data
                SaveData();
            }

            // Refresh the ListView to reflect the changes
            LoadData();
        }


        /// <summary>
        /// Updates the tooltip with folder details: type, size, and modification date if the hovered item is a folder.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void ListView_ItemMouseHover(object sender, ListViewItemMouseHoverEventArgs e)
        {
            if (e.Item != null)
            {
                // Get the full path of the item
                string path = e.Item.Tag.ToString();

                // Check if the path represents a directory
                if (Directory.Exists(path))
                {
                    // Calculate the size of the folder asynchronously
                    string folderSize = await SizeManager.GetSize(path);

                    // Update the tooltip of the item with folder information
                    e.Item.ToolTipText = $"Type: Folder\n" +
                        $"Size: {folderSize}\n" +
                        $"Date Modified: {new DirectoryInfo(path).LastWriteTime}";
                }
            }
        }

    }
}
