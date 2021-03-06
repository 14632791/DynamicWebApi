﻿using Metro.DynamicModeules.Interface.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Threading;
using System.ComponentModel.DataAnnotations.Schema;
using Metro.DynamicModeules.Common;
using System.Reflection;
using Metro.DynamicModeules.CodeFirst.Models;

namespace Metro.DynamicModeules.Service.Base
{
    public abstract class ServiceBase<TModel> : IServiceBase<TModel>
          where TModel : class, new()
    {
        protected  DbSet<TModel> GetDbSet()
        {

        }
        /// <summary>
        /// 重新给Context赋值，在Commit()执行之前警慎使用
        /// </summary>
        private void RefreshContext()
        {
            _dbContext = GetContext();
            switch (EntitiesType)
            {
                case EntitiesType.NormalContext:
                    CSFramework3NormalContext normalContext= _dbContext as CSFramework3NormalContext;
                    normalContext
                    break;
                case EntitiesType.SystemContext:
                    CSFramework3SystemContext sysContext = _dbContext as CSFramework3SystemContext;
                    break;
                default:
                    return null;
            }
        }
        internal DbContext DbContext
        {
            get
            {
                if (null == _dbContext)
                {
                    lock (_objLock)
                    {
                        RefreshContext();
                    }
                }
                return _dbContext;
            }
        }
        protected DbContext _dbContext;
        /// <summary>
        /// 该EF对应的数据上下文,只限于当前项目内使用
        /// </summary>
        internal DbSet<TModel> DbSet
        {
            get
            {
                if (null == _dbset)
                {
                    _dbset = GetDbSet();
                }
                return _dbset;
            }
        }
        #region 私有变量
        /// <summary>
        /// 连接哪个DB
        /// </summary>
        protected EntitiesType EntitiesType { get; set; } = EntitiesType.NormalContext;
        protected readonly object _objLock = new object();

        internal DbSet<TModel> _dbset = null;
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
        public void Add(IEnumerable<TModel> paramList)
        {
            Monitor.Enter(_objLock);
            try
            {
                DbSet.AddRange(paramList);
            }
            catch (Exception e)
            {
                LogHelper.Error(string.Format("BaseService-Add 实体类型：{0},内容：{1}", typeof(TModel).Name, paramList.JsonSe()), e);
            }
            finally
            {
                Monitor.Exit(_objLock);
            }
        }

        /// <summary>
        /// 返回新增后的主键
        /// </summary>
        /// <param name="efModel"></param>
        /// <param name="isSave"></param>
        /// <returns></returns>
        public virtual object[] Add(TModel efModel, bool isSave = true)
        {
            Monitor.Enter(_objLock);
            try
            {
                DbSet.Add(efModel);//Entry<TModel>(efModel).State = EntityState.Added;
                if (Commit(isSave))
                {
                    return GetPrimaryKey(efModel);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                LogHelper.Error(string.Format("BaseService-AddEf 实体类型：{0},内容：{1}", typeof(TModel).Name, efModel.JsonSe()), e);
                return null;
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
        public IEnumerable<TModel> GetSearchList(System.Linq.Expressions.Expression<Func<TModel, bool>> where)
        {
            //Monitor.Enter(_objLock);
            try
            {
                DbSet<TModel> context = GetContext();//解决缓存问题，所以new 
                IQueryable<TModel> lstEf = context.Where(where);
                return lstEf;
            }
            catch (Exception e)
            {
                LogHelper.Error("BaseService-GetSearchList,类型： " + GetTableName(), e);
                return null;
            }
            finally
            {
                //Monitor.Exit(_objLock);
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
        public IEnumerable<TModel> GetSearchListByPage<TKey>(Expression<Func<TModel, bool>> where, Expression<Func<TModel, TKey>> orderBy, int pageSize, int pageIndex)
        {
            try
            {
                DbSet<TModel> dbSet = GetDbSet();//解决缓存问题，所以new 
                var lstEf = context.Set<TModel>().Where(where).OrderByDescending(orderBy).Skip((pageIndex) * pageSize).Take(pageSize).ToList();
                int total = lstEf.Count;
                return lstEf;
            }
            catch (Exception e)
            {
                LogHelper.Error("BaseService-GetSearchListByPage<TKey>,类型： " + GetTableName(), e);
                return new List<TModel>();
            }
            finally
            {
            }
        }

        public IEnumerable<TModel> GetSearchListByPage<TKey>(Expression<Func<TModel, bool>> where, Expression<Func<TModel, TKey>> orderBy, int pageSize, int pageIndex, out int totalRow)
        {
            totalRow = 0;
            //Monitor.Enter(_objLock);
            try
            {
                totalRow = DbSet.Set<TModel>().Where(where).Count();
                return GetSearchListByPage(where, orderBy, pageSize, pageIndex);
            }
            catch (Exception e)
            {
                LogHelper.Error("BaseService-GetSearchListByPage<TKey>,类型： " + GetTableName(), e);
                return new List<TModel>();
            }
            finally
            {
                //Monitor.Exit(_objLock);
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
                    DbSet.Entry<TModel>(model).State = EntityState.Deleted;
                }
                // Commit();
            }
            catch (Exception e)
            {
                LogHelper.Error(string.Format("BaseService-Delete 实体类型：{0},内容：{1}", typeof(TModel).Name, paramList.JsonSe()), e);
            }
        }

        /// <summary>
        /// 删除一个实体，当有多表事务操作时不需要保存
        /// </summary>
        /// <param name="model"></param>
        /// <param name="isSave">是否保存</param>
        /// <returns></returns>       
        public bool Delete(TModel efModel, bool isSave)
        { //解决造成相同键的多个对象问题
            Monitor.Enter(_objLock);
            try
            {
                if (null == efModel) return true;
                DbSet.Entry<TModel>(efModel).State = EntityState.Deleted;
                return Commit(isSave);
            }
            catch (Exception e)
            {
                LogHelper.Error(string.Format("BaseService-DeleteEf [删除一个实体]：{0},内容：{1}", typeof(TModel).Name, efModel.JsonSe()), e);
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
        public virtual bool Delete(bool isSave, params object[] keyValues)
        {
            try
            {
                TModel model = Get(keyValues);
                if (null == model) return true;
                return Delete(model, isSave);
            }
            catch (Exception e)
            {
                LogHelper.Error("BaseService-Delete: " + GetTableName(), e);
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
        public void Update(Expression<Func<TModel, bool>> where, Dictionary<string, object> dic)
        {
            Monitor.Enter(_objLock);
            try
            {
                IEnumerable<TModel> result = DbSet.Where(where).ToList();
                if (null == result || result.Count() <= 0) return;
                Type type = typeof(TModel);
                List<PropertyInfo> propertyList = type.GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance).ToList();
                //遍历结果集
                foreach (TModel entity in result)
                {
                    //bool isUpdate = false;
                    foreach (var item in dic)
                    {
                        var property = propertyList.FirstOrDefault(p => string.Compare(p.Name, item.Key, true) == 0 && !_lstPrimaryName.Contains(p.Name));
                        if (null!= property&&!string.IsNullOrEmpty(property.Name))
                        {
                            
                            //DbSet.Entry<TModel>(entity).Property(propertyName).CurrentValue = dic[propertyName];
                            //isUpdate = true;
                        }
                    }
                }
                // Commit();
            }
            catch (Exception e)
            {
                LogHelper.Error(string.Format("BaseService-Update：{0},内容：{1}", typeof(TModel).Name, dic.JsonSe()), e);
            }
            finally
            {
                Monitor.Exit(_objLock);
            }
        }



        public bool Update(TModel efModel, bool isSave)
        {
            Monitor.Enter(_objLock);
            try
            {
                bool isUpdate = false;
                EntityState state = DbSet(efModel).State;
                switch (state)
                {
                    case EntityState.Modified:
                        isUpdate = true;
                        break;
                    case EntityState.Detached:
                        try
                        {
                            DbSet.Set<TModel>().Attach(efModel);
                            DbSet.Entry<TModel>(efModel).State = EntityState.Modified;
                            isUpdate = true;
                        }
                        catch (InvalidOperationException e)
                        {
                            TModel old = JsonHelper.JsonDe<TModel>(JsonHelper.JsonSe(efModel));
                            DbSet.Entry(old).CurrentValues.SetValues(efModel);
                            isUpdate = true;
                            LogHelper.Error(string.Format("BaseService-UpdateEf：{0},内容：{1}", typeof(TModel).Name, efModel.JsonSe()), e);
                        }
                        break;
                    default:
                        break;
                }
                return Commit(isSave);
            }
            catch (Exception e)
            {
                LogHelper.Error(string.Format("BaseService-UpdateEf：{0},内容：{1}", typeof(TModel).Name, efModel.JsonSe()), e);
                return false;
            }
            finally
            {
                Monitor.Exit(_objLock);
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
                if (null == _dbset) return bResult;
                bResult = _dbset.SaveChanges() > 0;
                return bResult;
            }
            catch (Exception e)
            {
                LogHelper.Error("BaseService-Commit,类型： " + GetTableName(), e);
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
            return typeof(TModel).GetAttributeValue((TableAttribute ta) => ta.Name);
        }

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
                using (DbSet<TModel> context = GetContext())
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
                LogHelper.Error("BaseService-SqlQuery,类型： " + GetTableName(), e);
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
                using (DbSet<TModel> context = GetContext())
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
                LogHelper.Error("BaseService-SqlQuery,类型： " + GetTableName(), e);
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
        protected abstract object[] GetPrimaryKey(TModel entity);

        #endregion

        /// <summary>
        /// 根据主键获得实体
        /// </summary>
        /// <param name="gid"></param>
        /// <returns></returns>
        public virtual TModel Get(params object[] keyValues)
        {
            try
            {
                DbSet<TModel> context = GetContext();//解决缓存问题，所以new 
                return context.Set<TModel>().Find(keyValues);
            }
            catch (Exception e)
            {
                LogHelper.Error("BaseService-Find:" + GetTableName(), e);
                return null;
            }
            finally
            {
            }
        }

        protected virtual DbContext GetContext()
        {
            switch (EntitiesType)
            {
                case EntitiesType.NormalContext:
                    return new CSFramework3SystemContext();
                case EntitiesType.SystemContext:
                    return new CSFramework3NormalContext();
                default:
                    return null;
            }
        }
    }
    public enum EntitiesType
    {
        NormalContext,
        SystemContext
    }
    internal static class AttributeExtensions
    {
        public static TValue GetAttributeValue<TAttribute, TValue>(
            this Type type,
            Func<TAttribute, TValue> valueSelector)
            where TAttribute : Attribute
        {
            var att = type.GetCustomAttributes(
                typeof(TAttribute), true
            ).FirstOrDefault() as TAttribute;
            if (att != null)
            {
                return valueSelector(att);
            }
            return default(TValue);
        }
    }
}
