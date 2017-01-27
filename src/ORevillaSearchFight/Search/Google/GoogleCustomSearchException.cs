using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ORevillaSearchFight.Engines.Google
{
    public class GoogleCustomSearchException : Exception
    {
        public GoogleCustomSearchException(string message) : base(message)
        {
        }
    }
}