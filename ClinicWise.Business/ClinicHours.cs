using System;

namespace ClinicWise.Business
{
    public static class ClinicHours
    {
        public static readonly TimeSpan WeekdayOpen = new TimeSpan(8, 0, 0);
        public static readonly TimeSpan WeekdayClose = new TimeSpan(17, 0, 0);

        public static readonly TimeSpan SaturdayOpen = new TimeSpan(9, 0, 0);
        public static readonly TimeSpan SaturdayClose = new TimeSpan(13, 0, 0);

        public static bool IsWithinBusinessHours(DateTime dateTime)
        {
            var time = dateTime.TimeOfDay;

            switch (dateTime.DayOfWeek)
            {
                case DayOfWeek.Saturday:
                    return time >= SaturdayOpen && time <= SaturdayClose;

                case DayOfWeek.Sunday:
                    return false;

                default:
                    return time >= WeekdayOpen && time <= WeekdayClose;
            }
        }
    }

}
