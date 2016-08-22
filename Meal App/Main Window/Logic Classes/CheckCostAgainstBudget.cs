using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Meal_App.User_Info_Models;
using Sqlite_Functions.SqliteFunctions;

namespace Meal_App.Main_Window.Logic_Classes
{
    public class CheckCostAgainstBudget
    {
        //Checks if cost of meals are lower than the user budget.
        public bool checkIfMealCostsAreWithinBudget()
        {
            try
            {
                Budget budget = new Budget();
                AppSettingsGetters getters = new AppSettingsGetters();

                if (getters.CumulativeCost > budget.UserBudget) //If cummulative cost is greater than user budget.
                    return true; //Return true meaning a new list will be made.
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}
