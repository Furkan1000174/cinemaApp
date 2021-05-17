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
            string[][] room = new string[19][];
            for (int i = 0; i < room.Length; i++)
            {
                room[i] = new string[18];
            }
            int[] exlude = new int[] { 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 1, 1, 1, 2, 2, 2, 3, 3, };
            for (int i = 0; i < exlude.Length; i++)
            {
                for (int j = 0; j < 18; j++)
                {
                    if (j > 9)
                    {
                        if (j < 18 - exlude[i])
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