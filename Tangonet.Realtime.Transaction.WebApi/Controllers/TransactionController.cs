using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Tangonet.Realtime.Transaction.WebApi.Dtos;
using Tangonet.Realtime.Transaction.WebApi.Interfaces;

namespace Tangonet.Realtime.Transaction.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TransactionController(ITransactionAppService transactionAppService)
        : ControllerBase
{
    private readonly ITransactionAppService _transactionAppService = transactionAppService;

    [HttpGet("get-transaction")]
    public async Task<TransactionDto.ResponseDto> GetAsync(
        [Required] string fromDate, string toDate, string transactionId, string maxCount , string transactionState, string terminalId)
    {
        return await  _transactionAppService.GetTransactionAsync(
            fromDate, toDate, transactionId, maxCount, transactionState, terminalId);
    }
}
