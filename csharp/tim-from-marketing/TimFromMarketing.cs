using System;

static class Badge
{
    public static string Print(int? id, string name, string? department)
    {
        return $"{(id != null ? $"[{id}] - " : null)}{name} - {department?.ToUpper() ?? "OWNER"}";
    }
}
