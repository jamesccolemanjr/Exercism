using System.Diagnostics.Metrics;

public class RailFenceCipher
{
    private int _numRails;
    private string[] _rails;

    public RailFenceCipher(int rails)
    {
        _numRails = rails;
        _rails = new string[rails];
    }

    public string Encode(string input)
    {
        bool ascending = true;
        int row = 0;
        for (int i = 0; i < input.Length; i++)
        {
            
            _rails[row] += input[i];
            UpdateRowNum(ref ascending, ref row);
        }
        return ConcatRails();

    }

    public string Decode(string input)
    {
        throw new NotImplementedException("You need to implement this method.");
    }

    private string ConcatRails()
    {
        string cipherText = "";
        foreach (string rail in _rails)
        {
            cipherText += rail;
        }
        return cipherText;
    }

    private void UpdateRowNum(ref bool ascending, ref int rowNum)
    {
        if (ascending)
        {
            if (rowNum + 1 < _numRails)
            {
                rowNum++;
            } else
            {
                ascending = false;
                rowNum--;
            }
        } else
        {
            if (rowNum - 1 >= 0)
            {
                rowNum--;
            } else
            {
                ascending = true;
                rowNum++;
            }
        }
    }
}