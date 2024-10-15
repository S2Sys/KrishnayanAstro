using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrishnyanAstro.Shared.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class ZodiacValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is ZodiacSign zodiacSign)
            {
                return Enum.IsDefined(typeof(ZodiacSign), zodiacSign);
            }
            return false;
        }
    }
}
