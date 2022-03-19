using Notepad.Model;
using System.Collections.ObjectModel;

namespace Notepad.ViewModel
{
    class TabCommands
    {
        public static ObservableCollection<Tab> Tabs { get; set; }

        public TabCommands()
        {
            Tabs = new ObservableCollection<Tab>()
            {
                new Tab() { Header = "File1.txt", Content = "" }
            };
        }

        public static void AddNewTab()
        {
            int count = Tabs.Count + 1;
            Tab tab = new Tab() { Header = "File" + count.ToString() + ".txt", Content = "" };
            Tabs.Add(tab);
        }

        public static void AddNewTab(string header, string content)
        {
            Tab tab = new Tab() { Header = header, Content = content };
            Tabs.Add(tab);
        }
    }
}
