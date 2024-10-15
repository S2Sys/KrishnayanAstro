using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrishnyanAstro.Shared.Exceptions
{
    public class AstrologyCalculationException : Exception
    {
        public AstrologyCalculationException(string message) : base(message) { }
        public AstrologyCalculationException(string message, Exception inner) : base(message, inner) { }
    }
}
