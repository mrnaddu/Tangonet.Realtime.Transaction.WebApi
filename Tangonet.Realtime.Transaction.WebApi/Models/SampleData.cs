using static Tangonet.Realtime.Transaction.WebApi.Dtos.TransactionDto;

namespace Tangonet.Realtime.Transaction.WebApi.Models;

public class SampleData
{
    private static readonly Random _random = new();

    private static readonly List<string> TransactionIds =
    [
        "txn-001", "txn-002", "txn-003", "txn-004", "txn-005",
        "txn-006", "txn-007", "txn-008", "txn-009", "txn-010",
        "txn-011", "txn-012", "txn-013", "txn-014", "txn-015",
        "txn-016", "txn-017", "txn-018", "txn-019", "txn-020",
        "txn-021", "txn-022", "txn-023", "txn-024", "txn-025",
        "txn-026", "txn-027", "txn-028", "txn-029", "txn-030"
    ];

    private static readonly List<string> TerminalIds =
    [
        "terminal-001", "terminal-002", "terminal-003", "terminal-004", "terminal-005",
        "terminal-006", "terminal-007", "terminal-008", "terminal-009", "terminal-010"
    ];

    private static readonly List<TransactionDetailDto> _transactions = [];

    public static ResponseDto GetSampleResponse()
    {
        var transactions = new List<TransactionDetailDto>();

        for (int i = 0; i < 100; i++) 
        {
            transactions.Add(new TransactionDetailDto
            {
                TransactionId = $"txn-{i + 1:D3}", 
                TransactionDttm = DateTime.UtcNow.AddDays(-_random.Next(1, 30)).ToString("o"),
                TransactionAmount = Math.Round(_random.NextDecimal(1, 1000), 2),
                TransactionFee = Math.Round(_random.NextDecimal(0.1m, 50), 2),
                TotalAmount = Math.Round(_random.NextDecimal(1, 1000) + _random.NextDecimal(0.1m, 50), 2),
                TransactionType = _random.Next(0, 2) == 0 ? "S" : "B",
                TransactionCurrency = _random.Next(0, 2) == 0 ? "USD" : "EUR",
                TransactionState = GetRandomTransactionState(),
                TerminalUid = TerminalIds[_random.Next(TerminalIds.Count)],
                PartnerName = $"Partner {_random.Next(1, 6)}",
                CustomerName = $"Customer {_random.Next(1, 20)}",
                StatusUpdatedDttm = DateTime.UtcNow.AddDays(-_random.Next(1, 30)).ToString("o")
            });
        }

        return new ResponseDto
        {
            Transactions = [.. transactions]
        };
    }

    public static List<TransactionDetailDto> SearchTransactions(string transactionId = null, string transactionType = null, string terminalUid = null)
    {
        var query = _transactions.AsQueryable();

        if (!string.IsNullOrEmpty(transactionId))
        {
            query = query.Where(t => t.TransactionId.Equals(transactionId, StringComparison.OrdinalIgnoreCase));
        }

        if (!string.IsNullOrEmpty(transactionType))
        {
            query = query.Where(t => t.TransactionType.Equals(transactionType, StringComparison.OrdinalIgnoreCase));
        }

        if (!string.IsNullOrEmpty(terminalUid))
        {
            query = query.Where(t => t.TerminalUid.Equals(terminalUid, StringComparison.OrdinalIgnoreCase));
        }

        return [.. query];
    }

    private static string GetRandomTransactionState()
    {
        string[] states = { "Y", "P", "C" };
        return states[_random.Next(states.Length)];
    }
}


public static class RandomExtensions
{
    public static decimal NextDecimal(
        this Random random, decimal minValue, decimal maxValue)
    {
        decimal range = maxValue - minValue;
        decimal sample = (decimal)random.NextDouble();
        return minValue + sample * range;
    }
}
