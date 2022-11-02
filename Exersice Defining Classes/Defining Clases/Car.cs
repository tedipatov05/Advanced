using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DefiningClasses
{
    internal class Car
    {
        public string Model { get; set; }
        
        public Engine Engine { get; set; }

        public Cargo Cargo { get; set; }

        public List<Tire> Tires { get; set; }

       public Car(string model, Engine engine, Cargo cargo)
       {
            Model = model;
            Engine = engine;
            Cargo = cargo;
            Tires = new List<Tire>(4);
       }


    }
}
