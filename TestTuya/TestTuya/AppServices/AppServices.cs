using Microsoft.AspNetCore.Mvc;
using TestTuya.AppServices.Contracts;
using TestTuya.DomainServices.Contracts;
using TestTuya.DTOs.RequestDTOs;
using TestTuya.DTOs.Response;
using TestTuya.Models;

namespace TestTuya.AppServices
{
    public class AppServices:IAppServices
    {
        private readonly TestTuyaIContext _context;
        private readonly IDomainServices _domainServices;
        public AppServices(TestTuyaIContext context, IDomainServices domainServices)
        {
            _context = context;
            _domainServices = domainServices;
        }

        public async Task<List<Customer>> GetCustomersAsync()
        {
            return await _domainServices.GetCustomersAsync();

        }

        public async Task<Customer> GetCustomerByIdAsync(int? id)
        {
            return await _domainServices.GetCustomerByIdAsync(id);
        }

        public async Task<ActionResult<Customer>> CreateCustomerAsync(RequestInsertCustomerDTO customer)
        {
            return await _domainServices.CreateCustomerAsync(customer);
        }

        public async Task<ActionResult<bool>> EditCustomerAsync(int? id, Customer customers)
        {
            try
            {
                var resultUpdate = false;

                var customer = await _domainServices.GetCustomerByIdAsync(id);

                if (customer != null)
                {
                    customer.Nombre = customers.Nombre;
                    customer.Apellidos = customers.Apellidos;
                    customer.Email = customers.Email;
                    customer.Identificacion = customers.Identificacion;
                    customer.Telefono = customers.Telefono;
                   
                    resultUpdate = await _domainServices.EditCustomerAsync(customer);
                }
                return resultUpdate;

            }
            catch (Exception)
            {

                throw;
            }




        }

        public async Task<ActionResult<bool>> DeleteCustomerAsync(int? id)
        {
            var resultDelete = false;

            var customer = await _domainServices.GetCustomerByIdAsync(id);

            if (customer != null)
            {
                resultDelete = await _domainServices.DeleteCustomerAsync(customer);
            }
            return resultDelete;


        }


        /************************Orders Methods******************************************/

        public async Task<List<Order>> GetOrdersAsync()
        {
            return await _domainServices.GetOrdersAsync();
        }

        public async Task<Order> GetOrdersByIdAsync(int? id)
        {
            return await _domainServices.GetOrdersByIdAsync(id);
        }

        public async Task<Order> InsertOrderAsync(RequestInsertOrderDTO requestInsertOrderDTO)
        {

            return await _domainServices.InsertOrderAsync(requestInsertOrderDTO);


        }


    }
}
