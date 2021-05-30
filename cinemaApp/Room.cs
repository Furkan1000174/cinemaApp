using System;
using System.Collections.Generic;
using System.Text;

namespace cinemaApp
{
    class Seat
    {
        public int Xcor { get; set; }

        public int Ycor { get; set; }

        public double Price { get; set; }

        public string Icon { get; set; }

        public Seat(string icon,int xcor, int ycor, double price)
        {
            Icon = icon;
            Xcor = xcor;
            Ycor = ycor;
            Price = price;
            
        }

        public override string ToString()
        {
            return string.Format("{0}",Icon,Xcor,Ycor,Price);
        }


    }

    class Room
    {
        public Seat[][] room { get; set; }
        public override string ToString()
        {
            string roomString = "";
            foreach(Seat[] roomArray in room)
            {
                foreach(Seat seat in roomArray)
                {
                    roomString += seat;
                }
                roomString += "\n";
            }
            return roomString;
        }
    }

}
