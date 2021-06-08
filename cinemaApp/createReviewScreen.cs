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
                if (jsonContents.Count == 0)
                {
                    Console.WriteLine("\nNo movies found!\nPlease create a listing first!\n");
                    System.Threading.Thread.Sleep(3500);
                    Console.Clear();
                    mainScreen.Show(CurrentAccount);
                }
                else
                {
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
                                        System.Threading.Thread.Sleep(3000);
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
        public static void reviewRemover(Account CurrentAccount)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            string a = "/// Remove review ///\n";
            Console.SetCursorPosition((Console.WindowWidth - a.Length) / 2, Console.CursorTop);
            Console.WriteLine(a);
            Console.ResetColor();
            List<String> jsonContents = new List<String> { };
            try
            {
                foreach (string line in File.ReadLines(@"reviews.json"))
                {
                    jsonContents.Add(line);
                }
                if (jsonContents.Count == 0)
                {
                    Console.WriteLine("\nNo movies found!\nPlease create a listing first!\n");
                    System.Threading.Thread.Sleep(3500);
                    Console.Clear();
                    mainScreen.Show(CurrentAccount);
                }
                else
                {
                    var reviewList = new List<ReviewJSN> { };
                    foreach (String rev in jsonContents)
                    {
                        reviewList.Add(JsonConvert.DeserializeObject<ReviewJSN>(rev));
                    }
                    foreach (var review in reviewList)
                    {
                        Console.WriteLine(review);
                    }
                }

            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("\nNo movies found!\nPlease create a listing first!\n");
                System.Threading.Thread.Sleep(3500);
                Console.Clear();
                mainScreen.Show(CurrentAccount);
            }
            Console.WriteLine("\nPlease enter the author of the review you would like to remove\n");
            var options = Console.ReadLine();
            List<String> jsonContents2 = new List<String> { };
            //Loop through all movies in the current movie list.
            try
            {
                foreach (string line in File.ReadLines(@"reviews.json")) //Creates a list with every object from json file
                {
                    //If given title of the movie is in a movie object DO NOT add to jsonContent2 list 
                    if (line.Contains(options))
                    {

                    }
                    else
                    {
                        jsonContents2.Add(line);
                    }
                }
                var reviewList = new List<ReviewJSN> { };
                foreach (string review in jsonContents2)
                {
                    reviewList.Add(JsonConvert.DeserializeObject<ReviewJSN>(review));
                }
                if (jsonContents2.Count == 0)
                {
                    using (StreamWriter sw = File.CreateText(@"reviews.json"))
                    {
                        sw.Close();
                        Console.WriteLine($"\n{options} has been removed");
                        System.Threading.Thread.Sleep(3000);
                        mainScreen.Show(CurrentAccount);
                    }
                }
                else
                    using (StreamWriter sw = File.CreateText(@"reviews.json"))
                    {
                        sw.Close();
                    }
                {
                    foreach (var review in reviewList)
                    {
                        string strNewMovieJson = JsonConvert.SerializeObject(review);
                        using (StreamWriter sw = File.AppendText(@"reviews.json"))
                        {
                            sw.WriteLine(strNewMovieJson);
                            sw.Close();
                        }
                    }
                }
                Console.WriteLine($"\n{options} has been removed");
                System.Threading.Thread.Sleep(3000);
                mainScreen.Show(CurrentAccount);
            }
            catch
            {

            }
        }
    }
}
