using System.Windows;
using static Notepad.Model.DataProvider;

namespace Notepad.View
{
    public partial class ReplaceWindow : Window
    {
        public ReplaceWindow()
        {
            InitializeComponent();
        }

        private void ReplaceClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ReplaceWindowOn = false;
        }
    }
}
