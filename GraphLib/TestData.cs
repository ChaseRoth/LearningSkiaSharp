using System;
using System.Collections.Generic;
using System.Text;

namespace GraphLib
{
    public static class TestData
    {
        public static List<Tank> Tanks = new List<Tank>
        {
            new Tank
            {
                Weight = 10,
                Speed = 1
            },
            new Tank
            {
                Weight = 8,
                Speed = 2
            },
            new Tank
            {
                Weight = 7,
                Speed = 3
            },
            new Tank
            {
                Weight = 6,
                Speed = 5
            },
            new Tank
            {
                Weight = 5,
                Speed = 5
            },
            new Tank
            {
                Weight = 3,
                Speed = 7
            },
            new Tank
            {
                Weight = 1,
                Speed = 9
            },
        };
    }

    public class Tank
    {
        public int Weight { get; set; }
        public int Speed { get; set; }
    }
}
