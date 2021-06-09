using System;
using System.Collections.Generic;
using System.Text;

namespace cinemaApp
{
    class mainScreen
    {

    
    public static void Show(Account CurrentAccount)
    {
            Console.Clear();
            string h;
            Console.ForegroundColor = ConsoleColor.Cyan;
        //TODO: Maak functie dat checkt of je user of guest bent, als je user bent zeg je hoi user anders zeg je gwn hoi
        if(CurrentAccount.UserName == "")
            {
                h = "/// Hello, guest  ///\n";
            }
            else
            {
                h = "/// Hello, " + CurrentAccount.UserName + " ///\n";
            }
            Console.SetCursorPosition((Console.WindowWidth - h.Length) / 2, Console.CursorTop);
        Console.WriteLine(h);
        Console.ResetColor();
            if (CurrentAccount.UserName == "")
            {
                Console.WriteLine("Please enter the number of what you would like to do:\n\n[1] View movies\n[2] Write a review\n[3] View catering\n[4] View Reservations\n[5] View Cart\n[6] Go Back");
            }
            else
            {
                Console.WriteLine("Please enter the number of what you would like to do:\n\n[1] View movies\n[2] Write a review\n[3] View catering\n[4] View Reservations\n[5] View Cart\n[6] Log Out");
            }
           
            if (CurrentAccount.Role == "Admin")
            {
                Console.WriteLine("[7] Manage movies\n[8] Manage catering\n[9] Manage Schedule\n[10] Remove reviews\n[11] Reset rooms");
            }
            Console.WriteLine("Please enter a number on screen to perform the desired action.");
            bool choosing = true;
            while (choosing)
            {
                string options = Console.ReadLine();
                try
                {
                    int number = Int32.Parse(options);
                    switch (number)
                    {
                        case 1:
                            MovieInfoScreen.showMovies(CurrentAccount);
                            choosing = false;
                            break;
                        case 2:
                            createReviewScreen.createReview(CurrentAccount);
                            choosing = false;
                            break;
                        case 3:
                            CateringScreen.showCatering(CurrentAccount);
                            choosing = false;
                            break;
                        case 4:
                            ReservationsScreen.showRes(CurrentAccount);
                            choosing = false;
                            break;
                        case 5:
                            cartScreen.showCart(CurrentAccount);
                            choosing = false;
                            break;
                        case 6:
                            Console.Clear();
                            if (CurrentAccount.UserName == "")
                            {
                                choosing = false;
                                Console.WriteLine("See you, guest!");
                            }
                            else
                            {
                                choosing = false;
                                Console.WriteLine("See you," + CurrentAccount.UserName);
                            }
                            Program.Main();
                            break;
                        case 7:
                            if(CurrentAccount.Role != "Admin")
                            {
                                Console.WriteLine("Nice try, but you're not getting in that easily ;)");
                            }
                            else
                            {
                                createMovieScreen.createMovie(CurrentAccount);
                                choosing = false;
                            }
                            break;
                        case 8:
                            if (CurrentAccount.Role != "Admin")
                            {
                                Console.WriteLine("Nice try, but you're not getting in that easily ;)");
                            }
                            else
                            {
                                createCateringScreen.CateringCreate(CurrentAccount);
                                choosing = false;
                            }
                            break;
                        case 9:
                            if (CurrentAccount.Role != "Admin")
                            {
                                Console.WriteLine("Nice try, but you're not getting in that easily ;)");
                            }
                            else
                            {
                                createScheduleScreen.createSchedule(CurrentAccount);
                                choosing = false;
                            }
                            break;
                        case 10:
                            if (CurrentAccount.Role != "Admin")
                            {
                                Console.WriteLine("Nice try, but you're not getting in that easily ;)");
                            }
                            else
                            {
                                createReviewScreen.reviewRemover(CurrentAccount);
                                choosing = false;
                            }
                            break;
                        case 11:
                            if (CurrentAccount.Role != "Admin")
                            {
                                Console.WriteLine("Nice try, but you're not getting in that easily ;)");
                            }
                            else
                            {
                                movieRooms.clearRooms();
                                choosing = false;
                            }
                            break;
                        default:
                            choosing = false;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("The input you gave is incorrect.\nPlease try a number that is shown on screen.");
                            Console.ResetColor();
                            System.Threading.Thread.Sleep(2500);
                            mainScreen.Show(CurrentAccount);
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The input you gave is incorrect.\nPlease try a number that is shown on screen.");
                    Console.ResetColor();
                    System.Threading.Thread.Sleep(2500);
                    mainScreen.Show(CurrentAccount);
                }
            }
    }
    }
}
