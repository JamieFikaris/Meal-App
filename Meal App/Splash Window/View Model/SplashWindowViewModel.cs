using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Meal_App.Set_Budget_Window;
using System.Windows.Input;
using Meal_App.Properties;
using Meal_App.User_Info_Models;
using Meal_App.Splash_Window.Logic_Classes;
using Meal_App.Main_Window.View;


namespace Meal_App.Splash_Window
{
    internal class SplashWindowViewModel
    {
        //View model for the splash screen window.
        public SplashWindowViewModel()
        {
            ButtonCommand = new SplashWindowButton(this);
        }

        public Action CloseAction { get; set; }
        
        public ICommand ButtonCommand
        {
            get;
            private set;
        }

        public bool canUpdate
        {
            get
            {
                return true;
            }
        }

        public void checkWhichWindowToShowUser()
        {
            try
            {

                Checks checks = new Checks();
                UserDates usrDates = new UserDates(); //Gets users' start and reset dates.


                if (checks.BudgetSet == false) //If the intro has not been completed.
                {
                    SetBudgetWindow setBudgetWindow = new SetBudgetWindow(); //Open the SetBudgetWindow so the user can set a budget and continue the program.
                    CloseAction();
                    setBudgetWindow.ShowDialog();

                }
                else if (usrDates.UserStartDate != null) //If the weekStartDate is not null (error checking). This will compare the dates to see if a new list needs to be created.
                {
                    CheckIfNewWeek checkIfNewWeek = new CheckIfNewWeek();
                    MainWindow mainWindow = new MainWindow();

                    if (checkIfNewWeek.checkIfUserNeedsANewMealList()) //Checks the current date against the next week date set when the user created their meal list.
                    {                                                  //If the current date = or is over the next week date it will then set the new start and reset dates (return true).

                        //Dates have been reset.  
                        //User can create a new meal list.
                        CloseAction();
                        mainWindow.ShowDialog();

                    }
                    else
                    {
                        CloseAction();
                        mainWindow.ShowDialog();
                    }
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

    }
}
