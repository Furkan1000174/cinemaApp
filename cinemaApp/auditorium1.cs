using System;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace cinemaApp
{
    class auditorium_150
    {
        public static void createRoom()
        {
            string[][] room = new string[14][];
            for (int i = 0; i < room.Length; i++)
            {
                room[i] = new string[12];
            }
            int[] exlude = new int[] { 2, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2, };
            for (int i = 0; i < exlude.Length; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    if (j > 6)
                    {
                        if (j < 12 - exlude[i])
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