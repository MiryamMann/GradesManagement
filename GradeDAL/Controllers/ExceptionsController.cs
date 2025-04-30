using GradeDO.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GradeDAL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExceptionsController : ControllerBase
    {
        private readonly ILogger _logger;
        public ExceptionsController(ILogger<ExceptionsController> logger)
        {
            _logger = logger;
        }

        [HttpGet("/error")]
        [HttpPost("/error")]
        [HttpDelete("/error")]
        [HttpPut("/error")]
        public IActionResult HandleError()
        {
            var exceptionDetails = HttpContext.Features.Get<IExceptionHandlerFeature>();

            if (exceptionDetails != null)
            {
                _logger.LogError(exceptionDetails.Error.Message, "Error was throwed");
                _logger.LogDebug(exceptionDetails.Error, "");
            }
            if (exceptionDetails?.Error is StudentNotExistException NotEx)
            {
                _logger.LogWarning("The user sent a student which doesnt exists.");
                return Problem(
                detail: exceptionDetails?.Error.Message,
                title: "Wrong answer",
                statusCode: NotEx.StatusCode
                );

            }
            if (exceptionDetails?.Error is StudentAlreadyExistException ALRDYEx)
            {
                _logger.LogWarning("The user sent a student which already exists.");
                return Problem(
                detail: exceptionDetails?.Error.Message,
                title: "Wrong answer",
                statusCode: ALRDYEx.StatusCode
                );

            }
            return Problem(
                detail: "Please restart the website again",
                title: "An error occurred",
                statusCode: 500
            );

        }

    }
}
