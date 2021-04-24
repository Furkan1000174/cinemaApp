using System;
using System.Collections.Generic;
using System.Text;

namespace cinemaApp
{
    class mainScreen
    {
    public static void Show(string user)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
            //TODO: Maak functie dat checkt of je user of guest bent, als je user bent zeg je hoi user anders zeg je gwn hoi
        string h = $"///  Welcome, {user}  ///\n";
        Console.SetCursorPosition((Console.WindowWidth - h.Length) / 2, Console.CursorTop);
        Console.WriteLine(h);
        Console.ResetColor();
        Console.WriteLine("Please enter the number of what you would like to do:\n1. View movies\n2. View reviews\n3. View catering\n4. View Schedule\n");
        //TODO: Maak Admin opties (if statement om te checken of de ingelogde gebruiker een admin is, dan deze opties laten zien)
        var choosing = true;
            while (choosing)
            {
                try
                {
                    string options = Console.ReadLine();
                    int number = Int32.Parse(options);
                    switch (number)
                    {
                        case 1:
                            MovieInfoScreen.showMovies();
                            choosing = false;
                            break;
                        case 2:
                            review.reviewScreen();
                            choosing = false;
                            break;
                        case 3:
                            //TODO: Maak Catering Screen
                            //cateringScreen();
                            break;
                        case 4:
                            Schedule.showSchedule();
                            choosing = false;
                            break;
                        case 5:
                            //TODO: Maak Manage Movies Scherm
                            createMovieScreen.createMovie();
                            choosing = false;
                            break;
                        case 6:
                        //TODO: Maak Manage Reservation Scherm
                        //adminReservationScreen();
                        //break;
                        case 7:
                        //TODO: Maak Catering Manage Scherm
                        //adminCateringScreen();
                        //break;
                        case 8:
                        //TODO: Maak Schedule Manage Scherm
                        //adminScheduleScreen();
                        //break;
                        default:
                            Console.WriteLine("The input you gave is incorrect.\n Please try a number that is shown on screen.");
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("The input you gave is incorrect.\n Please try a number that is shown on screen.");
                }
            }
    }
    }
}
