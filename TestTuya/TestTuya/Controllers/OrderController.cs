using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestTuya.AppServices.Contracts;
using TestTuya.DTOs.RequestDTOs;
using TestTuya.DTOs.Response;
using TestTuya.Models;

namespace TestTuya.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly TestTuyaIContext _context;
        private readonly IAppServices _appServices;

        public OrderController(TestTuyaIContext context, IAppServices appServices)
        {
            _context = context;
            _appServices = appServices;
        }

        [HttpGet]
        public async Task<ActionResult<List<Order>>> GetOrdersAsync()
        {
            return await _appServices.GetOrdersAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrdersByIdAsync(int? id)
        {
            var order = await _appServices.GetOrdersByIdAsync(id);

            if (order == null) return NotFound();

            return Ok(order);
        }

        [HttpPost]
        public async Task<Order> InsertOrderAsync(RequestInsertOrderDTO requestInsertOrderDTO)
        {
            return await _appServices.InsertOrderAsync(requestInsertOrderDTO);

        }

    }
}
