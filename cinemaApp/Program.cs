using System;

namespace cinemaApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the cinema!");
            Console.WriteLine("Please enter what you would like to do: ");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Continue as guest");
            Console.WriteLine("3. View movies");
            var options = Console.ReadLine();
            if (options == "1")
            {
                loginscherm();
            }
        }
        private static void loginscherm()
        {
            Console.WriteLine("Please enter your login info...");
            Console.WriteLine("Please enter your username: ");
            string enterUsername = Console.ReadLine();
            if (accountchecker(enterUsername) != true)
            {
                Console.WriteLine("User not found");
            }
            Console.WriteLine("Please enter your password: ");
            string enterPassword = Console.ReadLine();
            if (accountchecker(enterPassword) != true)
            {
                Console.WriteLine("Password is incorrect");
            }
        }
        private static bool accountchecker(string usernameORpassword)
        {
            if(usernameORpassword == "baba" | usernameORpassword == "123")
            {
                return true;
            }
            return false;
        }
    
    
    }
}
