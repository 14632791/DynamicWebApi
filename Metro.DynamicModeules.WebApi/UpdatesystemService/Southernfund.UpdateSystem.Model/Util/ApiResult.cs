namespace TeYou.UpdateSystem.Model.Util
{
    /// <summary>
    /// 客户端通用结果集
    /// </summary>
    public class ApiResult
    {
        public ApiResult() 
        {
            
        }
        /// <summary>
        /// 业务返回值
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// 操作结果，一般0是失败1是成功，如果是具体的业务自己定义
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 备注信息
        /// </summary>
        public string Info { get; set; }
    }
}
