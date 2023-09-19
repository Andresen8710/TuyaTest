using Microsoft.AspNetCore.Mvc;
using TestTuya.DTOs.RequestDTOs;
using TestTuya.DTOs.Response;
using TestTuya.Models;

namespace TestTuya.DomainServices.Contracts
{
    public interface IDomainServices
    {
        /*************************Orders**************************/
        Task<List<Order>> GetOrdersAsync();
        Task<Order> GetOrdersByIdAsync(int? id);
        Task<Order> InsertOrderAsync(RequestInsertOrderDTO requestInsertOrderDTO);

        /**************************Customers********************************/
        Task<List<Customer>> GetCustomersAsync();
        Task<Customer> GetCustomerByIdAsync(int? id);
        Task<ActionResult<Customer>> CreateCustomerAsync(RequestInsertCustomerDTO customer);
        Task<bool> EditCustomerAsync(Customer customer);
        Task<bool> DeleteCustomerAsync(Customer customer);

    }
}
