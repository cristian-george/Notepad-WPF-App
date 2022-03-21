using Notepad.Model;
using System.Collections.ObjectModel;
using static Notepad.Model.DataProvider;

namespace Notepad.ViewModel
{
    class TabCommands
    {
        public static ObservableCollection<Tab> Tabs { get; set; }
        public static Tab SelectedTab { get; set; }

        public TabCommands()
        {
            Tabs = new ObservableCollection<Tab>();
            AddNewTab();
        }

        private static int countUntitledFiles = 1;
        public static void AddNewTab()
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
                FilePath = filePath
            });
        }

        public static void RemoveTab()
        {
            Tabs.Remove(SelectedTab);
        }
    }
}
