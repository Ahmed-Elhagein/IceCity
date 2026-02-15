using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCity
{
    public class ElectricHeater : HeaterBase
    {
        public ElectricHeater(double power) : base(power) { }

        public override double CalculateEffectivePower()
        {
            return this.Power ; 
        }
    }
}
