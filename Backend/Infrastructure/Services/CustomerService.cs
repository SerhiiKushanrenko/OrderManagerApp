using Core.Enteties;
using Core.Interfacies;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{

    public class CustomerService : ICustomerService
    {
         private readonly IDbContextFactory<OMAContext> _dbContext;

        public CustomerService(IDbContextFactory<OMAContext> dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Customer> GetCustomersAndOrders()
        {
            var context = _dbContext.CreateDbContext();
            context.Database.EnsureCreated();

            return context.Customers
            .Where( e => !e.IsDeleted)
            .Include( e => e.Address)
            .Include(e => e.Orders);
        }
    }
}