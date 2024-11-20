using System.ComponentModel.DataAnnotations.Schema;

namespace Tangonet.Realtime.Transaction.WebApi.Entities;

#nullable enable
public class Transaction
{
    public class Request
    {
        public required string FromDate { get; set; }
        public string? ToDate { get; set; }
        public string? TransactionId { get; set; }
        public string? MaxCount { get; set; }
        public string? TransactionState { get; set; }
        public string? TerminalId { get; set; }
    }

    public class Response
    {
        public List<TransactionDetail> Transactions { get; set; } = [];
        public int RemainingTransactions { get; set; }
    }

    public class TransactionDetail
    {
        [Column("transaction_id")]
        public string? TransactionId { get; set; }
        [Column("transaction_dttm")]
        public string? TransactionDttm { get; set; }
        [Column("transaction_amount")]
        public decimal TransactionAmount { get; set; }
        [Column("transaction_fee")]
        public decimal TransactionFee { get; set; }
        public decimal TotalAmount { get; set; }
        [Column("transaction_type")]
        public string? TransactionType { get; set; }
        [Column("transaction_currency")]
        public string? TransactionCurrency { get; set; }
        [Column("transaction_status")]
        public string? TransactionState { get; set; }
        [Column("terminal_uid")]
        public string? TerminalUid { get; set; }
        public string? PartnerName { get; set; }
        [Column("customer_name")]
        public string? CustomerName { get; set; }
        [Column("status_updated_dttm")]
        public string? StatusUpdatedDttm { get; set; }
    }
}
