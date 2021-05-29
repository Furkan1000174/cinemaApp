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
        public static void createRoom()
        {
            string[][] room = new string[20][];
            for(int i=0; i < room.Length; i++)
            {
                room[i] = new string[30];
            }
            int[] exlude = new int[] { 4, 3, 3, 3, 3, 2, 1, 0, 0, 0, 0, 0, 1, 2, 2, 3, 3, 5, 7, 8 };
            for(int i=0; i < exlude.Length; i++)
            {
                for(int j=0; j < 30; j++)
                {
                    if (j > 15)
                    {
                        if (j < 30 - exlude[i])
                        {
                            room[i][j] = "O";
                        }
                        else
                        {
                            room[i][j] = " ";
                        }
                    }
                    else
                    {
                        if(j >= exlude[i])
                        {
                            room[i][j] = "O";
                        }
                        else
                        {
                            room[i][j] = " ";
                        }
                    }
                }
            }
            Room newRoom = new Room()
            {
                room = room,
            };
            string roomArray = JsonConvert.SerializeObject(newRoom);
            using (StreamWriter sw = File.AppendText(@"room.json"))
            {
                sw.WriteLine(roomArray);
                sw.Close();
            }

        }

        public static void roomScreen(Account CurrentAccount)
        {
            while (true)
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
                foreach (string room in jsonContent)
                {
                    roomList.Add(JsonConvert.DeserializeObject<Room>(room));
                }
                foreach (var line in roomList)
                {
                    Console.WriteLine(line);
                }
                Console.WriteLine("Please enter which seats you would like to reserve");
                Console.WriteLine("Please enter them as (X, Y) for example (Row 1, Seat 1)");
                string options = Console.ReadLine();
                if (options == "exit")
                {
                    MovieInfoScreen.showMovies(CurrentAccount);
                }
            }
        }   
    }
}
