using System.Text.Json;
using System.Text.Json.Serialization;
using System.Transactions;
using AutoMapper;
using Dapper;
using MySqlConnector;
using Tangonet.Realtime.Transaction.WebApi.Dtos;
using Tangonet.Realtime.Transaction.WebApi.Entities;
using Tangonet.Realtime.Transaction.WebApi.Helpers;
using Tangonet.Realtime.Transaction.WebApi.Interfaces;

namespace Tangonet.Realtime.Transaction.WebApi.Services;

public class TransactionAppService(
    ILogger<TransactionAppService> logger,
    IMapper mapper) : ITransactionAppService
{
    private readonly ILogger<TransactionAppService> _logger = logger;
    private readonly IMapper _mapper = mapper;
    public async Task<TransactionDto.ResponseDto> GetTransactionAsync(
        string fromDate, string toDate, string transactionId, string maxCount, string transactionState, string terminalId)
    {
        _logger.LogInformation("Received GetTransactionAsync request");

        try
        {
            return null;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, 
                "Error processing GetTransactionAsync reques");
            throw;
        }
    }
}
