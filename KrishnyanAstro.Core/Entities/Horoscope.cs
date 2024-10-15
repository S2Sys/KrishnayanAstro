using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrishnyanAstro.Core.Entities
{
    public class Horoscope
    {
        public int Id { get; set; }
        public string Sign { get; set; }
        public DateTime Date { get; set; }
        public string Prediction { get; set; }
    }
}
