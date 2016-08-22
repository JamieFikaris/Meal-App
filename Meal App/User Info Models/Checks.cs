using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Meal_App.Properties;

namespace Meal_App.User_Info_Models
{
    public class Checks
    {
        private Settings applicationSettings = new Settings(); //Creates an instance to access application settings.

        public bool BudgetSet
        {
            get { return applicationSettings.budgetSet; }
            set
            {
                applicationSettings.budgetSet = value;
                applicationSettings.Save();
            }
        }

        public bool MealsHaveBeenSelected
        {
            get { return applicationSettings.mealsHaveBeenSelectedCheck; }
            set
            {
                applicationSettings.mealsHaveBeenSelectedCheck = value;
                applicationSettings.Save();
            }
        }
    }
}
