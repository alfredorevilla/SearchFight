using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ORevillaSearchFight
{
    public sealed class ArgumentNullOrEmptyException : ArgumentException
    {
        public ArgumentNullOrEmptyException(string name) : base("Argument cannot be null or empty", name)
        {
        }

        public ArgumentNullOrEmptyException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}