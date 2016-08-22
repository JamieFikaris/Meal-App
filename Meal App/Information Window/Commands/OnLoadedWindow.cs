using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Meal_App.Information_Window.View_Model;

namespace Meal_App.Information_Window.Commands
{
    internal class OnLoadedWindow : ICommand
    {
        public OnLoadedWindow(InfoWindowViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        private InfoWindowViewModel _viewModel;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return _viewModel.canUpdate;
        }

        public void Execute(object parameter)
        {
            _viewModel.readFromTextFile();
            //set mealshavebeenselected to true here when done with project
        }
    }
}
