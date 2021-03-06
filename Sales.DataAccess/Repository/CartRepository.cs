﻿using Microsoft.EntityFrameworkCore;
using Sale.Api.Models;
using Sales.DataAccess.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sales.DataAccess.Repository
{
    public interface ICartRepository : IBaseRepository<Cart>
    {
        List<Cart> Carts(string customerId);
        List<Cart> GetAllProduct();
    }
    public class CartRepository : BaseRepository<Cart>, ICartRepository
    {
        public CartRepository(SalesContext context) : base(context)
        {
        }
        public List<Cart> Carts(string customerId)
        {
            var query = Dbset.AsQueryable();
            query = query.Include(x => x.Customer).Where(x => x.CustomerId == customerId);
            return query.ToList();
        }
        public List<Cart> GetAllProduct()
        {
            var query = Dbset.AsQueryable();
           
            return query.ToList();
        }
    }

}
