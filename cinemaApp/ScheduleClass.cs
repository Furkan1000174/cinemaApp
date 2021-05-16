using System;
using System.Collections.Generic;
using System.Text;

namespace cinemaApp
{
    class ScheduleClass
    {
        public string MovieName { get; set; }

        public string[] MovieTimes { get; set; }


        public ScheduleClass(string moviename, string[] movietimes)
        {
              MovieName = moviename;
              MovieTimes = movietimes;
        }

        public override string ToString()
        {
            return string.Format("\nMovie Name: {0}\nMovie Times: {1}");
        }
    }
}
