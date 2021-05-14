using System;
using System.Collections.Generic;
using System.Text;

namespace cinemaApp
{
    public class Movie
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Language { get; set; }
        public string Runtime { get; set; }
        public string AgeRating { get; set; }
        public string IMDB { get; set; }
        public string Synopsis { get; set; }
        
        public Movie(int id,string title, string genre, string language, string runtime, string agerating, string imdb, string synopsis)
        {
            ID = id;
            Title = title;
            Genre = genre;
            Language = language;
            Runtime = runtime;
            AgeRating = agerating;
            IMDB = imdb;
            Synopsis = synopsis;
        }
        
        
        
        public override string ToString()
        {
            return string.Format("{0}\nTitle: {1}\nGenre: {2}\nLanguage: {3}\nRuntime: {4}\nAge rating: {5}\nImdb score: {6}\n\nSynopsis: {6}\n\n",ID, Title, Genre, Language, Runtime, AgeRating, IMDB, Synopsis);
        }
    }
}
