using Sales.DataAccess.Entities;
using Sales.Models.Model.ShipperModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Services.Service
{
    public interface IShipperService : IEntityService<Shipper> 
    {
        List<ShipperListModels> GetAll();
        bool UpdateShipper(ShipperEditModels, out string message);
        ShipperEditModels CreateShipper(ShipperEditModels model, out string message);

    }

   public  class ShipperService
    {
    }
}
