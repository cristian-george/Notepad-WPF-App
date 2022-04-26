using Notepad.ViewModel;
using System.Windows;
using static Notepad.Model.DataProvider;

namespace Notepad.View
{
    public partial class FindWindow : Window
    {
        private TabCommands tabsCommands;
        public FindWindow(object dataContext)
        {
            InitializeComponent();
            tabsCommands = dataContext as TabCommands;
        }

        private void FindClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            FindWindowOn = false;
        }

        private void FindButton(object sender, RoutedEventArgs e)
        {
            tabsCommands.SelectedTab.WordToFind = textBox.Text;
        }
    }
}
