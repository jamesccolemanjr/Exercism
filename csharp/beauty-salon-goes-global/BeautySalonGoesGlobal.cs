using System.Globalization;
using System.Runtime.InteropServices;

public enum Location
{
    NewYork,
    London,
    Paris
}

public enum AlertLevel
{
    Early,
    Standard,
    Late
}

public static class Appointment
{
    public static DateTime ShowLocalTime(DateTime dtUtc)
    {
        return dtUtc.ToLocalTime();
    }

    public static DateTime Schedule(string appointmentDateDescription, Location location)
    {

        DateTime convertedDate = DateTime.Parse(appointmentDateDescription, CultureInfo.InvariantCulture);
        TimeZoneInfo timeZone = GetTimeZone(location);

        return TimeZoneInfo.ConvertTimeToUtc(convertedDate, timeZone);
    }

    private static TimeZoneInfo GetTimeZone(Location location)
    {
        return location switch
        {
            Location.NewYork when RuntimeInformation.IsOSPlatform(OSPlatform.OSX) || RuntimeInformation.IsOSPlatform(OSPlatform.Linux) => TimeZoneInfo.FindSystemTimeZoneById("America/New_York"),
            Location.NewYork when RuntimeInformation.IsOSPlatform(OSPlatform.Windows) => TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"),
            Location.London when RuntimeInformation.IsOSPlatform(OSPlatform.OSX) || RuntimeInformation.IsOSPlatform(OSPlatform.Linux) => TimeZoneInfo.FindSystemTimeZoneById("Europe/London"),
            Location.London when RuntimeInformation.IsOSPlatform(OSPlatform.Windows) => TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time"),
            Location.Paris when RuntimeInformation.IsOSPlatform(OSPlatform.OSX) || RuntimeInformation.IsOSPlatform(OSPlatform.Linux) => TimeZoneInfo.FindSystemTimeZoneById("Europe/Paris"),
            Location.Paris when RuntimeInformation.IsOSPlatform(OSPlatform.Windows) => TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time"),
            _ => throw new NotSupportedException("Unsupported location or operating system.")

        };
    }

    public static DateTime GetAlertTime(DateTime appointment, AlertLevel alertLevel)
    {
        return alertLevel switch
        {
            AlertLevel.Early => appointment.AddDays(-1),
            AlertLevel.Standard => appointment.AddMinutes(-105),
            AlertLevel.Late => appointment.AddMinutes(-30),
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    public static bool HasDaylightSavingChanged(DateTime dt, Location location)
    {
        TimeZoneInfo timeZone = GetTimeZone(location);
        return timeZone.IsDaylightSavingTime(dt) != timeZone.IsDaylightSavingTime(dt.AddDays(-7));
    }

    public static DateTime NormalizeDateTime(string dtStr, Location location)
    {
        try
        {
            return DateTime.Parse(dtStr, location switch
            {
                Location.NewYork => new CultureInfo("en-US"),
                Location.London => new CultureInfo("en-GB"),
                Location.Paris => new CultureInfo("fr-FR"),
                _ => throw new NotSupportedException("Unsupported location.")
            });

        }
        catch
        {
            return new DateTime(1, 1, 1);
        }
    }
}
