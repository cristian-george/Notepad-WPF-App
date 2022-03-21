using System.Windows.Controls;

namespace Notepad.Model
{
    class DataProvider
    {
        public static bool AboutWindowOn { get; set; }
        public static bool FindWindowOn { get; set; }
        public static bool ReplaceWindowOn { get; set; }
        public static bool ReplaceAllWindowOn { get; set; }

        public static TabControl TabControl { get; set; }
    }
}
