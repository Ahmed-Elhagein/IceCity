using System.Collections.Generic;

namespace IceCity
{
    public class CostService
    {
        private readonly ICostCalculationStrategy _strategy;

        // Dependency Injection via Constructor
        public CostService(ICostCalculationStrategy strategy)
        {
            _strategy = strategy;
        }

        public double CalculateMonthlyAverageCost(List<DailyUsage> usages)
        {
            return _strategy.CalculateCost(usages);
        }
    }
}