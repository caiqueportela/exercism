using System;
using System.Linq;

public static class Pangram
{
    public static bool IsPangram(string input) => input.ToLower().ToCharArray().ToList().Where(char.IsLetter).Distinct().Count() == 26;
}
