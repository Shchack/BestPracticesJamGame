using System;

public static class DateTimeExtensions
{
    public static string ToDayTimeText(this DateTime dateTime)
    {
        return dateTime.ToString("HH:mm");
    }
}
