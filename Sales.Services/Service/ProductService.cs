using Microsoft.AspNetCore.Http;
using Sales.Core;
using Sale.Api.Models;
using Sales.DataAccess.Repository;
using Sales.Models.Model.ProductModels;
using Sales.Services.AutoMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sales.Services.Service
{
    public interface IProductService : IEntityService<Product>
    {

        bool UpdateProduct(ProductEditModels model, out string message);
        ProductEditModels CreateProduct(ProductEditModels model, out string message);
        bool Delete(int ProductId, out string message);
        List<ProductListModels> GetListProduct();


    }
    public class ProductService : EntityService<Product>, IProductService
    {
        private readonly IProductRepository _ProductRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ProductService(IUnitOfWork unitofwork, IProductRepository ProductRepository, IHttpContextAccessor httpContextAccessor)
            : base(unitofwork, ProductRepository)
        {
            _ProductRepository = ProductRepository;
            _httpContextAccessor = httpContextAccessor;

        }
        public bool UpdateProduct(ProductEditModels model, out string message)
        {
            var ProductEntity = _ProductRepository.GetById(model.ProductId);
            if (ProductEntity != null)
            {
                var gr = _ProductRepository.getProduct(model.ProductId, model.ProductName);
                if (gr != null)
                {
                    message = Constant.ProductIsExist;
                    return false;
                }
                ProductEntity = model.MapToEditEntity(ProductEntity);
                _ProductRepository.Update(ProductEntity);
                UnitOfwork.SaveChanges();
                message = Constant.UpdateSuccess;
                return true;
            }
            message = Constant.UpdateFail;
            return false;
        }
        public ProductEditModels CreateProduct(ProductEditModels model, out string message)
        {
            var ship = _ProductRepository.getProduct(model.ProductId, model.ProductName);
            if (ship != null)
            {
                message = Constant.ProductIsExist;
                return null;
            }
            var CreateProduct = _ProductRepository.Insert(model.MapToEditEntity());
            UnitOfwork.SaveChanges();
            if (CreateProduct == null)
            {
                message = Constant.CreateFail;
                return null;

            }
            message = Constant.CreateSuccess;
            return CreateProduct.MapToEditModel();
        }

        public bool Delete(int ProductId, out string message)
        {
            try
            {
                var entity = _ProductRepository.GetById(ProductId);
                if (entity != null)
                {
                    _ProductRepository.Delete(ProductId);
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
        public List<ProductListModels> GetListProduct()
        {
            return _ProductRepository.GetAll().ToList().MapToModels();

        }
    }
}