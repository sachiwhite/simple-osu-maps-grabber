using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace osuGrabber.ViewModel
{
    public class RelayCommandAsync : CommandBase, ICommand
    {
        public static bool DoingThings;
        private readonly Func<object, Task> execute;
        public RelayCommandAsync(Func<object, Task> _execute, Predicate<object> _canExecute = null) :base(_canExecute)
        {
            
            try
            {
                execute = _execute ?? throw new ArgumentNullException(nameof(_execute));
            }
            catch (ArgumentNullException)
            {
                Task.Run(() =>
                   Messaging.Report("You didn't choose any song!","Error") );
            }
            
        }
        public override async void Execute(object parameter)
        {
            try
            {
                await execute(parameter);
            }
            catch
            {
                await Messaging.Report("You didn't choose any song!", "Error");
            }
           
        }
    }
}
