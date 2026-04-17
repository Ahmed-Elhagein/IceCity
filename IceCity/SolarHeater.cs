namespace IceCity
{
    public class SolarHeater : HeaterBase
    {
        public SolarHeater(double power) : base(power) { }

        
        public override double CalculateEffectivePower()
        {
            return this.Power * 0.7;
        }

      
        public override HeaterBase CreateReplacement()
        {
            return new SolarHeater(this.Power);
        }
    }
}