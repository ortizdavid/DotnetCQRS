namespace DotnetCQRS.Helpers;

public class Generator
{
    public static string GenerateCode(string predicate)
    {
        if (string.IsNullOrWhiteSpace(predicate))
        {
            throw new ArgumentNullException("predicate must have a value", nameof(predicate));
        }
        return $@"{predicate}-{DateTime.Today:yyyyMMddHHmmss}";
    }
}