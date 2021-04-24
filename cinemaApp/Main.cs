
using System;
using System.Collections;
using System.Collections.Generic;

namespace cinemaApp
{
    class Program
    {
        public static void Main()
        {
            var choosing = true;
            //Welcome screen
            while (choosing)
            {
                Console.WriteLine("Welcome to Pathé Movie Theatre!\n What would you like to do? \n1. Login \n2. Create Account\n3. Continue as guest\n");
                string options = Console.ReadLine();
                try
                {
                    int number = Int32.Parse(options);
                    switch (number)
                    {
                        case 1:
                            loginScreen.Login();
                            choosing = false;
                            break;
                        case 2:
                            createAccountScreen.Create();
                            choosing = false;
                            break;
                        case 3:
                            string name = "guest";
                            mainScreen.Show(name);
                            choosing = false;
                            break;
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



