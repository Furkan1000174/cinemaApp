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
            string roomString = "";
            foreach(Seat[] roomArray in seatRoom)
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
