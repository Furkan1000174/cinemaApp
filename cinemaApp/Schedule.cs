using System;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace cinemaApp
{
    class Schedule
    {


    public static void showSchedule(Account CurrentAccount)
    {       
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            string a = "/// FILM SELECTION ///\n";
            Console.SetCursorPosition((Console.WindowWidth - a.Length) / 2, Console.CursorTop);
            Console.WriteLine(a);
            Console.ResetColor();
            List<String> jsonContents = new List<String> { };
            try
            {
                foreach (string line in File.ReadLines(@"schedules.json"))
                {
                    jsonContents.Add(line);
                }
                if (jsonContents.Count == 0)
                {
                    Console.WriteLine("\nNo Schedule found!\nPlease create a listing first!\n");
                    System.Threading.Thread.Sleep(3500);
                    Console.Clear();
                    mainScreen.Show(CurrentAccount);
                }
                var scheduleList = new List<ScheduleClass> { };
                foreach (String schedule in jsonContents)
                {
                    scheduleList.Add(JsonConvert.DeserializeObject<ScheduleClass>(schedule));
                }
                foreach (var schedule in scheduleList)
                {
                    Console.WriteLine(schedule);
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("\nNo movie information found!\nPlease add some movies first!\n");
                System.Threading.Thread.Sleep(3500);
                Console.Clear();
                mainScreen.Show(CurrentAccount);
            }


            Console.WriteLine("Do you want to go to the film selection screen? y/n: ");

        string confirmation = Console.ReadLine();
        if (confirmation.ToLower() == "y")
        {

            MovieInfoScreen.showMovies(CurrentAccount);
        }
        else if (confirmation.ToLower() == "n")
        {
            mainScreen.Show(CurrentAccount);
        }
        else
        {
            showSchedule(CurrentAccount);
        }

    }
    }
}
