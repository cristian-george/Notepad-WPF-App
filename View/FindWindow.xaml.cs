using System.Windows;
using static Notepad.Model.DataProvider;

namespace Notepad.View
{
    public partial class FindWindow : Window
    {
        public FindWindow()
        {
            InitializeComponent();
        }

        private void FindClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            FindWindowOn = false;
        }
    }
}
