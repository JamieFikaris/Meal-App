using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Interactivity;
using Meal_App.Main_Window.View;
using System.Windows.Input;
using Meal_App.Main_Window.Commands;
using Meal_App.User_Info_Models;
using Meal_App.Main_Window.Logic_Classes;
using Sqlite_Functions.SqliteFunctions; //Class library for the database function used in this program.
using System.ComponentModel;
using Meal_App.Properties;
using Meal_App.Information_Window.View;

namespace Meal_App.Main_Window.View_Model
{
    internal class MainWindowViewModel : INotifyPropertyChanged
    {
        //View model for the main window.
        public MainWindowViewModel()
        {
            _selectedMeals = new SelectedMeals();
            ButtonCommand = new ButtonCommand(this);
            ResetCommand = new ResetCommand(this);
            IngredientsCommand = new IngredientsListboxCommand(this);
            MethodsCommand = new MethodsListboxCommand(this);
        }

        public Action CloseAction { get; set; }
        private Checks _usrChecks = new Checks();
        private AppSettingsGetters _getters = new AppSettingsGetters();
        private Budget _budget = new Budget();
        private Reset _resetMealNames = new Reset();
        SelectedMeals _selectedMeals = new SelectedMeals();

        public List<string> SelectedMeals //Gets and sets selected meals (sets to empty if the user resets the program).
        {
            get
            {
                return _selectedMeals.MealNames;
            }
            set
            {
                _selectedMeals.MealNames = new List<string>();
                _selectedMeals.MealNames = value;
                OnPropertyChanged("SelectedMeals");
            }
        }

        private string _selectedItem;
        public string SelectedItem //Gets and sets current selected item from listbox.
        {
            get { return _selectedItem; }
            set
            {
                if (value == _selectedItem)
                {
                    return;
                }
                _selectedItem = value;
            }
        }

        public bool MealsHaveBeenSelected //Gets and sets the check to make sure meals have been set so button can be disabled.
        {
            get { return _usrChecks.MealsHaveBeenSelected; }
            set
            {
                _usrChecks.MealsHaveBeenSelected = value;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool EnableOrDisableButton //Enables or disables the button.
        {
            get
            {
                if (_usrChecks.MealsHaveBeenSelected == false) //If MealsHaveBeenSelected property is false,
                    return true;    //return true meaning button will be enabled.
                else
                    return false;
            }
            set { _usrChecks.MealsHaveBeenSelected = value; }
        }

        public bool DisabledDoubleClicks //If the user hasn't created their meal list, they can't double click as there won't be anything to show.
        {
            get
            {
                if (_usrChecks.MealsHaveBeenSelected == false) //If MealsHaveBeenSelected property is false,
                    return false;    //return false meaning the user can trigger the double click event on the listbox.
                else
                    return true;
            }
            set { _usrChecks.MealsHaveBeenSelected = value; }
        }

        public bool canUpdate //No validation needed so just return true.
        {
            get
            {
                return true;
            }
        }

        #region Icommands

        public ICommand ButtonCommand
        {
            get;
            private set;
        }

        public ICommand ListboxCommand
        {
            get;
            private set;
        }

        public ICommand WindowCommand
        {
            get;
            private set;
        }

        public ICommand ResetCommand
        {
            get;
            private set;
        }

        public ICommand IngredientsCommand
        {
            get;
            private set;
        }

        public ICommand MethodsCommand
        {
            get;
            private set;
        }

        #endregion

        public void resetProgram() //Completely resets the program.
        {
            try
            {
                //Create empty list.
                List<string> emptyListForReset = new List<string>();
                for (int i = 0; i < 7; i++)
                {
                    emptyListForReset.Add("");
                }

                SelectedMeals = emptyListForReset; //Sets selected meals to empty, clearing them.
                MealsHaveBeenSelected = false; //Sets to false so user can create a new meal list.

                SelectedItem = ""; //Clear selected item.
                ResetCommand = new ResetCommand(this);

                Checks checks = new Checks();
                checks.BudgetSet = false; //Set to false so user can enter new budget.

                //Open splash window.
                SplashWindow splashWindow = new SplashWindow();
                CloseAction();
                splashWindow.ShowDialog();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void createNewmealList() //Create a new meal list.
        {
            try
            {
                selectMealsFromDb(); //Creates new meal list.
                AppSettingsGetters getters = new AppSettingsGetters();
                SelectedMeals = getters.SelectedMeals; //Sets the selected meals from the class library to local SelectedMeals.

                _usrChecks.MealsHaveBeenSelected = true; //Sets the meal check to true, this will disable the button.
                CheckIfUserIsHappyWithMeals checkWithUser = new CheckIfUserIsHappyWithMeals();

                //First check if the selected meals costs are within the users' budget.

                if (_getters.CumulativeCost > _budget.UserBudget) //If the total cost of meals is greater than the user budget.
                {
                    createNewmealList();
                }

                if (checkWithUser.askUser() == false) //User isn't happy with the selected meals.
                {
                    createNewmealList();
                    //selectNewMealsAndRefreshWindow();
                }
                else //User likes the selected meals.
                {
                    MealsHaveBeenSelected = true; //Set true so button will be disabled
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void showInfoWindow(string selectedListbox) //Passes selected listbox(ingredients or method) and current selected item
        {                                                  //to the info window and opens it.
            try
            {
                InfoWindow infoWindow = new InfoWindow(selectedListbox, SelectedItem);
                infoWindow.ShowDialog();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        private void selectMealsFromDb() //Selects meals from database in the class library.
        {
            try
            {
                SqliteFunctions databaseFunction = new SqliteFunctions("Meals", "MealInfo");
                databaseFunction.addMealInfoToDatabase(); //Adds all meal info into database (internal to class library).
                databaseFunction.selectDataFromDB(); //Selects meals.
                databaseFunction.disconnectDatabase(); //Disconnects database connection.
            }
            catch(Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

    }
}
