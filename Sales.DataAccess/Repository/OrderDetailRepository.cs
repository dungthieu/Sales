﻿using Sales.DataAccess.Entities;
using Sales.DataAccess.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sales.DataAccess.Repository
{ 
    public interface IOrderDetailRepository : IBaseRepository<OrderDetail>
    {
        List<OrderDetail> Search(int currentPage, int pageSize, string textSearch, string sortColumn, string sortDirection, out int totalPage);
    }
    public class OrderDetailRepository : BaseRepository<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(SalesContext context) : base(context)
        {
        }
        public List<OrderDetail> Search(int currentPage, int pageSize, string textSearch, string sortColumn, string sortDirection,
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
                query = query.OrderByDescending(c => c.OrderId);

            return query.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
        }
    }

}