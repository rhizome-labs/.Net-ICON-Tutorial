using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace IconExplorer
{
    public class NumericHelper
    {
        public static double Loop2ICX(BigInteger balance)
        {
            var d = (double)balance;
            var result = 1 * d / Math.Pow(10, 18);
            return result;
        }
    }
}
