using System;

namespace Knab.Application.TaskScheduler
{
    public class HangFireTaskSchedulerOptions
    {
        public int RateApiMonthlyRequestLimit { get; set; }
        public int ListingApiMonthlyRequestLimit { get; set; }

        public TimeSpan RateApiMonthlyRequestLimitTimeSpan => CalculateRateLimit(RateApiMonthlyRequestLimit);

        public TimeSpan ListingApiMonthlyRequestLimitTimeSpan => CalculateRateLimit(ListingApiMonthlyRequestLimit);

        public HangFireTaskSchedulerOptions()
        {
        }

        public HangFireTaskSchedulerOptions(int rateApiMonthlyRequestLimit = 250,
            int listingApiMonthlyRequestLimit = 10000)
        {
            RateApiMonthlyRequestLimit = rateApiMonthlyRequestLimit;
            ListingApiMonthlyRequestLimit = listingApiMonthlyRequestLimit;
        }

        private static TimeSpan CalculateRateLimit(double value)
        {
            byte level = 0;
            while (true)
            {
                value /= GetRateLimitLevel(level);

                if (value <= 1)
                {
                    return RateLimitTimeSpan(1 / value, level);
                }

                level++;
            }
        }

        private static double GetRateLimitLevel(byte level) =>
            level switch
            {
                // days
                0 => DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month),
                // hours
                1 => 24,
                // minutes
                2 => 60,
                // seconds
                3 => 60,
                // milliseconds
                4 => 1000,
                _ => -1
            };

        private static TimeSpan RateLimitTimeSpan(double value, byte level) =>
            level switch
            {
                0 => TimeSpan.FromDays(value),
                1 => TimeSpan.FromHours(value),
                2 => TimeSpan.FromMinutes(value),
                3 => TimeSpan.FromSeconds(value),
                4 => TimeSpan.FromMilliseconds(value),
                _ => TimeSpan.Zero
            };
    }
}