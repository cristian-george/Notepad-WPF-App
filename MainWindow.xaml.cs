using System.IO;
using System.Windows;
using Microsoft.Win32;
using Notepad.ViewModel;

namespace Notepad
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
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
                Model.Tab tab = tabControl.SelectedItem as Model.Tab;
                if (tab.OldContent != tab.Content)
                {
                    SaveFileDialog saveFile = new SaveFileDialog
                    {
                        FileName = tab.Header,
                        Filter = "Text document (*.txt)|*.txt|All files (*.*)|*.*"
                    };

                    if (saveFile.ShowDialog() == true)
                    {
                        string filePath = saveFile.FileName;
                        string fileContent = tab.Content;

                        File.WriteAllText(filePath, fileContent);
                    }
                }

                TabCommands.RemoveTab();
            }
        }

        private void ContentChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (tabControl.SelectedItem != null)
            {
                TabCommands.SelectedTab.Content = (sender as System.Windows.Controls.TextBox).Text;

                if (TabCommands.SelectedTab.OldContent != TabCommands.SelectedTab.Content)
                {
                    TabCommands.SelectedTab.BlankSpace = "*  ";
                }
                else
                {
                    TabCommands.SelectedTab.BlankSpace = "   ";
                }
            }
        }

        private void OpenFileEvent(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (treeView.SelectedItem != null)
            {
                DirectoryItemCommands directoryItem = treeView.SelectedItem as DirectoryItemCommands;
                if (directoryItem.Type == Model.DirectoryItemType.File)
                {
                    StreamReader streamReader = new StreamReader(File.OpenRead(directoryItem.FullPath));
                    TabCommands.AddNewTab(directoryItem.Name, streamReader.ReadToEnd(), directoryItem.FullPath);
                    streamReader.Dispose();
                }
            }
        }
    }
}