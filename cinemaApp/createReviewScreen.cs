using System;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace cinemaApp
{
    class createReviewScreen
    {
        public static void createReview(Account CurrentAccount) //Create a review for json
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            string a = "/// WRITE YOUR VERY OWN REVIEW!///\n";
            Console.SetCursorPosition((Console.WindowWidth - a.Length) / 2, Console.CursorTop);
            Console.WriteLine(a);
            Console.ResetColor();
            bool choosing = true;
            List<String> jsonContents = new List<String> { };
            try
            {
                foreach (string line in File.ReadLines(@"movies.json")) 
                {
                    jsonContents.Add(line);
                }
                var movieList = new List<Movie> { };
                foreach (String movie in jsonContents)
                {
                    movieList.Add(JsonConvert.DeserializeObject<Movie>(movie));
                }
                foreach (var movie in movieList)
                {
                    Console.WriteLine(movie);
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("\nNo movies found!\nPlease create a listing first!\n");
                System.Threading.Thread.Sleep(3500);
                Console.Clear();
                mainScreen.Show(CurrentAccount);
            }

            Console.WriteLine("Would you like to write a review of a selected film?\n1. Yes\n2. No\n");
            string options = Console.ReadLine();
            try
            {
                int number = Int32.Parse(options);
                switch (number)
                {
                    case 1:
                        try
                        {
                            while (choosing)
                            {
                                Console.WriteLine("\nPlease enter the movie number\n");
                                string choice = Console.ReadLine();
                                int result = Int32.Parse(choice);
                                


                                var movieList = new List<Movie> { };
                                foreach (String movie in jsonContents)
                                {
                                    movieList.Add(JsonConvert.DeserializeObject<Movie>(movie));
                                }
                                foreach (var movie in movieList)
                                {
                                    if (movie.ID == result)
                                    {
                                        reviewSelecter(result);
                                        Console.WriteLine("Review added!\n");
                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                        Console.WriteLine("You will be send back to the mainscreen\n");
                                        Console.ResetColor();
                                        System.Threading.Thread.Sleep(5000);
                                        Console.Clear();
                                        mainScreen.Show(CurrentAccount);
                                        choosing = false;
                                    }
                                }
                            }
                        }
                        catch
                        {
                            Console.WriteLine("There is no movie with that Index, please try again.");
                        }
                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("\nYou will be send back to the mainscreen\n");
                        Console.ResetColor();
                        System.Threading.Thread.Sleep(2000);
                        Console.Clear();
                        mainScreen.Show(CurrentAccount);
                        break;
                    default:
                        Console.WriteLine("The input you gave is incorrect.");
                        break;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Please enter a number");
            }
        }

        public static void reviewSelecter(int option)
        {
            int currentmovieid = option;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            string a = "/// START WRITING YOUR REVIEW ///\n";
            Console.SetCursorPosition((Console.WindowWidth - a.Length) / 2, Console.CursorTop);
            Console.WriteLine(a);
            Console.ResetColor();
            //REVIEWS SCHRIJVEN
            int id = 1;
            List<String> jsonContents = new List<String> { };
            try
            {
                foreach (string line in File.ReadLines(@"reviews.json"))
                {
                    jsonContents.Add(line);
                }
                var reviewList = new List<ReviewJSN> { };
                foreach (String rev in jsonContents)
                {
                    reviewList.Add(JsonConvert.DeserializeObject<ReviewJSN>(rev));
                }
                foreach (var review in reviewList)
                {
                    if (review.ID >= id)
                    {
                        id = review.ID + 1;
                    }
                }
                
            }
            catch (FileNotFoundException)
            {

            }
            Console.WriteLine("Please enter your name:");
            string reviewName = Console.ReadLine();
            while (string.IsNullOrEmpty(reviewName))
            {
                Console.WriteLine("The name section can't be empty, please try again.");
                Console.WriteLine("Please enter your name:");
                reviewName = Console.ReadLine();
            }
            Console.WriteLine("Please enter your review:");
            string reviewReview = Console.ReadLine();
            while (string.IsNullOrEmpty(reviewReview))
            {
                Console.WriteLine("The review can't be empty, please try again.");
                Console.WriteLine("Please enter your review:");
                reviewReview = Console.ReadLine();
            }
            ReviewJSN newReview = new ReviewJSN(id,currentmovieid, reviewName, reviewReview);

            string strNewReviewJson = JsonConvert.SerializeObject(newReview);
            using (StreamWriter sw = File.AppendText(@"reviews.json"))
            {
                sw.WriteLine(strNewReviewJson);
                sw.Close();
            }

        }
    }
}
