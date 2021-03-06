﻿using Microsoft.AspNetCore.Http;
using Sales.Core;
using Sale.Api.Models;
using Sales.DataAccess.Repository;
using Sales.Models.Model.EmployeeModels;
using Sales.Services.AutoMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sales.Services.Service
{
    public interface IEmployeeService : IEntityService<Employee>
    {

        bool UpdateEmployee(EmployeeEditModels model, out string message);
        EmployeeEditModels CreateEmployee(EmployeeEditModels model, out string message);
        bool Delete(int EmployeeId, out string message);
        List<EmployeeListModels> GetListEmployee();


    }
    public class EmployeeService : EntityService<Employee>, IEmployeeService
    {
        private readonly IEmployeeRepository _EmployeeRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public EmployeeService(IUnitOfWork unitofwork, IEmployeeRepository EmployeeRepository, IHttpContextAccessor httpContextAccessor)
            : base(unitofwork, EmployeeRepository)
        {
            _EmployeeRepository = EmployeeRepository;
            _httpContextAccessor = httpContextAccessor;

        }
        public bool UpdateEmployee(EmployeeEditModels model, out string message)
        {
            var EmployeeEntity = _EmployeeRepository.GetById(model.EmployeeId);
            if (EmployeeEntity != null)
            {
                var gr = _EmployeeRepository.getEmployee(model.EmployeeId, model.FirstName, model.LastName);
                if (gr != null)
                {
                    message = Constant.EmployeeIsExist;
                    return false;
                }
                EmployeeEntity = model.MapToEditEntity(EmployeeEntity);
                _EmployeeRepository.Update(EmployeeEntity);
                UnitOfwork.SaveChanges();
                message = Constant.UpdateSuccess;
                return true;
            }
            message = Constant.UpdateFail;
            return false;
        }
        public EmployeeEditModels CreateEmployee(EmployeeEditModels model, out string message)
        {
            var ship = _EmployeeRepository.getEmployee(model.EmployeeId, model.FirstName, model.LastName);
            if (ship != null)
            {
                message = Constant.EmployeeIsExist;
                return null;
            }
            var CreateEmployee = _EmployeeRepository.Insert(model.MapToEditEntity());
            UnitOfwork.SaveChanges();
            if (CreateEmployee == null)
            {
                message = Constant.CreateFail;
                return null;

            }
            message = Constant.CreateSuccess;
            return CreateEmployee.MapToEditModel();
        }

        public bool Delete(int EmployeeId, out string message)
        {
            try
            {
                var entity = _EmployeeRepository.GetById(EmployeeId);
                if (entity != null)
                {
                    _EmployeeRepository.Delete(EmployeeId);
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
        public List<EmployeeListModels> GetListEmployee()
        {
            return _EmployeeRepository.GetAll().ToList().MapToModels();

        }
    }
}