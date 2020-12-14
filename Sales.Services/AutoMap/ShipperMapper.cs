using Sales.DataAccess.Entities;
using Sales.Models.Model.ShipperModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Services.AutoMap
{
   public static class ShipperMapper
    {
        public static Shipper MapToEntity (this ShipperListModels model)
        {
            return new Shipper
            {
                ShipperId = model.ShipperId,
                CompanyName = model.CompanyName,
                Phone = model.Phone
            };
        }
        public static Shipper MapToEditEntity(this ShipperEditModels model)
        {
            return new Shipper
            {
                ShipperId = model.ShipperId,
                CompanyName = model.CompanyName,
                Phone = model.Phone
            };
        }
        public static ShipperListModels MapToModel(this Shipper entity)
        {
            return new ShipperListModels
            {
                ShipperId = entity.ShipperId,
                CompanyName = entity.CompanyName,
                Phone = entity.Phone
            };
        }
        public static ShipperEditModels MapToEditModel(this Shipper entity)
        {
            return new ShipperEditModels
            {
                ShipperId = entity.ShipperId,
                CompanyName = entity.CompanyName,
                Phone = entity.Phone
            };
        }
    }
}

 