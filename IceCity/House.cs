using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCity
{
    public class House
    {
        public Owner Owner { get; }

        //public List<DailyUsage> DailyUsages { get; private set; }

        private readonly List<DailyUsage> _dailyUsages;

        public IReadOnlyCollection<DailyUsage> DailyUsages
        {
            get
            {
                return _dailyUsages.AsReadOnly();
            }
        }



        private readonly List<HeaterBase> _heaters;

        public IReadOnlyCollection<HeaterBase> Heaters
        {
            get
            {
                return _heaters.AsReadOnly();
            }
        }


        public House(Owner owner)
        {

            if (owner == null)
            {
                throw new ArgumentNullException(nameof(owner));
            }

            Owner = owner;
            _dailyUsages = new List<DailyUsage>();
            _heaters = new List<HeaterBase>();
        }

        public void AddDailyUsage(DailyUsage usage)
        {
            if (usage == null)
                throw new ArgumentNullException(nameof(usage));

            _dailyUsages.Add(usage);
        }

        public void AddHeater(HeaterBase heater)
        {
            if (heater == null)
                throw new ArgumentNullException(nameof(heater));

            _heaters.Add(heater);
        }



        public double CalculateHeatingCost(Service1 service)
        {
            if (service == null)
                throw new ArgumentNullException(nameof(service));

            return service.CalculateMonthlyAverageCost(_dailyUsages);
        }




    }
}