using Tangonet.Realtime.Transaction.WebApi.Dtos;
using Tangonet.Realtime.Transaction.WebApi.Helpers;

namespace Tangonet.Realtime.Transaction.WebApi.Interfaces;

public interface ITransactionAppService
{
    TransactionDto.ResponseDto GetTransactionAsync(
        string fromDate, string toDate, string transactionId, string maxCount, string transactionState, string terminalId);
}
