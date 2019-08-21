using IconSDK.Extensions;
using IconSDK.RPCs;
using IconSDK.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace IconExplorer
{
    public static class Episode2
    {

        public static void SearchTransaction()
        {
            Console.WriteLine("Enter the transaction you wish to search for");
            var tx = Console.ReadLine();

            var getTransactionByHash = new GetTransactionByHash(WalletHelper.TestNetUrl);
            var result = getTransactionByHash.Invoke(tx).Result;

            var ticks = NumericHelper.FromEpoch((long)result.Transaction.Timestamp.Value/1000);

            Console.WriteLine($"BlockHeight : {result.BlockHeight}");
            Console.WriteLine($"Transaction Timestamp : {ticks.ToLocalTime().ToString("yyyy-MM-dd, HH:mm:ss")}");
            Console.WriteLine($"Transaction Amount : {NumericHelper.Loop2ICX(result.Transaction.Value.Value)} ICX");
        }
    }
}
