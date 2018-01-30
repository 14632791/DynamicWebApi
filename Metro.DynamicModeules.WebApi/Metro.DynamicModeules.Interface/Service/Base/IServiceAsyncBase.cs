using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Metro.DynamicModeules.Interface.Service.Base
{
    public interface IServiceAsyncBase<TModel>: ICommonServiceAsyncBase<TModel>
         where TModel : class
    {
        Task<bool> Commit(bool isSave = true);
    }
   

    public interface ICommonServiceAsyncBase<TModel>
        where TModel : class
    {
        /// <summary>
        /// 根据主键获取单个实体
        /// </summary>
        /// <returns></returns>
        Task<TModel> Find(object[] keyValues); 
        Task<ObservableCollection<TModel>> GetSearchList(Expression<Func<TModel, bool>> where);
        Task<ObservableCollection<TModel>> GetSearchListByPage<TKey>(Expression<Func<TModel, bool>> where, Expression<Func<TModel, TKey>> orderBy, int pageSize, int pageIndex);//, out int totalRow);
        Task<long> GetListCount(Expression<Func<TModel, bool>> where);
        /// <summary>
        /// 增加,成功后返回主键，失败返回null
        /// </summary>
        /// <returns></returns>
        Task<object[]> Add(TModel model, bool isSave = true);
        Task<bool> Add(TModel[] paramList, bool isSave = true);


        /// <summary>
        /// 更新
        /// </summary>
        /// <returns></returns>
        Task<bool> Update(TModel model, bool isSave = true);
        Task<bool> Update(Expression<Func<TModel, bool>> where, Dictionary<string, object> dic, bool isSave = true);


        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        Task<bool> Delete(bool isSave,  object[] keyValues);
        Task<bool> Delete(bool isSave, TModel[] entities);
        Task<bool> Delete(TModel model, bool isSave = true);
      
    }
}
