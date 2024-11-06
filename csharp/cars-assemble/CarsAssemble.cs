using System;

static class AssemblyLine
{
    public static double SuccessRate(int speed)
    {
        return speed switch
        {
            10 => .77,
            9 => .80,
            >= 5 and <= 8 => .90,
            >= 1 => 1,
            _ => .0
        };
    }

    public static double ProductionRatePerHour(int speed)
    {
        return 221 * speed * SuccessRate(speed);
    }

    public static int WorkingItemsPerMinute(int speed)
    {
        return (int)(ProductionRatePerHour(speed) / 60);
    }
}
