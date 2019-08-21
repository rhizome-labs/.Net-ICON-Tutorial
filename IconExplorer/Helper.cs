using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using IconSDK;
using IconSDK.Account;
using IconSDK.Blockchain;
using IconSDK.RPCs;
using IconSDK.Types;

namespace IconExplorer
{
    public class Helper
    {

        public static Wallet LoadWallet()
        {
            Console.WriteLine("Enter path of your keystore");
            var keyStorePath = Console.ReadLine();

            Wallet wallet = null;
            if (File.Exists(keyStorePath))
            {
                // This path is a file
                Console.WriteLine("Enter password for your Keystore...");
                var keyStorePassword = GetPassword();
                try
                {
                    wallet = Wallet.Load(keyStorePassword, keyStorePath);
                }
                catch (Exception)
                {
                    Console.WriteLine("Unable to open Keystore, did you type the correct password?");
                    LoadWallet();
                }
            }
            return wallet;
        }
        public static string GetPassword()
        {
            string pass = "";
            do
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                // Backspace Should Not Work
                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    pass += key.KeyChar;
                    Console.Write("*");
                }
                else
                {
                    if (key.Key == ConsoleKey.Backspace && pass.Length > 0)
                    {
                        pass = pass.Substring(0, (pass.Length - 1));
                        Console.Write("\b \b");
                    }
                    else if (key.Key == ConsoleKey.Enter)
                    {
                        break;
                    }
                }
            } while (true);

            return pass;
        }
     
        public static Hash32 Transfer(Address to, PrivateKey privateKey, BigInteger amount, BigInteger stepLimit, string Api)
        {
            var builder = new TransferTransactionBuilder
            {
                PrivateKey = privateKey,
                To = to,
                Value = amount,
                StepLimit = stepLimit,
                NID = 3
            };

            var tx = builder.Build();
            var sendTransaction = new SendTransaction(Api);
            return sendTransaction.Invoke(tx).Result;
        }
    }
}
