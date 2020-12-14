using Sales.DataAccess.Entities;
using Sales.Models.Model.ProductModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Services.AutoMap
{
    public static class ProductMapper
    {
        public static Product MapToEntity(this ProductListModels model)
        {
            return new Product
            {
                ProductId = model.ProductId,
                ProductName = model.ProductName,
                SupplierId = model.SupplierId,
                CategoryId = model.CategoryId,
                QuantityPerUnit = model.QuantityPerUnit,
                UnitPrice = model.UnitPrice,
                UnitsInStock = model.UnitsInStock,
                UnitsOnOrder = model.UnitsOnOrder,
                ReorderLevel = model.ReorderLevel,
                Discontinued = model.Discontinued
            };
        }
        public static Product MapToEditEntity(this ProductEditModels model)
        {
            return new Product
            {
                ProductId = model.ProductId,
                ProductName = model.ProductName,
                SupplierId = model.SupplierId,
                CategoryId = model.CategoryId,
                QuantityPerUnit = model.QuantityPerUnit,
                UnitPrice = model.UnitPrice,
                UnitsInStock = model.UnitsInStock,
                UnitsOnOrder = model.UnitsOnOrder,
                ReorderLevel = model.ReorderLevel,
                Discontinued = model.Discontinued
            };
        }
        public static ProductListModels MapToModel(this Product entity)
        {
            return new ProductListModels
            {
                ProductId = entity.ProductId,
                ProductName = entity.ProductName,
                SupplierId = entity.SupplierId,
                CategoryId = entity.CategoryId,
                QuantityPerUnit = entity.QuantityPerUnit,
                UnitPrice = entity.UnitPrice,
                UnitsInStock = entity.UnitsInStock,
                UnitsOnOrder = entity.UnitsOnOrder,
                ReorderLevel = entity.ReorderLevel,
                Discontinued = entity.Discontinued
            };
        }
        public static ProductEditModels MapToEditModel(this Product entity)
        {
            return new ProductEditModels
            {
                ProductId = entity.ProductId,
                ProductName = entity.ProductName,
                SupplierId = entity.SupplierId,
                CategoryId = entity.CategoryId,
                QuantityPerUnit = entity.QuantityPerUnit,
                UnitPrice = entity.UnitPrice,
                UnitsInStock = entity.UnitsInStock,
                UnitsOnOrder = entity.UnitsOnOrder,
                ReorderLevel = entity.ReorderLevel,
                Discontinued = entity.Discontinued
            };
        }
    }
}
