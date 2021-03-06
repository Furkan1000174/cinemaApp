using System;
using System.Collections.Generic;
using System.Text;

namespace cinemaApp
{
    class Reservation
    {
        public int ID { get; set; }
        public string Item { get; set; }
        public double Price { get; set; }


        public Reservation(int id, string item, double price)
        {
            ID = id;
            Item = item;
            Price = price;
        }



        public override string ToString()
        {
            return string.Format("----------\n{1}\nPrice: €{2}\n----------\n", ID, Item, Price);
        }
    }
}
