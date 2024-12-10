using static Tangonet.Realtime.Transaction.WebApi.Dtos.TransactionDto;

namespace Tangonet.Realtime.Transaction.WebApi.Models;

public class SampleData
{
    private static readonly Random _random = new();

    private static readonly List<string> TransactionIds =
    [
        "5c2b0fe2-f945-4085-a619-d1f7cc74a6a6",
        "d1f736ff-9517-49ff-9d1e-5a321907623b",
        "8b07c542-bc97-432f-8352-f5ed35acdbbe",
        "d8f3a2f5-e82c-41b3-b244-f4b9468ae658",
        "92fd9b24-bfa2-4442-95f6-cd9b2dbf7ac1",
        "bbe4a0fc-493d-4c90-b3ad-d0576e3a2767",
        "e586ae48-9f5f-4609-bd86-cfd9d79b0398",
        "4d6a36b3-6e89-48b9-86cf-bcb81e736d0f",
        "8c1a3f80-79a3-4629-92d7-4a29b8be93a1",
        "3c85c4db-dfbf-4ff0-9f91-e98c3a4d506b",
        "38b59322-392d-429e-a9b5-5207ff4ad0d7",
        "6b11d1d4-bba7-4878-b5e5-d5e6c4b80660",
        "a4c12f76-1e34-4721-bb96-5062f437f4f5",
        "c038cb5b-ef39-429b-9e68-29a41285e21c",
        "a7c71239-5b26-4268-bb3a-b43a26be7461",
        "28712ad0-6c9d-47c4-9a45-4352b875f27d",
        "9a1d69cd-f3d1-464a-b5b7-ea4ffb9b313f",
        "4c58e9c6-e1d1-463d-8f60-731c9b87de8f",
        "a0b03d8a-4c75-4626-9be0-0cd84e3d6a15",
        "e2e50384-4a16-4ca6-800d-52be1d014f4e",
        "60e9c23a-5328-4f8b-8d71-60f0a6fd61fe",
        "34d9e9a5-8c27-4f9f-bb1b-e7b34325f5a9",
        "3df17367-1c0d-477f-b346-bb5b3d3d9e52",
        "c72474bb-550d-41d2-b35b-93db4f3455db",
        "d01a73be-88f9-44a9-831d-bd40d7f4cc77",
        "3d15a342-1f52-4f0e-9013-f90c459f9e97",
        "9203702d-72c2-44e3-b745-3d4e1d76b2e7",
        "c14b648b-941f-406f-95f7-b5e9981fc605",
        "f72a6798-b95f-4b1b-bd34-9074b50334ae",
        "fd62c912-8fdb-4b68-9730-19e4f21c7ec4",
        "2a88dcbf-e497-4d3b-9d38-97f1b24ea0ed",
        "6f3956ff-83a2-49ab-bc87-3f009c6c4a6d",
        "6f321033-51f9-4f5c-9437-e4c9a9fe9d97",
        "218c7d17-40cf-4376-85d4-b6f5b5cf29b2",
        "8a69e60c-92a0-44f8-bd37-d035a520d8f0",
        "7d90ecda-66c3-48a1-b65a-9d4c89196ac0",
        "0049b26c-5a8e-4b0f-b6b1-df8f2044a207",
        "b07d9b39-baf7-4f42-bf19-9e1d13a8e493",
        "e924d4d1-3541-47ff-a7f1-bd4431a68a33",
        "24f9074b-b518-4fe1-a786-f88ff1301b7f",
        "4b54344f-d423-4b89-bad1-59c3b800c567",
        "0fa056fc-2fd0-48e4-a746-c0a4d944ec6e",
        "d7a4472f-9c74-473b-b544-57501f937a4f",
        "0ad42f0c-fc8a-4022-9b70-6e40b2a34c81",
        "6c823453-6cbb-4799-bff7-b78b9e4565a6",
        "5a89f4a7-2b68-4204-82bc-b6fe9f8e5a31",
        "61b74577-55de-40e5-b22e-4192dbe9f764",
        "dbeb86a1-f1a6-4a78-9c60-85c77b8a699f",
        "0a9411a1-73b4-4fc2-9736-742a27abfc1d",
        "5bbf5d29-512b-4637-b9c5-d14907e405ff",
        "6c1c5153-96d7-4304-b703-12c3b199444b",
        "ec0f7c35-1b57-44e7-b467-c7f8f5b8538f",
        "e51e1108-b77b-4b26-bb3c-96cf36a493cb",
        "5cd55088-40a5-4635-941d-cb51e23816d5",
        "0c72438b-2f36-465b-a8cc-b5ac9499d5c6",
        "f8ba84c0-bd62-4db0-b9f2-b038f5fdf69f",
        "1e5a73d7-64c2-44a1-b595-28b99475a3f3",
        "7b5ac1d5-dc98-44bc-8c9f-51719f115b87",
        "bb5372d0-0b66-40a1-8d0c-9ff861def6d1",
        "deea271f-18cf-4503-b85d-4a77d3be9e3f",
        "58fd61f2-5663-4d64-8f42-b9e09b66c5e1",
        "7f94ef43-bac3-4b93-9f4b-bcf8798b2cd5",
        "12ec8702-c0db-4f84-9a42-62ac506ab8a2",
        "6a3d1f7f-d9e4-4681-b38d-d8b5383bb712",
        "039b8535-61ca-4192-b07f-62bb94db5bc0",
        "e5f7e02d-2c4d-46f1-909e-896b78cb7c94",
        "06003f0f-cf53-4532-8bdf-8e71772f20e7",
        "d47963ca-1a38-4268-a69a-9356b6db3022",
        "2c516d07-e195-4b92-a5e1-56883c861f68",
        "9c8d9e7b-80cc-450b-8834-f2f5ea52904b",
        "8b2011f5-f3fe-4d27-81f5-c72fa8b6823f",
        "e74298b2-d5f5-4e7b-87bc-98b8eb6c42b2",
        "b0ff7b37-1576-4d6e-82d7-256a35a6ac64",
        "dfaaf16a-6df7-4535-8b89-8e3bbfd337a0",
        "438bf05a-0728-4e7c-84c9-b5ff73d0eeb0",
        "08c99331-1ab3-4632-91e5-b43175a9b37f",
        "3c6e35e1-98f7-4d6b-86ae-b3e07d8ca946",
        "b140e80b-b47b-4e50-bf5f-1b6c87669c2c",
        "f7ca8b53-f81a-462b-bc5c-902a52be2a2c",
        "d45c9515-c0f3-470d-9ff0-73e4f21271c9",
        "9da16738-df32-4374-8b79-44f074b4e9a0",
        "2e8e62a0-f06e-4b51-a2a1-7c7bcfc95702",
        "52c5be42-cd39-4e07-a5e9-cb4de5eebfa0",
        "ed09863f-d28a-4ab0-a0c7-f26fd144a428",
        "19798779-b7a0-4d2b-9d4b-d0c67b3d2726",
        "b3ffeb57-b2c0-46b9-96a5-5b1709cbf4be",
        "17e79910-fc5f-48cc-b1e0-d0494a82f7c7",
        "24dbdf74-2d39-4e69-9b19-b91b7fa78d25",
        "81d8467f-2320-42b4-bcd6-d9053877ebee",
        "f17413c3-df2d-4b2a-b1b3-5a7bcf5a1fbb",
        "e6d80d9b-b7c3-474b-907f-82317856e592",
        "a245fd6d-7241-4e2b-b385-0b16548b15e3",
        "07906e7b-67b6-4787-90b4-5401b74b178f",
        "f5f4b472-9d2b-451d-8686-d7b393b56a67",
        "62f277b7-8c9d-4557-8353-e06a4da98750",
        "8d45a347-0c6f-4f8a-b349-92c47d4d1d7e",
        "7da1c870-91f8-45b4-bc8f-e827ecdf8f90",
        "8750dcb3-548d-4c99-8752-500c2ea080fe",
        "c4db8b92-c1e1-44a0-9939-8b8c5c72fa0a",
        "ee0307b1-bc8b-41a5-9d28-57fc57e4b6a6",
        "d8633f30-b4c5-4fd8-8b7f-0ea3628c801b",
        "3b3d8f47-f8e7-4f4e-9d90-c12fa98610b2",
        "dfb393e3-c53a-4c3d-b6ec-df4b9a915b89",
        "a7501a33-ea75-42d9-b51f-baddf6785b7a",
        "1e92c02b-f4c0-49ca-b347-3dfb087e57d5",
        "b577e647-6ea3-488a-bf96-e5eb3514ec99",
        "6b1843f1-b570-4567-b6bb-0da3ad6eac7b",
        "b76c94d3-8a23-45f9-b0c9-71b1ad48e309",
        "7c8f0d9a-d7cf-44fd-9ff7-84b0dcb2670a",
        "048015cb-15d7-4162-b4e2-b909d8855d5b",
        "42ec34eb-9e2c-4c72-b0da-b7d586a0c3e0",
        "a960ae69-2647-4c76-8cfc-dff920a19862",
        "d13d90c2-3ea4-4f74-8b07-5917fbc5fcb7",
        "6fd450c8-6c89-4e57-8f7f-7f71ab1a53b6",
        "f3fa592e-f845-48d0-b5fd-c0a4d98f5363",
        "19993a83-c575-47e5-8e5c-87be34950678",
        "4a51d0f6-e98e-4c25-80d2-8de7b9f0d8d6",
        "8659de0a-575b-4044-9a0c-77993cdb6112",
        "af38c8ae-3d8f-4da9-b5c1-0b7e5b6cc088",
        "86b45b8f-10d0-47ea-95db-bd201af3e5ad",
        "f25b30a9-32cf-42ac-b107-e94349ae13ff",
        "0c5d35b7-f8e9-47b5-bb0d-e080c3e2c700",
        "8f85c1ff-d67e-4fd5-bc25-0399260a79c9",
        "0c90e8e0-2cf9-48da-8007-cd0de84f6049"
    ];


