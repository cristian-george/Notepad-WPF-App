using Microsoft.Xaml.Behaviors;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using static Notepad.Model.DataProvider;

namespace Notepad.ViewModel
{
    internal class TextBoxSelectionBehavior : Behavior<TextBox>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.SelectionChanged += TextBoxSelectionChanged;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.SelectionChanged -= TextBoxSelectionChanged;
        }

        private void TextBoxSelectionChanged(object sender, RoutedEventArgs e)
        {
            SelectedText = AssociatedObject.SelectedText;
        }

        public string SelectedText
        {
            get
            {
                return (string)GetValue(SelectedTextProperty);
            }
            set
            {
                SetValue(SelectedTextProperty, value);
            }
        }

        public static readonly DependencyProperty SelectedTextProperty = DependencyProperty.Register("SelectedText", typeof(string),
            typeof(TextBoxSelectionBehavior),
            new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnSelectedTextChanged));

        private static void OnSelectedTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (FindWindowOn == true)
            {
                var behavior = d as TextBoxSelectionBehavior;
                if (behavior.AssociatedObject == null || behavior.SelectedText == null)
                    return;

                var currentText = behavior.AssociatedObject.Text;
                var start = currentText.IndexOf(behavior.SelectedText);
                if (start >= 0)
                {
                    behavior.AssociatedObject.SelectionBrush = Brushes.Blue;
                    behavior.AssociatedObject.Select(start, behavior.SelectedText.Length);
                    behavior.AssociatedObject.Focus();
                }
            }
        }
    }
}
