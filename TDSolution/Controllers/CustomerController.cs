using Microsoft.AspNetCore.Mvc;
using TDSolution.DTOs;
using TDSolution.Services;

namespace TDSolution.Controllers
{
    [Route("api/customers")]
    public class CustomerController : AuthController
    {
        private ICustomerService _service;

        public CustomerController(ICustomerService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<ResultDto> GetCustomers([FromQuery] FilterDto FilterDto)
        {
            try
            {
                var data = _service.Filter(FilterDto);
                return Ok(BuildResDto(data));
            }
            catch (Exception exx)
            {
                return BadRequest(BuildResDto(null, null, exx));
            }
        }

        [HttpPost]
        public ActionResult<ResultDto> Create([FromBody] CustomerDto customerDto)
        {
            try
            {
                var data = _service.Create(customerDto);
                return Ok(BuildResDto(data));
            }
            catch (Exception exx)
            {
                return BadRequest(BuildResDto(null, null, exx));
            }
        }

        [HttpPut("{id}")]
        public ActionResult<ResultDto> Update(int id, [FromBody] CustomerDto customerDto)
        {
            try
            {
                var data = _service.Update(id, customerDto);
                return Ok(BuildResDto(data));
            }
            catch (Exception exx)
            {
                return BadRequest(BuildResDto(null, null, exx));
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<ResultDto> Removes(int id)
        {
            try
            {
                var data = _service.Remove(id);
                return Ok(BuildResDto(data));
            }
            catch (Exception exx)
            {
                return BadRequest(BuildResDto(null, null, exx));
            }
        }
    }
}