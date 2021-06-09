using System;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;


namespace cinemaApp
{
    class createScheduleScreen
    {
        public static void createSchedule(Account CurrentAccount)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            string a = "/// SCHEDULE CREATION ///\n";
            Console.SetCursorPosition((Console.WindowWidth - a.Length) / 2, Console.CursorTop);
            Console.WriteLine(a);
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            string b = "Here are all the movies:\n";
            Console.SetCursorPosition((Console.WindowWidth - b.Length) / 2, Console.CursorTop);
            Console.WriteLine(b);
            Console.ResetColor();
            bool choosing = true;
            List<String> jsonContents = new List<String> { };
            try
            {
                foreach (string line in File.ReadLines(@"movies.json"))
                {
                    jsonContents.Add(line);
                }
                if (jsonContents.Count == 0)
                {
                    Console.WriteLine("\nNo movies found!\nPlease create a listing first!\n");
                    System.Threading.Thread.Sleep(3500);
                    Console.Clear();
                    mainScreen.Show(CurrentAccount);
                }
                var movieList = new List<Movie> { };
                foreach (String movie in jsonContents)
                {
                    movieList.Add(JsonConvert.DeserializeObject<Movie>(movie));
                }
                foreach (var movie in movieList)
                {
                    Console.WriteLine(movie);
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("\nNo movie information found!\nPlease add some movies first!\n");
                System.Threading.Thread.Sleep(3500);
                Console.Clear();
                mainScreen.Show(CurrentAccount);
            }
            Console.WriteLine("Would you like to add a schedule?\n[1] Yes\n[2]Return to main menu");
            string options = Console.ReadLine();
            try
            {
                int number = Int32.Parse(options);
                switch (number)
                {
                    case 1:

                        try
                        {
                            while (choosing)
                            {
                                Console.WriteLine("\nPlease enter the movie number\n");
                                string choice = Console.ReadLine();
                                int result = Int32.Parse(choice);


                                var movieList = new List<Movie> { };
                                foreach (String movie in jsonContents)
                                {
                                    movieList.Add(JsonConvert.DeserializeObject<Movie>(movie));
                                }
                                foreach (var movie in movieList)
                                {
                                    if (movie.ID == result)
                                    {
                                        Console.WriteLine("\nPlease enter 5 schedule times(Type any time like so: 00:00. Press Enter to add it.");
                                        string[] times = new string[5];
                                        for (int i = 0; i < times.Length; i++)
                                        {
                                            times[i] = Console.ReadLine();
                                            while (string.IsNullOrEmpty(times[i]))
                                            {
                                                Console.WriteLine("The schedule time can't be empty, please try again.");
                                                Console.WriteLine("Please enter some schedule times(Type any time like so: 00:00. Press Enter to add it.");
                                                times[i] = Console.ReadLine();
                                            }

                                        }
                                        ScheduleClass newSchedule = new ScheduleClass(movie.Title, times);
                                        string strNewCartJSON = JsonConvert.SerializeObject(newSchedule);
                                        using (StreamWriter sw = File.AppendText(@"schedules.json"))
                                        {
                                            sw.WriteLine(strNewCartJSON);
                                            sw.Close();
                                        }
                                        choosing = false;
                                        Console.ForegroundColor = ConsoleColor.DarkMagenta;

                                        Console.WriteLine("\nYour Schedule has been added! You will be taken back to the Main Screen now.");
                                        System.Threading.Thread.Sleep(5000);
                                        Console.ResetColor();
                                        Console.Clear();
                                        mainScreen.Show(CurrentAccount);
                                        break;
                                    }
                                }


                            }
                        }
                        catch
                        {
                            Console.WriteLine("There is no Movie item with that index, please try again.");
                        }
                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("\nYou will be send back to the mainscreen\n");
                        Console.ResetColor();
                        System.Threading.Thread.Sleep(2000);
                        Console.Clear();
                        mainScreen.Show(CurrentAccount);
                        break;
                    default:
                        Console.WriteLine("The input you gave is incorrect.");
                        break;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Please enter a number");
            }
        }

    }
}
