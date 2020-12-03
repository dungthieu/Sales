using Sales.DataAccess.Entities;
using Sales.DataAccess.Extensions;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;

namespace Sales.DataAccess.Repository
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        List<Product> Search(int currentPage, int pageSize, string textSearch, string sortColumn, string sortDirection, out int totalPage);
        List<Product> GetByCategory(int? categoryId);
        Product GetDetail(int productId);
    }
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(SalesContext context) : base(context)
        {
        }
        public List<Product> Search(int currentPage, int pageSize, string textSearch, string sortColumn, string sortDirection,
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
                query = query.OrderByDescending(c => c.ProductId);

            return query.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
        }
        public List<Product> GetByCategory(int? categoryId)
        {
            var query = Dbset.AsQueryable();
            query = query.Include(x=>x.Category).Where(x => x.CategoryId ==categoryId);
            return query.ToList();
        }
        public Product GetDetail(int productId)
        {
            var query = Dbset.AsQueryable();
            query = query.Include(x => x.Supplier).Where(x => x.ProductId==productId);
            return query.FirstOrDefault();
        }
    }

}
