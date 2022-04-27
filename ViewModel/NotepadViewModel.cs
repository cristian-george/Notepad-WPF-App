using Microsoft.Win32;
using Notepad.Model;
using System.IO;

namespace Notepad.ViewModel
{
    class NotepadViewModel : BaseViewModel
    {
        public MenuCommands menuCommands;
        public TabCommands tabCommands;
        public DirectoryStructureViewModel directoryCommands;

        public NotepadViewModel()
        {
            tabCommands = new TabCommands();
            menuCommands = new MenuCommands(tabCommands);
            directoryCommands = new DirectoryStructureViewModel();
        }

        public void CloseTab()
        {
            Tab selectedTab = tabCommands.SelectedTab;
            if (selectedTab != null)
            {
                if (selectedTab.OldContent != selectedTab.Content)
                {
                    SaveFileDialog saveFile = new SaveFileDialog
                    {
                        FileName = selectedTab.Header,
                        Filter = "Text document (*.txt)|*.txt|All files (*.*)|*.*"
                    };

                    if (saveFile.ShowDialog() == true)
                    {
                        string filePath = saveFile.FileName;
                        string fileContent = selectedTab.Content;

                        File.WriteAllText(filePath, fileContent);
                    }
                }

                tabCommands.RemoveTab();
            }
        }

        public void ContentChanged(string content)
        {
            Tab selectedTab = tabCommands.SelectedTab;

            if (selectedTab != null)
            {
                selectedTab.Content = content;

                if (selectedTab.OldContent != selectedTab.Content)
                    selectedTab.BlankSpace = "*  ";
                else
                    selectedTab.BlankSpace = "   ";
            }
        }

        public void OpenFileEvent(object selectedItem)
        {
            if (selectedItem != null)
            {
                DirectoryItemCommands directoryItem = selectedItem as DirectoryItemCommands;
                if (directoryItem.Type == DirectoryItemType.File && directoryItem.FullPath.Contains(".txt"))
                {
                    StreamReader streamReader = new StreamReader(File.OpenRead(directoryItem.FullPath));
                    tabCommands.AddNewTab(directoryItem.Name, streamReader.ReadToEnd(), directoryItem.FullPath);
                    streamReader.Dispose();
                }
            }
        }
    }
}
