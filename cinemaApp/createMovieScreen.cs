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