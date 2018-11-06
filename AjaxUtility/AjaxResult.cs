using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloDBA.Utilities.AjaxUtility
{
    public class AjaxResult
    {
        /// <summary>
        /// 操作结果类型
        /// </summary>
        public object code { get; set; }
        /// <summary>
        /// 获取 消息内容
        /// </summary>
        public string msg { get; set; }
        public int count { get; set; }
        /// <summary>
        /// 获取 返回数据
        /// </summary>
        public object data { get; set; }
    }
    /// <summary>
    /// 表示 ajax 操作结果类型的枚举
    /// </summary>
    public enum AjaxResultType
    {
        /// <summary>
        /// 成功结果类型
        /// </summary>
        success = 0,
        /// <summary>
        /// 警告结果类型
        /// </summary>
        warning = 2,
        /// <summary>
        /// 异常结果类型
        /// </summary>
        error = 3
    }
}
