using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ARevillaSearchFight.Models
{
    public class ModelTermSearchResult
    {
        public string SearchEngineName { get; set; }

        public int Count { get; set; }

        public string Term { get; set; }
    }
}
