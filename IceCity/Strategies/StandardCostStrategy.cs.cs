using System;
using System.Collections.Generic;
using System.Linq;

namespace IceCity
{
    public class StandardCostStrategy : ICostCalculationStrategy
    {
        public double CalculateTotalHours(List<DailyUsage> usages)
        {
            return usages.Sum(u => u.WorkingHours);
        }

        public double CalculateMedian(List<double> heaterValues)
        {
            if (heaterValues == null || heaterValues.Count == 0) return 0;

            heaterValues.Sort();
            int count = heaterValues.Count;

            if (count.IsEven())
                return (heaterValues[count / 2 - 1] + heaterValues[count / 2]) / 2.0;
            else
                return heaterValues[count / 2];
        }

        public virtual double CalculateCost(List<DailyUsage> usages)
        {
            if (usages == null || usages.Count == 0) return 0;

            double totalHours = CalculateTotalHours(usages);

            List<double> heaterValues = new List<double>();
            foreach (var u in usages) heaterValues.Add(u.HeaterValue);

            double medianValue = CalculateMedian(heaterValues);

           
            return medianValue * (totalHours / (24 * 30));
        }
    }
}