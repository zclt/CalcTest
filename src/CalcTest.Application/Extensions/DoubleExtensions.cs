using System;
using System.Collections.Generic;
using System.Text;

namespace CalcTest.Application.Extensions
{
    public static class DoubleExtensions
    {
        public static double Truncate(this double value)
        {
            return Math.Truncate(value * 100) / 100;
        }
    }
}
