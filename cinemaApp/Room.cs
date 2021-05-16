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
            return room.ToString();
        }
    }

}
