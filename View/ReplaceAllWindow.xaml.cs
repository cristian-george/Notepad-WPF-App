using System.Windows;
using static Notepad.Model.DataProvider;

namespace Notepad.View
{
    public partial class ReplaceAllWindow : Window
    {
        public ReplaceAllWindow()
        {
            InitializeComponent();
        }

        private void ReplaceAllClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ReplaceAllWindowOn = false;
        }
    }
}
