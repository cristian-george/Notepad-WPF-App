using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Notepad.Model
{
    public static class DirectoryStructure
    {
        public static List<DirectoryItem> GetLogicalDrives()
        {
            return Directory.GetLogicalDrives().Select
                (drive => new DirectoryItem
                {
                    FullPath = drive,
                    Type = DirectoryItemType.Drive
                }).ToList();
        }

        public static List<DirectoryItem> GetDirectoryContents(string fullPath)
        {
            List<DirectoryItem> items = new List<DirectoryItem>();

            #region GetFolders
            try
            {
                string[] directories = Directory.GetDirectories(fullPath);
                if (directories.Length > 0)
                {
                    items.AddRange(directories.Select
                        (dir => new DirectoryItem
                        {
                            FullPath = dir,
                            Type = DirectoryItemType.Folder
                        }));
                }
            }
            catch { }
            #endregion

            #region GetFiles
            try
            {
                string[] files = Directory.GetFiles(fullPath);
                if (files.Length > 0)
                {
                    items.AddRange(files.Select(
                        file => new DirectoryItem
                        {
                            FullPath = file,
                            Type = DirectoryItemType.File
                        }));
                }
            }
            catch { }
            #endregion

            return items;
        }

        public static string GetFileFolderName(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                return string.Empty;
            }

            string normalizedPath = path.Replace('/', '\\');

            int lastIndex = normalizedPath.LastIndexOf('\\');
            if (lastIndex <= 0)
                return path;

            return path.Substring(lastIndex + 1);
        }
    }
}
