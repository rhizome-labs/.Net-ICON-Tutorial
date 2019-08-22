using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace IconExplorer
{
 
    public class Utils
    {
        static readonly DateTime EpochBase = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified);
        public static double Loop2ICX(BigInteger? balance, double powerOf = 0)
        {
            double y = 18;

            if (powerOf > 0)
            {
                y = powerOf;
            }

            var d = (double)balance;
            var result = 1 * d / Math.Pow(10, y);
            return result;
        }


        public static DateTime FromEpoch(long epoch)
         => EpochBase.AddMilliseconds(epoch);


    }
}
