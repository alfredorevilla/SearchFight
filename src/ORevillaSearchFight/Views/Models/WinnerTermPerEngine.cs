using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchFight.Views.Models
{
    public class WinnerTermPerEngine
    {
        public string Engine { get; set; }
        public string Term { get; set; }
        public int TotalResults { get; set; }
    }
}