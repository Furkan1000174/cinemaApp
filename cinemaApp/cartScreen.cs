using System;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace cinemaApp
{
    class cartScreen
    {

        public static void showCart(Account CurrentAccount)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            string a = "/// Your Personal Cart," + CurrentAccount.UserName + " ///\n";
            Console.SetCursorPosition((Console.WindowWidth - a.Length) / 2, Console.CursorTop);
            Console.WriteLine(a);
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            string b = "Here are the items you have ordered:\n";
            Console.SetCursorPosition((Console.WindowWidth - b.Length) / 2, Console.CursorTop);
            Console.WriteLine(b);
            Console.ResetColor();
            bool choosing = true;
            List<String> jsonContents = new List<String> { };
            double totalPrice = 0;
            //Haalt alle cart items op
            try
            {
                foreach (string line in File.ReadLines(@"cart.json"))
                {
                    jsonContents.Add(line);
                }
                if (jsonContents.Count == 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("\nThere are no items in your basket, you will be send back to the mainscreen\n");
                    Console.ResetColor();
                    System.Threading.Thread.Sleep(5000);
                    Console.Clear();
                    mainScreen.Show(CurrentAccount);
                }
                var cartList = new List<Cart> { };
                foreach (String cartItem in jsonContents)
                {
                    cartList.Add(JsonConvert.DeserializeObject<Cart>(cartItem));
                }
                //Laat alleen de Cart items zien van de ingelogde gebruiker
               

                foreach (var cart in cartList)
                {
                    if(CurrentAccount.ID == cart.ID)
                    {
                        Console.OutputEncoding = Encoding.UTF8;
                        Console.WriteLine(cart);
                        totalPrice = totalPrice + cart.Price;
                    }
                   
                }
                Console.OutputEncoding = Encoding.UTF8;
                Console.WriteLine("The total price of the items you ordered is: €" + totalPrice + "\n");
            }
            //Als er niks is gevonden
            catch (FileNotFoundException)
            {
                Console.WriteLine("\nNo cart information found!\nPlease add a item to your cart first!\n");
                System.Threading.Thread.Sleep(3500);
                Console.Clear();
                mainScreen.Show(CurrentAccount);
            }


            while (choosing)
            {
                Console.WriteLine("What would you like to do?\n1. Order more\n2. Check out\n3. Return to main menu\n");
                string choice = Console.ReadLine();
                try
                {

               
                    int number = Int32.Parse(choice);
                    switch (number)
                    {
                        case 1:
                        CateringScreen.showCatering(CurrentAccount);
                        break;

                        case 2:
                            checkout.checkoutScreen(CurrentAccount);

                            break;

                        case 3:
                        mainScreen.Show(CurrentAccount);
                        break;
                    }
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The input you gave is incorrect.\nPlease try a number that is shown on screen.");
                    Console.ResetColor();
                    System.Threading.Thread.Sleep(2500);
                    cartScreen.showCart(CurrentAccount);
                }

            }


        }







    }
}
