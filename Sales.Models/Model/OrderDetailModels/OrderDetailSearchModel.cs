using Sales.Models.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Models.Model.OrderDetailModels
{
   public  class OrderDetailSearchModel:Pagging
    {
        public string TextSearch { get; set; }
        public string SortColunm { get; set; }
        public string SortDirection { get; set; }
        public List<OrderDetailListModel> OrderDetail { get; set; }
    }
}
