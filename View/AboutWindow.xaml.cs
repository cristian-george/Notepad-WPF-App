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
    }
}
