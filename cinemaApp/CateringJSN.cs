using System;
using System.Collections.Generic;
using System.Text;

namespace cinemaApp
{
    class CateringJSN
    {
        public int ID { get; set; }
        public string Food { get; set; }
        public string Drink { get; set; }
        public string Size { get; set; }
        public double Price { get; set; }
        
        
        public CateringJSN(int id, string food, string drink, string size, double price)
        {
            ID = id;
            Food = food;
            Drink = drink;
            Size = size;
            Price = price;
        }
        
        
        public override string ToString()
        {
            return string.Format("\n[{0}]\n----------\nFood: {1}\nDrink: {2}\nSize: {3}\nPrice: €{4}\n\n", ID, Food, Drink, Size, Price);
        }
    }
}
