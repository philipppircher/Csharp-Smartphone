using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartphoneConsole
{
    internal class SmartPhone
    {
        public List<BaseApp> AppsList;

        public SmartPhone()
        {
            AppsList = new List<BaseApp>();
            AppsList.Add(new App("Corona App", 75.0, "Corona News and Facts"));
            AppsList.Add(new App("Weight Watchers", 125.44, "Gewicht abnehmen ganz einfach"));
            AppsList.Add(
                new Game("Super Mario Bros.", 301.60, "SMB the mobile game", Game.Rating.Everyone, Game.Genre.Platformer));
            AppsList.Add(
               new Game("Festers Quest", 288.12, "Addams Family Game", Game.Rating.Teen, Game.Genre.Top_Down));
        }

        public void StartMenu()
        {
            SmartPhone mySmartPhone = new SmartPhone();

            do
            {
                string input = "";

                PrintMenu();

                if (CheckValidInput(input = Console.ReadLine()))
                {
                    ExecuteOperation(input);
                }
                else
                {
                    Console.WriteLine("Ungültige Eingabe!");
                }
            } while (true);
        }

        private bool IsValidCommand(string userInput)
        {
            bool isValidCommand = false;

            if (userInput.Contains("Start:") || userInput.Contains("Filter"))
            {
                isValidCommand = true;
            }
            return isValidCommand;
        }

        private bool IsValidName(string userInput)
        {
            bool isValidName = false;

            if (userInput.Contains("<") && userInput.Contains(">"))
            {
                isValidName = true;
            }

            return isValidName;
        }

        private bool CheckValidInput(string userInput)
        {
            bool isValid = false;

            if (IsValidCommand(userInput) && IsValidName(userInput))
            {
                isValid = true;
            }

            return isValid;
        }

        private void ExecuteOperation(string input)
        {
            string name = GetNameOfInput(input);

            if (input.Contains("Start:"))
            {
                ExecuteStart(name);
            } 
            else if(input.Contains("Filter:"))
            {
                ExecuteFilter(name);
            }
        }

        private void ExecuteStart(string name)
        {
            BaseApp app = GetApp(name);

            if (app != null)
            {
                Console.WriteLine(app.Start());
            }
            else
            {
                Console.WriteLine("App oder Spiel ist nicht vorhanden");
            }
        }
        
        private void ExecuteFilter(string name)
        {

            if (name == "App")
            {
                var selectedApps = AppsList.OfType<App>().ToList();
                foreach (var item in selectedApps)
                {
                    Console.WriteLine(item.Name);
                }
            }
            else if (name == "Game")
            {
                var selectedApps = AppsList.OfType<Game>().ToList();
                foreach (var item in selectedApps)
                {
                    Console.WriteLine(item.Name);
                }
            }
            Console.WriteLine();
        }

        private BaseApp GetApp(string name)
        {
            BaseApp selectedApp = null;

            foreach (BaseApp app in AppsList)
            {
                if(app.Name == name)
                {
                    selectedApp = app;
                    break;
                }
                
            }
            return selectedApp;
        }

        private string GetNameOfInput(string input)
        {
            string name = "";

            int indexStart = input.IndexOf('<');
            int indexEnd = input.IndexOf('>');
            int indexBetween = indexEnd - indexStart + 1;
            name = input.Substring(indexStart, indexBetween);

            name = name.TrimStart('<');
            name = name.TrimEnd('>');

            return name;
        }
       

        private void PrintMenu()
        {
            Console.WriteLine("App/Game Menu\n" +
                "to Start App/Game enter this command:\n" +
                "Start: <appname/gamename>\n" +
                "to Print App/Game List enter this command:\n" +
                "Filter: <App/Game>" +
                "Your Input:\n");
        }
    }
}
