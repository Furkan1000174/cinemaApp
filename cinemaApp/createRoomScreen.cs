using System;
using System.Collections.Generic;
using System.Text;

namespace cinemaApp
{
    class createRoomScreen
    {
        public static void RoomCreate(Account CurrentAccount)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            string a = "/// Room creation ///\n";
            Console.SetCursorPosition((Console.WindowWidth - a.Length) / 2, Console.CursorTop);
            Console.WriteLine(a);
            Console.ResetColor();
            Console.WriteLine("Please enter the amount of rows for your room\n(Please enter just an integer)");
            string rowInput = Console.ReadLine();
            int roomRows;
            bool correctRows = int.TryParse(rowInput, out roomRows);
            while (!correctRows)
            {
                Console.WriteLine("That was not a correct input for rows, please try again");
                Console.WriteLine("Please enter the amount of rows for your room\n(Please enter just an integer)");
                rowInput = Console.ReadLine();
                correctRows = int.TryParse(rowInput, out roomRows);
            }
            Console.WriteLine("Please enter the amount of seats for your room\n(Please enter just an integer)");
            string seatInput = Console.ReadLine();
            int roomSeats;
            bool correctSeats = int.TryParse(seatInput, out roomSeats);
            while (!correctSeats)
            {
                Console.WriteLine("That was not a correct input for seats, please try again");
                Console.WriteLine("Please enter the amount of seats for your row\n(Please enter just an integer)");
                seatInput = Console.ReadLine();
                correctSeats = int.TryParse(seatInput, out roomSeats);
            }
            int[] exclude = new int[roomRows];
            for (int i = 0; i<roomRows;i++)
            {
                Random rnd = new Random();
                try
                {
                    exclude[i] = rnd.Next(0, 8);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }

            }
            try
            {
                movieRooms.createRoom(roomSeats, roomRows, exclude);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            Console.WriteLine("The Room has been added!");
            Console.WriteLine("\n\nYou will be send back to the mainscreen\n");
            System.Threading.Thread.Sleep(2500);
            mainScreen.Show(CurrentAccount);
        }
    }
}
