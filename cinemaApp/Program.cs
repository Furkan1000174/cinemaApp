using System;

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
            Console.Write("Please select what you would like to do\n");
            Console.Write("1. View movies\n");
            Console.Write("2. View reviews\n");
            Console.Write("3. View catering");

        }
        private static void adminScreen()
        {
            Console.Clear();
            Console.WriteLine("Welcome administrator\n");
            Console.WriteLine("Please select what you would like to do\n");
            Console.WriteLine("1. Manage movies\n");
            Console.WriteLine("2. Manage reservations\n");
            Console.WriteLine("3. Manage catering");
        }

        private static bool accountchecker(string usernameORpassword)
        {
            if (usernameORpassword == "admin" | usernameORpassword == "123")
            {
                return true;
            }
            return false;
        }
    }
}