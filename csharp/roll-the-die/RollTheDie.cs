using System;

public class Player
{
    private Random _random = new Random();

    public int RollDie()
    {
        return _random.Next(1, 19);
    }

    public double GenerateSpellStrength()
    {
        return _random.NextDouble() * 100;
    }
}
