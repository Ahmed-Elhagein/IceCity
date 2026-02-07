namespace IceCity
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            StartProcessing();

        }


        
        public static double CalculateWorkingTime(List<double> hoursPerDays)
        {
            var sum = 0d; 
            foreach (var item in hoursPerDays)
            {
                sum += item;
            }
            return sum;
        }

        public static void BubbleSort(List<double> heaterValues)
        {
            
            for (int i = 0; i < heaterValues.Count - 1; i++)
            {
                for (int j = heaterValues.Count - 1; j > i; j--)
                {
                    if (heaterValues[j] < heaterValues[j - 1])
                    {
                        double temp = heaterValues[j];
                        heaterValues[j] = heaterValues[j - 1];
                        heaterValues[j - 1] = temp;
                    }
                }
            }
        }

        public static double GetMedianHeaterValue(List<double> heaterValues)
        {
            BubbleSort(heaterValues);
            var medianIndex = heaterValues.Count / 2;
            return heaterValues[medianIndex];
        }

        public static double CalculateMonthlyAverageCost(List<double> heaterValues, List<double> hoursPerDays)
        {
            double medianHeaterValue = GetMedianHeaterValue(heaterValues);
            double workingTime = CalculateWorkingTime(hoursPerDays);

           
            double averageCost = medianHeaterValue * (workingTime / (24 * 30));
            return averageCost;
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


        public static void StartProcessing()
        {
            Console.Write("Enter Owner Name : ");

            string OwnerName = Console.ReadLine();
            List<double> HeaterValues = new List<double>(30);
            List<double> HoursPerDays = new List<double>(30);


            for (int i=0;i<30;i++)
            {

                double heaterValue = GetValidInput($"Enter Heater Value in Day ({i + 1}): ","Error!! Heater Value must be a positive number.",0,double.MaxValue);

                HeaterValues.Add(heaterValue);



                double hoursPerDay = GetValidInput($"Enter Hours Per Day ({i + 1}): ","Error!! Hours must be between 0 and 24.", 0,24);
                HoursPerDays.Add(hoursPerDay);

            }

            double AverageCost = CalculateMonthlyAverageCost(HeaterValues, HoursPerDays);
            Console.WriteLine("Monthly Average Cost : " + AverageCost);

        }


    }
    
}
