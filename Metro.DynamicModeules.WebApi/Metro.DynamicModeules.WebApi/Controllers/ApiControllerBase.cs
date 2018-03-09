using Metro.DynamicModeules.Common;
using Metro.DynamicModeules.Common.ExpressionSerialization;
using Metro.DynamicModeules.Interface.Service.Base;
using Metro.DynamicModeules.Service.Base;
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
    public class ApiControllerBase<TModel> : ApiController, IApiControllerBase<TModel> where TModel : class
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
        public object JsonHelper { get; private set; }

        protected virtual ServiceBase<TModel> GetService()
        {
            return new ServiceBase<TModel>();
        }

        [System.Web.Http.HttpPost]
        public object[] Add(TModel model, bool isSave = true)
        {
            return _service.Add(model, isSave);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.ActionName("Add1")]
        public bool Add(TModel[] paramList, bool isSave = true)
        {
            return _service.Add(paramList, isSave);
        }
        [System.Web.Http.HttpPost]
        public bool Delete(bool isSave, params object[] keyValues)
        {
            return _service.Delete(isSave, keyValues);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.ActionName("Delete1")]
        public bool Delete(bool isSave, TModel[] entities)
        {
            return _service.Delete(isSave, entities);
        }
        [System.Web.Http.ActionName("Delete2")]
        public bool Delete(TModel model, bool isSave = true)
        {
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
        public long GetListCount([FromBody]XElement xmlPredicate)
        {
            Expression<Func<TModel, bool>> where = SerializeHelper.DeserializeExpression<TModel, bool>(xmlPredicate);
            return _service.GetListCount(where);
        }

        [System.Web.Http.HttpPost]
        public TModel[] GetSearchListByPage<TKey>(XElement xmlPredicate, XElement xmlOrderBy, int pageSize, int pageIndex)//, out int totalRow)
        {                //将xml反序列化为linq
            Expression<Func<TModel, bool>> where = SerializeHelper.DeserializeExpression<TModel, bool>(xmlPredicate);
            Expression<Func<TModel, TKey>> orderBy = SerializeHelper.DeserializeExpression<TModel, TKey>(xmlOrderBy);
            return _service.GetSearchListByPage<TKey>(where, orderBy, pageSize, pageIndex);
        }
        [System.Web.Http.HttpPost]
        public bool Update(TModel model, bool isSave = true)
        {
            return _service.Update(model, isSave);
        }
        [System.Web.Http.HttpPost]
        public bool Update(XElement xmlPredicate, Dictionary<string, object> dic, bool isSave = true)
        {
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