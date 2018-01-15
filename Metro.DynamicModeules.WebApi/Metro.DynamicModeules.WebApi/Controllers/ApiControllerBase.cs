using Metro.DynamicModeules.Interface;
using Metro.DynamicModeules.Interface.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Linq.Expressions;
using System.Xml.Linq;
using Metro.DynamicModeules.Service.Base;
using System.IO;
using System.Text;
using System.Web.Http;

namespace Metro.DynamicModeules.WebApi.Controllers
{
    /// <summary>
    /// API控制器基类
    /// </summary>
    public abstract class ApiControllerBase<TModel> : ApiController, ICommonServiceBase<TModel> where TModel : class
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

        protected abstract ServiceBase<TModel> GetService();

        public object[] Add(TModel model, bool isSave = true)
        {
            return _service.Add(model, isSave);
        }

        public bool Add(IEnumerable<TModel> paramList, bool isSave = true)
        {
            return _service.Add(paramList, isSave);
        }

        public bool Delete(bool isSave, params object[] keyValues)
        {
            return _service.Delete(isSave, keyValues);
        }

        public bool Delete(bool isSave, IEnumerable<TModel> entities)
        {
            return _service.Delete(isSave, entities);
        }

        public bool Delete(TModel model, bool isSave = true)
        {
            return _service.Delete(model, isSave);
        }

        [System.Web.Mvc.HttpPut]
        public TModel Find( object[] keyValues)
        {
            return _service.Find(keyValues);
        }

        public IEnumerable<TModel> GetSearchList(XElement xmlPredicate)
        {
            return _service.GetSearchList(xmlPredicate);
        }

        public IEnumerable<TModel> GetSearchListByPage<TKey>(XElement xmlPredicate, XElement xmlOrderBy, int pageSize, int pageIndex, out int totalRow)
        {
            return _service.GetSearchListByPage<TKey>(xmlPredicate, xmlOrderBy, pageSize, pageIndex, out totalRow);
        }

        public bool Update(TModel model, bool isSave = true)
        {
            return _service.Update(model, isSave);
        }


        public bool Update(XElement xmlPredicate, Dictionary<string, object> dic, bool isSave = true)
        {
            return _service.Update(xmlPredicate, dic, isSave);
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
        //public Task<ApiResult> ApiAsync<TRequest, TResponse>(TRequest request, Func<TRequest, Task<TResponse>> handle) where TResponse : ResultObject
        //{
        //    return handle(request).ContinueWith(x =>
        //   {
        //       return Api(() => x.Result);
        //   });
        //}


        //#endregion
    }
}