using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Southernfund.UpdateSystem.DAL;
using Southernfund.UpdateSystem.IService;
using Southernfund.UpdateSystem.Model;
using Southernfund.UpdateSystem.Service.Base;
using Southernfund.UpdateSystem.Model.Util;

namespace Southernfund.UpdateSystem.Service
{
    public class ProjectsService : BaseService<ProjectsModel, UP_PROJECT, string>, IProjects
    {



        public List<ProjectsModel> GetList(ProjectsModel searchM, out int totalCount)
        {
            totalCount = 0;
            try
            {
                return GetSearchListByPage(t => !string.IsNullOrEmpty(t.name), t => t.id, searchM.PageSize, searchM.PagedIndex - 1, out totalCount).ToList();

            }
            catch
            {
            }
            return null;
        }

        public override bool Delete(string gid, bool isSave)
        {
            try
            {
                using (Entities db = new Entities())
                {
                    UP_PROJECT efModel = db.UP_PROJECT.Find(new object[] { gid });
                    db.UP_PROJECT.Remove(efModel);
                    if (isSave)
                    {
                        int iResult = db.SaveChanges();
                        return iResult > 0;
                    }
                    else return true;
                }
            }
            catch (Exception ex)
            {
                LogHelper.ErrorLog("ProjectsService.Delete", ex);
                return false;
            }
        }

        public ProjectsModel GetModel(string id)
        {
            return Get(id);

        }

        protected override string GetPrimaryKey(ProjectsModel entity)
        {
            return entity.ID;
        }

        public override UP_PROJECT ConvertToModel(ProjectsModel model)
        {
            return new UP_PROJECT
            {
                code = model.Code,
                description = model.Description,
                disable = model.Disable,
                downloadserverurl = model.DownloadServerURL,
                id = string.IsNullOrEmpty(model.ID) ? Guid.NewGuid().ToString("N") : model.ID,
                name = model.Name,
                remark = model.Remark,
                type = model.Type
            };
        }

        public override ProjectsModel ConvertToModel(UP_PROJECT EfModel)
        {
            return new ProjectsModel
            {
                Code = EfModel.code,
                Description = EfModel.description,
                Disable = EfModel.disable,
                DownloadServerURL = EfModel.downloadserverurl,
                ID = EfModel.id,
                Name = EfModel.name,
                Remark = EfModel.remark,
                Type = EfModel.type
            };
        }
    }
}
