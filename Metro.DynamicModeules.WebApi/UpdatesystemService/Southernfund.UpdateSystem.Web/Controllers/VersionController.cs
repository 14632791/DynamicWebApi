using Metro.DynamicModeules.Models.Update;
using Metro.DynamicModeules.Service.Update;
using System;
using System.Web.Http;
using UpdateSystem.Web.Models;

namespace UpdateSystem.Web.APIControllers
{
    public class VersionController : ApiController
    {
        UpdateService _updateSvc = new UpdateService();
        public bool NeedUpdate(string pcode, int cType, string version)
        {
            try
            {
                tb_Update uModel = _updateSvc.GetSearchList(u => u.updateType == cType && u.projectCode == pcode)[0];//.GetVersionModel(pcode, cType);
                Version serverVersion = new Version(version);
                Version cVersion = new Version(uModel.version);
                return cVersion < serverVersion;
            }
            catch
            {
                return false;
            }
        }
        public UpdateInfo GetVersion(string pcode, int cType, string version)
        {
            UpdateInfo info = new UpdateInfo { NeedUpdate = false, Version = version, FileDownloadURL = "", Mandatory = false, Description = "无" };
            try
            {
                tb_Update uModel = _updateSvc.GetSearchList(u => u.projectCode == pcode && u.updateType == cType)[0];//GetVersionModel(pcode, cType);
                if (uModel == null)
                {
                    return null;
                }
                Version cVersion = new Version(version);
                Version serverVersion = new Version(uModel.version);
                if (cVersion < serverVersion)
                {
                    string websiteUrl = System.Configuration.ConfigurationManager.AppSettings["WebSiteURL"];
                    info.NeedUpdate = true;
                    info.Version = uModel.version;
                    info.Mandatory = _updateSvc.GetSearchList(u => u.projectCode == pcode && u.updateType == cType && u.version == version)[0].mandatory.Value;
                        //GetMandatory(pcode, cType, version);
                    info.Description = uModel.updatelog;
                    string typePath = ((UpdateType)cType).ToString();
                    info.FileDownloadURL = string.Format(@"{0}/UpdateFiles/{1}/{2}/", websiteUrl, pcode, typePath);
                    info.XmlDownloadURL = string.Format(@"{0}/XMLFiles/{1}/{2}/ProgrameList.XML", websiteUrl, pcode, typePath);
                    info.FileDownloadPartURL = string.Format(@"UpdateFiles/{0}/{1}/", pcode, typePath);
                    info.XmlDownloadPartURL = string.Format(@"XMLFiles/{0}/{1}/ProgrameList.XML", pcode, typePath);
                }
            }
            catch
            {
            }
            return info;
        }

        public void Post([FromBody]string value)
        {
        }

        public void Put(int id, [FromBody]string value)
        {
        }

        public void Delete(int id)
        {
        }
    }
}
