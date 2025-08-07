using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TDSolution.DTOs;

namespace TDSolution.Controllers
{
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected virtual ResultDto BuildResDto(object? data, string? message = null, Exception? exception = null)
        {
            if (exception != null) message += $"\nSome parts of the process have issues: {exception.Message}";
            return new ResultDto
            {
                IsSuccess = exception == null,
                Data = data,
                Message = message
            };
        }
    }

    [Authorize]
    public class AuthController : BaseController
    {
    }
}