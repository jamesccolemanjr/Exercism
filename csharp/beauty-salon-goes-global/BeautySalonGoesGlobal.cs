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
        TimeZoneInfo timeZone = location switch
        {
            Location.NewYork when RuntimeInformation.OSDescription == "macOS" || RuntimeInformation.OSDescription == "Linux" => TimeZoneInfo.FindSystemTimeZoneById("America/New_York"),
            Location.NewYork when RuntimeInformation.OSDescription == "Windows" => TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"),
            Location.London when RuntimeInformation.OSDescription == "macOS" || RuntimeInformation.OSDescription == "Linux" => TimeZoneInfo.FindSystemTimeZoneById("Europe/London"),
            Location.London when RuntimeInformation.OSDescription == "Windows" => TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time"),
            Location.Paris when RuntimeInformation.OSDescription == "macOS" || RuntimeInformation.OSDescription == "Linux" => TimeZoneInfo.FindSystemTimeZoneById("Europe/Paris"),
            Location.Paris when RuntimeInformation.OSDescription == "Windows" => TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time"),
            _ => throw new NotSupportedException("Unsupported location or operating system")

        };

        return TimeZoneInfo.ConvertTimeToUtc(convertedDate, timeZone);
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
        throw new NotImplementedException("Please implement the (static) Appointment.HasDaylightSavingChanged() method");
    }

    public static DateTime NormalizeDateTime(string dtStr, Location location)
    {
        throw new NotImplementedException("Please implement the (static) Appointment.NormalizeDateTime() method");
    }
}
