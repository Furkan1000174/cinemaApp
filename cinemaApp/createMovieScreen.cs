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
        public static void createMovie() //Create a movie listing for json
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            string a = "/// Movie creation ///\n";
            Console.SetCursorPosition((Console.WindowWidth - a.Length) / 2, Console.CursorTop);
            Console.WriteLine(a);
            Console.ResetColor();
            Console.WriteLine("Please enter the movie title:");
            string movieTitle = Console.ReadLine();
            Console.WriteLine("Please enter the genre:");
            string movieGenre = Console.ReadLine();
            Console.WriteLine("Please enter the movie language:");
            string movieLanguage = Console.ReadLine();
            Console.WriteLine("Please enter the runtime");
            string movieRuntime = Console.ReadLine();
            Console.WriteLine("Please enter the age rating");
            string movieAgeRating = Console.ReadLine();
            Console.WriteLine("Please enter the IMDB score");
            string movieImdb = Console.ReadLine();
            Console.WriteLine("Please enter the synopsis");
            string movieSynopsis = Console.ReadLine();

            Movie newMovie = new Movie()
            {
                title = movieTitle,
                genre = movieGenre,
                language = movieLanguage,
                runtime = movieRuntime,
                ageRating = movieAgeRating,
                imdb = movieImdb,
                synopsis = movieSynopsis
            };

            string strNewMovieJson = JsonConvert.SerializeObject(newMovie);
            using (StreamWriter sw = File.AppendText(@"movies.json"))
            {
                sw.WriteLine(strNewMovieJson);
                sw.Close();
            }
            Console.WriteLine("Movie added!");
            
            mainScreen.Show(Program.CurrentAccount);
        }
    }
}