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
            Console.WriteLine("Please enter your creditcard number\n(A credit card consists of 16 digits)");
            while (choosing)
            {
                var creditcard = Console.ReadLine();
                try
                {
                    //checks if all the entered char's are numerial AND if its 16 digits long
                    if (creditcard.All(char.IsDigit) && creditcard.Length == 16){ 
                        Console.WriteLine("\nThank you " + CurrentAccount.UserName + "\nPlease confirm reservation\n1. Yes\n2. No\n");
                        var choice = Console.ReadLine();
                        if (choice == "1")
                        {
                            Console.WriteLine("Generating reservation code:(Please write it down!!)");
                            var random = new Random();
                            var number = random.Next(1000, 9999);
                            System.Threading.Thread.Sleep(2000);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Your reservation code: " + number.ToString());
                            Console.ResetColor();
                            using (StreamWriter sw = File.CreateText(@"cart.json"))
                            {
                                sw.WriteLine("");

                            }
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("Type anything if you want to return to the mainscreen.");
                            Console.ResetColor();
                            string confirmation = Console.ReadLine();
                            if (confirmation.ToLower() == "1")
                            {

                                mainScreen.Show(CurrentAccount);
                            }
                            else
                            {
                                mainScreen.Show(CurrentAccount);
                            }

                        }
                        else if (choice == "2")
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("\nYou will be send back to the mainscreen\n");
                            Console.ResetColor();
                            System.Threading.Thread.Sleep(2000);
                            Console.Clear();
                            mainScreen.Show(CurrentAccount);
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
