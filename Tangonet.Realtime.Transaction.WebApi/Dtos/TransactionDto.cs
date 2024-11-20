using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tangonet.Realtime.Transaction.WebApi.Dtos;

#nullable enable
public class TransactionDto
{
    public class RequestDto
    {
        [Required]
        public required string FromDate { get; set; }
        public string? ToDate { get; set; }
        public string? TransactionId { get; set; }
        public string? MaxCount { get; set; }
        public string? TransactionState { get; set; }
        public string? TerminalId { get; set; }
    }

    public class ResponseDto
    {
        public List<TransactionDetailDto> Transactions { get; set; } = [];
        public int RemainingTransactions { get; set; }
    }

    public class TransactionDetailDto
    {
        public string? TransactionId { get; set; }
        public string? TransactionDttm { get; set; }
        public decimal TransactionAmount { get; set; }
        public decimal TransactionFee { get; set; }
        public decimal TotalAmount { get; set; }
        public string? TransactionType { get; set; }
        public string? TransactionCurrency { get; set; }
        public string? TransactionState { get; set; }
        public string? TerminalUid { get; set; }
        public string? PartnerName { get; set; }
        public string? CustomerName { get; set; }
        public string? StatusUpdatedDttm { get; set; }
    }
}
