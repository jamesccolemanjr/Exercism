using System.Diagnostics.Metrics;

public class RailFenceCipher
{
    private int _numRails;
    private string[] _rails;
    private char[,] _decryptArray;

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
        int length = input.Length;
        _decryptArray = new char[_numRails, length];

        bool ascending = true;
        int row = 0;
        for (int i = 0; i < input.Length; i++)
        {
            _decryptArray[row, i] = 'X';
            UpdateRowNum(ref ascending, ref row);
        }

        int inputCount = 0;
        for(int y = 0; y < _decryptArray.GetLength(0); y++)
        {
            for(int x = 0; x < _decryptArray.GetLength(1); x++)
            {
                if( _decryptArray[y, x] == 'X')
                {
                    _decryptArray[y, x] = input[inputCount];
                    inputCount++;
                }
            }
        }

        return TraverseDecryptArray();

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

    private string TraverseDecryptArray()
    {
        string clearText = "";
        for (int x = 0; x < _decryptArray.GetLength(1); x++)
        {
            for (int y = 0; y < _decryptArray.GetLength(0); y++)
            {
                if(_decryptArray[y, x] != '\0')
                clearText += _decryptArray[y, x];
            }
        }
        return clearText;
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