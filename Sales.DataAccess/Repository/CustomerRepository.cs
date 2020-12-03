using Microsoft.EntityFrameworkCore;
using Sales.DataAccess.Entities;
using Sales.DataAccess.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sales.DataAccess.Repository
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
        Customer SignIn(string User, string Pass);
       
    }
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(SalesContext context) : base(context)
        {
        }
        public Customer SignIn(string User, string Pass)
        {
            var query = Dbset.AsQueryable();
            query = query.Where(x => x.User == User && x.Password == Pass);
            return query.FirstOrDefault();
        }
    }

}
