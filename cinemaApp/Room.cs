using System;
using System.Collections.Generic;
using System.Text;

namespace cinemaApp
{
    class Room
    {
        public string[][] room { get; set; }
        public override string ToString()
        {
            string roomString = "";
            foreach(string[] roomArray in room)
            {
                foreach(string rowLine in roomArray)
                {
                    foreach(char seat in rowLine)
                    {
                        roomString += seat;
                    }
                }
                roomString += "\n";
            }
            return roomString;
        }
    }

}
