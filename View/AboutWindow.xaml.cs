using System.Windows;
using static Notepad.Model.DataProvider;

namespace Notepad.View
{
    public partial class AboutWindow : Window
    {
        public AboutWindow()
        {
            InitializeComponent();
        }

        private void AboutClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            AboutWindowOn = false;
        }

        private void RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Uri.ToString());
        }
    }
}
