namespace Notepad.ViewModel
{
    class FindViewModel
    {
        private readonly TabCommands tabCommands;

        public FindViewModel(object dataContext)
        {
            tabCommands = dataContext as TabCommands;
        }

        public void SetWordToFind(string word)
        {
            tabCommands.SelectedTab.WordToFind = word;
        }
    }
}
