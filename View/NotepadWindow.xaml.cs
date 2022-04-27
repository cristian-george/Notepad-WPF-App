using System.Windows;
using Notepad.ViewModel;

namespace Notepad.View
{
    public partial class NotepadWindow : Window
    {
        private readonly NotepadViewModel viewModel;
        public NotepadWindow()
        {
            InitializeComponent();
            viewModel = new NotepadViewModel();

            DataContext = viewModel;
            menu.DataContext = viewModel.menuCommands;
            tabControl.DataContext = viewModel.tabCommands;
            treeView.DataContext = viewModel.directoryCommands;
        }

        private void WindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            for (int index = Application.Current.Windows.Count - 1; index >= 1; --index)
                Application.Current.Windows[index].Close();
        }

        private void CloseTab(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            viewModel.CloseTab();
        }

        private void ContentChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            string tabContent = (sender as System.Windows.Controls.TextBox).Text;
            viewModel.ContentChanged(tabContent);
        }

        private void OpenFileEvent(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var treeViewItem = (sender as System.Windows.Controls.TreeView).SelectedItem;
            viewModel.OpenFileEvent(treeViewItem);
        }
    }
}