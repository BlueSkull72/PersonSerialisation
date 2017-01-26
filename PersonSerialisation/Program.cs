using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PersonSerialisation
{
    class Program
    {
        static void Main(string[] args)
        {
            RunInit();
            ChoiceScreen();
            Console.ReadKey(true);
        }

        private static void ChoiceScreen()
        {
            bool noChoice = true;
            while (noChoice)
            {
                Console.WriteLine("Do you wish to Add or View a registry?");
                string choice = Console.ReadLine().Trim().ToLower();
                switch (choice)
                {
                    case "add":
                        Maternity.Add();
                        noChoice = false;
                        break;
                    case "view":
                        CivilService.Get();
                        noChoice = false;
                        break;
                    default:
                        break;
                }
            }
        }

        private static void RunInit()
        {
            string baseTargetFolder = @"C:\temp\data\PersonSerialisation";
            if (File.Exists(Path.Combine(baseTargetFolder, "Maternity.txt")) == false)
            {
                File.Create(Path.Combine(baseTargetFolder, "Maternity.txt"));
            }
            if (File.Exists(Path.Combine(baseTargetFolder, "CivilService.txt")) == false)
            {
                File.Create(Path.Combine(baseTargetFolder, "CivilService.txt"));
            }
        }
    }
}
