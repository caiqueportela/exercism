using System;
using System.Linq;

public static class Isogram
{
    public static bool IsIsogram(string word)
    {
        var letters = word.ToLower().Where(Char.IsLetter);
        return letters.Count() == letters.Distinct().Count();
    }
}
