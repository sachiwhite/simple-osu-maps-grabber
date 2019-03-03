using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace osuGrabber.ViewModel
{
    public abstract class CommandBase : ICommand
    {
        protected readonly Predicate<object> canExecute;
        public CommandBase(Predicate<object> _canExecute = null)
        {
            canExecute = _canExecute;
        }
       public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }
        public bool CanExecute(object parameter)
        {
            return canExecute == null ? true : canExecute(parameter);
        }

        public abstract void Execute(object parameter);
      }
}
