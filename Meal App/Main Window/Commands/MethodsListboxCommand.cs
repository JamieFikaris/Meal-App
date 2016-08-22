using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Meal_App.Main_Window.View_Model;

namespace Meal_App.Main_Window.Commands
{
    internal class MethodsListboxCommand : ICommand
    {
        public MethodsListboxCommand(MainWindowViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        private MainWindowViewModel _viewModel;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return _viewModel.DisabledDoubleClicks;
        }

        public void Execute(object parameter)
        {
            _viewModel.showInfoWindow("method");
        }
    }
}
