using BaseCoffee.DAL.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseCoffee.DAL.Entities.Concrete
{
    public class Cart: BaseEntity
    {
        public int ProductID { get; set; }

        public int Quantity { get; set; }

        public Product Product { get; set; }
    }
}
