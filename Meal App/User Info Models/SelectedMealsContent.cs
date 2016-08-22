using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Meal_App.Properties;

namespace Meal_App.User_Info_Models
{
    internal class SelectedMealsContent : INotifyPropertyChanged
    {
        //Gets and sets the content read from the text file containing either the ingredients or the method of the meal.

        Settings _applicationSettings = new Settings();

        public List<string> SelectedMealContent
        {
            get
            {
                return _applicationSettings.selectedMealsContent;
            }
            set
            {
                _applicationSettings.selectedMealsContent = new List<string>();
                _applicationSettings.selectedMealsContent = value;
                _applicationSettings.Save();
                OnPropertyChanged("SelectedMealContent");
            }
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
