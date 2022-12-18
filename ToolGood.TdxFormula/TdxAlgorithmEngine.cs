using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ToolGood.TdxFormula.Datas;
using ToolGood.TdxFormula.Internals;
using static tdxParser;

namespace ToolGood.TdxFormula
{
    public abstract class TdxAlgorithmEngine
    {
        protected Dictionary<string, Operand> _dict = new Dictionary<string, Operand>(StringComparer.OrdinalIgnoreCase);
        protected KDayData[] StockData;
        protected KDayDataIndex[] StockIndexData;
        protected MyDictionary Top_10_proportion;
        private static DateTime BaseDate = new DateTime(1900, 1, 1);

        public void ResetCache()
        {
            _dict.Clear();
        }

        public void SetParameter(string parameter, Operand operand)
        {
            _dict[parameter] = operand;
        }

        public Operand GetParameter(string parameter)
        {
            if (_dict.TryGetValue(parameter, out Operand operand)) {
                return operand;
            }
            Operand result = null;

            #region 股票信息
            if (parameter.Equals("open", StringComparison.OrdinalIgnoreCase) || parameter.Equals("o", StringComparison.OrdinalIgnoreCase)) {
                result = GetOpenData();
            } else if (parameter.Equals("close", StringComparison.OrdinalIgnoreCase) || parameter.Equals("c", StringComparison.OrdinalIgnoreCase)) {
                result = GetCloseData();
            } else if (parameter.Equals("high", StringComparison.OrdinalIgnoreCase) || parameter.Equals("h", StringComparison.OrdinalIgnoreCase)) {
                result = GetHighData();
            } else if (parameter.Equals("low", StringComparison.OrdinalIgnoreCase) || parameter.Equals("l", StringComparison.OrdinalIgnoreCase)) {
                result = GetLowData();
            } else if (parameter.Equals("vol", StringComparison.OrdinalIgnoreCase) || parameter.Equals("v", StringComparison.OrdinalIgnoreCase)) {
                result = GetVolData();
            } else if (parameter.Equals("amount", StringComparison.OrdinalIgnoreCase) || parameter.Equals("amo", StringComparison.OrdinalIgnoreCase)) {
                result = GetAmountData();
            } else if (parameter.Equals("turn", StringComparison.OrdinalIgnoreCase) || parameter.Equals("t", StringComparison.OrdinalIgnoreCase)) {
                result = GetTurnData();
            } else if (parameter.Equals("capital", StringComparison.OrdinalIgnoreCase)) {
                result = GetCapitalData();
            }
            #endregion

            #region 大盘信息
else if (parameter.Equals("indexA", StringComparison.OrdinalIgnoreCase)) {
                result = GetIndexAData();
            } else if (parameter.Equals("indexV", StringComparison.OrdinalIgnoreCase)) {
                result = GetIndexVData();
            } else if (parameter.Equals("indexO", StringComparison.OrdinalIgnoreCase)) {
                result = GetIndexOData();
            } else if (parameter.Equals("indexC", StringComparison.OrdinalIgnoreCase)) {
                result = GetIndexCData();
            } else if (parameter.Equals("indexH", StringComparison.OrdinalIgnoreCase)) {
                result = GetIndexHData();
            } else if (parameter.Equals("indexL", StringComparison.OrdinalIgnoreCase)) {
                result = GetIndexLData();
            }
            #endregion

            #region 复权因子
            else if (parameter.Equals("OldForeAdjustFactor", StringComparison.OrdinalIgnoreCase)) {
                return GetOldForeAdjustFactor();
            } else if (parameter.Equals("NewForeAdjustFactor", StringComparison.OrdinalIgnoreCase)) {
                return GetNewForeAdjustFactor();
            }
            #endregion

            #region 时间
            else if (parameter.Equals("date", StringComparison.OrdinalIgnoreCase)) {
                var dts = GetDateTimeData();
                List<double> array = new List<double>();
                for (int i = 0; i < dts.Count; i++) {
                    array.Add((dts[i].Year - 1900) * 10000 + dts[i].Month * 100 + dts[i].Day);
                }
                result = Operand.Create(array);
                _dict["date"] = result;
            } else if (parameter.Equals("time", StringComparison.OrdinalIgnoreCase)) {
                var dts = GetDateTimeData();
                List<double> array = new List<double>();
                for (int i = 0; i < dts.Count; i++) {
                    array.Add(dts[i].Hour * 100 + dts[i].Minute);
                }
                result = Operand.Create(array);
                _dict["time"] = result;
            } else if (parameter.Equals("time2", StringComparison.OrdinalIgnoreCase)) {
                var dts = GetDateTimeData();
                List<double> array = new List<double>();
                for (int i = 0; i < dts.Count; i++) {
                    array.Add(dts[i].Hour * 10000 + dts[i].Minute * 100 + dts[i].Second);
                }
                result = Operand.Create(array);
                _dict["time2"] = result;
            } else if (parameter.Equals("year", StringComparison.OrdinalIgnoreCase)) {
                var dts = GetDateTimeData();
                List<double> array = new List<double>();
                for (int i = 0; i < dts.Count; i++) {
                    array.Add(dts[i].Year);
                }
                result = Operand.Create(array);
                _dict["year"] = result;
            } else if (parameter.Equals("month", StringComparison.OrdinalIgnoreCase)) {
                var dts = GetDateTimeData();
                List<double> array = new List<double>();
                for (int i = 0; i < dts.Count; i++) {
                    array.Add(dts[i].Month);
                }
                result = Operand.Create(array);
                _dict["month"] = result;
            } else if (parameter.Equals("day", StringComparison.OrdinalIgnoreCase)) {
                var dts = GetDateTimeData();
                List<double> array = new List<double>();
                for (int i = 0; i < dts.Count; i++) {
                    array.Add(dts[i].Day);
                }
                result = Operand.Create(array);
                _dict["day"] = result;
            } else if (parameter.Equals("hour", StringComparison.OrdinalIgnoreCase)) {
                var dts = GetDateTimeData();
                List<double> array = new List<double>();
                for (int i = 0; i < dts.Count; i++) {
                    array.Add(dts[i].Hour);
                }
                result = Operand.Create(array);
                _dict["hour"] = result;
            } else if (parameter.Equals("minute", StringComparison.OrdinalIgnoreCase)) {
                var dts = GetDateTimeData();
                List<double> array = new List<double>();
                for (int i = 0; i < dts.Count; i++) {
                    array.Add(dts[i].Minute);
                }
                result = Operand.Create(array);
                _dict["minute"] = result;
            } else if (parameter.Equals("DAYSTOTODAY", StringComparison.OrdinalIgnoreCase)) {
                var dts = GetDateTimeData();
                List<double> array = new List<double>();
                for (int i = 0; i < dts.Count; i++) {
                    array.Add((DateTime.Today - dts[i]).Days);
                }
                result = Operand.Create(array);
                _dict["DAYSTOTODAY"] = result;
            } else if (parameter.Equals("WEEKDAY", StringComparison.OrdinalIgnoreCase)) {
                var dts = GetDateTimeData();
                List<double> array = new List<double>();
                for (int i = 0; i < dts.Count; i++) {
                    array.Add((int)dts[i].DayOfWeek);
                }
                result = Operand.Create(array);
                _dict["WEEKDAY"] = result;
            }
            #endregion

            if (object.Equals(null, result) == false) {
                return result;
            }
            throw new Exception($"Parameter [{parameter}] is missing.");
        }


