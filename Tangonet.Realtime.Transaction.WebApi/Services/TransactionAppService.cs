﻿using Tangonet.Realtime.Transaction.WebApi.Dtos;
using Tangonet.Realtime.Transaction.WebApi.Interfaces;
using Tangonet.Realtime.Transaction.WebApi.Models;

namespace Tangonet.Realtime.Transaction.WebApi.Services;

public class TransactionAppService(ILogger<TransactionAppService> logger) : ITransactionAppService
{
    private readonly ILogger<TransactionAppService> _logger = logger;
    public TransactionDto.ResponseDto GetTransactionAsync(
        string fromDate, string toDate, string transactionId, string lastTransactionIdPassed, string batchSize)
    {
        _logger.LogInformation("Received GetTransactionAsync request");

        try
        {
            var sampleResponse = SampleData.GetSampleResponse(
                fromDate, toDate);
            var transactions = sampleResponse.Transactions;
            var totalTransactions = sampleResponse.TotalRecordsFound;

            var filteredTransactions = transactions.AsQueryable();

            if (!string.IsNullOrEmpty(transactionId))
            {
                filteredTransactions = filteredTransactions.Where(t => t.TransactionUid.Equals(transactionId, StringComparison.OrdinalIgnoreCase));
            }

            if (DateTime.TryParse(fromDate, out var fromDateParsed))
            {
                DateTime toDateParsed = DateTime.UtcNow;

                if (!string.IsNullOrEmpty(toDate) && !DateTime.TryParse(toDate, out toDateParsed))
                {
                    toDateParsed = DateTime.UtcNow;
                }

                filteredTransactions = filteredTransactions.Where(t =>
                    DateTime.Parse(t.TransactionDttm) >= fromDateParsed &&
                    DateTime.Parse(t.TransactionDttm) <= toDateParsed);
            }

            if (!string.IsNullOrEmpty(lastTransactionIdPassed))
            {
                filteredTransactions = filteredTransactions.Where(t => string.Compare(t.TransactionUid, lastTransactionIdPassed, StringComparison.OrdinalIgnoreCase) > 0);
            }

            int maxTransactions = 50;
            if (int.TryParse(batchSize, out var batchSizeParsed))
            {
                maxTransactions = Math.Min(batchSizeParsed, 500); 
            }

            var resultTransactions = filteredTransactions
                .Take(maxTransactions)
                .ToList();

            var responseDto = new TransactionDto.ResponseDto
            {
                Transactions = resultTransactions,
                TotalRecordsFound = totalTransactions
            };

            return responseDto;
        }
        catch (Exception ex)
        {
            _logger.LogError(
                ex, "Error processing GetTransactionAsync request");
            throw;
        }
    }
}
