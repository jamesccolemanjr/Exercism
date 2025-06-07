using System.Diagnostics;

static class AssemblyLine
{
    const double carsPerUnitSpeed = 221f;

    static Dictionary<int, double> speedDictionary = new Dictionary<int, double>
    {
        { 0, 0 },
        { 1, 1.0 },
        { 2, 1.0 },
        { 3, 1.0 },
        { 4, 1.0 },
        { 5, 0.9 },
        { 6, 0.9 },
        { 7, 0.9 },
        { 8, 0.9 },
        { 9, 0.8 },
        { 10, 0.77 }
    };

    public static double SuccessRate(int speed)
    {
        foreach(KeyValuePair<int, double> speedEntry in speedDictionary)
        {
            if (speedEntry.Key == speed)
            {
                return speedEntry.Value;
            } 
        }

        throw new Exception($"We don't have success data for speed ({speed}).");
    }
    
    public static double ProductionRatePerHour(int speed)
    {
        return speed * carsPerUnitSpeed * SuccessRate(speed);
    }

    public static int WorkingItemsPerMinute(int speed)
    {
        double carsPerMinute = (carsPerUnitSpeed * speed * SuccessRate(speed))/ 60;
        return (int)carsPerMinute;
    }
}
