using Sales.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sales.Models.Model.CartModels
{
    public class CartEditModels
    {
        public int ProductId { get; set; }
        public int? Quantity { get; set; }
        public decimal? UnitPrice { get; set; }
        public string ProductName { get; set; }
        public string CookieName { get; set; }
        public string CustomerId { get; set; }
        
       
    }
}
