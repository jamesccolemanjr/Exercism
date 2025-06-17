class RemoteControlCar
{
    private int _distanceDriven = 0;
    private int _batteryPercentage = 100;

    public static RemoteControlCar Buy()
    {
        return new RemoteControlCar();
    }

    public string DistanceDisplay()
    {
        return $"Driven {_distanceDriven} meters";
    }

    public string BatteryDisplay()
    {
        return (_batteryPercentage <= 0) ? "Battery empty" : $"Battery at {_batteryPercentage}%";
    }

    public void Drive()
    {
        if (_batteryPercentage > 0)
        {
            _distanceDriven += 20;
            _batteryPercentage -= 1;
        }
    }
        
}
