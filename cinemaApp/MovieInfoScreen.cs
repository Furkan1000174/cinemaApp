using System;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;

namespace cinemaApp
{
    class MovieInfoScreen
    {
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
                                        Cart newCartJSON = new Cart(CurrentAccount.ID, movie.Title, movie.Price);
                                        string strNewCartJSON = JsonConvert.SerializeObject(newCartJSON);
                                        using (StreamWriter sw = File.AppendText(@"cart.json"))
                                        {
                                            sw.WriteLine(strNewCartJSON);
                                            sw.Close();
                                        }
                                        movieSelecter(result);
                                        choosing = false;
                                        Console.ForegroundColor = ConsoleColor.DarkMagenta;

                                        Console.WriteLine("\nYour reservation has been made!\nYou will be send back to the mainscreen");
                                        System.Threading.Thread.Sleep(5000);
                                        Console.ResetColor();
                                        Console.Clear();
                                        mainScreen.Show(CurrentAccount);
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("There is no movie with that number, please try again.");
                                        break;
                                    }
                                }
                            }
                        }
                        catch
                        {
                            Console.WriteLine("There is no movie with that number, please try again.");
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