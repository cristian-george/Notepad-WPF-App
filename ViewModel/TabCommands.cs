using Notepad.Model;
using System.Collections.ObjectModel;

namespace Notepad.ViewModel
{
    class TabCommands
    {
        public static ObservableCollection<Tab> Tabs { get; set; }

        public TabCommands()
        {
            Tabs = new ObservableCollection<Tab>();
            AddNewTab();
        }

        public static void AddNewTab()
        {
            int count = Tabs.Count + 1;
            Tab tab = new Tab() { Header = "File" + count.ToString() + ".txt", Content = "", FilePath = "" };
            Tabs.Add(tab);
        }

        public static void AddNewTab(string header, string content, string filePath)
        {
            Tab tab = new Tab() { Header = header, Content = content, FilePath = filePath };
            Tabs.Add(tab);
        }
    }
}
