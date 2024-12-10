using Tangonet.Realtime.Transaction.WebApi.Dtos;

namespace Tangonet.Realtime.Transaction.WebApi.Interfaces;

public interface ITransactionAppService
{
    TransactionDto.ResponseDto GetTransaction(
        string fromDate, string toDate, string transactionId, string lastTransactionIdPassed, int batchSize);
}
