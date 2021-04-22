using System;
using System.Collections.Generic;
using System.Text;

namespace cinemaApp
{
    public class Movie
    {
        public string title { get; set; }
        public string genre { get; set; }
        public string language { get; set; }
        public string runtime { get; set; }
        public string ageRating { get; set; }
        public string imdb { get; set; }
        public string synopsis { get; set; }
        public override string ToString()
        {
            return string.Format("\nMovie information: \n\nTitle: {0}\nGenre: {1}\nLanguage: {2}\nRuntime: {3}\nAge rating: {4}\nImdb score: {5}\n\nSynopsis: {6}\n\n", title, genre, language, runtime, ageRating, imdb, synopsis);
        }
    }
}
