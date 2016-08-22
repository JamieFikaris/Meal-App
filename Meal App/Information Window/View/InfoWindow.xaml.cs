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
using Meal_App.Information_Window.View_Model;
using System.Windows.Interactivity;

namespace Meal_App.Information_Window.View
{
    /// <summary>
    /// Interaction logic for InfoWindow.xaml
    /// </summary>
    public partial class InfoWindow : Window
    {
        public InfoWindow(string selectedListbox, string selectedItem)
        {
            InfoWindowViewModel viewModel = new InfoWindowViewModel(selectedListbox, selectedItem);
            this.DataContext = viewModel;
            if (viewModel.CloseAction == null)
                viewModel.CloseAction = new Action(this.Close);
            InitializeComponent();
        }
    }
}
