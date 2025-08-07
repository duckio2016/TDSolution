using Microsoft.AspNetCore.Mvc;
using TDSolution.DTOs;
using TDSolution.Services;

namespace TDSolution.Controllers
{
    [Route("api/orders")]
    public class OrderController : AuthController
    {
        private readonly IOrderService _service;

        public OrderController(IOrderService service)
        {
            _service = service;
        }

        [HttpPost]
        public ActionResult<ResultDto> Create([FromBody] OrderCreateDto orderCreateDto)
        {
            try
            {
                var data = _service.Create(orderCreateDto);
                return Ok(BuildResDto(data));
            }
            catch (Exception exx)
            {
                return BadRequest(BuildResDto(null, null, exx));
            }
        }

        [HttpGet]
        public ActionResult<ResultDto> GetOrders([FromQuery] OrderFilterDto orderFilterDto)
        {
            try
            {
                var data = _service.Filter(orderFilterDto);
                return Ok(BuildResDto(data));
            }
            catch (Exception exx)
            {
                return BadRequest(BuildResDto(null, null, exx));
            }
        }

        [HttpGet("{id}")]
        public ActionResult<ResultDto> GetDetail(int id)
        {
            try
            {
                var data = _service.Detail(id);
                return Ok(BuildResDto(data));
            }
            catch (Exception exx)
            {
                return BadRequest(BuildResDto(null, null, exx));
            }
        }
    }
}