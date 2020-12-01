using Sales.DataAccess.Entities;
using Sales.DataAccess.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sales.DataAccess.Repository
{
    public interface ICartRepository : IBaseRepository<Cart>
    {
        List<Cart> Search(int currentPage, int pageSize, string textSearch, string sortColumn, string sortDirection, out int totalPage);
    }
    public class CartRepository : BaseRepository<Cart>, ICartRepository
    {
        public CartRepository(SalesContext context) : base(context)
        {
        }
        public List<Cart> Search(int currentPage, int pageSize, string textSearch, string sortColumn, string sortDirection,
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
                query = query.OrderByDescending(c => c.CookieName);

            return query.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
        }
    }

}
