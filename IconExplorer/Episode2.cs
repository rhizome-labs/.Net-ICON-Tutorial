using IconSDK.Extensions;
using IconSDK.RPCs;
using IconSDK.Types;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

            var ticks = Utils.FromEpoch((long)result.Transaction.Timestamp.Value / 1000);

            Console.WriteLine($"BlockHeight : {result.BlockHeight}");
            Console.WriteLine($"Transaction Timestamp : {ticks.ToLocalTime().ToString("yyyy-MM-dd, HH:mm:ss")}");

            if (result.Transaction.Value != null)
            {
                Console.WriteLine($"Transaction Amount : {Utils.Loop2ICX(result.Transaction.Value.Value)} ICX");
            }

            var json = JsonConvert.SerializeObject(result.Transaction.Data);
            var data = JsonConvert.DeserializeObject<DataViewer>(json.Replace("params", "param"));

            Console.WriteLine($"Method name: {data?.method}");
            Console.WriteLine($"Value: {data?.param.value}");
        }
    }
}
