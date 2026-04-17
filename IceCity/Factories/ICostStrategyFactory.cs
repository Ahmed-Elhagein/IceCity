namespace IceCity
{
    public interface ICostStrategyFactory
    {
        ICostCalculationStrategy GetStrategy(string type);
    }
}