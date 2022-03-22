int seqCounter = 0;
int entityCounter = 0;
int charCounter;
int fileCounter = 0;
string outputpath;

// Take console inputs for the directories.
Console.WriteLine("Please enter input file path:");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
string inputpath = Console.ReadLine();
Console.WriteLine("Please enter output file name:");
string outputfile = Path.GetFileNameWithoutExtension(Console.ReadLine());
string outputdir = Directory.GetParent(inputpath).ToString();

// Split sequences after a certain amount of characters.
Console.WriteLine("Set maximum number of bases per line (0 for the entire sequence):");
int maxChars = int.Parse(Console.ReadLine());

// Split sequences into separate files.
Console.WriteLine("Split sequences into separate files? Y/N");
string splitQ = Console.ReadLine();

//inputpath = @"C:\testpath\test.fasta";
//outputpath = @"C:\testpath\output.txt";
// If we're not splitting files, set output path to the directory + the file name and
// using StreamWriter open the file to write to.
if (splitQ == "N")
{
    outputpath = outputdir + @"\" + outputfile + ".txt";
}
else
{
    outputpath = outputdir + @"\" + $"{outputfile}{entityCounter + 1}.txt";
}

StreamWriter file = new(path: outputpath, append: true);

// Read the file and display it line by line.
foreach (string line in System.IO.File.ReadLines(inputpath))
{
    // System.Console.WriteLine(line);
    if (line.StartsWith(">"))
    {
        if (entityCounter > 0 && splitQ == "N") // Only do this when writing in one file
        {
            Console.WriteLine(""); // WriteLine adds a newline character to the end of whatever is written
            file.WriteLine("");
        }
        else if (entityCounter > 0)
        {
            file.Close();
            outputpath = outputdir + @"\" + $"{outputfile}{entityCounter + 1}.txt";
            file = new(path: outputpath, append: true);

        }

        // System.Console.Write($"{Environment.NewLine}"); // Write a newline character, appropriate depending on the environment
        System.Console.WriteLine(line);
        file.WriteLine(line);
        entityCounter++;
    }

    else
    {
        if (maxChars == 0)
        {
            System.Console.WriteLine(line);
            file.Write(line);
            seqCounter++;
        }
        else
        {
            charCounter = 0;
            foreach (char c in line)
            {
                System.Console.Write(c);
                file.Write(c);
                charCounter++;
                if (charCounter == maxChars)
                {
                    System.Console.WriteLine("");
                    file.WriteLine("");
                    charCounter = 0;
                }
            }
            seqCounter++;
        }

    }
    //file.Close();
}
file.Close();

System.Console.WriteLine("There were {0} entities.", entityCounter);
System.Console.WriteLine("There were {0} sequences.", seqCounter);
// Suspend the screen.
System.Console.ReadLine(); // This makes sure the console waits for our Enter input before the text disappears.
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.