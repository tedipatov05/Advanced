﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    internal class Engine
    {

        public int Speed { get; set; }
        public int Power { get; set; }

        public Engine(int speed, int power)
        {
            Speed = speed;
            Power = power;
        }
    }
}
