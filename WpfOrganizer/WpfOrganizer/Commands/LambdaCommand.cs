using System;
using System.Collections.Generic;
using System.Text;

namespace WpfOrganizer.Commands
{
    class LambdaCommand : Command
    {
        private Action<object> execute;
        private Func<object, bool> canExecute;

        public LambdaCommand(Action<object> execute, Func<object, bool> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException(nameof(execute));
            else
                this.execute = execute;

            this.canExecute = canExecute;
        }

        public override bool CanExecute(object parameter) => (canExecute != null) ? canExecute.Invoke(parameter) : true;

        public override void Execute(object parameter) => execute(parameter);
    }
}
