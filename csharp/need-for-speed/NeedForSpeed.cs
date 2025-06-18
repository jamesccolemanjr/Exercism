using System.Runtime.CompilerServices;

class RemoteControlCar
{
    private int speed;
    private int batteryPct;
    private int batteryDrain;
    private int distanceDriven;

    // TODO: define the constructor for the 'RemoteControlCar' class
    public RemoteControlCar(int speed, int batteryDrain)
    {
        this.batteryPct = 100;
        this.distanceDriven = 0;
        this.speed = speed;
        this.batteryDrain = batteryDrain;
    }

    public bool BatteryDrained() => batteryPct < batteryDrain;

    public int DistanceDriven() => distanceDriven;

    public void Drive()
    {
        if (!BatteryDrained())
        {
            distanceDriven += speed;
            batteryPct -= batteryDrain;
        }
    }

    public static RemoteControlCar Nitro() => new RemoteControlCar(50, 4);

    public int GetSpeed() => speed;
    public int GetBatteryDrain() => batteryDrain;

}

class RaceTrack
{
    private int distance;

    // TODO: define the constructor for the 'RaceTrack' class
    public RaceTrack(int distance)
    {
        this.distance = distance;
    }

    public bool TryFinishTrack(RemoteControlCar car)
    {
        float drivesRequired = (float)distance / (float)car.GetSpeed();
        float batteryRequired = drivesRequired * car.GetBatteryDrain();
        return batteryRequired <= 100;
    }
}
