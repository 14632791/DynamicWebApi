using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Metro.DynamicModeules.Interface.Sys
{

    /// <summary>
    /// 支持模糊查询的接口,用于frmFuzzySearch窗体
    /// </summary>
    public interface IFuzzySearchSupportable<T>
    {
        string FuzzySearchName { get; }
        IList<T> FuzzySearch(string content);
    }
}
