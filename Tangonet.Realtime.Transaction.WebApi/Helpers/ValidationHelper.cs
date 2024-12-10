namespace Tangonet.Realtime.Transaction.WebApi.Helpers;

public static class ValidationHelper
{
    public static bool IsDateFormat(string date)
    {
        return DateTime.TryParse(date, out _);
    }

    public static bool IsNumberFormat(string number)
    {
        return int.TryParse(number, out _);
    }

    public static bool IsAlphaNumericFormat(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return false;
        }

        bool hasLetter = false;
        bool hasDigit = false;

        foreach (char c in input)
        {
            if (char.IsLetter(c))
            {
                hasLetter = true;
            }
            else if (char.IsDigit(c))
            {
                hasDigit = true;
            }

            if (hasLetter && hasDigit)
            {
                return true;
            }
        }

        return false; 
    }

    public static bool IsGuidFormat(string guid)
    {
        return Guid.TryParse(guid, out _);
    }
}
