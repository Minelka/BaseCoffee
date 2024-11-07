using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseCoffee.DAL.Entities.Enums;

namespace BaseCoffee.DAL.Entities.Abstract
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifedDate { get; set; } = DateTime.MinValue;

        public DateTime DeletedDate { get; set; } = DateTime.MinValue;

        public DataStatus Status { get; set; }
    }
}
