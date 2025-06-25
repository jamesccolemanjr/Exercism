using System.Text;

public static class Identifier
{
    public static string Clean(string identifier)
    {
        StringBuilder stringToClean = new StringBuilder(identifier);

        //Replace spaces with underscores
        stringToClean.Replace(' ', '_');

        //Replace control characters with the upper case string CTRL
        stringToClean.Replace("\0", "CTRL");

        //Loop through string for character adjustments
        for (int i = 0; i < stringToClean.Length; i++)
        {
            //Convert kebob-case to camelCase
            if (stringToClean[i] == '-')
            {
                stringToClean.Remove(i, 1);
                stringToClean[i] = char.ToUpper(stringToClean[i]);
            }
        }

        //Loop through string for character adjustments
        for (int i = 0; i < stringToClean.Length; i++)
        {
            //Remove characters that are not letters
            if (!char.IsLetter(stringToClean[i]))
            {
                if (stringToClean[i] == '_') { continue; }
                stringToClean.Remove(i, 1);
                i--;
            }
        }

        //Loop through string for character adjustments
        for (int i = 0; i < stringToClean.Length; i++)
        {
            //Omit greek lowercase letters
            if (stringToClean[i] >= 'α' && stringToClean[i] <= 'ω')
            {
                stringToClean.Remove(i, 1);
                i--;
            }
        }

        return stringToClean.ToString();
    }
}
