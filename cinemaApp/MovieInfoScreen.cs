using System;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace cinemaApp
{
    class MovieInfoScreen
    {

        public static void reserve(Account currentAccount)
        {

        }
        public static void showMovies(Account CurrentAccount)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            string a = "/// FILM SELECTION ///\n";
            Console.SetCursorPosition((Console.WindowWidth - a.Length) / 2, Console.CursorTop);
            Console.WriteLine(a);
            Console.ResetColor();
            int counter = 1;
            bool choosing = true;
                List<String> jsonContents = new List<String> { };
                try
                {
                    foreach (string line in File.ReadLines(@"movies.json")) //Creates a list with every object from json file
                    {
                        jsonContents.Add(line);
                    }
                    var movieList = new List<Movie> { };
                    foreach (String movie in jsonContents)
                    {
                        movieList.Add(JsonConvert.DeserializeObject<Movie>(movie));
                    }
                    foreach (var movie in movieList)
                    {
                        Console.Write("[" + counter + "]");
                        counter++;
                        Console.WriteLine(movie);
                    }
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("\nNo movies found!\nPlease create a listing first!\n");
                    System.Threading.Thread.Sleep(3500);
                    Console.Clear();
                    mainScreen.Show(CurrentAccount);
                }
            while (choosing)
            {
                Console.WriteLine("Would you like to make a reservation?\n1. Yes\n2. No\n");
                string options = Console.ReadLine();
                try
                {
                    int number = Int32.Parse(options);
                    switch (number)
                    {
                        case 1:
                            try
                            {
                                Console.WriteLine("\nPlease enter the movie number\n");
                                string choice = Console.ReadLine();
                                int result = Int32.Parse(choice);
                                movieSelecter(result);
                                choosing = false;
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine("\nYou selected this film! but the reservation section is currently under construction\nYou will be send back to the mainscreen");
                                System.Threading.Thread.Sleep(7000);
                                Console.ResetColor();
                                Console.Clear();
                                mainScreen.Show(CurrentAccount);
                                break;
                            }
                            catch
                            {
                                showMovies(CurrentAccount);
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
            /*
            while (true)
            {
                Console.WriteLine("These are the available movies of our theatre:\n\n1. Minari\n2. Sound of Metal\n3. Nomadland\n4. Another round\n5. The Father\n\nEnter the number of the movie you would like to get more information of: ");
                var options = Console.ReadLine();
                if (options == "1")
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    string s = "/// MINARI ///\n";
                    Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop);
                    Console.WriteLine(s);
                    Console.ResetColor();
                    Console.WriteLine("Genre: Drama\nLanguage: Korean/English\nRuntime: 2h(120min)\nAge Rating: 12\nIMDb: 7.6\n");
                    Console.WriteLine("Synopsis:\n");
                    Console.WriteLine("A Korean family starts a farm in 1980s Arkansas.\n");
                    Console.WriteLine("Do you want to make a reservation for this film? y/n: ");
                    var yis = Console.ReadLine();
                    if (yis == "Y" | yis == "y")
                    {
                        Console.WriteLine("\nReservations are not available yet");
                        Console.Read();
                        showMovies(CurrentAccount);
                    }
                    else if (yis == "N" | yis == "n")
                    {
                        showMovies(CurrentAccount);
                    }
                }
                else if (options == "2")
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    string s = "/// SOUND OF METAL ///\n";
                    Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop);
                    Console.WriteLine(s);
                    Console.ResetColor();
                    Console.WriteLine("Genre: Drama/Music\nLanguage: English/American Sign Language/French\nRuntime: 2h(120min)\nAge Rating: 16\nIMDb: 7.8\n");
                    Console.WriteLine("Synopsis:\n");
                    Console.WriteLine("A heavy-metal drummer's life is thrown into freefall when he begins to lose his hearing.\n");
                    Console.WriteLine("Do you want to make a reservation for this film? y/n: ");
                    var yis = Console.ReadLine();
                    if (yis == "Y" | yis == "y")
                    {
                        Console.WriteLine("\nReservations are not available yet. Please press the enter key to continue.");
                        Console.Read();
                        showMovies(CurrentAccount);
                    }
                    else if (yis == "N" | yis == "n")
                    {
                        showMovies(CurrentAccount);
                    }
                }
                else if (options == "3")
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    string s = "/// NOMADLAND ///\n";
                    Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop);
                    Console.WriteLine(s);
                    Console.ResetColor();
                    Console.WriteLine("Genre: Drama\nLanguage: English\nRuntime: 1h47m (107min)\nAge Rating: 12\nIMDb: 7.6\n");
                    Console.WriteLine("Synopsis:\n");
                    Console.WriteLine("After losing everything in the Great Recession,\na woman embarks on a journey through the American West,\nliving as a van-dwelling modern-day nomad.\n");
                    Console.WriteLine("Do you want to make a reservation for this film? y/n: ");
                    var yis = Console.ReadLine();
                    if (yis == "Y" | yis == "y")
                    {
                        Console.WriteLine("\nReservations are not available yet. Please press the enter key to continue.");
                        Console.Read();
                        showMovies(CurrentAccount);
                    }
                    else if (yis == "N" | yis == "n")
                    {
                        showMovies(CurrentAccount);
                    }
                }
                else if (options == "4")
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    string s = "/// ANOTHER ROUND ///\n";
                    Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop);
                    Console.WriteLine(s);
                    Console.ResetColor();
                    Console.WriteLine("Genre: Drama/Comedy\nLanguage: Danish/Swedish\nRuntime: 1h57m (117min)\nAge Rating: 12\nIMDb: 7.8\n");
                    Console.WriteLine("Synopsis:\n");
                    Console.WriteLine("Four friends, all high school teachers,\ntest a theory that they will improve their lives by maintaining a constant level of alcohol in their blood.\n");
                    Console.WriteLine("Do you want to make a reservation for this film? y/n: ");
                    var yis = Console.ReadLine();
                    if (yis == "Y" | yis == "y")
                    {
                        Console.WriteLine("\nReservations are not available yet. Please press the enter key to continue.");
                        Console.Read();
                        showMovies(CurrentAccount);
                    }
                    else if (yis == "N" | yis == "n")
                    {
                        showMovies(CurrentAccount);
                    }
                }
                else if (options == "5")
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    string s = "/// THE FATHER ///\n";
                    Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop);
                    Console.WriteLine(s);
                    Console.ResetColor();
                    Console.WriteLine("Genre: Drama\nLanguage: English\nRuntime: 1h37m (97min)\nAge Rating: 12\nIMDb: 8.3\n");
                    Console.WriteLine("Synopsis:\n");
                    Console.WriteLine("A man refuses all assistance from his daughter as he ages.\nAs he tries to make sense of his changing circumstances, he begins to doubt his loved ones,\nhis own mind and even the fabric of his reality.\n");
                    Console.WriteLine("Do you want to make a reservation for this film? y/n: ");
                    var yis = Console.ReadLine();
                    if (yis == "Y" | yis == "y")
                    {
                        Console.WriteLine("\nReservations are not available yet. Please press the enter key to continue.");
                        Console.Read();
                        showMovies(CurrentAccount);
                    }
                    else if (yis == "N" | yis == "n")
                    {
                        showMovies(CurrentAccount);
                    }
                }
            }
         */
        }
        public static void movieSelecter(int option)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            string a = "/// YOUR RESERVATION ///\n";
            Console.SetCursorPosition((Console.WindowWidth - a.Length) / 2, Console.CursorTop);
            Console.WriteLine(a);
            Console.ResetColor();
                List<String> jsonContents = new List<String> { };
                try
                {

                    foreach (string line in File.ReadLines(@"movies.json")) //Creates a list with every object from json file
                    {
                        jsonContents.Add(line);
                    }
                    var movieList = new List<Movie> { };
                    foreach (String movie in jsonContents)
                    {
                        movieList.Add(JsonConvert.DeserializeObject<Movie>(movie));
                    }
                    Console.WriteLine(movieList[option - 1]);
                }
                catch (Exception)
                {
                    Console.WriteLine("Please enter a number");
                }
        }
    }
}