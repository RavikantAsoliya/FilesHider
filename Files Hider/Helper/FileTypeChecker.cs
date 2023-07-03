using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Files_Hider.Helper
{
    internal class FileTypeChecker
    {
        /// <summary>
        /// Gets the file type based on a list of files and folders.
        /// </summary>
        /// <param name="listOfFilesAndFolders">The list of files and folders.</param>
        /// <returns>The file type based on the list.</returns>
        public static string GetFileType(List<string> ListOfFilesAndFolders)
        {
            // Check if all items in the list exist as files
            bool allFiles = ListOfFilesAndFolders.All(File.Exists);

            // Check if all items in the list exist as folders
            bool allFolders = ListOfFilesAndFolders.All(Directory.Exists);

            // Check if the list contains more than one item
            if (ListOfFilesAndFolders.Count > 1)
            {
                // Check if all items in the list are files and have the same extension
                if (allFiles && ListOfFilesAndFolders.All(item => Path.GetExtension(item) == Path.GetExtension(ListOfFilesAndFolders.First())))
                {
                    // Get the file extension of the first item in the list
                    string fileExtension = Path.GetExtension(ListOfFilesAndFolders.First());

                    // Get the file type based on the extension
                    string fileType = GetFileTypeByExtension(fileExtension);

                    // Return the file type if it exists, otherwise return the file extension with a label
                    return fileType != null ? $"All of type {fileType}" : $"All of type {fileExtension} File";
                }

                // Check if all items in the list are folders
                return allFolders ? "All of Type File folder" : "Multiple Types";
            }

            // Get the first item in the list
            string fileOrFolder = ListOfFilesAndFolders[0];

            // Check if the item exists as a file, and return its type if it does
            // Otherwise, return "File Folder" to indicate it's a folder
            return File.Exists(fileOrFolder) ? GetFileTypeByExtension(Path.GetExtension(fileOrFolder)) : "File Folder";
        }




        /// <summary>
        /// Gets the file type based on the file extension.
        /// </summary>
        /// <param name="extension">The file extension.</param>
        /// <returns>The file type based on the extension.</returns>
        public static string GetFileTypeByExtension(string extension)
        {
            string fileType = null;

            // Open the Windows Registry to retrieve the file type based on the extension
            using (RegistryKey key = Registry.ClassesRoot.OpenSubKey(extension))
            {
                if (key != null && key.GetValue("") != null)
                {
                    string fileClass = key.GetValue("").ToString();

                    // Open the registry key for the file class
                    using (RegistryKey classKey = Registry.ClassesRoot.OpenSubKey(fileClass))
                    {
                        if (classKey != null && classKey.GetValue("") != null)
                        {
                            fileType = classKey.GetValue("").ToString();
                        }
                    }
                }
            }

            // If the file type is not found, construct a generic file type based on the extension
            return fileType ?? $"{extension.Replace(".", "").ToUpperInvariant()} File";
        }

    }
}