        #region stocks
        protected int ArrayCount()
        {
            return StockData.Length;
        }

        private List<DateTime> DateTimeData;
        private List<DateTime> GetDateTimeData()
        {
            if (DateTimeData == null) {
                List<DateTime> array = new List<DateTime>(ArrayCount());
                foreach (var item in StockData) {
                    array.Add(item.Date);
                }
                Debug.Assert(array.Count == ArrayCount());
                DateTimeData = array;
            }
            return DateTimeData;
        }

        private Operand AmountData;
        private Operand GetAmountData()
        {
            if (object.Equals(AmountData, null)) {
                List<double> array = new List<double>(ArrayCount());
                foreach (var item in StockData) {
                    array.Add(item.Amount);
                }
                Debug.Assert(array.Count == ArrayCount());
                AmountData = Operand.Create(array);
            }
            return AmountData;
        }
        private Operand VolData;
        private Operand GetVolData()
        {
            if (object.Equals(VolData, null)) {
                List<double> array = new List<double>(ArrayCount());
                foreach (var item in StockData) {
                    array.Add(item.Volume);
                }
                Debug.Assert(array.Count == ArrayCount());
                VolData = Operand.Create(array);
            }
            return VolData;
        }
        private Operand CloseData;
        private Operand GetCloseData()
        {
            if (object.Equals(CloseData, null)) {
                List<double> array = new List<double>(ArrayCount());
                foreach (var item in StockData) {
                    array.Add(item.Close);
                }
                Debug.Assert(array.Count == ArrayCount());
                CloseData = Operand.Create(array);
            }
            return CloseData;
        }

