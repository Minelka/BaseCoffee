using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseCoffee.BLL.DTOs
{
    public record OrderDetailDTO (int Id, int OrderID, int ProductID,int Quantity,decimal UnitPrice);
}
