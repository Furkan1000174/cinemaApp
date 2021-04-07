using System;
using System.Collections.Generic;
using System.Text;

namespace cinemaApp
{
    class admin
    {
        public static void adminScreen()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            string a = "/// Welcome admin ///\n";
            Console.SetCursorPosition((Console.WindowWidth - a.Length) / 2, Console.CursorTop);
            Console.WriteLine(a);
            Console.ResetColor();
            Console.WriteLine("Please select what you would like to do\n\n1. Manage movies\n2. Manage catering\n3. Manage reviews\n4. Manage reservations\nPress 6 to go back");
        }
    }
}
