using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ToolGood.TdxFormula
{
    /// <summary>
    /// tdx 数学类
    /// </summary>
    public static class TdxMath
    {
        /// <summary>
        /// 求逻辑非.
        /// 用法: NOT(X)返回非X,即当X=0时返回1,否则返回0
        /// 例如: NOT(ISUP)表示平盘或收阴
        /// </summary>
        /// <param name="X"></param>
        /// <returns></returns>
        public static TdxNumber NOT(TdxNumber X)
        {
            var array = new double[X.Length];
            for (int i = 0; i < array.Length; i++) {
                if (X[i] == 0) { array[i] = 1; }
            }
            return new TdxNumber(array);
        }

        #region Math
        /// <summary>
        /// 反余弦值.
        /// 用法: ACOS(X)返回X的反余弦值
        /// </summary>
        /// <param name="X"></param>
        /// <returns></returns>
        public static TdxNumber ACOS(TdxNumber X)
        {
            return X.RunFun(Math.Acos);
        }
        /// <summary>
        /// 反正弦值.
        /// 用法: ASIN(X)返回X的反正弦值
        /// </summary>
        /// <param name="X"></param>
        /// <returns></returns>
        public static TdxNumber ASIN(TdxNumber X)
        {
            return X.RunFun(Math.Asin);
        }
        /// <summary>
        /// 反正切值.
        /// 用法: ATAN(X)返回X的反正切值
        /// </summary>
        /// <param name="X"></param>
        /// <returns></returns>
        public static TdxNumber ATAN(TdxNumber X)
        {
            return X.RunFun(Math.Atan);
        }
        /// <summary>
        /// 余弦值.
        /// 用法: COS(X)返回X的余弦值
        /// </summary>
        /// <param name="X"></param>
        /// <returns></returns>
        public static TdxNumber COS(TdxNumber X)
        {
            return X.RunFun(Math.Cos);
        }
        /// <summary>
        /// 正弦值.
        /// 用法: SIN(X)返回X的正弦值
        /// </summary>
        /// <param name="X"></param>
        /// <returns></returns>
        public static TdxNumber SIN(TdxNumber X)
        {
            return X.RunFun(Math.Sin);
        }
        /// <summary>
        /// 正切值.
        /// 用法: TAN(X)返回X的正切值
        /// </summary>
        /// <param name="X"></param>
        /// <returns></returns>
        public static TdxNumber TAN(TdxNumber X)
        {
            return X.RunFun(Math.Tan);
        }
        /// <summary>
        /// 指数.
        /// 用法: EXP(X)为e的X次幂
        /// 例如: EXP(CLOSE)返回e的CLOSE次幂
        /// </summary>
        /// <param name="X"></param>
        /// <returns></returns>
        public static TdxNumber EXP(TdxNumber X)
        {
            return X.RunFun(Math.Exp);
        }
        /// <summary>
        /// 求自然对数.
        /// 用法: LN(X)以e为底的对数
        /// 例如: LN(CLOSE)求收盘价的对数
        /// </summary>
        /// <param name="X"></param>
        /// <returns></returns>
        public static TdxNumber LN(TdxNumber X)
        {
            return X.RunFun(Math.Log);
        }
        /// <summary>
        /// 求N为底的对数.
        /// 用法: LOG(X,N)取得X的对数
        /// 例如: LOG(100,10)等于2
        /// </summary>
        /// <param name="X"></param>
        /// <returns></returns>
        public static TdxNumber LOG(TdxNumber X)
        {
            return X.RunFun2(Math.Log, 10.0);
        }
        /// <summary>
        /// 求N为底的对数.
        /// 用法: LOG(X,N)取得X的对数
        /// 例如: LOG(100,10)等于2
        /// </summary>
        /// <param name="X"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public static TdxNumber LOG(TdxNumber X, double num)
        {
            return X.RunFun2(Math.Log, num);
        }
        /// <summary>
        /// 求N为底的对数.
        /// 用法: LOG(X,N)取得X的对数
        /// 例如: LOG(100,10)等于2
        /// </summary>
        /// <param name="X"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public static TdxNumber LOG(TdxNumber X, TdxNumber num)
        {
            return X.RunFun2((m, n) => { return Math.Log(m, n); }, num);
        }
        /// <summary>
        /// 开平方.
        /// 用法: SQRT(X)为X的平方根
        /// 例如: SQRT(CLOSE)收盘价的平方根
        /// </summary>
        /// <param name="X"></param>
        /// <returns></returns>
        public static TdxNumber SQRT(TdxNumber X)
        {
            return X.RunFun(Math.Sqrt);
        }
        /// <summary>
        /// 求绝对值.
        /// 用法: ABS(X)返回X的绝对值
        /// 例如: ABS(-34)返回34
        /// </summary>
        /// <param name="X"></param>
        /// <returns></returns>
        public static TdxNumber ABS(TdxNumber X)
        {
            return X.RunFun(Math.Abs);
        }
        /// <summary>
        /// 向上舍入.
        /// 用法: CEILING(A)返回沿A数值增大方向最接近的整数
        /// 例如: CEILING(12.3)求得13,CEILING(-3.5)求得-3
        /// </summary>
        /// <param name="X"></param>
        /// <returns></returns>
        public static TdxNumber CEILING(TdxNumber X)
        {
            return X.RunFun(Math.Ceiling);
        }
        /// <summary>
        /// 向下舍入.
        /// 用法: FLOOR(A)返回沿A数值减小方向最接近的整数
        /// 例如: FLOOR(12.3)求得12,FLOOR(-3.5)求得-4
        /// </summary>
        /// <param name="X"></param>
        /// <returns></returns>
        public static TdxNumber FLOOR(TdxNumber X)
        {
            return X.RunFun(Math.Floor);
        }
        /// <summary>
        /// 取整.
        /// 用法: INTPART(A)返回沿A绝对值减小方向最接近的整数
        /// 例如: INTPART(12.3)求得12,INTPART(-3.5)求得-3
        /// </summary>
        /// <param name="X"></param>
        /// <returns></returns>
        public static TdxNumber INTPART(TdxNumber X)
        {
            return X.RunFun((m) => { return (int)m; });
        }
        /// <summary>
        /// 小数部分.
        /// 用法: FRACPART(X),返回X的小数部分
        /// </summary>
        /// <param name="X"></param>
        /// <returns></returns>
        public static TdxNumber FRACPART(TdxNumber X)
        {
            return X.RunFun((m) => { return m - (int)m; });
        }
        /// <summary>
        /// 四舍五入.
        /// 用法: ROUND(X,N),返回X四舍五入到个位的数值
        /// </summary>
        /// <param name="X"></param>
        /// <returns></returns>
        public static TdxNumber ROUND(TdxNumber X)
        {
            return X.RunFun((m) => { return Math.Round(m, MidpointRounding.AwayFromZero); });
        }
        /// <summary>
        /// 四舍五入.
        /// 用法: ROUND(X,N),返回X四舍五入到个位的数值
        /// </summary>
        /// <param name="X"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public static TdxNumber ROUND(TdxNumber X, int num)
        {
            return X.RunFun2((m, n) => { return Math.Round(m, (int)n, MidpointRounding.AwayFromZero); }, num);
        }
        /// <summary>
        /// 四舍五入.
        /// 用法: ROUND(X,N),返回X四舍五入到个位的数值
        /// </summary>
        /// <param name="X"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public static TdxNumber ROUND(TdxNumber X, TdxNumber num)
        {
            return X.RunFun2((m, n) => { return Math.Round(m, (int)n, MidpointRounding.AwayFromZero); }, num);
        }
        /// <summary>
        /// 取符号.
        /// 用法: SIGN(X),返回X的符号.当X>0,X=0,X&lt;0分别返回1,0,-1
        /// </summary>
        /// <param name="X"></param>
        /// <returns></returns>
        public static TdxNumber SIGN(TdxNumber X)
        {
            return X.RunFun(Math.Sign);
        }

        /// <summary>
        /// 取模.
        /// 用法: MOD(M, N),返回M关于N的模(M除以N的余数)
        /// 例如: MOD(5,3)返回2 注意:公式系统对有效数字部分有要求,如果数字部分超过7-8位,会有精度丢失
        /// </summary>
        /// <param name="X"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static TdxNumber MOD(TdxNumber X, TdxNumber N)
        {
            var array = new double[X.Length];   
            for (int i = 0; i < X.Length; i++) {
                array[i] = Math.Round(X[i], 0, MidpointRounding.AwayFromZero) % (int)N[i];
            }
            return array;
        }
        /// <summary>
        /// 取模.
        /// 用法: MOD(M, N),返回M关于N的模(M除以N的余数)
        /// 例如: MOD(5,3)返回2 注意:公式系统对有效数字部分有要求,如果数字部分超过7-8位,会有精度丢失
        /// </summary>
        /// <param name="X"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static TdxNumber MOD(TdxNumber X, double N)
        {
            var array = new double[X.Length];
            for (int i = 0; i < X.Length; i++) {
                array[i] = Math.Round(X[i], 0, MidpointRounding.AwayFromZero) % (int)N;
            }
            return array;
        }
        /// <summary>
        /// 取模.
        /// 用法: MOD(M, N),返回M关于N的模(M除以N的余数)
        /// 例如: MOD(5,3)返回2 注意:公式系统对有效数字部分有要求,如果数字部分超过7-8位,会有精度丢失
        /// </summary>
        /// <param name="X"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static TdxNumber MOD(double X, TdxNumber N)
        {
            var array = new double[N.Length];
            for (int i = 0; i < N.Length; i++) {
                array[i] = Math.Round(X, 0, MidpointRounding.AwayFromZero) % (int)N[i];
            }
            return array;
        }

        /// <summary>
        /// 求最大值.
        /// 用法: MAX(A, B)返回A和B中的较大值
        /// 例如: MAX(CLOSE-OPEN,0)表示若收盘价大于开盘价返回它们的差值,否则返回0
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <returns></returns>
        public static TdxNumber MAX(TdxNumber X, TdxNumber Y)
        {
            return X.RunFun2(Math.Max, Y);
        }
        /// <summary>
        /// 求最大值.
        /// 用法: MAX(A, B)返回A和B中的较大值
        /// 例如: MAX(CLOSE-OPEN,0)表示若收盘价大于开盘价返回它们的差值,否则返回0
        /// </summary>
        /// <param name="Y"></param>
        /// <param name="X"></param>
        /// <returns></returns>
        public static TdxNumber MAX(TdxNumber X, double Y)
        {
            return X.RunFun2(Math.Max, Y);
        }
        /// <summary>
        /// 求最大值.
        /// 用法: MAX(A, B)返回A和B中的较大值
        /// 例如: MAX(CLOSE-OPEN,0)表示若收盘价大于开盘价返回它们的差值,否则返回0
        /// </summary>
        /// <param name="Y"></param>
        /// <param name="X"></param>
        /// <returns></returns>
        public static TdxNumber MAX(double X, TdxNumber Y)
        {
            return Y.RunFun2(Math.Max, X);
        }

        /// <summary>
        /// 求最小值.
        /// 用法: MIN(A, B)返回A和B中的较小值
        /// 例如: MIN(CLOSE, OPEN)返回开盘价和收盘价中的较小值
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <returns></returns>
        public static TdxNumber MIN(TdxNumber X, TdxNumber Y)
        {
            return X.RunFun2(Math.Min, Y);
        }
        /// <summary>
        /// 求最小值.
        /// 用法: MIN(A, B)返回A和B中的较小值
        /// 例如: MIN(CLOSE, OPEN)返回开盘价和收盘价中的较小值
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <returns></returns>
        public static TdxNumber MIN(TdxNumber X, double Y)
        {
            return X.RunFun2(Math.Min, Y);
        }
        /// <summary>
        /// 求最小值.
        /// 用法: MIN(A, B)返回A和B中的较小值
        /// 例如: MIN(CLOSE, OPEN)返回开盘价和收盘价中的较小值
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <returns></returns>
        public static TdxNumber MIN(double X, TdxNumber Y)
        {
            return Y.RunFun2(Math.Min, X);
        }

        /// <summary>
        /// 乘幂.
        /// 用法: POW(A, B)返回A的B次幂
        /// 例如: POW(CLOSE,3)求得收盘价的3次方
        /// </summary>
        /// <param name="X"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public static TdxNumber POW(TdxNumber X, double num)
        {
            return X.RunFun2((m, n) => { return Math.Pow(m, n); }, num);
        }
        /// <summary>
        /// 乘幂.
        /// 用法: POW(A, B)返回A的B次幂
        /// 例如: POW(CLOSE,3)求得收盘价的3次方
        /// </summary>
        /// <param name="X"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public static TdxNumber POW(TdxNumber X, TdxNumber num)
        {
            return X.RunFun2((m, n) => { return Math.Pow(m, n); }, num);
        }
        /// <summary>
        /// 乘幂.
        /// 用法: POW(A, B)返回A的B次幂
        /// 例如: POW(CLOSE,3)求得收盘价的3次方
        /// </summary>
        /// <param name="X"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public static TdxNumber POW(double X, TdxNumber num)
        {
            return num.RunFun2((m, n) => { return Math.Pow(n, m); }, X);
        }

        /// <summary>
        /// 求最大值.
        /// 用法: MAX(A, B)返回A和B中的较大值
        /// 例如: MAX(CLOSE-OPEN,0)表示若收盘价大于开盘价返回它们的差值,否则返回0
        /// </summary>
        /// <param name="Values"></param>
        /// <returns></returns>
        public static double[] MAX(params TdxNumber[] Values)
        {
            List<double[]> doubles = new List<double[]>();
            foreach (var item in Values) {
                doubles.Add((double[])item);
            }

            var array = new double[Values[0].Length];
            for (int i = 0; i < array.Length; i++) {
                var max = doubles[0][i];
                for (int j = 1; j < doubles.Count; j++) {
                    var val = doubles[j][i];
                    if (val > max) {
                        max = val;
                    }
                }
                array[i] = max;
            }
            return array;
        }

        /// <summary>
        /// 求最小值.
        /// 用法: MIN(A, B)返回A和B中的较小值
        /// 例如: MIN(CLOSE, OPEN)返回开盘价和收盘价中的较小值
        /// </summary>
        /// <param name="Values"></param>
        /// <returns></returns>
        public static double[] MIN(params TdxNumber[] Values)
        {
            List<double[]> doubles = new List<double[]>();
            foreach (var item in Values) {
                doubles.Add((double[])item);
            }

            var array = new double[Values[0].Length];
            for (int i = 0; i < array.Length; i++) {
                var min = doubles[0][i];
                for (int j = 1; j < doubles.Count; j++) {
                    var val = doubles[j][i];
                    if (val < min) {
                        min = val;
                    }
                }
                array[i] = min;
            }
            return array;
        }

        #endregion
        /// <summary>
        /// 求相反数.
        /// 用法: REVERSE(X)返回-X.
        /// 例如: REVERSE(CLOSE)返回-CLOSE
        /// </summary>
        /// <param name="X"></param>
        /// <returns></returns>
        public static TdxNumber REVERSE(TdxNumber X)
        {
            return X.RunFun((m) => { return -m; });
        }
        /// <summary>
        /// CONST(A):取A最后的值为常量.
        /// 用法: CONST(INDEXC)表示取指数现价
        /// </summary>
        /// <param name="X"></param>
        /// <returns></returns>
        public static TdxNumber CONST(TdxNumber X)
        {
            var array = new double[X.Length];
            Array.Fill(array, X[array.Length - 1]);
            return new TdxNumber(array);
        }
        /// <summary>
        /// 判断时否有效值
        /// </summary>
        /// <param name="X"></param>
        /// <returns></returns>
        public static TdxNumber ISVALID(TdxNumber X)
        {
            return X.RunFun((m) => {
                if (double.IsNaN(m)) return 0;
                return 1;
            });
        }

        /// <summary>
        /// 上一次条件成立到当前的周期数.
        /// 用法: BARSLAST(X) :上一次X不为0到现在的周期数
        /// 例如: BARSLAST(CLOSE/REF(CLOSE,1)>=1.1)表示上一个涨停板到当前的周期数
        /// </summary>
        /// <param name="X"></param>
        /// <returns></returns>
        public static TdxNumber BARSLAST(TdxNumber X)
        {
            var array = new double[X.Length];
            int count = 0;
            for (int i = 0; i < array.Length; i++) {
                if (X.GetBoolean(i)) {
                    count = 0;
                } else {
                    count++;
                    array[i] = count;
                }
            }
            return new TdxNumber(array);
        }
        /// <summary>
        /// 上一次条件成立到当前的周期数.
        /// 用法: BARSLAST(X) :上一次X不为0到现在的周期数
        /// 例如: BARSLAST(CLOSE/REF(CLOSE,1)>=1.1)表示上一个涨停板到当前的周期数
        /// </summary>
        /// <param name="X"></param>
        /// <returns></returns>
        public static TdxNumber BARSLAST(bool[] X)
        {
            var array = new double[X.Length];
            int count = 0;
            for (int i = 0; i < array.Length; i++) {
                if (X[i]) {
                    count = 0;
                } else {
                    count++;
                    array[i] = count;
                }
            }
            return new TdxNumber(array);
        }
        /// <summary>
        /// 统计连续满足条件的周期数.
        /// 用法: BARSLASTCOUNT(X),统计连续满足X条件的周期数.
        /// 例如: BARSLASTCOUNT(CLOSE>OPEN)表示统计连续收阳的周期数
        /// </summary>
        /// <param name="X"></param>
        /// <returns></returns>
        public static TdxNumber BARSLASTCOUNT(TdxNumber X)
        {
            var array = new double[X.Length];
            int count = 0;
            for (int i = 0; i < array.Length; i++) {
                if (X.GetBoolean(i) == false) {
                    count = 0;
                } else {
                    count++;
                    array[i] = count;
                }
            }
            return new TdxNumber(array);
        }
        /// <summary>
        /// 统计连续满足条件的周期数.
        /// 用法: BARSLASTCOUNT(X),统计连续满足X条件的周期数.
        /// 例如: BARSLASTCOUNT(CLOSE>OPEN)表示统计连续收阳的周期数
        /// </summary>
        /// <param name="X"></param>
        /// <returns></returns>
        public static TdxNumber BARSLASTCOUNT(bool[] X)
        {
            var array = new double[X.Length];
            int count = 0;
            for (int i = 0; i < array.Length; i++) {
                if (X[i] == false) {
                    count = 0;
                } else {
                    count++;
                    array[i] = count;
                }
            }
            return new TdxNumber(array);
        }
        /// <summary>
        /// 有效数据周期数.
        /// 用法: BARSCOUNT(X)第一个有效数据到当前的间隔周期数
        /// </summary>
        /// <param name="X"></param>
        /// <returns></returns>
        public static TdxNumber BARSCOUNT(TdxNumber X)
        {
            var array = new double[X.Length];

            var startIndex = 0;
            while (startIndex < array.Length && double.IsNaN(X[startIndex])) { array[startIndex] = double.NaN; startIndex++; }

            for (int i = startIndex; i < array.Length; i++) {
                array[i] = i - startIndex;
            }
            return new TdxNumber(array);
        }
        /// <summary>
        /// 第一个条件成立到当前的周期数.
        /// 用法: BARSSINCE(X) :第一次X不为0到现在的周期数
        /// 例如: BARSSINCE(HIGH>10)表示股价超过10元时到当前的周期数
        /// </summary>
        /// <param name="X"></param>
        /// <returns></returns>
        public static TdxNumber BARSSINCE(TdxNumber X)
        {
            var array = new double[X.Length];
            int count = -1;
            bool first = false;
            for (int i = 0; i < array.Length; i++) {
                if (first) {
                    count++;
                } else if (X.GetBoolean(i)) {
                    first = true;
                    count = 0;
                }
                if (count == -1) {
                    array[i] = double.NaN;
                } else {
                    array[i] = count;
                }
            }
            return new TdxNumber(array);
        }
        /// <summary>
        /// 第一个条件成立到当前的周期数.
        /// 用法: BARSSINCE(X) :第一次X不为0到现在的周期数
        /// 例如: BARSSINCE(HIGH>10)表示股价超过10元时到当前的周期数
        /// </summary>
        /// <param name="X"></param>
        /// <returns></returns>
        public static TdxNumber BARSSINCE(bool[] X)
        {
            var array = new double[X.Length];
            int count = -1;
            bool first = false;
            for (int i = 0; i < array.Length; i++) {
                if (first) {
                    count++;
                } else if (X[i]) {
                    first = true;
                    count = 0;
                }
                if (count == -1) {
                    array[i] = double.NaN;
                } else {
                    array[i] = count;
                }
            }
            return new TdxNumber(array);
        }
        /// <summary>
        /// 当前值是近多少周期内的最小值.
        /// 用法: LOWRANGE(X) :X是近多少周期内X的最小值
        /// 例如: LOWRANGE(LOW)表示当前最低价是近多少周期内最低价的最小值
        /// </summary>
        /// <param name="X"></param>
        /// <returns></returns>
        public static TdxNumber LOWRANGE(TdxNumber X)
        {
            var array = new double[X.Length];
            for (int i = 0; i < array.Length; i++) {
                int index = 0;
                var num = X[i];
                for (int j = i - 1; j >= 0; j--) {
                    if (num >= X[j]) {
                        break;
                    }
                    index++;
                }
                array[i] = index;
            }
            return new TdxNumber(array);
        }
        /// <summary>
        /// 当前值是近多少周期内的最大值.
        /// 用法: TOPRANGE(X) :X是近多少周期内X的最大值
        /// 例如: TOPRANGE(HIGH)表示当前最高价是近多少周期内最高价的最大值
        /// </summary>
        /// <param name="X"></param>
        /// <returns></returns>
        public static TdxNumber TOPRANGE(TdxNumber X)
        {
            var array = new double[X.Length];
            for (int i = 0; i < array.Length; i++) {
                int index = 0;
                var num = X[i];
                for (int j = i - 1; j >= 0; j--) {
                    if (num <= X[j]) {
                        break;
                    }
                    index++;
                }
                array[i] = index;
            }
            return new TdxNumber(array);
        }
        /// <summary>
        /// 并且
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Xs"></param>
        /// <returns></returns>
        public static bool[] AND(TdxNumber X, params TdxNumber[] Xs)
        {
            var array = new bool[X.Length];
            for (int i = 0; i < array.Length; i++) {
                if (X.GetBoolean(i) == false) { continue; }
                bool b = true;
                for (int j = 0; j < Xs.Length; j++) {
                    if (Xs[j].GetBoolean(i) == false) {
                        b = false;
                        break;
                    }
                }
                array[i] = b;
            }
            return array;
        }
        /// <summary>
        /// 并且
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Xs"></param>
        /// <returns></returns>
        public static bool[] AND(TdxNumber X, params bool[][] Xs)
        {
            var array = new bool[X.Length];
            for (int i = 0; i < array.Length; i++) {
                if (X.GetBoolean(i) == false) { continue; }
                bool b = true;
                for (int j = 0; j < Xs.Length; j++) {
                    if (Xs[j][i] == false) {
                        b = false;
                        break;
                    }
                }
                array[i] = b;
            }
            return array;
        }

        /// <summary>
        /// 或者
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Xs"></param>
        /// <returns></returns>
        public static bool[] OR(TdxNumber X, params TdxNumber[] Xs)
        {
            var array = new bool[X.Length];
            for (int i = 0; i < array.Length; i++) {
                if (X.GetBoolean(i)) {
                    array[i] = true;
                    continue;
                }
                bool b = false;
                for (int j = 0; j < Xs.Length; j++) {
                    if (Xs[j].GetBoolean(i)) {
                        b = true;
                        break;
                    }
                }
                array[i] = b;
            }
            return array;
        }

        /// <summary>
        /// 或者
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Xs"></param>
        /// <returns></returns>
        public static bool[] OR(TdxNumber X, params bool[][] Xs)
        {
            var array = new bool[X.Length];
            for (int i = 0; i < array.Length; i++) {
                if (X.GetBoolean(i)) {
                    array[i] = true;
                    continue;
                }
                bool b = false;
                for (int j = 0; j < Xs.Length; j++) {
                    if (Xs[j][i]) {
                        b = true;
                        break;
                    }
                }
                array[i] = b;
            }
            return array;
        }


        /// <summary>
        /// 引用若干周期前的数据.
        /// 用法: REF(X, A),引用A周期前的X值.A可以是变量.
        /// 例如: REF(CLOSE, BARSCOUNT(C)-1)表示第二根K线的收盘价.
        /// </summary>
        /// <param name="X"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static TdxNumber REF(TdxNumber X, int N)
        {
            var array = new double[X.Length];
            for (int i = array.Length - 1; i >= 0; i--) {
                var idx = i - N;
                if (idx < 0) idx = 0;
                array[i] = X[idx];
            }
            return new TdxNumber(array);
        }
        /// <summary>
        /// 引用若干周期前的数据.
        /// 用法: REF(X, A),引用A周期前的X值.A可以是变量.
        /// 例如: REF(CLOSE, BARSCOUNT(C)-1)表示第二根K线的收盘价.
        /// </summary>
        /// <param name="X"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static TdxNumber REF(TdxNumber X, TdxNumber N)
        {
            var array = new double[X.Length];
            for (int i = array.Length - 1; i >= 0; i--) {
                var idx = i - (int)N[i];
                if (idx < 0) idx = 0;
                array[i] = X[idx];
            }
            return new TdxNumber(array);
        }
        /// <summary>
        /// 返回涨停价
        /// 用法: ZTPRICE(REF(CLOSE,1),0.1):按10%计算得到在昨收盘基础上的涨停价(对于复权序列K线, 由于复权处理, 根据前一天的收盘价计算结果可能与涨停价不符)
        /// 比如: ZTPrice(REF(QHJSJ,1),0.1),得到期货的涨停价
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <returns></returns>
        public static TdxNumber ZTPRICE(TdxNumber X, double Y)
        {
            var array = new double[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = Math.Round(X[i] * (1 + Y), 2, MidpointRounding.AwayFromZero);
            }
            return new TdxNumber(array);
        }
        /// <summary>
        /// 返回涨停价
        /// 用法: ZTPRICE(REF(CLOSE,1),0.1):按10%计算得到在昨收盘基础上的涨停价(对于复权序列K线, 由于复权处理, 根据前一天的收盘价计算结果可能与涨停价不符)
        /// 比如: ZTPrice(REF(QHJSJ,1),0.1),得到期货的涨停价
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <returns></returns>
        public static TdxNumber ZTPRICE(TdxNumber X, TdxNumber Y)
        {
            var array = new double[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = Math.Round(X[i] * (1 + Y[i]), 2, MidpointRounding.AwayFromZero);
            }
            return new TdxNumber(array);
        }
        /// <summary>
        /// 返回跌停价
        /// 用法: DTPRICE(REF(CLOSE,1),0.1):按10%计算得到在昨收盘基础上的跌停价(对于复权序列K线, 由于复权处理, 根据前一天的收盘价计算结果可能与跌停价不符)
        /// 比如: DTPrice(REF(QHJSJ,1),0.6),得到期货的跌停价(跌停比例为0.6的话)
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <returns></returns>
        public static TdxNumber DTPRICE(TdxNumber X, double Y)
        {
            var array = new double[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = Math.Round(X[i] * (1 - Y), 2, MidpointRounding.AwayFromZero);
            }
            return new TdxNumber(array);
        }
        /// <summary>
        /// 返回跌停价
        /// 用法: DTPRICE(REF(CLOSE,1),0.1):按10%计算得到在昨收盘基础上的跌停价(对于复权序列K线, 由于复权处理, 根据前一天的收盘价计算结果可能与跌停价不符)
        /// 比如: DTPrice(REF(QHJSJ,1),0.6),得到期货的跌停价(跌停比例为0.6的话)
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <returns></returns>
        public static TdxNumber DTPRICE(TdxNumber X, TdxNumber Y)
        {
            var array = new double[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = Math.Round(X[i] * (1 - Y[i]), 2, MidpointRounding.AwayFromZero);
            }
            return new TdxNumber(array);
        }
        /// <summary>
        /// 两条线交叉.
        /// 用法: CROSS(A, B)表示当A从下方向上穿过B时返回1,否则返回0
        /// 例如: CROSS(MA(CLOSE,5),MA(CLOSE,10))表示5日均线与10日均线交金叉
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <returns></returns>
        public static TdxNumber CROSS(TdxNumber X, TdxNumber Y)
        {
            var array = new double[X.Length];
            for (int i = 1; i < array.Length; i++) {
                if (X[i - 1] < Y[i - 1]) {
                    if (X[i] > Y[i]) {
                        array[i] = 1;
                        continue;
                    }
                }
                array[i] = 0;
            }
            return new TdxNumber(array);
        }
        /// <summary>
        /// 两条线交叉.
        /// 用法: CROSS(A, B)表示当A从下方向上穿过B时返回1,否则返回0
        /// 例如: CROSS(MA(CLOSE,5),MA(CLOSE,10))表示5日均线与10日均线交金叉
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <returns></returns>
        public static TdxNumber CROSS(TdxNumber X, double Y)
        {
            var array = new double[X.Length];
            for (int i = 0; i < array.Length; i++) {
                if (X[i - 1] < Y) {
                    if (X[i] > Y) {
                        array[i] = 1;
                        continue;
                    }
                }
                array[i] = 0;
            }
            return new TdxNumber(array);
        }
        /// <summary>
        /// N周期内第一个条件成立到当前的周期数.
        /// 用法: BARSSINCEN(X, N) :N周期内第一次X不为0到现在的周期数,N为常量
        /// 例如: BARSSINCEN(HIGH>10,10)表示10个周期内股价超过10元时到当前的周期数
        /// </summary>
        /// <param name="X"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static TdxNumber BARSSINCEN(TdxNumber X, int N)
        {
            var array = new double[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = -1;
            }
            for (int i = 0; i < array.Length; i++) {
                if (X.GetBoolean(i) == false) { continue; }
                for (int j = 0; j < N; j++) {
                    if (i + j < array.Length && array[i + j] < j) {
                        array[i + j] = j;
                    }
                }
            }
            return new TdxNumber(array);
        }
        /// <summary>
        /// N周期内第一个条件成立到当前的周期数.
        /// 用法: BARSSINCEN(X, N) :N周期内第一次X不为0到现在的周期数,N为常量
        /// 例如: BARSSINCEN(HIGH>10,10)表示10个周期内股价超过10元时到当前的周期数
        /// </summary>
        /// <param name="X"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static TdxNumber BARSSINCEN(bool[] X, int N)
        {
            var array = new double[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = -1;
            }

            for (int i = 0; i < array.Length; i++) {
                if (X[i] == false) { continue; }
                for (int j = 0; j < N; j++) {
                    if (i + j < array.Length && array[i + j] < j) {
                        array[i + j] = j;
                    }
                }
            }
            return new TdxNumber(array);
        }
        /// <summary>
        /// 统计满足条件的周期数.
        /// 用法: COUNT(X, N),统计N周期中满足X条件的周期数,若N&lt;0则从第一个有效值开始.
        /// 例如: COUNT(CLOSE>OPEN,20)表示统计20周期内收阳的周期数
        /// </summary>
        /// <param name="X"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static TdxNumber COUNT(TdxNumber X, int N)
        {
            var array = new double[X.Length];
            int index = 0;
            if (N <= 0) {
                for (int i = 0; i < array.Length; i++) {
                    if (X.GetBoolean(i)) index++;
                    array[i] = index;
                }
            } else {
                for (int i = 0; i < Math.Min(N, array.Length); i++) {
                    if (X.GetBoolean(i)) index++;
                    array[i] = index;
                }
                for (int i = N; i < array.Length; i++) {
                    if (X.GetBoolean(i - N)) index--;
                    if (X.GetBoolean(i)) index++;
                    array[i] = index;
                }
            }
            return new TdxNumber(array);
        }
        /// <summary>
        /// 统计满足条件的周期数.
        /// 用法: COUNT(X, N),统计N周期中满足X条件的周期数,若N&lt;0则从第一个有效值开始.
        /// 例如: COUNT(CLOSE>OPEN,20)表示统计20周期内收阳的周期数
        /// </summary>
        /// <param name="X"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static TdxNumber COUNT(bool[] X, int N)
        {
            var array = new double[X.Length];
            int index = 0;
            if (N <= 0) {
                for (int i = 0; i < array.Length; i++) {
                    if (X[i]) index++;
                    array[i] = index;
                }
            } else {
                for (int i = 0; i < Math.Min(N, array.Length); i++) {
                    if (X[i]) index++;
                    array[i] = index;
                }
                for (int i = N; i < array.Length; i++) {
                    if (X[i - N]) index--;
                    if (X[i]) index++;
                    array[i] = index;
                }
            }
            return new TdxNumber(array);
        }
        /// <summary>
        /// 求最高值.
        /// 用法: HHV(X, N),求N周期内X最高值,N=0则从第一个有效值开始.
        /// 例如: HHV(HIGH,30)表示求30日最高价
        /// </summary>
        /// <param name="X"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static TdxNumber HHV(TdxNumber X, int N)
        {
            var array = new double[X.Length];
            var startIndex = 0;
            while (startIndex < X.Length && double.IsNaN(X[startIndex])) { array[startIndex] = double.NaN; startIndex++; }

            double max = -1;
            if (N <= 0) {
                for (int i = startIndex; i < array.Length; i++) {
                    if (X[i] > max) max = X[i];
                    array[i] = max;
                }
                return array;
            }

            for (int i = startIndex; i < Math.Min(startIndex + N, array.Length); i++) {
                if (X[i] > max) max = X[i];
                array[i] = max;
            }
            for (int i = startIndex + N; i < array.Length; i++) {
                if (X[i] > max) {
                    max = X[i];
                } else if (X[i - N] == max) {
                    max = -1;
                    for (int j = i - N + 1; j <= i; j++) {
                        if (X[j] > max) max = X[j];
                    }
                }
                array[i] = max;
            }
            return new TdxNumber(array);
        }
        /// <summary>
        /// 求上一高点到当前的周期数.
        /// 用法: HHVBARS(X, N) :求N周期内X最高值到当前周期数,N=0表示从第一个有效值开始统计
        /// 例如: HHVBARS(HIGH,0)求得历史新高到到当前的周期数
        /// </summary>
        /// <param name="X"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static TdxNumber HHVBARS(TdxNumber X, int N)
        {
            var array = new double[X.Length];
            N = Math.Max(N, 0);
            var startIndex = 0;
            while (startIndex < X.Length && double.IsNaN(X[startIndex])) { array[startIndex] = double.NaN; startIndex++; }

            double max = -1;
            int index = -1;
            if (N <= 0) {
                for (int i = startIndex; i < array.Length; i++) {
                    index++;
                    if (X[i] >= max) {
                        max = X[i];
                        index = 0;
                    }
                    array[i] = index;
                }
                return array;
            }

            for (int i = startIndex; i < Math.Min(startIndex + N, array.Length); i++) {
                index++;
                if (X[i] >= max) {
                    max = X[i];
                    index = 0;
                }
                array[i] = index;
            }
            for (int i = startIndex + N; i < array.Length; i++) {
                if (X[i] >= max) {
                    max = X[i];
                    index = 0;
                } else if (X[i - N] == max) {
                    max = -1;
                    index = -1;
                    for (int j = i - N + 1; j <= i; j++) {
                        index++;
                        if (X[j] >= max) {
                            max = X[j];
                            index = 0;
                        }
                    }
                } else {
                    index++;
                }
                array[i] = index;
            }
            return new TdxNumber(array);
        }
        /// <summary>
        /// 求最低值.
        /// 用法: LLV(X, N),求N周期内X最低值,N=0则从第一个有效值开始.
        /// 例如: LLV(LOW,0)表示求历史最低价
        /// </summary>
        /// <param name="X"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static TdxNumber LLV(TdxNumber X, int N)
        {
            var array = new double[X.Length];
            var startIndex = 0;
            while (startIndex < X.Length && double.IsNaN(X[startIndex])) { array[startIndex] = double.NaN; startIndex++; }
            double min = double.MaxValue;

            if (N <= 0) {
                for (int i = startIndex; i < array.Length; i++) {
                    if (X[i] > min) min = X[i];
                    array[i] = min;
                }
                return array;
            }

            for (int i = startIndex; i < Math.Min(startIndex + N, array.Length); i++) {
                if (X[i] < min) min = X[i];
                array[i] = min;
            }
            for (int i = startIndex + N; i < array.Length; i++) {
                if (X[i] < min) {
                    min = X[i];
                } else if (X[i - N] == min) {
                    min = double.MaxValue;
                    for (int j = i - N + 1; j <= i; j++) {
                        if (X[j] < min) min = X[j];
                    }
                }
                array[i] = min;
            }
            return new TdxNumber(array);
        }
        /// <summary>
        /// 求上一低点到当前的周期数.
        /// 用法: LLVBARS(X, N) :求N周期内X最低值到当前周期数,N=0表示从第一个有效值开始统计
        /// 例如: LLVBARS(HIGH,20)求得20日最低点到当前的周期数
        /// </summary>
        /// <param name="X"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static TdxNumber LLVBARS(TdxNumber X, int N)
        {
            var array = new double[X.Length];
            var startIndex = 0;
            while (startIndex < X.Length && double.IsNaN(X[startIndex])) { array[startIndex] = double.NaN; startIndex++; }

            double min = double.MaxValue;
            int index = -1;
            if (N <= 0) {
                for (int i = startIndex; i < array.Length; i++) {
                    index++;
                    if (X[i] <= min) {
                        min = X[i];
                        index = 0;
                    }
                    array[i] = index;
                }
                return array;
            }

            for (int i = startIndex; i < Math.Min(startIndex + N, array.Length); i++) {
                index++;
                if (X[i] <= min) {
                    min = X[i];
                    index = 0;
                }
                array[i] = index;
            }
            for (int i = startIndex + N; i < array.Length; i++) {
                if (X[i] <= min) {
                    min = X[i];
                    index = 0;
                } else if (X[i - N] == min) {
                    min = double.MaxValue;
                    index = -1;
                    for (int j = i - N + 1; j <= i; j++) {
                        index++;
                        if (X[j] <= min) {
                            min = X[j];
                            index = 0;
                        }
                    }
                } else {
                    index++;
                }
                array[i] = index;
            }
            return new TdxNumber(array);
        }
        /// <summary>
        /// 求总和.
        /// 用法: SUM(X, N),统计N周期中X的总和,N=0则从第一个有效值开始.
        /// 例如: SUM(VOL,0)表示统计从上市第一天以来的成交量总和
        /// </summary>
        /// <param name="X"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static TdxNumber SUM(TdxNumber X, int N)
        {
            var array = new double[X.Length];
            var startIndex = 0;
            while (startIndex < X.Length && double.IsNaN(X[startIndex])) { array[startIndex] = double.NaN; startIndex++; }

            double sum = 0;
            if (N <= 0) {
                for (int i = startIndex; i < array.Length; i++) {
                    sum += X[i];
                    array[i] = sum;
                }
                return array;
            }
            for (int i = startIndex; i < Math.Min(startIndex + N, array.Length); i++) {
                sum += X[i];
                array[i] = sum;
            }
            for (int i = startIndex + N; i < array.Length; i++) {
                sum += X[i];
                sum -= X[i - N];
                array[i] = sum;
            }
            return new TdxNumber(array);
        }
        /// <summary>
        /// 向前累加到指定值到现在的周期数.
        /// 用法: SUMBARS(X, A) :将X向前累加直到大于等于A,返回这个区间的周期数,若所有的数据都累加后还不能达到A,则返回此时前面的总周期数.
        /// 例如: SUMBARS(VOL, CAPITAL)求完全换手到现在的周期数
        /// </summary>
        /// <param name="X"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static TdxNumber SUMBARS(TdxNumber X, double N)
        {
            var array = new double[X.Length];
            for (int i = array.Length - 1; i >= 0; i--) {
                double sum = 0;
                int index = i;
                int count = 0;
                while (index >= 0 && sum < N) {
                    count++;
                    sum += X[index];
                    index--;
                }
                array[i] = count;
            }
            array.Reverse();
            return new TdxNumber(array);
        }
        /// <summary>
        /// 向前累加到指定值到现在的周期数.
        /// 用法: SUMBARS(X, A) :将X向前累加直到大于等于A,返回这个区间的周期数,若所有的数据都累加后还不能达到A,则返回此时前面的总周期数.
        /// 例如: SUMBARS(VOL, CAPITAL)求完全换手到现在的周期数
        /// </summary>
        /// <param name="X"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static TdxNumber SUMBARS(TdxNumber X, TdxNumber N)
        {
            var array = new double[X.Length];
            for (int i = array.Length - 1; i >= 0; i--) {
                double sum = 0;
                int index = i;
                int count = 0;
                while (index >= 0 && sum < N[i]) {
                    count++;
                    sum += X[index];
                    index--;
                }
                array[i] = count;
            }
            array.Reverse();
            return new TdxNumber(array);
        }
        /// <summary>
        /// 返回简单移动平均
        /// 用法: MA(X, N) :X的N日简单移动平均,算法(X1+X2+X3+...+Xn)/N,N支持变量
        /// </summary>
        /// <param name="X"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static TdxNumber MA(TdxNumber X, int N)
        {
            var array = new double[X.Length];
            var startIndex = 0;
            while (startIndex < X.Length && double.IsNaN(X[startIndex])) { array[startIndex] = double.NaN; startIndex++; }

            double sum = 0;
            for (int i = startIndex; i < Math.Min(startIndex + N - 1, array.Length); i++) {
                sum += X[i];
                array[i] = double.NaN;
            }

            for (int i = startIndex + N - 1; i < array.Length; i++) {
                sum += X[i];
                array[i] = sum / N;
                sum -= X[i - N + 1];
            }
            return new TdxNumber(array);
        }
        /// <summary>
        /// 返回指数移动平均
        /// 用法: EMA(X, N) :X的N日指数移动平均.算法:Y=(X*2+Y'*(N-1))/(N+1)
        /// EMA(X, N)相当于SMA(X, N+1,2),N支持变量
        /// </summary>
        /// <param name="X"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static TdxNumber EMA(TdxNumber X, int N)
        {
            var array = new double[X.Length];
            var startIndex = 0;
            while (startIndex < X.Length && double.IsNaN(X[startIndex])) { array[startIndex] = double.NaN; startIndex++; }

            double Y = X[startIndex];
            array[startIndex] = X[startIndex];
            for (int i = startIndex + 1; i < array.Length; i++) {
                Y = (X[i] * 2 + Y * (N - 1)) / (N + 1);
                array[i] = Y;
            }
            return new TdxNumber(array);
        }
        /// <summary>
        /// 返回平滑移动平均
        /// 用法: MEMA(X, N) :X的N日平滑移动平均,如Y=(X+Y'*(N-1))/N
        /// MEMA(X, N)相当于SMA(X, N,1)
        /// </summary>
        /// <param name="X"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static TdxNumber MEMA(TdxNumber X, int N)
        {
            var array = new double[X.Length];
            var startIndex = 0;
            while (startIndex < X.Length && double.IsNaN(X[startIndex])) { array[startIndex] = double.NaN; startIndex++; }

            double Y = X[startIndex];
            for (int i = startIndex + 1; i < array.Length; i++) {
                Y = (X[i] + Y * (N - 1)) / N;
                array[i] = Y;
            }
            return new TdxNumber(array);
        }
        /// <summary>
        /// 求自适应均线值.
        /// 用法: AMA(X, A),A为自适应系数,必须小于1.
        /// 算法: Y=Y'+A*(X-Y').初值为X
        /// </summary>
        /// <param name="X"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static TdxNumber AMA(TdxNumber X, double N)
        {
            var array = new double[X.Length];
            var startIndex = 0;
            while (startIndex < X.Length && double.IsNaN(X[startIndex])) { array[startIndex] = double.NaN; startIndex++; }

            double Y = X[startIndex];
            array[startIndex] = X[startIndex];
            for (int i = startIndex + 1; i < array.Length; i++) {
                Y += N * (X[i] - Y);
                array[i] = Y;
            }
            return new TdxNumber(array);
        }
        /// <summary>
        /// 求动态移动平均.
        /// 用法: DMA(X, A),求X的动态移动平均.
        /// 算法: Y=A* X+(1-A)*Y',其中Y'表示上一周期Y值,A必须大于0且小于1.A支持变量.
        /// 例如: DMA(CLOSE, VOL/CAPITAL)表示求以换手率作平滑因子的平均价
        /// </summary>
        /// <param name="X"></param>
        /// <param name="A"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static TdxNumber DMA(TdxNumber X, TdxNumber A)
        {
            var array = new double[X.Length];
            var startIndex = 0;
            while (startIndex < X.Length && double.IsNaN(X[startIndex])) { array[startIndex] = double.NaN; startIndex++; }

            double Y = X[startIndex];
            array[startIndex] = X[startIndex];
            for (int i = startIndex + 1; i < array.Length; i++) {
                var a = A[i];
                if (a > 1) { a = 0.9999999; }
                if (a < 0) { a = 0.0000001; }
                Y = a * X[i] + (1 - a) * Y;
                array[i] = Y;
            }
            return new TdxNumber(array);
        }
        /// <summary>
        /// 求动态移动平均.
        /// 用法: DMA(X, A),求X的动态移动平均.
        /// 算法: Y=A* X+(1-A)*Y',其中Y'表示上一周期Y值,A必须大于0且小于1.A支持变量.
        /// 例如: DMA(CLOSE, VOL/CAPITAL)表示求以换手率作平滑因子的平均价
        /// </summary>
        /// <param name="X"></param>
        /// <param name="A"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static TdxNumber DMA(TdxNumber X, double A)
        {
            var array = new double[X.Length];
            var startIndex = 0;
            while (startIndex < X.Length && double.IsNaN(X[startIndex])) { array[startIndex] = double.NaN; startIndex++; }

            double Y = X[startIndex];
            array[startIndex] = X[startIndex];
            for (int i = startIndex + 1; i < array.Length; i++) {
                var a = A;
                if (a > 1) { a = 0.9999999; }
                if (a < 0) { a = 0.0000001; }
                Y = a * X[i] + (1 - a) * Y;
                array[i] = Y;
            }
            return new TdxNumber(array);
        }
        /// <summary>
        /// 返回加权移动平均
        /// 用法: WMA(X, N) :X的N日加权移动平均.算法:Yn=(1*X1+2*X2+...+n* Xn)/(1+2+...+n)
        /// </summary>
        /// <param name="X"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static TdxNumber WMA(TdxNumber X, int N)
        {
            var array = new double[X.Length];
            var temp = (1 + N) * N / 2;
            var startIndex = 0;
            while (startIndex < X.Length && double.IsNaN(X[startIndex])) { array[startIndex] = double.NaN; startIndex++; }
            for (int i = startIndex; i < Math.Min(startIndex + N, array.Length); i++) { array[i] = double.NaN; }
            for (int i = startIndex + N; i < array.Length; i++) {
                double sum = 0;
                for (int j = 1; j <= N; j++) {
                    sum += X[i - N + j] * j;
                }
                array[i] = sum / temp;
            }
            return new TdxNumber(array);
        }
        /// <summary>
        /// 过滤连续出现的信号.
        /// 用法: FILTER(X, N) :X满足条件后,将其后N周期内的数据置为0,N为常量.
        /// 例如: FILTER(CLOSE>OPEN,5)查找阳线,5天内再次出现的阳线不被记录在内
        /// </summary>
        /// <param name="X"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static TdxNumber FILTER(TdxNumber X, int N)
        {
            var array = new double[X.Length];
            var skipCount = 0;
            for (int i = 0; i < array.Length; i++) {
                if (skipCount > 0) {
                    //array[i] = 0;
                    skipCount--;
                    continue;
                }
                if (X.GetBoolean(i)) {
                    array[i] = 1;
                    skipCount = N;
                    //} else {
                    //    array[i] = 0;
                }
            }
            return new TdxNumber(array);
        }
        /// <summary>
        /// 过滤连续出现的信号.
        /// 用法: FILTER(X, N) :X满足条件后,将其后N周期内的数据置为0,N为常量.
        /// 例如: FILTER(CLOSE>OPEN,5)查找阳线,5天内再次出现的阳线不被记录在内
        /// </summary>
        /// <param name="X"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static TdxNumber FILTER(bool[] X, int N)
        {
            var array = new double[X.Length];
            var skipCount = 0;
            for (int i = 0; i < array.Length; i++) {
                if (skipCount > 0) {
                    //array[i] = 0;
                    skipCount--;
                    continue;
                }
                if (X[i]) {
                    array[i] = 1;
                    skipCount = N;
                    //} else {
                    //    array[i] = 0;
                }
            }
            return new TdxNumber(array);
        }
        /// <summary>
        /// 反向过滤连续出现的信号.
        /// 用法: FILTERX(X, N) :X满足条件后,将其前N周期内的数据置为0,N为常量.
        /// 例如: FILTERX(CLOSE>OPEN,5)查找阳线,前5天内出现过的阳线不被记录在内
        /// </summary>
        /// <param name="X"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static TdxNumber FILTERX(TdxNumber X, int N)
        {
            var array = new double[X.Length];
            var skipCount = 0;
            for (int i = array.Length - 1; i >= 0; i--) {
                if (skipCount > 0) {
                    //array[i] = 0;
                    skipCount--;
                    continue;
                }
                if (X.GetBoolean(i)) {
                    array[i] = 1;
                    skipCount = N;
                    //} else {
                    //    array[i] = 0;
                }
            }
            return new TdxNumber(array);
        }
        /// <summary>
        /// 反向过滤连续出现的信号.
        /// 用法: FILTERX(X, N) :X满足条件后,将其前N周期内的数据置为0,N为常量.
        /// 例如: FILTERX(CLOSE>OPEN,5)查找阳线,前5天内出现过的阳线不被记录在内
        /// </summary>
        /// <param name="X"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static TdxNumber FILTERX(bool[] X, int N)
        {
            var array = new double[X.Length];
            var skipCount = 0;
            for (int i = array.Length - 1; i >= 0; i--) {
                if (skipCount > 0) {
                    //array[i] = 0;
                    skipCount--;
                    continue;
                }
                if (X[i]) {
                    array[i] = 1;
                    skipCount = N;
                    //} else {
                    //    array[i] = 0;
                }
            }
            return new TdxNumber(array);
        }
        /// <summary>
        /// 求高值名次.
        /// 用法: HOD(X, N) :求当前X数据是N周期内的第几个高值,N=0则从第一个有效值开始.
        /// 例如: HOD(HIGH,20)返回是20日的第几个高价
        /// </summary>
        /// <param name="X"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static TdxNumber HOD(TdxNumber X, int N)
        {
            var array = new double[X.Length];
            var startIndex = 0;
            while (startIndex < X.Length && double.IsNaN(X[startIndex])) { array[startIndex] = double.NaN; startIndex++; }

            List<double> temp = new List<double>(Math.Min(400, N)); // 从大到小
            if (N == 0) {
                for (int i = startIndex; i < array.Length; i++) {
                    var x = X[i];
                    var sort = InsertArray_Max2Min(temp, x);
                    array[i] = sort;
                }
                return array;
            }
            for (int i = startIndex; i < Math.Min(startIndex + N, array.Length); i++) {
                var x = X[i];
                var sort = InsertArray_Max2Min(temp, x);
                array[i] = sort;
            }
            for (int i = startIndex + N; i < array.Length; i++) {
                var x = X[i];
                temp.Remove(X[i - N]);
                var sort = InsertArray_Max2Min(temp, x);
                array[i] = sort;
            }
            return new TdxNumber(array);
        }
        /// <summary>
        /// 求低值名次.
        /// 用法: LOD(X, N) :求当前X数据是N周期内的第几个低值,N=0则从第一个有效值开始.
        /// 例如: LOD(LOW,20)返回是20日的第几个低价
        /// </summary>
        /// <param name="X"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static TdxNumber LOD(TdxNumber X, int N)
        {
            var array = new double[X.Length];
            var startIndex = 0;
            while (startIndex < X.Length && double.IsNaN(X[startIndex])) { array[startIndex] = double.NaN; startIndex++; }
            List<double> temp = new List<double>(Math.Min(400, N)); // 从大到小

            if (N == 0) {
                for (int i = startIndex; i < array.Length; i++) {
                    var x = X[i];
                    var sort = InsertArray_Min2Max(temp, x);
                    array[i] = sort;
                }
                return array;
            }
            for (int i = startIndex; i < Math.Min(startIndex + N, array.Length); i++) {
                var x = X[i];
                var sort = InsertArray_Min2Max(temp, x);
                array[i] = sort;
            }
            for (int i = startIndex + N; i < array.Length; i++) {
                var x = X[i];
                temp.Remove(X[i - N]);
                var sort = InsertArray_Min2Max(temp, x);
                array[i] = sort;
            }
            return new TdxNumber(array);
        }
        /// <summary>
        /// 求累乘.
        /// 用法: MULAR(X, N),统计N周期中X的乘积.N=0则从第一个有效值开始.
        /// 例如: MULAR(C/REF(C,1),0)表示统计从上市第一天以来的复利
        /// </summary>
        /// <param name="X"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static TdxNumber MULAR(TdxNumber X, int N)
        {
            var array = new double[X.Length];
            var startIndex = 0;
            while (startIndex < X.Length && double.IsNaN(X[startIndex])) { array[startIndex] = double.NaN; startIndex++; }
            double sum = 1;
            if (N == 0) {
                for (int i = startIndex; i < array.Length; i++) {
                    sum *= X[i];
                    array[i] = sum;
                }
                return array;
            }
            for (int i = startIndex; i < Math.Min(startIndex + N - 1, array.Length); i++) {
                sum *= X[i];
                array[i] = sum;
            }

            for (int i = startIndex + N - 1; i < array.Length; i++) {
                sum *= X[i];
                array[i] = sum;
                sum /= X[i - N + 1];
            }
            return new TdxNumber(array);
        }
        /// <summary>
        /// 返回周期数内是否连涨.
        /// 用法: UPNDAY(CLOSE, M) 表示连涨M个周期,M为常量
        /// </summary>
        /// <param name="X"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static TdxNumber UPNDAY(TdxNumber X, int N)
        {
            var array = new double[X.Length];
            var startIndex = 0;
            while (startIndex < X.Length && double.IsNaN(X[startIndex])) { array[startIndex] = double.NaN; startIndex++; }
            var temp = 0;
            for (int i = startIndex + 1; i < Math.Min(startIndex + N, array.Length); i++) {
                if (X[i] > X[i - 1]) {
                    temp++;
                } else {
                    temp = 0;
                }
            }
            for (int i = startIndex + N; i < array.Length; i++) {
                if (X[i] > X[i - 1]) {
                    temp++;
                    if (temp >= N) { array[i] = 1; }
                } else {
                    temp = 0;
                }
            }
            return new TdxNumber(array);
        }
        /// <summary>
        /// 返回周期数内是否连跌.
        /// 用法: DOWNNDAY(CLOSE, M) 表示连跌M个周期,M为常量
        /// </summary>
        /// <param name="X"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static TdxNumber DOWNNDAY(TdxNumber X, int N)
        {
            var array = new double[X.Length];
            var startIndex = 0;
            while (startIndex < X.Length && double.IsNaN(X[startIndex])) { array[startIndex] = double.NaN; startIndex++; }
            var temp = 0;
            for (int i = startIndex + 1; i < Math.Min(startIndex + N, array.Length); i++) {
                if (X[i] < X[i - 1]) {
                    temp++;
                } else {
                    temp = 0;
                }
            }
            for (int i = startIndex + N; i < array.Length; i++) {
                if (X[i] < X[i - 1]) {
                    temp++;
                    if (temp >= N) { array[i] = 1; }
                } else {
                    temp = 0;
                }
            }
            return new TdxNumber(array);
        }
        /// <summary>
        /// 是否存在.
        /// 例如: EXIST(CLOSE>OPEN,10) 表示10日内存在着阳线,第2个参数为常量
        /// </summary>
        /// <param name="X"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static TdxNumber EXIST(TdxNumber X, int N)
        {
            var array = new double[X.Length];
            for (int i = 0; i < array.Length; i++) {
                //bool b = false;
                for (int j = i; j >= Math.Max(i - N + 1, 0); j--) {
                    if (X.GetBoolean(j)) {
                        array[i] = 1;
                        //b = true;
                        break;
                    }
                }
                //array.Add(b ? 1 : 0);
            }
            return new TdxNumber(array);
        }
        /// <summary>
        /// 是否存在.
        /// 例如: EXIST(CLOSE>OPEN,10) 表示10日内存在着阳线,第2个参数为常量
        /// </summary>
        /// <param name="X"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static TdxNumber EXIST(bool[] X, int N)
        {
            var array = new double[X.Length];
            for (int i = 0; i < array.Length; i++) {
                //bool b = false;
                for (int j = i; j >= Math.Max(i - N + 1, 0); j--) {
                    if (X[j]) {
                        array[i] = 1;
                        //b = true;
                        break;
                    }
                }
                //array.Add(b ? 1 : 0);
            }
            return new TdxNumber(array);
        }
        /// <summary>
        /// 一直存在.
        /// 例如: EVERY(CLOSE>OPEN, N) 表示N日内一直阳线(N应大于0, 小于总周期数, N支持变量)
        /// </summary>
        /// <param name="X"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static TdxNumber EVERY(TdxNumber X, int N)
        {
            var array = new double[X.Length];
            var temp = 0;
            for (int i = 0; i < Math.Min(N, array.Length); i++) {
                if (X.GetBoolean(i)) {
                    temp++;
                } else {
                    temp = 0;
                }
            }
            for (int i = N; i < array.Length; i++) {
                if (X.GetBoolean(i)) {
                    temp++;
                    if (temp >= N) {
                        array[i] = 1;
                    }
                } else {
                    temp = 0;
                }
            }
            return new TdxNumber(array);
        }
        /// <summary>
        /// 一直存在.
        /// 例如: EVERY(CLOSE>OPEN, N) 表示N日内一直阳线(N应大于0, 小于总周期数, N支持变量)
        /// </summary>
        /// <param name="X"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static TdxNumber EVERY(bool[] X, int N)
        {
            var array = new double[X.Length];
            var temp = 0;
            for (int i = 0; i < Math.Min(N, array.Length); i++) {
                if (X[i]) {
                    temp++;
                } else {
                    temp = 0;
                }
            }
            for (int i = N; i < array.Length; i++) {
                if (X[i]) {
                    temp++;
                    if (temp >= N) {
                        array[i] = 1;
                    }
                } else {
                    temp = 0;
                }
            }
            return new TdxNumber(array);
        }
        /// <summary>
        /// AVEDEV(X,N) 返回平均绝对偏差
        /// </summary>
        /// <param name="X"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static TdxNumber AVEDEV(TdxNumber X, int N)
        {
            var array = new double[X.Length];
            var startIndex = 0;
            while (startIndex < X.Length && double.IsNaN(X[startIndex])) { array[startIndex] = double.NaN; startIndex++; }
            List<double> temp = new List<double>(N);

            for (int i = startIndex; i < Math.Min(startIndex + N - 1, array.Length); i++) {
                temp.Add(X[i]);
            }
            for (int i = startIndex + N - 1; i < array.Length; i++) {
                temp.Add(X[i]);
                double avg = temp.Average();
                double sum = 0;
                for (int j = 0; j < temp.Count; j++) {
                    sum += Math.Abs(temp[j] - avg);
                }
                array[i] = sum / temp.Count;
                temp.RemoveAt(0);
            }
            return new TdxNumber(array);
        }
        /// <summary>
        /// DEVSQ(X,N) 返回数据偏差平方和
        /// </summary>
        /// <param name="X"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static TdxNumber DEVSQ(TdxNumber X, int N)
        {
            var array = new double[X.Length];
            var startIndex = 0;
            while (startIndex < X.Length && double.IsNaN(X[startIndex])) { array[startIndex] = double.NaN; startIndex++; }
            List<double> temp = new List<double>(N);

            for (int i = startIndex; i < Math.Min(startIndex + N - 1, array.Length); i++) {
                temp.Add(X[i]);
            }
            for (int i = startIndex + N - 1; i < array.Length; i++) {
                temp.Add(X[i]);
                double avg = temp.Average();
                double sum = 0;
                for (int j = 0; j < temp.Count; j++) {
                    sum += (temp[j] - avg) * (temp[j] - avg);
                }
                array[i] = sum;

                temp.RemoveAt(0);
            }
            return new TdxNumber(array);
        }
        /// <summary>
        /// FORCAST(X,N) 返回线性回归预测值,N支持变量
        /// </summary>
        /// <param name="X"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static TdxNumber FORCAST(TdxNumber X, int N)
        {
            var array = new double[X.Length];
            var startIndex = 0;
            while (startIndex < X.Length && double.IsNaN(X[startIndex])) { array[startIndex] = double.NaN; startIndex++; }
            double sum = 0;
            var temp = 0;
            for (int i = startIndex; i < Math.Min(startIndex + N, array.Length); i++) {
                sum += X[i];
                temp += (i + 1);
            }
            for (int i = startIndex + N; i < array.Length; i++) {
                sum += X[i];
                sum -= X[i - N];
                var ma = sum / N;
                double sum2 = 0;
                for (int j = 1; j <= N; j++) {
                    sum2 += X[i - N + j] * j;
                }
                var wma = sum2 / temp;
                array[i] = 3 * wma - 2 * ma;
            }
            return new TdxNumber(array);
        }
        /// <summary>
        /// SLOPE(X,N) 返回线性回归斜率,N支持变量
        /// </summary>
        /// <param name="X"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static TdxNumber SLOPE(TdxNumber X, int N)
        {
            var array = new double[X.Length];
            var startIndex = 0;
            while (startIndex < X.Length && double.IsNaN(X[startIndex])) { array[startIndex] = double.NaN; startIndex++; }
            double averagex = (N - 1) / (double)2;
            double denominator = 0;
            for (int i = startIndex; i < Math.Min(startIndex + N, array.Length); i++) {
                denominator += (i - averagex) * (i - averagex);
            }

            List<double> temp = new List<double>(N);

            for (int i = startIndex; i < Math.Min(startIndex + N - 1, array.Length); i++) {
                temp.Add(X[i]);
            }
            for (int i = startIndex + N - 1; i < array.Length; i++) {
                temp.Add(X[i]);

                var t = LinearRegressionCoefficient(temp, averagex, denominator);
                array[i] = t;

                temp.RemoveAt(0);
            }
            return new TdxNumber(array);
        }
        /// <summary>
        /// STD(X,N) 返回估算标准差,N支持变量
        /// </summary>
        /// <param name="X"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static TdxNumber STD(TdxNumber X, int N)
        {
            var array = new double[X.Length];
            var startIndex = 0;
            while (startIndex < X.Length && double.IsNaN(X[startIndex])) { array[startIndex] = double.NaN; startIndex++; }
            List<double> temp = new List<double>(N);

            for (int i = startIndex; i < Math.Min(startIndex + N - 1, array.Length); i++) {
                temp.Add(X[i]);
            }
            for (int i = startIndex + N - 1; i < array.Length; i++) {
                temp.Add(X[i]);
                double avg = temp.Average();
                double sum = 0;
                for (int j = 0; j < temp.Count; j++) {
                    sum += (temp[j] - avg) * (temp[j] - avg);
                }
                array[i] = Math.Sqrt(sum / (temp.Count - 1));
                temp.RemoveAt(0);
            }
            return new TdxNumber(array);
        }
        /// <summary>
        /// STDP(X,N) 返回总体标准差,N支持变量
        /// </summary>
        /// <param name="X"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static TdxNumber STDP(TdxNumber X, int N)
        {
            var array = new double[X.Length];
            var startIndex = 0;
            while (startIndex < X.Length && double.IsNaN(X[startIndex])) { array[startIndex] = double.NaN; startIndex++; }
            List<double> temp = new List<double>(N);

            for (int i = startIndex; i < Math.Min(startIndex + N - 1, array.Length); i++) {
                temp.Add(X[i]);
            }
            for (int i = startIndex + N - 1; i < array.Length; i++) {
                temp.Add(X[i]);
                double avg = temp.Average();
                double sum = 0;
                for (int j = 0; j < temp.Count; j++) {
                    sum += (temp[j] - avg) * (temp[j] - avg);
                }
                array[i] = Math.Sqrt(sum / temp.Count);
                temp.RemoveAt(0);
            }
            return new TdxNumber(array);
        }
        /// <summary>
        /// VAR(X,N) 返回估算样本方差,N支持变量
        /// </summary>
        /// <param name="X"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static TdxNumber VAR(TdxNumber X, int N)
        {
            var array = new double[X.Length];
            var startIndex = 0;
            while (startIndex < X.Length && double.IsNaN(X[startIndex])) { array[startIndex] = double.NaN; startIndex++; }
            List<double> temp = new List<double>(N);

            for (int i = startIndex; i < Math.Min(startIndex + N - 1, array.Length); i++) {
                temp.Add(X[i]);
            }
            for (int i = startIndex + N - 1; i < array.Length; i++) {
                temp.Add(X[i]);

                double sum = 0;
                double sum2 = 0;
                for (int j = 0; j < temp.Count; j++) {
                    sum += temp[j] * temp[j];
                    sum2 += temp[j];
                }
                var t = (temp.Count * sum - sum2 * sum2) / temp.Count / (temp.Count - 1);
                array[i] = t;

                temp.RemoveAt(0);
            }
            return new TdxNumber(array);
        }
        /// <summary>
        /// VARP(X,N) 返回总体样本方差,N支持变量
        /// </summary>
        /// <param name="X"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static TdxNumber VARP(TdxNumber X, int N)
        {
            var array = new double[X.Length];
            var startIndex = 0;
            while (startIndex < X.Length && double.IsNaN(X[startIndex])) { array[startIndex] = double.NaN; startIndex++; }
            List<double> temp = new List<double>(N);

            for (int i = startIndex; i < Math.Min(startIndex + N - 1, array.Length); i++) {
                temp.Add(X[i]);
            }
            for (int i = startIndex + N - 1; i < array.Length; i++) {
                temp.Add(X[i]);

                double sum = 0;
                double avg = temp.Average();
                for (int j = 0; j < temp.Count; j++) {
                    sum += (avg - temp[j]) * (avg - temp[j]);
                }
                var t = sum / temp.Count;
                array[i] = t;
                temp.RemoveAt(0);
            }
            return new TdxNumber(array);
        }
        /// <summary>
        /// VALUEWHEN(COND,X) 
        /// 当COND条件成立时,取X的当前值,否则取VALUEWHEN的上个值.
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <returns></returns>
        public static TdxNumber VALUEWHEN(TdxNumber X, double Y)
        {
            var array = new double[X.Length];
            var startIndex = 0;
            while (startIndex < X.Length) { array[startIndex] = double.NaN; startIndex++; }
            double last = -1;
            for (int i = startIndex; i < array.Length; i++) {
                if (X.GetBoolean(i)) {
                    last = Y;
                }
                array[i] = last;
            }
            return new TdxNumber(array);
        }
        /// <summary>
        /// VALUEWHEN(COND,X) 
        /// 当COND条件成立时,取X的当前值,否则取VALUEWHEN的上个值.
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <returns></returns>
        public static TdxNumber VALUEWHEN(bool[] X, double Y)
        {
            var array = new double[X.Length];
            var startIndex = 0;
            while (startIndex < X.Length) { array[startIndex] = double.NaN; startIndex++; }
            double last = -1;
            for (int i = startIndex; i < array.Length; i++) {
                if (X[i]) {
                    last = Y;
                }
                array[i] = last;
            }
            return new TdxNumber(array);
        }
        /// <summary>
        /// VALUEWHEN(COND,X) 
        /// 当COND条件成立时,取X的当前值,否则取VALUEWHEN的上个值.
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <returns></returns>
        public static TdxNumber VALUEWHEN(TdxNumber X, TdxNumber Y)
        {
            var array = new double[X.Length];
            var startIndex = 0;
            while (startIndex < X.Length && double.IsNaN(Y[startIndex])) { array[startIndex] = double.NaN; startIndex++; }
            double last = -1;
            for (int i = startIndex; i < array.Length; i++) {
                if (X.GetBoolean(i)) {
                    last = Y[i];
                }
                array[i] = last;
            }
            return new TdxNumber(array);
        }
        /// <summary>
        /// VALUEWHEN(COND,X) 
        /// 当COND条件成立时,取X的当前值,否则取VALUEWHEN的上个值.
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <returns></returns>
        public static TdxNumber VALUEWHEN(bool[] X, TdxNumber Y)
        {
            var array = new double[X.Length];
            var startIndex = 0;
            while (startIndex < X.Length && double.IsNaN(Y[startIndex])) { array[startIndex] = double.NaN; startIndex++; }
            double last = -1;
            for (int i = startIndex; i < array.Length; i++) {
                if (X[i]) {
                    last = Y[i];
                }
                array[i] = last;
            }
            return new TdxNumber(array);
        }
        /// <summary>
        /// 根据条件求不同的值.
        /// 用法: IF(X, A, B)若X不为0则返回A,否则返回B
        /// 例如: IF(CLOSE>OPEN, HIGH, LOW)表示该周期收阳则返回最高值,否则返回最低值
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="Z"></param>
        /// <returns></returns>
        public static TdxNumber IF(TdxNumber X, TdxNumber Y, TdxNumber Z)
        {
            var array = new double[X.Length];
            for (int i = 0; i < array.Length; i++) {
                if (X.GetBoolean(i)) {
                    array[i] = Y[i];
                } else {
                    array[i] = Z[i];
                }
            }
            return new TdxNumber(array);
        }
        /// <summary>
        /// 根据条件求不同的值.
        /// 用法: IF(X, A, B)若X不为0则返回A,否则返回B
        /// 例如: IF(CLOSE>OPEN, HIGH, LOW)表示该周期收阳则返回最高值,否则返回最低值
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="Z"></param>
        /// <returns></returns>
        public static TdxNumber IF(bool[] X, TdxNumber Y, TdxNumber Z)
        {
            var array = new double[X.Length];
            for (int i = 0; i < array.Length; i++) {
                if (X[i]) {
                    array[i] = Y[i];
                } else {
                    array[i] = Z[i];
                }
            }
            return new TdxNumber(array);
        }
        /// <summary>
        /// 根据条件求不同的值.
        /// 用法: IF(X, A, B)若X不为0则返回A,否则返回B
        /// 例如: IF(CLOSE>OPEN, HIGH, LOW)表示该周期收阳则返回最高值,否则返回最低值
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="Z"></param>
        /// <returns></returns>
        public static TdxNumber IF(TdxNumber X, TdxNumber Y, double Z)
        {
            var array = new double[X.Length];
            for (int i = 0; i < array.Length; i++) {
                if (X.GetBoolean(i)) {
                    array[i] = Y[i];
                } else {
                    array[i] = Z;
                }
            }
            return new TdxNumber(array);
        }
        /// <summary>
        /// 根据条件求不同的值.
        /// 用法: IF(X, A, B)若X不为0则返回A,否则返回B
        /// 例如: IF(CLOSE>OPEN, HIGH, LOW)表示该周期收阳则返回最高值,否则返回最低值
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="Z"></param>
        /// <returns></returns>
        public static TdxNumber IF(bool[] X, TdxNumber Y, double Z)
        {
            var array = new double[X.Length];
            for (int i = 0; i < array.Length; i++) {
                if (X[i]) {
                    array[i] = Y[i];
                } else {
                    array[i] = Z;
                }
            }
            return new TdxNumber(array);
        }
        /// <summary>
        /// 根据条件求不同的值.
        /// 用法: IF(X, A, B)若X不为0则返回A,否则返回B
        /// 例如: IF(CLOSE>OPEN, HIGH, LOW)表示该周期收阳则返回最高值,否则返回最低值
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="Z"></param>
        /// <returns></returns>
        public static TdxNumber IF(TdxNumber X, double Y, TdxNumber Z)
        {
            var array = new double[X.Length];
            for (int i = 0; i < array.Length; i++) {
                if (X.GetBoolean(i)) {
                    array[i] = Y;
                } else {
                    array[i] = Z[i];
                }
            }
            return new TdxNumber(array);
        }
        /// <summary>
        /// 根据条件求不同的值.
        /// 用法: IF(X, A, B)若X不为0则返回A,否则返回B
        /// 例如: IF(CLOSE>OPEN, HIGH, LOW)表示该周期收阳则返回最高值,否则返回最低值
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="Z"></param>
        /// <returns></returns>
        public static TdxNumber IF(bool[] X, double Y, TdxNumber Z)
        {
            var array = new double[X.Length];
            for (int i = 0; i < array.Length; i++) {
                if (X[i]) {
                    array[i] = Y;
                } else {
                    array[i] = Z[i];
                }
            }
            return new TdxNumber(array);
        }
        /// <summary>
        /// 根据条件求不同的值.
        /// 用法: IF(X, A, B)若X不为0则返回A,否则返回B
        /// 例如: IF(CLOSE>OPEN, HIGH, LOW)表示该周期收阳则返回最高值,否则返回最低值
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="Z"></param>
        /// <returns></returns>
        public static TdxNumber IF(TdxNumber X, double Y, double Z)
        {
            var array = new double[X.Length];
            for (int i = 0; i < array.Length; i++) {
                if (X.GetBoolean(i)) {
                    array[i] = Y;
                } else {
                    array[i] = Z;
                }
            }
            return new TdxNumber(array);
        }
        /// <summary>
        /// 根据条件求不同的值.
        /// 用法: IF(X, A, B)若X不为0则返回A,否则返回B
        /// 例如: IF(CLOSE>OPEN, HIGH, LOW)表示该周期收阳则返回最高值,否则返回最低值
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="Z"></param>
        /// <returns></returns>
        public static TdxNumber IF(bool[] X, double Y, double Z)
        {
            var array = new double[X.Length];
            for (int i = 0; i < array.Length; i++) {
                if (X[i]) {
                    array[i] = Y;
                } else {
                    array[i] = Z;
                }
            }
            return new TdxNumber(array);
        }
        /// <summary>
        /// 根据条件求不同的值,同IF判断相反.
        /// 用法: IFN(X, A, B)若X不为0则返回B,否则返回A
        /// 例如: IFN(CLOSE>OPEN, HIGH, LOW)表示该周期收阴则返回最高值,否则返回最低值
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="Z"></param>
        /// <returns></returns>
        public static TdxNumber IFN(TdxNumber X, TdxNumber Y, TdxNumber Z)
        {
            var array = new double[X.Length];
            for (int i = 0; i < array.Length; i++) {
                if (X.GetBoolean(i) == false) {
                    array[i] = Y[i];
                } else {
                    array[i] = Z[i];
                }
            }
            return new TdxNumber(array);
        }
        /// <summary>
        /// 根据条件求不同的值,同IF判断相反.
        /// 用法: IFN(X, A, B)若X不为0则返回B,否则返回A
        /// 例如: IFN(CLOSE>OPEN, HIGH, LOW)表示该周期收阴则返回最高值,否则返回最低值
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="Z"></param>
        /// <returns></returns>
        public static TdxNumber IFN(bool[] X, TdxNumber Y, TdxNumber Z)
        {
            var array = new double[X.Length];
            for (int i = 0; i < array.Length; i++) {
                if (X[i] == false) {
                    array[i] = Y[i];
                } else {
                    array[i] = Z[i];
                }
            }
            return new TdxNumber(array);
        }
        /// <summary>
        /// 根据条件求不同的值,同IF判断相反.
        /// 用法: IFN(X, A, B)若X不为0则返回B,否则返回A
        /// 例如: IFN(CLOSE>OPEN, HIGH, LOW)表示该周期收阴则返回最高值,否则返回最低值
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="Z"></param>
        /// <returns></returns>
        public static TdxNumber IFN(TdxNumber X, TdxNumber Y, double Z)
        {
            var array = new double[X.Length];
            for (int i = 0; i < array.Length; i++) {
                if (X.GetBoolean(i) == false) {
                    array[i] = Y[i];
                } else {
                    array[i] = Z;
                }
            }
            return new TdxNumber(array);
        }
        /// <summary>
        /// 根据条件求不同的值,同IF判断相反.
        /// 用法: IFN(X, A, B)若X不为0则返回B,否则返回A
        /// 例如: IFN(CLOSE>OPEN, HIGH, LOW)表示该周期收阴则返回最高值,否则返回最低值
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="Z"></param>
        /// <returns></returns>
        public static TdxNumber IFN(bool[] X, TdxNumber Y, double Z)
        {
            var array = new double[X.Length];
            for (int i = 0; i < array.Length; i++) {
                if (X[i] == false) {
                    array[i] = Y[i];
                } else {
                    array[i] = Z;
                }
            }
            return new TdxNumber(array);
        }
        /// <summary>
        /// 根据条件求不同的值,同IF判断相反.
        /// 用法: IFN(X, A, B)若X不为0则返回B,否则返回A
        /// 例如: IFN(CLOSE>OPEN, HIGH, LOW)表示该周期收阴则返回最高值,否则返回最低值
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="Z"></param>
        /// <returns></returns>
        public static TdxNumber IFN(TdxNumber X, double Y, TdxNumber Z)
        {
            var array = new double[X.Length];
            for (int i = 0; i < array.Length; i++) {
                if (X.GetBoolean(i) == false) {
                    array[i] = Y;
                } else {
                    array[i] = Z[i];
                }
            }
            return new TdxNumber(array);
        }
        /// <summary>
        /// 根据条件求不同的值,同IF判断相反.
        /// 用法: IFN(X, A, B)若X不为0则返回B,否则返回A
        /// 例如: IFN(CLOSE>OPEN, HIGH, LOW)表示该周期收阴则返回最高值,否则返回最低值
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="Z"></param>
        /// <returns></returns>
        public static TdxNumber IFN(bool[] X, double Y, TdxNumber Z)
        {
            var array = new double[X.Length];
            for (int i = 0; i < array.Length; i++) {
                if (X[i] == false) {
                    array[i] = Y;
                } else {
                    array[i] = Z[i];
                }
            }
            return new TdxNumber(array);
        }
        /// <summary>
        /// 根据条件求不同的值,同IF判断相反.
        /// 用法: IFN(X, A, B)若X不为0则返回B,否则返回A
        /// 例如: IFN(CLOSE>OPEN, HIGH, LOW)表示该周期收阴则返回最高值,否则返回最低值
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="Z"></param>
        /// <returns></returns>
        public static TdxNumber IFN(TdxNumber X, double Y, double Z)
        {
            var array = new double[X.Length];
            for (int i = 0; i < array.Length; i++) {
                if (X.GetBoolean(i) == false) {
                    array[i] = Y;
                } else {
                    array[i] = Z;
                }
            }
            return new TdxNumber(array);
        }
        /// <summary>
        /// 根据条件求不同的值,同IF判断相反.
        /// 用法: IFN(X, A, B)若X不为0则返回B,否则返回A
        /// 例如: IFN(CLOSE>OPEN, HIGH, LOW)表示该周期收阴则返回最高值,否则返回最低值
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="Z"></param>
        /// <returns></returns>
        public static TdxNumber IFN(bool[] X, double Y, double Z)
        {
            var array = new double[X.Length];
            for (int i = 0; i < array.Length; i++) {
                if (X[i] == false) {
                    array[i] = Y;
                } else {
                    array[i] = Z;
                }
            }
            return new TdxNumber(array);
        }


        /// <summary>
        /// RANGE(A,B,C):A在B和C范围之间,B &lt; A &lt; C
        /// 用法: RANGE(A, B, C)表示A大于B同时小于C时返回1,否则返回0
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="Z"></param>
        /// <returns></returns>
        public static TdxNumber RANGE(TdxNumber X, TdxNumber Y, TdxNumber Z)
        {
            var array = new double[X.Length];
            var startIndex = 0;
            while (startIndex < X.Length && double.IsNaN(X[startIndex]) && double.IsNaN(Y[startIndex]) && double.IsNaN(Z[startIndex])) { array[startIndex] = double.NaN; startIndex++; }

            for (int i = startIndex + 1; i < array.Length; i++) {
                if (Y[i] < X[i] && X[i] < Z[i]) {
                    array[i] = 1;
                } else {
                    array[i] = 0;
                }
            }
            return new TdxNumber(array);
        }
        /// <summary>
        /// RANGE(A,B,C):A在B和C范围之间,B&lt;A&lt;C
        /// 用法: RANGE(A, B, C)表示A大于B同时小于C时返回1,否则返回0
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="Z"></param>
        /// <returns></returns>
        public static TdxNumber RANGE(TdxNumber X, TdxNumber Y, double Z)
        {
            var array = new double[X.Length];
            var startIndex = 0;
            while (startIndex < X.Length && double.IsNaN(X[startIndex]) && double.IsNaN(Y[startIndex])) { array[startIndex] = double.NaN; startIndex++; }

            for (int i = startIndex + 1; i < array.Length; i++) {
                if (Y[i] < X[i] && X[i] < Z) {
                    array[i] = 1;
                } else {
                    array[i] = 0;
                }
            }
            return new TdxNumber(array);
        }
        /// <summary>
        /// RANGE(A,B,C):A在B和C范围之间,B&lt;A&lt;C
        /// 用法: RANGE(A, B, C)表示A大于B同时小于C时返回1,否则返回0
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="Z"></param>
        /// <returns></returns>
        public static TdxNumber RANGE(TdxNumber X, double Y, TdxNumber Z)
        {
            var array = new double[X.Length];
            var startIndex = 0;
            while (startIndex < X.Length && double.IsNaN(X[startIndex]) && double.IsNaN(Z[startIndex])) { array[startIndex] = double.NaN; startIndex++; }

            for (int i = startIndex + 1; i < array.Length; i++) {
                if (Y < X[i] && X[i] < Z[i]) {
                    array[i] = 1;
                } else {
                    array[i] = 0;
                }
            }
            return new TdxNumber(array);
        }
        /// <summary>
        /// RANGE(A,B,C):A在B和C范围之间,B&lt;A&lt;C
        /// 用法: RANGE(A, B, C)表示A大于B同时小于C时返回1,否则返回0
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="Z"></param>
        /// <returns></returns>
        public static TdxNumber RANGE(TdxNumber X, double Y, double Z)
        {
            var array = new double[X.Length];
            var startIndex = 0;
            while (startIndex < X.Length && double.IsNaN(X[startIndex])) { array[startIndex] = double.NaN; startIndex++; }

            for (int i = startIndex + 1; i < array.Length; i++) {
                if (Y < X[i] && X[i] < Z) {
                    array[i] = 1;
                } else {
                    array[i] = 0;
                }
            }
            return new TdxNumber(array);
        }
        /// <summary>
        /// 介于.
        /// 用法: BETWEEN(A, B, C)表示A处于B和C之间时返回1,B &lt; A &lt; C或C &lt; A &lt;B, 否则返回0
        /// 例如: BETWEEN(CLOSE, MA(CLOSE,10),MA(CLOSE,5))表示收盘价介于5日均线和10日均线之间
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="Z"></param>
        /// <returns></returns>
        public static TdxNumber BETWEEN(TdxNumber X, TdxNumber Y, TdxNumber Z)
        {
            var array = new double[X.Length];
            var startIndex = 0;
            while (startIndex < X.Length && double.IsNaN(X[startIndex]) && double.IsNaN(Y[startIndex]) && double.IsNaN(Z[startIndex])) { array[startIndex] = double.NaN; startIndex++; }

            for (int i = startIndex + 1; i < array.Length; i++) {
                if (Y[i] <= X[i] && X[i] <= Z[i]) {
                    array[i] = 1;
                } else if (Z[i] >= X[i] && X[i] >= Y[i]) {
                    array[i] = 1;
                } else {
                    array[i] = 0;
                }
            }
            return new TdxNumber(array);
        }
        /// <summary>
        /// 介于.
        /// 用法: BETWEEN(A, B, C)表示A处于B和C之间时返回1,B &lt; A &lt; C或C &lt; A &lt;B, 否则返回0
        /// 例如: BETWEEN(CLOSE, MA(CLOSE,10),MA(CLOSE,5))表示收盘价介于5日均线和10日均线之间
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="Z"></param>
        /// <returns></returns>
        public static TdxNumber BETWEEN(TdxNumber X, TdxNumber Y, double Z)
        {
            var array = new double[X.Length];
            var startIndex = 0;
            while (startIndex < X.Length && double.IsNaN(X[startIndex]) && double.IsNaN(Y[startIndex])) { array[startIndex] = double.NaN; startIndex++; }

            for (int i = startIndex + 1; i < array.Length; i++) {
                if (Y[i] <= X[i] && X[i] <= Z) {
                    array[i] = 1;
                } else if (Z >= X[i] && X[i] >= Y[i]) {
                    array[i] = 1;
                } else {
                    array[i] = 0;
                }
            }
            return new TdxNumber(array);
        }
        /// <summary>
        /// 介于.
        /// 用法: BETWEEN(A, B, C)表示A处于B和C之间时返回1,B&lt;A&lt;C或C&lt;A&lt;B, 否则返回0
        /// 例如: BETWEEN(CLOSE, MA(CLOSE,10),MA(CLOSE,5))表示收盘价介于5日均线和10日均线之间
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="Z"></param>
        /// <returns></returns>
        public static TdxNumber BETWEEN(TdxNumber X, double Y, TdxNumber Z)
        {
            var array = new double[X.Length];
            var startIndex = 0;
            while (startIndex < X.Length && double.IsNaN(X[startIndex]) && double.IsNaN(Z[startIndex])) { array[startIndex] = double.NaN; startIndex++; }

            for (int i = startIndex + 1; i < array.Length; i++) {
                if (Y <= X[i] && X[i] <= Z[i]) {
                    array[i] = 1;
                } else if (Z[i] >= X[i] && X[i] >= Y) {
                    array[i] = 1;
                } else {
                    array[i] = 0;
                }
            }
            return new TdxNumber(array);
        }
        /// <summary>
        /// 介于.
        /// 用法: BETWEEN(A, B, C)表示A处于B和C之间时返回1,B&lt;A&lt;C或C&lt;A&lt;B, 否则返回0
        /// 例如: BETWEEN(CLOSE, MA(CLOSE,10),MA(CLOSE,5))表示收盘价介于5日均线和10日均线之间
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="Z"></param>
        /// <returns></returns>
        public static TdxNumber BETWEEN(TdxNumber X, double Y, double Z)
        {
            var array = new double[X.Length];
            var startIndex = 0;
            while (startIndex < X.Length && double.IsNaN(X[startIndex])) { array[startIndex] = double.NaN; startIndex++; }

            for (int i = startIndex + 1; i < array.Length; i++) {
                if (Y <= X[i] && X[i] <= Z) {
                    array[i] = 1;
                } else if (Z >= X[i] && X[i] >= Y) {
                    array[i] = 1;
                } else {
                    array[i] = 0;
                }
            }
            return new TdxNumber(array);
        }
        /// <summary>
        /// 返回移动平均
        /// 用法: SMA(X, N, M) :X的N日移动平均,M为权重,如Y=(X* M+Y'*(N-M))/N
        /// </summary>
        /// <param name="X"></param>
        /// <param name="N"></param>
        /// <param name="M"></param>
        /// <returns></returns>
        public static TdxNumber SMA(TdxNumber X, TdxNumber N, TdxNumber M)
        {
            var array = new double[X.Length];
            var startIndex = 0;
            while (startIndex < X.Length && double.IsNaN(X[startIndex])) { array[startIndex] = double.NaN; startIndex++; }

            double Y = X[0];
            array[0] = X[0];
            for (int i = startIndex + 1; i < array.Length; i++) {
                Y = (X[i] * M[i] + Y * (N[i] - M[i])) / N[i];
                array[i] = Y;
            }
            return new TdxNumber(array);
        }
        /// <summary>
        /// 返回移动平均
        /// 用法: SMA(X, N, M) :X的N日移动平均,M为权重,如Y=(X* M+Y'*(N-M))/N
        /// </summary>
        /// <param name="X"></param>
        /// <param name="N"></param>
        /// <param name="M"></param>
        /// <returns></returns>
        public static TdxNumber SMA(TdxNumber X, TdxNumber N, double M)
        {
            var array = new double[X.Length];
            var startIndex = 0;
            while (startIndex < X.Length && double.IsNaN(X[startIndex])) { array[startIndex] = double.NaN; startIndex++; }

            double Y = X[0];
            array[0] = X[0];
            for (int i = startIndex + 1; i < array.Length; i++) {
                Y = (X[i] * M + Y * (N[i] - M)) / N[i];
                array[i] = Y;
            }
            return new TdxNumber(array);
        }
        /// <summary>
        /// 返回移动平均
        /// 用法: SMA(X, N, M) :X的N日移动平均,M为权重,如Y=(X* M+Y'*(N-M))/N
        /// </summary>
        /// <param name="X"></param>
        /// <param name="N"></param>
        /// <param name="M"></param>
        /// <returns></returns>
        public static TdxNumber SMA(TdxNumber X, double N, TdxNumber M)
        {
            var array = new double[X.Length];
            var startIndex = 0;
            while (startIndex < X.Length && double.IsNaN(X[startIndex])) { array[startIndex] = double.NaN; startIndex++; }

            double Y = X[0];
            array[0] = X[0];
            for (int i = startIndex + 1; i < array.Length; i++) {
                Y = (X[i] * M[i] + Y * (N - M[i])) / N;
                array[i] = Y;
            }
            return new TdxNumber(array);
        }
        /// <summary>
        /// 返回移动平均
        /// 用法: SMA(X, N, M) :X的N日移动平均,M为权重,如Y=(X* M+Y'*(N-M))/N
        /// </summary>
        /// <param name="X"></param>
        /// <param name="N"></param>
        /// <param name="M"></param>
        /// <returns></returns>
        public static TdxNumber SMA(TdxNumber X, double N, double M)
        {
            var array = new double[X.Length];
            var startIndex = 0;
            while (startIndex < X.Length && double.IsNaN(X[startIndex])) { array[startIndex] = double.NaN; startIndex++; }

            double Y = X[0];
            array[0] = X[0];
            for (int i = startIndex + 1; i < array.Length; i++) {
                Y = (X[i] * M + Y * (N - M)) / N;
                array[i] = Y;
            }
            return new TdxNumber(array);
        }
        /// <summary>
        /// 返回移动平均
        /// 用法: TMA(X, A, B),A和B必须小于1,算法 Y = (A * Y'+B*X),其中Y'表示上一周期Y值.初值为X
        /// </summary>
        /// <param name="X"></param>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static TdxNumber TMA(TdxNumber X, TdxNumber A, TdxNumber B)
        {
            var array = new double[X.Length];
            var startIndex = 0;
            while (startIndex < X.Length && double.IsNaN(X[startIndex])) { array[startIndex] = double.NaN; startIndex++; }

            double Y = X[startIndex];
            array[startIndex] = X[startIndex];
            for (int i = startIndex + 1; i < array.Length; i++) {
                Y = A[i] * Y + B[i] * X[i];
                array[i] = Y;
            }
            return new TdxNumber(array);
        }
        /// <summary>
        /// 返回移动平均
        /// 用法: TMA(X, A, B),A和B必须小于1,算法 Y = (A * Y'+B*X),其中Y'表示上一周期Y值.初值为X
        /// </summary>
        /// <param name="X"></param>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static TdxNumber TMA(TdxNumber X, TdxNumber A, double B)
        {
            var array = new double[X.Length];
            var startIndex = 0;
            while (startIndex < X.Length && double.IsNaN(X[startIndex])) { array[startIndex] = double.NaN; startIndex++; }

            double Y = X[startIndex];
            array[startIndex] = X[startIndex];
            for (int i = startIndex + 1; i < array.Length; i++) {
                Y = A[i] * Y + B * X[i];
                array[i] = Y;
            }
            return new TdxNumber(array);
        }
        /// <summary>
        /// 返回移动平均
        /// 用法: TMA(X, A, B),A和B必须小于1,算法 Y = (A * Y'+B*X),其中Y'表示上一周期Y值.初值为X
        /// </summary>
        /// <param name="X"></param>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static TdxNumber TMA(TdxNumber X, double A, TdxNumber B)
        {
            var array = new double[X.Length];
            var startIndex = 0;
            while (startIndex < X.Length && double.IsNaN(X[startIndex])) { array[startIndex] = double.NaN; startIndex++; }

            double Y = X[startIndex];
            array[startIndex] = X[startIndex];
            for (int i = startIndex + 1; i < array.Length; i++) {
                Y = A * Y + B[i] * X[i];
                array[i] = Y;
            }
            return new TdxNumber(array);
        }
        /// <summary>
        /// 返回移动平均
        /// 用法: TMA(X, A, B),A和B必须小于1,算法 Y = (A * Y'+B*X),其中Y'表示上一周期Y值.初值为X
        /// </summary>
        /// <param name="X"></param>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static TdxNumber TMA(TdxNumber X, double A, double B)
        {
            if (A >= 1) { throw new Exception("Function TMA parameter A is error."); }
            if (B >= 1) { throw new Exception("Function TMA parameter B is error."); }
            var array = new double[X.Length];
            var startIndex = 0;
            while (startIndex < X.Length && double.IsNaN(X[startIndex])) { array[startIndex] = double.NaN; startIndex++; }

            double Y = X[startIndex];
            array[startIndex] = X[startIndex];
            for (int i = startIndex + 1; i < array.Length; i++) {
                Y = A * Y + B * X[i];
                array[i] = Y;
            }
            return new TdxNumber(array);
        }
        /// <summary>
        /// 两条线维持一定周期后交叉.
        /// 用法:LONGCROSS(A, B, N)表示A在N周期内都小于B,本周期从下方向上穿过B时返回1,否则返回0
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static TdxNumber LONGCROSS(TdxNumber X, TdxNumber Y, int N)
        {
            var array = new double[X.Length];
            var startIndex = 0;
            while (startIndex < X.Length && double.IsNaN(X[startIndex])) { array[startIndex] = double.NaN; startIndex++; }

            for (int i = startIndex + N + 1; i < array.Length; i++) {
                bool b = false;
                if (X[i] > Y[i]) {
                    b = true;
                    for (int j = 1; j <= N; j++) {
                        if (X[i - j] >= Y[i - j]) {
                            b = false;
                            break;
                        }
                    }
                }
                array[i] = b ? 1 : 0;
            }
            return new TdxNumber(array);
        }
        /// <summary>
        /// 两条线维持一定周期后交叉.
        /// 用法:LONGCROSS(A, B, N)表示A在N周期内都小于B,本周期从下方向上穿过B时返回1,否则返回0
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static TdxNumber LONGCROSS(TdxNumber X, double Y, int N)
        {
            var array = new double[X.Length];
            var startIndex = 0;
            while (startIndex < X.Length && double.IsNaN(X[startIndex])) { array[startIndex] = double.NaN; startIndex++; }

            for (int i = startIndex + N + 1; i < array.Length; i++) {
                bool b = false;
                if (X[i] > Y) {
                    b = true;
                    for (int j = 1; j <= N; j++) {
                        if (X[i - j] >= Y) {
                            b = false;
                            break;
                        }
                    }
                }
                array[i] = b ? 1 : 0;
            }
            return new TdxNumber(array);
        }
        /// <summary>
        /// 两条线维持一定周期后交叉.
        /// 用法:LONGCROSS(A, B, N)表示A在N周期内都小于B,本周期从下方向上穿过B时返回1,否则返回0
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static TdxNumber LONGCROSS(double X, TdxNumber Y, int N)
        {
            var array = new double[Y.Length];
            var startIndex = 0;
            while (startIndex < Y.Length && double.IsNaN(Y[startIndex])) { array[startIndex] = double.NaN; startIndex++; }

            for (int i = startIndex + N + 1; i < array.Length; i++) {
                bool b = false;
                if (X > Y[i]) {
                    b = true;
                    for (int j = 1; j <= N; j++) {
                        if (X >= Y[i - j]) {
                            b = false;
                            break;
                        }
                    }
                }
                array[i] = b ? 1 : 0;
            }
            return new TdxNumber(array);
        }


        /// <summary>
        /// 返回是否持续存在X>Y
        /// 用法: NDAY(CLOSE, OPEN,3) 表示连续3日收阳线
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static TdxNumber NDAY(TdxNumber X, TdxNumber Y, int N)
        {
            var array = new double[X.Length];
            var startIndex = 0;
            while (startIndex < X.Length && double.IsNaN(X[startIndex])) { array[startIndex] = double.NaN; startIndex++; }

            var temp = 0;
            for (int i = startIndex; i < Math.Min(startIndex + N, array.Length); i++) {
                if (X[i] > Y[i]) {
                    temp++;
                } else {
                    temp = 0;
                }
            }
            for (int i = startIndex + N; i < array.Length; i++) {
                if (X[i] > Y[i]) {
                    temp++;
                    if (temp >= N) {
                        array[i] = 1;
                    }
                } else {
                    temp = 0;
                }
            }
            return new TdxNumber(array);
        }
        /// <summary>
        /// 返回是否持续存在X>Y
        /// 用法: NDAY(CLOSE, OPEN,3) 表示连续3日收阳线
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static TdxNumber NDAY(TdxNumber X, double Y, int N)
        {
            var array = new double[X.Length];
            var startIndex = 0;
            while (startIndex < X.Length && double.IsNaN(X[startIndex])) { array[startIndex] = double.NaN; startIndex++; }

            var temp = 0;
            for (int i = startIndex; i < Math.Min(startIndex + N, array.Length); i++) {
                if (X[i] > Y) {
                    temp++;
                } else {
                    temp = 0;
                }
            }
            for (int i = startIndex + N; i < array.Length; i++) {
                if (X[i] > Y) {
                    temp++;
                    if (temp >= N) {
                        array[i] = 1;
                    }
                } else {
                    temp = 0;
                }
            }
            return new TdxNumber(array);
        }
        /// <summary>
        /// 返回是否持续存在X>Y
        /// 用法: NDAY(CLOSE, OPEN,3) 表示连续3日收阳线
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static TdxNumber NDAY(double X, TdxNumber Y, int N)
        {
            var array = new double[Y.Length];
            var startIndex = 0;
            while (startIndex < Y.Length && double.IsNaN(Y[startIndex])) { array[startIndex] = double.NaN; startIndex++; }

            var temp = 0;
            for (int i = startIndex; i < Math.Min(startIndex + N, array.Length); i++) {
                if (X > Y[i]) {
                    temp++;
                } else {
                    temp = 0;
                }
            }
            for (int i = startIndex + N; i < array.Length; i++) {
                if (X > Y[i]) {
                    temp++;
                    if (temp >= N) {
                        array[i] = 1;
                    }
                } else {
                    temp = 0;
                }
            }
            return new TdxNumber(array);
        }

        /// <summary>
        /// EXISTR(X,A,B):是否存在(前几日到前几日间).
        /// 例如: EXISTR(CLOSE>OPEN,10,5) 表示从前10日内到前5日内存在着阳线
        /// 若A为0, 表示从第一天开始, B为0, 表示到最后日止, 第2,3个参数为常量
        /// </summary>
        /// <param name="X"></param>
        /// <param name="N"></param>
        /// <param name="M"></param>
        /// <returns></returns>
        public static TdxNumber EXISTR(TdxNumber X, int N, int M)
        {
            var array = new double[X.Length];
            if (M > N) {
                (M, N) = (N, M);
            }
            for (int i = 0; i < array.Length; i++) {
                //bool b = false;
                for (int j = Math.Max(i - N, 0); j <= Math.Max(i - M, 0); j++) {
                    if (X.GetBoolean(j)) {
                        array[i] = 1;
                        //b = true;
                        break;
                    }
                }
                //array.Add(b ? 1 : 0);
            }
            return new TdxNumber(array);
        }
        /// <summary>
        /// EXISTR(X,A,B):是否存在(前几日到前几日间).
        /// 例如: EXISTR(CLOSE>OPEN,10,5) 表示从前10日内到前5日内存在着阳线
        /// 若A为0, 表示从第一天开始, B为0, 表示到最后日止, 第2,3个参数为常量
        /// </summary>
        /// <param name="X"></param>
        /// <param name="N"></param>
        /// <param name="M"></param>
        /// <returns></returns>
        public static TdxNumber EXISTR(bool[] X, int N, int M)
        {
            var array = new double[X.Length];
            if (M > N) {
                (M, N) = (N, M);
            }
            for (int i = 0; i < array.Length; i++) {
                //bool b = false;
                for (int j = Math.Max(i - N, 0); j <= Math.Max(i - M, 0); j++) {
                    if (X[j]) {
                        array[i] = 1;
                        //b = true;
                        break;
                    }
                }
                //array.Add(b ? 1 : 0);
            }
            return new TdxNumber(array);
        }
        /// <summary>
        /// LAST(X,A,B):持续存在.
        /// 例如: LAST(CLOSE>OPEN,10,5) 表示从前10日到前5日内一直阳线
        /// 若A为0, 表示从第一天开始, B为0, 表示到最后日止
        /// </summary>
        /// <param name="X"></param>
        /// <param name="N"></param>
        /// <param name="M"></param>
        /// <returns></returns>
        public static TdxNumber LAST(TdxNumber X, int N, int M)
        {
            var array = new double[X.Length];
            if (M > N) {
                (M, N) = (N, M);
            }
            for (int i = 0; i < array.Length; i++) {
                bool b = true;
                for (int j = Math.Max(i - N, 0); j <= Math.Max(i - M, 0); j++) {
                    if (X.GetBoolean(j) == false) {
                        b = false;
                        break;
                    }
                }
                array[i] = b ? 1 : 0;
                //array.Add(b ? 1 : 0);
            }
            return new TdxNumber(array);
        }
        /// <summary>
        /// LAST(X,A,B):持续存在.
        /// 例如: LAST(CLOSE>OPEN,10,5) 表示从前10日到前5日内一直阳线
        /// 若A为0, 表示从第一天开始, B为0, 表示到最后日止
        /// </summary>
        /// <param name="X"></param>
        /// <param name="N"></param>
        /// <param name="M"></param>
        /// <returns></returns>
        public static TdxNumber LAST(bool[] X, int N, int M)
        {
            var array = new double[X.Length];
            if (M > N) {
                (M, N) = (N, M);
            }
            for (int i = 0; i < array.Length; i++) {
                bool b = true;
                for (int j = Math.Max(i - N, 0); j <= Math.Max(i - M, 0); j++) {
                    if (X[j] == false) {
                        b = false;
                        break;
                    }
                }
                array[i] = b ? 1 : 0;
                //array.Add(b ? 1 : 0);
            }
            return new TdxNumber(array);
        }
        /// <summary>
        /// COVAR(X,Y,N) 返回X和Y的N周期的协方差,N支持变量
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static TdxNumber COVAR(TdxNumber X, TdxNumber Y, int N)
        {
            var array = new double[X.Length];
            var startIndex = 0;
            while (startIndex < X.Length && double.IsNaN(X[startIndex]) && double.IsNaN(Y[startIndex])) { array[startIndex] = double.NaN; startIndex++; }

            List<double> temp = new List<double>(N);
            List<double> temp2 = new List<double>(N);

            for (int i = startIndex; i < Math.Min(startIndex + N, array.Length); i++) {
                temp.Add(X[i]);
                temp2.Add(Y[i]);
            }
            for (int i = startIndex + N; i < array.Length; i++) {
                temp.Add(X[i]);
                temp2.Add(Y[i]);
                temp.RemoveAt(0);
                temp2.RemoveAt(0);

                double sum = 0;
                double avg = temp.Average();
                double avg2 = temp2.Average();
                for (int j = 0; j < temp.Count; j++) {
                    sum += (temp[j] - avg) * (temp2[j] - avg2);
                }
                var t = sum / (temp.Count - 1);
                array[i] = t;
            }
            return new TdxNumber(array);
        }
        /// <summary>
        /// RELATE(X,Y,N) 返回X和Y的N周期的相关系数,N支持变量
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static TdxNumber RELATE(TdxNumber X, TdxNumber Y, int N)
        {
            var array = new double[X.Length];
            var startIndex = 0;
            while (startIndex < X.Length && double.IsNaN(X[startIndex]) && double.IsNaN(Y[startIndex])) { array[startIndex] = double.NaN; startIndex++; }

            List<double> temp = new List<double>(N);
            List<double> temp2 = new List<double>(N);

            for (int i = startIndex; i < Math.Min(startIndex + N, array.Length); i++) {
                temp.Add(X[i]);
                temp2.Add(Y[i]);
            }
            for (int i = startIndex + N; i < array.Length; i++) {
                temp.Add(X[i]);
                temp2.Add(Y[i]);
                temp.RemoveAt(0);
                temp2.RemoveAt(0);

                double sum = 0;
                double sum2 = 0;
                double sum3 = 0;
                double avg = temp.Average();
                double avg2 = temp2.Average();
                for (int j = 0; j < temp.Count; j++) {
                    sum += (temp[j] - avg) * (temp2[j] - avg2);
                    sum2 += (temp[j] - avg) * (temp[j] - avg);
                    sum3 += (temp2[j] - avg2) * (temp2[j] - avg2);
                }
                var t = sum / Math.Sqrt(sum2 * sum3);
                array[i] = t;
            }
            return new TdxNumber(array);
        }

        /// <summary>
        /// N周期前的M周期内的第T个最大值.
        /// 用法: FINDHIGH(VAR, N, M, T) :VAR在N日前的M天内第T个最高价
        /// </summary>
        /// <param name="X"></param>
        /// <param name="N"></param>
        /// <param name="M"></param>
        /// <param name="T"></param>
        /// <returns></returns>
        public static TdxNumber FINDHIGH(TdxNumber X, int N, int M, int T)
        {
            var array = new double[X.Length];
            var startIndex = 0;
            while (startIndex < X.Length && double.IsNaN(X[startIndex])) { array[startIndex] = double.NaN; startIndex++; }

            var temp = new List<double>(array.Length);
            for (int i = startIndex; i < startIndex + M - 1; i++) {
                InsertArray_Max2Min(temp, X[i]);
                //array[i] = 0;
            }
            var e = M + N;
            //for (int i = M - 1; i < e - 1; i++) {
            //    array[i] = 0;
            //}
            for (int i = startIndex + e - 1; i < array.Length; i++) {
                //var x = X[i - N];
                InsertArray_Max2Min(temp, X[i - N]);
                var t = temp[T - 1];
                array[i] = t;
                temp.Remove(X[i - e + 1]);
            }
            return new TdxNumber(array);
        }
        /// <summary>
        /// N周期前的M周期内的第T个最小值.
        /// 用法: FINDLOW(VAR, N, M, T) :VAR在N日前的M天内第T个最低价
        /// </summary>
        /// <param name="X"></param>
        /// <param name="N"></param>
        /// <param name="M"></param>
        /// <param name="T"></param>
        /// <returns></returns>
        public static TdxNumber FINDLOW(TdxNumber X, int N, int M, int T)
        {
            var array = new double[X.Length];
            var startIndex = 0;
            while (startIndex < X.Length && double.IsNaN(X[startIndex])) { array[startIndex] = double.NaN; startIndex++; }

            var temp = new List<double>(array.Length);
            for (int i = startIndex; i < startIndex + M - 1; i++) {
                var x = X[i];
                InsertArray_Min2Max(temp, x);
                //array[i] = 0;
            }
            var e = M + N;
            //for (int i = M - 1; i < e - 1; i++) {
            //    array[i] = 0;
            //}
            for (int i = startIndex + e - 1; i < array.Length; i++) {
                InsertArray_Min2Max(temp, X[i - N]);
                var t = temp[T - 1];
                array[i] = t;
                temp.Remove(X[i - e + 1]);
            }
            return new TdxNumber(array);
        }
        /// <summary>
        /// N周期前的M周期内的第T个最大值到当前周期的周期数.
        /// 用法: FINDHIGHBARS(VAR, N, M, T) :VAR在N日前的M天内第T个最高价到当前周期的周期数
        /// </summary>
        /// <param name="X"></param>
        /// <param name="N"></param>
        /// <param name="M"></param>
        /// <param name="T"></param>
        /// <returns></returns>
        public static TdxNumber FINDHIGHBARS(TdxNumber X, int N, int M, int T)
        {
            var array = new double[X.Length];
            var startIndex = 0;
            while (startIndex < X.Length && double.IsNaN(X[startIndex])) { array[startIndex] = double.NaN; startIndex++; }
            var temp = new List<double>(array.Length);

            for (int i = startIndex; i < startIndex + M - 1; i++) {
                InsertArray_Max2Min(temp, X[i]);
            }
            for (int i = startIndex + M - 1; i < array.Length; i++) {
                InsertArray_Max2Min(temp, X[i]);
                var t = temp[T - 1];
                int index = i;
                while (Math.Round(X[index] - t, 12, MidpointRounding.AwayFromZero) != 0) { index--; }
                if (i + N < array.Length) {
                    array[i + N] = i - index + N;
                }
                temp.Remove(X[i + 1 - M]);
            }
            return new TdxNumber(array);
        }

        /// <summary>
        /// N周期前的M周期内的第T个最小值到当前周期的周期数.
        /// 用法: FINDLOWBARS(VAR, N, M, T) :VAR在N日前的M天内第T个最低价到当前周期的周期数.
        /// </summary>
        /// <param name="X"></param>
        /// <param name="N"></param>
        /// <param name="M"></param>
        /// <param name="T"></param>
        /// <returns></returns>
        public static TdxNumber FINDLOWBARS(TdxNumber X, int N, int M, int T)
        {
            var array = new double[X.Length];
            var startIndex = 0;
            while (startIndex < X.Length && double.IsNaN(X[startIndex])) { array[startIndex] = double.NaN; startIndex++; }
            var temp = new List<double>(array.Length);

            for (int i = startIndex; i < startIndex + M - 1; i++) {
                InsertArray_Min2Max(temp, X[i]);
            }
            for (int i = startIndex + M - 1; i < array.Length; i++) {
                InsertArray_Min2Max(temp, X[i]);
                var t = temp[T - 1];
                int index = i;
                while (Math.Round(X[index] - t, 12, MidpointRounding.AwayFromZero) != 0) { index--; }
                if (i + N < array.Length) {
                    array[i + N] = i - index + N;
                }
                temp.Remove(X[i + 1 - M]);
            }
            return new TdxNumber(array);
        }

        #region 未来函数


        /// <summary>
        /// 属于未来函数,之字转向.
        /// 用法: ZIGA(K, X),当价格变化超过X时转向,K表示0:开盘价,1:最高价,2:最低价,3:收盘价,其余:数组信息
        /// 例如: ZIGA(3,1.5)表示收盘价变化1.5元的ZIGA转向
        /// </summary>
        /// <param name="k"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public static TdxNumber ZIGA(TdxNumber k, double x)
        {
            var peers = ZigPeeka(k, x);

            double[] z = new double[k.Length];
            for (int i = 0; i < peers.Count; i++) {
                var peer_start_i = peers[i];
                var peer_end_i = peers[i + 1];
                var start_value = k[peer_start_i];
                var end_value = k[peer_end_i];
                var a = (end_value - start_value) / (peer_end_i - peer_start_i);// 斜率
                for (int j = 0; j < peer_end_i - peer_start_i + 1; j++) {
                    z[j + peer_start_i] = start_value + a * j;
                }
            }
            return new TdxNumber(z);
        }
        /// <summary>
        /// 属于未来函数,之字转向.
        /// 用法: ZIG(K, N),当价格变化量超过N%时转向,K表示0:开盘价,1:最高价,2:最低价,3:收盘价,其余:数组信息
        /// 例如: ZIG(3,5)表示收盘价的5%的ZIG转向
        /// </summary>
        /// <param name="k"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public static TdxNumber ZIG(TdxNumber k, double x)
        {
            var peers = ZigPeek(k, x);

            double[] z = new double[k.Length];
            for (int i = 0; i < peers.Count - 1; i++) {
                var peer_start_i = peers[i];
                var peer_end_i = peers[i + 1];
                var start_value = k[peer_start_i];
                var end_value = k[peer_end_i];
                var a = (end_value - start_value) / (peer_end_i - peer_start_i);// 斜率
                for (int j = 0; j < peer_end_i - peer_start_i + 1; j++) {
                    z[j + peer_start_i] = start_value + a * j;
                }
            }
            return new TdxNumber(z);
        }
        private static List<int> ZigPeeka(double[] k, double x)
        {
            const int state_none = 0;
            const int state_up = 1;
            const int state_down = 2;
            const int digits = 4;

            var peers = new List<int>() { 0 };
            bool isFirst = true;
            var tempStart = k[0];
            var tempIndex = 0;
            var state = state_none;

            for (int i = 1; i < k.Length - 1; i++) {
                if (isFirst) {
                    if (Math.Round(k[i] - (tempStart + x), digits, MidpointRounding.AwayFromZero) >= 0) {
                        tempStart = k[i];
                        tempIndex = i;
                        state = state_up;
                        isFirst = false;
                    } else if (Math.Round(k[i] - (tempStart - x), digits, MidpointRounding.AwayFromZero) <= 0) {
                        tempStart = k[i];
                        tempIndex = i;
                        state = state_down;
                        isFirst = false;
                    }
                } else if (state == state_up) {
                    if (Math.Round(k[i] - tempStart, digits, MidpointRounding.AwayFromZero) > 0) {
                        tempStart = k[i];
                        tempIndex = i;
                    } else if (Math.Round(k[i] - (tempStart - x), digits, MidpointRounding.AwayFromZero) <= 0) {
                        peers.Add(tempIndex);
                        tempStart = k[i];
                        tempIndex = i;
                        state = state_down;
                    }
                } else if (state == state_down) {
                    if (Math.Round(k[i] - tempStart, digits, MidpointRounding.AwayFromZero) < 0) {
                        tempStart = k[i];
                        tempIndex = i;
                    } else if (Math.Round(k[i] - (tempStart + x), digits, MidpointRounding.AwayFromZero) >= 0) {
                        peers.Add(tempIndex);
                        tempStart = k[i];
                        tempIndex = i;
                        state = state_up;
                    }
                }
            }

            peers.Add(tempIndex);
            peers.Add(k.Length - 1);
            return peers;
        }

        private static List<int> ZigPeek(double[] k, double x)
        {
            const int state_none = 0;
            const int state_up = 1;
            const int state_down = 2;
            const int digits = 4;
            double up = 1 + x;
            double down = 1 - x;

            var peers = new List<int>() { 0 };
            bool isFirst = true;
            var tempStart = k[0];
            var tempIndex = 0;
            var state = state_none;

            for (int i = 1; i < k.Length - 1; i++) {
                if (isFirst) {
                    if (k[i] > tempStart && Math.Round(k[i] - tempStart * up, digits, MidpointRounding.AwayFromZero) >= 0) {
                        tempStart = k[i];
                        tempIndex = i;
                        state = state_up;
                        isFirst = false;
                    } else if (k[i] < tempStart && Math.Round(k[i] - tempStart * down, digits, MidpointRounding.AwayFromZero) <= 0) {
                        tempStart = k[i];
                        tempIndex = i;
                        state = state_down;
                        isFirst = false;
                    }
                } else if (state == state_up) {
                    if (Math.Round(k[i] - tempStart, digits, MidpointRounding.AwayFromZero) > 0) {
                        tempStart = k[i];
                        tempIndex = i;
                    } else if (Math.Round(k[i] - tempStart * down, digits, MidpointRounding.AwayFromZero) <= 0) {
                        peers.Add(tempIndex);
                        tempStart = k[i];
                        tempIndex = i;
                        state = state_down;
                    }
                } else if (state == state_down) {
                    if (Math.Round(k[i] - tempStart, digits, MidpointRounding.AwayFromZero) < 0) {
                        tempStart = k[i];
                        tempIndex = i;
                    } else if (Math.Round(k[i] - tempStart * up, digits, MidpointRounding.AwayFromZero) >= 0) {
                        peers.Add(tempIndex);
                        tempStart = k[i];
                        tempIndex = i;
                        state = state_up;
                    }
                }
            }
            peers.Add(tempIndex);
            peers.Add(k.Length - 1);
            return peers;
        }

        #endregion

        #region private
        static double LinearRegressionCoefficient(List<double> parray, double averagex, double denominator)
        {
            //求出横纵坐标的平均值
            double averagey = parray.Average();

            //经验回归系数的分子
            double numerator = 0;
            for (int i = 0; i < parray.Count; i++) {
                numerator += (i - averagex) * (parray[i] - averagey);
            }
            //回归系数b（Regression Coefficient）
            return numerator / denominator;
        }
        static int InsertArray_Max2Min(List<double> arr, double x)
        {
            int low = 0, high = arr.Count - 1;
            int mid;
            while (low <= high) {
                mid = low + (high - low) / 2;
                if (x >= arr[mid]) {
                    high = mid - 1;
                } else { // 元素相同时，也插入在后面的位置
                    low = mid + 1;
                }
            }
            arr.Insert(low, x);
            return low + 1;
        }
        static int InsertArray_Min2Max(List<double> arr, double x)
        {
            int low = 0, high = arr.Count - 1;
            int mid;
            while (low <= high) {
                mid = low + (high - low) / 2;
                if (x <= arr[mid]) {
                    high = mid - 1;
                } else { // 元素相同时，也插入在后面的位置
                    low = mid + 1;
                }
            }
            arr.Insert(low, x);
            return low + 1;
        }
        #endregion
    }
}
