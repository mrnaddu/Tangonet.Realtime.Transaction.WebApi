using Tangonet.Realtime.Transaction.WebApi.Dtos;
using Tangonet.Realtime.Transaction.WebApi.Interfaces;
using Tangonet.Realtime.Transaction.WebApi.Models;

namespace Tangonet.Realtime.Transaction.WebApi.Services;

public class TransactionAppService(ILogger<TransactionAppService> logger) : ITransactionAppService
{
    private readonly ILogger<TransactionAppService> _logger = logger;

    public TransactionDto.ResponseDto GetTransactionAsync(
    string fromDate, string toDate, string transactionId, string maxCount, string transactionState, string terminalId)
    {
        _logger.LogInformation("Received GetTransactionAsync request");

        try
        {
            var sampleResponse = SampleData.GetSampleResponse(
                fromDate, toDate);

            var transactions = sampleResponse.Transactions;
             
            var filteredTransactions = transactions.AsQueryable();

            if (!string.IsNullOrEmpty(transactionId))
            {
                filteredTransactions = filteredTransactions.Where(t => t.TransactionId.Equals(transactionId, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrEmpty(transactionState))
            {
                filteredTransactions = filteredTransactions.Where(t => t.TransactionState.Equals(transactionState, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrEmpty(terminalId))
            {
                filteredTransactions = filteredTransactions.Where(t => t.TerminalUid.Equals(terminalId, StringComparison.OrdinalIgnoreCase));
            }

            if (DateTime.TryParse(fromDate, out var fromDateParsed))
            {
                DateTime toDateParsed = DateTime.UtcNow; 

                if (!string.IsNullOrEmpty(toDate) && !DateTime.TryParse(toDate, out toDateParsed))
                {
                    _logger.LogWarning("toDate is not in a valid format. Defaulting to current date.");
                    toDateParsed = DateTime.UtcNow; 
                }

                filteredTransactions = filteredTransactions.Where(t =>
                    DateTime.Parse(t.TransactionDttm) >= fromDateParsed &&
                    DateTime.Parse(t.TransactionDttm) <= toDateParsed);
            }

            int maxTransactions = 50; 
            if (int.TryParse(maxCount, out var maxCountParsed))
            {
                maxTransactions = Math.Min(maxCountParsed, maxTransactions);
            }

            var resultTransactions = filteredTransactions.Take(maxTransactions).ToList();

            var remainingTransactions = Math.Max(0, transactions.Count - resultTransactions.Count);

            var responseDto = new TransactionDto.ResponseDto
            {
                Transactions = resultTransactions,
                RemainingTransactions = remainingTransactions
            };

            return responseDto;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error processing GetTransactionAsync request");
            throw;
        }
    }
}
