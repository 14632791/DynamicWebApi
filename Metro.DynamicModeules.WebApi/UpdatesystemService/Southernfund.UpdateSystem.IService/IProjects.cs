using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Southernfund.UpdateSystem.Model;
using Southernfund.UpdateSystem.IService.Base;

namespace Southernfund.UpdateSystem.IService
{
    public interface IProjects : IBaseService<ProjectsModel, string>
    {
        List<ProjectsModel> GetList(ProjectsModel serach, out int totalCount);
        ProjectsModel GetModel(string id);
    }
}
