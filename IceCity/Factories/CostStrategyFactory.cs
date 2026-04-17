namespace IceCity
{
   

    public class CostStrategyFactory : ICostStrategyFactory
    {
        public ICostCalculationStrategy GetStrategy(string type)
        {
            
            if (type.Equals("Eco", System.StringComparison.OrdinalIgnoreCase))
            {
                return new EcoCostStrategy();
            }
            return new StandardCostStrategy();
        }
    }
}