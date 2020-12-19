using Microsoft.AspNetCore.Http;
using Sales.Core;
using Sales.DataAccess.Entities;
using Sales.DataAccess.Repository;
using Sales.Models.Model.OrderModels;
using Sales.Services.AutoMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sales.Services.Service
{
    public interface IOrderService : IEntityService<Order>
    {

        bool UpdateOrder(OrderEditModels model, out string message);
        OrderEditModels CreateOrder(OrderEditModels model, out string message);
        bool Delete(int OrderId, out string message);
        List<OrderListModels> GetListOrder();


    }
    public class OrderService : EntityService<Order>, IOrderService
    {
        private readonly IOrderRepository _OrderRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public OrderService(IUnitOfWork unitofwork, IOrderRepository OrderRepository, IHttpContextAccessor httpContextAccessor)
            : base(unitofwork, OrderRepository)
        {
            _OrderRepository = OrderRepository;
            _httpContextAccessor = httpContextAccessor;

        }
        public bool UpdateOrder(OrderEditModels model, out string message)
        {
            var OrderEntity = _OrderRepository.GetById(model.OrderId);
            if (OrderEntity != null)
            {
                var gr = _OrderRepository.getOrder(model.OrderId, model.CustomerId, model.EmployeeId);
                if (gr != null)
                {
                    message = Constant.OrderIsExist;
                    return false;
                }
                OrderEntity = model.MapToEditEntity(OrderEntity);
                _OrderRepository.Update(OrderEntity);
                UnitOfwork.SaveChanges();
                message = Constant.UpdateSuccess;
                return true;
            }
            message = Constant.UpdateFail;
            return false;
        }
        public OrderEditModels CreateOrder(OrderEditModels model, out string message)
        {
            var ship = _OrderRepository.getOrder(model.OrderId, model.CustomerId, model.EmployeeId);
            if (ship != null)
            {
                message = Constant.OrderIsExist;
                return null;
            }
            var CreateOrder = _OrderRepository.Insert(model.MapToEditEntity());
            UnitOfwork.SaveChanges();
            if (CreateOrder == null)
            {
                message = Constant.CreateFail;
                return null;

            }
            message = Constant.CreateSuccess;
            return CreateOrder.MapToEditModel();
        }

        public bool Delete(int OrderId, out string message)
        {
            try
            {
                var entity = _OrderRepository.GetById(OrderId);
                if (entity != null)
                {
                    _OrderRepository.Delete(OrderId);
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
        public List<OrderListModels> GetListOrder()
        {
            return _OrderRepository.GetAll().ToList().MapToModels();

        }
    }
}