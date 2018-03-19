using Common;
using Common.Hash;
using Microsoft.Practices.Unity;
using PagedList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using UpdateSystem.IService;
using UpdateSystem.Model;
using UpdateSystem.Model.Util;
using UpdateSystem.Web.Common;
using System.Threading;
using UpdateSystem.Service;
using XH.UpdateSystem.Web.Common;
using System.Threading.Tasks;

namespace UpdateSystem.Web.Controllers
{
    [Authority]
    public class UpdateController : Controller
    {
        [Dependency]
        public IUpdate US { get; set; }
        [Dependency]
        public IProjects UP { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">ProjectsID</param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public ActionResult Index(string id, int type = 0, int pageIndex = 1)
        {
            if (string.IsNullOrEmpty(id))
            {
                return View();
            }
            int pageSize = 10;
            int totalCount;
            var list = US.GetList(new UpdateModel { PagedIndex = pageIndex, PageSize = pageSize, ProjectsID = id, Type = type }, out totalCount);
            ViewBag.ProjectsID = id;
            ViewBag.type = type;
            //获取项目名称 2017.7.7 陈刚
            ViewBag.AddProjectName = "添加-" + UP.Get(id)?.Name;
            if (list != null)
            {
                var pageList = new StaticPagedList<UpdateModel>(list, pageIndex, pageSize, totalCount);
                return View(pageList);
            }
            return View();
        }



        [HttpPost]
        public ActionResult Save(UpdateModel form, HttpPostedFileBase UpdateFile)
        {
            string msg = "";
            try
            {
                if (!ModelState.IsValid || UpdateFile == null)
                {
                    return RtnMsg("验证未通过！");
                }
                var pModel = UP.GetModel(form.ProjectsID);
                if (pModel == null)
                {
                    return RtnMsg("无法找到项目！");
                }
                form.ID = Guid.NewGuid().ToString("N");
                Version curVersion;
                Version newVersion;
                try
                {
                    curVersion = new Version(US.GetVersion(pModel.ID, (int)form.Type));
                    newVersion = new Version(form.Version);
                }
                catch (Exception ex)
                {
                    return RtnMsg(ex.Message);
                }
                if (curVersion >= newVersion)
                {
                    msg = "最新版本号低于或等于当前版本！";
                    return RtnMsg(msg);
                }
                string filePath = "";
                string dir = ((UpdateType)form.Type).ToString();
                string strUploadFilesDirPath = "/UploadFiles/" + dir + "/";
                string strCodeTypePath = pModel.Code + "/" + dir;
                string strPhysicsUnzipDirPath = Server.MapPath("/UpdateFiles/" + strCodeTypePath); //解压文件的保存目录

                bool isSaveFile = false;
                Task.WaitAll(new Task[2] {
                    Task.Factory.StartNew(()=>{
                isSaveFile=SaveFile(UpdateFile, strUploadFilesDirPath, out filePath, out msg);}),
                    Task.Factory.StartNew(()=>{
                         string backupZipDir = Server.MapPath(string.Format("/BackupFiles/{0}/before_{1}.zip", strCodeTypePath, form.Version));
                        HandleZip(strPhysicsUnzipDirPath, backupZipDir);
                    })
                });
                if (!isSaveFile)
                {
                    return RtnMsg(msg);
                }
                form.DownloadURL = filePath;
                if (!HandleUnZip(filePath, strCodeTypePath, out strPhysicsUnzipDirPath))
                    return RtnMsg("解压处理失败！");

                //更新客户端UpdateConfig.XML
                string strClientUpdateConfigPath = strPhysicsUnzipDirPath + "UpdateConfig.XML";//UpdateConfig.XML文件理论上应该分为32/64等不周的四个版本
                if (!System.IO.File.Exists(strClientUpdateConfigPath))
                {
                    new FileInfo(Server.MapPath("/UpdateFiles/") + "UpdateConfig.xml").CopyTo(strClientUpdateConfigPath);
                }
                XmlDocument xdClientUpdateConfig = new XmlDocument();
                xdClientUpdateConfig.Load(strClientUpdateConfigPath);
                xdClientUpdateConfig.SelectSingleNode("UpdateInfo/CurrentVersion").InnerText = form.Version;
                xdClientUpdateConfig.SelectSingleNode("UpdateInfo/type").InnerText = form.Type.ToString();
                xdClientUpdateConfig.SelectSingleNode("UpdateInfo/code").InnerText = pModel.Code;
                xdClientUpdateConfig.Save(strClientUpdateConfigPath);
                //获取所有文件HASHMD5值
                XmlDocument xdNewFileList = GetProgrameHASHValue(strPhysicsUnzipDirPath);
                string strXMLSavePath = Server.MapPath("/XMLFiles/" + strCodeTypePath + "/");
                if (!Directory.Exists(strXMLSavePath))
                {
                    Directory.CreateDirectory(strXMLSavePath);
                }
                form.createdon = DateTime.Now;
                xdNewFileList.Save(strXMLSavePath + "ProgrameList.XML");
                bool isAdd = US.Add(form);
                string resultMsg = "新增成功！";
                if (isAdd)
                {
                    //备份当前版本的文件 2017.6.26 陈刚
                    //ThreadPool.QueueUserWorkItem(callBack =>
                    //{ 
                    //    string backupZipDir = Server.MapPath(string.Format("/BackupFiles/{0}/{1}.zip", strCodeTypePath, form.Version));
                    //    HandleZip(strPhysicsUnzipDirPath, backupZipDir);
                    //});
                }
                else
                {
                    resultMsg = "新增失败！";
                }
                return RtnMsg(resultMsg);
                //}
                //else
                //{
                //    return RtnMsg("验证未通过！");
                //}

            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("保存异常：", ex);
                return RtnMsg("保存异常：" + ex.Message);
            }

        }



        /// <summary>
        /// 压缩文件
        /// </summary>
        /// <param name="physicsPath">备份原路径</param>
        /// <param name="backupZipPath">压缩后的路径</param>
        private void HandleZip(string physicsPath, string backupZipPath)
        {
            try
            {  //检查是否存在目的目录  
                string directoryTarget = Path.GetDirectoryName(backupZipPath);
                if (!Directory.Exists(directoryTarget))
                {
                    Directory.CreateDirectory(directoryTarget);
                }
                FilesHelper fileHelper = new FilesHelper();
                List<FileInfo> files = fileHelper.GetAllFilesInDirectory(physicsPath);
                if (null != files)
                {
                    ZipTools.GetCompressPath(backupZipPath, files.Select(f => f.FullName).ToList(), physicsPath);
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("压缩文件异常：", ex);
            }
        }
        /// <summary>
        /// 解压文件
        /// </summary>
        /// <param name="zipFileRelativePath"></param>
        /// <param name="projectCode"></param>
        /// <param name="strUnzipPath"></param>
        /// <returns></returns>
        private bool HandleUnZip(string zipFileRelativePath, string projectCode, out string strUnzipPath)
        {
            //解压ZIP
            strUnzipPath = Server.MapPath("/UpdateFiles/" + projectCode + "/");
            if (!System.IO.Directory.Exists(strUnzipPath))
            {
                System.IO.Directory.CreateDirectory(strUnzipPath);
            }
            //UnZipClass uzzip = new UnZipClass();
            try
            {
                var zipFilePath = Path.Combine(Server.MapPath(zipFileRelativePath));
                ZipHelper.UnZip(zipFilePath, strUnzipPath);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        XmlDocument xdUpdateInfoTemp;

        private XmlDocument GetProgrameHASHValue(string strPhysicsUnzipDirPath)
        {
            xdUpdateInfoTemp = new XmlDocument();
            XmlElement xe = xdUpdateInfoTemp.CreateElement("FileList");
            SearchPrograme("", strPhysicsUnzipDirPath, xe);
            xdUpdateInfoTemp.AppendChild(xe);
            return xdUpdateInfoTemp;
        }

        private void SearchPrograme(string strDirStructure, string strPhysicsDirRoot, XmlElement xeFileList)
        {
            string strPath = strPhysicsDirRoot + strDirStructure;
            if (!Directory.Exists(strPath) || strDirStructure.IndexOf("DBScript") >= 0) return;
            string[] strDirList = Directory.GetDirectories(strPath, "*", System.IO.SearchOption.AllDirectories);
            string[] strFileList = Directory.GetFiles(strPath);
            for (int i = 0; i < strDirList.Length; i++)
            {
                string strDirName = strDirList[i].Substring(strDirList[i].LastIndexOf("\\"));//Path.GetDirectoryName(strDirList[i]);
                SearchPrograme(strDirStructure + strDirName + "\\", strPhysicsDirRoot, xeFileList);
            }
            foreach (string strFilePath in strFileList)
            {
                XmlElement xeFile = xdUpdateInfoTemp.CreateElement("File");
                xeFile.SetAttribute("HashMD5", HashHelper.ComputeMD5(strFilePath));
                xeFile.SetAttribute("Directory", strDirStructure);
                xeFile.SetAttribute("Name", Path.GetFileName(strFilePath));
                xeFileList.AppendChild(xeFile);
            }
        }

        public ActionResult RtnMsg(string msg)
        {
            ViewData["msg"] = msg;
            return View("~/Views/shared/_msg.cshtml");
        }

        public ActionResult Delete(string id)
        {
            try
            {
                ViewData["msg"] = US.Delete(id) ? "删除成功！" : "删除失败！";
                return View("~/Views/shared/_msg.cshtml");
            }
            catch
            {
                ViewData["msg"] = "删除异常";
                return View("~/Views/shared/_msg.cshtml");
            }
        }

        public ActionResult Create(string id = "")
        {
            UpdateModel m = new UpdateModel();
            var model = US.GetLatest(id);
            if (null != model)
            {
                Version curVersion = new Version(model.Version);
                Version newVersion = new Version(curVersion.Major, curVersion.Minor, curVersion.Build, curVersion.Revision + 1);
                m.Version = newVersion.ToString();//赋默认值
            }
            if (!string.IsNullOrEmpty(id))
            {
                m.ProjectsID = id;
                return View(m);
            }
            else
            {
                return HttpNotFound();
            }
        }

        /// <summary>
        /// 回滚到上一个版本
        /// </summary>
        /// <param name="vision"></param>
        /// <param name="code"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public ActionResult RollBack(string vision, string code, int type)
        {
            try
            {
                UpdateService upSvc = US as UpdateService;
                string resultMsg;
                UpdateModel result = upSvc.RollBack(vision, code, type, out resultMsg);
                //if (null == result)
                //{
                ViewData["msg"] = resultMsg;
                return View("~/Views/shared/_msg.cshtml");
            }
            catch
            {
                ViewData["msg"] = "回滚异常";
                return View("~/Views/shared/_msg.cshtml");
            }
        }

        private bool SaveFile(HttpPostedFileBase file, string strSaveDirPath, out string filePath, out string msg)
        {
            msg = "";
            filePath = "";
            try
            {
                if (file == null && file.ContentLength <= 0)
                {
                    msg = "请上传更新文件ZIP压缩包！";
                    return false;
                }
                if (Path.GetExtension(file.FileName) != ".zip")
                {
                    msg = "更新包的压缩文件格式必须是ZIP文件格式！";
                    return false;
                }
                var fileName = Path.GetFileName(file.FileName);
                fileName = DateTime.Now.ToString("yyyyMMddhhmmssfff") + fileName;
                var path = Path.Combine(Server.MapPath(strSaveDirPath), fileName);
                var dir = Server.MapPath(strSaveDirPath);
                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);
                if (System.IO.File.Exists(path))
                    System.IO.File.Delete(path);
                file.SaveAs(path);
                filePath = Path.Combine(strSaveDirPath, fileName);
                msg = "保存成功！";
                return true;
            }
            catch (Exception ex)
            {
                msg = "保存异常：" + ex.ToString();
                return false;
            }
        }

        private bool SaveAnyFile(HttpPostedFileBase file, string strSaveDirPath, out string filePath, out string msg)
        {
            msg = "";
            filePath = "";
            try
            {
                if (file == null && file.ContentLength <= 0)
                {
                    msg = "请上传更新文件！";
                    return false;
                }
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath(strSaveDirPath), fileName);
                var dir = Server.MapPath(strSaveDirPath);
                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);
                if (System.IO.File.Exists(path))
                    System.IO.File.Delete(path);
                file.SaveAs(path);
                filePath = Path.Combine(strSaveDirPath, fileName);
                msg = "保存成功！";
                return true;
            }
            catch (Exception ex)
            {
                msg = "保存异常：" + ex.ToString();
                return false;
            }
        }

    }
}
