using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ORevillaSearchFight.Views.Models
{
    public class SearchAndFightArgs : EventArgs
    {
        public SearchAndFightArgs(string[] terms)
        {
            this.Terms = terms;
        }

        public string[] Terms { get; }
    }
}