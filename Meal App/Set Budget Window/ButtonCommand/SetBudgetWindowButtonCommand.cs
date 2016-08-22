using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Meal_App.Set_Budget_Window.View_Model;

namespace Meal_App.Set_Budget_Window.ButtonCommand
{
    internal class SetBudgetWindowButtonCommand : ICommand
    {
        //View model for the set budget window.
        public SetBudgetWindowButtonCommand(SetBudgetWindowViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        private SetBudgetWindowViewModel _viewModel;

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
            _viewModel.setUserStartAndResetDates();
        }
    }
}
