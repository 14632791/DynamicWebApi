using System;
using System.Threading;

namespace Southernfund.UpdateSystem.Model.Util
{
    /**/
    /// <summary>  
    /// LogHelper的摘要说明。   
    /// </summary>   
    public class LogHelper 
    {
        private LogHelper()
        {
        }

        /// <summary>
        /// 静态只读实体对象info信息
        /// </summary>
        public static readonly log4net.ILog Loginfo = log4net.LogManager.GetLogger("loginfo");

        /// <summary>
        ///  静态只读实体对象error信息
        /// </summary>
        public static readonly log4net.ILog Logerror = log4net.LogManager.GetLogger("logerror");
        

        /// <summary>
        ///  添加info信息
        /// </summary>
        /// <param name="info"></param>
        public static void WriteLog(string info)
        {
            if (Loginfo.IsInfoEnabled)
            {
                Loginfo.Info(info);
            }
        }

        /// <summary>
        /// 添加异常信息
        /// </summary>
        /// <param name="info"></param>
        /// <param name="se"></param>
        public static void WriteLog(string info, Exception se)
        {
            if (Logerror.IsErrorEnabled)
            {
                Logerror.Error(info, se);
            }
        }
        public static void ErrorLog(string info, Exception ex)
        {
            //2016.5.11 陈刚 这里异步执行
            ThreadPool.QueueUserWorkItem(callback =>
            {
                string errorMsg = BeautyErrorMsg(ex);
                if (!string.IsNullOrEmpty(info) && ex == null)
                {
                    Logerror.ErrorFormat("【附加信息】 : {0}<br>", new object[] { info });
                }
                else if (!string.IsNullOrEmpty(info) && ex != null)
                {
                    Logerror.ErrorFormat("【附加信息】 : {0}<br>{1}", new object[] { info, errorMsg });
                }
                else if (string.IsNullOrEmpty(info) && ex != null)
                {
                    Logerror.Error(errorMsg);
                }
            });
        }
        /// <summary>
        /// 美化错误信息  sw
        /// </summary>
        /// <param name="ex">异常</param>
        /// <returns>错误信息</returns>
        private static string BeautyErrorMsg(Exception ex)
        {
            string errorMsg = string.Format("【异常类型】：{0} <br>【异常信息】：{1} <br>【堆栈调用】：{2}", new object[] { ex.GetType().Name, ex.Message, ex.StackTrace });
            errorMsg = errorMsg.Replace("\r\n", "<br>");
            errorMsg = errorMsg.Replace("位置", "<strong style=\"color:red\">位置</strong>");
            return errorMsg;
        }
    }
}