using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace osuGrabber.ViewModel
{
    internal class RelayCommand : CommandBase, ICommand
    {
        private Action<object> execute;

        public RelayCommand(Action<object> _execute,Predicate<object> _canExecute = null) : base(_canExecute)
        {
            try
            {
                execute = _execute ?? throw new ArgumentNullException(nameof(_execute));
            }
            catch (ArgumentNullException)
            {
                Task.Run(()=> Messaging.Report("You didn't choose any song!", "Error"));
            }
        }

        public override void Execute(object parameter)
        {
            execute(parameter);
        }
    }
}