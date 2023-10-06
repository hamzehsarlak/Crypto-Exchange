using System;

namespace CryptoExchange.Application.TaskScheduler
{
    public static class Helpers
    {
        public static string ToRecurringCronExpression(this TimeSpan timeSpan)
        {
            return $"{GetPart(timeSpan.Minutes)} {GetPart(timeSpan.Hours)} {GetPart(timeSpan.Days)} * *";
        }

        private static string GetPart(int part) => part == 0 ? "*" : $"*/{part}";
    }
}