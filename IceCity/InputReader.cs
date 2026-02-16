using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCity
{
    public static class InputReader
    {
        public static int GetValidInteger(string message, int min, int max)
        {
            int userInput;
            bool isValid = false;
            do
            {
                Console.Write(message);
                
                if (int.TryParse(Console.ReadLine(), out userInput) && userInput >= min && userInput <= max)
                {
                    isValid = true;
                }
                else
                {
                    Console.WriteLine($"Error! Please enter a number between {min} and {max}.");
                }
            } while (!isValid);

            return userInput;
        }
    }
}
