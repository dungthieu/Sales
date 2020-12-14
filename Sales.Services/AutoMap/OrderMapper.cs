using Sales.DataAccess.Entities;
using Sales.Models.Model.OrderModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Services.AutoMap
{
    public static class OrderMapper
    {
        public static Order MapToEntity(this OrderListModels model)
        {
            return new Order
            {
                OrderId = model.OrderId,
                CustomerId = model.CustomerId,
                EmployeeId = model.EmployeeId,
                OrderDate = model.OrderDate,
                RequiredDate = model.RequiredDate,
                ShippedDate = model.ShippedDate,
                ShipVia = model.ShipVia,
                Freight = model.Freight,
                ShipName = model.ShipName,
                ShipAddress = model.ShipAddress,
                ShipCity = model.ShipCity,
                ShipRegion = model.ShipRegion,
                ShipPostalCode = model.ShipPostalCode,
                ShipCountry = model.ShipCountry
            };
        }
        public static Order MapToEditEntity(this OrderEditModel model)
        {
            return new Order
            {
                OrderId = model.OrderId,
                CustomerId = model.CustomerId,
                EmployeeId = model.EmployeeId,
                OrderDate = model.OrderDate,
                RequiredDate = model.RequiredDate,
                ShippedDate = model.ShippedDate,
                ShipVia = model.ShipVia,
                Freight = model.Freight,
                ShipName = model.ShipName,
                ShipAddress = model.ShipAddress,
                ShipCity = model.ShipCity,
                ShipRegion = model.ShipRegion,
                ShipPostalCode = model.ShipPostalCode,
                ShipCountry = model.ShipCountry
            };
        }
        public static OrderListModels MapToModel(this Order entity)
        {
            return new OrderListModels
            {
                OrderId = entity.OrderId,
                CustomerId = entity.CustomerId,
                EmployeeId = entity.EmployeeId,
                OrderDate = entity.OrderDate,
                RequiredDate = entity.RequiredDate,
                ShippedDate = entity.ShippedDate,
                ShipVia = entity.ShipVia,
                Freight = entity.Freight,
                ShipName = entity.ShipName,
                ShipAddress = entity.ShipAddress,
                ShipCity = entity.ShipCity,
                ShipRegion = entity.ShipRegion,
                ShipPostalCode = entity.ShipPostalCode,
                ShipCountry = entity.ShipCountry
            };
        }
        public static OrderEditModel MapToEditModel(this Order entity)
        {
            return new OrderEditModel
            {
                OrderId = entity.OrderId,
                CustomerId = entity.CustomerId,
                EmployeeId = entity.EmployeeId,
                OrderDate = entity.OrderDate,
                RequiredDate = entity.RequiredDate,
                ShippedDate = entity.ShippedDate,
                ShipVia = entity.ShipVia,
                Freight = entity.Freight,
                ShipName = entity.ShipName,
                ShipAddress = entity.ShipAddress,
                ShipCity = entity.ShipCity,
                ShipRegion = entity.ShipRegion,
                ShipPostalCode = entity.ShipPostalCode,
                ShipCountry = entity.ShipCountry
            };
        }
    }
}
