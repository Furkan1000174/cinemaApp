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
               if(movie.ID >= id)
                {
                    id = movie.ID + 1;
                }
            }


            Console.WriteLine("Please enter the movie title:");
            string movieTitle = Console.ReadLine();
            while (string.IsNullOrEmpty(movieTitle))
            {
                Console.WriteLine("The movie title can't be empty, please try again.");
                movieTitle = Console.ReadLine();
            }
            Console.WriteLine("Please enter the genre:");
            string movieGenre = Console.ReadLine();
            while (string.IsNullOrEmpty(movieGenre))
            {
                Console.WriteLine("The movie genre can't be empty, please try again.");
                movieGenre = Console.ReadLine();
            }
            Console.WriteLine("Please enter the movie language:");
            string movieLanguage = Console.ReadLine();
            while (string.IsNullOrEmpty(movieLanguage))
            {
                Console.WriteLine("The movie language can't be empty, please try again.");
                movieLanguage = Console.ReadLine();
            }
            Console.WriteLine("Please enter the runtime");
            string movieRuntime = Console.ReadLine();
            while (string.IsNullOrEmpty(movieRuntime))
            {
                Console.WriteLine("The menu Size can't be empty, please try again.");
                movieRuntime = Console.ReadLine();
            }
            Console.WriteLine("Please enter the age rating");
            string movieAgeRating = Console.ReadLine();
            while (string.IsNullOrEmpty(movieAgeRating))
            {
                Console.WriteLine("The movie age rating can't be empty, please try again.");
                movieAgeRating = Console.ReadLine();
            }
            Console.WriteLine("Please enter the IMDB score");
            string movieImdb = Console.ReadLine();
            while (string.IsNullOrEmpty(movieImdb))
            {
                Console.WriteLine("The menu Size can't be empty, please try again.");
                movieImdb = Console.ReadLine();
            }
            Console.WriteLine("Please enter the synopsis(Short Summary of the movie)");
            string movieSynopsis = Console.ReadLine();
            while (string.IsNullOrEmpty(movieSynopsis))
            {
                Console.WriteLine("The menu Size can't be empty, please try again.");
                movieSynopsis = Console.ReadLine();
            }

            Movie newMovie = new Movie(id,movieTitle, movieGenre, movieLanguage, movieRuntime, movieAgeRating, movieImdb, movieSynopsis);

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