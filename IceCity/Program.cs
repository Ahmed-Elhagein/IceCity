using System;
using System.Collections.Generic;

namespace IceCity
{
    class Program
    {
        static void Main(string[] args)
        {
           
            SimulationRepository simulator = new SimulationRepository();
            Service1 service = new Service1();
            Report report = new Report(service);

            
            

            Console.WriteLine("========================================");
            Console.WriteLine("   IceCity: Smart Heating Cost System   ");
            Console.WriteLine("========================================");

            int year = InputReader.GetValidInteger("Enter Year (e.g. 2026): ", 2000, 2100);
            int month = InputReader.GetValidInteger("Enter Month (1-12): ", 1, 12);

            Console.WriteLine($"\n[System] Running simulation for: {month}/{year}...");
            Console.WriteLine($"[System] Days in month: {DateTime.DaysInMonth(year, month)} days.");
            Console.WriteLine("----------------------------------------\n");

           
            List<Owner> owners = simulator.GetSimulatedData(year, month);

            foreach (Owner owner in owners)
            {
                Console.WriteLine($"Owner: {owner.Name}");

                foreach (House house in owner.Houses)
                {
                   
                    string result = report.GetFinalReport(house);

                    Console.WriteLine($"  -> {result}");
                }
                Console.WriteLine("---------------------------------------------------------------------------------------------");
            }

            Console.WriteLine("\nDone. Press any key to exit...");
            Console.ReadKey();
        }
    }
}