﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Metro.DynamicModeules.Interface.Service.Base
{
    public interface IServiceBase<TModel> : ICommonServiceBase<TModel>
         where TModel : class
    {
        bool Commit(bool isSave = true);
        bool Update(Expression<Func<TModel, bool>> where, Dictionary<string, object> dic, bool isSave = true);
        TModel[] GetSearchList(Expression<Func<TModel, bool>> where);
        TModel[] GetSearchListByPage<TKey>(Expression<Func<TModel, bool>> where, Expression<Func<TModel, TKey>> orderBy, int pageSize, int pageIndex);//, out int totalRow);
        long GetListCount(Expression<Func<TModel, bool>> where);
    }
    public interface IApiControllerBase<TModel> : ICommonServiceBase<TModel>
         where TModel : class
    {
        /// <summary>
        /// 按照条件修改数据,但不保存
        /// </summary>
        /// <param name="where"></param>
        /// <param name="dic"></param>
        bool Update(XElement xmlPredicate, Dictionary<string, object> dic, bool isSave = true);

        TModel[] GetSearchList(XElement xmlPredicate);
       // TModel[] GetSearchListByPage<TKey>(XElement xmlPredicate, XElement xmlOrderBy, int pageSize, int pageIndex);//, out int totalRow);
        long GetListCount(XElement xmlPredicate);
    }
    public interface ICommonServiceBase<TModel>
        where TModel : class
    {
        /// <summary>
        /// 根据主键获取单个实体
        /// </summary>
        /// <returns></returns>
        TModel Find(object[] keyValues);

        /// <summary>
        /// 增加,成功后返回主键，失败返回null
        /// </summary>
        /// <returns></returns>
        object[] Add(TModel model, bool isSave = true);
        bool Add(TModel[] paramList, bool isSave = true);


        /// <summary>
        /// 更新
        /// </summary>
        /// <returns></returns>
        bool Update(TModel model, bool isSave = true);

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        bool Delete(bool isSave, object[] keyValues);
        bool Delete(bool isSave, TModel[] entities);
        bool Delete(TModel model, bool isSave = true);
    }
}
