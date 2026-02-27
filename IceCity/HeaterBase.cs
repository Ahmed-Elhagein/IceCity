
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCity
{
    public abstract class HeaterBase
    {
       
        public string HeaterId { get; private set; } = Guid.NewGuid().ToString();

        
        public event HeaterEventHandler OpenHeater;
        public event HeaterDurationHandler CloseHeater;

        
        private DateTime? _lastOpenTime;

        

        private double _power;

        public double Power
        {
            get { return _power; }
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

       

        public void Open()
        {
            
            if (new Random().Next(1, 100) <= 20)
            {
                throw new HeaterFailedException($"Critical Failure: Heater {HeaterId} has failed!");
            }

            _lastOpenTime = DateTime.UtcNow;

           
            OpenHeater?.Invoke(this, new HeaterEventArgs { Heater = this });
        }


        public abstract HeaterBase CreateReplacement();

        public void Close()
        {
            if (_lastOpenTime == null) return; 

           
            double duration = (DateTime.UtcNow - _lastOpenTime.Value).TotalSeconds;

            _lastOpenTime = null; 

            
            CloseHeater?.Invoke(this, new HeaterDurationEventArgs { Heater = this, HoursWorked = duration });
        }
    }
}




