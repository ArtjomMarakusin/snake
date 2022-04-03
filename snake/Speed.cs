using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace snake
{
    class Speed
    {
        public static int SnSped(int score)
        {
            int speed = 100;
            if (score > 5)
            {
                speed = 85;
            }
            if (score > 10)
            {
                speed = 70;
            }
            if (score > 15)
            {
                speed = 60;
            }
            if (score > 20)
            {
                speed = 50;
            }
            return speed;
        }
    }
}
