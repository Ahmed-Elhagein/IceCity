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
            if (heaterValues == null || heaterValues.Count == 0) return 0;

            BubbleSort(heaterValues);
            int count = heaterValues.Count;

            
            if (count.IsEven())
            {
                return (heaterValues[count / 2 - 1] + heaterValues[count / 2]) / 2.0;
            }
            else
            {
                return heaterValues[count / 2];
            }
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

            int actualDaysCount = dailyUsages.Count;

            double averageCost = medianHeaterValue * (totalWorkingHours / (24 * actualDaysCount));
            return averageCost;
        }

    }
}
