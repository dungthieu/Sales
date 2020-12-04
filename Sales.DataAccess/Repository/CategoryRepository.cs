using Microsoft.EntityFrameworkCore;
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
        List<Category> GetListCategory(); 
    }
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(SalesContext context) : base(context)
        {
        }
        public List<Category> GetListCategory()
        {
           

            var query = Dbset.AsQueryable();               
            return query.ToList();
        }
    }

}
