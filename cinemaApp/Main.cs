
using System;
using System.Collections;
using System.Collections.Generic;

namespace cinemaApp
{
    class Program
    {
        public static Account CurrentAccount = new Account()
        {
            ID = "",
            username = "",
            password = ""
        };
        public static void Main()
        {
            CurrentAccount.ID = "";
            CurrentAccount.username = "";
            CurrentAccount.password = "";
            //Welcome screen
            while (true)
            {
                Console.WriteLine("Welcome to  Movie Theatre!\n What would you like to do? \n1. Login \n2. Create Account\n3. Continue as guest\n");
                string options = Console.ReadLine();
                try
                {
                    int number = Int32.Parse(options);
                    switch (number)
                    {
                        case 1:
                            loginScreen.Login(CurrentAccount);
                            break;
                        case 2:
                            createAccountScreen.Create();
                            break;
                        case 3:
                            mainScreen.Show(CurrentAccount);
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



