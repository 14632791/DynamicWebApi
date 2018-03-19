using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Southernfund.UpdateSystem.Model.Util
{
    public static class ConfigHelper
    {
        public static readonly string DefaultConfigPath = @"web.config";
        /// <summary>
        /// 获取指定config 文件中的 appsetting 节点值
        /// </summary>
        /// <param name="configPath">配置文件完整路径</param>
        /// <param name="key">节点名称</param>
        /// <returns></returns>
        public static string GetConfigString(string configPath, string key)
        {
            if (string.IsNullOrEmpty(configPath))
                throw new Exception("请检查应用程序配置文件 appSettings 节点，是否存在 indexConfig 且 value 不为空的配置节！");
            if (!File.Exists(configPath))
                throw new Exception(string.Format("配置文件不存在：{0}", configPath));
            ExeConfigurationFileMap ecf = new ExeConfigurationFileMap();
            ecf.ExeConfigFilename = configPath;
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(ecf, ConfigurationUserLevel.None);
            return config.AppSettings.Settings[key].Value;
        }
        public static string GetConnectionStrings(string key, string configPath = "")
        {
            if (string.IsNullOrEmpty(configPath))
            {
                configPath = DefaultConfigPath;
            }
            string result = string.Empty;
            try
            {
                if (string.IsNullOrEmpty(configPath))
                    throw new Exception("请检查应用程序配置文件 appSettings 节点，是否存在 indexConfig 且 value 不为空的配置节！");
                if (!File.Exists(configPath))
                    throw new Exception(string.Format("配置文件不存在：{0}", configPath));
                ExeConfigurationFileMap ecf = new ExeConfigurationFileMap();
                ecf.ExeConfigFilename = configPath;
                Configuration config = ConfigurationManager.OpenMappedExeConfiguration(ecf, ConfigurationUserLevel.None);
                result = config.ConnectionStrings.ConnectionStrings[key].ConnectionString;
            }
            catch (Exception ex)
            {
                LogHelper.ErrorLog("ConfigHelper-GetConnectionStrings", ex);
            }
            return result;
        }
        public static string GetConfigString(string str)
        {
            string result = string.Empty;
            try
            {
                result = System.Configuration.ConfigurationManager.AppSettings[str];
                //2016.3.10 增加备用方法
                if (string.IsNullOrEmpty(result))
                {
                    result = GetConfigString(DefaultConfigPath, str);
                }
            }
            catch (Exception ex)
            {
                LogHelper.ErrorLog("ConfigHelper-GetConfigString", ex);
            }
            return result;
        }
        public static void SetCongfig(string key, string value, string configPath = "")
        {
            try
            {
                if (string.IsNullOrEmpty(configPath))
                {
                    configPath = DefaultConfigPath.Replace(".config","");
                }
                Configuration config = ConfigurationManager.OpenExeConfiguration(configPath);

                if (config.AppSettings.Settings[key] != null)
                    config.AppSettings.Settings[key].Value = value;
                else
                    config.AppSettings.Settings.Add(key, value);
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
            catch (Exception ex)
            {
                LogHelper.ErrorLog("ConfigHelper-SetCongfig", ex);
            }
        }

        /// <summary>
        /// 默认异常返回0
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int GetConfigInt(string str)
        {
            int i = 0;
            try
            {
                i = Convert.ToInt32(GetConfigString(str));
            }
            catch (Exception ex)
            {
                LogHelper.ErrorLog("ConfigHelper-GetConfigInt", ex);
            }
            return i;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int GetConfigInt(string str, int pDefault)
        {
            // int i = 0;
            try
            {
                return int.Parse(System.Configuration.ConfigurationManager.AppSettings[str]);
            }
            catch (Exception ex)
            {
                LogHelper.ErrorLog("ConfigHelper-GetConfigInt(string str, int pDefault)", ex);
            }
            return pDefault;
        }
        /// <summary>
        /// 比较时间差 返回分钟
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static int GetTimeDiffMinutes(DateTime start, DateTime end)
        {
            int totalTime = 0;
            if (start != null && end != null)
            {
                TimeSpan diff = end - start;
                totalTime = (int)diff.TotalMinutes;
            }
            return totalTime;
        }
        /// 比较时间差 返回小时
        public static int GetTimeDiffHours(DateTime start, DateTime end)
        {
            int totalTime = 0;
            if (start != null && end != null)
            {
                TimeSpan diff = end - start;
                totalTime = (int)diff.TotalHours;
            }
            return totalTime;
        }

        /// <summary>
        /// 转换时间差为小时 分
        /// </summary>return hh.ToString() + "小时" + mm.ToString() + "分钟";            
        /// <param name="difftime"></param>
        /// <returns></returns>
        public static string GetHourAndMinute(int difftime)
        {
            if (difftime > 0)
            {
                int mm = difftime % 60;
                int hh = Convert.ToInt32((double)difftime / (double)60);
                return hh.ToString() + "小时" + mm.ToString() + "分钟";
                //return hh.ToString("D2") + ":" + mm.ToString("D2");
            }
            //return "00:00";
            return "0小时0分钟";
        }

       
        #region GetConfigAppSettingsValue 获取配置文件的AppSettings的值
        /// <summary>
        /// 获取配置文件的AppSettings的值
        /// </summary>
        /// <param name="key">配置name名称</param>
        /// <returns>配置value值</returns>
        public static string GetConfigAppSettingsValue(string key)
        {

            if (ConfigurationManager.AppSettings[key] != null)
            {
                return ConfigurationManager.AppSettings[key];
            }
            return "";
        }
        #endregion

    }
}
