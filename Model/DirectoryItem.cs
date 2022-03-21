namespace Notepad.Model
{
    public enum DirectoryItemType
    {
        Drive,
        File,
        Folder
    }

    public class DirectoryItem
    {
        public DirectoryItemType Type { get; set; }
        public string FullPath { get; set; }
        public string Name
        {
            get
            {
                if (Type == DirectoryItemType.Drive)
                    return FullPath;

                return DirectoryStructure.GetFileFolderName(FullPath);
            }
        }
    }
}
