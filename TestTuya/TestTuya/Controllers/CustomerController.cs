using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestTuya.AppServices.Contracts;
using TestTuya.DTOs.RequestDTOs;
using TestTuya.Models;

namespace TestTuya.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly TestTuyaIContext _context;
        private readonly IAppServices _appServices;

        public CustomerController(TestTuyaIContext context, IAppServices appServices)
        {
            _context = context;
            _appServices = appServices;
        }

        // GET: Customers
        [HttpGet]
        public async Task<ActionResult<List<Customer>>> GetCustomersAsync()
        {
            var customer = await _appServices.GetCustomersAsync();
            //return await _appServices.InsertCustomer(requestInsertCustomerDTO);
            return Ok(customer);

        }


        //// GET: Customers/Details/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomerByIdAsync(int? id)
        {
            var customer = await _appServices.GetCustomerByIdAsync(id);

            if (customer == null) return NotFound();

            return Ok(customer);
        }

        //POST: Customers/Create
        [HttpPost]
        public async Task<ActionResult<Customer>> CreateCustomerAsync(RequestInsertCustomerDTO customer)
        {

            await _appServices.CreateCustomerAsync(customer);
            return Ok(customer);


        }

        //// Put: Customers/Edit/5
        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> EditCustomer(int? id, [FromBody] Customer customers)
        {
            return await _appServices.EditCustomerAsync(id, customers);
        }

        //// GET: Customers/Delete/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteCustomerAsync(int? id)
        {
            return await _appServices.DeleteCustomerAsync(id);
        }
    }
}
