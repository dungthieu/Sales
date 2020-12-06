using Sales.Models.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Models.Model.CustomerModels
{
    public class CustomerSearchModels:Pagging
    {
        public string TextSearch { get; set; }
        public string SortColumn { get; set; }
        public string SortDirection { get; set; }
        public List<CustomerListModels> CustomerModels { get; set; }
    }
}
