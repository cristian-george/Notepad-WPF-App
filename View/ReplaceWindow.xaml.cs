using Notepad.ViewModel;
using System.Windows;
using static Notepad.Model.DataProvider;

namespace Notepad.View
{
    public partial class ReplaceWindow : Window
    {
        private readonly ReplaceViewModel viewModel;

        public ReplaceWindow(object dataContext)
        {
            InitializeComponent();
            viewModel = new ReplaceViewModel(dataContext as TabCommands);
            DataContext = viewModel;
        }

        private void ReplaceClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ReplaceWindowOn = false;
        }

        private void ReplaceButton(object sender, RoutedEventArgs e)
        {
            string stringToFind = textBoxFind.Text;
            string stringToReplace = textBoxReplace.Text;

            if (string.IsNullOrEmpty(stringToFind) && string.IsNullOrEmpty(stringToReplace))
                return;

            viewModel.PerformReplace(stringToFind, stringToReplace, (bool)replaceAll.IsChecked, (bool)replaceInOpenedFiles.IsChecked);
        }
    }
}
