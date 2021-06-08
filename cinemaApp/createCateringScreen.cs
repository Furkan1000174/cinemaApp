using System;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace cinemaApp
{
    class createCateringScreen
    {
        public static void CateringCreate(Account CurrentAccount)
        {
            int id = 1;
            try
            {
                List<String> jsonContents = new List<String> { };
                foreach (string line in File.ReadLines(@"catering.json"))
                {
                    jsonContents.Add(line);
                }
                var cateList = new List<CateringJSN> { };
                foreach (String cate in jsonContents)
                {
                    cateList.Add(JsonConvert.DeserializeObject<CateringJSN>(cate));
                }
                foreach (var cate in cateList)
                {
                    if (cate.ID >= id)
                    {
                        id = cate.ID + 1;
                    }
                }
            }
            catch (FileNotFoundException)
            {

            }
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            string a = "/// Catering creation ///\n";
            Console.SetCursorPosition((Console.WindowWidth - a.Length) / 2, Console.CursorTop);
            Console.WriteLine(a);
            Console.ResetColor();
            Console.WriteLine("Please enter what you would like to do\n\n[1] Add catering\n[2] Remove catering\n[3] Back to menu");
            bool choosing = true;
            while (choosing)
            {
                string options = Console.ReadLine();
                try
                {
                    int number = Int32.Parse(options);
                    switch (number)
                    {
                        case 1:
                            choosing = false;
                            break;
                        case 2:
                            removeCatering(CurrentAccount);
                            choosing = false;
                            break;
                        case 3:
                            mainScreen.Show(CurrentAccount);
                            choosing = false;
                            break;
                        default:
                            choosing = false;
                            Console.WriteLine("The input you gave is incorrect.\n Please try a number that is shown on screen.");
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("The input you gave is incorrect.\n Please try a number that is shown on screen.");
                }
            }
            Console.WriteLine("Please enter the food item:");
            string foodItem = Console.ReadLine();
            //Hier blijft het doorzeuren tot er wel iets is ingevoerd, geen lege data meer
            while (string.IsNullOrEmpty(foodItem))
            {
                Console.WriteLine("The food item can't be empty, please try again.");
                Console.WriteLine("Please enter the food item:");
                foodItem = Console.ReadLine();
            }
            Console.WriteLine("Please enter the drink item:");
            string drinkItem = Console.ReadLine();
            while (string.IsNullOrEmpty(drinkItem))
            {
                Console.WriteLine("The drink item can't be empty, please try again.");
                Console.WriteLine("Please enter the drink item:");
                drinkItem = Console.ReadLine();
            }

            Console.WriteLine("Please enter the menu size (Small/Medium/Large):\nKeep in mind that the menu sizes are Case sensitive, so don't forget the captial letter.");
            string menuSize = Console.ReadLine();
            string[] sizes = { "Small", "Medium", "Large" };
            bool correctSize = sizes.Contains(menuSize);
            while (!correctSize)
            {
                Console.WriteLine("That was an incorrect menu size, please try again.");
                Console.WriteLine("Please enter the menu size (Small/Medium/Large):\nKeep in mind that the menu sizes are Case sensitive, so don't forget the captial letter.");
                menuSize = Console.ReadLine();
                correctSize = sizes.Contains(menuSize);
            }
            Console.WriteLine("Please enter the overall price:\n(Please use a comma for decimals)");
            string priceInput = Console.ReadLine();
            double menuPrice;
            bool correctInput = double.TryParse(priceInput, out menuPrice);
            menuPrice = Math.Truncate(menuPrice * 100) / 100;
            while (!correctInput)
            {
                Console.WriteLine("That was not a correct input for Price, please try again");
                Console.WriteLine("Please enter the overall price:\n(Please use a comma for decimals)");
                priceInput = Console.ReadLine();
                correctInput = double.TryParse(priceInput, out menuPrice);
                menuPrice = Math.Truncate(menuPrice * 100) / 100;
            }

            CateringJSN newCateringJSN = new CateringJSN(id, foodItem, drinkItem, menuSize, menuPrice);

            string strNewCateringJSN = JsonConvert.SerializeObject(newCateringJSN);
            using (StreamWriter sw = File.AppendText(@"catering.json"))
            {
                sw.WriteLine(strNewCateringJSN);
                sw.Close();
            }
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\n\nMenu added! You will be send back to the mainscreen\n");
            System.Threading.Thread.Sleep(2500);
            Console.ResetColor();

            mainScreen.Show(CurrentAccount);
        }
        public static void removeCatering(Account CurrentAccount)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            string a = "/// Remove catering ///\n";
            Console.SetCursorPosition((Console.WindowWidth - a.Length) / 2, Console.CursorTop);
            Console.WriteLine(a);
            Console.ResetColor();
            List<String> jsonContents = new List<String> { };
            try
            {
                foreach (string line in File.ReadLines(@"catering.json")) //Creates a list with every object from json file
                {
                    jsonContents.Add(line);
                }
                if (jsonContents.Count == 0)
                {
                    Console.WriteLine("\nNo catering found!\nPlease create a listing first!\n");
                    System.Threading.Thread.Sleep(3500);
                    Console.Clear();
                    mainScreen.Show(CurrentAccount);
                }
                else
                {
                    var cateringList = new List<CateringJSN> { };
                    foreach (String catering in jsonContents)
                    {
                        cateringList.Add(JsonConvert.DeserializeObject<CateringJSN>(catering));
                    }
                    foreach (var cater in cateringList)
                    {
                        Console.WriteLine(cater);
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("\nNo catering found!\nPlease create a listing first!\n");
                System.Threading.Thread.Sleep(3500);
                Console.Clear();
                mainScreen.Show(CurrentAccount);
            }
            Console.WriteLine("\nPlease enter the food name of the item you would like to remove\n");
            var options = Console.ReadLine();
            List<String> jsonContents2 = new List<String> { };
            try
            {
                foreach (string line in File.ReadLines(@"catering.json"))
                {

                    if (line.Contains(options))
                    {

                    }
                    else
                    {
                        jsonContents2.Add(line);
                    }
                }
                var cateringList = new List<CateringJSN> { };
                foreach (string catering in jsonContents2)
                {
                    cateringList.Add(JsonConvert.DeserializeObject<CateringJSN>(catering));
                }
                if (jsonContents2.Count == 0)
                {
                    using (StreamWriter sw = File.CreateText(@"catering.json"))
                    {

                        sw.Close();
                        Console.WriteLine($"\n{options} has been removed");
                        System.Threading.Thread.Sleep(3000);
                        mainScreen.Show(CurrentAccount);
                    }
                }
                else
                    using (StreamWriter sw = File.CreateText(@"catering.json"))
                    {
                        sw.Close();
                    }
                {
                    foreach (var catering in cateringList)
                    {
                        string strNewMovieJson = JsonConvert.SerializeObject(catering);
                        using (StreamWriter sw = File.AppendText(@"catering.json"))
                        {
                            sw.WriteLine(strNewMovieJson);
                            sw.Close();
                        }
                    }
                }
                Console.WriteLine($"\n{options} has been removed");
                System.Threading.Thread.Sleep(3000);
                //Figure out how to convert jsonContents2 to a movie format to add to json
                mainScreen.Show(CurrentAccount);
            }
            catch
            {

            }
        }
    }
}
