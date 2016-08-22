using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Meal_App.Properties;
using Meal_App.User_Info_Models;
using System.IO;
using System.Windows;
using System.ComponentModel;

namespace Meal_App.Information_Window.Logic_Classes
{
    internal class ReadFromFile : INotifyPropertyChanged
    {
        //Reads from text file either the method to make the meal or the ingredients.
        public ReadFromFile(string selectedItem, string selectedListbox)
        {
            _selectedItem = selectedItem;
            _selectedListbox = selectedListbox;
        }

        private string _selectedItem, _selectedListbox;
        private SelectedMealsContent _selectedMealsContent = new SelectedMealsContent();

        public List<String> readFromTextFile()
        {
            string fileName;
            List<string> ingredients = new List<string>();

            if (_selectedListbox == "ingredients") //Passed through, if the listbox is ingredients, we need to read the ingredients text file.
            {
                fileName = _selectedItem + " 1"; //add 1 onto the end so we can get the full file name to read from (1 being ing and 2 being met)
            }
            else
            {
                fileName = _selectedItem + " 2";
            }

            TextReader text = new StreamReader("Meals\\" + fileName + ".txt");
            string currentLine;

            while ((currentLine = text.ReadLine()) != null) //while there is still text in the text file
            {
                if (currentLine == "")
                    continue;
                else
                    ingredients.Add(currentLine);
            }

            text.Close();

            return ingredients;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
