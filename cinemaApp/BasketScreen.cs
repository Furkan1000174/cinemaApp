using System;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace cinemaApp
{
    class BasketScreen
    {
        public static void showBasket(Account CurrentAccount)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            string a = "/// Basket ///\n";
            Console.SetCursorPosition((Console.WindowWidth - a.Length) / 2, Console.CursorTop);
            Console.WriteLine(a);
            Console.ResetColor();
            int counter = 1;

                         //FIlm 
            List<String> jsonContents = new List<String> { };
            try
            {
                foreach (string line in File.ReadLines(@"movies.json")) 
                {
                    jsonContents.Add(line);
                }
                var movieList = new List<Movie> { };
                foreach (String movie in jsonContents)
                {
                    movieList.Add(JsonConvert.DeserializeObject<Movie>(movie));
                }
                foreach (var movie in movieList)
                {
                    Console.Write("[" + counter + "]");
                    counter++;
                    Console.WriteLine(movie);
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("\nNo movies found!\n");
            }

                        //FOOD SECTION
            try
            {
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
                    Console.Write("[" + counter + "]");
                    counter++;
                    Console.WriteLine(cate);
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("\nNo food reservations found!\n");
            }




            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            string b = "These are the items in your Basket, you'll return to the mainscreen shortly\n";
            Console.SetCursorPosition((Console.WindowWidth - b.Length) / 2, Console.CursorTop);
            Console.WriteLine(b);
            Console.ResetColor();
            System.Threading.Thread.Sleep(4500);
            Console.Clear();
            mainScreen.Show(CurrentAccount);
        }
    }


}

