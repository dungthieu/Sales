using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Models.Model.OrderDetailModels
{
    public class OrderDetailListModels
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public decimal Discount { get; set; }

    }
}
