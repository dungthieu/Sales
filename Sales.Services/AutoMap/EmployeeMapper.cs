﻿using Sales.DataAccess.Entities;
using Sales.Models.Model.EmployeeModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Services.AutoMap
{
    public static class EmployeeMapper
    {
        public static EmployeeListModel MapToModel(this Employee entity)
        {
            return new EmployeeListModel
            {
                EmployeeId = entity.EmployeeId,
                LastName = entity.LastName,
                FirstName = entity.FirstName,
                Title = entity.Title,
                TitleOfCourtesy = entity.TitleOfCourtesy,
                BirthDate = entity.BirthDate,
                HireDate = entity.HireDate,
                Address = entity.Address,
                City = entity.City,
                Region = entity.Region,
                PostalCode = entity.PostalCode,
                Country = entity.Country,
                HomePhone = entity.HomePhone,
                Extension = entity.Extension,
                Photo = entity.Photo,
                Notes = entity.Notes,
                ReportsTo = entity.ReportsTo,
                PhotoPath = entity.PhotoPath
            };
        }
        public static EmployeeEditModel MapToEditModel(this Employee entity, EmployeeEditModel model)
        {

            model.EmployeeId = entity.EmployeeId;
            model.LastName = entity.LastName;
            model.FirstName = entity.FirstName;
            model.Title = entity.Title;
            model.TitleOfCourtesy = entity.TitleOfCourtesy;
            model.BirthDate = entity.BirthDate;
            model.HireDate = entity.HireDate;
            model.Address = entity.Address;
            model.City = entity.City;
            model.Region = entity.Region;
            model.PostalCode = entity.PostalCode;
            model.Country = entity.Country;
            model.HomePhone = entity.HomePhone;
            model.Extension = entity.Extension;
            model.Photo = entity.Photo;
            model.Notes = entity.Notes;
            model.ReportsTo = entity.ReportsTo;
            model.PhotoPath = entity.PhotoPath;
            return model;
        }
        public static Employee MapToEntity(this EmployeeEditModel model)
        {
            return new Employee
            {
                EmployeeId = model.EmployeeId,
                LastName = model.LastName,
                FirstName = model.FirstName,
                Title = model.Title,
                TitleOfCourtesy = model.TitleOfCourtesy,
                BirthDate = model.BirthDate,
                HireDate = model.HireDate,
                Address = model.Address,
                City = model.City,
                Region = model.Region,
                PostalCode = model.PostalCode,
                Country = model.Country,
                HomePhone = model.HomePhone,
                Extension = model.Extension,
                Photo = model.Photo,
                Notes = model.Notes,
                ReportsTo = model.ReportsTo,
                PhotoPath = model.PhotoPath
            };
        }
        public static Employee MapToEntity(this EmployeeEditModel model, Employee entity)
        {
            entity.EmployeeId = model.EmployeeId;
            entity.LastName = model.LastName;
            entity.FirstName = model.FirstName;
            entity.Title = model.Title;
            entity.TitleOfCourtesy = model.TitleOfCourtesy;
            entity.BirthDate = model.BirthDate;
            entity.HireDate = model.HireDate;
            entity.Address = model.Address;
            entity.City = model.City;
            entity.Region = model.Region;
            entity.PostalCode = model.PostalCode;
            entity.Country = model.Country;
            entity.HomePhone = model.HomePhone;
            entity.Extension = model.Extension;
            entity.Photo = model.Photo;
            entity.Notes = model.Notes;
            entity.ReportsTo = model.ReportsTo;
            entity.PhotoPath = model.PhotoPath;
            return entity;

        }

    }
}
