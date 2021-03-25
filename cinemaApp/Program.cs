using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace cinemaApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Welcome screen
            Console.WriteLine("Welcome to the cinema!");
            Console.WriteLine("Please enter what you would like to do: ");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Continue as guest");
            Console.WriteLine("3. Create an account");
            var options = Console.ReadLine();
            if (options == "1")
            {
                loginscherm();
            }
            else if (options == "2")
            {
                Console.WriteLine("Please enter your email");
                var guestMail = Console.ReadLine();
                mainScreen();
            }
            else if (options == "3")
            {
                createAccount();
            }
        }
        private static void createAccount()
        {
            Console.WriteLine("Please enter your account information below..");
            Console.WriteLine("Please enter your username:");
            string username = Console.ReadLine();
            Console.WriteLine("Please enter your password:");
            string password = Console.ReadLine();
            Console.WriteLine("Please enter your email:");
            string email = Console.ReadLine();
        }
        private static void loginscherm()
        {
            Console.WriteLine("Please enter your login info...");
            var logginIn = true;
            while (logginIn)
            {
                Console.WriteLine("Please enter your username: ");
                string enterUsername = Console.ReadLine();
                if (accountchecker(enterUsername) == true)
                {
                    Console.WriteLine("Please enter your password: ");
                    string enterPassword = Console.ReadLine();
                    if (accountchecker(enterPassword) == true)
                    {
                        if(enterUsername == "admin"){
                            if(enterPassword == "123")
                            {
                                adminScreen();
                                break;
                            }
                        }
                        mainScreen();
                        logginIn = false;
                    }
                    else if (accountchecker(enterPassword) != true)
                    {
                        Console.WriteLine("Password is incorrect...");
                    }
                }
                else if (accountchecker(enterUsername) != true)
                {
                    Console.WriteLine("Username is incorrect...");
                }
            }
        }
        private static void mainScreen()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the cinema..\n");
            Console.WriteLine("Please select what you would like to do\n");
            Console.WriteLine("1. View movies");
            Console.WriteLine("2. View reviews");
            Console.WriteLine("3. View catering");
            var options = Console.ReadLine();
            if (options == "1")
            {
                movieScreen();
            }

        }
        private static void adminScreen()
        {
            Console.Clear();
            Console.WriteLine("Welcome administrator\n");
            Console.WriteLine("Please select what you would like to do\n");
            Console.WriteLine("1. Manage movies");
            Console.WriteLine("2. Manage reservations");
            Console.WriteLine("3. Manage catering");
        }

        private static bool accountchecker(string usernameORpassword)
        {
            if (usernameORpassword == "customer" | usernameORpassword == "123")
            {
                return true;
            }
            else if(usernameORpassword == "admin" | usernameORpassword == "123")
            {
                return true;
            }
            return false;
        }
        private static void movieScreen()
        {
            Console.Clear();
            Console.WriteLine("Welcome to our movie selections!");
            Console.WriteLine("We are proud to present the following movies!");
            Console.WriteLine("");
            Console.WriteLine("1. Baba1\n");
            Console.WriteLine("2. Baba2\n");
            Console.WriteLine("3. BabaThePreSquel\n");
            Console.WriteLine("4. The adventures of Baba\n");
            Console.WriteLine("5. Baba\'s bizarre adventures\n");

        }
    }
}