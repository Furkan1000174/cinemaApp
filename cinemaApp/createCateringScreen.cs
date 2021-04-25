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
        public static void CateringCreate()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            string a = "/// Catering creation ///\n";
            Console.SetCursorPosition((Console.WindowWidth - a.Length) / 2, Console.CursorTop);
            Console.WriteLine(a);
            Console.ResetColor();
            Console.WriteLine("Please enter the food item:");
            string foodItem = Console.ReadLine();
            Console.WriteLine("Please enter the drink item:");
            string drinkItem = Console.ReadLine();
            Console.WriteLine("Please enter the menu size (Small/Medium/Large:");
            string menuSize = Console.ReadLine();
            Console.WriteLine("Please enter the overall price:");
            string menuPrice = Console.ReadLine();

            CateringJSN newCateringJSN = new CateringJSN()
            {
                food = foodItem,
                drink = drinkItem,
                size = menuSize,
                price = menuPrice
            };

            string strNewCateringJSN = JsonConvert.SerializeObject(newCateringJSN);
            using (StreamWriter sw = File.AppendText(@"catering.json"))
            {
                sw.WriteLine(strNewCateringJSN);
                sw.Close();
            }
            Console.WriteLine("Menu added!");

            mainScreen.Show(Program.CurrentAccount);
        }
    }
}
