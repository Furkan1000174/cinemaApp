﻿using System;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace cinemaApp
{
    class movieRooms
    {
        public static void createRoom(int seats, int rows,int[] exlude)
        {
            Seat[][] room = new Seat[rows][];
            for(int i=0; i < room.Length; i++)
            {
                room[i] = new Seat[seats];
            }
            for(int i=0; i < exlude.Length; i++)
            {
                for(int j=0; j < seats; j++)
                {
                    if (j > (seats/2))
                    {
                        if (j < seats - exlude[i])
                        {
                            room[i][j] = new Seat("O",i,j,15.00);
                        }
                        else
                        {
                            room[i][j] = new Seat(" ",i,j,00.00);
                        }
                    }
                    else
                    {
                        if(j >= exlude[i])
                        {
                            room[i][j] = new Seat("O", i, j, 15.00);
                        }
                        else
                        {
                            room[i][j] = new Seat(" ", i, j, 00.00);
                        }
                    }
                }
            }
            int id = 1;
            List<String> jsonContents = new List<String> { };
            foreach (string line in File.ReadLines(@"room.json"))
            {
                jsonContents.Add(line);
            }
            var roomList = new List<Room> { };
            foreach (String roomObject in jsonContents)
            {
                roomList.Add(JsonConvert.DeserializeObject<Room>(roomObject));
            }
            foreach (var roomItem in roomList)
            {
                if (roomItem.RoomID >= id)
                {
                    id = roomItem.RoomID + 1;
                }
            }
            Room newRoom = new Room(id, room);
            string roomArray = JsonConvert.SerializeObject(newRoom);
            using (StreamWriter sw = File.AppendText(@"room.json"))
            {
                sw.WriteLine(roomArray);
                sw.Close();
            }

        }

        public static void roomScreen(Account CurrentAccount, string movieName)
        {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                string h = "Welcome to the seat selection!\n\n";
                Console.SetCursorPosition((Console.WindowWidth - h.Length) / 2, Console.CursorTop);
                Console.WriteLine(h);
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
                    Console.WriteLine(seat);
                }
               

            //Jullie zijn lieve kereltjes ♥

            Console.WriteLine("What would you like to do?\n1. Reserve a seat.\n2. Go back to the main menu.\n");
            string options = Console.ReadLine();

            int number = Int32.Parse(options);
            try
            {
                switch (number)
                {
                    case 1:

                            var seatList = new List<Seat> { };
                            foreach(var room in roomList)
                            {
                               for(int i = 0; i< room.seatRoom.Length;i++)
                                {
                                    for(int j = 0; j < room.seatRoom[i].Length;j++)
                                    {
                                        seatList.Add(room.seatRoom[i][j]);
                                    }
                                }
                            }
                            //:)
                            Console.WriteLine("Please enter which seats you would like to reserve");
                            Console.WriteLine("Please enter the row in which you would like to sit, enter a number.");
                            string xCorInput = Console.ReadLine();
                            int seatXCor;
                            bool correctXCor = int.TryParse(xCorInput, out seatXCor);
                            while (!correctXCor)
                            {
                                Console.WriteLine("That was not a correct input for the row, please try again");
                                Console.WriteLine("Please enter the row in which you would like to sit, enter a number.");
                                xCorInput = Console.ReadLine();
                                correctXCor = int.TryParse(xCorInput, out seatXCor);
                            }

                            Console.WriteLine("Please enter the column in which you would like to sit, enter a number.");
                            string yCorInput = Console.ReadLine();
                            int seatYCor;
                            bool correctYCor = int.TryParse(yCorInput, out seatYCor);
                            while (!correctYCor)
                            {
                                Console.WriteLine("That was not a correct input for the column, please try again");
                                Console.WriteLine("Please enter the column in which you would like to sit, enter a number.");
                                yCorInput = Console.ReadLine();
                                correctYCor = int.TryParse(yCorInput, out seatYCor);
                            }
                            foreach (var seat in seatList)
                            {
                                if (seat.Xcor == seatXCor && seat.Ycor == seatYCor)
                                {
                                    if (seat.Icon != " " && seat.Icon != "X")
                                    {
                                        Cart newCartJSON = new Cart(CurrentAccount.ID, movieName, seat.Price);
                                        string strNewCartJSON = JsonConvert.SerializeObject(newCartJSON);
                                        using (StreamWriter sw = File.AppendText(@"cart.json"))
                                        {
                                            sw.WriteLine(strNewCartJSON);
                                            sw.Close();
                                        }
                                        seat.Icon = "Your reservation has been made! Returning to Seat Selection";
                                    Console.WriteLine(seat);
                                    System.Threading.Thread.Sleep(2000);
                                    roomScreen(CurrentAccount, movieName);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Something went wrong. Please try again.");
                                        System.Threading.Thread.Sleep(2000);
                                        roomScreen(CurrentAccount, movieName);
                                    }
                                }
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
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }   
    }
}