        private Operand HighData;
        private Operand GetHighData()
        {
            if (object.Equals(HighData, null)) {
                List<double> array = new List<double>(ArrayCount());
                foreach (var item in StockData) {
                    array.Add(item.High);
                }
                Debug.Assert(array.Count == ArrayCount());
                HighData = Operand.Create(array);
            }
            return HighData;
        }
        private Operand LowData;
        private Operand GetLowData()
        {
            if (object.Equals(LowData, null)) {
                List<double> array = new List<double>(ArrayCount());
                foreach (var item in StockData) {
                    array.Add(item.Low);
                }
                Debug.Assert(array.Count == ArrayCount());
                LowData = Operand.Create(array);
            }
            return LowData;
        }

        private Operand OpenData;
        private Operand GetOpenData()
        {
            if (object.Equals(OpenData, null)) {
                List<double> array = new List<double>(ArrayCount());
                foreach (var item in StockData) {
                    array.Add(item.Open);
                }
                Debug.Assert(array.Count == ArrayCount());
                OpenData = Operand.Create(array);
            }
            return OpenData;
        }

        private Operand TurnData;
        private Operand GetTurnData()
        {
            if (object.Equals(TurnData, null)) {
                List<double> array = new List<double>(ArrayCount());
                foreach (var item in StockData) {
                    array.Add(item.Turn);
                }
                Debug.Assert(array.Count == ArrayCount());
                TurnData = Operand.Create(array);
            }
            return TurnData;
        }


        private Operand CapitalData;

        private Operand GetCapitalData()
        {
            if (object.Equals(CapitalData, null)) {
                List<double> array = new List<double>(ArrayCount());
                foreach (var item in StockData) {
                    array.Add(item.Capital);
                }
                Debug.Assert(array.Count == ArrayCount());
                CapitalData = Operand.Create(array);
            }
            return CapitalData;
        }


        #endregion

        #region Index

        private Operand IndexAData;

        protected Operand GetIndexAData()
        {
            if (object.Equals(IndexAData, null)) {
                List<double> array = new List<double>(ArrayCount());
                foreach (var item in StockIndexData) {
                    array.Add(item.Amount);
                }
                Debug.Assert(array.Count == ArrayCount());
                IndexAData = Operand.Create(array);
            }
            return IndexAData;
        }

        private Operand IndexCData;
        protected Operand GetIndexCData()
        {
            if (object.Equals(IndexCData, null)) {
                List<double> array = new List<double>(ArrayCount());
                foreach (var item in StockIndexData) {
                    array.Add(item.Close);
                }
                Debug.Assert(array.Count == ArrayCount());
                IndexCData = Operand.Create(array);
            }
            return IndexCData;
        }
        private Operand IndexHData;
        protected Operand GetIndexHData()
        {
            if (object.Equals(IndexHData, null)) {
                List<double> array = new List<double>(ArrayCount());
                foreach (var item in StockIndexData) {
                    array.Add(item.High);
                }
                Debug.Assert(array.Count == ArrayCount());
                IndexHData = Operand.Create(array);
            }
            return IndexHData;
        }
        private Operand IndexLData;
        protected Operand GetIndexLData()
        {
            if (object.Equals(IndexLData, null)) {
                List<double> array = new List<double>(ArrayCount());
                foreach (var item in StockIndexData) {
                    array.Add(item.Low);
                }
                Debug.Assert(array.Count == ArrayCount());
                IndexLData = Operand.Create(array);
            }
            return IndexLData;
        }
        private Operand IndexOData;
        protected Operand GetIndexOData()
        {
            if (object.Equals(IndexOData, null)) {
                List<double> array = new List<double>(ArrayCount());
                foreach (var item in StockIndexData) {
                    array.Add(item.Open);
                }
                Debug.Assert(array.Count == ArrayCount());
                IndexOData = Operand.Create(array);
            }
            return IndexOData;
        }
        private Operand IndexVData;
        protected Operand GetIndexVData()
        {
            if (object.Equals(IndexVData, null)) {
                List<double> array = new List<double>(ArrayCount());
                foreach (var item in StockIndexData) {
                    array.Add(item.Volume);
                }
                Debug.Assert(array.Count == ArrayCount());
                IndexVData = Operand.Create(array);
            }
            return IndexVData;
        }

