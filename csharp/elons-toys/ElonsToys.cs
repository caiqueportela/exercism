using System;

class RemoteControlCar
{
    private int _distance = 0;
    private int _batery = 100;

    public static RemoteControlCar Buy()
    {
        return new RemoteControlCar();
    }

    public string DistanceDisplay()
    {
        return $"Driven {_distance} meters";
    }

    public string BatteryDisplay()
    {
        return _batery == 0 ? "Battery empty" : $"Battery at {_batery}%";
    }

    public void Drive()
    {
        if (_batery == 0) return;

        _distance += 20;
        _batery -= 1;
    }
}
