using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseCoffee.BLL.DTOs
{
    public record CartDTO(int Id, int ProductID, int Quantity);
    
}
