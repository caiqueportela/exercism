using System;
using System.Linq;

class BirdCount
{
    private int[] _birdsPerDay;

    public BirdCount(int[] birdsPerDay)
    {
        _birdsPerDay = birdsPerDay;
    }

    public static int[] LastWeek()
    {
        return [ 0, 2, 5, 3, 7, 8, 4 ];
    }

    public int Today()
    {
        return _birdsPerDay[_birdsPerDay.Length-1];
    }

    public void IncrementTodaysCount()
    {
        _birdsPerDay[6] += 1;
    }

    public bool HasDayWithoutBirds()
    {
        return Array.IndexOf(_birdsPerDay, 0) >= 0;
    }

    public int CountForFirstDays(int numberOfDays)
    {
        var count = 0;

        for (var i = 0; i < numberOfDays; i++)
        {
            count += _birdsPerDay[i];
        }

        return count;
    }

    public int BusyDays()
    {
        var count = 0;

        foreach (var birds in _birdsPerDay)
        {
            if (birds >= 5) count++;
        }

        return count;
    }
}
