using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Meal_App.User_Info_Models;

namespace Meal_App.Shared_Logic_Classes
{
    public class GetStartAndResetDates
    {
        //Gets current and next weeks date.
        private DateTime _dt = DateTime.Now; //Get current date.

        public string nextWeekDate()
        {
            try
            {
                return _dt.AddDays(7).ToShortDateString().ToString(); //Add 7 days to current date.
            }
            catch(Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public string currentDate()
        {
            try
            {
                return _dt.ToShortDateString().ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

        }
    }
}
            


