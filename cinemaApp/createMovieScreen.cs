using System;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace cinemaApp
{
    class createMovieScreen
    {
        public static void createMovie(Account CurrentAccount) //Create a movie listing for json
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            string a = "/// Movie creation ///\n";
            Console.SetCursorPosition((Console.WindowWidth - a.Length) / 2, Console.CursorTop);
            Console.WriteLine(a);
            Console.ResetColor();
            Console.WriteLine("Please enter what you would like to do\n\n[1] Add movie\n[2] Remove movie\n");
            bool choosing = true;
            while (choosing)
            {
                string options = Console.ReadLine();
                try
                {
                    int number = Int32.Parse(options);
                    switch (number)
                    {
                        case 1:
                            choosing = false;
                            break;
                        case 2:
                            RemoveMovie(CurrentAccount);
                            choosing = false;
                            break;
                        default:
                            choosing = false;
                            Console.WriteLine("The input you gave is incorrect.\n Please try a number that is shown on screen.");
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("The input you gave is incorrect.\n Please try a number that is shown on screen.");
                }
                int id = 1;
                List<String> jsonContents = new List<String> { };
                try
                {
                    foreach (string line in File.ReadLines(@"movies.json"))
                    {
                        jsonContents.Add(line);
                    }
                    var movieList = new List<CateringJSN> { };
                    foreach (String cate in jsonContents)
                    {
                        movieList.Add(JsonConvert.DeserializeObject<CateringJSN>(cate));
                    }
                    foreach (var movie in movieList)
                    {
                        if (movie.ID >= id)
                        {
                            id = movie.ID + 1;
                        }
                    }
                    //Hier blijft het doorzeuren tot er wel iets is ingevoerd, geen lege data meer
                }
                catch (FileNotFoundException)
                {

                }
                Console.WriteLine("Please enter the movie title:");
                string movieTitle = Console.ReadLine();
                while (string.IsNullOrEmpty(movieTitle))
                {
                    Console.WriteLine("The movie title can't be empty, please try again.");
                    Console.WriteLine("Please enter the movie title:");
                    movieTitle = Console.ReadLine();
                }
                Console.WriteLine("Please enter the genre:");
                string movieGenre = Console.ReadLine();
                while (string.IsNullOrEmpty(movieGenre))
                {
                    Console.WriteLine("The movie genre can't be empty, please try again.");
                    Console.WriteLine("Please enter the genre:");
                    movieGenre = Console.ReadLine();
                }
                Console.WriteLine("Please enter the movie language:");
                string movieLanguage = Console.ReadLine();
                while (string.IsNullOrEmpty(movieLanguage))
                {
                    Console.WriteLine("The movie language can't be empty, please try again.");
                    Console.WriteLine("Please enter the movie language:");
                    movieLanguage = Console.ReadLine();
                }
                Console.WriteLine("Please enter the runtime\n(Please enter just an integer)");
                string runtimeInput = Console.ReadLine();
                int movieRuntime;
                bool correctRuntime = int.TryParse(runtimeInput, out movieRuntime);
                while (!correctRuntime)
                {
                    Console.WriteLine("That was not a correct input for runtime, please try again");
                    Console.WriteLine("Please enter the runtime\n(Please use a comma for decimals)");
                    runtimeInput = Console.ReadLine();
                    correctRuntime = int.TryParse(runtimeInput, out movieRuntime);
                }
                Console.WriteLine("Please enter the age rating\n(Please enter just an integer)");
                string ageRatingInput = Console.ReadLine();
                int movieAgeRating;
                bool correctAgeRating = int.TryParse(ageRatingInput, out movieAgeRating);
                while (!correctAgeRating)
                {
                    Console.WriteLine("That was not a correct input for age rating, please try again");
                    Console.WriteLine("Please enter the age rating\n(Please enter just an integer)");
                    ageRatingInput = Console.ReadLine();
                    correctAgeRating = int.TryParse(ageRatingInput, out movieAgeRating);
                }
                Console.WriteLine("Please enter the IMDB score\n(Please use a comma for decimals)");
                string IMDBInput = Console.ReadLine();
                double movieIMDB;
                bool correctInput = double.TryParse(IMDBInput, out movieIMDB);
                movieIMDB = Math.Truncate(movieIMDB * 100) / 100;
                while (!correctInput)
                {
                    Console.WriteLine("That was not a correct input for IMDB, please try again");
                    Console.WriteLine("Please enter the IMDB score:\n(Please use a comma for decimals)");
                    IMDBInput = Console.ReadLine();
                    correctInput = double.TryParse(IMDBInput, out movieIMDB);
                    movieIMDB = Math.Truncate(movieIMDB * 100) / 100;
                }
                Console.WriteLine("Please enter the synopsis(Short Summary of the movie)");
                string movieSynopsis = Console.ReadLine();
                while (string.IsNullOrEmpty(movieSynopsis))
                {
                    Console.WriteLine("The menu Size can't be empty, please try again.");
                    Console.WriteLine("Please enter the synopsis(Short Summary of the movie)");
                    movieSynopsis = Console.ReadLine();
                }
                Console.WriteLine("Please enter the price");
                Movie newMovie = new Movie(id, movieTitle, movieGenre, movieLanguage, movieRuntime, movieAgeRating, movieIMDB, movieSynopsis);

                string strNewMovieJson = JsonConvert.SerializeObject(newMovie);
                using (StreamWriter sw = File.AppendText(@"movies.json"))
                {
                    sw.WriteLine(strNewMovieJson);
                    sw.Close();
                }
                Console.WriteLine("Movie added!");

                mainScreen.Show(CurrentAccount);
            }
        }
        public static void RemoveMovie(Account CurrentAccount)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            string a = "/// Remove movie ///\n";
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
                if (jsonContents.Count == 0)
                {
                    Console.WriteLine("\nNo movies found!\nPlease create a listing first!\n");
                    System.Threading.Thread.Sleep(3500);
                    Console.Clear();
                    mainScreen.Show(CurrentAccount);
                }
                else 
                {
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
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("\nNo movies found!\nPlease create a listing first!\n");
                System.Threading.Thread.Sleep(3500);
                Console.Clear();
                mainScreen.Show(CurrentAccount);
            }
            Console.WriteLine("\nPlease enter the title of the movie you would like to remove\n");
            var options = Console.ReadLine();
            List<String> jsonContents2 = new List<String> { };
            //Loop through all movies in the current movie list.
            try
            {
                foreach (string line in File.ReadLines(@"movies.json")) //Creates a list with every object from json file
                {
                    //If given title of the movie is in a movie object DO NOT add to jsonContent2 list 
                    if (line.Contains(options))
                    {

                    }
                    else
                    {
                        jsonContents2.Add(line);
                    }
                }
                var movieList = new List<Movie> { };
                foreach (string movie in jsonContents2)
                {
                    movieList.Add(JsonConvert.DeserializeObject<Movie>(movie));
                }
                if (jsonContents2.Count == 0)
                {
                    using (StreamWriter sw = File.CreateText(@"movies.json"))
                    {

                        sw.Close();
                    }
                }
                else
                {
                    foreach (var movie in movieList)
                    {
                        string strNewMovieJson = JsonConvert.SerializeObject(movie);
                        using (StreamWriter sw = File.CreateText(@"movies.json"))
                        {
                            sw.WriteLine(strNewMovieJson);
                            sw.Close();
                        }
                    }
                }

                System.Threading.Thread.Sleep(3000);
                //Figure out how to convert jsonContents2 to a movie format to add to json
                mainScreen.Show(CurrentAccount);
            }
            catch
            {

            }
        }
    }
}