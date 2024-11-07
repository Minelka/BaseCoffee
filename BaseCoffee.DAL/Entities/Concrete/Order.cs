using BaseCoffee.DAL.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseCoffee.DAL.Entities.Concrete
{
    public class Order : BaseEntity
    {
        public DateTime OrderDate { get; set; }= DateTime.Now;

        public decimal TotalAmount { get; set; }

        public string Status { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
