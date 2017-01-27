using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ORevillaSearchFight.Views.Models
{
    public class TermSearchResult
    {
        public string SearchEngineName { get; set; }

        public long Count { get; set; }

        public string Term { get; set; }
    }
}