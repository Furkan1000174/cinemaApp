using System;
using System.Collections.Generic;
using System.Text;

namespace cinemaApp
{
    public class Movie
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Language { get; set; }
        public string Runtime { get; set; }
        public string AgeRating { get; set; }
        public string IMDB { get; set; }
        public string Synopsis { get; set; }
        
        public Movie(string title, string genre, string language, string runtime, string agerating, string imdb, string synopsis)
        {
            Title = title;
            Language = language;
            Runtime = runtime;
            AgeRating = agerating;
            IMDB = imdb;
            Synopsis = synopsis;
        }
        
        
        
        public override string ToString()
        {
            return string.Format("\nTitle: {0}\nGenre: {1}\nLanguage: {2}\nRuntime: {3}\nAge rating: {4}\nImdb score: {5}\n\nSynopsis: {6}\n\n", Title, Genre, Language, Runtime, AgeRating, IMDB, Synopsis);
        }
    }
}
