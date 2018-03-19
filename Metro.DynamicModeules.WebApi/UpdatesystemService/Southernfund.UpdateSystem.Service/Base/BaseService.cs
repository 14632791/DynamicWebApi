/*----------------------------------------------------------------
* Copyright (C) 2017。
*
* 文件名：BaseService.cs
* 功能描述： 封装的EF基类 只适用了DB Frist
*
* Author：陈刚 Time：2015-12-17 
*
* 修改标识：
* 修改描述：
*
* 修改标识：
* 修改描述：
*
*----------------------------------------------------------------*/



using Southernfund.UpdateSystem.DAL;
using Southernfund.UpdateSystem.IService.Base;
using Southernfund.UpdateSystem.Model.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Southernfund.UpdateSystem.Service.Base
{
    /// <summary>
    /// 封装的EF基类,只适用了DB Frist
    /// </summary>
    /// <typeparam name="TModel">手动生成的实体类</typeparam>
    /// <typeparam name="TEFModel">EF自动生成的实体类</typeparam>
    /// <typeparam name="TPrimaryKey">主键，默认只有一个</typeparam>
    public abstract class BaseService<TModel, TEFModel, TPrimaryKey> : IBaseService<TModel, TPrimaryKey> where TModel : class, new()
        where TEFModel : class, new()
        //where TPrimaryKey : struct
    {
        public BaseService()
        {
            IsOptRecord = true;
        }
        /// <summary>
        /// 重新给Context赋值，在Commit()执行之前警慎使用
        /// </summary>
        private void RefreshContext()
        {
            _context = GetContext();
        }
        /// <summary>
        /// 该EF对应的数据上下文,只限于当前项目内使用
        /// </summary>
        internal DbContext Context
        {
            get
            {
                if (null == _context)
                {
                    lock (_objLock)
                    {
                        RefreshContext();
                    }
                }
                return _context;
            }
            set
            {
                _context = value;
            }
        }
        #region 私有变量

        protected readonly object _objLock = new object();

        internal DbContext _context = null;
        /// <summary>
        /// 主键列表
        /// </summary>
        protected List<string> _lstPrimaryName = new List<string>();


        #endregion


        #region 新增操作
        /// <summary>
        /// 实体新增但不保存
        /// </summary>
        /// <param name="model"></param>
        public void Add(params TModel[] paramList)
        {
            Add(paramList.Select(p => ConvertToModel(p)).ToArray());
        }
        public void Add(params TEFModel[] paramList)
        {
            Monitor.Enter(_objLock);
            try
            {
                foreach (var model in paramList)
                {
                    Context.Entry<TEFModel>(model).State = EntityState.Added;
                }
            }
            catch (Exception e)
            {
                LogHelper.ErrorLog(string.Format("BaseService-Add 实体类型：{0},内容：{1}", typeof(TModel).Name, paramList.JsonSe()), e);
            }
            finally
            {
                Monitor.Exit(_objLock);
            }
        }

        /// <summary>
        /// 新增操作，当有多表事务操作时，不需要保存
        /// </summary>
        /// <param name="model"></param>
        /// <param name="isSave">是否保存</param>
        /// <returns></returns>
        public virtual bool Add(TModel model, bool isSave)
        {
            Monitor.Enter(_objLock);
            try
            {
                //说明数据已存在就不要再添加 了 2016.1.22 陈刚
                TModel tmpModel = Get(GetPrimaryKey(model));
                if (null != tmpModel) return true;
                TEFModel efModel = ConvertToModel(model);
                Context.Entry<TEFModel>(efModel).State = EntityState.Added;
                return Commit(isSave);
            }
            catch (Exception e)
            {
                LogHelper.ErrorLog(string.Format("BaseService-Add 实体类型：{0},内容：{1}", typeof(TModel).Name, model.JsonSe()), e);
                return false;
            }
            finally
            {
                Monitor.Exit(_objLock);
            }
        }



        internal bool AddEf(TEFModel efModel, bool isSave)
        {
            Monitor.Enter(_objLock);
            try
            {
                Context.Entry<TEFModel>(efModel).State = EntityState.Added;
                return Commit(isSave);
            }
            catch (Exception e)
            {
                LogHelper.ErrorLog(string.Format("BaseService-AddEf 实体类型：{0},内容：{1}", typeof(TModel).Name, efModel.JsonSe()), e);
                return false;
            }
            finally
            {
                Monitor.Exit(_objLock);
            }
        }
        #endregion

        #region 分页查询及普通查询
        /// <summary>
        /// 实体查询
        /// </summary>
        public IEnumerable<TModel> GetSearchList(System.Linq.Expressions.Expression<Func<TEFModel, bool>> where)
        {
            //Monitor.Enter(_objLock);
            try
            {
                List<TEFModel> lstEf = GetSearchListEf(where).ToList();
                int total = lstEf.Count;
                TModel[] lstModel = new TModel[total];
                Parallel.For(0, total, (i) =>
                {
                    lstModel[i] = ConvertToModel(lstEf[i]);
                });
                return lstModel;
            }
            catch (Exception e)
            {
                LogHelper.ErrorLog("BaseService-GetSearchList,类型： " + GetTableName(), e);
                return new List<TModel>();
            }
            finally
            {
                //Monitor.Exit(_objLock);
            }
        }
        internal IEnumerable<TEFModel> GetSearchListEf(System.Linq.Expressions.Expression<Func<TEFModel, bool>> where)
        {
            //Monitor.Enter(_objLock);
            try
            {
                DbContext context = GetContext();//解决缓存问题，所以new 
                IQueryable<TEFModel> lstEf = context.Set<TEFModel>().Where(where);
                return lstEf;
            }
            catch (Exception e)
            {
                LogHelper.ErrorLog("BaseService-GetSearchList,类型： " + GetTableName(), e);
                return new List<TEFModel>();
            }
            finally
            {
                //Monitor.Exit(_objLock);
            }
        }

        public IEnumerable<T> GetSearchList<T, TEF>(System.Linq.Expressions.Expression<Func<TEF, bool>> where)
            where T : class
            where TEF : class
        {
            try
            {
                DbContext context = GetContext();//解决缓存问题，所以new 
                List<TEF> lstEf = context.Set<TEF>().Where(where).ToList();
                int total = lstEf.Count;
                T[] lstModel = new T[total];
                Parallel.For(0, total, (i) =>
                {
                    string convert = JsonHelper.JonsSeWithoutSelfLoop(lstEf[i]);
                    lstModel[i] = JsonHelper.JsonDe<T>(convert);
                    //lstModel[i] = ConvertToModel<TEF, T>(lstEf[i]);
                });
                return lstModel;
            }
            catch (Exception e)
            {
                LogHelper.ErrorLog("BaseService-GetSearchList,类型： " + GetTableName(), e);
                return new List<T>();
            }
        }

        /// <summary>
        /// 实体分页查询
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="where"></param>
        /// <param name="orderBy"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex">第一页从0开始</param>
        /// <returns></returns>
        public IEnumerable<TModel> GetSearchListByPage<TKey>(Expression<Func<TEFModel, bool>> where, Expression<Func<TEFModel, TKey>> orderBy, int pageSize, int pageIndex)
        {
            //Monitor.Enter(_objLock);
            try
            {
                var lstEf = GetSearchListByPageEf(where, orderBy, pageSize, pageIndex).ToArray();
                int total = lstEf.Count();
                TModel[] lstModel = new TModel[total];
                Parallel.For(0, total, (i) =>
                {
                    lstModel[i] = ConvertToModel(lstEf[i]);
                });
                return lstModel;
            }
            catch (Exception e)
            {
                LogHelper.ErrorLog("BaseService-GetSearchListByPage<TKey>,类型： " + GetTableName(), e);
                return new List<TModel>();
            }
            finally
            {
                //Monitor.Exit(_objLock);
            }
        }

        internal IEnumerable<TEFModel> GetSearchListByPageEf<TKey>(Expression<Func<TEFModel, bool>> where, Expression<Func<TEFModel, TKey>> orderBy, int pageSize, int pageIndex)
        {
            try
            {
                DbContext context = GetContext();//解决缓存问题，所以new 
                var lstEf = context.Set<TEFModel>().Where(where).OrderByDescending(orderBy).Skip((pageIndex) * pageSize).Take(pageSize).ToList();
                int total = lstEf.Count;
                return lstEf;
            }
            catch (Exception e)
            {
                LogHelper.ErrorLog("BaseService-GetSearchListByPage<TKey>,类型： " + GetTableName(), e);
                return new List<TEFModel>();
            }
            finally
            {
            }
        }

        public IEnumerable<TModel> GetSearchListByPage<TKey>(Expression<Func<TEFModel, bool>> where, Expression<Func<TEFModel, TKey>> orderBy, int pageSize, int pageIndex, out int totalRow)
        {
            totalRow = 0;
            //Monitor.Enter(_objLock);
            try
            {
                lock (_objLock)
                {
                    totalRow = Context.Set<TEFModel>().Where(where).Count();
                }
                return GetSearchListByPage(where, orderBy, pageSize, pageIndex);
            }
            catch (Exception e)
            {
                LogHelper.ErrorLog("BaseService-GetSearchListByPage<TKey>,类型： " + GetTableName(), e);
                return new List<TModel>();
            }
            finally
            {
                //Monitor.Exit(_objLock);
            }
        }

        public IEnumerable<T> GetSearchListByPage2<TOrder, T>(Expression<Func<TEFModel, bool>> where, Expression<Func<TEFModel, TOrder>> orderBy, int pageSize, int pageIndex, out int totalRow)
        {
            totalRow = 0;
            try
            {
                IQueryable<TEFModel> ic = Context.Set<TEFModel>().Where(where);
                totalRow = ic.Count();
                List<TEFModel> lstEf = ic.OrderByDescending(orderBy).Skip((pageIndex) * pageSize).Take(pageSize).ToList();
                int total = lstEf.Count;
                T[] lstModel = new T[total];
                Parallel.For(0, total, (i) =>
                {
                    string strConvert = JsonHelper.JsonSe(lstEf[i]);
                    lstModel[i] = JsonHelper.JsonDe<T>(strConvert);
                });
                return lstModel;
            }
            catch (Exception e)
            {
                LogHelper.ErrorLog("BaseService-GetSearchListByPage2<TOrder, T>,类型： " + GetTableName(), e);
                return new List<T>();
            }
        }
        #endregion

        #region 删除操作

        /// <summary>
        /// 删除多个实体，但不保存
        /// </summary>
        /// <param name="model"></param>
        public virtual void Delete(params TModel[] paramList)
        {
            try
            {
                if (null == paramList) return;
                foreach (var model in paramList)
                {
                    if (null == model) continue;
                    Context.Entry<TEFModel>(ConvertToModel(model)).State = EntityState.Deleted;
                }
                // Commit();
            }
            catch (Exception e)
            {
                LogHelper.ErrorLog(string.Format("BaseService-Delete 实体类型：{0},内容：{1}", typeof(TModel).Name, paramList.JsonSe()), e);
            }
        }

        /// <summary>
        /// 删除一个实体，当有多表事务操作时不需要保存
        /// </summary>
        /// <param name="model"></param>
        /// <param name="isSave">是否保存</param>
        /// <returns></returns>
        public virtual bool Delete(TModel model, bool isSave)
        {
            //解决造成相同键的多个对象问题
            Monitor.Enter(_objLock);
            try
            {
                if (null == model) return true;
                TEFModel efModel = ConvertToModel(model);
                Context.Entry<TEFModel>(efModel).State = EntityState.Deleted;
                return Commit(isSave);
            }
            catch (Exception e)
            {
                LogHelper.ErrorLog(string.Format("BaseService-Delete [删除一个实体]：{0},内容：{1}", typeof(TModel).Name, model.JsonSe()), e);
                return false;
            }
            finally
            {
                Monitor.Exit(_objLock);
            }
        }
        internal bool Delete(TEFModel efModel, bool isSave)
        { //解决造成相同键的多个对象问题
            Monitor.Enter(_objLock);
            try
            {
                if (null == efModel) return true;
                Context.Entry<TEFModel>(efModel).State = EntityState.Deleted;
                return Commit(isSave);
            }
            catch (Exception e)
            {
                LogHelper.ErrorLog(string.Format("BaseService-DeleteEf [删除一个实体]：{0},内容：{1}", typeof(TModel).Name, efModel.JsonSe()), e);
                return false;
            }
            finally
            {
                Monitor.Exit(_objLock);
            }
        }

        /// <summary>
        /// 删除gid对应的一个实体，当有多表事务操作时不需要保存
        /// </summary>
        /// <param name="gid"></param>
        /// <param name="isSave"></param>
        /// <returns></returns>
        public virtual bool Delete(TPrimaryKey gid, bool isSave)
        {
            try
            {
                //TEFModel efModel = Find(gid);
                //return Delete(efModel, isSave);
                TModel model = Get(gid);
                if (null == model) return true;
                return Delete(model, isSave);
            }
            catch (Exception e)
            {
                LogHelper.ErrorLog("BaseService-Delete: " + GetTableName(), e);
                return false;
            }
        }
        #endregion

        #region 更新操作
        /// <summary>
        /// 按照条件修改数据,但不保存
        /// </summary>
        /// <param name="where"></param>
        /// <param name="dic"></param>
        public void Update(Expression<Func<TEFModel, bool>> where, Dictionary<string, object> dic)
        {
            Monitor.Enter(_objLock);
            try
            {
                IEnumerable<TEFModel> result = Context.Set<TEFModel>().Where(where).ToList();
                if (null == result || result.Count() <= 0) return;
                Type type = typeof(TEFModel);
                List<PropertyInfo> propertyList = type.GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance).ToList();
                //遍历结果集
                foreach (TEFModel entity in result)
                {
#pragma warning disable CS0219 // 变量“isUpdate”已被赋值，但从未使用过它的值
                    bool isUpdate = false;
#pragma warning restore CS0219 // 变量“isUpdate”已被赋值，但从未使用过它的值
                    foreach (var item in dic)
                    {
                        string propertyName = propertyList.Where(p => string.Compare(p.Name, item.Key, true) == 0 && !_lstPrimaryName.Contains(p.Name)).Select(p => p.Name).FirstOrDefault();
                        if (!string.IsNullOrEmpty(propertyName))
                        {
                            Context.Entry<TEFModel>(entity).Property(propertyName).CurrentValue = dic[propertyName];
                            isUpdate = true;
                        }
                    }
                }
                // Commit();
            }
            catch (Exception e)
            {
                LogHelper.ErrorLog(string.Format("BaseService-Update：{0},内容：{1}", typeof(TModel).Name, dic.JsonSe()), e);
            }
            finally
            {
                Monitor.Exit(_objLock);
            }
        }


        /// <summary>
        /// 更新一个实体,当主键不是自增长的int类型时才能使用，由于历史原因，暂时不适用于有增长主键表的更新操作
        /// </summary>
        /// <param name="model"></param>
        /// <param name="isSave"></param>
        /// <returns></returns>
        public bool Update(TModel model, bool isSave)
        {
            if (model == null) return false;
            bool flag = UpdateEf(ConvertToModel(model), isSave, GetPrimaryKey(model));
            if (!flag && (IsOptRecord || DownLoadedOptRecord))//确定要同步数据时才加备用方案
            {
                return DealFailUpdate(model, GetPrimaryKey(model));
            }
            return flag;
        }

        internal bool UpdateEf(TEFModel efModel, bool isSave, TPrimaryKey key)
        {
            Monitor.Enter(_objLock);
            try
            {
#pragma warning disable CS0219 // 变量“isUpdate”已被赋值，但从未使用过它的值
                bool isUpdate = false;
#pragma warning restore CS0219 // 变量“isUpdate”已被赋值，但从未使用过它的值
                EntityState state = Context.Entry<TEFModel>(efModel).State;
                switch (state)
                {
                    case EntityState.Modified:
                        isUpdate = true;
                        break;
                    case EntityState.Detached:
                        try
                        {
                            Context.Set<TEFModel>().Attach(efModel);
                            Context.Entry<TEFModel>(efModel).State = EntityState.Modified;
                            isUpdate = true;
                        }
                        catch (InvalidOperationException e)
                        {
                            TEFModel old = JsonHelper.JsonDe<TEFModel>(JsonHelper.JsonSe(efModel));
                            Context.Entry(old).CurrentValues.SetValues(efModel);
                            isUpdate = true;
                            LogHelper.ErrorLog(string.Format("BaseService-UpdateEf：{0},内容：{1}", typeof(TModel).Name, efModel.JsonSe()), e);
                        }
                        break;
                    default:
                        break;
                }
                //if (isUpdate)
                //{
                //    //同步操作
                //    AddOptRecord(key, DataRowState.Modified);
                //}
                return Commit(isSave);
            }
            catch (Exception e)
            {
                LogHelper.ErrorLog(string.Format("BaseService-UpdateEf：{0},内容：{1}", typeof(TModel).Name, efModel.JsonSe()), e);
                return false;
            }
            finally
            {
                Monitor.Exit(_objLock);
            }
        }

        /// <summary>
        /// 如果更新失败，则启动新增机制
        /// </summary>
        /// <param name="efModel"></param>
        /// <param name="key"></param>
        public bool DealFailUpdate(TModel efModel, TPrimaryKey key)
        {
            try
            {
                TModel model = Get(key);
                if (model == null)
                {
                    return Add(efModel);
                }
                return false;
            }
            catch (Exception ex)
            {
                LogHelper.ErrorLog(string.Format("BaseService-DealFailUpdate：{0},内容：{1}", typeof(TModel).Name, efModel.JsonSe()), ex);
                return false;
            }
        }
        #endregion

        /// <summary>
        /// 提交所做的更改同时释放资源
        /// </summary>
        /// <returns></returns>
        public virtual bool Commit(bool isSave = true)
        {
            if (!isSave) return true;
            Monitor.Enter(_objLock);
            try
            {
                bool bResult = false;
                if (null == _context) return bResult;
                bResult = _context.SaveChanges() > 0;
                return bResult;
            }
            catch (Exception e)
            {
                LogHelper.ErrorLog("BaseService-Commit,类型： " + GetTableName(), e);
                return false;
            }
            finally
            {
                if (isSave)
                {
                    RefreshContext();
                }
                Monitor.Exit(_objLock);
            }
        }

        /// <summary>
        /// 获取当前的表名
        /// </summary>
        /// <returns></returns>
        protected virtual string GetTableName()
        {
            Type type = typeof(TEFModel);
            return type.Name;
        }

        #region EF实体与手动实体之间的转换
        /// <summary>
        /// EF实体转换为Model,不包括子表集合的内容
        /// </summary>
        /// <param name="oModel"></param>
        /// <returns></returns>
        public virtual TModel ConvertToModel(TEFModel EfModel)
        {
            try
            {
                string strConvert = JsonHelper.JsonSe(EfModel);
                return JsonHelper.JsonDe<TModel>(strConvert);
            }
            catch (Exception e)
            {
                LogHelper.ErrorLog(string.Format("BaseService-ConvertToModel：{0},内容：{1}", typeof(TEFModel).Name, EfModel.JsonSe()), e);
                return null;
            }
        }

        /// <summary>
        /// Model实体转换为EF实体,不包括子表集合的内容
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public virtual TEFModel ConvertToModel(TModel model)
        {
            try
            {
                string strConvert = JsonHelper.JsonSe(model);
                return JsonHelper.JsonDe<TEFModel>(strConvert);
            }
            catch (Exception e)
            {
                LogHelper.ErrorLog("BaseService-ConvertToModel,类型： " + GetTableName(), e);
                return null;
            }
        }
        public TDestination ConvertToModel<TSource, TDestination>(TSource model)
            where TSource : class
            where TDestination : class
        {
            string strConvert = JsonHelper.JsonSe(model);
            return JsonHelper.JsonDe<TDestination>(strConvert);
        }

        /// <summary>
        /// 简单的clonemodel的数据功能，暂时只支持单属性复制 huqin 2016-03-05
        /// </summary>
        /// <typeparam name="TSource">复制的元数据</typeparam>
        /// <typeparam name="TDestination">目标数据</typeparam>
        /// <param name="des">目标数据</param>
        /// <param name="model">复制的元数据</param>
        public void CloneModelData<TSource, TDestination>(TSource sourceModel, TDestination desModel)
        {
            Dictionary<string, PropertyInfo> dicSourcePinfo = sourceModel.GetType().GetProperties().ToDictionary(x => x.Name, y => y);
            Dictionary<string, PropertyInfo> dicDesInfo = desModel.GetType().GetProperties().ToDictionary(x => x.Name, y => y);
            foreach (var item in dicSourcePinfo)
            {
                if (dicDesInfo.ContainsKey(item.Key))
                {
                    PropertyInfo pinfoDes = dicDesInfo[item.Key];
                    PropertyInfo pinfoSou = item.Value;
                    pinfoDes.SetValue(desModel, pinfoSou.GetValue(sourceModel, null), null);
                }
            }
        }
        #endregion

        #region 使用SQL语句查询
        /// <summary>
        /// 使用SQL语句查询
        /// </summary>
        /// <typeparam name="TCustom"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        protected List<TDestination> SqlQuery<TDestination>(string sql, DbParameter[] parameter = null) where TDestination : class
        {
            try
            {
                using (DbContext context = GetContext())
                {
                    IEnumerable<TDestination> lstModel = null;
                    if (parameter == null)
                    {
                        lstModel = context.Database.SqlQuery<TDestination>(sql);
                    }
                    else
                    {
                        lstModel = context.Database.SqlQuery<TDestination>(sql, parameter);
                    }
                    List<TDestination> lst = lstModel.ToList();
                    return lst;
                }
            }
            catch (Exception e)
            {
                LogHelper.ErrorLog("BaseService-SqlQuery,类型： " + GetTableName(), e);
                return null;
            }
        }
        /// <summary>
        /// 使用SQL语句查询
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        protected List<TModel> SqlQuery(string sql, DbParameter[] parameter = null)
        {
            try
            {
                using (DbContext context = GetContext())
                {
                    IEnumerable<TModel> lstModel = null;
                    if (parameter == null)
                    {
                        lstModel = context.Database.SqlQuery<TModel>(sql);
                    }
                    else
                    {
                        lstModel = context.Database.SqlQuery<TModel>(sql, parameter);
                    }
                    List<TModel> lst = lstModel.ToList();
                    return lst;
                }
            }
            catch (Exception e)
            {
                LogHelper.ErrorLog("BaseService-SqlQuery,类型： " + GetTableName(), e);
                return null;
            }
        }
        #endregion

        #region 子类必须要实现的抽象方法

        /// <summary>
        /// 获取实体entity的主键，模板方法模式，该方法延迟到子类中实现
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        protected abstract TPrimaryKey GetPrimaryKey(TModel entity);

        #endregion

        #region IBaseService接口

        /// <summary>
        /// 返回该商家的所有数据的主键
        /// </summary>
        /// <param name="merId"></param>
        /// <returns></returns>
        public virtual List<TPrimaryKey> GetListByMerchants(int merId)
        {
            return null;
        }

        /// <summary>
        /// 是否同步数据
        /// </summary>
        public bool IsOptRecord
        {
            get;
            set;
        }

        public bool DownLoadedOptRecord { get; set; }

        /// <summary>
        /// 根据主键获得实体
        /// </summary>
        /// <param name="gid"></param>
        /// <returns></returns>
        public virtual TModel Get(TPrimaryKey gid)
        {
            try
            {
                TEFModel efModel = Find(gid);
                if (null == efModel) return null;
                return ConvertToModel(efModel);
            }
            catch (Exception e)
            {
                LogHelper.ErrorLog(string.Format("BaseService-Get,方法名{0},主键值:{1}/ ", GetTableName(), gid), e);
                return null;
            }
        }
        /// <summary>
        /// 只限定主键一致的情况下使用
        /// </summary>
        /// <param name="gids"></param>
        /// <returns></returns>
        protected TEFModel Find(TPrimaryKey gid)
        {
            try
            {
                DbContext context = GetContext();//解决缓存问题，所以new 
                return context.Set<TEFModel>().Find(gid);
            }
            catch (Exception e)
            {
                LogHelper.ErrorLog("BaseService-Find:" + GetTableName(), e);
                return null;
            }
            finally
            {
            }
        }

        public virtual bool Add(TModel model)
        {
            return Add(model, true);
        }

        public virtual bool Update(TModel model)
        {
            return Update(model, true);
        }

        public virtual bool Delete(TPrimaryKey gid)
        {
            return Delete(gid, true);
        }

        #endregion



        protected DbContext GetContext()
        {
            return new Entities();
        }

    }
}
