using Notepad.Model;
using System.Collections.ObjectModel;

namespace Notepad.ViewModel
{
    class TabCommands : BaseViewModel
    {
        public static ObservableCollection<Tab> Tabs { get; set; }
        public static Tab SelectedTab { get; set; }

        public TabCommands()
        {
            Tabs = new ObservableCollection<Tab>();
            AddNewFileTab();
        }

        private static int countUntitledFiles = 1;
        public static void AddNewFileTab()
        {
            AddNewTab("File" + countUntitledFiles.ToString() + ".txt");
            ++countUntitledFiles;
        }

        public static void AddNewTab(string header, string content = "", string filePath = "")
        {
            Tabs.Add(new Tab()
            {
                Header = header,
                Content = content,
                FilePath = filePath,
                OldContent = content
            });
        }

        public static void RemoveTab()
        {
            Tabs.Remove(SelectedTab);
        }
    }
}
