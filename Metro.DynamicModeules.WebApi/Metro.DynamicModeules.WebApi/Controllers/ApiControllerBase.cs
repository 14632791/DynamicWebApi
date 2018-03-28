using Metro.DynamicModeules.Common;
using Metro.DynamicModeules.Common.ExpressionSerialization;
using Metro.DynamicModeules.Interface.Service.Base;
using Metro.DynamicModeules.Service.Base;
using Metro.DynamicModeules.WebApi.Filter;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using System.Xml.Linq;

namespace Metro.DynamicModeules.WebApi.Controllers
{
    /// <summary>
    /// API控制器基类
    /// </summary>
    [CustomException]
    public abstract class ApiControllerBase<TModel> : ApiController where TModel : class  //, IApiControllerBase<TModel>
    {
        #region 私有方法
        /// <summary>
        /// 获取请求字符串
        /// </summary>
        /// <returns>请求输入的字符串</returns>
        private string GetInputStr()
        {
            string str = string.Empty;
            //Request.InputStream.Position = 0;
            //StreamReader sr = new StreamReader(Request.InputStream, Encoding.UTF8);
            //{
            //    str = sr.ReadToEnd();
            //}
            return str;
        }
        protected ServiceBase<TModel> _service;

        #endregion
        public ApiControllerBase()
        {
            _service = GetService();
        }
        #region 实现service的方法
        //public object JsonHelper { get; private set; }

        protected virtual ServiceBase<TModel> GetService()
        {
            return new ServiceBase<TModel>();
        }

        [System.Web.Http.HttpPost]
        public object[] Add(dynamic dyncObj)
        {
            bool isSave = Convert.ToBoolean(dyncObj.isSave);
            TModel model = JsonHelper.JsonDe<TModel>(Convert.ToString(dyncObj.model));
            return _service.Add(model, isSave);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.ActionName("Add1")]
        public bool Add1(dynamic dyncObj)
        {
            bool isSave = Convert.ToBoolean(dyncObj.isSave);
            TModel[] paramList = JsonHelper.JsonDe<TModel[]>(Convert.ToString(dyncObj.paramList));
            return _service.Add(paramList, isSave);
        }
        [System.Web.Http.HttpPost]
        public bool Delete(dynamic dyncObj)
        {
            bool isSave = Convert.ToBoolean(dyncObj.isSave);
            object[] keyValues = JsonHelper.JsonDe<object[]>(Convert.ToString(dyncObj.keyValues));
            return _service.Delete(isSave, keyValues);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.ActionName("Delete1")]
        public bool Delete1(dynamic dyncObj)
        {
            bool isSave = Convert.ToBoolean(dyncObj.isSave);
            TModel[] entities = JsonHelper.JsonDe<TModel[]>(Convert.ToString(dyncObj.entities));
            return _service.Delete(isSave, entities);
        }
        [System.Web.Http.ActionName("Delete2")]
        public bool Delete2(dynamic dyncObj)
        {
            TModel model = JsonHelper.JsonDe<TModel>(Convert.ToString(dyncObj.model));
            bool isSave = Convert.ToBoolean(dyncObj.isSave);
            return _service.Delete(model, isSave);
        }

        [System.Web.Http.HttpPost]
        public virtual TModel Find(object[] keyValues)
        {
            return _service.Find(keyValues);
        }
        [System.Web.Http.HttpPost]
        public TModel[] GetSearchList(XElement xmlPredicate)
        {
            Expression<Func<TModel, bool>> where = SerializeHelper.DeserializeExpression<TModel, bool>(xmlPredicate);
            var predicate = SerializeHelper.DeserializeExpression<TModel, bool>(xmlPredicate);
            return _service.GetSearchList(where);
        }

        [System.Web.Http.HttpPost]
        public long GetListCount(XElement xmlPredicate)
        {
            Expression<Func<TModel, bool>> where = SerializeHelper.DeserializeExpression<TModel, bool>(xmlPredicate);
            return _service.GetListCount(where);
        }

