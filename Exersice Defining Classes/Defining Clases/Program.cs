using System;
using System.Linq;
using System.Collections.Generic;



namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            for(int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ');
                string model = input[0];
                int engineSpeed = int.Parse(input[1]);
                int enginePower = int.Parse(input[2]);

                Engine engine = new Engine(engineSpeed, enginePower);

                int weightCargo = int.Parse(input[3]);
                string typeCargo = input[4];

                Cargo cargo = new Cargo(typeCargo, weightCargo);

                Car car = new Car(model, engine, cargo);
                
                
                for(int j = 5; j < input.Length; j+=2)
                {
                    double tirepress = double.Parse(input[j]);
                    int age = int.Parse(input[j+1]);
                    Tire tire = new Tire(age, tirepress);

                    car.Tires.Add(tire);
                     
                }
                cars.Add(car);
                
               
            }
            string type = Console.ReadLine();
            List<Car> carsOutput = cars.Where(car => car.Cargo.Type == type).ToList();

            if (type == "fagile")
            {
                foreach(Car car in carsOutput)
                {
                    foreach (Tire t in car.Tires)
                    {
                        if(t.Pressure < 1)
                        {
                            Console.WriteLine($"{car.Model}");
                            
                        }
                    }

                }

            }
            else if(type == "flammable")
            {
                foreach(Car c in carsOutput.Where(c => c.Engine.Power >250))
                {
                    Console.WriteLine(c.Model);
                }

            }







        }
    }
}
