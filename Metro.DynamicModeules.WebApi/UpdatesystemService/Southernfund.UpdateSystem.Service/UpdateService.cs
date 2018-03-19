using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Southernfund.UpdateSystem.DAL;
using Southernfund.UpdateSystem.IService;
using Southernfund.UpdateSystem.Model;
using Southernfund.UpdateSystem.Model.Util;
using Southernfund.UpdateSystem.Service.Base;
using System.Data.Entity;

namespace Southernfund.UpdateSystem.Service
{
    public class UpdateService : BaseService<UpdateModel, UP_UPDATE, string>, IUpdate
    {
        public List<UpdateModel> GetList(UpdateModel serach, out int totalCount)
        {
            totalCount = 0;
            try
            {
                return GetSearchListByPage(t => t.projectsid == serach.ProjectsID && t.type == serach.Type, t => t.createdon, serach.PageSize, serach.PagedIndex - 1, out totalCount).ToList();

            }
            catch
            {
            }
            return null;
        }

        public UpdateModel GetModel(string id)
        {
            return Get(id);
        }
        public string GetVersion(string pid, int clientType)
        {
            Entities db = new Entities();
            var model = db.UP_UPDATE.Where(t => t.projectsid == pid && t.type == clientType).OrderByDescending(t => t.createdon).FirstOrDefault();
            if (model != null)
            {
                return model.version;
            }
            return "0.0.1";
        }

        /// <summary>
        /// 获取是否强制信息，从客户端的版本算起，是否存在强制更新
        /// </summary>
        /// <param name="code"></param>
        /// <param name="clientType"></param>
        /// <param name="version"></param>
        /// <returns></returns>
        public bool GetMandatory(string code, int clientType, string version)
        {
            var list = GetSearchList(t => t.UP_PROJECT.code == code && t.type == clientType && t.mandatory == true);
            return list.Any(t => (new Version(t.Version)) > (new Version(version)));
            //db.UP_UPDATE.Where(t => t.UP_PROJECT.code == code && t.type == clientType && t.mandatory == true).ToList();
            //foreach (var item in list.Where(t =>(new Version(t.version)) > (new Version(version))))
            //{
            //    return true;
            //}
            //return false;
        }

        /// <summary>
        /// 回滚到上一个版本
        /// </summary>
        /// <param name="vison"></param>
        /// <param name="code"></param>
        /// <param name="type"></param>
        /// <returns>返回上一个版本的信息</returns>
        public UpdateModel RollBack(string version, string code, int type, out string msg)
        {
            msg = "";
            try
            {
                //找到该版本的数据及对应的下一条数据
                var list = GetSearchListByPageEf(t => t.UP_PROJECT.code == code && t.type == type && new Version(t.version) <= new Version(version), t => t.createdon, 2, 0).ToList();
                //如果数据只有一条则无法回滚
                if (list.Count() < 2)
                {
                    msg = "该版本是首次发布，无法回滚";
                    return null;
                }
                Delete(list[1].id);
                return ConvertToModel(list[0]);
            }
            catch (Exception ex)
            {
                LogHelper.ErrorLog("UpdateModel RollBack(string version, string code, int type,out string msg)方法", ex);
                msg = ex.Message;
                return null;
            }
        }

        public override bool Delete(string gid, bool isSave)
        {
            return base.Delete(gid, isSave);
        }

        public UpdateModel GetVersionModel(string code, int clientType)
        {
            Entities db = new Entities();
            var model = db.UP_UPDATE.Include("UP_PROJECT").Where(t => t.UP_PROJECT.code == code && t.type == clientType).OrderByDescending(t => t.createdon).FirstOrDefault();
            if (model != null)
            {
                return ConvertToModel(model);
            }
            return null;
        }

        protected override string GetPrimaryKey(UpdateModel entity)
        {
            return entity.ID;
        }

        public override UP_UPDATE ConvertToModel(UpdateModel model)
        {
            return new UP_UPDATE
            {
                id = string.IsNullOrEmpty(model.ID) ? Guid.NewGuid().ToString("N") : model.ID,
                version = model.Version,
                type = model.Type,
                downloadurl = model.DownloadURL,
                mandatory = model.Mandatory,
                projectsid = model.ProjectsID,
                remark = model.Remark,
                updatelog = model.UpdateLog,
                serverurl = model.ServerUrl,
                createdon = model.createdon
            };
        }

        public override UpdateModel ConvertToModel(UP_UPDATE EfModel)
        {
            return new UpdateModel
            {
                Version = EfModel.version,
                Type = EfModel.type,
                DownloadURL = EfModel.downloadurl,
                ID = EfModel.id,
                Mandatory = EfModel.mandatory,
                ProjectsID = EfModel.projectsid,
                Remark = EfModel.remark,
                UpdateLog = EfModel.updatelog,
                ServerUrl = EfModel.serverurl,
                createdon = EfModel.createdon
            };
        }


        public UpdateModel GetLatest(string projectsid)
        {
            try
            {
                Entities context = new Entities();//解决缓存问题，所以new 
                UP_UPDATE model = context.UP_UPDATE.OrderByDescending(u => u.createdon).First(u=>u.projectsid== projectsid);
                return ConvertToModel(model);
            }
            catch (Exception e)
            {
                LogHelper.ErrorLog("BaseService-GetSearchList,类型： " + GetTableName(), e);
                throw e;
            }
            finally
            {
                //Monitor.Exit(_objLock);
            }
        }
    }
}
