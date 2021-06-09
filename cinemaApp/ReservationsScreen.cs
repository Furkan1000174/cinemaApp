using System;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace cinemaApp
{
    class ReservationsScreen
    {
        public static void showRes(Account CurrentAccount)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            string a = "/// Your Reservations," + CurrentAccount.UserName + " ///\n";
            Console.SetCursorPosition((Console.WindowWidth - a.Length) / 2, Console.CursorTop);
            Console.WriteLine(a);
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            string b = "Here are your reservations:\n";
            Console.SetCursorPosition((Console.WindowWidth - b.Length) / 2, Console.CursorTop);
            Console.WriteLine(b);
            Console.ResetColor();
            List<String> jsonContents = new List<String> { };
            double totalPrice = 0;
            try
            {
                foreach (string line in File.ReadLines(@"reservations.json"))
                {
                    jsonContents.Add(line);
                }
                if (jsonContents.Count == 0)
                {
                    Console.WriteLine("\nNo items found!\nPlease create a listing first!\n");
                    System.Threading.Thread.Sleep(3500);
                    Console.Clear();
                    mainScreen.Show(CurrentAccount);
                }
                else
                {
                    var cartList = new List<Reservation> { };
                    foreach (String cartItem in jsonContents)
                    {
                        cartList.Add(JsonConvert.DeserializeObject<Reservation>(cartItem));
                    }
                    foreach (var cart in cartList)
                    {
                        if (CurrentAccount.ID == cart.ID)
                        {
                            Console.OutputEncoding = Encoding.UTF8;
                            Console.WriteLine(cart);
                            totalPrice = totalPrice + cart.Price;
                        }

                    }
                }
                Console.OutputEncoding = Encoding.UTF8;
                Console.WriteLine("The total price of the items you ordered is: €" + totalPrice + "\n");
                System.Threading.Thread.Sleep(5000);
                mainScreen.Show(CurrentAccount);
            }
            //Als er niks is gevonden
            catch (FileNotFoundException)
            {
                Console.WriteLine("\nNo cart information found!\nPlease add a item to your cart first!\n");
                System.Threading.Thread.Sleep(3500);
                Console.Clear();
                mainScreen.Show(CurrentAccount);
            }
        }
    }
}
