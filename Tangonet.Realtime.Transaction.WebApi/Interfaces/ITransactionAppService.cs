using Tangonet.Realtime.Transaction.WebApi.Dtos;

namespace Tangonet.Realtime.Transaction.WebApi.Interfaces;

public interface ITransactionAppService
{
    Task<TransactionDto.ResponseDto> GetTransactionAsync(
        string fromDate, string toDate, string transactionId, string maxCount, string transactionState, string terminalId);
}
