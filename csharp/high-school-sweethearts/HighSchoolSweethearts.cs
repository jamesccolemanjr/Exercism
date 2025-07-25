using System.Globalization;

public static class HighSchoolSweethearts
{
    public static string DisplaySingleLine(string studentA, string studentB)
    {
        return $"{studentA.PadLeft(29)} ♡ {studentB.PadRight(29)}";
    }

    public static string DisplayBanner(string studentA, string studentB)
    {
        string heartMessage = $"{studentA} +  {studentB}";
        return $@"
     ******       ******
   **      **   **      **
 **         ** **         **
**            *            **
**                         **
**     {heartMessage}    **
 **                       **
   **                   **
     **               **
       **           **
         **       **
           **   **
             ***
              *";
    }

    public static string DisplayGermanExchangeStudents(string studentA
        , string studentB, DateTime start, float hours)
    {
        CultureInfo gc = new CultureInfo("de-DE");
        return String.Format(gc, "{0} and {1} have been dating since {2:d} - that's {3:N2} hours", studentA, studentB, start, hours);

    }
}
