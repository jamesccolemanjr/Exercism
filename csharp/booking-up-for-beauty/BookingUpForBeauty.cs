static class Appointment
{
    public static DateTime Schedule(string appointmentDateDescription) 
        => DateTime.Parse(appointmentDateDescription);


    public static bool HasPassed(DateTime appointmentDate) 
        => (appointmentDate - DateTime.Now >  TimeSpan.Zero) ? false: true;

    public static bool IsAfternoonAppointment(DateTime appointmentDate) 
        => appointmentDate.Hour >= 12 && appointmentDate.Hour < 18;

    public static string Description(DateTime appointmentDate) 
        => $"You have an appointment on {appointmentDate.ToShortDateString()} {appointmentDate.ToLongTimeString()}.";

    public static DateTime AnniversaryDate() => new DateTime(2025, 9, 15);
}
