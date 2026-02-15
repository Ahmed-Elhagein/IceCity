using System;

namespace IceCity
{
    public class DailyUsage
    {
        private DateTime _date;
        private double _workingHours;
        private HeaterBase _heater;

        public DailyUsage(DateTime date, double hours, HeaterBase heater)
        {
            
            this.Date = date;
            this.WorkingHours = hours;
            this.Heater = heater;
        }

        public DateTime Date
        {
            get { return _date; }
            private set { _date = value; }
        }

        public double WorkingHours
        {
            get { return _workingHours; }

            private set
            {
                
                if (value < 0 || value > 24)
                    throw new ArgumentException("Working hours must be between 0 and 24");

                _workingHours = value;
            }
        }

        public HeaterBase Heater
        {
            get { return _heater; }


            private set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(value), "Heater cannot be null for daily usage.");
                _heater = value;
            }
        }

       
        public double HeaterValue
        {
            get
            { 
                return _heater.CalculateEffectivePower(); 
            }
        }
    }
}