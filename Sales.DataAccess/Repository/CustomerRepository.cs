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
        List<Customer> Search(int currentPage, int pageSize, string textSearch, string sortColumn, string sortDirection, out int totalPage);
    }
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(SalesContext context) : base(context)
        {
        }
        public List<Customer> Search(int currentPage, int pageSize, string textSearch, string sortColumn, string sortDirection,
        out int totalPage)
        {
            currentPage = (currentPage <= 0) ? 1 : currentPage;
            pageSize = (pageSize <= 0) ? 20 : pageSize;

            var query = Dbset.AsQueryable();
            totalPage = query.Count();
            if (!string.IsNullOrEmpty(sortColumn))
            {
                query = query.OrderByField(sortColumn.Trim(), sortDirection);
            }
            else
                query = query.OrderByDescending(c => c.CustomerId);

            return query.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
        }
    }

}
