using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ORevillaSearchFight.Models
{
    public class ModelTermSearchResult
    {
        public string SearchEngineName { get; set; }

        public long Count { get; set; }

        public string Term { get; set; }
    }
}