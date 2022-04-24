using Notepad.Model;
using System.Collections.ObjectModel;

namespace Notepad.ViewModel
{
    class TabCommands : BaseViewModel
    {
        public ObservableCollection<Tab> Tabs { get; set; }
        public Tab SelectedTab { get; set; }

        public TabCommands()
        {
            Tabs = new ObservableCollection<Tab>();
            AddNewFileTab();
        }

        private int countUntitledFiles = 1;

        public void AddNewFileTab()
        {
            AddNewTab("File" + countUntitledFiles.ToString() + ".txt");
            ++countUntitledFiles;
        }

        public void AddNewTab(string header, string content = "", string filePath = "")
        {
            Tab tab = new Tab()
            {
                Header = header,
                Content = content,
                FilePath = filePath,
                OldContent = content
            };

            Tabs.Add(tab);
            SelectedTab = tab;
        }

        public void RemoveTab()
        {
            Tabs.Remove(SelectedTab);
        }
    }
}
