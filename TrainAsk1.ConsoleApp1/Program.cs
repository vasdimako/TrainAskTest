using TrainAsk1.ProteinLibrary;

// Take console inputs for the directories.
//string inputPath = InputChecks.GetInput();
//string outputDir = InputChecks.GetOutput(inputPath);
(string splitQ, int maxChars) = InputChecks.GetOptions();

string inputPath = @"C:\testpath\test.fasta";
var outputDir = "C:/testpath/output_vp";

List<Protein> proteins = FastaTools.ReadFasta(inputPath);
FastaTools.WriteFasta(proteins, outputDir, splitQ, maxChars);


foreach (var f in proteins)
{
    Console.WriteLine($"{f.Name}");
}

var sumOfChars = 0;

foreach (var f in proteins)
{
    sumOfChars += f.CountSeq();
}

System.Console.WriteLine("There were {0} entities.", proteins.Count());
System.Console.WriteLine("There were {0} characters.", sumOfChars);
// Suspend the screen.
System.Console.ReadLine(); // This makes sure the console waits for our Enter input before the text disappears.
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.