using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainAsk1.ProteinLibrary
{
    public static class InputChecks
    {
        public static string GetInput()
        {
            Console.WriteLine("Please enter input file path:");
            string inputPath = Console.ReadLine();
            if (String.IsNullOrEmpty(inputPath))
            {
                Console.WriteLine("Current directory used for output.");
                inputPath = Directory.GetCurrentDirectory();
            }

            return inputPath;
        }

        public static string GetOutput(string inputPath)
        {
            Console.WriteLine("Please enter output folder name:");
            string outputFolder = Console.ReadLine();
            string outputPath = inputPath + outputFolder;
            if (String.IsNullOrEmpty(outputFolder))
            {
                Console.WriteLine("Default output directory.");
                outputPath = inputPath + "/output";
            }
            return outputPath;
        }

        public static (string, int) GetOptions()
        {
            Console.WriteLine("Set maximum number of bases per line (0 for the entire sequence):");
            int maxChars = int.Parse(Console.ReadLine());
            Console.WriteLine("Split sequences into separate files? Y/N");
            string splitQ = Console.ReadLine();
            return (splitQ, maxChars);
        }
    }
}
