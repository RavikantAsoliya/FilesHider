using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using Microsoft.WindowsAPICodePack;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Threading;

namespace Files_Hider
{
    
    public partial class FilesHider : Form
    {
        private static readonly string path = $@"C:\Users\{Environment.UserName}\Files Hider";
        public FilesHider()
        {
            InitializeComponent();
            CatchData();
        }
        
        private void CatchData()
        {
            if (Directory.Exists(path))
            {
                foreach (var line in File.ReadLines($"{path}\\hiddenFiles.dat"))
                {
                    hiddenFilesListbox.Items.Add(line);
                }
                foreach (var line in File.ReadLines($"{path}\\hiddenFolders.dat"))
                {
                    hiddenFoldersListBox.Items.Add(line);
                }
            }
            else
            {
                Directory.CreateDirectory(path);
                File.Create($"{path}\\hiddenFiles.dat");
                File.Create($"{path}\\hiddenFolders.dat");
                SubProcess.Call("attrib", $"+s +h \"{path}\"");
            }
        }


        #region Add and Remove Files

        private void AddFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(() =>
            {
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Multiselect = true,
                    InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                    Filter = "All Files|*.*",

                };
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (var file in openFileDialog.FileNames)
                    {
                        Task.Factory.StartNew(() =>
                        {
                            SubProcess.Call("attrib", $"+s +h \"{file}\"");
                            hiddenFilesListbox.Invoke((MethodInvoker)(() => hiddenFilesListbox.Items.Add(file)));
                        });
                    }
                    using (StreamWriter streamWriter = File.AppendText($"{path}\\hiddenFiles.dat"))
                    {
                        foreach (var line in openFileDialog.FileNames)
                        {
                            streamWriter.WriteLine(line);
                        }
                    }
                }
            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        private void RemoveFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                List<string> files = new List<string>();

                hiddenFilesListbox.Invoke((MethodInvoker)(() =>
                {
                    foreach (int index in hiddenFilesListbox.SelectedIndices)
                    {
                        string file = hiddenFilesListbox.Items[index].ToString();
                        files.Add(file);
                    }
                }));

                foreach (string file in files)
                {
                    SubProcess.Call("attrib", $"-s -h \"{file}\"");
                    hiddenFilesListbox.Invoke((MethodInvoker)(() => hiddenFilesListbox.Items.Remove(file)));
                }

                using (StreamWriter streamWriter = File.CreateText($"{path}\\hiddenFiles.dat"))
                {
                    for (int i = 0; i <= hiddenFilesListbox.Items.Count - 1; i++)
                        streamWriter.WriteLine(hiddenFilesListbox.Items[i].ToString());
                }
            });
        }

        #endregion


        #region Add and Remove Folders

        private void AddFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog commonOpenFileDialog = new CommonOpenFileDialog
            {
                IsFolderPicker = true,
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                Multiselect = true
            };
            if (commonOpenFileDialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                foreach (var folder in commonOpenFileDialog.FileNames)
                {
                    SubProcess.Call("attrib", $"+s +h \"{folder}\"");
                    hiddenFoldersListBox.Items.Add(folder);
                }
                using (StreamWriter streamWriter = File.AppendText($"{path}\\hiddenFolders.dat"))
                {
                    foreach (var line in commonOpenFileDialog.FileNames)
                    {
                        streamWriter.WriteLine(line);
                    }
                }
            }
        }
        private void RemoveFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> folders = new List<string>();
            foreach (int index in hiddenFoldersListBox.SelectedIndices)
            {
                string folder = hiddenFoldersListBox.Items[index].ToString();
                folders.Add(folder);
            }
            foreach (string folder in folders)
            {
                hiddenFoldersListBox.Items.Remove(folder);
                SubProcess.Call("attrib", $"-s -h \"{folder}\"");
            }

            using (StreamWriter streamWriter = File.CreateText($"{path}\\hiddenFolders.dat"))
            {
                for (int i = 0; i <= hiddenFoldersListBox.Items.Count - 1; i++)
                    streamWriter.WriteLine(hiddenFoldersListBox.Items[i].ToString());
            }
        }

        #endregion


        #region Drag App

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr one, int two, int three, int four);

        private void TitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }

        #endregion


        private void ExitButton_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        
    }
}
