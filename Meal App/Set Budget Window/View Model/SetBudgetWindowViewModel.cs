using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Meal_App.Properties;
using Meal_App.Set_Budget_Window.ButtonCommand;
using System.Windows.Input;
using System.Windows;
using Meal_App.User_Info_Models;
using Meal_App.Shared_Logic_Classes;
using Meal_App.Main_Window.View;

namespace Meal_App.Set_Budget_Window.View_Model
{
    internal class SetBudgetWindowViewModel
    {
        //View model for the set budget window.
        public SetBudgetWindowViewModel()
        {
            _budget = new Budget();
            ButtonCommand = new SetBudgetWindowButtonCommand(this);
        }

        public Action CloseAction { get; set; }
        private Budget _budget;

        public ICommand ButtonCommand
        {
            get;
            private set;
        }

        public Budget Budget //Returns the budget.
        {
            get { return _budget; }
        }

        public bool canUpdate //Disable button if text is less than 20, text is not a number or if the textbox is _empty.
        {
            get
            {
                if (Budget == null || _budget.UserBudget < 20)
                {
                    return false;
                }
                return !Double.IsNaN(Budget.UserBudget); //Return if not _empty.

            }
        }

        public void setUserStartAndResetDates() //Sets the start and reset date so a new meal list can be created each week.
        {
            try
            {
                UserDates userDates = new UserDates();
                Checks checks = new Checks();

                GetStartAndResetDates setDates = new GetStartAndResetDates(); //Gets current and next weeks date.

                userDates.UserStartDate = setDates.currentDate();  //Sets start date.
                userDates.UserResetDate = setDates.nextWeekDate(); //Sets reset date.
                checks.BudgetSet = true; //Set true to set the budget check to true so we don't set a new budget each time the program opens.

                //Open main window
                MainWindow mainWindow = new MainWindow();
                CloseAction();
                mainWindow.ShowDialog();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}
