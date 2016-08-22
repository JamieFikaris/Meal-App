using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Meal_App.Splash_Window
{
    internal class SplashWindowButton : ICommand
    {
       //Command for the button on the splash screen.

        public SplashWindowButton(SplashWindowViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        private SplashWindowViewModel _viewModel;

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
            _viewModel.checkWhichWindowToShowUser();
        }
    }
}
