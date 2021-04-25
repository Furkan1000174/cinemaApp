using System;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace cinemaApp
{
    class review
    {
        public static string movieReview()
        {
            return null;
        }
        public static void reviewScreen()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            string a = "/// REVIEWS ///\n";
            Console.SetCursorPosition((Console.WindowWidth - a.Length) / 2, Console.CursorTop);
            Console.WriteLine(a);
            Console.ResetColor();
            while (true)
            {
                Console.WriteLine("Please select which review you would like to see\n\n1. Minari\n2.Sound of Metal\n3.Nomadland\n4.Another round\n5.The Father");
                string options = Console.ReadLine();
                try
                {
                    int number = Int32.Parse(options);
                    switch (number)
                    {
                        case 1:
                            //Should show first review
                            //loginScreen.Login();
                            break;
                        case 2:
                            //createAccountScreen.Create();
                            //break;
                        case 3:
                            //mainScreen.Show();
                            //break;
                        default:
                            Console.WriteLine("The input you gave is incorrect.\n Please try a number that is shown on screen.");
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("The input you gave is incorrect.\n Please try a number that is shown on screen.");
                }
            }
        }
    }
}
