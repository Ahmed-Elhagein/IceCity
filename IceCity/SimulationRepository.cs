using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCity
{
    public class SimulationRepository
    {

        private Random _random = new Random();

        public List<Owner> GetSimulatedData(int year, int month)
        {
            List<Owner> owners = new List<Owner>();
            int daysInMonth = DateTime.DaysInMonth(year, month);


            Owner owner1 = new Owner("Ahmed (Saver Mode)");
            House house1 = new House(owner1);


            HeaterBase heater1 = new ElectricHeater(1000);
            house1.AddHeater(heater1);


            for (int day = 1; day <= daysInMonth; day++)
            {
                double hours = _random.Next(1, 5);
                house1.AddDailyUsage(new DailyUsage(new DateTime(year, month, day), hours, heater1));
            }

            owner1.AddHouse(house1);
            owners.Add(owner1);



            Owner owner2 = new Owner("Mona (Comfort Mode)");
            House house2 = new House(owner2);
            HeaterBase heater2 = new GasHeater(2500);
            house2.AddHeater(heater2);


            for (int day = 1; day <= daysInMonth; day++)
            {
                double hours = _random.Next(8, 16);
                house2.AddDailyUsage(new DailyUsage(new DateTime(year, month, day), hours, heater2));
            }

            owner2.AddHouse(house2);
            owners.Add(owner2);

            return owners;
        }
    }
}