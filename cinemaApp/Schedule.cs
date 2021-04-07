using System;
using System.Collections.Generic;
using System.Text;

namespace cinemaApp
{
    class Schedule
    {


    public static void showSchedule()
    {
        Console.Clear();
        Console.WriteLine("Minari:\n 19:00 | 21:00 | 23:00 | 01:00 | 03:00\n");
        Console.WriteLine("Sound of metal:\n 18:30 | 20:30 | 22:30 | 00:30 | 02:00\n");
        Console.WriteLine("Normadland:\n 18:00 | 22:00 | 22:30 | 01:00 | 02:00\n");
        Console.WriteLine("Another round:\n 13:00| 15:30 | 19:00 | 21:00 | 23:00 | 03:00 |\n");
        Console.WriteLine("The Father:\n 12:45 | 15:00 | 19:00 | 21:00 | 23:00\n");




        Console.WriteLine("Do you want to go to the film selection screeen? y/n: ");

        string confirmation = Console.ReadLine();
        if (confirmation.ToLower() == "y")
        {

            MovieInfoScreen.showMovies();
        }
        else if (confirmation.ToLower() == "n")
        {
            mainScreen.Show(Program.CurrentAccount);
        }
        else
        {
            showSchedule();
        }

    }
    }
}
