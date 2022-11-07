using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;

namespace Drones
{
    public class Airfield
    {
        public List<Drone> Drones { get; set; }

        public string Name { get; set; }    
        public int Capacity { get; set; }
        public double LandingStrip { get; set; }

        public Airfield(string name, int capacity, double landingStrip)
        {
            Name = name;
            Capacity = capacity;
            LandingStrip = landingStrip;
            Drones = new List<Drone>();
        }

        public int Count => Drones.Count;

        public string AddDrone(Drone drone)
        {
            if (string.IsNullOrEmpty(drone.Name) || 
                string.IsNullOrEmpty(drone.Brand) ||
                drone.Range<5 || drone.Range>15)
            {
                return "Invalid drone.";
            }
            if(Drones.Count >= Capacity )
            {
                return "Airfield is full";
            }
            Drones.Add(drone);
            return $"Succesfully added {drone.Name} to the airfield";
        }
        public bool RemoveDrone(string name)
        {
            int count = Drones.RemoveAll(dr => dr.Name == name);
            return count > 0;
        }
        public int RemoveDroneByBrand(string brand)
        {
            int count = Drones.RemoveAll(dr => dr.Brand== brand);
            return count;

        }
        public Drone FlyDrone(string name)
        {
            Drone drone = Drones.Where(dr => dr.Name == name).FirstOrDefault();
            if(drone == null)
                return null;
            drone.Available = false;
            return drone;
        }
        public List<Drone> FlyDronesByRange(int range)
        {
            List<Drone> drones =  Drones.Where(dr => dr.Range >= range).ToList();
            drones.ForEach(dr => dr.Available = false);
            return drones;
        }
        public string Report()
        {
            var available = Drones.Where(d => d.Available == true).ToList();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Drones available at {Name}: ");
            sb.AppendLine($"{string.Join(Environment.NewLine, available)}");
            return sb.ToString();
        }


    }
}
