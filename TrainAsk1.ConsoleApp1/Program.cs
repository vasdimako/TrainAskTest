int seqCounter = 0;
int entityCounter = 0;

// Take console inputs for the directories.

Console.WriteLine("Please enter input file path:");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
string inputpath = Console.ReadLine();
Console.WriteLine("Please enter output file name:");
string outputpath = Console.ReadLine();
outputpath = Directory.GetParent(inputpath) + @"\" + "output.txt";

// Split sequences into separate files.
Console.WriteLine("Split sequences into separate files? Y/N");
string splitQ = Console.ReadLine();

if (splitQ == "Y")
{
    file.Close();
    using StreamWriter file = new(path: Directory.GetParent(inputpath) + @"\" + "output{0}.txt", entityCounter);
    // Also have to change the entityCounter > 0 if statement to something that looks at if this is the first file line instead.
}

// To set the number of allowable columns per line, we might need to go character-by-character rather than line by line when we write.
// Or maybe we write it in one line and then go through that line and add newline characters.

inputpath = @"C:\testpath\test.fasta";
outputpath = @"C:\testpath\output.txt";

using StreamWriter file = new(path: outputpath);
// Read the file and display it line by line.
foreach (string line in System.IO.File.ReadLines(inputpath))
{
    // System.Console.WriteLine(line);
    if (line.StartsWith(">"))
    {
        if (entityCounter > 0)
        {
            Console.WriteLine(""); // WriteLine adds a newline character to the end of whatever is written
            file.WriteLine("");
        }

        // System.Console.Write($"{Environment.NewLine}"); // Write a newline character, appropriate depending on the environment
        entityCounter++;
        System.Console.WriteLine(line);
        file.WriteLine(line);
    }

    else
    file.Write(line);
    seqCounter++;
}
file.Close();

System.Console.WriteLine("There were {0} entities.", entityCounter);
System.Console.WriteLine("There were {0} sequences.", seqCounter);
// Suspend the screen.
System.Console.ReadLine(); // This makes sure the console waits for our Enter input before the text disappears.
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.