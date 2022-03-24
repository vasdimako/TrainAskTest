using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainAsk1.ProteinLibrary
{
    public class Protein
    {
        public string Name { get; } = default!; //This means it will definitely be named so it's not nullable.
        public string Description { get; } 
        public string Sequence { get; set; } //It gets rid of this error.
        public Protein(string name, string description)
        {
            Name = name;
            Description = description;
        }
        public Dictionary<char, int> Alphabet { get {
                return CountAminos(Sequence);
            } 
        }
        public int CountSeq()
        {
            return Sequence.Length;
        }

        public Dictionary<char, int> CountAminos(string sequence)
        {
            string uniqueAminos = new string(sequence.Distinct().ToArray());
            Dictionary<char, int> alphabet = new();

            foreach (char amino in uniqueAminos)
            {
                int freq = Sequence.Count(f => (f == amino));
                alphabet.Add(amino, freq);
            }

            return alphabet;
        }

    }
}
