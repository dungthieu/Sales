using Sales.Models.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Models.Model.OrderModels
{
    public class OrderSearchModels:Pagging
    {
        public string TextSearch { get; set; }
        public string SortColunm { get; set; }
        public string SortDirection { get; set; }
        public List<OrderListMOdels> OrderModels { get; set; }
    }
}
