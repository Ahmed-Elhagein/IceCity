using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCity
{
    public class Service1
    {

        public  double CalculateWorkingTime(List<double> hoursPerDays)
        {
            var sum = 0d;
            foreach (var item in hoursPerDays)
            {
                sum += item;
            }
            return sum;
        }

        private  void BubbleSort(List<double> heaterValues)
        {

            for (int i = 0; i < heaterValues.Count - 1; i++)
            {
                for (int j = heaterValues.Count - 1; j > i; j--)
                {
                    if (heaterValues[j] < heaterValues[j - 1])
                    {
                        double temp = heaterValues[j];
                        heaterValues[j] = heaterValues[j - 1];
                        heaterValues[j - 1] = temp;
                    }
                }
            }
        }

        public double GetMedianHeaterValue(List<double> heaterValues)
        {
            BubbleSort(heaterValues);
            var medianIndex = heaterValues.Count / 2;
            return heaterValues[medianIndex];
        }

        public  double CalculateMonthlyAverageCost(List<DailyUsage >dailyUsages)
        {
            
            double totalWorkingHours = 0;
            List<double> heaterValues = new List<double>();

            foreach (var usage in dailyUsages)
            {
                totalWorkingHours += usage.WorkingHours;
                heaterValues.Add(usage.HeaterValue);
            }

            double medianHeaterValue = GetMedianHeaterValue(heaterValues);

            

            double averageCost = medianHeaterValue * (totalWorkingHours / (24 * 30));
            return averageCost;
        }

    }
}
