using KrishnyanAstro.Core.Entities;

namespace KrishnyanAstro.Core.Interfaces
{
    public interface IHoroscopeRepository
    {
        Task<Horoscope> GetDailyHoroscopeAsync(string sign, DateTime date);
        Task<IEnumerable<Horoscope>> GetHoroscopesForPeriodAsync(string sign, DateTime startDate, DateTime endDate);
        Task AddHoroscopeAsync(Horoscope horoscope);
        Task UpdateHoroscopeAsync(Horoscope horoscope);
    }
}
