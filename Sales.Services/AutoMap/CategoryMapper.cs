using Sales.DataAccess.Entities;
using System;
using Sales.Models.Model.CategoryModels;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Sales.Services.AutoMap
{
    public static class CategoryMapper
    {
        #region Mapping CategoryMapper
        public static CategoryListModels MapToModel(this Category entity)
        {
            return new CategoryListModels
            {
                CategoryId = entity.CategoryId,
                CategoryName = entity.CategoryName,
                Description = entity.Description
            };

        }
        public static CategoryEditModels MapToEditModel(this Category entity)
        {
            return new CategoryEditModels
            {
                CategoryId = entity.CategoryId,
                CategoryName = entity.CategoryName,
                Description = entity.Description
            };

        }
        public static CategoryEditModels MapToEntityModel(this Category entity, CategoryEditModels model)
        {

            model.CategoryId = entity.CategoryId;
            model.CategoryName = entity.CategoryName;
            model.Description = entity.Description;
            return model;
        }
        public static Category MapToEntity(this CategoryListModels model)
        {
            return new Category
            {
                CategoryId = model.CategoryId,
                CategoryName = model.CategoryName,
                Description = model.Description
            };
        }
        public static Category MapToEditEntity(this CategoryEditModels model)
        {
            return new Category
            {
                CategoryId = model.CategoryId,
                CategoryName = model.CategoryName,
                Description = model.Description
            };
        }
        public static Category MapToEntity(this CategoryEditModels model, Category entity)
        {

            entity.CategoryId = model.CategoryId;
            entity.CategoryName = model.CategoryName;
            entity.Description = model.Description;
            return entity;
        }
        public static List<CategoryListModels> MapToEnities(this List<Category> entities)
        {
            return entities.Select(x => x.MapToModel()).ToList();
        }
        public static List<Category> MapToModels(this List<CategoryEditModels> models)
        {
            return models.Select(x => x.MapToEditEntity()).ToList();
        }
        #endregion
    }
}
