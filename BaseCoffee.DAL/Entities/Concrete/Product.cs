using BaseCoffee.DAL.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseCoffee.DAL.Entities.Concrete
{
    public class Product : BaseEntity
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public int StockQuantity { get; set; }

        public Category Category { get; set; }
        
        public ICollection<OrderDetail> OrderDetails { get; set; }

    }
}
