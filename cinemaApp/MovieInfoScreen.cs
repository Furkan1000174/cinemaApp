﻿using System;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;

namespace cinemaApp
{
    class MovieInfoScreen
    {
        public static void showMovies(Account CurrentAccount)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            string a = "/// FILM SELECTION ///\n";
            Console.SetCursorPosition((Console.WindowWidth - a.Length) / 2, Console.CursorTop);
            Console.WriteLine(a);
            Console.ResetColor();
            bool choosing = true;
            List<String> jsonContents = new List<String> { };
            try
            {
                foreach (string line in File.ReadLines(@"movies.json")) //Creates a list with every object from json file
                {
                    jsonContents.Add(line);
                }
                var movieList = new List<Movie> { };
                foreach (string movie in jsonContents)
                {
                    movieList.Add(JsonConvert.DeserializeObject<Movie>(movie));
                }
                foreach (var movie in movieList)
                {
                    Console.WriteLine("[" + movie.ID + "]" + "\nTitle: " + movie.Title + "\n");
                }
                
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("\nNo movies found!\nPlease create a listing first!\n");
                System.Threading.Thread.Sleep(3500);
                Console.Clear();
                mainScreen.Show(CurrentAccount);
            }
            Console.WriteLine("Would you like to make a reservation and see the reviews of a selected film?\n1. Yes\n2. No\n");
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
                                        movieSelecter(result);
                                        choosing = false;
                                        Console.WriteLine("\nWould you like to make a reservation?\n1. Yes\n2. No\n");
                                        string opti = Console.ReadLine();
                                        try
                                        {
                                            int numb = Int32.Parse(opti);
                                            bool choosingRoom = true;
                                            switch (numb)
                                            {
                                                case 1:
                                                    try
                                                    {
                                                        while(choosingRoom)
                                                        {
                                                            Console.WriteLine("Please enter the room number.");
                                                            string chosenRoom = Console.ReadLine();
                                                            int roomResult = Int32.Parse(chosenRoom);

                                                          
                                                            List<String> roomJsonContents = new List<String> { };
                                                            foreach (string line in File.ReadLines(@"room.json"))
                                                            {
                                                                roomJsonContents.Add(line);
                                                            }
                                                            var roomList = new List<Room> { };
                                                            foreach (string seat in roomJsonContents)
                                                            {
                                                                roomList.Add(JsonConvert.DeserializeObject<Room>(seat));
                                                            }
                                                            foreach(var room in roomList)
                                                            {
                                                                if(room.RoomID == roomResult)
                                                                {
                                                                   movieRooms.roomScreen(CurrentAccount, movie.Title, roomResult);
                                                                    choosingRoom = false;
                                                                }
                                                            }
                                                        }
                                                        
                                                    }
                                                    catch (Exception)
                                                    {
                                                        Console.WriteLine("Please enter a number");
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
        public static void movieSelecter(int option)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            string a = "/// YOUR RESERVATION ///\n";
            Console.SetCursorPosition((Console.WindowWidth - a.Length) / 2, Console.CursorTop);
            Console.WriteLine(a);
            Console.ResetColor();
            List<String> jsonContents = new List<String> { };
            try
            {
                foreach (string line in File.ReadLines(@"movies.json")) //Creates a list with every object from json file
                {
                    jsonContents.Add(line);
                }
                var movieList = new List<Movie> { };
                foreach (String movie in jsonContents)
                {
                    movieList.Add(JsonConvert.DeserializeObject<Movie>(movie));
                }
                Console.WriteLine(movieList[option - 1]);

            }
            catch (Exception)
            {
                Console.WriteLine("Please enter a number");
            }
            List<String> jsonContentss = new List<String> { };
            try
            {

                foreach (string line in File.ReadLines(@"reviews.json"))
                {
                    jsonContentss.Add(line);
                }
                var reviewList = new List<ReviewJSN> { };
                foreach (String review in jsonContentss)
                {
                    reviewList.Add(JsonConvert.DeserializeObject<ReviewJSN>(review));
                }
                foreach (var review in reviewList)
                {
                    if(review.MovieID == option)
                    Console.WriteLine(review);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Please enter a number");
            }
            Console.ForegroundColor = ConsoleColor.Green;
            string b = "/// ROOM SELECTION ///\n";
            string availableseat = "O";
            Console.SetCursorPosition((Console.WindowWidth - b.Length) / 2, Console.CursorTop);
            Console.WriteLine(b);
            Console.ResetColor();
            List<string> jsonContent = new List<string> { };
            foreach (string line in File.ReadLines(@"room.json"))
            {
                jsonContent.Add(line);
            }
            var roomList = new List<Room> { };
            foreach (string seat in jsonContent)
            {
                roomList.Add(JsonConvert.DeserializeObject<Room>(seat));
            }
            foreach (var seat in roomList)
            {
                Console.WriteLine($"[{seat.RoomID}]");
                Console.WriteLine($"Room number: #{seat.RoomID}");
            }

        }
    }
}