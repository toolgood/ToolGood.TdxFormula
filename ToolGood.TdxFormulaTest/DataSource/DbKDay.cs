using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolGood.ReadyGo3.Attributes;

namespace ToolGood.TdxFormulaTest
{
    public class DbKDay
    {
        public int Id { get; set; }

        /// <summary>
        /// 时间
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// 开盘价（元）
        /// </summary>
        public double Open { get; set; }

        /// <summary>
        /// 最高价（元）
        /// </summary>
        public double High { get; set; }

        /// <summary>
        /// 最低价（元）
        /// </summary>
        public double Low { get; set; }

        /// <summary>
        /// 收盘价（元）
        /// </summary>
        public double Close { get; set; }

        [Ignore]
        public double Average { get; set; }

        /// <summary>
        /// 成交量（手、100股）
        /// </summary>
        public long Volume { get; set; }

        /// <summary>
        /// 成交额（万元）
        /// </summary>
        public double Amount { get; set; }

        /// <summary>
        /// 换手率（%）
        /// </summary>
        public double Turn { get; set; }

        public bool IsST { get; set; }

        /// <summary>
        /// 流通股本（股）
        /// </summary>
        public long Capital { get; set; }

        /// <summary>
        /// 总股本（股）
        /// </summary>
        public long TotalCapital { get; set; }
    }

}
