using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Meal_App.User_Info_Models;
using Meal_App.Properties;

namespace Meal_App.Main_Window.Logic_Classes
{
    internal class Reset
    {
        //Reset values.
        public void resetValues()
        {
            try
            {
                Budget budget = new Budget();
                Checks checks = new Checks();

                budget.UserBudget = 20;
                checks.BudgetSet = false;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}
