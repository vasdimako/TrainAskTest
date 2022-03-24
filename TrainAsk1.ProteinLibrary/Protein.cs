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
        public int CountSeq()
        {
            return Sequence.Length;
        }
        //Class must know how many of each aminoacid the sequence contains.
        //Use a table if that exists.
    }
}
