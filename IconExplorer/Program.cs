using System;
using System.IO;

namespace IconExplorer
{
    class Program
    {
    
        static void Main(string[] args)
        {
            try
            {
                int userInput = 0;
                while (userInput != 7)
                {
                    userInput = DisplayMenu();
                    switch (userInput)
                    {
                        case 1:
                            Episode1.CreateKeyStore();
                            break;
                        case 2:
                            Episode1.DisplayBalance();
                            break;
                        case 3:
                            Episode1.SendICX();
                            break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Something went wrong! Going back to Main Menu {e.ToString()}");
                DisplayMenu();
            }
        }

        static int DisplayMenu()
        {
            Console.WriteLine("Choose an option...");
            Console.WriteLine();
            Console.WriteLine("1. Create Keystore");
            Console.WriteLine("2. Show Balance");
            Console.WriteLine("3. Send ICX");
            Console.WriteLine("4. Search Transaction");
            Console.WriteLine("5. GET Data from an ICON SCORE");
            Console.WriteLine("6. POST Data to an ICON SCORE");
            Console.WriteLine("7. Exit");
            var result = Console.ReadLine();
            return Convert.ToInt32(result);
        }
    }
}
