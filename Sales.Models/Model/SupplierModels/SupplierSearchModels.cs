using Sales.Models.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Models.Model.SupplierModels
{
   public  class SupplierSearchModels : Pagging
    {
        public string TextSearch { get; set; }
        public string SortColumn { get; set; }
        public string SortDirection { get; set; }
        public  List<SupplierListModels> SupplierModels { get; set; }
    }
}
