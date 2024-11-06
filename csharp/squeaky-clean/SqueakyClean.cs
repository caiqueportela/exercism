using System;
using System.Collections.Generic;
using System.Text;

public static class Identifier
{
    public static string Clean(string identifier)
    {
        var stringBuilder = new StringBuilder();
        var parts = identifier.ToCharArray();
        char part;

        for (var i = 0; i < parts.Length; i++)
        {
            part = parts[i];

            stringBuilder.Append(part switch
            {
                _ when Char.IsWhiteSpace(part) => '_',
                _ when Char.IsControl(part) => "CTRL",
                _ when part.Equals('-') => Char.ToUpper(parts[++i]),
                _ when Char.IsBetween(part, 'α', 'ω') => default,
                _ when Char.IsLetter(part) => part,
                _ => default,
            });
        }

        return stringBuilder.ToString();
    }
}
