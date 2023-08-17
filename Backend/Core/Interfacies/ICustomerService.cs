using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Enteties;

namespace Core.Interfacies
{
    public interface ICustomerService
    {
        IQueryable<Customer> GetCustomersAndOrders();
    }
}