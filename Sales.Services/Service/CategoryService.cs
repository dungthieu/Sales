using Microsoft.AspNetCore.Http;
using Sales.Core;
using Sales.DataAccess.Entities;
using Sales.DataAccess.Repository;
using Sales.Models.Model.CategoryModels;
using Sales.Services.AutoMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sales.Services.Service
{
    public interface ICategoryService : IEntityService<Category>
    {

        bool UpdateCategory(CategoryEditModels model, out string message);
        CategoryEditModels CreateCategory(CategoryEditModels model, out string message);
        bool Delete(int CategoryId, out string message);
        List<CategoryListModels> GetListCategory();


    }
    public class CategoryService : EntityService<Category>, ICategoryService
    {
        private readonly ICategoryRepository _CategoryRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CategoryService(IUnitOfWork unitofwork, ICategoryRepository CategoryRepository, IHttpContextAccessor httpContextAccessor)
            : base(unitofwork, CategoryRepository)
        {
            _CategoryRepository = CategoryRepository;
            _httpContextAccessor = httpContextAccessor;

        }
        public bool UpdateCategory(CategoryEditModels model, out string message)
        {
            var CategoryEntity = _CategoryRepository.GetById(model.CategoryId);
            if (CategoryEntity != null)
            {
                var gr = _CategoryRepository.getCategory(model.CategoryId, model.CategoryName);
                if (gr != null)
                {
                    message = Constant.CategoryIsExist;
                    return false;
                }
                CategoryEntity = model.MapToEditEntity(CategoryEntity);
                _CategoryRepository.Update(CategoryEntity);
                UnitOfwork.SaveChanges();
                message = Constant.UpdateSuccess;
                return true;
            }
            message = Constant.UpdateFail;
            return false;
        }
        public CategoryEditModels CreateCategory(CategoryEditModels model, out string message)
        {
            var ship = _CategoryRepository.getCategory(model.CategoryId, model.CategoryName);
            if (ship != null)
            {
                message = Constant.CategoryIsExist;
                return null;
            }
            var CreateCategory = _CategoryRepository.Insert(model.MapToEditEntity());
            UnitOfwork.SaveChanges();
            if (CreateCategory == null)
            {
                message = Constant.CreateFail;
                return null;

            }
            message = Constant.CreateSuccess;
            return CreateCategory.MapToEditModel();
        }

        public bool Delete(int CategoryId, out string message)
        {
            try
            {
                var entity = _CategoryRepository.GetById(CategoryId);
                if (entity != null)
                {
                    _CategoryRepository.Delete(CategoryId);
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
        public List<CategoryListModels> GetListCategory()
        {
            return _CategoryRepository.GetAll().ToList().MapToModels();

        }
    }
}