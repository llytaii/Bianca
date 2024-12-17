namespace Bianca;

using SSO = StringSplitOptions;

public static class StringExt
{
    public static bool IsNullOrEmpty(this string? self)
        => string.IsNullOrEmpty(self);

    public static bool IsNullOrWhiteSpace(this string? self)
        => string.IsNullOrWhiteSpace(self);

    public static bool IsReadable(this string? self)
        => !self.IsNullOrEmpty() && !self.IsNullOrWhiteSpace();

    public static string[] SplitTrim(this string self, char separator)
        => self.Split(separator, SSO.TrimEntries | SSO.RemoveEmptyEntries);
}