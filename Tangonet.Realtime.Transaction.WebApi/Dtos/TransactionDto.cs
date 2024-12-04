namespace Tangonet.Realtime.Transaction.WebApi.Dtos;

#nullable enable
public class TransactionDto
{
    public class ResponseDto
    {
        public int TotalRecordsFound { get; set; }
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
        public string? Biller { get; set; }
        public string? ReferenceNumber { get; set; }
        public string? BillAccountNumber { get; set; }
        public decimal Amount { get; set; }
        public decimal Fee { get; set; }
    }
    public class RemittanceSendDto
    {
        public string? Receiver { get; set; }
        public string? ReceiveMethod { get; set; }
        public string? ReferenceNumber { get; set; }
        public decimal Amount { get; set; }
        public decimal Fee { get; set; }
    }
    public class PlayTicketDto
    {
        public int? TicketCount { get; set; }
        public List<TicketDto>? Tickets { get; set; } = [];
    }

    public class TicketDto
    {
        public bool TicketAllocated { get; set; }
        public string? TicketUid { get; set; }
        public string? TicketId { get; set; }
        public bool TicketRedeemedSuccessfully { get; set; }
        public DateTime? TicketCreatedDateTime { get; set; }
        public DateTime? TicketCompletedDateTime { get; set; }
        public char? TicketStatus { get; set; }
        public int? FaceValue { get; set; }
        public string? Notes { get; set; }

    }
}
