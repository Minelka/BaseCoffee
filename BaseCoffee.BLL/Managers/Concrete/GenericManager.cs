using AutoMapper;
using BaseCoffee.BLL.Managers.Abstract;
using BaseCoffee.DAL.Entities.Abstract;
using BaseCoffee.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BaseCoffee.BLL.Managers.Concrete
{
    /// <summary>
    /// dto ve entity üzerinde işlemler gerçekleştiği sınıf
    /// </summary>
    public class GenericManager<TDTO, TEntity> : IGenericManager<TDTO, TEntity> where TEntity : BaseEntity, new() where TDTO : class
    {
        private readonly IMapper _mapper;
        private readonly IRepository <TEntity> _repository;

        //mapper dto ve entitty nesneleri arasında dönüşüm yapmamızı sağlar
        public GenericManager(IRepository<TEntity> repository) 
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<TDTO, TEntity>().ReverseMap());
            _mapper = new Mapper(config);
            _repository = repository;
        }

        /// <summary>
        /// yeni bir sto nesnesi ekler ve eklenen nesneyi döner
        /// </summary>
        /// <param name="dTO">eklenecek dto nesnesi </param>
        /// <returns>eklenen dto nesnesi </returns>
        public TDTO Add(TDTO dTO)
        {
            TEntity entity = _mapper.Map<TEntity>(dTO);
            var newEntity = _repository.Add(entity);
            TDTO newDto = _mapper.Map<TDTO>(newEntity);
            return newDto;
        }
         
        /// <summary>
        /// bir liste hakinde dto nesnelerini ekler ve elenen listenin döner
        /// </summary>
        /// <param name="dTOs"></param>
        /// <returns></returns>
        public IList<TDTO> AddRange(List<TDTO> dTOs)
        {
            List<TEntity> entities = _mapper.Map<List<TEntity>>(dTOs);
            _repository.AddRange(entities);
            return dTOs;
        }
        /// <summary>
        /// belirtilen dto nesnesini siler
        /// </summary>
        /// <param name="dTO"></param>
        /// <returns></returns>
        public TDTO Delete(TDTO dTO)
        {
            TEntity entity = _mapper.Map<TEntity>(dTO);
            _repository.Delete(entity);
            return dTO;
        }

        /// <summary>
        /// BELİRTİLEN KİMLİĞE GÖRE BİR DTO NESNESİ BULUR VE DÖNER
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TDTO Find(int id)
        {
            var entity= _repository.Find(id);
            var DTO =_mapper.Map<TDTO>(entity);
            return DTO;
        }

        /// <summary>
        /// belirtilen koşula göre dto nesnesini getirir
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public TDTO Get(Expression<Func<TDTO, bool>> predicate)
        {
            var entityPredicate = _mapper.Map<Expression<Func<TEntity, bool>>>(predicate);
            var entity = _repository.Get(entityPredicate);
            var DTO = _mapper.Map<TDTO>(entity);
            return DTO;
        }

        /// <summary>
        /// tüm dto nesnelerinin listesini döner
        /// </summary>
        /// <returns></returns>
        public IList<TDTO> GetAll()
        {
            var entities= _repository.GetAll();
            var DTOs= _mapper.Map<List<TDTO>>(entities);
            return DTOs;
        }

        /// <summary>
        /// belirtilen dto nesnesini kaldırır ve kaldırılan nesneyi döner
        /// </summary>
        /// <param name="dTO"></param>
        /// <returns></returns>
        public TDTO Remove(TDTO dTO)
        {
            TEntity entity = _mapper.Map<TEntity>(dTO);
            _repository.Remove(entity);
            return dTO;
        }

        /// <summary>
        /// belirtilen dto nesnesini günceller ve güncellenmiş nesneyi döner
        /// </summary>
        /// <param name="dTO"></param>
        /// <returns></returns>
        public TDTO Update(TDTO dTO)
        {
            TEntity entity = _mapper.Map<TEntity> (dTO);
            _repository.Update(entity);
            return dTO;
        }
    }
}
