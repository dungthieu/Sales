using Sales.DataAccess.Entities;
using Sales.Models.Model.OrderDetailModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Services.AutoMap
{
    public static class OrderDetailMapper
    {
        public static OrderDetail MapToEntity ( this OrderDetailListModel model)
        {
            return new OrderDetail {
                OrderId = model.OrderId,
                ProductId = model.ProductId,
                UnitPrice = model.UnitPrice,
                Quantity = model.Quantity,
                Discount = model.Discount           
            };

        }
        public static OrderDetail MapToEditEntity(this OrderDetailEditModel model)
        {
            return new OrderDetail
            {
                OrderId = model.OrderId,
                ProductId = model.ProductId,
                UnitPrice = model.UnitPrice,
                Quantity = model.Quantity,
                Discount = model.Discount
            };

        }
        public static OrderDetailListModel MapToModel(this OrderDetail Entity)
        {
            return new OrderDetailListModel
            {
                OrderId = Entity.OrderId,
                ProductId = Entity.ProductId,
                UnitPrice = Entity.UnitPrice,
                Quantity = Entity.Quantity,
                Discount = Entity.Discount
            };

        }
        public static OrderDetailEditModel MapToEditModel(this OrderDetail Entity)
        {
            return new OrderDetailEditModel
            {
                OrderId = Entity.OrderId,
                ProductId = Entity.ProductId,
                UnitPrice = Entity.UnitPrice,
                Quantity = Entity.Quantity,
                Discount = Entity.Discount
            };

        }
    }
}
