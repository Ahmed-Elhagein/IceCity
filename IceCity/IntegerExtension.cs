using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCity
{
    public static class IntegerExtensions
    {
        public static bool IsEven(this int number) => number % 2 == 0;
        public static bool IsOdd(this int number) => number % 2 != 0;
    }
}
