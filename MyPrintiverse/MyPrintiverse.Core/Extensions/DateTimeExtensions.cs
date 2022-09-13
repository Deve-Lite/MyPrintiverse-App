namespace MyPrintiverse.Core.Extensions;

public static class DateTimeExtensions
{
    public static DateTime TicksToDateTime(this DateTime dateTime, long ticks) => new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)
                                                                                            .AddMilliseconds(ticks)
                                                                                            .ToLocalTime();
}
