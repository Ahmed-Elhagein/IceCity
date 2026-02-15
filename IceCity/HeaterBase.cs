using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCity
{
    
        public abstract class HeaterBase
        {
            private double _power;

            public double Power
            {
                get 
                {
                   return _power;
                }  

                set
                {
                    if (value <= 0)
                    {
                        throw new ArgumentException("Power must be greater than 0");
                    }
                    
                    _power = value;
                }
            }

            protected HeaterBase(double power)
            {
                Power = power;
            }

            public abstract double CalculateEffectivePower();
        }

}
