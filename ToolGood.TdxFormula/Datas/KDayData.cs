using System;
using System.Collections.Generic;
using System.Text;

namespace ToolGood.TdxFormula.Datas
{
    public struct KDayData
    {
        public DateTime Date { get; set; }
        public double Open { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public double Close { get; set; }
        public long Volume { get; set; }
        public double Amount { get; set; }
        public double Turn { get; set; }
        public long Capital { get; set; }


        public double OldOpen { get; set; }
        public double OldHigh { get; set; }
        public double OldLow { get; set; }
        public double OldClose { get; set; }


        public double OldForeAdjustFactor { get; set; }
        public double NewForeAdjustFactor { get; set; }


    }
}
