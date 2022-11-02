using System;
using System.Collections.Generic;
using System.Text;

namespace RandomCardGame
{
    public class Card
    {
        public Card(string name)
        {
            this.Name = name;
            Random rnd = new Random();
            double queficent = rnd.Next(1, 1000);
            //1000 - attack * queficent = HP;
            this.Attack = queficent;
            this.HP = Math.Round((1000 - this.Attack), 2);
        }

        public string Name { get; set; }
        public double Attack { get; set; }
        public double HP { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return $"{this.Name}: -== Attack: {this.Attack} HP: {this.HP} ==-";
        }
    }
}
