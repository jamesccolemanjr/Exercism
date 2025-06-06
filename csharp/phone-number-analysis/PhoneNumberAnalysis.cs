using System.Dynamic;

public static class PhoneNumber
{
    private static int GetCentralOfficeCode(string phoneNumber)
    {
        int centralOfficeCode = Convert.ToInt32(phoneNumber.Substring(4, 3));
        return centralOfficeCode;
    }

    public static int GetAreaCode(string phoneNumber)
    {
        int areaCode = Convert.ToInt32(phoneNumber.Substring(0, 3));
        return areaCode;
    }

    public static (bool IsNewYork, bool IsFake, string LocalNumber) Analyze(string phoneNumber)
    {
        bool IsNewYork = GetAreaCode(phoneNumber) == 212;
        bool IsFake = GetCentralOfficeCode(phoneNumber) == 555;
        string LocalNumber = phoneNumber.Substring(8, 4);

        return (IsNewYork, IsFake, LocalNumber);
    }

    public static bool IsFake((bool IsNewYork, bool IsFake, string LocalNumber) phoneNumberInfo)
    {
        return phoneNumberInfo.IsFake;
    }
}
