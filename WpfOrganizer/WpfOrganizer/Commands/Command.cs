using System;
using System.Windows.Input;

namespace WpfOrganizer.Commands
{
    abstract class Command : ICommand
    {
        // Передаем управление WPF (автоматически). Virtual чтоб если чо поменять
        public virtual event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public abstract bool CanExecute(object parameter);
        public abstract void Execute(object parameter);
    }
}
