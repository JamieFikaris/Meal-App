using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Meal_App.Properties;

namespace Meal_App.User_Info_Models
{
    public class UserDates
    {
        private Settings applicationSettings = new Settings(); //Creates an instance to access application settings.

        public string UserStartDate
        {
            get { return applicationSettings.weekStartDate; }
            set
            {
                applicationSettings.weekStartDate = value;
                applicationSettings.Save();
            }
        }

        public string UserResetDate
        {
            get { return applicationSettings.nextWeekResetDate; }
            set
            {
                applicationSettings.nextWeekResetDate = value;
                applicationSettings.Save();
            }
        }
    }
}
