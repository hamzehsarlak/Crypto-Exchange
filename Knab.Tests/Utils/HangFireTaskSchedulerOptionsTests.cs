using FluentAssertions;
using FluentAssertions.Extensions;
using Knab.Application.TaskScheduler;

namespace Knab.Tests.Utils;

[TestFixture]
public class HangFireTaskSchedulerOptionsTests
{
    [Test]
    public void Monthly_Request_Limit_Should_Be_Correct()
    {
        // 1 request per hour
        var anHour = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month) * 24;
        
        // 1 request per minute
        var aMin = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month) * 24 * 60;
        
        var opt = new HangFireTaskSchedulerOptions(anHour, aMin);
        
        opt.RateApiMonthlyRequestLimitTimeSpan.Should().Be(1.Hours());
        opt.ListingApiMonthlyRequestLimitTimeSpan.Should().Be(1.Minutes());
    }
}