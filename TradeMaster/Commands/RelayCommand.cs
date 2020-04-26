using System;
using System.Windows.Input;

namespace TradeMaster.Commands
{
    public class RelayCommand : ICommand
    {
        public Action<object> MethodActions;
        public Func<object, bool> CanMethodExecute;
        public event EventHandler CanExecuteChanged; 

        public RelayCommand(Action<object> methodActions, Func<object, bool> canMethodExecute) {
            MethodActions = methodActions;
            CanMethodExecute = canMethodExecute;
        }

        public void Execute(object parameter) {
            MethodActions.Invoke(parameter);
        }

        public bool CanExecute(object parameter) {
            return CanMethodExecute.Invoke(parameter);
        }
    }
}
