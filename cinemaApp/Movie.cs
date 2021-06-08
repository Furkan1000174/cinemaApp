namespace cinemaApp
{
    public class Movie
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Language { get; set; }
        public double Runtime { get; set; }
        public int AgeRating { get; set; }
        public double IMDB { get; set; }

        public string ScheduledTime { get; set; }
        public string Synopsis { get; set; }

        public Movie(int id,string title, string genre, string language, double runtime, int agerating, string scheduledTime, double imdb, string synopsis)
        {
            ID = id;
            Title = title;
            Genre = genre;
            Language = language;
            Runtime = runtime;
            AgeRating = agerating;
            IMDB = imdb;
            ScheduledTime = scheduledTime;
            Synopsis = synopsis;
        }
        public override string ToString()
        {
            return string.Format("[{0}]\nTitle: {1}\nGenre: {2}\nLanguage: {3}\nRuntime: {4}\nAge rating: {5}\nImdb score: {6}\nScheduled time: {7}\n\nSynopsis: {7}\n", ID, Title, Genre, Language, Runtime, AgeRating, IMDB, ScheduledTime, Synopsis);
        }
    }
}
