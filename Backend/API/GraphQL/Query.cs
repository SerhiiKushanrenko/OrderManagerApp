using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Enteties;
using Infrastructure.Data;

namespace API.GraphQL
{
    public class Query
    {
        [UseFiltering]
        public IQueryable<Customer> GetCustomers([Service] OMAContext context)
        {
            context.Database.EnsureCreated();
            return context.Customers;
        }

        [UseFiltering]
        public IQueryable<Order> GetOrders([Service] OMAContext context)
        {
            context.Database.EnsureCreated();
            return context.Orders;
        }
    }
}