namespace cinemaApp
{
    public class ReviewJSN
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Review { get; set; }

        public ReviewJSN(int id, string name, string review)
        {
            ID = id;
            Name = name;
            Review = review;
        }



        public override string ToString()
        {
            return string.Format("{0}\nReview written by: {1}\nReview: {2}\n\n", ID, Name, Review);
        }
    }
}
