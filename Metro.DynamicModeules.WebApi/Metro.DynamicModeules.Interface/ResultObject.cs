using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Metro.DynamicModeules.Interface
{
    /*
     包装响应的时候，有两种情况，第一种是操作类接口，比如添加商品，这些接口是不用响应对象的，只要返回是否成功就行了，第二种查询类，这个时候必须要返回一些具体的东西了，所以响应包装设计成两个类：
         */
    public class ResultObject
    {
        /// <summary>
        /// 等于0表示成功
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// code不为0时，返回错误消息
        /// </summary>
        public string Msg { get; set; }
    }

    public class ResultObject<TResponse> : ResultObject where TResponse : class
    {
        public ResultObject()
        {
        }
        public ResultObject(TResponse data)
        {
            Data = data;
        }
        /// <summary>
        /// 返回的数据
        /// </summary>
        public TResponse Data { get; set; }

    }
}