    private static readonly List<string> TerminalIds =
    [
        "terminal-001", "terminal-002", "terminal-003", "terminal-004", "terminal-005",
        "terminal-006", "terminal-007", "terminal-008", "terminal-009", "terminal-010"
    ];

    public static ResponseDto GetSampleResponse(
        string fromDate, string toDate = null)
    {
        var transactions = new List<TransactionDetailDto>();
        var random = new Random();

        DateTime parsedFromDate = DateTime.Parse(fromDate);
        DateTime fromDateUtc = TimeZoneInfo.ConvertTimeToUtc(parsedFromDate);
        DateTime parsedToDate = string.IsNullOrWhiteSpace(toDate) ? DateTime.UtcNow : DateTime.Parse(toDate);

        for (int i = 0; i < 250; i++)
        {
            var transactionDate = DateTime.UtcNow.AddDays(-random.Next(1, 30)).AddSeconds(random.Next(0, 86400));
            var statusUpdatedDate = DateTime.UtcNow.AddDays(-random.Next(1, 30)).AddSeconds(random.Next(0, 86400));

            if (transactionDate >= fromDateUtc && transactionDate <= parsedToDate &&
                statusUpdatedDate >= fromDateUtc && statusUpdatedDate <= parsedToDate)
            {
                decimal transactionAmount = Math.Round(random.NextDecimal(1, 1000), 2);
                decimal transactionFee = Math.Round(random.NextDecimal(0.1m, 50), 2);
                string transactionType = GetRandomTransactionType();

                var discretionaryData = new DiscretionaryDataDto();

                if (transactionType == "BPY")
                {
                    int billCount = random.Next(1, 5); 
                    discretionaryData.BillPay = [];

                    decimal totalBillAmount = 0;
                    decimal totalBillFee = 0;

                    for (int j = 0; j < billCount; j++)
                    {
                        decimal billAmount = Math.Round(random.NextDecimal(1, 1000), 2);
                        decimal billFee = Math.Round(random.NextDecimal(0.1m, 50), 2);

                        discretionaryData.BillPay.Add(new BillPayDto
                        {
                            Biller = GenerateBillerName(),
                            ReferenceNumber = GenerateReferenceNumber(),
                            BillAccountNumber = GenerateBillAccountNumber(),
                            Amount = billAmount,
                            Fee = billFee
                        });

                        totalBillAmount += billAmount;
                        totalBillFee += billFee;
                    }
                    transactionAmount = totalBillAmount;
                    transactionFee = totalBillFee;
                }

                if (transactionType == "RSND")
                {
                    discretionaryData.RemittanceSend =
                [
                    new()
                    {
                        Receiver = GenerateReciverName(),
                        ReceiveMethod = GetRandomReceiveMethod(),
                        ReferenceNumber = GenerateReferenceNumber(),
                        Amount = transactionAmount,
                        Fee = transactionFee
                    }
                ];
                }

                if (transactionType == "TKTP")
                {
                    int ticketCount = random.Next(1, 10);
                    var tickets = new List<TicketDto>();

                    for (int j = 0; j < ticketCount; j++)
                    {
                        tickets.Add(new TicketDto
                        {
                            TicketUid = Guid.NewGuid().ToString(),
                            TicketId = GenerateTicketId(),
                            TicketAllocated = true,
                            TicketRedeemedSuccessfully = random.Next(0, 2) == 1,
                            TicketCreatedDateTime = DateTime.UtcNow,
                            TicketCompletedDateTime = DateTime.UtcNow.AddDays(-random.Next(1, 30)),
                            TicketStatus = GetRandomTicketStatus(),
                            FaceValue = random.Next(1, 100),
                            Notes = GetRandomTicketNote()
                        });
                    }

                    discretionaryData.PlayTicket =
                [
                    new()
                    {
                        TicketCount = ticketCount,
                        Tickets = tickets
                    }
                ];
                }

                TimeZoneInfo easternTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
                DateTime transactionDateEastern = TimeZoneInfo.ConvertTimeFromUtc(transactionDate, easternTimeZone);

                transactions.Add(new TransactionDetailDto
                {
                    TransactionUid = TransactionIds[random.Next(TransactionIds.Count)],
                    TransactionId = $"TRN{random.Next(100000, 999999)}",
                    Terminald = TerminalIds[random.Next(TerminalIds.Count)],
                    TransactionDttm = transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss"),
                    Amount = transactionAmount,
                    Fee = transactionFee,
                    Currency = GetRandomTransactionCurreny(),
                    TransactionType = transactionType,
                    Status = GetRandomTransactionStatus(),
                    DiscretionaryData = discretionaryData
                });
            }
        }

        return new ResponseDto
        {
            Transactions = transactions,
            TotalRecordsFound = transactions.Count
        };
    }

