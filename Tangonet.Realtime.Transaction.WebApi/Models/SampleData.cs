using static Tangonet.Realtime.Transaction.WebApi.Dtos.TransactionDto;

namespace Tangonet.Realtime.Transaction.WebApi.Models;

public class SampleData
{
    public static ResponseDto GetSampleResponse(string fromDate, string toDate = null)
    {
        var transactions = new List<TransactionDetailDto>();
        var random = new Random();

        DateTime parsedFromDate = DateTime.Parse(fromDate);
        DateTime fromDateUtc = TimeZoneInfo.ConvertTimeToUtc(parsedFromDate);
        DateTime parsedToDate = string.IsNullOrWhiteSpace(toDate) ? DateTime.UtcNow : DateTime.Parse(toDate);

        if (fromDateUtc > parsedToDate)
        {
            throw new ArgumentException("fromDate cannot be after toDate.");
        }

        var transactionDate = DateTime.UtcNow.AddDays(-random.Next(1, 30)).AddSeconds(random.Next(0, 86400));
        var statusUpdatedDate = DateTime.UtcNow.AddDays(-random.Next(1, 30)).AddSeconds(random.Next(0, 86400));

        bool isTransactionDateInRange = transactionDate >= fromDateUtc && transactionDate <= parsedToDate;
        bool isStatusUpdatedDateInRange = statusUpdatedDate >= fromDateUtc && statusUpdatedDate <= parsedToDate;

        if (isTransactionDateInRange && isStatusUpdatedDateInRange)
        {
            TimeZoneInfo easternTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            DateTime transactionDateEastern = TimeZoneInfo.ConvertTimeFromUtc(transactionDate, easternTimeZone);

            transactions.Add(new TransactionDetailDto
            {
                TransactionUid = "5e316b16-b860-459d-bb11-7dc23f460432",
                TransactionId = $"TRN1000",
                Terminald = "terminal-001",
                TransactionDttm = transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss"),
                Amount = 300,
                Fee = 30,
                Currency = "USD",
                TransactionType = "BPY",
                Status = "C",
                DiscretionaryData = new DiscretionaryDataDto
                {
                    BillPay =
                    [
                        new BillPayDto
                            {
                                Biller = "Biller 1",
                                ReferenceNumber = "FLTP1:0:1",
                                BillAccountNumber = "******** **** 1234",
                                Amount = 100,
                                Fee = 10
                            },
                            new BillPayDto
                            {
                                Biller = "Biller 2",
                                ReferenceNumber = "FLTP1:0:2",
                                BillAccountNumber = "**** **** **** 5678",
                                Amount = 200,
                                Fee = 20
                            }
                    ]
                }
            });

            transactions.Add(new TransactionDetailDto
            {
                TransactionUid = "0fb066d1-de0c-41ac-aa88-1cd1d85cd053",
                TransactionId = $"TRN1001",
                Terminald = "terminal-002",
                TransactionDttm = transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss"),
                Amount = 200,
                Fee = 20,
                Currency = "USD",
                TransactionType = "RSND",
                Status = "C",
                DiscretionaryData = new DiscretionaryDataDto
                {
                    RemittanceSend =
                    [
                        new RemittanceSendDto
                            {
                                Receiver = "User 1",
                                ReceiveMethod = "10 Min Service",
                                ReferenceNumber = "FLTP1:0:1",
                                Amount = 100,
                                Fee = 10
                            },
                            new RemittanceSendDto
                            {
                                Receiver = "User 2",
                                ReceiveMethod = "1 Day Service",
                                ReferenceNumber = "FLTP1:0:2",
                                Amount = 200,
                                Fee = 20
                            }
                    ]
                }
            });

            transactions.Add(new TransactionDetailDto
            {
                TransactionUid = "8006c93d-1adb-453c-b393-ef8fb977591f",
                TransactionId = $"TRN1002",
                Terminald = "terminal-003",
                TransactionDttm = transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss"),
                Amount = 100,
                Fee = 10,
                Currency = "USD",
                TransactionType = "TKTP",
                Status = "C",
                DiscretionaryData = new DiscretionaryDataDto
                {
                    PlayTicket =
                    [
                        new PlayTicketDto
                            {
                                TicketCount = 2,
                                Tickets =
                                [
                                    new TicketDto
                                    {
                                        TicketUid = "3f9a864d-143d-4198-96b4-a1f6a630c628",
                                        TicketId = "CYYDDD0001",
                                        TicketAllocated = true,
                                        TicketRedeemedSuccessfully = true,
                                        TicketCreatedDateTime = DateTime.Parse(transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss")),
                                        TicketCompletedDateTime = transactionDateEastern.AddDays(-random.Next(1, 30)),
                                        TicketStatus = 'R',
                                        FaceValue = 100,
                                        Notes = "Ticket Redeemed successfully."
                                    },
                                    new TicketDto
                                    {
                                        TicketUid = "c391e701-e7a9-434b-a78d-4674d78249db",
                                        TicketId = "CYYDDD0002",
                                        TicketAllocated = true,
                                        TicketRedeemedSuccessfully = false,
                                        TicketCreatedDateTime = DateTime.Parse(transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss")),
                                        TicketCompletedDateTime = transactionDateEastern.AddDays(-random.Next(1, 30)),
                                        TicketStatus = 'V',
                                        FaceValue = 200,
                                        Notes = "Ticket inquiry successfully."
                                    }
                                ]
                            }
                    ]
                }
            });

            transactions.Add(new TransactionDetailDto
            {
                TransactionUid = "207c2add-0725-413b-9198-11427241c5d3",
                TransactionId = $"TRN1003",
                Terminald = "terminal-004",
                TransactionDttm = transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss"),
                Amount = 50,
                Fee = 5,
                Currency = "USD",
                TransactionType = "BPY",
                Status = "C",
                DiscretionaryData = new DiscretionaryDataDto
                {
                    BillPay =
                    [
                        new BillPayDto
                            {
                                Biller = "Biller 1",
                                ReferenceNumber = "FLTP1:0:1",
                                BillAccountNumber = "******** **** 1234",
                                Amount = 50,
                                Fee = 5
                            }
                    ]
                }
            });

            transactions.Add(new TransactionDetailDto
            {
                TransactionUid = "21776933-1320-4998-bc6a-3d665433c427",
                TransactionId = $"TRN1004",
                Terminald = "terminal-005",
                TransactionDttm = transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss"),
                Amount = 100,
                Fee = 10,
                Currency = "USD",
                TransactionType = "BPY",
                Status = "C",
                DiscretionaryData = new DiscretionaryDataDto
                {
                    BillPay =
                    [
                        new BillPayDto
                            {
                                Biller = "Biller 2",
                                ReferenceNumber = "FLTP1:0:2",
                                BillAccountNumber = "**** **** **** 5678",
                                Amount = 100,
                                Fee = 10
                            }
                    ]
                }
            });

            transactions.Add(new TransactionDetailDto
            {
                TransactionUid = "0109c798-da99-45aa-8f44-35a3a5ac9011",
                TransactionId = $"TRN1005",
                Terminald = "terminal-006",
                TransactionDttm = transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss"),
                Amount = 200,
                Fee = 20,
                Currency = "USD",
                TransactionType = "BPY",
                Status = "C",
                DiscretionaryData = new DiscretionaryDataDto
                {
                    BillPay =
                    [
                        new BillPayDto
                            {
                                Biller = "Biller 1",
                                ReferenceNumber = "FLTP1:0:1",
                                BillAccountNumber = "******** **** 1234",
                                Amount = 200,
                                Fee = 20
                            }
                    ]
                }
            });

            transactions.Add(new TransactionDetailDto
            {
                TransactionUid = "87d401e6-2136-42a4-b796-a25112675349",
                TransactionId = $"TRN1006",
                Terminald = "terminal-007",
                TransactionDttm = transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss"),
                Amount = 300,
                Fee = 30,
                Currency = "USD",
                TransactionType = "TKTP",
                Status = "C",
                DiscretionaryData = new DiscretionaryDataDto
                {
                    PlayTicket =
                    [
                        new PlayTicketDto
                            {
                                TicketCount = 1,
                                Tickets =
                                [
                                    new TicketDto
                                    {
                                        TicketUid = "3f9a864d-143d-4198-96b4-a1f6a630c628",
                                        TicketId = "CYYDDD0001",
                                        TicketAllocated = true,
                                        TicketRedeemedSuccessfully = true,
                                        TicketCreatedDateTime = DateTime.Parse(transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss")),
                                        TicketCompletedDateTime = transactionDateEastern.AddDays(-random.Next(1, 30)),
                                        TicketStatus = 'R',
                                        FaceValue = 300,
                                        Notes = "Ticket Redeemed successfully."
                                    }
                                ]
                            }
                    ]
                }
            });

            transactions.Add(new TransactionDetailDto
            {
                TransactionUid = "37648e17-d16c-4824-a9d0-af1bf5f04859",
                TransactionId = $"TRN1007",
                Terminald = "terminal-008",
                TransactionDttm = transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss"),
                Amount = 400,
                Fee = 40,
                Currency = "USD",
                TransactionType = "TKTP",
                Status = "C",
                DiscretionaryData = new DiscretionaryDataDto
                {
                    PlayTicket =
                    [
                        new PlayTicketDto
                            {
                                TicketCount = 1,
                                Tickets =
                                [
                                    new TicketDto
                                    {
                                        TicketUid = "c391e701-e7a9-434b-a78d-4674d78249db",
                                        TicketId = "CYYDDD0002",
                                        TicketAllocated = true,
                                        TicketRedeemedSuccessfully = false,
                                        TicketCreatedDateTime = DateTime.Parse(transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss")),
                                        TicketCompletedDateTime = transactionDateEastern.AddDays(-random.Next(1, 30)),
                                        TicketStatus = 'V',
                                        FaceValue = 400,
                                        Notes = "Ticket inquiry successfully."
                                    }
                                ]
                            }
                    ]
                }
            });

            transactions.Add(new TransactionDetailDto
            {
                TransactionUid = "dbd9eb01-5262-4747-961f-1fafbed3603d",
                TransactionId = "TRN1008",
                Terminald = "terminal-016",
                TransactionDttm = transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss"),
                Amount = 800,
                Fee = 80,
                Currency = "USD",
                TransactionType = "RSND",
                Status = "C",
                DiscretionaryData = new DiscretionaryDataDto
                {
                    RemittanceSend =
                    [
                        new RemittanceSendDto
                        {
                            Receiver = "User 5",
                            ReceiveMethod = "Express Service",
                            ReferenceNumber = "FLTP1:0:5",
                            Amount = 800,
                            Fee = 80
                        }
                    ]
                }
            });

            transactions.Add(new TransactionDetailDto
            {
                TransactionUid = "3fb9fb7b-7668-414c-a128-002a36837ec1",
                TransactionId = "TRN1009",
                Terminald = "terminal-015",
                TransactionDttm = transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss"),
                Amount = 700,
                Fee = 70,
                Currency = "USD",
                TransactionType = "BPY",
                Status = "C",
                DiscretionaryData = new DiscretionaryDataDto
                {
                    BillPay =
                    [
                        new BillPayDto
                        {
                            Biller = "Biller 5",
                            ReferenceNumber = "FLTP1:0:5",
                            BillAccountNumber = "**** **** **** 3333",
                            Amount = 700,
                            Fee = 70
                        }
                    ]
                }
            });

            transactions.Add(new TransactionDetailDto
            {
                TransactionUid = "2943c85d-c787-4f4c-af5b-96601fb693a1",
                TransactionId = "TRN1010",
                Terminald = "terminal-014",
                TransactionDttm = transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss"),
                Amount = 600,
                Fee = 60,
                Currency = "USD",
                TransactionType = "TKTP",
                Status = "C",
                DiscretionaryData = new DiscretionaryDataDto
                {
                    PlayTicket =
                    [
                        new PlayTicketDto
                        {
                            TicketCount = 4,
                            Tickets =
                            [
                                new TicketDto
                                {
                                    TicketUid = "9i9i9i9i-9i9i-9i9i-9i9i-9i9i9i9i",
                                    TicketId = "CYYDDD0005",
                                    TicketAllocated = true,
                                    TicketRedeemedSuccessfully = true,
                                    TicketCreatedDateTime = DateTime.Parse(transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss")),
                                    TicketCompletedDateTime = transactionDateEastern.AddDays(-random.Next(1, 30)),
                                    TicketStatus = 'R',
                                    FaceValue = 150,
                                    Notes = "Ticket Redeemed successfully."
                                },
                                new TicketDto
                                {
                                    TicketUid = "a0a0a0a0-a0a0-a0a0-a0a0-a0a0a0a0",
                                    TicketId = "CYYDDD0006",
                                    TicketAllocated = true,
                                    TicketRedeemedSuccessfully = false,
                                    TicketCreatedDateTime = DateTime.Parse(transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss")),
                                    TicketCompletedDateTime = transactionDateEastern.AddDays(-random.Next(1, 30)),
                                    TicketStatus = 'V',
                                    FaceValue = 200,
                                    Notes = "Ticket inquiry successfully."
                                }
                            ]
                        }
                    ]
                }
            });

            transactions.Add(new TransactionDetailDto
            {
                TransactionUid = "6ddec94c-a939-4634-b950-d91ecc1ff277",
                TransactionId = "TRN1011",
                Terminald = "terminal-013",
                TransactionDttm = transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss"),
                Amount = 350,
                Fee = 35,
                Currency = "USD",
                TransactionType = "RSND",
                Status = "C",
                DiscretionaryData = new DiscretionaryDataDto
                {
                    RemittanceSend =
                    [
                        new RemittanceSendDto
                        {
                            Receiver = "User 4",
                            ReceiveMethod = "Instant Service",
                            ReferenceNumber = "FLTP1:0:4",
                            Amount = 350,
                            Fee = 35
                        }
                    ]
                }
            });

            transactions.Add(new TransactionDetailDto
            {
                TransactionUid = "ccaa4cc8-94fa-4660-aee1-4db48025f789",
                TransactionId = "TRN1012",
                Terminald = "terminal-012",
                TransactionDttm = transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss"),
                Amount = 400,
                Fee = 40,
                Currency = "USD",
                TransactionType = "BPY",
                Status = "C",
                DiscretionaryData = new DiscretionaryDataDto
                {
                    BillPay =
                    [
                        new BillPayDto
                        {
                            Biller = "Biller 4",
                            ReferenceNumber = "FLTP1:0:4",
                            BillAccountNumber = "**** **** **** 2222",
                            Amount = 400,
                            Fee = 40
                        }
                    ]
                }
            });

            transactions.Add(new TransactionDetailDto
            {
                TransactionUid = "0c0784f5-9759-4070-919a-a1e6c1e00bfd",
                TransactionId = "TRN1013",
                Terminald = "terminal-011",
                TransactionDttm = transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss"),
                Amount = 250,
                Fee = 25,
                Currency = "USD",
                TransactionType = "TKTP",
                Status = "C",
                DiscretionaryData = new DiscretionaryDataDto
                {
                    PlayTicket =
                    [
                        new PlayTicketDto
                        {
                            TicketCount = 3,
                            Tickets =
                            [
                                new TicketDto
                                {
                                    TicketUid = "4d4d4d4d-4d4d-4d4d-4d4d-4d4d4d4d",
                                    TicketId = "CYYDDD0003",
                                    TicketAllocated = true,
                                    TicketRedeemedSuccessfully = true,
                                    TicketCreatedDateTime = DateTime.Parse(transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss")),
                                    TicketCompletedDateTime = transactionDateEastern.AddDays(-random.Next(1, 30)),
                                    TicketStatus = 'R',
                                    FaceValue = 100,
                                    Notes = "Ticket Redeemed successfully."
                                },
                                new TicketDto
                                {
                                    TicketUid = "5e5e5e5e-5e5e-5e5e-5e5e-5e5e5e5e",
                                    TicketId = "CYYDDD0004",
                                    TicketAllocated = true,
                                    TicketRedeemedSuccessfully = false,
                                    TicketCreatedDateTime = DateTime.Parse(transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss")),
                                    TicketCompletedDateTime = transactionDateEastern.AddDays(-random.Next(1, 30)),
                                    TicketStatus = 'V',
                                    FaceValue = 150,
                                    Notes = "Ticket inquiry successfully."
                                }
                            ]
                        }
                    ]
                }
            });

            transactions.Add(new TransactionDetailDto
            {
                TransactionUid = "b08b4f93-de9a-4d77-9f39-ac10a8ae1d06",
                TransactionId = "TRN1014",
                Terminald = "terminal-010",
                TransactionDttm = transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss"),
                Amount = 150,
                Fee = 15,
                Currency = "USD",
                TransactionType = "RSND",
                Status = "C",
                DiscretionaryData = new DiscretionaryDataDto
                {
                    RemittanceSend =
                    [
                        new RemittanceSendDto
                        {
                            Receiver = "User 3",
                            ReceiveMethod = "3 Day Service",
                            ReferenceNumber = "FLTP1:0:3",
                            Amount = 150,
                            Fee = 15
                        }
                    ]
                }
            });

            transactions.Add(new TransactionDetailDto
            {
                TransactionUid = "4d55eb89-4de5-4729-a00a-151d026e213c",
                TransactionId = "TRN1015",
                Terminald = "terminal-009",
                TransactionDttm = transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss"),
                Amount = 500,
                Fee = 50,
                Currency = "USD",
                TransactionType = "BPY",
                Status = "C",
                DiscretionaryData = new DiscretionaryDataDto
                {
                    BillPay =
                    [
                        new BillPayDto
                        {
                            Biller = "Biller 3",
                            ReferenceNumber = "FLTP1:0:3",
                            BillAccountNumber = "**** **** **** 1111",
                            Amount = 500,
                            Fee = 50
                        }
                    ]
                }
            });

            transactions.Add(new TransactionDetailDto
            {
                TransactionUid = "86e38404-796e-4e23-9c26-43bb9c51a27f",
                TransactionId = "TRN1016",
                Terminald = "terminal-002",
                TransactionDttm = transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss"),
                Amount = 100,
                Fee = 10,
                Currency = "USD",
                TransactionType = "TKTP",
                Status = "C",
                DiscretionaryData = new DiscretionaryDataDto
                {
                    PlayTicket =
                    [
                        new PlayTicketDto
                        {
                            TicketCount = 2,
                            Tickets =
                            [
                                new TicketDto
                                {
                                    TicketUid = "1c1c1c1c-1c1c-1c1c1c1c",
                                    TicketId = "CYYDDD0001",
                                    TicketAllocated = true,
                                    TicketRedeemedSuccessfully = true,
                                    TicketCreatedDateTime = DateTime.Parse(transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss")),
                                    TicketCompletedDateTime = transactionDateEastern.AddDays(-random.Next(1, 30)),
                                    TicketStatus = 'R',
                                    FaceValue = 50,
                                    Notes = "Ticket Redeemed successfully."
                                },
                                new TicketDto
                                {
                                    TicketUid = "2d2d2d2d-2d2d-2d2d2d2d",
                                    TicketId = "CYYDDD0002",
                                    TicketAllocated = true,
                                    TicketRedeemedSuccessfully = false,
                                    TicketCreatedDateTime = DateTime.Parse(transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss")),
                                    TicketCompletedDateTime = transactionDateEastern.AddDays(-random.Next(1, 30)),
                                    TicketStatus = 'V',
                                    FaceValue = 100,
                                    Notes = "Ticket inquiry successfully."
                                }
                            ]
                        }
                    ]
                }
            });

            transactions.Add(new TransactionDetailDto
            {
                TransactionUid = "99a33adf-a815-4970-b189-08ea5f1617b4",
                TransactionId = "TRN1017",
                Terminald = "terminal-003",
                TransactionDttm = transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss"),
                Amount = 200,
                Fee = 20,
                Currency = "USD",
                TransactionType = "RSND",
                Status = "C",
                DiscretionaryData = new DiscretionaryDataDto
                {
                    RemittanceSend =
                    [
                        new RemittanceSendDto
                        {
                            Receiver = "User 2",
                            ReceiveMethod = "2 Day Service",
                            ReferenceNumber = "FLTP1:0:2",
                            Amount = 200,
                            Fee = 20
                        }
                    ]
                }
            });

            transactions.Add(new TransactionDetailDto
            {
                TransactionUid = "4604554c-be2a-4f25-b53a-17220a99c488",
                TransactionId = "TRN1018",
                Terminald = "terminal-004",
                TransactionDttm = transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss"),
                Amount = 300,
                Fee = 30,
                Currency = "USD",
                TransactionType = "BPY",
                Status = "C",
                DiscretionaryData = new DiscretionaryDataDto
                {
                    BillPay =
                    [
                        new BillPayDto
                        {
                            Biller = "Biller 2",
                            ReferenceNumber = "FLTP1:0:2",
                            BillAccountNumber = "**** **** **** 4444",
                            Amount = 300,
                            Fee = 30
                        }
                    ]
                }
            });

            transactions.Add(new TransactionDetailDto
            {
                TransactionUid = "b3093cc3-720f-46bd-8575-c6b8b74d1c78",
                TransactionId = "TRN1019",
                Terminald = "terminal-005",
                TransactionDttm = transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss"),
                Amount = 400,
                Fee = 40,
                Currency = "USD",
                TransactionType = "TKTP",
                Status = "C",
                DiscretionaryData = new DiscretionaryDataDto
                {
                    PlayTicket =
                    [
                        new PlayTicketDto
                        {
                            TicketCount = 1,
                            Tickets =
                            [
                                new TicketDto
                                {
                                    TicketUid = "6f6f6f6f-6f6f-6f6f6f6f",
                                    TicketId = "CYYDDD0001",
                                    TicketAllocated = true,
                                    TicketRedeemedSuccessfully = true,
                                    TicketCreatedDateTime = DateTime.Parse(transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss")),
                                    TicketCompletedDateTime = transactionDateEastern.AddDays(-random.Next(1, 30)),
                                    TicketStatus = 'R',
                                    FaceValue = 25,
                                    Notes = "Ticket Redeemed successfully."
                                }
                            ]
                        }
                    ]
                }
            });

            transactions.Add(new TransactionDetailDto
            {
                TransactionUid = "ac91fd07-7663-4647-80a7-f856c09cfb57",
                TransactionId = "TRN1020",
                Terminald = "terminal-006",
                TransactionDttm = transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss"),
                Amount = 500,
                Fee = 50,
                Currency = "USD",
                TransactionType = "RSND",
                Status = "C",
                DiscretionaryData = new DiscretionaryDataDto
                {
                    RemittanceSend =
                    [
                        new RemittanceSendDto
                        {
                            Receiver = "User 1",
                            ReceiveMethod = "1 Day Service",
                            ReferenceNumber = "FLTP1:0:1",
                            Amount = 500,
                            Fee = 50
                        }
                    ]
                }
            });

            transactions.Add(new TransactionDetailDto
            {
                TransactionUid = "4de05aa6-2efc-4959-b515-3d45efcbc24b",
                TransactionId = "TRN1021",
                Terminald = "terminal-007",
                TransactionDttm = transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss"),
                Amount = 600,
                Fee = 60,
                Currency = "USD",
                TransactionType = "BPY",
                Status = "C",
                DiscretionaryData = new DiscretionaryDataDto
                {
                    BillPay =
                    [
                        new BillPayDto
                        {
                            Biller = "Biller 1",
                            ReferenceNumber = "FLTP1:0:1",
                            BillAccountNumber = "**** **** **** 5555",
                            Amount = 600,
                            Fee = 60
                        }
                    ]
                }
            });

            transactions.Add(new TransactionDetailDto
            {
                TransactionUid = "6fafcaa8-c89e-42bd-82b8-7a8975b9952b",
                TransactionId = "TRN1022",
                Terminald = "terminal-008",
                TransactionDttm = transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss"),
                Amount = 700,
                Fee = 70,
                Currency = "USD",
                TransactionType = "TKTP",
                Status = "C",
                DiscretionaryData = new DiscretionaryDataDto
                {
                    PlayTicket =
                    [
                        new PlayTicketDto
                        {
                            TicketCount = 1,
                            Tickets =
                            [
                                new TicketDto
                                {
                                    TicketUid = "9i9i9i9i-9i9i-9i9i9i9i",
                                    TicketId = "CYYDDD0001",
                                    TicketAllocated = true,
                                    TicketRedeemedSuccessfully = true,
                                    TicketCreatedDateTime = DateTime.Parse(transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss")),
                                    TicketCompletedDateTime = transactionDateEastern.AddDays(-random.Next(1, 30)),
                                    TicketStatus = 'R',
                                    FaceValue = 10,
                                    Notes = "Ticket Redeemed successfully."
                                }
                            ]
                        }
                    ]
                }
            });

            transactions.Add(new TransactionDetailDto
            {
                TransactionUid = "e96c2ecb-5842-4788-8b27-0e84bdcb8c16",
                TransactionId = "TRN1023",
                Terminald = "terminal-001",
                TransactionDttm = transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss"),
                Amount = 800,
                Fee = 80,
                Currency = "USD",
                TransactionType = "RSND",
                Status = "C",
                DiscretionaryData = new DiscretionaryDataDto
                {
                    RemittanceSend =
                    [
                        new RemittanceSendDto
                        {
                            Receiver = "User 0",
                            ReceiveMethod = "Free Service",
                            ReferenceNumber = "FLTP1:0:0",
                            Amount = 800,
                            Fee = 80
                        }
                    ]
                }
            });

            transactions.Add(new TransactionDetailDto
            {
                TransactionUid = "94eeb498-cc5a-43a3-8165-b203529e21a4",
                TransactionId = "TRN1024",
                Terminald = "terminal-014",
                TransactionDttm = transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss"),
                Amount = 1000,
                Fee = 100,
                Currency = "USD",
                TransactionType = "BPY",
                Status = "C",
                DiscretionaryData = new DiscretionaryDataDto
                {
                    BillPay =
                    [
                        new BillPayDto
                        {
                            Biller = "Biller 0",
                            ReferenceNumber = "FLTP1:0:0",
                            BillAccountNumber = "**** **** **** 3333",
                            Amount = 1000,
                            Fee = 100
                        }
                    ]
                }
            });

            transactions.Add(new TransactionDetailDto
            {
                TransactionUid = "4abbedde-616f-4455-aee1-f67ab3e8105a",
                TransactionId = "TRN1025",
                TransactionDttm = transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss"),
                Amount = 1200,
                Fee = 120,
                Currency = "USD",
                TransactionType = "TKTP",
                Status = "C",
                DiscretionaryData = new DiscretionaryDataDto
                {
                    PlayTicket =
                    [
                        new PlayTicketDto
                        {
                            TicketCount = 1,
                            Tickets =
                            [
                                new TicketDto
                                {
                                    TicketUid = "1a1a1a1a-1a1a-1a1a1a1a",
                                    TicketId = "CYYDDD0001",
                                    TicketAllocated = true,
                                    TicketRedeemedSuccessfully = true,
                                    TicketCreatedDateTime = DateTime.Parse(transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss")),
                                    TicketCompletedDateTime = transactionDateEastern.AddDays(-random.Next(1, 30)),
                                    TicketStatus = 'R',
                                    FaceValue = 5,
                                    Notes = "Ticket Redeemed successfully."
                                }
                            ]
                        }
                    ]
                }
            });

            transactions.Add(new TransactionDetailDto
            {
                TransactionUid = "1201830e-5314-4354-864e-7482f4060b0e",
                TransactionId = "TRN1026",
                TransactionDttm = transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss"),
                Amount = 1400,
                Fee = 140,
                Currency = "USD",
                TransactionType = "RSND",
                Status = "C",
                DiscretionaryData = new DiscretionaryDataDto
                {
                    RemittanceSend =
                    [
                        new RemittanceSendDto
                        {
                            Receiver = "User 4",
                            ReceiveMethod = "4 Day Service",
                            ReferenceNumber = "FLTP1:0:4",
                            Amount = 1400,
                            Fee = 140
                        }
                    ]
                }
            });

            transactions.Add(new TransactionDetailDto
            {
                TransactionUid = "bc5a4779-4d13-4c6b-9353-350952337277",
                TransactionId = "TRN1027",
                TransactionDttm = transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss"),
                Amount = 1600,
                Fee = 160,
                Currency = "USD",
                TransactionType = "BPY",
                Status = "C",
                DiscretionaryData = new DiscretionaryDataDto
                {
                    BillPay =
                    [
                        new BillPayDto
                        {
                            Biller = "Biller 4",
                            ReferenceNumber = "FLTP1:0:4",
                            BillAccountNumber = "**** **** **** 2222",
                            Amount = 1600,
                            Fee = 160
                        }
                    ]
                }
            });

            transactions.Add(new TransactionDetailDto
            {
                TransactionUid = "c99ee6f0-6305-4a68-ad66-dc1edd1c8139",
                TransactionId = "TRN1028",
                TransactionDttm = transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss"),
                Amount = 1800,
                Fee = 180,
                Currency = "USD",
                TransactionType = "TKTP",
                Status = "C",
                DiscretionaryData = new DiscretionaryDataDto
                {
                    PlayTicket =
                    [
                        new PlayTicketDto
                        {
                            TicketCount = 1,
                            Tickets =
                            [
                                new TicketDto
                                {
                                    TicketUid = "2b2b2b2b-2b2b-2b2b2b2b",
                                    TicketId = "CYYDDD0001",
                                    TicketAllocated = true,
                                    TicketRedeemedSuccessfully = true,
                                    TicketCreatedDateTime = DateTime.Parse(transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss")),
                                    TicketCompletedDateTime = transactionDateEastern.AddDays(-random.Next(1, 30)),
                                    TicketStatus = 'R',
                                    FaceValue = 2,
                                    Notes = "Ticket Redeemed successfully."
                                }
                            ]
                        }
                    ]
                }
            });

            transactions.Add(new TransactionDetailDto
            {
                TransactionUid = "1201830e-5314-4354-864e-7482f4060b0e",
                TransactionId = "TRN1029",
                TransactionDttm = transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss"),
                Amount = 1400,
                Fee = 140,
                Currency = "USD",
                TransactionType = "RSND",
                Status = "C",
                DiscretionaryData = new DiscretionaryDataDto
                {
                    RemittanceSend =
                    [
                        new RemittanceSendDto
                        {
                            Receiver = "User 4",
                            ReceiveMethod = "4 Day Service",
                            ReferenceNumber = "FLTP1:0:4",
                            Amount = 1400,
                            Fee = 140
                        }
                    ]
                }
            });

            transactions.Add(new TransactionDetailDto
            {
                TransactionUid = "bc5a4779-4d13-4c6b-9353-350952337277",
                TransactionId = "TRN1030",
                TransactionDttm = transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss"),
                Amount = 1600,
                Fee = 160,
                Currency = "USD",
                TransactionType = "BPY",
                Status = "C",
                DiscretionaryData = new DiscretionaryDataDto
                {
                    BillPay =
                    [
                        new BillPayDto
                        {
                            Biller = "Biller 4",
                            ReferenceNumber = "FLTP1:0:4",
                            BillAccountNumber = "**** **** **** 2222",
                            Amount = 1600,
                            Fee = 160
                        }
                    ]
                }
            });

            transactions.Add(new TransactionDetailDto
            {
                TransactionUid = "c99ee6f0-6305-4a68-ad66-dc1edd1c8139",
                TransactionId = "TRN1031",
                TransactionDttm = transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss"),
                Amount = 1800,
                Fee = 180,
                Currency = "USD",
                TransactionType = "TKTP",
                Status = "C",
                DiscretionaryData = new DiscretionaryDataDto
                {
                    PlayTicket =
                    [
                        new PlayTicketDto
                        {
                            TicketCount = 1,
                            Tickets =
                            [
                                new TicketDto
                                {
                                    TicketUid = "2b2b2b2b-2b2b-2b2b2b2b",
                                    TicketId = "CYYDDD0001",
                                    TicketAllocated = true,
                                    TicketRedeemedSuccessfully = true,
                                    TicketCreatedDateTime = DateTime.Parse(transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss")),
                                    TicketCompletedDateTime = transactionDateEastern.AddDays(-random.Next(1, 30)),
                                    TicketStatus = 'R',
                                    FaceValue = 2,
                                    Notes = "Ticket Redeemed successfully."
                                }
                            ]
                        }
                    ]
                }
            });

            transactions.Add(new TransactionDetailDto
            {
                TransactionUid = "dc6d603a-e954-4d61-b214-3eb96d478002",
                TransactionId = "TRN1032",
                Terminald = "terminal-001",
                TransactionDttm = transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss"),
                Amount = 100,
                Fee = 10,
                Currency = "USD",
                TransactionType = "BPY",
                Status = "C",
                DiscretionaryData = new DiscretionaryDataDto
                {
                    BillPay =
                    [
                        new BillPayDto
                        {
                            Biller = "Biller 1",
                            ReferenceNumber = "BPY1",
                            BillAccountNumber = "**** **** **** 1234",
                            Amount = 50,
                            Fee = 5
                        }
                    ]
                }
            });

            transactions.Add(new TransactionDetailDto
            {
                TransactionUid = "8df68caf-95df-40fb-a9c9-c07d2e83be3f",
                TransactionId = "TRN1033",
                Terminald = "terminal-002",
                TransactionDttm = transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss"),
                Amount = 100,
                Fee = 10,
                Currency = "USD",
                TransactionType = "RSND",
                Status = "C",
                DiscretionaryData = new DiscretionaryDataDto
                {
                    RemittanceSend =
                    [
                        new RemittanceSendDto
                        {
                            Receiver = "User 1",
                            ReceiveMethod = "10 Min Service",
                            ReferenceNumber = "RSND1",
                            Amount = 100,
                            Fee = 10
                        }
                    ]
                }
            });


            transactions.Add(new TransactionDetailDto
            {
                TransactionUid = "d4254555-e7b3-43bb-90fc-675217ef4072",
                TransactionId = "TRN1034",
                Terminald = "terminal-003",
                TransactionDttm = transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss"),
                Amount = 300,
                Fee = 30,
                Currency = "USD",
                TransactionType = "TKTP",
                Status = "C",
                DiscretionaryData = new DiscretionaryDataDto
                {
                    PlayTicket =
                    [
                        new PlayTicketDto
                        {
                            TicketCount = 1,
                            Tickets =
                            [
                                new TicketDto
                                {
                                    TicketUid = "44444444-4444-4444-4444-444444444444",
                                    TicketId = "TKTP1",
                                    TicketAllocated = true,
                                    TicketRedeemedSuccessfully = true,
                                    TicketCreatedDateTime = DateTime.Parse(transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss")),
                                    TicketCompletedDateTime = transactionDateEastern.AddDays(-random.Next(1, 30)),
                                    TicketStatus = 'R',
                                    FaceValue = 100,
                                    Notes = "Redeemed ticket."
                                }
                            ]
                        }
                    ]
                }
            });

            transactions.Add(new TransactionDetailDto
            {
                TransactionUid = "1c1d608a-b583-4438-961b-21959d79f8db",
                TransactionId = "TRN1035",
                Terminald = "terminal-004",
                TransactionDttm = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"),
                Amount = 60,
                Fee = 6,
                Currency = "USD",
                TransactionType = "BPY",
                Status = "C",
                DiscretionaryData = new DiscretionaryDataDto
                {
                    BillPay =
                    [
                        new BillPayDto
                        {
                            Biller = "Biller 2",
                            ReferenceNumber = "BPY2",
                            BillAccountNumber = "**** **** **** 5678",
                            Amount = 60,
                            Fee = 6
                        }
                    ]
                }
            });

            transactions.Add(new TransactionDetailDto
            {
                TransactionUid = "f7bf5195-5d19-4990-839a-8d11a1044787",
                TransactionId = "TRN1036",
                Terminald = "terminal-005",
                TransactionDttm = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"),
                Amount = 125,
                Fee = 12,
                Currency = "USD",
                TransactionType = "RSND",
                Status = "C",
                DiscretionaryData = new DiscretionaryDataDto
                {
                    RemittanceSend =
                    [
                        new RemittanceSendDto
                        {
                            Receiver = "User 2",
                            ReceiveMethod = "1 Day Service",
                            ReferenceNumber = "RSND2",
                            Amount = 125,
                            Fee = 12
                        }
                    ]
                }
            });

            transactions.Add(new TransactionDetailDto
            {
                TransactionUid = "d5d5d5d5-d5d5-d5d5d5d5d5d5",
                TransactionId = "TRN1037",
                Terminald = "terminal-006",
                TransactionDttm = transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss"),
                Amount = 250,
                Fee = 12,
                Currency = "USD",
                TransactionType = "TKTP",
                Status = "C",
                DiscretionaryData = new DiscretionaryDataDto
                {
                    PlayTicket =
                    [
                        new PlayTicketDto
                        {
                            TicketCount = 1,
                            Tickets =
                            [
                                new TicketDto
                                {
                                    TicketUid = "55555555-5555-555555555555",
                                    TicketId = "TKTP2",
                                    TicketAllocated = true,
                                    TicketRedeemedSuccessfully = true,
                                    TicketCreatedDateTime = DateTime.Parse(transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss")),
                                    TicketCompletedDateTime = transactionDateEastern.AddDays(-random.Next(1, 30)),
                                    TicketStatus = 'R',
                                    FaceValue = 50,
                                    Notes = "Redeemed ticket."
                                }
                            ]
                        }
                    ]
                }
            });

            transactions.Add(new TransactionDetailDto
            {
                TransactionUid = "1c1d608a-b583-4438-961b-21959d79f8db",
                TransactionId = "TRN1038",
                Terminald = "terminal-007",
                TransactionDttm = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"),
                Amount = 60,
                Fee = 6,
                Currency = "USD",
                TransactionType = "BPY",
                Status = "C",
                DiscretionaryData = new DiscretionaryDataDto
                {
                    BillPay =
                    [
                        new BillPayDto
                        {
                            Biller = "Biller 3",
                            ReferenceNumber = "BPY3",
                            BillAccountNumber = "**** **** **** 9012",
                            Amount = 60,
                            Fee = 6
                        }
                    ]
                }
            });

            transactions.Add(new TransactionDetailDto
            {
                TransactionUid = "f7bf5195-5d19-4990-839a-8d11a1044787",
                TransactionId = "TRN1039",
                Terminald = "terminal-008",
                TransactionDttm = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"),
                Amount = 125,
                Fee = 12,
                Currency = "USD",
                TransactionType = "RSND",
                Status = "C",
                DiscretionaryData = new DiscretionaryDataDto
                {
                    RemittanceSend =
                    [
                        new RemittanceSendDto
                        {
                            Receiver = "User 3",
                            ReceiveMethod = "2 Day Service",
                            ReferenceNumber = "RSND3",
                            Amount = 125,
                            Fee = 12
                        }
                    ]
                }
            });

            transactions.Add(new TransactionDetailDto
            {
                TransactionUid = "d5d5d5d5-d5d5-d5d5d5d5d5d5",
                TransactionId = "TRN1040",
                Terminald = "terminal-009",
                TransactionDttm = transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss"),
                Amount = 250,
                Fee = 12,
                Currency = "USD",
                TransactionType = "TKTP",
                Status = "C",
                DiscretionaryData = new DiscretionaryDataDto
                {
                    PlayTicket =
                    [
                        new PlayTicketDto
                        {
                            TicketCount = 1,
                            Tickets =
                            [
                                new TicketDto
                                {
                                    TicketUid = "66666666-6666-666666666666",
                                    TicketId = "TKTP3",
                                    TicketAllocated = true,
                                    TicketRedeemedSuccessfully = true,
                                    TicketCreatedDateTime = DateTime.Parse(transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss")),
                                    TicketCompletedDateTime = transactionDateEastern.AddDays(-random.Next(1, 30)),
                                    TicketStatus = 'R',
                                    FaceValue = 50,
                                    Notes = "Redeemed ticket."
                                }
                            ]
                        }
                    ]
                }
            });

            transactions.Add(new TransactionDetailDto
            {
                TransactionUid = "1c1d608a-b583-4438-961b-21959d79f8db",
                TransactionId = "TRN1041",
                Terminald = "terminal-010",
                TransactionDttm = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"),
                Amount = 60,
                Fee = 6,
                Currency = "USD",
                TransactionType = "BPY",
                Status = "C",
                DiscretionaryData = new DiscretionaryDataDto
                {
                    BillPay =
                    [
                        new BillPayDto
                        {
                            Biller = "Biller 4",
                            ReferenceNumber = "BPY4",
                            BillAccountNumber = "**** **** **** 3456",
                            Amount = 60,
                            Fee = 6
                        }
                    ]
                }
            });

            transactions.Add(new TransactionDetailDto
            {
                TransactionUid = "f7bf5195-5d19-4990-839a-8d11a1044787",
                TransactionId = "TRN1042",
                Terminald = "terminal-011",
                TransactionDttm = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"),
                Amount = 125,
                Fee = 12,
                Currency = "USD",
                TransactionType = "RSND",
                Status = "C",
                DiscretionaryData = new DiscretionaryDataDto
                {
                    RemittanceSend =
                    [
                        new RemittanceSendDto
                        {
                            Receiver = "User 4",
                            ReceiveMethod = "4 Day Service",
                            ReferenceNumber = "RSND4",
                            Amount = 125,
                            Fee = 12
                        }
                    ]
                }
            });

            transactions.Add(new TransactionDetailDto
            {
                TransactionUid = "67b76214-95e2-4de4-b294-6c3e9a24e14c",
                TransactionId = "TRN1043",
                Terminald = "terminal-012",
                TransactionDttm = transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss"),
                Currency = "USD",
                TransactionType = "TKTP",
                Status = "C",
                Amount = 200,
                Fee=12,
                DiscretionaryData = new DiscretionaryDataDto
                {
                    PlayTicket =
                    [
                        new PlayTicketDto
                        {
                            TicketCount = 1,
                            Tickets =
                            [
                                new TicketDto
                                {
                                    TicketUid = "77777777-7777-777777777777",
                                    TicketId = "TKTP4",
                                    TicketAllocated = true,
                                    TicketRedeemedSuccessfully = true,
                                    TicketCreatedDateTime = DateTime.Parse(transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss")),
                                    TicketCompletedDateTime = transactionDateEastern.AddDays(-random.Next(1, 30)),
                                    TicketStatus = 'R',
                                    FaceValue = 50,
                                    Notes = "Redeemed ticket."
                                }
                            ]
                        }
                    ]
                }
            });

            transactions.Add(new TransactionDetailDto
            {
                TransactionUid = "68bd879d-8a1d-44d7-9764-402b90bdba48",
                TransactionId = "TRN1044",
                Terminald = "terminal-013",
                TransactionDttm = transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss"),
                Amount = 100,
                Fee = 10,
                Currency = "USD",
                TransactionType = "BPY",
                Status = "C",
                DiscretionaryData = new DiscretionaryDataDto
                {
                    BillPay =
                    [
                        new BillPayDto
                        {
                            Biller = "Biller 5",
                            ReferenceNumber = "BPY5",
                            BillAccountNumber = "**** **** **** 7890",
                            Amount = 100,
                            Fee = 10
                        }
                    ]
                }
            });

            transactions.Add(new TransactionDetailDto
            {
                TransactionUid = "d3f8cb28-33f3-4bf1-9965-3e8531ceedb2",
                TransactionId = "TRN1045",
                Terminald = "terminal-014",
                TransactionDttm = transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss"),
                Amount = 150,
                Fee = 15,
                Currency = "USD",
                TransactionType = "RSND",
                Status = "C",
                DiscretionaryData = new DiscretionaryDataDto
                {
                    RemittanceSend =
                    [
                        new RemittanceSendDto
                        {
                            Receiver = "User 5",
                            ReceiveMethod = "8 Day Service",
                            ReferenceNumber = "RSND5",
                            Amount = 150,
                            Fee = 15
                        }
                    ]
                }
            });

            transactions.Add(new TransactionDetailDto
            {
                TransactionUid = "884d7d99-26b5-473b-ae8f-93a758cc831a",
                TransactionId = "TRN1046",
                Terminald = "terminal-015",
                TransactionDttm = transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss"),
                Amount = 300,
                Fee = 30,
                Currency = "USD",
                TransactionType = "TKTP",
                Status = "C",
                DiscretionaryData = new DiscretionaryDataDto
                {
                    PlayTicket =
                    [
                        new PlayTicketDto
                        {
                            TicketCount = 1,
                            Tickets =
                            [
                                new TicketDto
                                {
                                    TicketUid = "88888888-8888-888888888888",
                                    TicketId = "TKTP5",
                                    TicketAllocated = true,
                                    TicketRedeemedSuccessfully = true,
                                    TicketCreatedDateTime = DateTime.Parse(transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss")),
                                    TicketCompletedDateTime = transactionDateEastern.AddDays(-random.Next(1, 30)),
                                    TicketStatus = 'R',
                                    FaceValue = 100,
                                    Notes = "Redeemed ticket."
                                }
                            ]
                        }
                    ]
                }
            });

            transactions.Add (new TransactionDetailDto 
            {
                TransactionUid = "9fafec61-6c9f-44a7-a947-e9467c950c28",
                TransactionId = "TRN1047",
                Terminald = "terminal-016",
                TransactionDttm = transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss"),
                Amount = 100,
                Fee = 10,
                Currency = "USD",
                TransactionType = "BPY",
                Status = "C",
                DiscretionaryData = new DiscretionaryDataDto
                {
                    BillPay =
                    [
                        new BillPayDto
                        {
                            Biller = "Biller 6",
                            ReferenceNumber = "BPY6",
                            BillAccountNumber = "**** **** **** 1234",
                            Amount = 100,
                            Fee = 10
                        }
                    ]
                }
            });

            transactions.Add(new TransactionDetailDto
            {
                TransactionUid = "a9d44f28-1526-4a9b-b297-d4ebb585376e",
                TransactionId = "TRN1048",
                Terminald = "terminal-017",
                TransactionDttm = transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss"),
                Amount = 150,
                Fee = 15,
                Currency = "USD",
                TransactionType = "RSND",
                Status = "C",
                DiscretionaryData = new DiscretionaryDataDto
                {
                    RemittanceSend =
                    [
                        new RemittanceSendDto
                        {
                            Receiver = "User 6",
                            ReceiveMethod = "10 Day Service",
                            ReferenceNumber = "RSND6",
                            Amount = 150,
                            Fee = 15
                        }
                    ]
                }
            });

            transactions.Add(new TransactionDetailDto
            {
                TransactionUid = "50c3fb0c-a301-4f2d-8060-88a14ebe8615",
                TransactionId = "TRN1049",
                Terminald = "terminal-018",
                TransactionDttm = transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss"),
                Amount = 300,
                Fee = 30,
                Currency = "USD",
                TransactionType = "TKTP",
                Status = "C",
                DiscretionaryData = new DiscretionaryDataDto
                {
                    PlayTicket =
                    [
                        new PlayTicketDto
                        {
                            TicketCount = 1,
                            Tickets =
                            [
                                new TicketDto
                                {
                                    TicketUid = "99999999-9999-999999999999",
                                    TicketId = "TKTP6",
                                    TicketAllocated = true,
                                    TicketRedeemedSuccessfully = true,
                                    TicketCreatedDateTime = DateTime.Parse(transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss")),
                                    TicketCompletedDateTime = transactionDateEastern.AddDays(-random.Next(1, 30)),
                                    TicketStatus = 'R',
                                    FaceValue = 100,
                                    Notes = "Redeemed ticket."
                                }
                            ]
                        }
                    ]
                }
            });

            transactions.Add(new TransactionDetailDto
            {
                TransactionUid = "26e60dc3-48bb-487c-8492-29ecff68af0b",
                TransactionId = "TRN1050",
                Terminald = "terminal-019",
                TransactionDttm = transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss"),
                Amount = 100,
                Fee = 10,
                Currency = "USD",
                TransactionType = "BPY",
                Status = "C",
                DiscretionaryData = new DiscretionaryDataDto
                {
                    BillPay =
                    [
                        new BillPayDto
                        {
                            Biller = "Biller 7",
                            ReferenceNumber = "BPY7",
                            BillAccountNumber = "**** **** **** 5678",
                            Amount = 100,
                            Fee = 10
                        }
                    ]
                }

            });

            transactions.Add (new TransactionDetailDto
            {
                TransactionUid = "8d66008f-a02d-4a61-9232-1c54097801c4",
                TransactionId = "TRN1051",
                Terminald = "terminal-020",
                TransactionDttm = transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss"),
                Amount = 150,
                Fee = 15,
                Currency = "USD",
                TransactionType = "RSND",
                Status = "C",
                DiscretionaryData = new DiscretionaryDataDto
                {
                    RemittanceSend =
                    [
                        new RemittanceSendDto
                        {
                            Receiver = "User 7",
                            ReceiveMethod = "12 Day Service",
                            ReferenceNumber = "RSND7",
                            Amount = 150,
                            Fee = 15
                        }
                    ]
                }
            });

            transactions.Add(new TransactionDetailDto
            {
                TransactionUid = "d574e46c-a5e6-43d2-9b77-a2d9b1ac4b45",
                TransactionId = "TRN1052",
                Terminald = "terminal-021",
                TransactionDttm = transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss"),
                Amount = 300,
                Fee = 30,
                Currency = "USD",
                TransactionType = "TKTP",
                Status = "C",
                DiscretionaryData = new DiscretionaryDataDto
                {
                    PlayTicket =
                    [
                        new PlayTicketDto
                        {
                            TicketCount = 1,
                            Tickets =
                            [
                                new TicketDto
                                {
                                    TicketUid = "aaaaaaaa-aaaa-aaaaaaaaaaaa",
                                    TicketId = "TKTP7",
                                    TicketAllocated = true,
                                    TicketRedeemedSuccessfully = true,
                                    TicketCreatedDateTime = DateTime.Parse(transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss")),
                                    TicketCompletedDateTime = transactionDateEastern.AddDays(-random.Next(1, 30)),
                                    TicketStatus = 'R',
                                    FaceValue = 100,
                                    Notes = "Redeemed ticket."
                                }
                            ]
                        }
                    ]
                }
            });

            transactions.Add (new TransactionDetailDto
            {
                TransactionUid = "b70f3c96-9f94-4127-8cdb-5a0f22c202b8",
                TransactionId = "TRN1053",
                Terminald = "terminal-022",
                TransactionDttm = transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss"),
                Amount = 100,
                Fee = 10,
                Currency = "USD",
                TransactionType = "BPY",
                Status = "C",
                DiscretionaryData = new DiscretionaryDataDto
                {
                    BillPay =
                    [
                        new BillPayDto
                        {
                            Biller = "Biller 8",
                            ReferenceNumber = "BPY8",
                            BillAccountNumber = "**** **** **** 9012",
                            Amount = 100,
                            Fee = 10
                        }
                    ]
                }
            });

            transactions.Add(new TransactionDetailDto
            {
                TransactionUid = "ca4d2099-e67c-4438-a6af-896fb9851adf",
                TransactionId = "TRN1054",
                Terminald = "terminal-023",
                TransactionDttm = transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss"),
                Amount = 150,
                Fee = 15,
                Currency = "USD",
                TransactionType = "RSND",
                Status = "C",
                DiscretionaryData = new DiscretionaryDataDto
                {
                    RemittanceSend =
                    [
                        new RemittanceSendDto
                        {
                            Receiver = "User 8",
                            ReceiveMethod = "14 Day Service",
                            ReferenceNumber = "RSND8",
                            Amount = 150,
                            Fee = 15
                        }
                    ]
                }
            });

            transactions.Add(new TransactionDetailDto
            {
                TransactionUid = "26803eb2-ce11-4249-93df-6cc80040a0dd",
                TransactionId = "TRN1055",
                Terminald = "terminal-024",
                TransactionDttm = transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss"),
                Amount = 300,
                Fee = 30,
                Currency = "USD",
                TransactionType = "TKTP",
                Status = "C",
                DiscretionaryData = new DiscretionaryDataDto
                {
                    PlayTicket =
                    [
                        new PlayTicketDto
                        {
                            TicketCount = 1,
                            Tickets =
                            [
                                new TicketDto
                                {
                                    TicketUid = "bbbbbbbb-bbbb-bbbbbbbbbbbb",
                                    TicketId = "TKTP8",
                                    TicketAllocated = true,
                                    TicketRedeemedSuccessfully = true,
                                    TicketCreatedDateTime = DateTime.Parse(transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss")),
                                    TicketCompletedDateTime = transactionDateEastern.AddDays(-random.Next(1, 30)),
                                    TicketStatus = 'R',
                                    FaceValue = 100,
                                    Notes = "Redeemed ticket."
                                }
                            ]
                        }
                    ]
                }

            });

            transactions.Add(new TransactionDetailDto
            {
                TransactionUid = "8788c34a-ea33-48f4-a2d8-ee74e5858a4d",
                TransactionId = "TRN1056",
                Terminald = "terminal-025",
                TransactionDttm = transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss"),
                Amount = 100,
                Fee = 10,
                Currency = "USD",
                TransactionType = "BPY",
                Status = "C",
                DiscretionaryData = new DiscretionaryDataDto
                {
                    BillPay =
                    [
                        new BillPayDto
                        {
                            Biller = "Biller 9",
                            ReferenceNumber = "BPY9",
                            BillAccountNumber = "**** **** **** 3456",
                            Amount = 100,
                            Fee = 10
                        }
                    ]
                }
            });

            transactions.Add(new TransactionDetailDto
            {
                TransactionUid = "ae079229-ead9-43cb-b9ae-26247758ab40",
                TransactionId = "TRN1057",
                Terminald = "terminal-026",
                TransactionDttm = transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss"),
                Amount = 150,
                Fee = 15,
                Currency = "USD",
                TransactionType = "RSND",
                Status = "C",
                DiscretionaryData = new DiscretionaryDataDto
                {
                    RemittanceSend =
                    [
                        new RemittanceSendDto
                        {
                            Receiver = "User 9",
                            ReceiveMethod = "16 Day Service",
                            ReferenceNumber = "RSND9",
                            Amount = 150,
                            Fee = 15
                        }
                    ]
                }
            });

            transactions.Add(new TransactionDetailDto
            {
                TransactionUid = "42927b10-bc5f-4a8f-bf8c-39229a2198a6",
                TransactionId = "TRN1058",
                Terminald = "terminal-027",
                TransactionDttm = transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss"),
                Amount = 300,
                Fee = 30,
                Currency = "USD",
                TransactionType = "TKTP",
                Status = "C",
                DiscretionaryData = new DiscretionaryDataDto
                {
                    PlayTicket =
                    [
                        new PlayTicketDto
                        {
                            TicketCount = 1,
                            Tickets =
                            [
                                new TicketDto
                                {
                                    TicketUid = "cccccccc-cccc-cccccccccccc",
                                    TicketId = "TKTP9",
                                    TicketAllocated = true,
                                    TicketRedeemedSuccessfully = true,
                                    TicketCreatedDateTime = DateTime.Parse(transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss")),
                                    TicketCompletedDateTime = transactionDateEastern.AddDays(-random.Next(1, 30)),
                                    TicketStatus = 'R',
                                    FaceValue = 100,
                                    Notes = "Redeemed ticket."
                                }
                            ]
                        }
                    ]
                }
            });

            transactions.Add(new TransactionDetailDto
            {   
                TransactionUid = "0476595a-811c-44ba-aaab-a5eee14b41b2",
                TransactionId = "TRN1059",
                Terminald = "terminal-028",
                TransactionDttm = transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss"),
                Amount = 100,
                Fee = 10,
                Currency = "USD",
                TransactionType = "BPY",
                Status = "C",
                DiscretionaryData = new DiscretionaryDataDto
                {
                    BillPay =
                    [
                        new BillPayDto
                        {
                            Biller = "Biller 10",
                            ReferenceNumber = "BPY10",
                            BillAccountNumber = "**** **** **** 7890",
                            Amount = 100,
                            Fee = 10
                        }
                    ]
                }
            });

            transactions.Add(new TransactionDetailDto
            {
                TransactionUid = "5ca60b2a-4ba4-4cd0-b4e7-136a47dfb1ab",
                TransactionId = "TRN1060",
                Terminald = "terminal-029",
                TransactionDttm = transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss"),
                Amount = 150,
                Fee = 15,
                Currency = "USD",
                TransactionType = "RSND",
                Status = "C",
                DiscretionaryData = new DiscretionaryDataDto
                {
                    RemittanceSend =
                    [
                        new RemittanceSendDto
                        {
                            Receiver = "User 10",
                            ReceiveMethod = "18 Day Service",
                            ReferenceNumber = "RSND10",
                            Amount = 150,
                            Fee = 15
                        }
                    ]
                }
            });

            transactions.Add(new TransactionDetailDto
            {
                TransactionUid = "2f8e006a-1552-44bc-88b1-ecb27839c324",
                TransactionId = "TRN1061",
                Terminald = "terminal-030",
                TransactionDttm = transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss"),
                Amount = 300,
                Fee = 15,
                Currency = "USD",
                TransactionType = "TKTP",
                Status = "C",
                DiscretionaryData = new DiscretionaryDataDto
                {
                    PlayTicket =
                    [
                        new PlayTicketDto
                        {
                            TicketCount = 1,
                            Tickets =
                            [
                                new TicketDto
                                {
                                    TicketUid = "dddddddd-dddd-dddddddddddd",
                                    TicketId = "TKTP10",
                                    TicketAllocated = true,
                                    TicketRedeemedSuccessfully = true,
                                    TicketCreatedDateTime = DateTime.Parse(transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss")),
                                    TicketCompletedDateTime = transactionDateEastern.AddDays(-random.Next(1, 30)),
                                    TicketStatus = 'R',
                                    FaceValue = 100,
                                    Notes = "Redeemed ticket."
                                }
                            ]
                        }
                    ]
                }
            });

            transactions.Add (new TransactionDetailDto
            {
                TransactionUid = "dda683f8-ba37-48a1-ac88-b7ac1eced51e",
                TransactionId = "TRN1062",
                Terminald = "terminal-031",
                TransactionDttm = transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss"),
                Amount = 100,
                Fee = 10,
                Currency = "USD",
                TransactionType = "BPY",
                Status = "C",
                DiscretionaryData = new DiscretionaryDataDto
                {
                    BillPay =
                    [
                        new BillPayDto
                        {
                            Biller = "Biller 11",
                            ReferenceNumber = "BPY11",
                            BillAccountNumber = "**** **** **** 1357",
                            Amount = 100,
                            Fee = 10
                        }
                    ]
                }
            });

            transactions.Add(new TransactionDetailDto
            {
                TransactionUid = "c8f957f5-1ca0-4ce9-9269-7559a4a41222",
                TransactionId = "TRN1063",
                Terminald = "terminal-032",
                TransactionDttm = transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss"),
                Amount = 150,
                Fee = 15,
                Currency = "USD",
                TransactionType = "RSND",
                Status = "C",
                DiscretionaryData = new DiscretionaryDataDto
                {
                    RemittanceSend =
                    [
                        new RemittanceSendDto
                        {
                            Receiver = "User 11",
                            ReceiveMethod = "20 Day Service",
                            ReferenceNumber = "RSND11",
                            Amount = 150,
                            Fee = 15
                        }
                    ]
                }
            });

            transactions.Add(new TransactionDetailDto
            {
                TransactionUid = "37e90689-5171-41ae-843e-9de6fce78d7c",
                TransactionId = "TRN1064",
                Terminald = "terminal-033",
                TransactionDttm = transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss"),
                Amount = 300,
                Fee = 30,
                Currency = "USD",
                TransactionType = "TKTP",
                Status = "C",
                DiscretionaryData = new DiscretionaryDataDto
                {
                    PlayTicket =
                    [
                        new PlayTicketDto
                        {
                            TicketCount = 1,
                            Tickets =
                            [
                                new TicketDto
                                {
                                    TicketUid = "eeeeeeee-eeee-eeeeeeeeeeee",
                                    TicketId = "TKTP11",
                                    TicketAllocated = true,
                                    TicketRedeemedSuccessfully = true,
                                    TicketCreatedDateTime = DateTime.Parse(transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss")),
                                    TicketCompletedDateTime = transactionDateEastern.AddDays(-random.Next(1, 30)),
                                    TicketStatus = 'R',
                                    FaceValue = 100,
                                    Notes = "Redeemed ticket."
                                }
                            ]
                        }
                    ]
                }
            });

            transactions.Add(new TransactionDetailDto
            {
                TransactionUid = "38dc14bb-2e18-4d36-a1e6-396ab9b6f748",
                TransactionId = "TRN1065",
                Terminald = "terminal-034",
                TransactionDttm = transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss"),
                Amount = 100,
                Fee = 10,
                Currency = "USD",
                TransactionType = "BPY",
                Status = "C",
                DiscretionaryData = new DiscretionaryDataDto
                {
                    BillPay =
                    [
                        new BillPayDto
                        {
                            Biller = "Biller 12",
                            ReferenceNumber = "BPY12",
                            BillAccountNumber = "**** **** **** 2468",
                            Amount = 100,
                            Fee = 10
                        }
                    ]
                }
            });

            transactions.Add(new TransactionDetailDto
            {
                TransactionUid = "6b5a37ea-e85a-4d3a-93be-b9c60a3e248c",
                TransactionId = "TRN1066",
                Terminald = "terminal-035",
                TransactionDttm = transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss"),
                Amount = 150,
                Fee = 15,
                Currency = "USD",
                TransactionType = "RSND",
                Status = "C",
                DiscretionaryData = new DiscretionaryDataDto
                {
                    RemittanceSend =
                    [
                        new RemittanceSendDto
                        {
                            Receiver = "User 12",
                            ReceiveMethod = "22 Day Service",
                            ReferenceNumber = "RSND12",
                            Amount = 150,
                            Fee = 15
                        }
                    ]
                }
            });

            transactions.Add(new TransactionDetailDto
            {
                TransactionUid = "c93dff91-45a2-46b8-848e-1d55077a31f8",
                TransactionId = "TRN1068",
                Terminald = "terminal-036",
                TransactionDttm = transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss"),
                Amount = 300,
                Fee = 30,
                Currency = "USD",
                TransactionType = "TKTP",
                Status = "C",
                DiscretionaryData = new DiscretionaryDataDto
                {
                    PlayTicket =
                    [
                        new PlayTicketDto
                        {
                            TicketCount = 1,
                            Tickets =
                            [
                                new TicketDto
                                {
                                    TicketUid = "ffffffff-ffff-ffffffffffff",
                                    TicketId = "TKTP12",
                                    TicketAllocated = true,
                                    TicketRedeemedSuccessfully = true,
                                    TicketCreatedDateTime = DateTime.Parse(transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss")),
                                    TicketCompletedDateTime = transactionDateEastern.AddDays(-random.Next(1, 30)),
                                    TicketStatus = 'R',
                                    FaceValue = 100,
                                    Notes = "Redeemed ticket."
                                }
                            ]
                        }
                    ]
                }
            });

            transactions.Add(new TransactionDetailDto
            {
                TransactionUid = "5ce53903-116d-45fe-83c3-1526e62ecdbc",
                TransactionId = "TRN1069",
                Terminald = "terminal-037",
                TransactionDttm = transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss"),
                Amount = 100,
                Fee = 10,
                Currency = "USD",
                TransactionType = "BPY",
                Status = "C",
                DiscretionaryData = new DiscretionaryDataDto
                {
                    BillPay =
                    [
                        new BillPayDto
                        {
                            Biller = "Biller 13",
                            ReferenceNumber = "BPY13",
                            BillAccountNumber = "**** **** **** 3579",
                            Amount = 100,
                            Fee = 10
                        }
                    ]
                }
            });

            transactions.Add(new TransactionDetailDto
            {
                TransactionUid = "8df3a8cf-50ba-47cd-b4f9-fab425309b40",
                TransactionId = "TRN1070",
                Terminald = "terminal-038",
                TransactionDttm = transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss"),
                Amount = 150,
                Fee = 15,
                Currency = "USD",
                TransactionType = "RSND",
                Status = "C",
                DiscretionaryData = new DiscretionaryDataDto
                {
                    RemittanceSend =
                    [
                        new RemittanceSendDto
                        {
                            Receiver = "User 13",
                            ReceiveMethod = "24 Day Service",
                            ReferenceNumber = "RSND13",
                            Amount = 150,
                            Fee = 15
                        }
                    ]
                }
            });

            transactions.Add(new TransactionDetailDto
            {
                TransactionUid = "fc20270b-8430-4801-a333-0b75f1fb81f9",
                TransactionId = "TRN1071",
                Terminald = "terminal-039",
                TransactionDttm = transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss"),
                Amount = 300,
                Fee = 30,
                Currency = "USD",
                TransactionType = "TKTP",
                Status = "C",
                DiscretionaryData = new DiscretionaryDataDto
                {
                    PlayTicket =
                    [
                        new PlayTicketDto
                        {
                            TicketCount = 1,
                            Tickets =
                            [
                                new TicketDto
                                {
                                    TicketUid = "gggggggg-gggg-gggggggggggg",
                                    TicketId = "TKTP13",
                                    TicketAllocated = true,
                                    TicketRedeemedSuccessfully = true,
                                    TicketCreatedDateTime = DateTime.Parse(transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss")),
                                    TicketCompletedDateTime = transactionDateEastern.AddDays(-random.Next(1, 30)),
                                    TicketStatus = 'R',
                                    FaceValue = 100,
                                    Notes = "Redeemed ticket."
                                }
                            ]
                        }
                    ]
                }

            });

            transactions.Add(new TransactionDetailDto
            {
                TransactionUid = "ae58575e-cb24-4b3a-9643-61a72b6b5fd3",
                TransactionId = "TRN1072",
                Terminald = "terminal-040",
                TransactionDttm = transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss"),
                Amount = 100,
                Fee = 10,
                Currency = "USD",
                TransactionType = "BPY",
                Status = "C",
                DiscretionaryData = new DiscretionaryDataDto
                {
                    BillPay =
                    [
                        new BillPayDto
                        {
                            Biller = "Biller 14",
                            ReferenceNumber = "BPY14",
                            BillAccountNumber = "**** **** **** 4680",
                            Amount = 100,
                            Fee = 10
                        }
                    ]
                }
            });

            transactions.Add (new TransactionDetailDto
            {
                TransactionUid = "cfc503fd-8340-48dd-bdd7-19a4987f155a",
                TransactionId = "TRN1073",
                Terminald = "terminal-041",
                TransactionDttm = transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss"),
                Amount = 150,
                Fee = 15,
                Currency = "USD",
                TransactionType = "RSND",
                Status = "C",
                DiscretionaryData = new DiscretionaryDataDto
                {
                    RemittanceSend =
                    [
                        new RemittanceSendDto
                        {
                            Receiver = "User 14",
                            ReceiveMethod = "26 Day Service",
                            ReferenceNumber = "RSND14",
                            Amount = 150,
                            Fee = 15
                        }
                    ]
                }
            });

            transactions.Add(new TransactionDetailDto
            {
                TransactionUid = "0a22f1f9-1c03-40a7-96a1-bbc05d36df75",
                TransactionId = "TRN1074",
                Terminald = "terminal-042",
                TransactionDttm = transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss"),
                Amount = 300,
                Fee = 30,
                Currency = "USD",
                TransactionType = "TKTP",
                Status = "C",
                DiscretionaryData = new DiscretionaryDataDto
                {
                    PlayTicket =
                    [
                        new PlayTicketDto
                        {
                            TicketCount = 1,
                            Tickets =
                            [
                                new TicketDto
                                {
                                    TicketUid = "hhhhhhhh-hhhh-hhhhhhhhhhhh",
                                    TicketId = "TKTP14",
                                    TicketAllocated = true,
                                    TicketRedeemedSuccessfully = true,
                                    TicketCreatedDateTime = DateTime.Parse(transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss")),
                                    TicketCompletedDateTime = transactionDateEastern.AddDays(-random.Next(1, 30)),
                                    TicketStatus = 'R',
                                    FaceValue = 100,
                                    Notes = "Redeemed ticket."
                                }
                            ]
                        }
                    ]
                }
            });

            transactions.Add(new TransactionDetailDto
            {
                TransactionUid = "e45a1ab3-8481-4524-9442-6d88413c3650",
                TransactionId = "TRN1075",
                Terminald = "terminal-043",
                TransactionDttm = transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss"),
                Amount = 100,
                Fee = 10,
                Currency = "USD",
                TransactionType = "BPY",
                Status = "C",
                DiscretionaryData = new DiscretionaryDataDto
                {
                    BillPay =
                    [
                        new BillPayDto
                        {
                            Biller = "Biller 15",
                            ReferenceNumber = "BPY15",
                            BillAccountNumber = "**** **** **** 5791",
                            Amount = 100,
                            Fee = 10
                        }
                    ]
                }
            });

            transactions.Add(new TransactionDetailDto
            {
                TransactionUid = "1c578935-f6df-4e59-bc3f-a783d4386f74",
                TransactionId = "TRN1076",
                Terminald = "terminal-044",
                TransactionDttm = transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss"),
                Amount = 150,
                Fee = 15,
                Currency = "USD",
                TransactionType = "RSND",
                Status = "C",
                DiscretionaryData = new DiscretionaryDataDto
                {
                    RemittanceSend =
                    [
                        new RemittanceSendDto
                        {
                            Receiver = "User 15",
                            ReceiveMethod = "28 Day Service",
                            ReferenceNumber = "RSND15",
                            Amount = 150,
                            Fee = 15
                        }
                    ]
                }
            });

            transactions.Add(new TransactionDetailDto
            {
                TransactionUid = "451419c9-7975-410b-aba9-1c696818b63f",
                TransactionId = "TRN1077",
                Terminald = "terminal-045",
                TransactionDttm = transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss"),
                Amount = 300,
                Fee = 30,
                Currency = "USD",
                TransactionType = "TKTP",
                Status = "C",
                DiscretionaryData = new DiscretionaryDataDto
                {
                    PlayTicket =
                    [
                        new PlayTicketDto
                        {
                            TicketCount = 1,
                            Tickets =
                            [
                                new TicketDto
                                {
                                    TicketUid = "iiiiiiii-iiii-iiiiiiiiiiii",
                                    TicketId = "TKTP15",
                                    TicketAllocated = true,
                                    TicketRedeemedSuccessfully = true,
                                    TicketCreatedDateTime = DateTime.Parse(transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss")),
                                    TicketCompletedDateTime = transactionDateEastern.AddDays(-random.Next(1, 30)),
                                    TicketStatus = 'R',
                                    FaceValue = 100,
                                    Notes = "Redeemed ticket."
                                }
                            ]
                        }
                    ]
                }
            });

            transactions.Add(new TransactionDetailDto
            {
                TransactionUid = "024624b6-5818-4153-808f-a2e20195b93f",
                TransactionId = "TRN1078",
                Terminald = "terminal-046",
                TransactionDttm = transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss"),
                Amount = 100,
                Fee = 10,
                Currency = "USD",
                TransactionType = "BPY",
                Status = "C",
                DiscretionaryData = new DiscretionaryDataDto
                {
                    BillPay =
                    [
                        new BillPayDto
                        {
                            Biller = "Biller 16",
                            ReferenceNumber = "BPY16",
                            BillAccountNumber = "**** **** **** 6802",
                            Amount = 100,
                            Fee = 10
                        }
                    ]
                }
            });

            transactions.Add(new TransactionDetailDto
            {
                TransactionUid = "33aab5c8-cf84-4cf4-af8c-954500c1009e",
                TransactionId = "TRN1079",
                Terminald = "terminal-047",
                TransactionDttm = transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss"),
                Amount = 150,
                Fee = 15,
                Currency = "USD",
                TransactionType = "RSND",
                Status = "C",
                DiscretionaryData = new DiscretionaryDataDto
                {
                    RemittanceSend =
                    [
                        new RemittanceSendDto
                        {
                            Receiver = "User 16",
                            ReceiveMethod = "30 Day Service",
                            ReferenceNumber = "RSND16",
                            Amount = 150,
                            Fee = 15
                        }
                    ]
                }
            });

            transactions.Add(new TransactionDetailDto
            {
                TransactionUid = "a50d5a00-bed8-4f07-bb10-480b32e94dd9",
                TransactionId = "TRN1080",
                Terminald = "terminal-048",
                TransactionDttm = transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss"),
                Amount = 300,
                Fee = 30,
                Currency = "USD",
                TransactionType = "TKTP",
                Status = "C",
                DiscretionaryData = new DiscretionaryDataDto
                {
                    PlayTicket =
                    [
                        new PlayTicketDto
                        {
                            TicketCount = 1,
                            Tickets =
                            [
                                new TicketDto
                                {
                                    TicketUid = "jjjjjjjj-jjjj-jjjjjjjjjjjj",
                                    TicketId = "TKTP16",
                                    TicketAllocated = true,
                                    TicketRedeemedSuccessfully = true,
                                    TicketCreatedDateTime = DateTime.Parse(transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss")),
                                    TicketCompletedDateTime = transactionDateEastern.AddDays(-random.Next(1, 30)),
                                    TicketStatus = 'R',
                                    FaceValue = 100,
                                    Notes = "Redeemed ticket."
                                }
                            ]
                        }
                    ]
                }
            });

            transactions.Add(new TransactionDetailDto
            {
                TransactionUid = "51a4be72-e2fc-4812-ac84-bafbf2367676",
                TransactionId = "TRN1081",
                Terminald = "terminal-049",
                TransactionDttm = transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss"),
                Amount = 100,
                Fee = 10,
                Currency = "USD",
                TransactionType = "BPY",
                Status = "C",
                DiscretionaryData = new DiscretionaryDataDto
                {
                    BillPay =
                    [
                        new BillPayDto
                        {
                            Biller = "Biller 17",
                            ReferenceNumber = "BPY17",
                            BillAccountNumber = "**** **** **** 7913",
                            Amount = 100,
                            Fee = 10
                        }
                    ]
                }
            });

            transactions.Add(new TransactionDetailDto
            {
                TransactionUid = "2a41f4a7-83f6-491b-85b5-cd56fb48606a",
                TransactionId = "TRN1082",
                Terminald = "terminal-050",
                TransactionDttm = transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss"),
                Amount = 150,
                Fee = 15,
                Currency = "USD",
                TransactionType = "RSND",
                Status = "C",
                DiscretionaryData = new DiscretionaryDataDto
                {
                    RemittanceSend =
                    [
                        new RemittanceSendDto
                        {
                            Receiver = "User 17",
                            ReceiveMethod = "32 Day Service",
                            ReferenceNumber = "RSND17",
                            Amount = 150,
                            Fee = 15
                        }
                    ]
                }
            });

            transactions.Add(new TransactionDetailDto
            {
                TransactionUid = "a500ba61-03b3-42ef-a024-02f468730ac7",
                TransactionId = "TRN1083",
                Terminald = "terminal-051",
                TransactionDttm = transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss"),
                Amount = 300,
                Fee = 30,
                Currency = "USD",
                TransactionType = "TKTP",
                Status = "C",
                DiscretionaryData = new DiscretionaryDataDto
                {
                    PlayTicket =
                    [
                        new PlayTicketDto
                        {
                            TicketCount = 1,
                            Tickets =
                            [
                                new TicketDto
                                {
                                    TicketUid = "kkkkkkkk-kkkk-kkkkkkkkkkkk",
                                    TicketId = "TKTP17",
                                    TicketAllocated = true,
                                    TicketRedeemedSuccessfully = true,
                                    TicketCreatedDateTime = DateTime.Parse(transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss")),
                                    TicketCompletedDateTime = transactionDateEastern.AddDays(-random.Next(1, 30)),
                                    TicketStatus = 'R',
                                    FaceValue = 100,
                                    Notes = "Redeemed ticket."
                                }
                            ]
                        }
                    ]
                }
            });

            transactions.Add(new TransactionDetailDto
            {
                TransactionUid = "94c85e0a-d920-4190-ab55-cc41335abd5d",
                TransactionId = "TRN1084",
                Terminald = "terminal-052",
                TransactionDttm = transactionDateEastern.ToString("yyyy-MM-ddTHH:mm:ss"),
                Amount = 100,
                Fee = 10,
                Currency = "USD",
                TransactionType = "BPY",
                Status = "C",
                DiscretionaryData = new DiscretionaryDataDto
                {
                    BillPay =
                    [
                        new BillPayDto
                        {
                            Biller = "Biller 18",
                            ReferenceNumber = "BPY18",
                            BillAccountNumber = "**** **** **** 8024",
                            Amount = 100,
                            Fee = 10
                        }
                    ]
                }
            });
        }

        return new ResponseDto
        {
            Transactions = transactions,
            TotalRecordsFound = transactions.Count
        };
    }
}

