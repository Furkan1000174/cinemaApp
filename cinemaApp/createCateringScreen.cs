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
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            string a = "/// Catering creation ///\n";
            Console.SetCursorPosition((Console.WindowWidth - a.Length) / 2, Console.CursorTop);
            Console.WriteLine(a);
            Console.ResetColor();
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
            menuPrice = Math.Truncate(menuPrice* 100)/100;
            while(!correctInput)
            {
                Console.WriteLine("That was not a correct input for Price, please try again");
                Console.WriteLine("Please enter the overall price:\n(Please use a comma for decimals)");
                priceInput = Console.ReadLine();
                correctInput = double.TryParse(priceInput, out menuPrice);
                menuPrice = Math.Truncate(menuPrice*100)/100;
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
    }
}
