using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCity
{
    public class Owner
    {
        private string _name;

        public string Name
        {
            get 
            {
                return _name;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value)) 
                {

                    throw new ArgumentException("Name required");

                }
                    
                _name = value;
            }
        }

        

        private readonly List<House> _houses;

        public IReadOnlyCollection<House> Houses
        {
            get
            {
                return _houses.AsReadOnly();
            }
        }


        public Owner(string name)
        {
            Name = name;
            _houses = new List<House>();
        }

        public void AddHouse(House house)
        {
            if (house == null)
                throw new ArgumentNullException(nameof(house));

            if (house.Owner != this)
                throw new InvalidOperationException("House does not belong to this owner.");

            if (_houses.Contains(house))
                throw new InvalidOperationException("House already added.");


            _houses.Add(house); 
        }
    }
}
