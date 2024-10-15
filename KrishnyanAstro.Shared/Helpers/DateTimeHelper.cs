namespace KrishnyanAstro.Shared.Helpers
{
    public static class DateTimeHelper
    {
        public static DateTime ConvertToIndianTime(DateTime utcDateTime)
        {
            return TimeZoneInfo.ConvertTimeFromUtc(utcDateTime,
                TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"));
        }
        // ... other date/time related helper methods
    }
}
