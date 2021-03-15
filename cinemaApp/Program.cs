using System;

namespace cinemaApp
{
    class Program
    {
        public static void Main()
        {
            Console.WriteLine("Welcome to the cinema!");
            Console.WriteLine("Please enter what you would like to do: ");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Continue as guest");
            Console.WriteLine("3. View movies");
            var options = Console.ReadLine();
        }
    }
}
