using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchFight.Views.Models
{
    public class TermSearchResult
    {
        public long Count { get; set; }
        public string SearchEngineName { get; set; }
        public string Term { get; set; }
    }
}