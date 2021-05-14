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
            while (string.IsNullOrEmpty(foodItem))
            {
                Console.WriteLine("The food item can't be empty, please try again.");
                foodItem = Console.ReadLine();
            }
            Console.WriteLine("Please enter the drink item:");
            string drinkItem = Console.ReadLine();
            while (string.IsNullOrEmpty(drinkItem))
            {
                Console.WriteLine("The drink item can't be empty, please try again.");
                drinkItem = Console.ReadLine();
            }
            Console.WriteLine("Please enter the menu size (Small/Medium/Large:");
            string menuSize = Console.ReadLine();
            while (string.IsNullOrEmpty(menuSize))
            {
                Console.WriteLine("The menu Size can't be empty, please try again.");
                menuSize = Console.ReadLine();
            }
            Console.WriteLine("Please enter the overall price:");
            string menuPrice = Console.ReadLine();
            while (string.IsNullOrEmpty(menuPrice))
            {
                Console.WriteLine("The menu price can't be empty, please try again.");
                menuPrice = Console.ReadLine();
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
