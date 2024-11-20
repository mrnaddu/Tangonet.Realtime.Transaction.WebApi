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

    public static bool IsTransactionState(string transactionState)
    {
        if (string.IsNullOrEmpty(transactionState))
        {
            return false;
        }
        transactionState = transactionState.ToUpper();

        return transactionState == "C" || transactionState == "Y" || transactionState == "P";
    }

    public static bool IsGuidFormat(string guid)
    {
        return Guid.TryParse(guid, out _);
    }
}
