using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using TestTuya.DomainServices.Contracts;
using TestTuya.DTOs.RequestDTOs;
using TestTuya.DTOs.Response;
using TestTuya.Models;

namespace TestTuya.DomainServices
{
    public class DomainServices:IDomainServices
    {
        private readonly TestTuyaIContext _context;

        public DomainServices(TestTuyaIContext context)
        {
            _context = context;
        }

        /**************************Orders********************************/
        public async Task<List<Order>> GetOrdersAsync()
        {
            return await  _context.Orders.ToListAsync();
        }

        public async Task<Order> GetOrdersByIdAsync(int? id)
        {
            return await _context.Orders.FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<Order> InsertOrderAsync(RequestInsertOrderDTO requestInsertOrderDTO)
        {
            if (requestInsertOrderDTO == null) { }

            var orden = new Order()
            {
                CustomerId = requestInsertOrderDTO.customerId,
                ValorOrden = requestInsertOrderDTO.ValorOrden,
                FechaOrden = requestInsertOrderDTO.FechaOrden,
            };

            var details = new List<OrderDetail>();


            foreach (var item in requestInsertOrderDTO.DetalleOrden)
            {
                var detail = new OrderDetail();

                detail.IdProducto = item.idProducto;
                detail.DescripcionProducto = item.descripcion;
                detail.Cantidad = item.Cantidad;
                detail.Total = item.ValorTotal;
                detail.ValorUnitario = item.ValorUnitario;

                details.Add(detail);
            }


            _context.Orders.Add(orden);

            var resultInsertOrden = await _context.SaveChangesAsync();

            if (resultInsertOrden > 0)
            {

                foreach (var item in details)
                {
                    item.OrderId = orden.Id;
                }

                _context.OrderDetails.AddRange(details);
                var resultInsertDetail = await _context.SaveChangesAsync();

            }

            return orden;
        }

        /**************************Customers********************************/

        public async Task<List<Customer>> GetCustomersAsync()
        {
            return await _context.Customers.ToListAsync();

        }
        public async Task<Customer> GetCustomerByIdAsync(int? id)
        {
            return await _context.Customers.FirstOrDefaultAsync(c => c.Id.Equals(id));
        }

        public async Task<ActionResult<Customer>> CreateCustomerAsync(RequestInsertCustomerDTO customer)
        {
            var newCustomer = new Customer()
            {
                Nombre = customer.Nombre,
                Apellidos = customer.Apellidos,
                Identificacion = customer.Identificacion,                
                Email = customer.Email,
                Telefono = customer.Telefono,
            };

            _context.Customers.Add(newCustomer);

            var resul = await _context.SaveChangesAsync();

            return newCustomer;

        }

        public async Task<bool> EditCustomerAsync(Customer customer)
        {
            var resultUpdate = false;

            _context.Customers.Update(customer);
            var result = await _context.SaveChangesAsync();

            if (result > 0) resultUpdate = true;

            return resultUpdate;

        }

        public async Task<bool> DeleteCustomerAsync(Customer customer)
        {
            var resultDelete = false;

            _context.Customers.Remove(customer);
            var result = await _context.SaveChangesAsync();

            if (result > 0) resultDelete = true;

            return resultDelete;
        }
    }
}
