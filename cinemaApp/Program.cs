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
            Console.WriteLine("4. Check Schedule");
            Console.WriteLine("5. Log Out");

            var options = Console.ReadLine();
            switch(options)
            {
                case "1":
                   // viewMovies();
                    break;
                case "2":
                  //  viewReviews();
                    break;
                case "3":
                  //  viewCatering();
                    break;
                case "4":
                  //  checkSchedule();
                    break;
                case "5":
                    exit();
                    break;
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
            Console.WriteLine("4. Check Schedule");
            Console.WriteLine("5. Log Out");
             
            var options = Console.ReadLine();
            switch(options)
            {
                case "1":
                   // manageMovies();
                    break;
                case "2":
                   // manageReservations();
                    break;
                case "3":
                  //  manageCatering();
                    break;
                case "4":
                   // checkSchedule();
                    break;
                case "5":
                    exit();
                    break;
            }
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

        private static void exit()
        {
            Console.WriteLine("Press enter to continue");
            string test = Console.ReadLine();
        }
    }
}