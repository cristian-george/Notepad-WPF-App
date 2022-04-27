using Notepad.Model;
using System.Collections.ObjectModel;
using System.Linq;

namespace Notepad.ViewModel
{
    public class DirectoryStructureViewModel : BaseViewModel
    {
        public ObservableCollection<DirectoryItemCommands> Items { get; set; }

        public DirectoryStructureViewModel()
        {
            var children = DirectoryStructure.GetLogicalDrives();
            Items = new ObservableCollection<DirectoryItemCommands>(
                children.Select(drive => new DirectoryItemCommands(drive.FullPath, DirectoryItemType.Drive)));
        }
    }
}