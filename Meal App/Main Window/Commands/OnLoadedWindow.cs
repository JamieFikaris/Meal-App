using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Meal_App.Main_Window.View_Model;
using Meal_App.User_Info_Models;

namespace Meal_App.Main_Window.Commands
{
    internal class OnLoadedWindow : ICommand
    {
        public OnLoadedWindow(MainWindowViewModel viewModel)
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
            return _viewModel.EnableOrDisableButton;
        }

        public void Execute(object parameter)
        {
            _viewModel.EnableOrDisableButton = true;
        }
    }
}
