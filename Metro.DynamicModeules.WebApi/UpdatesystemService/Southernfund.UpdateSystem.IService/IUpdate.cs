using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Southernfund.UpdateSystem.Model;
using Southernfund.UpdateSystem.IService.Base;

namespace Southernfund.UpdateSystem.IService
{
    public interface IUpdate : IBaseService<UpdateModel, string>
    {
        List<UpdateModel> GetList(UpdateModel serach, out int totalCount);
        UpdateModel GetModel(string id);
        string GetVersion(string pid,int clientType);
        UpdateModel GetVersionModel(string code, int clientType);

        /// <summary>
        /// 获取最新的一条数据
        /// </summary>
        /// <returns></returns>
        UpdateModel GetLatest(string projectsid);
    }
}
