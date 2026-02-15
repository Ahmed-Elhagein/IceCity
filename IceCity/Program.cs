using System;
using System.Data;


namespace IceCity
{
  
    class Program
    {
        static void Main(string[] args)
        {
           
            Service1 calcService = new Service1();
            Report reporter = new Report(calcService);

            Console.WriteLine("--- IceCity - Week 2 OOP ---");
            Console.Write("Enter Owner Name: ");
            Owner owner = new Owner(Console.ReadLine());
            House house = new House(owner);

           
            for (int i = 1; i <= 2; i++)
            {
                Console.WriteLine("Day " + i + ":");
                Console.Write("Choose Heater Type (1 for Electric, 2 for Gas): ");
                string choice = Console.ReadLine();

                Console.Write("Enter Power Value: ");

                // = Convert.ToDouble(Console.ReadLine());

                double power = GetValidInput($"Enter Heater Value in Day ({i + 1}): ", "Error!! Heater Value must be a positive number.", 0, double.MaxValue);

                Console.Write("Enter Working Hours (0-24): ");

                //double hours = Convert.ToDouble(Console.ReadLine());

                double hours = GetValidInput($"Enter Hours Per Day ({i + 1}): ", "Error!! Hours must be between 0 and 24.", 0, 24);


                HeaterBase selectedHeater;

                if (choice == "1")
                {
                    selectedHeater = new ElectricHeater(power);
                }
                else
                {
                    selectedHeater = new GasHeater(power);
                }


               
                DailyUsage usage = new DailyUsage(DateTime.Now, hours, selectedHeater);
                house.AddDailyUsage(usage);

                Console.Clear(); 
            }

          
            Console.WriteLine("----------------------------------");
            string finalReport = reporter.GetFinalReport(house);
            Console.WriteLine(finalReport);
            Console.WriteLine("----------------------------------");

           
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        
        public static double GetValidInput(string message, string errorMessage, double min, double max)
        {
            double userInput;
            bool isValid = false;

            do
            {
                Console.Write(message);


                if (double.TryParse(Console.ReadLine(), out userInput) && userInput >= min && userInput <= max)
                {
                    isValid = true;
                }
                else
                {
                    Console.WriteLine(errorMessage);
                    isValid = false;
                }

            } while (!isValid);

            return userInput;
        }




    }
}