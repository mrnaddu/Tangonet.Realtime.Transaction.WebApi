namespace Tangonet.Realtime.Transaction.WebApi.Dtos;

#nullable enable
public class TransactionDto
{
    public class ResponseDto
    {
        public int TotalRecordFound { get; set; }
        public List<TransactionDetailDto> Transactions { get; set; } = [];
    }

    public class TransactionDetailDto
    {
        public string? TransactionUid { get; set; }
        public string? TransactionId { get; set; }
        public string? Terminald { get; set; }
        public string? TransactionDttm { get; set; }
        public decimal Amount { get; set; }
        public decimal Fee { get; set; }
        public string? Currency { get; set; }
        public string? TransactionType { get; set; }
        public string? Status { get; set; }
        public string? CustomerName { get; set; }
        public DiscretionaryDataDto? DiscretionaryData { get; set; } = new DiscretionaryDataDto();
    }

    public class DiscretionaryDataDto
    {
        public List<BillPayDto>? BillPay { get; set; } = [];
        public List<RemittanceSendDto>? RemittanceSend { get; set; } = [];
        public List<PlayTicketDto>? PlayTicket { get; set; } = [];
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
