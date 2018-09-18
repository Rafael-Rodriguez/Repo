using Chapter24.CustomerMaintenance.Model;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace Chapter24.CustomerMaintenance.Database
{
    public class CustomerRepository : ICustomerRepository
    {
        public Customer GetCustomerById(int customerID)
        {
            var matchingCustomer = MMABooksEntity.Instance.DbContext.Customers.Where(customer => customer.CustomerID == customerID).SingleOrDefault();

            if (matchingCustomer != null)
            {
                if (!MMABooksEntity.Instance.DbContext.Entry(matchingCustomer).Reference("State").IsLoaded)
                {
                    MMABooksEntity.Instance.DbContext.Entry(matchingCustomer).Reference("State").Load();
                }
            }

            return matchingCustomer;
        }

        public bool AddCustomer(Customer customer)
        {
            MMABooksEntity.Instance.DbContext.Customers.Add(customer);

            try
            {
                MMABooksEntity.Instance.DbContext.SaveChanges();
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
                MMABooksEntity.Instance.DbContext.Entry(customer).State = EntityState.Modified;
                MMABooksEntity.Instance.DbContext.SaveChanges();
                return new SaveChangesResult() {Value = SaveChangesResult.Result.Ok};
            }
            catch (DbUpdateConcurrencyException ex)
            {
                ex.Entries.Single().Reload();
                if (MMABooksEntity.Instance.DbContext.Entry(customer).State == EntityState.Detached)
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
