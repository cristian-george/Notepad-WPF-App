using System.Windows;
using Notepad.ViewModel;
using static Notepad.Model.DataProvider;

namespace Notepad
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            TabControl = tabControl;
        }

        private void WindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            for (int index = Application.Current.Windows.Count - 1; index >= 1; --index)
                Application.Current.Windows[index].Close();
        }

        private void CloseTab(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (tabControl.SelectedItem != null)
            {
                TabCommands.RemoveTab();
            }
        }

        private void ContentChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (tabControl.SelectedItem != null)
            {
                int selectedIndex = tabControl.SelectedIndex;

                TabCommands.Tabs[selectedIndex].BlankSpace = "*  ";
                TabCommands.Tabs[selectedIndex].IsContentModified = true;
                TabCommands.Tabs[selectedIndex].Content = (sender as System.Windows.Controls.TextBox).Text;
            }
        }
    }
}