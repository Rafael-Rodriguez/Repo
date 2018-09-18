using Chapter24.CustomerMaintenance.Model;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace Chapter24.CustomerMaintenance.Database
{
    public class CustomerRepository : ICustomerRepository
    {
        private MMABooksEntities _dbContext;
        private object _syncLock = new object();

        private MMABooksEntities DbContext
        {
            get
            {
                if (_dbContext == null)
                {
                    lock (_syncLock)
                    {
                        _dbContext = new MMABooksEntities();
                    }
                }

                return _dbContext;
            }
        }

        public Customer GetCustomerById(int customerID)
        {
            var matchingCustomer = DbContext.Customers.Where(customer => customer.CustomerID == customerID).SingleOrDefault();

            if (matchingCustomer != null)
            {
                if (!DbContext.Entry(matchingCustomer).Reference("State").IsLoaded)
                {
                    DbContext.Entry(matchingCustomer).Reference("State").Load();
                }
            }

            return matchingCustomer;
        }

        public bool AddCustomer(Customer customer)
        {
            DbContext.Customers.Add(customer);

            try
            {
                DbContext.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public SaveChangesResult SaveChanges(Customer customer)
        {
            try
            {
                DbContext.SaveChanges();
                return new SaveChangesResult() {Value = SaveChangesResult.Result.Ok};
            }
            catch (DbUpdateConcurrencyException ex)
            {
                ex.Entries.Single().Reload();
                if (DbContext.Entry(customer).State == EntityState.Detached)
                {
                    return new SaveChangesResult() { Value = SaveChangesResult.Result.Abort };
                }
                else
                {
                    return new SaveChangesResult() {Value = SaveChangesResult.Result.Retry };
                }
            }
            
        }
    }
}