        #endregion

        #region 复权因子
        private Operand OldForeAdjustFactor;
        private Operand GetOldForeAdjustFactor()
        {
            if (object.Equals(OldForeAdjustFactor, null)) {
                List<double> array = new List<double>(ArrayCount());
                foreach (var item in StockData) {
                    array.Add(item.OldForeAdjustFactor);
                }
                OldForeAdjustFactor = Operand.Create(array);
            }
            return OldForeAdjustFactor;
        }
        private Operand NewForeAdjustFactor;
        private Operand GetNewForeAdjustFactor()
        {
            if (object.Equals(NewForeAdjustFactor, null)) {
                List<double> array = new List<double>(ArrayCount());
                foreach (var item in StockData) {
                    array.Add(item.NewForeAdjustFactor);
                }
                NewForeAdjustFactor = Operand.Create(array);
            }
            return NewForeAdjustFactor;
        }
        #endregion

        public Operand Evaluate(string exp)
        {
            ProgContext context = Parse(exp);

            var visitor = new TdxVisitor();
            visitor.GetParameter += GetParameter;
            visitor.SetParameter += SetParameter;
            visitor.GetChipDistribution += GetChipDistribution;
            visitor.GetChip += GetChip;
            visitor.GetChipN += GetChipN;
            visitor.GetChipSumArray += GetChipSumArray;
            visitor.ArrayCount = ArrayCount();

            return visitor.Visit(context);
        }

        private ProgContext Parse(string exp)
        {
            if (string.IsNullOrWhiteSpace(exp)) { return null; }
            var stream = new AntlrCharStream(new AntlrInputStream(exp));
            var lexer = new tdxLexer(stream);
            var tokens = new CommonTokenStream(lexer);
            var parser = new tdxParser(tokens);
            return parser.prog();
        }

        public Operand this[string name] {
            get {
                if (_dict.TryGetValue(name, out Operand operand)) {
                    return operand;
                }
                return null;
            }
        }

        public void SetStockData(KDayData[] stockData)
        {
            StockData = stockData;
        }

        public void SetStockIndexData(KDayDataIndex[] stockIndexData)
        {
            StockIndexData = stockIndexData;
        }

        public void SetTop10(Dictionary<DateTime, double> top10)
        {
            Dictionary<int, double> dict = new Dictionary<int, double>();

            foreach (var item in top10) {
                var key = (int)(item.Key - BaseDate).TotalDays;
                dict[key] = item.Value;
            }
            Top_10_proportion = new MyDictionary(dict);

            chip = null;
            chipSum = null;
            chipSumArray = null;
            chipN = new Dictionary<int, double[]>();
        }

        private double GetTurnoverAttenuationCoefficient(DateTime date)
        {
            if (object.Equals(null, Top_10_proportion) || (Top_10_proportion.Keys != null && Top_10_proportion.Keys.Length > 0)) {
                var key = (int)(date - BaseDate).TotalDays;
                return 1 / (1 - Top_10_proportion.GetTop10Proportion(key));
            }
            return 1;
        }

