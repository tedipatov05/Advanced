﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    internal class Tire
    {
        public int Age { get; set; }
        public double Pressure { get; set; }  
        
        public Tire(int age, double pressure)
        {
            Age = age;
            Pressure = pressure;
        }
    }
}
