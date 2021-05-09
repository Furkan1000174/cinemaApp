using System;
using System.Collections.Generic;
using System.Text;

namespace cinemaApp
{
    class CateringJSN
    {
        public int ID { get; set; }
        public string food { get; set; }
        public string drink { get; set; }
        public string size { get; set; }
        public string price { get; set; }
        public override string ToString()
        {
            return string.Format("\n[{0}]\nFood: {1}\nDrink: {2}\nSize: {3}\nPrice(euro): {4}\n\n", ID, food, drink, size, price);
        }
    }
}
