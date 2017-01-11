using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ARevillaSearchFight.Views.Models
{

    public class TermSearchResult
    {
        public string SearchEngineName { get; set; }

        public int Count { get; set; }

        public string Term { get; set; }
    }
}
