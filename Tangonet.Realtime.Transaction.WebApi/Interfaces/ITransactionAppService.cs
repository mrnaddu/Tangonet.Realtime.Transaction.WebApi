using Tangonet.Realtime.Transaction.WebApi.Dtos;

namespace Tangonet.Realtime.Transaction.WebApi.Interfaces;

public interface ITransactionAppService
{
    /*    TransactionDto.ResponseDto GetTransactionAsync(
            string fromDate, string toDate, string transactionId, string pageNumber, string pageSize, string maxCount, string transactionState, string terminalId);*/

    TransactionDto.ResponseDto GetTransactionAsync(
        string fromDate, string toDate, string transactionId, string lastTransactionIdPassed, string batchSize);
}
