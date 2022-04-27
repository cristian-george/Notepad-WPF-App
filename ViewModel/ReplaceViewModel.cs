namespace Notepad.ViewModel
{
    class ReplaceViewModel
    {
        private TabCommands tabCommands;
        public ReplaceViewModel(object dataContext)
        {
            tabCommands = dataContext as TabCommands;
        }

        private void ReplaceFirstApperance(string stringToFind, string stringToReplace, bool isAllOpenedFilesChecked = false)
        {
            if (isAllOpenedFilesChecked == false)
            {
                var currentText = tabCommands.SelectedTab.Content;
                var start = currentText.IndexOf(stringToFind);
                if (start >= 0)
                {
                    var newText = currentText.Substring(0, start) + stringToReplace + currentText.Substring(start + stringToFind.Length);
                    tabCommands.SelectedTab.Content = newText;
                }
            }
            else
            {
                var tabs = tabCommands.Tabs;
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
                var currentText = tabCommands.SelectedTab.Content;

                var newText = currentText.Replace(stringToFind, stringToReplace);
                tabCommands.SelectedTab.Content = newText;
            }
            else
            {
                var tabs = tabCommands.Tabs;
                foreach (var tab in tabs)
                {
                    var currentText = tab.Content;

                    var newText = currentText.Replace(stringToFind, stringToReplace);
                    tab.Content = newText;
                }
            }
        }

        public void PerformReplace(string stringToFind, string stringToReplace, bool replaceAll, bool replaceInOpenedFiles)
        {
            if (replaceAll == true)
            {
                if (replaceInOpenedFiles == true)
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
                if (replaceInOpenedFiles == true)
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
