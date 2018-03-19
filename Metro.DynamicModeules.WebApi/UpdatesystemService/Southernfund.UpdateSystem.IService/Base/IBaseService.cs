/*----------------------------------------------------------------
* Copyright (C) 2017。
*
* 文件名：SwitchModelType.cs
* 功能描述：所有service类的基础接口
*
* Author：陈刚 Time：2015-10-20 16:42:32 
*
* 修改标识：
* 修改描述：
*
* 修改标识：
* 修改描述：
*
*----------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Southernfund.UpdateSystem.IService.Base
{
    /// <summary>
    /// 通用功能接口
    /// </summary>
    /// <typeparam name="TModel">返回的实体类型</typeparam>
    /// <typeparam name="TPrimaryKey">该实体的主键类型</typeparam>
    public interface IBaseService<TModel, TPrimaryKey>
        where TModel : class, new()
        //where TPrimaryKey : struct
    {
        /// <summary>
        /// 根据id获取单个实体
        /// </summary>
        /// <returns></returns>
        TModel Get(TPrimaryKey gid);

        /// <summary>
        /// 增加
        /// </summary>
        /// <returns></returns>
        bool Add(TModel model);

        /// <summary>
        /// 更新
        /// </summary>
        /// <returns></returns>
        bool Update(TModel model);
        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        bool Delete(TPrimaryKey gid);

        void Delete(params TModel[] paramList);

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="isSave"></param>
        /// <returns></returns>
        bool Commit(bool isSave);

        void Add(params TModel[] paramList);
        bool Add(TModel model, bool isSave);
        bool Delete(TModel model, bool isSave);
        IEnumerable<T> GetSearchList<T, TEFModel>(Expression<Func<TEFModel, bool>> where)
            where T : class
            where TEFModel : class;

        bool Update(TModel model, bool isSave);

    }


    public interface IMultPrimaryKeyServiceBase<TModel>
        where TModel : class, new()
    {
        /// <summary>
        /// 根据id获取单个实体
        /// </summary>
        /// <returns></returns>
        TModel Get(params object[] keyValues);


        List<TModel> GetList(TModel serach, out int totalCount);
        /// <summary>
        /// 增加
        /// </summary>
        /// <returns></returns>
        bool Add(TModel model);

        /// <summary>
        /// 更新
        /// </summary>
        /// <returns></returns>
        bool Update(TModel model);
        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        bool Delete(params object[] keyValues);


        void Add(params TModel[] paramList);
        bool Add(TModel model, bool isSave);
        bool Commit(bool isSave = true);
        void Delete(params TModel[] paramList);
        bool Delete(TModel model, bool isSave);
        IEnumerable<T> GetSearchList<T, TEF>(Expression<Func<TEF, bool>> where)
            where T : class
            where TEF : class;
        bool Update(TModel model, bool isSave);
    }
}
