using Sales.Models.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Models.Model.ProductModels
{
    public class ProductSearchModel:Pagging
    {
        public string TextSearch { get; set; }
        public string SortColumn { get; set; }  
        public string SortDirection { get; set; }
        public List<ProductListModels> ProductListModels { get; set; }
    }
}
