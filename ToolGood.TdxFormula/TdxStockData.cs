using System;
using System.Collections.Generic;
using System.Linq;

namespace ToolGood.TdxFormula
{
    /// <summary>
    /// 股票 数据
    /// </summary>
    public partial class TdxStockData
    {
        /// <summary>
        /// 长度
        /// </summary>
        public int Length => Date.Length;

        /// <summary>
        /// 日期
        /// </summary>
        public DateTime[] Date { get; set; }

        /// <summary>
        /// 开盘价（元）
        /// </summary>
        public TdxNumber Open { get; set; }

        /// <summary>
        /// 最高价（元）
        /// </summary>
        public TdxNumber High { get; set; }

        /// <summary>
        /// 最低价（元）
        /// </summary>
        public TdxNumber Low { get; set; }

        /// <summary>
        /// 收盘价（元）
        /// </summary>
        public TdxNumber Close { get; set; }

        /// <summary>
        /// 复权后的均价
        /// </summary>
        public TdxNumber Average { get; set; }

        /// <summary>
        /// 成交量（手、100股）
        /// </summary>
        public TdxNumber Volume { get; set; }

        /// <summary>
        /// 成交额（万元）
        /// </summary>
        public TdxNumber Amount { get; set; }

        /// <summary>
        /// 流通股
        /// </summary>
        public TdxNumber Capital { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        public TdxStockData()
        { }

        /// <summary>
        /// 构造函数，支持 IStockData[] 和 List&lt;IStockData>
        /// </summary>
        /// <param name="datas">K线数据</param>
        public TdxStockData(IEnumerable<IStockData> datas)
        {
            Date = datas.Select(x => x.Date).ToArray();
            Open = datas.Select(x => x.Open).ToArray();
            High = datas.Select(x => x.High).ToArray();
            Low = datas.Select(x => x.Low).ToArray();
            Close = datas.Select(x => x.Close).ToArray();
            Average = datas.Select(x => x.Average).ToArray();
            Volume = datas.Select(x => (double)x.Volume).ToArray();
            Amount = datas.Select(x => (double)x.Amount).ToArray();
            Capital = datas.Select(x => (double)x.Capital).ToArray();
        }

        /// <summary>
        /// 构造函数，支持 IStockData[] 和 List&lt;IStockData>
        /// </summary>
        /// <param name="datas">K线数据</param>
        /// <param name="lastDays">K线长度</param>
        public TdxStockData(IEnumerable<IStockData> datas, int lastDays)
        {
            var temp = datas.TakeLast(lastDays).ToList();
            Date = temp.Select(x => x.Date).ToArray();
            Open = temp.Select(x => x.Open).ToArray();
            High = temp.Select(x => x.High).ToArray();
            Low = temp.Select(x => x.Low).ToArray();
            Close = temp.Select(x => x.Close).ToArray();
            Average = temp.Select(x => x.Average).ToArray();
            Volume = temp.Select(x => (double)x.Volume).ToArray();
            Amount = temp.Select(x => (double)x.Amount).ToArray();
            Capital = temp.Select(x => (double)x.Capital).ToArray();
        }

        /// <summary>
        /// 构造函数，支持 IStockData[] 和 List&lt;IStockData>
        /// </summary>
        /// <param name="datas">K线数据</param>
        /// <param name="endDate">结束日期</param>
        public TdxStockData(IEnumerable<IStockData> datas, DateTime endDate)
        {
            var temp = datas.Where(q => q.Date <= endDate).ToList();

            Date = temp.Select(x => x.Date).ToArray();
            Open = temp.Select(x => x.Open).ToArray();
            High = temp.Select(x => x.High).ToArray();
            Low = temp.Select(x => x.Low).ToArray();
            Close = temp.Select(x => x.Close).ToArray();
            Average = temp.Select(x => x.Average).ToArray();
            Volume = temp.Select(x => (double)x.Volume).ToArray();
            Amount = temp.Select(x => (double)x.Amount).ToArray();
            Capital = temp.Select(x => (double)x.Capital).ToArray();
        }

        /// <summary>
        /// 构造函数，支持 IStockData[] 和 List&lt;IStockData>
        /// </summary>
        /// <param name="datas">K线数据</param>
        /// <param name="endDate">结束日期</param>
        /// <param name="lastDays">K线长度</param>
        public TdxStockData(IEnumerable<IStockData> datas, DateTime endDate, int lastDays)
        {
            var temp = datas.Where(q => q.Date <= endDate).TakeLast(lastDays).ToList();
            Date = temp.Select(x => x.Date).ToArray();
            Open = temp.Select(x => x.Open).ToArray();
            High = temp.Select(x => x.High).ToArray();
            Low = temp.Select(x => x.Low).ToArray();
            Close = temp.Select(x => x.Close).ToArray();
            Average = temp.Select(x => x.Average).ToArray();
            Volume = temp.Select(x => (double)x.Volume).ToArray();
            Amount = temp.Select(x => (double)x.Amount).ToArray();
            Capital = temp.Select(x => (double)x.Capital).ToArray();
        }

        /// <summary>
        /// 构造函数，支持 IStockData[] 和 List&lt;IStockData>
        /// </summary>
        /// <param name="datas">K线数据</param>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        public TdxStockData(IEnumerable<IStockData> datas, DateTime startDate, DateTime endDate)
        {
            var temp = datas.Where(q => q.Date >= startDate && q.Date <= endDate).ToList();

            Date = temp.Select(x => x.Date).ToArray();
            Open = temp.Select(x => x.Open).ToArray();
            High = temp.Select(x => x.High).ToArray();
            Low = temp.Select(x => x.Low).ToArray();
            Close = temp.Select(x => x.Close).ToArray();
            Average = temp.Select(x => x.Average).ToArray();
            Volume = temp.Select(x => (double)x.Volume).ToArray();
            Amount = temp.Select(x => (double)x.Amount).ToArray();
            Capital = temp.Select(x => (double)x.Capital).ToArray();
        }

        /// <summary>
        /// 构造函数，支持 IStockData[] 和 List&lt;IStockData>
        /// </summary>
        /// <param name="datas">K线数据</param>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <param name="frontDays">前置数量</param>
        public TdxStockData(IEnumerable<IStockData> datas, DateTime startDate, DateTime endDate, int frontDays)
        {
            var temp = datas.Where(q => q.Date < startDate).TakeLast(frontDays).ToList();
            var temp2 = datas.Where(q => q.Date >= startDate && q.Date <= endDate).ToList();
            temp.AddRange(temp2);
            Date = temp.Select(x => x.Date).ToArray();
            Open = temp.Select(x => x.Open).ToArray();
            High = temp.Select(x => x.High).ToArray();
            Low = temp.Select(x => x.Low).ToArray();
            Close = temp.Select(x => x.Close).ToArray();
            Average = temp.Select(x => x.Average).ToArray();
            Volume = temp.Select(x => (double)x.Volume).ToArray();
            Amount = temp.Select(x => (double)x.Amount).ToArray();
            Capital = temp.Select(x => (double)x.Capital).ToArray();
        }
    }
}