        #region 成本分布
        private List<Dictionary<int, double>> chipDistribution;
        protected List<Dictionary<int, double>> GetChipDistribution()
        {
            if (chipDistribution == null) {
                var arrayCount = ArrayCount();
                Dictionary<int, double>[] result = new Dictionary<int, double>[arrayCount];
                Parallel.For(0, arrayCount, (i) => {
                    var item = StockData[i];
                    var dict = CalcChipDistribution(item.OldHigh, item.OldLow, item.OldOpen, item.OldClose, item.Volume);
                    result[i] = dict;
                });
                chipDistribution = new List<Dictionary<int, double>>(result);
            }
            return chipDistribution;
        }
        protected Dictionary<int, double> CalcChipDistribution(double high, double low, double open, double close, double volT)
        {
            if (volT == 0) { return new Dictionary<int, double>(); }
            Dictionary<int, double> tmpChip;
            if (high == low) {
                tmpChip = new Dictionary<int, double>(1);
                tmpChip[(int)(high * 100)] = (int)volT;
                return tmpChip;
            } else if (high <= low + 0.01) {
                if (close == high) {
                    tmpChip = new Dictionary<int, double>(2);
                    tmpChip[(int)(high * 100)] = (int)(volT / 3 * 2);
                    tmpChip[(int)(low * 100)] = (int)(volT / 3);
                } else {
                    tmpChip = new Dictionary<int, double>(2);
                    tmpChip[(int)(high * 100)] = (int)(volT / 3);
                    tmpChip[(int)(low * 100)] = (int)(volT / 3 * 2);
                }
                return tmpChip;
            }

            var avg = (open + close + low + high) / 4;
            var top = high + 0.01;      // 加0.01为了包含high这个点
            var h = 2 / (top - low);    // 最低点  low  ，最高点 high+0.01
            var avglow = h / (avg - low);
            var highavg = h / (top - avg);
            var step = (top - low > 2) ? (top - low) / 200 : 0.01;  //防止细分过度 内存使用量过多

            var len = Math.Min((top - low) * 100, 200);
            tmpChip = new Dictionary<int, double>((int)len);

            for (double i = low; i < top; i += step) {
                var start = i;
                var end = i + step;
                double y1, y2;
                if (end < avg) {
                    y1 = avglow * (start - low);
                    y2 = avglow * (end - low);
                } else if (start > avg) {
                    y1 = highavg * (top - start);
                    y2 = highavg * Math.Max(0, top - end);
                } else {
                    y1 = (avglow * (start - low) + h) / 2;
                    y2 = (highavg * (top - end) + h) / 2;
                }
                tmpChip[(int)(i * 100)] = (y1 + y2) / 2 * volT;
            }
            return tmpChip;
        }
        protected void SetChipDistribution(List<Dictionary<int, double>> chipDistribution)
        {
            this.chipDistribution = chipDistribution;
        }


        private List<Dictionary<int, double>> chip;
        private List<double> chipSum;
        private List<MyDictionary> chipSumArray;

        protected List<Dictionary<int, double>> GetChip()
        {
            if (chip == null) {
                chip = new List<Dictionary<int, double>>(ArrayCount());
                var T = GetTurnData().NumberArrayValue;
                var OldForeAdjustFactor = GetOldForeAdjustFactor().NumberArrayValue;
                var NewForeAdjustFactor = GetNewForeAdjustFactor().NumberArrayValue;
                var chipDistribution = GetChipDistribution();
                var arrayCount = ArrayCount();

                Dictionary<int, double> oldCost = new Dictionary<int, double>();
                for (int i = 0; i < arrayCount; i++) {
                    var newCost = chipDistribution[i];
                    var TurnoverAttenuationCoefficient = GetTurnoverAttenuationCoefficient(StockData[i].Date);//历史换手衰减系数
                    oldCost = MyMath.CalcChip(oldCost, newCost, OldForeAdjustFactor[i], NewForeAdjustFactor[i], T[i], TurnoverAttenuationCoefficient);
                    chip.Add(oldCost);
                }

                var chipSum2 = new double[ArrayCount()];
                var chipSumArray2 = new MyDictionary[ArrayCount()];
                Parallel.For(0, arrayCount, (i) => {
                    var oldCost = chip[i];

                    Dictionary<int, double> temp = new Dictionary<int, double>(oldCost.Count);
                    double sum = 0;
                    foreach (var key in oldCost.Keys.OrderBy(q => q)) {
                        sum += oldCost[key];
                        temp[key] = sum;
                    }
                    var mydict = new MyDictionary(temp, sum);
                    chipSum2[i] = sum;
                    chipSumArray2[i] = mydict;
                });
                chipSum = new List<double>(chipSum2);
                chipSumArray = new List<MyDictionary>(chipSumArray2);
            }
            return chip;
        }
        protected List<MyDictionary> GetChipSumArray()
        {
            if (chipSumArray == null) {
                GetChip();
            }
            return chipSumArray;
        }


        private Dictionary<int, double[]> chipN = new Dictionary<int, double[]>();
        protected double[] GetChipN(int N)
        {
            if (chipN.ContainsKey(N) == false) {
                var p = N / 100.0;
                var chipsums = GetChipSumArray();
                var array = new double[ArrayCount()];
                var tops = chipSum;

                Parallel.For(0, ArrayCount(), (i) => {
                    var oldCost = chipsums[i];
                    var old = oldCost.GetChipN(tops[i] * p); // 返回 价格*100
                    array[i] = (Math.Round(old / 100.0, 2));
                });
                chipN[N] = array;
            }
            return chipN[N];
        }
        #endregion
    }

}
