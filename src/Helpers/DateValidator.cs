using System.Globalization;

namespace DotnetCQRS.Helpers
{
    public class DateValidator
    {
       public static bool ValidateFormat(DateTime date, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (date == default || date == DateTime.MinValue || date == DateTime.MaxValue)
            {
                errorMessage = "Invalid date format. Please use 'yyyy-MM-dd'.";
                return false;
            }

            return true;
        }
    }
}