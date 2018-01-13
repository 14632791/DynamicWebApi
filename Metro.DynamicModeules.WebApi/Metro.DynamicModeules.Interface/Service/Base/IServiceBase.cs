using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Metro.DynamicModeules.Interface.Service.Base
{
    public interface IServiceBase<TModel>
         where TModel : class, new()
    {
        /// <summary>
        /// 根据主键获取单个实体
        /// </summary>
        /// <returns></returns>
        TModel Get(params object[] keyValues);
        //List<TModel> Get(TModel serach, out int totalCount);

        /// <summary>
        /// 增加,成功后返回主键，失败返回null
        /// </summary>
        /// <returns></returns>
        object[] Add(TModel model, bool isSave = true);
        void Add(IEnumerable<TModel> paramList);


        /// <summary>
        /// 更新
        /// </summary>
        /// <returns></returns>
        bool Update(TModel model, bool isSave = true);
        /// <summary>
        /// 按照条件修改数据,但不保存
        /// </summary>
        /// <param name="where"></param>
        /// <param name="dic"></param>
        void Update(Expression<Func<TModel, bool>> where, Dictionary<string, object> dic);

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        bool Delete(bool isSave, params object[] keyValues);
        void Delete(params TModel[] paramList);
        bool Delete(TModel model, bool isSave = true);


        bool Commit(bool isSave = true);
        IEnumerable<TModel> GetSearchList(Expression<Func<TModel, bool>> where);
        IEnumerable<TModel> GetSearchListByPage<TKey>(Expression<Func<TModel, bool>> where, Expression<Func<TModel, TKey>> orderBy, int pageSize, int pageIndex, out int totalRow);

    }
}
