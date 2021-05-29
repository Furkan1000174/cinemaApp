using System;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;

namespace cinemaApp
{
    class MovieInfoScreen
    {
        public static void showMovies(Account CurrentAccount)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            string a = "/// FILM SELECTION ///\n";
            Console.SetCursorPosition((Console.WindowWidth - a.Length) / 2, Console.CursorTop);
            Console.WriteLine(a);
            Console.ResetColor();
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

            Console.WriteLine("Would you like to make a reservation and see the reviews of a selected film?\n1. Yes\n2. No\n");
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
                                        movieSelecter(result);
                                        choosing = false;
                                        Console.WriteLine("\nWould you like to make a reservation?\n1. Yes\n2. No\n");
                                        string opti = Console.ReadLine();
                                        try
                                        {
                                            int numb = Int32.Parse(opti);
                                            switch (numb)
                                            {
                                                case 1:

                                                    movieRooms.roomScreen(CurrentAccount,movie.Title);
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
                        }
                        catch
                        {
                            Console.WriteLine("There is no movie with that Index, please try again.");
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
            List<String> jsonCuntents = new List<String> { };
            try
            {

                foreach (string line in File.ReadLines(@"reviews.json"))
                {
                    jsonCuntents.Add(line);
                }
                var reviewList = new List<ReviewJSN> { };
                foreach (String review in jsonCuntents)
                {
                    reviewList.Add(JsonConvert.DeserializeObject<ReviewJSN>(review));
                }
                foreach (var review in reviewList)
                {
                    if(review.MovieID == option)
                    Console.WriteLine(review);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Please enter a number");
            }
        }
    }
}