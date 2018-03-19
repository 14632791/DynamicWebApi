using System;
using System.Text;

namespace TeYou.UpdateSystem.Model.Util
{
    public class RandomCode
    {
        /// <summary>
        /// 生成N位不重复随机数
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static string RandCode(int n)
        {
            var arrChar = new[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            var num = new StringBuilder();
            var rnd = new Random(Guid.NewGuid().GetHashCode());
            for (int i = 0; i < n; i++)
            {
                num.Append(arrChar[rnd.Next(0, arrChar.Length)].ToString());
            }
            return num.ToString();
        }
    }
}
