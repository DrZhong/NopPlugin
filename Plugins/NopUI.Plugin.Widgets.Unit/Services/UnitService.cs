using Nop.Core.Caching;
using Nop.Core.Data;
using NopUI.Plugin.Widgets.Unit.Domain;
using Nop.Services.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NopUI.Plugin.Widgets.Unit.Services
{
    public class UnitService:IUnitService
    {
        private IRepository<UnitEntity> _repository;
        private IEventPublisher _eventPublisher;
        private readonly ICacheManager _cacheManager;
        public UnitService(IRepository<UnitEntity> repository,
            IEventPublisher eventPublisher,ICacheManager cacheManage )
        {
            _repository = repository;
            _eventPublisher = eventPublisher;
            _cacheManager = cacheManage;
        }

        #region 获取所有单位
        /// <summary>
        /// 获取所有单位
        /// </summary>
        /// <returns></returns>
        public IList<Domain.UnitEntity> GetAll()
        {
            return _repository.Table.ToList();
        } 
        #endregion

        #region Creat
        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="Entity"></param>
        public void Insert(UnitEntity Entity)
        {
            if (Entity == null)
                throw new ArgumentNullException("UnitEntity");
            _repository.Insert(Entity);

            _eventPublisher.EntityInserted(Entity);
        } 
        #endregion

        private const string NOPPLUGINUNIT = "NopUI.Plugin.unit.{0}";
        private const string NOPPLUGINUNITALL = "NopUI.Plugin.unit";
        #region Get an entity by Id
        /// <summary>
        /// Get an entity by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public UnitEntity GetById(int Id)
        {
            var entity = _cacheManager.Get(string.Format(NOPPLUGINUNIT,Id), () =>
            {
                return _repository.GetById(Id);
            });
            return entity;
        } 
        #endregion

        #region update an entity
        /// <summary>
        /// update an entity
        /// </summary>
        /// <param name="entity"></param>
        public void Update(UnitEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("UnitEntity");
            _repository.Update(entity);
            _cacheManager.Remove(string.Format(NOPPLUGINUNIT,entity.Id));
            _eventPublisher.EntityUpdated(entity);
        } 
        #endregion

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(UnitEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("UnitEntity");
            _repository.Delete(entity);
            _cacheManager.RemoveByPattern(NOPPLUGINUNITALL);
            _eventPublisher.EntityDeleted(entity);
        }
    }
}
