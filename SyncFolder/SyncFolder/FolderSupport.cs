using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncFolder
{
    class FolderSupport
    {
        /// <summary>
        /// get file/folder name list
        /// </summary>
        /// <param name="targetDirectory"></param>
        /// <param name="rootPath"></param>
        /// <returns>0:folder; 1: file;</returns>
        static public List<string[]> getFileNameList(string targetDirectory, string rootPath)
        {
            List<string[]> fileNameList = new List<string[]>();

            try
            {
                // Recurse into subdirectories of this directory.
                string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
                foreach (string subdirectory in subdirectoryEntries)
                {
                    fileNameList.Add(new String[] { subdirectory.Replace(rootPath, ""), "0" });
                }

                // Process the list of files found in the directory.
                string[] fileEntries = System.IO.Directory.GetFiles(targetDirectory);
                foreach (string fileName in fileEntries)
                {
                    fileNameList.Add(new String[] { fileName.Replace(rootPath, ""), "1" });
                }
            }
            catch (IOException e)
            {
            }

            return fileNameList;
        }


        static public string removeLastSlash(string path)
        {
            return path.TrimEnd(new char[] { '\\' });
        }


        static public string removeLastFile(string path)
        {
            int position = path.LastIndexOf('\\');
            return path.Substring(0, position);
        }

    }
}
