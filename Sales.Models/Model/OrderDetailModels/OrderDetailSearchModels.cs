using Sales.Models.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Models.Model.OrderDetailModels
{
   public  class OrderDetailSearchModels:Pagging
    {
        public string TextSearch { get; set; }
        public string SortColunm { get; set; }
        public string SortDirection { get; set; }
        public List<OrderDetailListModels> OrderDetail { get; set; }
    }
}
