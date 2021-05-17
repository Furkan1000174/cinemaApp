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
            string row = ""; 
            foreach(string[] roomArray in room)
            {
                foreach(string rowLine in roomArray)
                {
                    row += rowLine;
                }
            }
            return row;
        }
    }

}
