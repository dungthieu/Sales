using Microsoft.AspNetCore.Http;
using Sales.Core;
using Sale.Api.Models;
using Sales.DataAccess.Repository;
using Sales.Models.Model.CustomerModels;
using Sales.Services.AutoMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sales.Services.Service
{
    public interface ICustomerService : IEntityService<Customer>
    {

        bool UpdateCustomer(CustomerListModels model, out string message);
        CustomerListModels CreateCustomer(CustomerListModels model, out string message);
        bool Delete(int CustomerId, out string message);
        List<CustomerListModels> GetListCustomer();


    }
    public class CustomerService : EntityService<Customer>, ICustomerService
    {
        private readonly ICustomerRepository _CustomerRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CustomerService(IUnitOfWork unitofwork, ICustomerRepository CustomerRepository, IHttpContextAccessor httpContextAccessor)
            : base(unitofwork, CustomerRepository)
        {
            _CustomerRepository = CustomerRepository;
            _httpContextAccessor = httpContextAccessor;

        }
        public bool UpdateCustomer(CustomerListModels model, out string message)
        {
            var CustomerEntity = _CustomerRepository.GetById(model.CustomerId);
            if (CustomerEntity != null)
            {
                var gr = _CustomerRepository.getCustomer(model.CustomerId, model.ContactName, model.CompanyName);
                if (gr != null)
                {
                    message = Constant.CustomerIsExist;
                    return false;
                }
                CustomerEntity = model.MapToEntity(CustomerEntity);
                _CustomerRepository.Update(CustomerEntity);
                UnitOfwork.SaveChanges();
                message = Constant.UpdateSuccess;
                return true;
            }
            message = Constant.UpdateFail;
            return false;
        }
        public CustomerListModels CreateCustomer(CustomerListModels model, out string message)
        {
            var ship = _CustomerRepository.getCustomer(model.CustomerId, model.ContactName, model.CompanyName);
            if (ship != null)
            {
                message = Constant.CustomerIsExist;
                return null;
            }
            var CreateCustomer = _CustomerRepository.Insert(model.MapToEntity());
            UnitOfwork.SaveChanges();
            if (CreateCustomer == null)
            {
                message = Constant.CreateFail;
                return null;

            }
            message = Constant.CreateSuccess;
            return CreateCustomer.MapToModel();
        }

        public bool Delete(int CustomerId, out string message)
        {
            try
            {
                var entity = _CustomerRepository.GetById(CustomerId);
                if (entity != null)
                {
                    _CustomerRepository.Delete(CustomerId);
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
        public List<CustomerListModels> GetListCustomer()
        {
            return _CustomerRepository.GetAll().ToList().MapToModels();

        }
    }
}