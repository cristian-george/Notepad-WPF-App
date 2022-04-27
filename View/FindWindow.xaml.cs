using Notepad.ViewModel;
using System.Windows;
using static Notepad.Model.DataProvider;

namespace Notepad.View
{
    public partial class FindWindow : Window
    {
        private readonly FindViewModel viewModel;

        public FindWindow(object dataContext)
        {
            InitializeComponent();
            viewModel = new FindViewModel(dataContext);
            DataContext = viewModel;
        }

        private void FindClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            FindWindowOn = false;
        }

        private void FindButton(object sender, RoutedEventArgs e)
        {
            viewModel.SetWordToFind(textBox.Text);
        }
    }
}
