using System;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace cinemaApp
{
    class checkout
    {
        public static void checkoutScreen(Account CurrentAccount)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            string a = "/// Your Personal Cart," + CurrentAccount.UserName + " ///\n";
            Console.SetCursorPosition((Console.WindowWidth - a.Length) / 2, Console.CursorTop);
            Console.WriteLine(a);
            Console.ResetColor();
            var choosing = true;
            Console.WriteLine("Please enter your creditcard number: ");
            while (choosing)
            {
                var creditcard = Console.ReadLine();
                try
                {
                    var creditcard1 = Int32.Parse(creditcard.Substring(0,4));
                    var creditcard2 = Int32.Parse(creditcard.Substring(4, 4));
                    var creditcard3 = Int32.Parse(creditcard.Substring(8, 4));
                    var creditcard4 = Int32.Parse(creditcard.Substring(12, 4));
                    if (creditcard1.ToString().Length == 4 && creditcard2.ToString().Length == 4 && creditcard3.ToString().Length == 4 && creditcard4.ToString().Length == 4)
                    {
                        Console.WriteLine("Thank you " + CurrentAccount.UserName + "\nPlease confirm reservation\n1. Yes\n2. No");
                        var choice = Console.ReadLine();
                        if (choice == "1")
                        {
                            Console.WriteLine("Generating reservation code:");
                            var random = new Random();
                            var number = random.Next(1000, 9999);
                            System.Threading.Thread.Sleep(2000);
                            Console.WriteLine("Your reservation code: " + number.ToString());
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid creditcard number");
                    }
                    
                }
                catch
                {
                    Console.WriteLine("Please enter a valid creditcard number");
                }

            }
        }
        
        
    }
}
