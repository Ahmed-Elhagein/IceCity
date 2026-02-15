using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCity
{
    public class GasHeater : HeaterBase
    {
        public GasHeater(double power) : base(power) { }

        public override double CalculateEffectivePower()
        {
            return Power * 0.8; 
        }
    }
}
