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
            int row = 0;
            string roomString = "    ";
            Seat[] seatRow = seatRoom[0];
            for(int i = 0;i<seatRow.Length; i++)
            {
                if(i < 10)
                {
                      roomString += $"{i}  ";
                }
                else
                {
                    roomString += $"{i} ";
                }
            }
            roomString += "\n\n";
            foreach(Seat[] roomArray in seatRoom)
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
