using Metro.DynamicModeules.Interface;
using Metro.DynamicModeules.Interface.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Linq.Expressions;
using System.Xml.Linq;
using Metro.DynamicModeules.Service.Base;

namespace Metro.DynamicModeules.WebApi.Controllers
{
    /// <summary>
    /// API控制器基类
    /// </summary>
    public class ApiControllerBase<TModel> : ApiController, ICommonServiceBase<TModel> where TModel:class
    {
        protected ServiceBase<TModel> _service;
        public ApiControllerBase(ServiceBase<TModel> service)
        {
            _service = service;
        }

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

        public TModel Get(params object[] keyValues)
        {
            return _service.Get(keyValues);
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
            return _service.Update(xmlPredicate,dic, isSave);
        }

        #region 默认封装
        public ApiResult Api<TRequest>(TRequest request, Func<TRequest, ResultObject> handle)
        {
            try
            {
                //var requestBase = request as IRequest;
                //if (requestBase != null)
                //{
                //    //处理需要登录用户的请求
                //    var userRequest = request as UserRequestBase;
                //    if (userRequest != null)
                //    {
                //        var loginUser = LoginUser.GetUser();
                //        if (loginUser != null)
                //        {
                //            userRequest.ApiUserID = loginUser.UserID;
                //            userRequest.ApiUserName = loginUser.UserName;
                //        }
                //    }
                //    var validResult = requestBase.Validate();
                //    if (validResult != null)
                //    {
                //        return new ApiResult(validResult);
                //    }
                //}
                var result = handle(request); //处理请求
                return new ApiResult(result);
            }
            catch (Exception exp)
            {
                //异常日志：
                return new ApiResult { ResultData = new ResultObject { Code = 1, Msg = "系统异常：" + exp.Message } };
            }
        }

        public ApiResult Api(Func<ResultObject> handle)
        {
            try
            {
                var result = handle();//处理请求
                return new ApiResult(result);
            }
            catch (Exception exp)
            {
                //异常日志
                return new ApiResult { ResultData = new ResultObject { Code = 1, Msg = "系统异常：" + exp.Message } };
            }
        }

        /// <summary>
        /// 异步api
        /// </summary>
        /// <typeparam name="TRequest"></typeparam>
        /// <param name="request"></param>
        /// <param name="handle"></param>
        /// <returns></returns>
        public Task<ApiResult> ApiAsync<TRequest, TResponse>(TRequest request, Func<TRequest, Task<TResponse>> handle) where TResponse : ResultObject
        {
            return  handle(request).ContinueWith(x =>
            {
                return Api(() => x.Result);
            });
        }


        #endregion
    }
}