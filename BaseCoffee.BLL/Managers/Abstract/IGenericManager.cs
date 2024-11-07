using BaseCoffee.DAL.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BaseCoffee.BLL.Managers.Abstract
{
    public interface IGenericManager<TDTO, T> where T : BaseEntity, new() where TDTO : class
    {
        public TDTO Add(TDTO dTO);

        public TDTO Update(TDTO dTO);

        public TDTO Delete(TDTO dTO);

        public TDTO Remove(TDTO dTO);

        public IList< TDTO> AddRange(List< TDTO> dTOs);

        public IList<TDTO> GetAll();

        public TDTO Get(Expression<Func<TDTO, bool>> predicate);

        public TDTO Find(int id);


    }
}
