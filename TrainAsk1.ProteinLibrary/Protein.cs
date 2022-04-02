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

        public string _sequence;
        public string Sequence
        {
            get
            {
                return _sequence;
            }
            set
            {
                _sequence = value;
                string uniqueAminos = new(_sequence.Distinct().ToArray());
                _alphabet = new();

                foreach (char amino in uniqueAminos)
                {
                    int freq = Sequence.Count(f => (f == amino));
                    _alphabet.Add(amino, freq);
                   _alphabet2[amino - 65] = freq;
                   _alphabet3[65] = new List<int>();
                   Sequence.Contains("ADEDSFD");
                }

            }
        } //It gets rid of this error.

        private int[] _alphabet2 = new int[26];
        private List<List<int>> _alphabet3 = new List<List<int>>();


        private Dictionary<char, int> _alphabet;
        public Dictionary<char, int> Alphabet => _alphabet;
        public Protein(string name, string description)
        {
            Name = name;
            Description = description;
        }

        // public Dictionary<char, int> Alphabet { get {
        //         return CountAminos(Sequence);
        //     } 
        // }

        public int CountSeq()
        {
            return Sequence.Length;
        }

        public int GetCountOfAnAminoAcid(char aminoAcid)
        {
            if (aminoAcid >= 'A' && aminoAcid <= 'Z')
                return _alphabet2[aminoAcid - 65];

            return -1;

            // if (_alphabet == null) return -1;
            // int count;
            // if (_alphabet.TryGetValue(aminoAcid, out count))
            // {
            //     return count;
            // }
            // return 0;
        }
    }
}
