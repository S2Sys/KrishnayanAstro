using KrishnyanAstro.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrishnyanAstro.Core.Interfaces
{
    public interface IHoroscopeService
    {
        Task<Horoscope> GetDailyHoroscopeAsync(string sign, DateTime date);
        Task<IEnumerable<Horoscope>> GetWeeklyHoroscopeAsync(string sign);
    }
}
