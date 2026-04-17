using System.Collections.Generic;

namespace IceCity
{
    public interface ICostCalculationStrategy
    {
        double CalculateTotalHours(List<DailyUsage> usages);
        double CalculateMedian(List<double> heaterValues);
        double CalculateCost(List<DailyUsage> usages);
    }
}