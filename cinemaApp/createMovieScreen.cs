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
            Console.WriteLine("Please enter the runtime\n(Please use a comma for decimals)");
            string runtimeInput = Console.ReadLine();
            double movieRuntime;
            bool correctRuntime = double.TryParse(runtimeInput, out movieRuntime);
            movieRuntime = Math.Truncate(movieRuntime * 100) / 100;
            while (!correctRuntime)
            {
                Console.WriteLine("That was not a correct input for runtime, please try again");
                Console.WriteLine("Please enter the runtime\n(Please use a comma for decimals)");
                runtimeInput = Console.ReadLine();
                correctRuntime = double.TryParse(runtimeInput, out movieRuntime);
                movieRuntime = Math.Truncate(movieRuntime * 100) / 100;
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
            Movie newMovie = new Movie(id,movieTitle, movieGenre, movieLanguage, movieRuntime, movieAgeRating, movieIMDB, movieSynopsis);

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
}