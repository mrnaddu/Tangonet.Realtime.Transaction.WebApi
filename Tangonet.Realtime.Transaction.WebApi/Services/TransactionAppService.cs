using System.Text.Json;
using System.Text.Json.Serialization;
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
    IMapper mapper,
    ConnectionHelper connectionHelper) : ITransactionAppService
{
    private readonly ILogger<TransactionAppService> _logger = logger;
    private readonly IMapper _mapper = mapper;
    private readonly ConnectionHelper _connectionHelper = connectionHelper;
    public async Task<TransactionDto.ResponseDto> GetTransactionAsync(
        string fromDate, string toDate, string transactionId, string maxCount, string transactionState, string terminalId)
    {
        _logger.LogInformation("Received GetTransactionAsync request");

        try
        {
            var (transactions, remainingTransactions) = await FetchTransactionsAsync(
                fromDate, toDate, transactionId, maxCount, transactionState, terminalId);
            return CreateResponseDto(transactions);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error processing GetTransactionAsync reques");
            return null; // Consider returning an error response DTO instead
        }
    }

    private async Task<(List<TransactionEntities.TransactionDetail> transactions, List<TransactionEntities.TransactionDetail> remainingTransactions)>
        FetchTransactionsAsync(
        string fromDate, string toDate, string transactionId, string maxCount, string transactionState, string terminalId)
    {
        var parameters = CreateTransactionParameters(
            fromDate, toDate, transactionId,maxCount,transactionState,terminalId);

        return await GetTransactionsAsync(
            Environment.GetEnvironmentVariable("DbOffice"),
            Environment.GetEnvironmentVariable("GetTransactionSnapshot"),
            parameters);
    }

    private async Task<(List<TransactionEntities.TransactionDetail> transactions, List<TransactionEntities.TransactionDetail> remainingTransactions)>
        GetTransactionsAsync(string database, string storedProcedure, object parameters)
    {
        await using var conn = new MySqlConnection(await _connectionHelper.GetRdsDatabaseConnectionString(database));

        try
        {
            await conn.OpenAsync();
            _logger.LogInformation(
                $"Database: {database}, Stored Procedure: {storedProcedure}, Parameters: {JsonSerializer.Serialize(parameters)}");

            var transactions = await FetchTransactionsFromDatabase(conn, storedProcedure, parameters);
            _logger.LogInformation(
                $"Data retrieved successfully from {database} using procedure: {storedProcedure}.");

            return SplitTransactions(transactions);
        }
        catch (Exception ex)
        {
            _logger.LogError(
                $"Error executing procedure {storedProcedure} in {database}: {ex.Message}.");
            throw; 
        }
        finally
        {
            await conn.CloseAsync();
            _logger.LogInformation(
                $"Closing connection to {database}.");
        }
    }

    private static async Task<List<TransactionEntities.TransactionDetail>> FetchTransactionsFromDatabase(
        MySqlConnection conn, string storedProcedure, object parameters)
    {
        return (await conn.QueryAsync<TransactionEntities.TransactionDetail>(
            storedProcedure,
            parameters,
            commandType: System.Data.CommandType.StoredProcedure)).AsList();
    }

    private static (List<TransactionEntities.TransactionDetail> transactions, List<TransactionEntities.TransactionDetail> remainingTransactions)
        SplitTransactions(List<TransactionEntities.TransactionDetail> transactions)
    {
        var displayedTransactions = transactions.Take(50).ToList();
        var remainingTransactions = transactions.Skip(50).ToList();
        return (displayedTransactions, remainingTransactions);
    }

    private static object CreateTransactionParameters(
        string fromDate,string toDate,string transactionId,string maxCount,string transactionState,string terminalId) => new
    {
        p_fromDateTime = fromDate,
        p_toDateTime = toDate,
        p_transactionId = transactionId,
        p_maxCount = maxCount,
        p_transactionState = transactionState,
        p_terminalId = terminalId
        };

    private TransactionDto.ResponseDto CreateResponseDto(List<TransactionEntities.TransactionDetail> transactions)
    {
        return new TransactionDto.ResponseDto
        {
            
        };
    }
}
