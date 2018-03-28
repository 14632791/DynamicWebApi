using Metro.DynamicModeules.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Metro.DynamicModeules.Service.Base;
using Metro.DynamicModeules.Service;
using System.Threading.Tasks;
using System.Xml.Linq;
using Metro.DynamicModeules.Common.ExpressionSerialization;
using System.Linq.Expressions;
using System.Threading;
using Metro.DynamicModeules.Models.Sys;

namespace Metro.DynamicModeules.WebApi.Controllers.Sys
{
    public class MyUserController : ApiControllerBase<tb_MyUser>
    { 
        protected override ServiceBase<tb_MyUser> GetService()
        {
            return new MyUserService();
        }
        [System.Web.Http.HttpPost]
        public tb_MyUser[] SearchList(XElement xmlPredicate)
        {
            Expression<Func<tb_MyUser, bool>> where = SerializeHelper.DeserializeExpression<tb_MyUser, bool>(xmlPredicate);
            var predicate = SerializeHelper.DeserializeExpression<tb_MyUser, bool>(xmlPredicate);
            var list=  ((MyUserService)_service).SearchList(where);
            return list;
        }

        [HttpGet]
        public async Task<string> Get()
        {
            var info = string.Format("api执行线程:{0}", Thread.CurrentThread.ManagedThreadId);
            var infoTask = await TaskCaller();
            var infoTaskFinished = string.Format("api执行线程（task调用完成后）:{0}", Thread.CurrentThread.ManagedThreadId);
            return string.Format("{0},{1},{2}", info, infoTask, infoTaskFinished);
        }

        private async Task<string> TaskCaller()
        {
            await Task.Delay(500);
            return string.Format("task 执行线程:{0}", Thread.CurrentThread.ManagedThreadId);
        }
        [System.Web.Http.HttpPost]
        //public override tb_MyUser[] GetSearchListByPage([FromBody]XElement xmlPredicate, int pageSize, int pageIndex)
        //{
        //    Expression<Func<tb_MyUser, bool>> where = SerializeHelper.DeserializeExpression<tb_MyUser, bool>(xmlPredicate);
        //    return _service.GetSearchListByPage(where, g => g.CreateTime, pageSize, pageIndex);
        //}

        protected override dynamic GetOrderBy()
        {
            Expression<Func<tb_MyUser, DateTime?>> orderBy = g => g.CreatedTime;
            return orderBy;
        }
    }
}