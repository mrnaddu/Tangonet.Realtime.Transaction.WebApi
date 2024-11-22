namespace Tangonet.Realtime.Transaction.WebApi.Dtos;

#nullable enable
public class TransactionDto
{
    public class ResponseDto
    {
        public int TotalTransactions { get; set; }
        public List<TransactionDetailDto> Transactions { get; set; } = [];
    }

    public class TransactionDetailDto
    {
        public string? TransactionUid { get; set; }
        public string? TransactionId { get; set; }
        public string? Terminald { get; set; }
        public string? TransactionDttm { get; set; }
        public decimal TransactionAmount { get; set; }
        public decimal TransactionFee { get; set; }
        public string? TransactionCurrency { get; set; }
        public string? TransactionType { get; set; }
        public string? TransactionStatus { get; set; }
        public string? CustomerName { get; set; }
        public DiscretionaryDataDto? DiscretionaryData { get; set; }
    }

    public class DiscretionaryDataDto
    {
        public List<BillPayDto>? BillPay { get; set; }
        public List<RemittanceSendDto>? RemittanceSend { get; set; }
        public List<PlayTicketDto>? PlayTicket { get; set; }
    }

    public class BillPayDto
    {
        public string? BillerName { get; set; }
    }
    public class RemittanceSendDto
    {
        public string? ReceiverName { get; set; }
    }
    public class PlayTicketDto
    {
        public string? TicketId { get; set; }
    }
}
