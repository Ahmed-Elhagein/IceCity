
using System;
using System.Collections.Generic;

namespace IceCity
{
    public class House
    {
       
        public string HouseId { get; private set; } = Guid.NewGuid().ToString().Substring(0, 5);

        public Owner Owner { get; }

        private readonly List<DailyUsage> _dailyUsages;
        public IReadOnlyCollection<DailyUsage> DailyUsages
        {
            get { return _dailyUsages.AsReadOnly(); }
        }

       
        private readonly List<HeaterBase?> _heaters;
        public IReadOnlyCollection<HeaterBase?> Heaters
        {
            get { return _heaters.AsReadOnly(); }
        }

        public House(Owner owner)
        {
            if (owner == null)
                throw new ArgumentNullException(nameof(owner));

            Owner = owner;
            _dailyUsages = new List<DailyUsage>();
            _heaters = new List<HeaterBase?>(); 
        }

        public void AddDailyUsage(DailyUsage usage)
        {
            if (usage == null)
                throw new ArgumentNullException(nameof(usage));

            _dailyUsages.Add(usage);
        }

        public void AddHeater(HeaterBase? heater) 
        {
            _heaters.Add(heater);
        }

       
        public void ReplaceHeater(int index, HeaterBase? newHeater)
        {
            if (index >= 0 && index < _heaters.Count)
            {
                _heaters[index] = newHeater;
            }
        }

        public double CalculateHeatingCost(Service1 service)
        {
            if (service == null)
                throw new ArgumentNullException(nameof(service));

            return service.CalculateMonthlyAverageCost(_dailyUsages);
        }
    }
}


