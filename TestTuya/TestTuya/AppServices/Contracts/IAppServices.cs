using Microsoft.AspNetCore.Mvc;
using TestTuya.DTOs.RequestDTOs;
using TestTuya.DTOs.Response;
using TestTuya.Models;

namespace TestTuya.AppServices.Contracts
{
    public interface IAppServices
    {
        //Customer
        Task<List<Customer>> GetCustomersAsync();
        Task<Customer> GetCustomerByIdAsync(int? id);
        Task<ActionResult<Customer>> CreateCustomerAsync(RequestInsertCustomerDTO customer);
        Task<ActionResult<bool>> EditCustomerAsync(int? id, Customer customers);

        Task<ActionResult<bool>> DeleteCustomerAsync(int? id);

        //ordenes
        Task<List<Order>> GetOrdersAsync();
        Task<Order> GetOrdersByIdAsync(int? id);
        Task<Order> InsertOrderAsync(RequestInsertOrderDTO requestInsertOrderDTO);
      
    }
}
