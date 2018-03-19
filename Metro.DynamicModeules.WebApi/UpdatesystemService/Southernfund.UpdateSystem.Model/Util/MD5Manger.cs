using System;
using System.Security.Cryptography;
using System.Text;

namespace Southernfund.UpdateSystem.Model.Util
{
    /// <summary>
    /// MD5散列加密  xwf  2012-11-12
    /// </summary>
    public class Md5Manger
    {
        /// <summary>
        /// MD5加密，不区分大小写的
        /// </summary>
        /// <param name="str">要加密的字符串</param>
        /// <param name="type">16位还是32位，16位就是取32位的第8到16位</param>
        /// <returns></returns>
        public static string Md5Encrypt(string str, Md5EncryptType type = Md5EncryptType.md532)
        {
            byte[] result = Encoding.UTF8.GetBytes(str);
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] output = md5.ComputeHash(result);
            return type == Md5EncryptType.md516 ? BitConverter.ToString(output).Replace("-", "").ToLower().Substring(8, 16) : BitConverter.ToString(output).Replace("-", "").ToLower();

        }

    }
    /// <summary>
    /// MD5加密的类型
    /// </summary>
    public enum Md5EncryptType
    {
        md516 = 0,//16位
        md532 = 1   //32位
    }

}
