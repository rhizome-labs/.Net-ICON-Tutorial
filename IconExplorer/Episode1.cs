using System;
using System.IO;
using System.Numerics;
using IconSDK;
using IconSDK.Account;
using IconSDK.Helpers;
using IconSDK.RPCs;
using IconSDK.Types;

namespace IconExplorer
{
    public static class Episode1
    {
        static readonly string TestNetUrl = "https://bicon.net.solidwallet.io/api/v3";
      
        public static void CreateKeyStore()
        {
            var keyStorePath = string.Empty;
            var match = false;

            while (string.IsNullOrWhiteSpace(keyStorePath))
            {
                Console.WriteLine("Enter Path and filename to save Keystore file");
                keyStorePath = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(keyStorePath))
                {
                    Console.WriteLine("File path cannot be blank please try again");
                }
            }

            var keyStorePassword1 = string.Empty;
            var keyStorePassword2 = string.Empty;

            while (!match)
            {
                Console.WriteLine("Enter password for your Keystore...");
                keyStorePassword1 = Console.ReadLine();
                Console.WriteLine("Enter password again for verification");
                keyStorePassword2 = Console.ReadLine();

                if (keyStorePassword1.Equals(keyStorePassword2))
                {
                    match = true;
                }
                else
                {
                    Console.WriteLine("Passwords do not match");
                }
            }


            var wallet = Wallet.Create();
            Console.WriteLine("Creating Keystore please wait...");
            var keyStore = wallet.Store(keyStorePassword1, keyStorePath);

            if (!string.IsNullOrWhiteSpace(keyStore))
            {
                Console.WriteLine($"Keystore file created successfully at : {keyStorePath}");
                Console.WriteLine($"Your public address is : {wallet.Address}");
                Console.WriteLine($"You will need to send ICX to this address to use Marvin");
            }
        }
        public static void DisplayBalance()
        {
          var wallet = Helper.LoadWallet();
          var getBalance = GetBalance.Create(TestNetUrl);
          var balance = getBalance.Invoke(wallet.Address).Result;

          Console.WriteLine($"Your current ICX balance for {wallet.Address} is : {NumericHelper.Loop2ICX(balance)} ICX");
        }

        public static void SendICX()
        {
            var wallet = Helper.LoadWallet();
            Console.WriteLine();
            Console.WriteLine("How much ICX do you want to send?");
            var amount = BigInteger.Parse(Console.ReadLine());
            BigInteger amountToSend = amount * Consts.ICX2Loop;

            Console.WriteLine($"Enter the public address to send {amount}");
            var toAddress = Console.ReadLine();

            BigInteger stepLimit = NumericsHelper.ICX2Loop("0.000000001");
            Hash32 result = Helper.Transfer(toAddress, wallet.PrivateKey, amountToSend, stepLimit, TestNetUrl);

            Console.WriteLine($"Transfer successful tx: {result}");
        }
    }
}
