using System;
using System.Collections.Generic;

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
                loginScreen();
            }
            else if (options == "2")
            {
                Console.WriteLine("Please enter your email");
                var guestMail = Console.ReadLine();
                mainScreen();
            }
        }
       
        private static void loginScreen() {
            Console.WriteLine("Please enter your login info...");
            var logginIn = true;
            while (logginIn) {
            Console.WriteLine("Please enter your username: ");
            string enteredUsername = Console.ReadLine();
            Console.WriteLine("Please enter your password: ");
            string enteredPassword = Console.ReadLine();
                if (accountchecker(enteredUsername, enteredPassword) == true) {
                    if(enteredUsername == "admin"){
                        if(enteredPassword == "adminPass") {
                            adminScreen();
                            break;
                        }
                    }
                    else if (enteredUsername != "admin") {
                        mainScreen();
                        logginIn = false;
                    }
                        
                }
                else if (accountchecker(enteredUsername, enteredPassword) == false) {
                    Console.WriteLine("pass or username is incorrect...");
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

        
        
        private static bool accountchecker(string enteredUsername, string enteredPassword) {
            IDictionary<string, string> accountDict = new Dictionary<string, string> { { "account1", "password1" }, { "account2", "password2" } };
            accountDict.Add("admin", "adminPass"); //just testing if adding accounts works

            if (accountDict.ContainsKey(enteredUsername)) {
                if (accountDict[enteredUsername] == enteredPassword)
                    return true;
            }
            
            return false;
        }
    }
}