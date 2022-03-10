using System;

namespace TrainAsk1.ConsoleApp1;

class Program
{
    static void Main(string[] args)
    {
        int seqCounter = 0;
        int entityCounter = 0;

        using StreamWriter file = new(path: @"C:\test");
        // Read the file and display it line by line.  
        foreach (string line in System.IO.File.ReadLines(@"c:\test.txt"))
        {
            // System.Console.WriteLine(line);
            if (line.StartsWith(">"))
            {
                if (entityCounter > 0)
                {
                    System.Console.WriteLine(""); // WriteLine adds a newline character to the end of whatever is written
                    file.WriteLine("");
                }
                // System.Console.Write($"{Environment.NewLine}"); // Write a newline character, appropriate depending on the environment
                entityCounter++;
                System.Console.WriteLine(line);
                file.WriteLine(line);
            }
                
            else
                System.Console.Write(line); // Write just writes what we specified without a newline character.
                file.WriteLine(line);
                seqCounter++;
        }
        file.Close();
        System.Console.WriteLine("There were {0} entities.", entityCounter);
        System.Console.WriteLine("There were {0} sequences.", seqCounter);
        // Suspend the screen.  
        System.Console.ReadLine(); // This makes sure the console waits for our Enter input before the text disappears.
    }
}

