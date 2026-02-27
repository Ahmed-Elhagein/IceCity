using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCity
{


    public class CityCenterService
    {

        public async Task<HeaterBase> RequestReplacementAsync(string houseId, HeaterBase oldHeater)
        {
            Console.WriteLine($"\n[City Center] SOS received from House {houseId}. Heater {oldHeater.HeaterId} has failed!");
            Console.WriteLine("[City Center] Dispatching an exact replacement based on the broken model...");

            await Task.Delay(2000);


            return oldHeater.CreateReplacement();
        }
    }

}