    private static string GenerateTicketId()
    {
        int numericPart = _random.Next(100000, 999999);
        return $"CYYDDD{numericPart:D6}"; 
    }

    private static string GenerateReciverName()
    {
        int numericPart = _random.Next(1,99);
        return $"User {numericPart}";
    }
    private static string GenerateBillerName()
    {
        int numericPart = _random.Next(1, 99);
        return $"Biller {numericPart}";
    }

    private static char GetRandomTicketStatus()
    {
        char[] states = ['R', 'V', 'E']; 
        return states[_random.Next(states.Length)]; 
    }

    private static string GetRandomTransactionStatus()
    {
        string[] states = ["X", "V", "C"];
        return states[_random.Next(states.Length)];
    }

    private static string GetRandomTransactionType()
    {
        string[] states = ["BPY", "RSND", "TKTP"];
        return states[_random.Next(states.Length)];
    }

    private static string GetRandomTransactionCurreny()
    {
        string[] states = ["USD", "EUR", "GBP", "JPY", "AUD", "CAD", "CHF", "CNY", "NZD", "SEK"];
        return states[_random.Next(states.Length)];
    }

    private static string GenerateBillAccountNumber()
    {
        int lastFourDigits = _random.Next(1000, 10000); 
                                                        
        string maskedPart = new('*', 12); 
                                                 
        return $"{maskedPart}{lastFourDigits:D4}"; 
    }

    private static string GenerateReferenceNumber()
    {
        int firstPart = _random.Next(0, 10); 
        int secondPart = _random.Next(0, 10); 
        return $"FLTP1:{firstPart}:{secondPart}";
    }

    private static string GetRandomReceiveMethod()
    {
        string[] receiveMethods = ["10 Min Service", "1 Day Service", "2 Day Service", "3 Day Service"];
        return receiveMethods[_random.Next(receiveMethods.Length)];
    }

    private static string GetRandomTicketNote()
    {
        string[] notes =
        {
            "Ticket purchased successfully.",
            "Please keep this ticket safe.",
            "This ticket is valid for one entry.",
            "Check the date and time of your event.",
            "No refunds or exchanges.",
            "Enjoy your event!",
            "This ticket is non-transferable.",
            "Lost tickets cannot be replaced.",
            "Present this ticket at the entrance.",
            "Thank you for your purchase!"
        };

        return notes[_random.Next(notes.Length)]; 
    }
}

public static class RandomExtensions
{
    public static decimal NextDecimal(
        this Random random, decimal minValue, decimal maxValue)
    {
        decimal range = maxValue - minValue;
        decimal sample = (decimal)random.NextDouble();
        return minValue + sample * range;
    }
}
