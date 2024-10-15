using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrishnyanAstro.Shared.Helpers
{

    public static class StringHelper
    {
        public static string Capitalize(string input)
        {
            if (string.IsNullOrEmpty(input)) return input;
            return char.ToUpper(input[0]) + input.Substring(1);
        }
        // ... other string manipulation helper methods
    }
}
