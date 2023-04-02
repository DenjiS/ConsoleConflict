using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleConflict
{
    internal static class Randomizer
    {
        private static readonly Random _random = new();

        public static int GenerateNumber(int minValue, int maxValue) =>
            _random.Next(minValue, maxValue);
    }
}
