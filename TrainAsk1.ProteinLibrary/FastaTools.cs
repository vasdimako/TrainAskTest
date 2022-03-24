namespace TrainAsk1.ProteinLibrary
{
    public static class FastaTools
    {
        //Read proteins, write proteins with options. Maybe get paths from console etc.
        public static List<Protein> ReadFasta(string inputPath)
        {
            var proteins = new List<Protein>();
            Protein fastaItem = null; //It's a ReferenceType not a variable.
            //That means we can't just define the variable type, we have to null.

            foreach (string line in System.IO.File.ReadLines(inputPath))
            {
                if (line.StartsWith(">"))
                {
                    fastaItem = new Protein(line.Substring(startIndex: 4, length: 6), line.Substring(1));
                    proteins.Add(fastaItem);
                }

                else
                {
                    if (fastaItem != null)
                    {
                        fastaItem.Sequence += line;
                    }
                }
            }
            return proteins;
        }

        public static void WriteFasta(List<Protein> proteins, string outputDir, string splitQ, int maxChars)
        {
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            if (splitQ == "Y")
            {
                foreach (var f in proteins)
                {
                    var outputPath = $"{outputDir}/{f.Name}.fasta";
                    StreamWriter file = new(path: outputPath, append: true);
                    file.WriteLine($">{f.Description}");
                    WriteSeqLine(file, f.Sequence, maxChars);
                    file.Close();
                }
            } else
            {
                var outputPath = $"{outputDir}/allProteins.fasta";
                StreamWriter file = new(path: outputPath);

                foreach (var f in proteins)
                {
                    file.WriteLine($">{f.Description}");
                    WriteSeqLine(file, f.Sequence, maxChars);
                }
                file.Close();
            }

        }
        private static void WriteSeqLine(StreamWriter file, string sequence, int maxChars)
        {
            if (maxChars == 0)
            {
                file.WriteLine($"{sequence}");
            }
            else
            {
                int charCounter = 0;
                foreach (var amino in sequence)
                {
                    file.Write(amino);
                    charCounter++;
                    if (charCounter == maxChars)
                    {
                        file.WriteLine("");
                        charCounter = 0;
                    }
                }
            }
        }
    }
}