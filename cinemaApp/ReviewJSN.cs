namespace cinemaApp
{
    public class ReviewJSN
    {
        public int ID { get; set; }
        public int MovieID { get; set; }
        public string Name { get; set; }
        public string Review { get; set; }

        public ReviewJSN(int id, int movieid, string name, string review)
        {
            ID = id;
            MovieID = movieid;
            Name = name;
            Review = review;
        }



        public override string ToString()
        {
            return string.Format("Review #: {0}\nReview written by: {1}\nReview: {2}\n", ID, Name, Review);
        }
    }
}
