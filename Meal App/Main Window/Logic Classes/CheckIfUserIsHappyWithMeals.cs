using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Meal_App.User_Info_Models;
using Sqlite_Functions.SqliteFunctions;

namespace Meal_App.Main_Window.Logic_Classes
{
    internal class CheckIfUserIsHappyWithMeals
    {
        //Checks if the user is happy with their newely generated meal list.
        public bool askUser()
        {
            try
            {
                CheckCostAgainstBudget checkCost = new CheckCostAgainstBudget();
                MessageBoxResult result = MessageBox.Show("Are you happy with these meals?", "Continue?", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    return true; //User happy with meal list.
                }
                else
                {
                    return false; //New list will be created.
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        
    }
}
