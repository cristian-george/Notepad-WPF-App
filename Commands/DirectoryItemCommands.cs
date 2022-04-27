using Notepad.Model;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace Notepad.ViewModel
{
    public class DirectoryItemCommands : BaseViewModel
    {
        public DirectoryItemType Type { get; set; }
        public string FullPath { get; set; }
        public string Name
        {
            get
            {
                return Type == DirectoryItemType.Drive ? FullPath : DirectoryStructure.GetFileFolderName(FullPath);
            }
        }

        public ObservableCollection<DirectoryItemCommands> Children { get; set; }

        public bool CanExpand
        {
            get
            {
                return Type != DirectoryItemType.File;
            }
        }

        public bool IsExpanded
        {
            get
            {
                return Children?.Count(child => child != null) > 0;
            }
            set
            {
                if (value == true)
                {
                    Expand(this);
                }
                else
                {
                    Collapse();
                }
            }
        }
        public string ImageName
        {
            get
            {
                if (Type == DirectoryItemType.Drive)
                    return "drive";

                if (Type == DirectoryItemType.File)
                    return "file";

                if (Type == DirectoryItemType.Folder && IsExpanded == true)
                    return "folder-open";

                return "folder-closed";
            }
        }

        public DirectoryItemCommands(string fullPath, DirectoryItemType type)
        {
            ExpandCommand = new RelayCommand(Expand);
            FullPath = fullPath;
            Type = type;

            Collapse();
        }

        public ICommand ExpandCommand { get; set; }

        private void Expand(object parameter)
        {
            if (Type == DirectoryItemType.File) return;

            var children = DirectoryStructure.GetDirectoryContents(FullPath);
            Children = new ObservableCollection<DirectoryItemCommands>(
                       children.Select(content => new DirectoryItemCommands(content.FullPath, content.Type)));
        }

        private void Collapse()
        {
            Children = new ObservableCollection<DirectoryItemCommands>();

            if (Type != DirectoryItemType.File)
                Children.Add(null);
        }
    }
}
