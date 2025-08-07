using Microsoft.AspNetCore.Mvc;
using TDSolution.DTOs;
using TDSolution.Services;

namespace TDSolution.Controllers
{
    [Route("api/products")]
    public class ProductController : AuthController
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<ResultDto> GetProducts([FromQuery] ProductFilterDto filterDto)
        {
            try
            {
                var data = _service.Filter(filterDto);
                return Ok(BuildResDto(data));
            }
            catch (Exception exx)
            {
                return BadRequest(BuildResDto(null, null, exx));
            }
        }
    }
}