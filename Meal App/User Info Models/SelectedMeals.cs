using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sqlite_Functions.SqliteFunctions;
using System.ComponentModel;
using Meal_App.Properties;

namespace Meal_App.User_Info_Models
{
    public class SelectedMeals : INotifyPropertyChanged
    {
        public string this[string columnName]
        {
            get
            {
                if (columnName == "SelectedMeals")
                {
                    if (MealNames == null)
                        Error = null;
                }
                return Error;
            }
        }

        public string Error
        {
            get;
            private set;
        }

        AppSettingsGetters getters = new AppSettingsGetters();
        Settings _applicationSettings = new Settings();

        private List<string> _selectedMeals = new List<string>();
        public List<string> MealNames
        {
            get
            {
                _applicationSettings.selectedMeals = new List<string>();
                _applicationSettings.selectedMeals = getters.SelectedMeals;
                _applicationSettings.Save();
                //OnPropertyChanged("MealNames");
                return _applicationSettings.selectedMeals;
            }
            set
            {
                getters.SelectedMeals = new List<string>();
                getters.SelectedMeals = value;
                OnPropertyChanged("MealNames");
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
