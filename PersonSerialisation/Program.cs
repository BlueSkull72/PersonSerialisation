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
