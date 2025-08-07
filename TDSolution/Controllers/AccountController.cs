using Microsoft.AspNetCore.Mvc;
using TDSolution.Services;

namespace TDSolution.Controllers
{
    [Route("api/account")]
    public class AccountController : BaseController
    {
        private IAccountService _service;

        public AccountController(IAccountService service)
        {
            _service = service;
        }

        [HttpPost("login")]
        public ActionResult Login()
        {
            try
            {
                var data = _service.Login();
                return Ok(BuildResDto(data));
            }
            catch (Exception exx)
            {
                return BadRequest(BuildResDto(null, null, exx));
            }
        }
    }
}