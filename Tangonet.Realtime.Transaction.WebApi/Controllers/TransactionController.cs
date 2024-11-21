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
    public IActionResult GetAsync(
        [Required] string fromDate, string toDate, string transactionId, string pageNumber , string pageSize, string maxCount, string transactionState, string terminalId)
    {
        string traceId = HttpContext.TraceIdentifier;
        _logger.LogInformation(
            "Request processed. TraceId: {traceId}", traceId);

        try
        {
            var validationErrors = new List<string>();

            if (!ValidationHelper.IsDateFormat(fromDate))
            {
                validationErrors.Add($"Invalid request FromDate. Please use yyyy-MM-dd format. {fromDate}");
            }

            if (!string.IsNullOrWhiteSpace(toDate) && !ValidationHelper.IsDateFormat(toDate))
            {
                validationErrors.Add($"Invalid request ToDate. Please use yyyy-MM-dd format. {toDate}");
            }

            if (!string.IsNullOrWhiteSpace(maxCount) && !ValidationHelper.IsNumberFormat(maxCount))
            {
                validationErrors.Add($"Invalid request MaxCount. Please use integer format. {maxCount}");
            }

            if (!string.IsNullOrWhiteSpace(pageNumber) && !ValidationHelper.IsNumberFormat(pageNumber))
            {
                validationErrors.Add($"Invalid request PageNumber. Please use integer format. {pageNumber}");
            }

            if (!string.IsNullOrWhiteSpace(pageSize) && !ValidationHelper.IsNumberFormat(pageSize))
            {
                validationErrors.Add($"Invalid request PageSize. Please use integer format. {pageSize}");
            }

            if (!string.IsNullOrWhiteSpace(transactionState) && !ValidationHelper.IsTransactionState(transactionState))
            {
                validationErrors.Add($"Invalid request TransactionState. Please use one of the following values: C, Y, P. {transactionState}");
            }

            if (!string.IsNullOrWhiteSpace(terminalId) && !ValidationHelper.IsAlphaNumericFormat(terminalId))
            {
                validationErrors.Add($"Invalid request TerminalId. Please use alphanumeric format. {terminalId}");
            }

            if (!string.IsNullOrWhiteSpace(transactionId) && !ValidationHelper.IsGuidFormat(transactionId))
            {
                validationErrors.Add($"Invalid request TransactionId. Please use guid format. {transactionId}");
            }

            if (validationErrors.Count != 0)
            {
                return BadRequest(ErrorResponse.BadRequest(string.Join(" ", validationErrors), traceId));
            }

            var response = _transactionAppService.GetTransactionAsync(
                fromDate, toDate, transactionId,pageNumber,pageSize, maxCount, transactionState, terminalId);

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

                if (!string.IsNullOrWhiteSpace(transactionState))
                {
                    noResultsMessage += $"transactionState: {transactionState}; ";
                }

                if (!string.IsNullOrWhiteSpace(terminalId))
                {
                    noResultsMessage += $"terminalId: {terminalId}; ";
                }

                if (!string.IsNullOrWhiteSpace(maxCount))
                {
                    noResultsMessage += $"maxCount: {maxCount}; ";
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
