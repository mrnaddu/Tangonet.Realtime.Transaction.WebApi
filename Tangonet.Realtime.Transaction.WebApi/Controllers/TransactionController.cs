using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Tangonet.Realtime.Transaction.WebApi.Dtos;
using Tangonet.Realtime.Transaction.WebApi.Helpers;
using Tangonet.Realtime.Transaction.WebApi.Interfaces;
using Tangonet.Realtime.Transaction.WebApi.Models;

namespace Tangonet.Realtime.Transaction.WebApi.Controllers;

[Route("/api/tangonet-real-time/")]
[ApiController]
public class TransactionController(
    ITransactionAppService transactionAppService,
    ILogger<TransactionController> logger)
        : ControllerBase
{
    private readonly ITransactionAppService _transactionAppService = transactionAppService;
    private readonly ILogger<TransactionController> _logger = logger;

    [HttpGet("transaction")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TransactionDto.ResponseDto))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
    public IActionResult GetAsync(
    [Required] string fromDate,
    string toDate,
    string transactionId,
    string maxCount,
    string transactionState,
    string terminalId)
    {
        string traceId = HttpContext.TraceIdentifier;
        _logger.LogInformation("Request processed. TraceId: {traceId}", traceId);

        try
        {
            var validationErrors = new List<string>();

            if (!ValidationHelper.IsDateFormat(fromDate))
            {
                validationErrors.Add($"Invalid request from date format. Please use yyyy-MM-dd format. {fromDate}");
            }

            if (!string.IsNullOrWhiteSpace(toDate) && !ValidationHelper.IsDateFormat(toDate))
            {
                validationErrors.Add($"Invalid request to date format. Please use yyyy-MM-dd format. {toDate}");
            }

            if (!string.IsNullOrWhiteSpace(maxCount) && !ValidationHelper.IsNumberFormat(maxCount))
            {
                validationErrors.Add($"Invalid request max count. Please use integer format. {maxCount}");
            }

            if (!string.IsNullOrWhiteSpace(transactionState) && !ValidationHelper.IsTransactionState(transactionState))
            {
                validationErrors.Add($"Invalid request transaction state. Please use one of the following values: C, Y, P. {transactionState}");
            }

            if (!string.IsNullOrWhiteSpace(terminalId) && !ValidationHelper.IsNumberFormat(terminalId))
            {
                validationErrors.Add($"Invalid request terminal id. Please use integer format. {terminalId}");
            }

            if (!string.IsNullOrWhiteSpace(transactionId) && !ValidationHelper.IsGuidFormat(transactionId))
            {
                validationErrors.Add($"Invalid request transaction id. Please use guid format. {transactionId}");
            }

            if (validationErrors.Count != 0)
            {
                return BadRequest(ErrorResponse.BadRequest(string.Join(" ", validationErrors), traceId));
            }

            var response = _transactionAppService.GetTransactionAsync(
                fromDate, toDate, transactionId, maxCount, transactionState, terminalId);

            return Ok(response);
        }
        catch (Exception ex)
        {
            return StatusCode(
                StatusCodes.Status500InternalServerError, ErrorResponse.InternalServerError(ex.Message, traceId));
        }
    }
}
