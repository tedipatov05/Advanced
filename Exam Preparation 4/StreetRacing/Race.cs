using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace StreetRacing
{
    public class Race
    {
        public Race(string name, string type, int laps, int capacity, int maxHorsePower)
        {
            
            Name = name;
            Type = type;
            Laps = laps;
            Capacity = capacity;
            MaxHorsePower = maxHorsePower;
            Participants = new List<Car>(Capacity);
        }

        public List<Car> Participants { get; set; }

        public string Name { get; set; }    
        public string Type { get; set; }
        public int Laps { get; set; }
        public int Capacity { get; set; }
        public int MaxHorsePower { get; set; }

        public int Count => Participants.Count;

        public void Add(Car car)
        {
            if (Count < Capacity && !Participants.Any(c => c.LicensePlate == car.LicensePlate) && car.HorsePower <= MaxHorsePower)
            {
                Participants.Add(car);
            }
        }
        public bool Remove(string licencePlate)
        {
            Car car = Participants.FirstOrDefault(c => c.LicensePlate == licencePlate);

            return Participants.Remove(car);

        }
        public Car FindParticipant(string licensePlate)
        => Participants.FirstOrDefault(c => c.LicensePlate == licensePlate);
        public Car GetMostPowerfulCar()
        {
            Car mostPowerfulCar = null;
            int maxHorsePower = 0;
            foreach(Car car in Participants)
            {
                if(car.HorsePower >= maxHorsePower)
                {
                    maxHorsePower = car.HorsePower;
                    mostPowerfulCar = car;
                }
            }

            return mostPowerfulCar;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Race: {Name} - Type: {Type} (Laps: {Laps})");
            foreach(Car car in Participants)
            {
                sb.AppendLine(car.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
