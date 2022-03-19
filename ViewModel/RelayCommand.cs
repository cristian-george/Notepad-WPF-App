using System;
using System.Windows.Input;

namespace Notepad.ViewModel
{
    class RelayCommand : ICommand
    {
        private readonly Action<object> m_commandTask;

        public RelayCommand(Action<object> workToDo)
        {
            m_commandTask = workToDo;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            m_commandTask(parameter);
        }
    }
}
