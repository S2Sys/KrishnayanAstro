using KrishnyanAstro.Core.Entities;
using KrishnyanAstro.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrishnyanAstro.Core.Services
{
    public class HoroscopeService : IHoroscopeService
    {
        private readonly IHoroscopeRepository _horoscopeRepository;

        public HoroscopeService(IHoroscopeRepository horoscopeRepository)
        {
            _horoscopeRepository = horoscopeRepository;
        }

        public async Task<Horoscope> GetDailyHoroscopeAsync(string sign, DateTime date)
        {
            return await _horoscopeRepository.GetDailyHoroscopeAsync(sign, date);
        }

        public async Task<IEnumerable<Horoscope>> GetWeeklyHoroscopeAsync(string sign)
        {
            var startDate = DateTime.Today;
            var endDate = startDate.AddDays(7);
            return await _horoscopeRepository.GetHoroscopesForPeriodAsync(sign, startDate, endDate);
        }
    }
}
