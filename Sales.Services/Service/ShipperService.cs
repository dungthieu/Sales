using Microsoft.AspNetCore.Http;
using Sales.Core;
using Sale.Api.Models;
using Sales.DataAccess.Repository;
using Sales.Models.Model.ShipperModels;
using Sales.Services.AutoMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sales.Services.Service
{
    public interface IShipperService : IEntityService<Shipper>
    {

        bool UpdateShipper(ShipperEditModels model, out string message);
        ShipperEditModels CreateShipper(ShipperEditModels model, out string message);
        bool Delete(int shipperId, out string message);
        List<ShipperListModels> GetListShipper();


    }
    public class ShipperService : EntityService<Shipper>, IShipperService
    {
        private readonly IShipperRepository _ShipperRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ShipperService(IUnitOfWork unitofwork, IShipperRepository ShipperRepository, IHttpContextAccessor httpContextAccessor)
            : base(unitofwork, ShipperRepository)
        {
            _ShipperRepository = ShipperRepository;
            _httpContextAccessor = httpContextAccessor;

        }
        public bool UpdateShipper(ShipperEditModels model, out string message)
        {
            var shipperEntity = _ShipperRepository.GetById(model.ShipperId);
            if (shipperEntity != null)
            {
                var gr = _ShipperRepository.getshipper(model.ShipperId, model.CompanyName, model.Phone);
                if (gr != null)
                {
                    message = Constant.ShipperIsExist;
                    return false;
                }
                shipperEntity = model.MapToEditEntity(shipperEntity);
                _ShipperRepository.Update(shipperEntity);
                UnitOfwork.SaveChanges();
                message = Constant.UpdateSuccess;
                return true;
            }
            message = Constant.UpdateFail;
            return false;
        }
        public ShipperEditModels CreateShipper(ShipperEditModels model, out string message)
        {
            var ship = _ShipperRepository.getshipper(model.ShipperId, model.CompanyName, model.Phone);
            if (ship != null)
            {
                message = Constant.ShipperIsExist;
                return null;
            }
            var CreateShipper = _ShipperRepository.Insert(model.MapToEditEntity());
            UnitOfwork.SaveChanges();
            if (CreateShipper == null)
            {
                message = Constant.CreateFail;
                return null;

            }
            message = Constant.CreateSuccess;
            return CreateShipper.MapToEditModel();
        }

        public bool Delete(int shipperId, out string message)
        {
            try
            {
                var entity = _ShipperRepository.GetById(shipperId);
                if (entity != null)
                {
                    _ShipperRepository.Delete(shipperId);
                    UnitOfwork.SaveChanges();
                    message = Constant.DeleteSuccess;
                    return true;
                }

                message = Constant.DeleteFail;
                return false;
            }
            catch
            {
                message = Constant.RecordsisUsedCanNotDeleted;
                return false;
            }
        }
       public  List<ShipperListModels> GetListShipper()
        {          
               return _ShipperRepository.GetAll().ToList().MapToModels();
        
        }
    }
}