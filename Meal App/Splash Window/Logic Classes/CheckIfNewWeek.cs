using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Meal_App.User_Info_Models;
using Meal_App.Shared_Logic_Classes;
using Meal_App.Properties;
using Sqlite_Functions.SqliteFunctions;

namespace Meal_App.Splash_Window.Logic_Classes
{
    public class CheckIfNewWeek
    {
        //Checks if the user needs a new meal list.

        public bool checkIfUserNeedsANewMealList() //Gets the current date and compares it to the next week date that was set when the user first created their meal list
        {                                          //to see when the week was up so a new meal list could be created.
            try
            {
                UserDates usrDates = new UserDates(); //Gets the users' dates.

                DateTime dt = DateTime.Now;
                string currentDate = dt.ToShortDateString().ToString(); //Gets current date and sets it to the short date format.

                if (DateTime.Parse(currentDate) == DateTime.Parse(usrDates.UserResetDate)    //If the current date = the reset date,
                    || DateTime.Parse(currentDate) > DateTime.Parse(usrDates.UserResetDate)) //Or if the current date is over the reset date,
                {                                                                            //The week is over and the user needs a new meal list.
                    GetStartAndResetDates setDates = new GetStartAndResetDates();

                    //Set the new dates.
                    usrDates.UserStartDate = setDates.currentDate();
                    usrDates.UserResetDate = setDates.nextWeekDate();
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
                throw new Exception(ex.ToString());
            }
        }
    }
}
