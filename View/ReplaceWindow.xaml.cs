using Notepad.ViewModel;
using System.Windows;
using static Notepad.Model.DataProvider;

namespace Notepad.View
{
    public partial class ReplaceWindow : Window
    {
        private TabCommands tabsCommands;

        bool m_replaceAll;
        bool m_replaceInOpenedFiles;

        public ReplaceWindow(object dataContext)
        {
            InitializeComponent();
            tabsCommands = dataContext as TabCommands;
        }

        private void ReplaceClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ReplaceWindowOn = false;
        }

        private void ReplaceFirstApperance(string stringToFind, string stringToReplace, bool isAllOpenedFilesChecked = false)
        {
            if (isAllOpenedFilesChecked == false)
            {
                var currentText = tabsCommands.SelectedTab.Content;
                var start = currentText.IndexOf(stringToFind);
                if (start >= 0)
                {
                    var newText = currentText.Substring(0, start) + stringToReplace + currentText.Substring(start + stringToFind.Length);
                    tabsCommands.SelectedTab.Content = newText;
                }
            }
            else
            {
                var tabs = tabsCommands.Tabs;
                foreach (var tab in tabs)
                {
                    var currentText = tab.Content;
                    var start = currentText.IndexOf(stringToFind);
                    if (start >= 0)
                    {
                        var newText = currentText.Substring(0, start) + stringToReplace + currentText.Substring(start + stringToFind.Length);
                        tab.Content = newText;
                    }
                }
            }
        }

        private void ReplaceAllApperances(string stringToFind, string stringToReplace, bool isAllOpenedFilesChecked = false)
        {
            if (isAllOpenedFilesChecked == false)
            {
                var currentText = tabsCommands.SelectedTab.Content;

                var newText = currentText.Replace(stringToFind, stringToReplace);
                tabsCommands.SelectedTab.Content = newText;
            }
            else
            {
                var tabs = tabsCommands.Tabs;
                foreach (var tab in tabs)
                {
                    var currentText = tab.Content;

                    var newText = currentText.Replace(stringToFind, stringToReplace);
                    tab.Content = newText;
                }
            }
        }

        private void ReplaceButton(object sender, RoutedEventArgs e)
        {
            string stringToFind = textBoxFind.Text;
            string stringToReplace = textBoxReplace.Text;

            if (string.IsNullOrEmpty(stringToFind) && string.IsNullOrEmpty(stringToReplace))
                return;

            m_replaceAll = (bool)replaceAll.IsChecked;
            m_replaceInOpenedFiles = (bool)replaceInOpenedFiles.IsChecked;

            if (m_replaceAll == true)
            {
                if (m_replaceInOpenedFiles == true)
                {
                    ReplaceAllApperances(stringToFind, stringToReplace, true);

                }
                else
                {
                    ReplaceAllApperances(stringToFind, stringToReplace);
                }
            }
            else
            {
                if (m_replaceInOpenedFiles == true)
                {
                    ReplaceFirstApperance(stringToFind, stringToReplace, true);
                }
                else
                {
                    ReplaceFirstApperance(stringToFind, stringToReplace);
                }
            }
        }
    }
}
