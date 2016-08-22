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
using System.Windows.Shapes;
using Meal_App.User_Info_Models;
using Meal_App.Set_Budget_Window.View_Model;

namespace Meal_App.Set_Budget_Window
{
    /// <summary>
    /// Interaction logic for SetBudgetWindow.xaml
    /// </summary>
    public partial class SetBudgetWindow : Window
    {
        public SetBudgetWindow()
        {
            InitializeComponent();
            SetBudgetWindowViewModel viewModel = new SetBudgetWindowViewModel();
            this.DataContext = viewModel;
            if (viewModel.CloseAction == null)
                viewModel.CloseAction = new Action(this.Close);
        }
    }
}
