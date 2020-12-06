using Sales.Models.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Models.Model.EmployeeModels
{
    public class EmployeeSearchModels: Pagging
    {
        public string TextSearch { get; set; }
        public string SortColumn { get; set; }
        public string SortDirection { get; set; }
        public List<EmployeeListModel> EmployeeModel { get; set; }
    }
}
