using Sales.DataAccess.Entities;
using Sales.DataAccess.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sales.DataAccess.Repository
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        List<Category> Search(int currentPage, int pageSize, string textSearch, string sortColumn, string sortDirection, out int totalPage);
    }
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(SalesContext context) : base(context)
        {
        }
        public List<Category> Search(int currentPage, int pageSize, string textSearch, string sortColumn, string sortDirection,
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
                query = query.OrderByDescending(c => c.CategoryId);

            return query.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
        }
    }

}
