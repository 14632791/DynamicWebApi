using Metro.DynamicModeules.Common;
using Metro.DynamicModeules.Interface.Service.Update;
using Metro.DynamicModeules.Models.Update;
using Metro.DynamicModeules.Service.Base;
using System;

namespace Metro.DynamicModeules.Service.Update
{
    public class UpdateService : ServiceBase<tb_Update>, IUpdate
    {
        /// <summary>
        /// 回滚到上一个版本
        /// </summary>
        /// <param name="vison"></param>
        /// <param name="code"></param>
        /// <param name="type"></param>
        /// <returns>返回上一个版本的信息</returns>
        public tb_Update RollBack(string version, string code, int type, out string msg)
        {
            msg = "";
            try
            {
                //找到该版本的数据及对应的下一条数据
                var list = GetSearchListByPage(t => t.projectCode == code && t.updateType == type && new Version(t.version) <= new Version(version), t => t.createdon, 2, 0);
                //如果数据只有一条则无法回滚
                if (list.Length < 2)
                {
                    msg = "该版本是首次发布，无法回滚";
                    return null;
                }
                Delete(true,new object[] { list[1].id });
                return list[0];
            }
            catch (Exception ex)
            {
                LogHelper.Error("UpdateModel RollBack(string version, string code, int type,out string msg)方法", ex);
                msg = ex.Message;
                return null;
            }
        }

    }
}
