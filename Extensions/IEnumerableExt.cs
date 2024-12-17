namespace Bianca;

public static class IEnumerableExt
{
    public static string Join<T>(this IEnumerable<T> self, char separator, Func<T, string>? selector = null)
    {
        selector ??= x => x?.ToString() ?? string.Empty;
        return string.Join(separator, self.Select(selector));
    }
}