        [System.Web.Http.HttpPost]
        public TModel[] GetSearchListByPage(dynamic dyncObj)
        {
            XElement xmlPredicate = JsonHelper.JsonDe<XElement>(Convert.ToString(dyncObj.xmlPredicate));
            int pageSize = Convert.ToInt32(dyncObj.pageSize);
            int pageIndex = (int)Convert.ToInt32(dyncObj.pageIndex);
            Expression<Func<TModel, bool>> where = SerializeHelper.DeserializeExpression<TModel, bool>(xmlPredicate);
            dynamic orderBy = GetOrderBy();
            return _service.GetSearchListByPage(where, orderBy, pageSize, pageIndex);
        }
        protected abstract dynamic GetOrderBy();

        [System.Web.Http.HttpPost]
        public bool Update(dynamic dyncObj)
        {
            TModel model = JsonHelper.JsonDe<TModel>(Convert.ToString(dyncObj.model));
            bool isSave = Convert.ToBoolean(dyncObj.isSave);
            return _service.Update(model, isSave);
        }
        [System.Web.Http.HttpPost]
        public bool Update2(dynamic dyncObj)
        {
            XElement xmlPredicate = JsonHelper.JsonDe<XElement>(Convert.ToString(dyncObj.xmlPredicate));
            Dictionary<string, object> dic = JsonHelper.JsonDe<Dictionary<string, object>>(Convert.ToString(dyncObj.dic));
            bool isSave = Convert.ToBoolean(dyncObj.isSave);
            Expression<Func<TModel, bool>> where = SerializeHelper.DeserializeExpression<TModel, bool>(xmlPredicate);
            return _service.Update(where, dic, isSave);
        }


        #endregion

        //#region 默认封装
        //public ApiResult Api<TRequest>(TRequest request, Func<TRequest, ResultObject> handle)
        //{
        //    try
        //    {
        //        //var requestBase = request as IRequest;
        //        //if (requestBase != null)
        //        //{
        //        //    //处理需要登录用户的请求
        //        //    var userRequest = request as UserRequestBase;
        //        //    if (userRequest != null)
        //        //    {
        //        //        var loginUser = LoginUser.GetUser();
        //        //        if (loginUser != null)
        //        //        {
        //        //            userRequest.ApiUserID = loginUser.UserID;
        //        //            userRequest.ApiUserName = loginUser.UserName;
        //        //        }
        //        //    }
        //        //    var validResult = requestBase.Validate();
        //        //    if (validResult != null)
        //        //    {
        //        //        return new ApiResult(validResult);
        //        //    }
        //        //}
        //        var result = handle(request); //处理请求
        //        return new ApiResult(result);
        //    }
        //    catch (Exception exp)
        //    {
        //        //异常日志：
        //        return new ApiResult { ResultData = new ResultObject { Code = 1, Msg = "系统异常：" + exp.Message } };
        //    }
        //}

        //public ApiResult Api(Func<ResultObject> handle)
        //{
        //    try
        //    {
        //        var result = handle();//处理请求
        //        return new ApiResult(result);
        //    }
        //    catch (Exception exp)
        //    {
        //        //异常日志
        //        return new ApiResult { ResultData = new ResultObject { Code = 1, Msg = "系统异常：" + exp.Message } };
        //    }
        //}

        ///// <summary>
        ///// 异步api
        ///// </summary>
        ///// <typeparam name="TRequest"></typeparam>
        ///// <param name="request"></param>
        ///// <param name="handle"></param>
        ///// <returns></returns>
        //public ApiResult> ApiAsync<TRequest, TResponse>(TRequest request, Func<TRequest, TResponse>> handle) where TResponse : ResultObject
        //{
        //    return handle(request).ContinueWith(x =>
        //   {
        //       return Api(() => x.Result);
        //   });
        //}


        //#endregion
    }
}