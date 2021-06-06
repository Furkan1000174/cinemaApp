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
        public int RoomID;
        public Seat[][] seatRoom { get; set; }
        
        public Room(int roomid, Seat[][] seatroom)
        {
            RoomID = roomid;
            seatRoom = seatroom;
        }











        public override string ToString()
        {
            int row = 1;
            string roomString = "   1  2  3  4  5  6  7  8  9  10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30\n\n";
            foreach(Seat[] roomArray in room)
            {
                if (row.ToString().Length == 1)
                {
                    roomString += row.ToString() + "  ";
                }
                else if (row.ToString().Length == 2)
                {
                    roomString += row.ToString() + " ";
                }
                row += 1;
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
