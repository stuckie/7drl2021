using System;

namespace _7DRL_2021
{
    public class Point
    {
        public Point(int _x, int _y)
        {
            x = _x;
            y = _y;
        }

        double Distance2(Point _b)
        {
            return (((_b.x - x) * (_b.x - x)) + ((_b.y - y) * (_b.y - y)));
        }

        double Distance(Point _b)
        {
            return Math.Sqrt(Distance2(_b));
        }
        
        public int x;
        public int y;
    }
}