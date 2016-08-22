using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Meal_App.Properties;
using System.ComponentModel;

namespace Meal_App.User_Info_Models
{
    public class Budget : INotifyPropertyChanged, IDataErrorInfo
    {
       //Nothing is passing into the constuctor because otherwise we'd be setting the user budget every time an instance is created.

        private Settings applicationSettings = new Settings(); //Creates an instance to access application settings.

        public string this[string columnName]
        {
            get
            {
                if (columnName == "Budget")
                {
                    if (UserBudget < 20)
                        Error = "Please enter a budget more than £20";
                    else if (Double.IsNaN(UserBudget))
                        Error = "Input must be a number";
                    else
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

        public double UserBudget
        {
            get { return applicationSettings.userBudget; }
            set
            {
                    applicationSettings.userBudget = value; //Sets the application setting userBudget to the value entered by user if value > £20 and no other errors occur.
                    applicationSettings.Save();
                    OnPropertyChanged("Budget");
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
