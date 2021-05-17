using System;
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
            for (int i = 0; i < room.Length; i++)
            {
                room[i] = new string[30];
            }
            int[] exlude = new int[] { 4, 3, 3, 3, 3, 2, 1, 0, 0, 0, 0, 0, 1, 2, 2, 3, 3, 5, 7, 8 };
            for (int i = 0; i < exlude.Length; i++)
            {
                for (int j = 0; j < 30; j++)
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
                        if (j >= exlude[i])
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

        public static void roomScreen()
        {

        }
    }
}