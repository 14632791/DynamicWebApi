﻿
///*************************************************************************/
///*
///* 文件名    ：BllBase.cs                                      
///* 程序说明  : 业务逻辑层基类
///* 原创作者  ：陈刚
///* 
///* Copyright 2015 Metro.DynamicModeules software
///**************************************************************************/
using Metro.DynamicModeules.BLL.Security;
using Metro.DynamicModeules.Common;
using Metro.DynamicModeules.Interface.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Metro.DynamicModeules.BLL.Base
{
    /// <summary>
    /// 业务逻辑层基类
    /// </summary>
    public class BllBase<T> : IServiceBase<T> where T : class
    {

        string _controllerName;
        protected string ControllerName
        {
            get
            {
                if (string.IsNullOrEmpty(_controllerName))
                {
                    Type type = typeof(T);
                    _controllerName = type.Name;
                }
                return _controllerName;
            }
        }
        private string GetApiUrl(string methodName)
        {
            return string.Format("{0}/{1}/{2}", GlobalData.WEBURL, ControllerName, methodName);
        }
        public async Task<object[]> Add(T model, bool isSave = true)
        {
            var apiParams = new { model, isSave };
            return await WebRequestHelper.PostHttpAsync<object[]>(GetApiUrl("Add"), apiParams);
        }

        public async Task<bool> Add(IEnumerable<T> paramList, bool isSave = true)
        {
            var apiParams = new { paramList, isSave };
            return await WebRequestHelper.PostHttpAsync<bool>(GetApiUrl("Add"), apiParams);
        }

        public async Task<bool> Delete(bool isSave, object[] keyValues)
        {
            var apiParams = new { isSave, keyValues };
            return await WebRequestHelper.PostHttpAsync<bool>(GetApiUrl("Delete"), apiParams);
        }

        public async Task<bool> Delete(bool isSave, IEnumerable<T> entities)
        {
            var apiParams = new { isSave, entities };
            return await WebRequestHelper.PostHttpAsync<bool>(GetApiUrl("Delete"), apiParams);
        }

        public async Task<bool> Delete(T model, bool isSave = true)
        {
            var apiParams = new { model, isSave };
            return await WebRequestHelper.PostHttpAsync<bool>(GetApiUrl("Delete"), apiParams);
        }

        public async Task<T> Find(object[] keyValues)
        {
            return await WebRequestHelper.PostHttpAsync<T>(GetApiUrl("Find"), keyValues);
        }

        public async Task<List<T>> GetSearchList(Expression<Func<T, bool>> where)
        {
            XElement xmlPredicate = SerializeHelper.SerializeExpression(where);
            return await WebRequestHelper.PostHttpAsync<List<T>>(GetApiUrl("GetSearchList"), xmlPredicate);
        }
        public async Task<long> GetListCount(Expression<Func<T, bool>> where)
        {
            XElement xmlPredicate = SerializeHelper.SerializeExpression(where);
            return await WebRequestHelper.PostHttpAsync<long>(GetApiUrl("GetListCount"), xmlPredicate);
        }
        public async Task<List<T>> GetSearchListByPage<TKey>(Expression<Func<T, bool>> where, Expression<Func<T, TKey>> orderBy, int pageSize, int pageIndex)
        {
            XElement xmlPredicate = SerializeHelper.SerializeExpression(where);
            XElement xmlOrderBy = SerializeHelper.SerializeExpression(orderBy);
            var apiParams = new { xmlPredicate, xmlOrderBy, pageSize, pageIndex };
            return await WebRequestHelper.PostHttpAsync<List<T>>(GetApiUrl("GetSearchListByPage"), apiParams);
        }

        public async Task<bool> Update(Expression<Func<T, bool>> where, Dictionary<string, object> dic, bool isSave = true)
        {
            XElement xmlPredicate = SerializeHelper.SerializeExpression(where);
            var apiParams = new { xmlPredicate, dic, isSave };
            return await WebRequestHelper.PostHttpAsync<bool>(GetApiUrl("Update"), apiParams);
        }

        public async Task<bool> Update(T model, bool isSave = true)
        {
            var apiParams = new { model, isSave };
            return await WebRequestHelper.PostHttpAsync<bool>(GetApiUrl("Update"), apiParams);
        }

        Task<bool> IServiceBase<T>.Commit(bool isSave)
        {
            throw new NotImplementedException();
        }


    }
}
