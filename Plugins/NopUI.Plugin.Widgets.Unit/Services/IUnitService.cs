using NopUI.Plugin.Widgets.Unit.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NopUI.Plugin.Widgets.Unit.Services
{
    public interface IUnitService
    {
        /// <summary>
        /// 获取所有单位
        /// </summary>
        /// <returns></returns>
        IList<UnitEntity> GetAll();

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="Entity"></param>
        void Insert(Domain.UnitEntity Entity);

        /// <summary>
        /// 通过Id获取实体
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        UnitEntity GetById(int Id);

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="entity"></param>
        void Update(UnitEntity entity);

        /// <summary>
        /// delete an entity
        /// </summary>
        /// <param name="entity"></param>
        void Delete(UnitEntity entity);
    }
}
