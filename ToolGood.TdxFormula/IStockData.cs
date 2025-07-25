using System;

namespace ToolGood.TdxFormula
{
    /// <summary>
    /// 股票K线数据
    /// </summary>
    public interface IStockData
    {
        /// <summary>
        /// 日期
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

        /// <summary>
        /// 复权后的均价
        /// </summary>
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
        /// 流通股
        /// </summary>
        public double Capital { get; set; }
    }
}