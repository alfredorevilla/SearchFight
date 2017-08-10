using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SearchFight.Engines.Microsoft
{
    public class BingSearchEngineException : Exception
    {
        public BingSearchEngineException(string message) : base(message)
        {
        }
    }
}