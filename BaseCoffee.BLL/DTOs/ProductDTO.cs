using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseCoffee.BLL.DTOs
{
    public record ProductDTO(int Id, int CategoryID, string Name, decimal Price, string Description,int StockQuantity);
}
