using System.Collections.Generic;

namespace IceCity
{
    public class EcoCostStrategy : StandardCostStrategy
    {
        public override double CalculateCost(List<DailyUsage> usages)
        {
            double standardCost = base.CalculateCost(usages);
            double totalHours = CalculateTotalHours(usages);

           
            if (totalHours < 120)
            {
                return standardCost * 0.90;
            }

            return standardCost;
        }
    }
}