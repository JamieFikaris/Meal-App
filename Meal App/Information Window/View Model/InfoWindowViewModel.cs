using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Meal_App.User_Info_Models;
using System.ComponentModel;
using Meal_App.Information_Window.Logic_Classes;
using System.Windows.Input;
using Meal_App.Information_Window.Commands;
using System.Windows;

namespace Meal_App.Information_Window.View_Model
{
    internal class InfoWindowViewModel : INotifyPropertyChanged
    {
        //View model for the information window.
        public InfoWindowViewModel(string selectedListbox, string selectedItem)
        {
            _fileContents = new SelectedMealsContent();
            WindowCommand = new OnLoadedWindow(this);
            _selectedItem = selectedItem;
            _selectedListbox = selectedListbox;
        }

        public Action CloseAction { get; set; }

        private SelectedMealsContent _fileContents;
        private string _selectedItem, _selectedListbox;

        public List<string> SelectedContent //Content from text file, either method to make meal or ingredients.
        {
            get
            {
                return _fileContents.SelectedMealContent;
            }
            set
            {
                _fileContents.SelectedMealContent = new List<string>();
                _fileContents.SelectedMealContent = value;
                OnPropertyChanged("SelectedContent");
            }
        }

        public bool canUpdate //No validation needed so just return true.
        {
            get
            {
                return true;
            }
        }

        public void readFromTextFile() //Reads either the method or ingredients text file.
        {                              //Determines this by passing _selectedListBox which is either ingredients or else.
            ReadFromFile read = new ReadFromFile(_selectedItem, _selectedListbox);
            List<string> ing = read.readFromTextFile(); //Returns content from text file.

            SelectedContent = ing; 
        }

        public ICommand WindowCommand
        {
            get;
            private set;
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
