using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Meal_App.Splash_Window;

namespace Meal_App
{
    public partial class SplashWindow : Window
    {
        public SplashWindow()
        {
            
            SplashWindowViewModel viewModel = new SplashWindowViewModel();
            this.DataContext = viewModel;
            if (viewModel.CloseAction == null)
                viewModel.CloseAction = new Action(this.Close);

            InitializeComponent();
        }
    }
}
