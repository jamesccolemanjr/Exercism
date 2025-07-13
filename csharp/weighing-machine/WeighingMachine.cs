class WeighingMachine
{
    public int Precision { get; private set; }

    private double weight;
    public double Weight
    {
        get { return weight; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                weight = value;
            }
        }
    }

    public string DisplayWeight
    {
        get
        {
            double returnWeight = weight - TareAdjustment;
            string format = $"F{Precision}";
            return $"{returnWeight.ToString(format)} kg";
        }
    }

    public double TareAdjustment { get; set; }


    public WeighingMachine(int precision)
    {
        Precision = precision;
        TareAdjustment = 5.0;
    }
}
