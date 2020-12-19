using System;
using System.Collections.Generic;

#nullable disable

namespace Sales.DataAccess.Entities
{
    public partial class Product
    {
        public Product()
        {
            Carts = new HashSet<Cart>();
            Employees = new HashSet<Employee>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int? SupplierId { get; set; }
        public int? CategoryId { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }
        public short? UnitsOnOrder { get; set; }
        public short? ReorderLevel { get; set; }
        public bool Discontinued { get; set; }

        public virtual Category Category { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
