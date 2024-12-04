using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tangonet.Realtime.Transaction.WebApi.Dtos;
using Tangonet.Realtime.Transaction.WebApi.Helpers;
using Tangonet.Realtime.Transaction.WebApi.Interfaces;
using Tangonet.Realtime.Transaction.WebApi.Models;

namespace Tangonet.Realtime.Transaction.WebApi.Controllers;

[Authorize]
[Route("/api/v1/")]
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
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorResponse))]
    public IActionResult GetAsync(
        [Required] string fromDate, string toDate, string transactionId, string lastTransactionIdPassed, string batchSize)
    {
        string traceId = HttpContext.TraceIdentifier;
        _logger.LogInformation(
            "Request processed. TraceId: {traceId}", traceId);

        try
        {
            var validationErrors = new List<string>();

            if (!ValidationHelper.IsDateFormat(fromDate))
            {
                validationErrors.Add($"Invalid request FromDateTime. Please use yyyy-MM-dd format. {fromDate}");
            }

            if (!string.IsNullOrWhiteSpace(toDate) && !ValidationHelper.IsDateFormat(toDate))
            {
                validationErrors.Add($"Invalid request ToDateTime. Please use yyyy-MM-dd format. {toDate}");
            }

            if (!string.IsNullOrWhiteSpace(transactionId) && !ValidationHelper.IsGuidFormat(transactionId))
            {
                validationErrors.Add($"Invalid request TransactionId. Please use guid format. {transactionId}");
            }

            if (!string.IsNullOrWhiteSpace(lastTransactionIdPassed) && !ValidationHelper.IsGuidFormat(lastTransactionIdPassed))
            {
                validationErrors.Add($"Invalid request LastTransactionId. Please use guid format. {lastTransactionIdPassed}");
            }

            if (validationErrors.Count != 0)
            {
                return BadRequest(ErrorResponse.BadRequest(string.Join(" ", validationErrors), traceId));
            }

            var response = _transactionAppService.GetTransactionAsync(
                fromDate, toDate, transactionId,lastTransactionIdPassed,batchSize);

            if (response == null || response.Transactions == null || response.Transactions.Count == 0)
            {
                var noResultsMessage = "Transaction not found for the specified criteria. Check the following inputs: ";

                if (!ValidationHelper.IsDateFormat(fromDate))
                {
                    noResultsMessage += $"fromDate: {fromDate}; ";
                }

                if (!string.IsNullOrWhiteSpace(toDate) && !ValidationHelper.IsDateFormat(toDate))
                {
                    noResultsMessage += $"toDate: {toDate}; ";
                }

                if (!string.IsNullOrWhiteSpace(transactionId))
                {
                    noResultsMessage += $"transactionId: {transactionId}; ";
                }

                if (!string.IsNullOrWhiteSpace(lastTransactionIdPassed))
                {
                    noResultsMessage += $"lastTransactionIdPassed: {lastTransactionIdPassed}; ";
                }

                return NotFound(ErrorResponse.NotFound(noResultsMessage.TrimEnd(';', ' '), traceId));
            }

            return Ok(response);
        }
        catch (Exception ex)
        {
            return StatusCode(
                StatusCodes.Status500InternalServerError, ErrorResponse.InternalServerError(ex.Message, traceId));
        }
    }
}
