using System;
using System.Collections.Generic;

namespace ToolGood.TdxFormula
{
    public static partial class TdxMath
    {
        /// <summary>
        /// 求逻辑非.
        /// 用法: NOT(X)返回非X,即当X=0时返回1,否则返回0
        /// 例如: NOT(ISUP)表示平盘或收阴
        /// </summary>
        /// <param name="X"></param>
        /// <returns></returns>
        public static FqNumber NOT(FqNumber X)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = NOT(X[i]);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// 求逻辑非.
        /// 用法: NOT(X)返回非X,即当X=0时返回1,否则返回0
        /// 例如: NOT(ISUP)表示平盘或收阴
        /// </summary>
        /// <param name="X"></param>
        /// <returns></returns>
        public static FqBoolean NOT(FqBoolean X)
        {
            var array = new TdxBoolean[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = NOT(X[i]);
            }
            return new FqBoolean(array);
        }

        #region Math

        /// <summary>
        /// 反余弦值.
        /// 用法: ACOS(X)返回X的反余弦值
        /// </summary>
        /// <param name="X"></param>
        /// <returns></returns>
        public static FqNumber ACOS(FqNumber X)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = ACOS(X[i]);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// 反正弦值.
        /// 用法: ASIN(X)返回X的反正弦值
        /// </summary>
        /// <param name="X"></param>
        /// <returns></returns>
        public static FqNumber ASIN(FqNumber X)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = ASIN(X[i]);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// 反正切值.
        /// 用法: ATAN(X)返回X的反正切值
        /// </summary>
        /// <param name="X"></param>
        /// <returns></returns>
        public static FqNumber ATAN(FqNumber X)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = ATAN(X[i]);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// 余弦值.
        /// 用法: COS(X)返回X的余弦值
        /// </summary>
        /// <param name="X"></param>
        /// <returns></returns>
        public static FqNumber COS(FqNumber X)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = COS(X[i]);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// 正弦值.
        /// 用法: SIN(X)返回X的正弦值
        /// </summary>
        /// <param name="X"></param>
        /// <returns></returns>
        public static FqNumber SIN(FqNumber X)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = SIN(X[i]);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// 正切值.
        /// 用法: TAN(X)返回X的正切值
        /// </summary>
        /// <param name="X"></param>
        /// <returns></returns>
        public static FqNumber TAN(FqNumber X)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = TAN(X[i]);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// 指数.
        /// 用法: EXP(X)为e的X次幂
        /// 例如: EXP(CLOSE)返回e的CLOSE次幂
        /// </summary>
        /// <param name="X"></param>
        /// <returns></returns>
        public static FqNumber EXP(FqNumber X)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = EXP(X[i]);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// 求自然对数.
        /// 用法: LN(X)以e为底的对数
        /// 例如: LN(CLOSE)求收盘价的对数
        /// </summary>
        /// <param name="X"></param>
        /// <returns></returns>
        public static FqNumber LN(FqNumber X)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = LN(X[i]);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// 求N为底的对数.
        /// 用法: LOG(X,N)取得X的对数
        /// 例如: LOG(100,10)等于2
        /// </summary>
        /// <param name="X"></param>
        /// <returns></returns>
        public static FqNumber LOG(FqNumber X)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = LOG(X[i]);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// 求N为底的对数.
        /// 用法: LOG(X,N)取得X的对数
        /// 例如: LOG(100,10)等于2
        /// </summary>
        /// <param name="X"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public static FqNumber LOG(FqNumber X, double num)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = LOG(X[i], num);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// 求N为底的对数.
        /// 用法: LOG(X,N)取得X的对数
        /// 例如: LOG(100,10)等于2
        /// </summary>
        /// <param name="X"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public static FqNumber LOG(FqNumber X, FqNumber num)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = LOG(X[i], num[i]);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// 开平方.
        /// 用法: SQRT(X)为X的平方根
        /// 例如: SQRT(CLOSE)收盘价的平方根
        /// </summary>
        /// <param name="X"></param>
        /// <returns></returns>
        public static FqNumber SQRT(FqNumber X)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = SQRT(X[i]);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// 求绝对值.
        /// 用法: ABS(X)返回X的绝对值
        /// 例如: ABS(-34)返回34
        /// </summary>
        /// <param name="X"></param>
        /// <returns></returns>
        public static FqNumber ABS(FqNumber X)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = ABS(X[i]);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// 向上舍入.
        /// 用法: CEILING(A)返回沿A数值增大方向最接近的整数
        /// 例如: CEILING(12.3)求得13,CEILING(-3.5)求得-3
        /// </summary>
        /// <param name="X"></param>
        /// <returns></returns>
        public static FqNumber CEILING(FqNumber X)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = CEILING(X[i]);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// 向下舍入.
        /// 用法: FLOOR(A)返回沿A数值减小方向最接近的整数
        /// 例如: FLOOR(12.3)求得12,FLOOR(-3.5)求得-4
        /// </summary>
        /// <param name="X"></param>
        /// <returns></returns>
        public static FqNumber FLOOR(FqNumber X)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = FLOOR(X[i]);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// 取整.
        /// 用法: INTPART(A)返回沿A绝对值减小方向最接近的整数
        /// 例如: INTPART(12.3)求得12,INTPART(-3.5)求得-3
        /// </summary>
        /// <param name="X"></param>
        /// <returns></returns>
        public static FqNumber INTPART(FqNumber X)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = INTPART(X[i]);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// 小数部分.
        /// 用法: FRACPART(X),返回X的小数部分
        /// </summary>
        /// <param name="X"></param>
        /// <returns></returns>
        public static FqNumber FRACPART(FqNumber X)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = FRACPART(X[i]);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// 四舍五入.
        /// 用法: ROUND(X,N),返回X四舍五入到个位的数值
        /// </summary>
        /// <param name="X"></param>
        /// <returns></returns>
        public static FqNumber ROUND(FqNumber X)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = ROUND(X[i]);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// 四舍五入.
        /// 用法: ROUND(X,N),返回X四舍五入到个位的数值
        /// </summary>
        /// <param name="X"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public static FqNumber ROUND(FqNumber X, int num)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = ROUND(X[i], num);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// 四舍五入.
        /// 用法: ROUND(X,N),返回X四舍五入到个位的数值
        /// </summary>
        /// <param name="X"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public static FqNumber ROUND(FqNumber X, FqNumber num)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = ROUND(X[i], num[i]);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// 取符号.
        /// 用法: SIGN(X),返回X的符号.当X>0,X=0,X&lt;0分别返回1,0,-1
        /// </summary>
        /// <param name="X"></param>
        /// <returns></returns>
        public static FqNumber SIGN(FqNumber X)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = SIGN(X[i]);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// 取模.
        /// 用法: MOD(M, N),返回M关于N的模(M除以N的余数)
        /// 例如: MOD(5,3)返回2 注意:公式系统对有效数字部分有要求,如果数字部分超过7-8位,会有精度丢失
        /// </summary>
        /// <param name="X"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static FqNumber MOD(FqNumber X, FqNumber N)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = MOD(X[i], N[i]);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// 取模.
        /// 用法: MOD(M, N),返回M关于N的模(M除以N的余数)
        /// 例如: MOD(5,3)返回2 注意:公式系统对有效数字部分有要求,如果数字部分超过7-8位,会有精度丢失
        /// </summary>
        /// <param name="X"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static FqNumber MOD(FqNumber X, double N)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = MOD(X[i], N);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// 取模.
        /// 用法: MOD(M, N),返回M关于N的模(M除以N的余数)
        /// 例如: MOD(5,3)返回2 注意:公式系统对有效数字部分有要求,如果数字部分超过7-8位,会有精度丢失
        /// </summary>
        /// <param name="X"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static FqNumber MOD(double X, FqNumber N)
        {
            var array = new TdxNumber[N.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = MOD(X, N[i]);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// 求最大值.
        /// 用法: MAX(A, B)返回A和B中的较大值
        /// 例如: MAX(CLOSE-OPEN,0)表示若收盘价大于开盘价返回它们的差值,否则返回0
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <returns></returns>
        public static FqNumber MAX(FqNumber X, FqNumber Y)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = MAX(X[i], Y[i]);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// 求最大值.
        /// 用法: MAX(A, B)返回A和B中的较大值
        /// 例如: MAX(CLOSE-OPEN,0)表示若收盘价大于开盘价返回它们的差值,否则返回0
        /// </summary>
        /// <param name="Y"></param>
        /// <param name="X"></param>
        /// <returns></returns>
        public static FqNumber MAX(FqNumber X, double Y)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = MAX(X[i], Y);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// 求最大值.
        /// 用法: MAX(A, B)返回A和B中的较大值
        /// 例如: MAX(CLOSE-OPEN,0)表示若收盘价大于开盘价返回它们的差值,否则返回0
        /// </summary>
        /// <param name="Y"></param>
        /// <param name="X"></param>
        /// <returns></returns>
        public static FqNumber MAX(double X, FqNumber Y)
        {
            var array = new TdxNumber[Y.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = MAX(X, Y[i]);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// 求最小值.
        /// 用法: MIN(A, B)返回A和B中的较小值
        /// 例如: MIN(CLOSE, OPEN)返回开盘价和收盘价中的较小值
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <returns></returns>
        public static FqNumber MIN(FqNumber X, FqNumber Y)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = MIN(X[i], Y[i]);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// 求最小值.
        /// 用法: MIN(A, B)返回A和B中的较小值
        /// 例如: MIN(CLOSE, OPEN)返回开盘价和收盘价中的较小值
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <returns></returns>
        public static FqNumber MIN(FqNumber X, double Y)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = MIN(X[i], Y);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// 求最小值.
        /// 用法: MIN(A, B)返回A和B中的较小值
        /// 例如: MIN(CLOSE, OPEN)返回开盘价和收盘价中的较小值
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <returns></returns>
        public static FqNumber MIN(double X, FqNumber Y)
        {
            var array = new TdxNumber[Y.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = MIN(X, Y[i]);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// 乘幂.
        /// 用法: POW(A, B)返回A的B次幂
        /// 例如: POW(CLOSE,3)求得收盘价的3次方
        /// </summary>
        /// <param name="X"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public static FqNumber POW(FqNumber X, double num)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = POW(X[i], num);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// 乘幂.
        /// 用法: POW(A, B)返回A的B次幂
        /// 例如: POW(CLOSE,3)求得收盘价的3次方
        /// </summary>
        /// <param name="X"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public static FqNumber POW(FqNumber X, FqNumber num)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = POW(X[i], num[i]);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// 乘幂.
        /// 用法: POW(A, B)返回A的B次幂
        /// 例如: POW(CLOSE,3)求得收盘价的3次方
        /// </summary>
        /// <param name="X"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public static FqNumber POW(double X, FqNumber num)
        {
            var array = new TdxNumber[num.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = POW(X, num[i]);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// 求最大值.
        /// 用法: MAX(A, B)返回A和B中的较大值
        /// 例如: MAX(CLOSE-OPEN,0)表示若收盘价大于开盘价返回它们的差值,否则返回0
        /// </summary>
        /// <param name="Values"></param>
        /// <returns></returns>
        public static FqNumber MAX(params FqNumber[] Values)
        {
            var array = new TdxNumber[Values[0].Length];
            for (int i = 0; i < array.Length; i++) {
                List<TdxNumber> temps = new List<TdxNumber>();
                for (int j = 0; j < Values.Length; j++) {
                    temps.Add(Values[i][j]);
                }
                array[i] = MAX(temps.ToArray());
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// 求最小值.
        /// 用法: MIN(A, B)返回A和B中的较小值
        /// 例如: MIN(CLOSE, OPEN)返回开盘价和收盘价中的较小值
        /// </summary>
        /// <param name="Values"></param>
        /// <returns></returns>
        public static FqNumber MIN(params FqNumber[] Values)
        {
            var array = new TdxNumber[Values[0].Length];
            for (int i = 0; i < array.Length; i++) {
                List<TdxNumber> temps = new List<TdxNumber>();
                for (int j = 0; j < Values.Length; j++) {
                    temps.Add(Values[i][j]);
                }
                array[i] = MIN(temps.ToArray());
            }
            return new FqNumber(array);
        }

        #endregion Math

        /// <summary>
        /// 求相反数.
        /// 用法: REVERSE(X)返回-X.
        /// 例如: REVERSE(CLOSE)返回-CLOSE
        /// </summary>
        /// <param name="X"></param>
        /// <returns></returns>
        public static FqNumber REVERSE(FqNumber X)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = REVERSE(X[i]);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// CONST(A):取A最后的值为常量.
        /// 用法: CONST(INDEXC)表示取指数现价
        /// </summary>
        /// <param name="X"></param>
        /// <returns></returns>
        public static FqNumber CONST(FqNumber X)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = CONST(X[i]);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// 判断时否有效值
        /// </summary>
        /// <param name="X"></param>
        /// <returns></returns>
        public static FqNumber ISVALID(FqNumber X)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = ISVALID(X[i]);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// 上一次条件成立到当前的周期数.
        /// 用法: BARSLAST(X) :上一次X不为0到现在的周期数
        /// 例如: BARSLAST(CLOSE/REF(CLOSE,1)>=1.1)表示上一个涨停板到当前的周期数
        /// </summary>
        /// <param name="X"></param>
        /// <returns></returns>
        public static FqNumber BARSLAST(FqNumber X)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = BARSLAST(X[i]);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// 上一次条件成立到当前的周期数.
        /// 用法: BARSLAST(X) :上一次X不为0到现在的周期数
        /// 例如: BARSLAST(CLOSE/REF(CLOSE,1)>=1.1)表示上一个涨停板到当前的周期数
        /// </summary>
        /// <param name="X"></param>
        /// <returns></returns>
        public static FqNumber BARSLAST(FqBoolean X)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = BARSLAST(X[i]);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// 统计连续满足条件的周期数.
        /// 用法: BARSLASTCOUNT(X),统计连续满足X条件的周期数.
        /// 例如: BARSLASTCOUNT(CLOSE>OPEN)表示统计连续收阳的周期数
        /// </summary>
        /// <param name="X"></param>
        /// <returns></returns>
        public static FqNumber BARSLASTCOUNT(FqNumber X)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = BARSLASTCOUNT(X[i]);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// 统计连续满足条件的周期数.
        /// 用法: BARSLASTCOUNT(X),统计连续满足X条件的周期数.
        /// 例如: BARSLASTCOUNT(CLOSE>OPEN)表示统计连续收阳的周期数
        /// </summary>
        /// <param name="X"></param>
        /// <returns></returns>
        public static FqNumber BARSLASTCOUNT(FqBoolean X)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = BARSLASTCOUNT(X[i]);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// 有效数据周期数.
        /// 用法: BARSCOUNT(X)第一个有效数据到当前的间隔周期数
        /// </summary>
        /// <param name="X"></param>
        /// <returns></returns>
        public static FqNumber BARSCOUNT(FqNumber X)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = BARSCOUNT(X[i]);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// 第一个条件成立到当前的周期数.
        /// 用法: BARSSINCE(X) :第一次X不为0到现在的周期数
        /// 例如: BARSSINCE(HIGH>10)表示股价超过10元时到当前的周期数
        /// </summary>
        /// <param name="X"></param>
        /// <returns></returns>
        public static FqNumber BARSSINCE(FqNumber X)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = BARSSINCE(X[i]);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// 第一个条件成立到当前的周期数.
        /// 用法: BARSSINCE(X) :第一次X不为0到现在的周期数
        /// 例如: BARSSINCE(HIGH>10)表示股价超过10元时到当前的周期数
        /// </summary>
        /// <param name="X"></param>
        /// <returns></returns>
        public static FqNumber BARSSINCE(FqBoolean X)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = BARSSINCE(X[i]);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// 当前值是近多少周期内的最小值.
        /// 用法: LOWRANGE(X) :X是近多少周期内X的最小值
        /// 例如: LOWRANGE(LOW)表示当前最低价是近多少周期内最低价的最小值
        /// </summary>
        /// <param name="X"></param>
        /// <returns></returns>
        public static FqNumber LOWRANGE(FqNumber X)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = LOWRANGE(X[i]);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// 当前值是近多少周期内的最大值.
        /// 用法: TOPRANGE(X) :X是近多少周期内X的最大值
        /// 例如: TOPRANGE(HIGH)表示当前最高价是近多少周期内最高价的最大值
        /// </summary>
        /// <param name="X"></param>
        /// <returns></returns>
        public static FqNumber TOPRANGE(FqNumber X)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = TOPRANGE(X[i]);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// 并且
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Xs"></param>
        /// <returns></returns>
        public static FqBoolean AND(FqNumber X, params FqNumber[] Xs)
        {
            var array = new TdxBoolean[X.Length];
            for (int i = 0; i < array.Length; i++) {
                List<TdxNumber> temps = new List<TdxNumber>();
                foreach (var item in Xs) {
                    temps.Add(item[i]);
                }
                array[i] = AND(X[i], temps.ToArray());
            }
            return new FqBoolean(array);
        }

        /// <summary>
        /// 并且
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Xs"></param>
        /// <returns></returns>
        public static FqBoolean AND(FqNumber X, params FqBoolean[] Xs)
        {
            var array = new TdxBoolean[X.Length];
            for (int i = 0; i < array.Length; i++) {
                List<TdxBoolean> temps = new List<TdxBoolean>();
                foreach (var item in Xs) {
                    temps.Add(item[i]);
                }
                array[i] = AND(X[i], temps.ToArray());
            }
            return new FqBoolean(array);
        }

        /// <summary>
        /// 或者
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Xs"></param>
        /// <returns></returns>
        public static FqBoolean OR(FqNumber X, params FqNumber[] Xs)
        {
            var array = new TdxBoolean[X.Length];
            for (int i = 0; i < array.Length; i++) {
                List<TdxNumber> temps = new List<TdxNumber>();
                foreach (var item in Xs) {
                    temps.Add(item[i]);
                }
                array[i] = OR(X[i], temps.ToArray());
            }
            return new FqBoolean(array);
        }

        /// <summary>
        /// 或者
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Xs"></param>
        /// <returns></returns>
        public static FqBoolean OR(FqNumber X, params FqBoolean[] Xs)
        {
            var array = new TdxBoolean[X.Length];
            for (int i = 0; i < array.Length; i++) {
                List<TdxBoolean> temps = new List<TdxBoolean>();
                foreach (var item in Xs) {
                    temps.Add(item[i]);
                }
                array[i] = OR(X[i], temps.ToArray());
            }
            return new FqBoolean(array);
        }

        /// <summary>
        /// 引用若干周期前的数据.
        /// 用法: REF(X, A),引用A周期前的X值.A可以是变量.
        /// 例如: REF(CLOSE, BARSCOUNT(C)-1)表示第二根K线的收盘价.
        /// </summary>
        /// <param name="X"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static FqNumber REF(FqNumber X, int N)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = REF(X[i], N);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// 引用若干周期前的数据.
        /// 用法: REF(X, A),引用A周期前的X值.A可以是变量.
        /// 例如: REF(CLOSE, BARSCOUNT(C)-1)表示第二根K线的收盘价.
        /// </summary>
        /// <param name="X"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static FqNumber REF(FqNumber X, FqNumber N)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = REF(X[i], N[i]);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// 返回涨停价
        /// 用法: ZTPRICE(REF(CLOSE,1),0.1):按10%计算得到在昨收盘基础上的涨停价(对于复权序列K线, 由于复权处理, 根据前一天的收盘价计算结果可能与涨停价不符)
        /// 比如: ZTPrice(REF(QHJSJ,1),0.1),得到期货的涨停价
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <returns></returns>
        public static FqNumber ZTPRICE(FqNumber X, double Y)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = ZTPRICE(X[i], Y);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// 返回涨停价
        /// 用法: ZTPRICE(REF(CLOSE,1),0.1):按10%计算得到在昨收盘基础上的涨停价(对于复权序列K线, 由于复权处理, 根据前一天的收盘价计算结果可能与涨停价不符)
        /// 比如: ZTPrice(REF(QHJSJ,1),0.1),得到期货的涨停价
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <returns></returns>
        public static FqNumber ZTPRICE(FqNumber X, FqNumber Y)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = ZTPRICE(X[i], Y[i]);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// 返回跌停价
        /// 用法: DTPRICE(REF(CLOSE,1),0.1):按10%计算得到在昨收盘基础上的跌停价(对于复权序列K线, 由于复权处理, 根据前一天的收盘价计算结果可能与跌停价不符)
        /// 比如: DTPrice(REF(QHJSJ,1),0.6),得到期货的跌停价(跌停比例为0.6的话)
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <returns></returns>
        public static FqNumber DTPRICE(FqNumber X, double Y)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = DTPRICE(X[i], Y);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// 返回跌停价
        /// 用法: DTPRICE(REF(CLOSE,1),0.1):按10%计算得到在昨收盘基础上的跌停价(对于复权序列K线, 由于复权处理, 根据前一天的收盘价计算结果可能与跌停价不符)
        /// 比如: DTPrice(REF(QHJSJ,1),0.6),得到期货的跌停价(跌停比例为0.6的话)
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <returns></returns>
        public static FqNumber DTPRICE(FqNumber X, FqNumber Y)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = DTPRICE(X[i], Y[i]);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// 两条线交叉.
        /// 用法: CROSS(A, B)表示当A从下方向上穿过B时返回1,否则返回0
        /// 例如: CROSS(MA(CLOSE,5),MA(CLOSE,10))表示5日均线与10日均线交金叉
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <returns></returns>
        public static FqNumber CROSS(FqNumber X, FqNumber Y)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = CROSS(X[i], Y[i]);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// 两条线交叉.
        /// 用法: CROSS(A, B)表示当A从下方向上穿过B时返回1,否则返回0
        /// 例如: CROSS(MA(CLOSE,5),MA(CLOSE,10))表示5日均线与10日均线交金叉
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <returns></returns>
        public static FqNumber CROSS(FqNumber X, double Y)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = CROSS(X[i], Y);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// N周期内第一个条件成立到当前的周期数.
        /// 用法: BARSSINCEN(X, N) :N周期内第一次X不为0到现在的周期数,N为常量
        /// 例如: BARSSINCEN(HIGH>10,10)表示10个周期内股价超过10元时到当前的周期数
        /// </summary>
        /// <param name="X"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static FqNumber BARSSINCEN(FqNumber X, int N)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = BARSSINCEN(X[i], N);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// N周期内第一个条件成立到当前的周期数.
        /// 用法: BARSSINCEN(X, N) :N周期内第一次X不为0到现在的周期数,N为常量
        /// 例如: BARSSINCEN(HIGH>10,10)表示10个周期内股价超过10元时到当前的周期数
        /// </summary>
        /// <param name="X"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static FqNumber BARSSINCEN(FqBoolean X, int N)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = BARSSINCEN(X[i], N);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// 统计满足条件的周期数.
        /// 用法: COUNT(X, N),统计N周期中满足X条件的周期数,若N&lt;0则从第一个有效值开始.
        /// 例如: COUNT(CLOSE>OPEN,20)表示统计20周期内收阳的周期数
        /// </summary>
        /// <param name="X"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static FqNumber COUNT(FqNumber X, int N)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = COUNT(X[i], N);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// 统计满足条件的周期数.
        /// 用法: COUNT(X, N),统计N周期中满足X条件的周期数,若N&lt;0则从第一个有效值开始.
        /// 例如: COUNT(CLOSE>OPEN,20)表示统计20周期内收阳的周期数
        /// </summary>
        /// <param name="X"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static FqNumber COUNT(FqBoolean X, int N)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = COUNT(X[i], N);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// 求最高值.
        /// 用法: HHV(X, N),求N周期内X最高值,N=0则从第一个有效值开始.
        /// 例如: HHV(HIGH,30)表示求30日最高价
        /// </summary>
        /// <param name="X"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static FqNumber HHV(FqNumber X, int N)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = HHV(X[i], N);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// 求上一高点到当前的周期数.
        /// 用法: HHVBARS(X, N) :求N周期内X最高值到当前周期数,N=0表示从第一个有效值开始统计
        /// 例如: HHVBARS(HIGH,0)求得历史新高到到当前的周期数
        /// </summary>
        /// <param name="X"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static FqNumber HHVBARS(FqNumber X, int N)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = HHVBARS(X[i], N);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// 求最低值.
        /// 用法: LLV(X, N),求N周期内X最低值,N=0则从第一个有效值开始.
        /// 例如: LLV(LOW,0)表示求历史最低价
        /// </summary>
        /// <param name="X"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static FqNumber LLV(FqNumber X, int N)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = LLV(X[i], N);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// 求上一低点到当前的周期数.
        /// 用法: LLVBARS(X, N) :求N周期内X最低值到当前周期数,N=0表示从第一个有效值开始统计
        /// 例如: LLVBARS(HIGH,20)求得20日最低点到当前的周期数
        /// </summary>
        /// <param name="X"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static FqNumber LLVBARS(FqNumber X, int N)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = LLVBARS(X[i], N);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// 求总和.
        /// 用法: SUM(X, N),统计N周期中X的总和,N=0则从第一个有效值开始.
        /// 例如: SUM(VOL,0)表示统计从上市第一天以来的成交量总和
        /// </summary>
        /// <param name="X"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static FqNumber SUM(FqNumber X, int N)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = SUM(X[i], N);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// 向前累加到指定值到现在的周期数.
        /// 用法: SUMBARS(X, A) :将X向前累加直到大于等于A,返回这个区间的周期数,若所有的数据都累加后还不能达到A,则返回此时前面的总周期数.
        /// 例如: SUMBARS(VOL, CAPITAL)求完全换手到现在的周期数
        /// </summary>
        /// <param name="X"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static FqNumber SUMBARS(FqNumber X, double N)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = SUMBARS(X[i], N);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// 向前累加到指定值到现在的周期数.
        /// 用法: SUMBARS(X, A) :将X向前累加直到大于等于A,返回这个区间的周期数,若所有的数据都累加后还不能达到A,则返回此时前面的总周期数.
        /// 例如: SUMBARS(VOL, CAPITAL)求完全换手到现在的周期数
        /// </summary>
        /// <param name="X"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static FqNumber SUMBARS(FqNumber X, FqNumber N)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = SUMBARS(X[i], N[i]);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// 返回简单移动平均
        /// 用法: MA(X, N) :X的N日简单移动平均,算法(X1+X2+X3+...+Xn)/N,N支持变量
        /// </summary>
        /// <param name="X"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static FqNumber MA(FqNumber X, int N)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = MA(X[i], N);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// 返回指数移动平均
        /// 用法: EMA(X, N) :X的N日指数移动平均.算法:Y=(X*2+Y'*(N-1))/(N+1)
        /// EMA(X, N)相当于SMA(X, N+1,2),N支持变量
        /// </summary>
        /// <param name="X"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static FqNumber EMA(FqNumber X, int N)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = EMA(X[i], N);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// 返回平滑移动平均
        /// 用法: MEMA(X, N) :X的N日平滑移动平均,如Y=(X+Y'*(N-1))/N
        /// MEMA(X, N)相当于SMA(X, N,1)
        /// </summary>
        /// <param name="X"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static FqNumber MEMA(FqNumber X, int N)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = MEMA(X[i], N);
            }
            return new FqNumber(array);
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
        public static FqNumber AMA(FqNumber X, double N)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = AMA(X[i], N);
            }
            return new FqNumber(array);
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
        public static FqNumber DMA(FqNumber X, FqNumber A)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = DMA(X[i], A[i]);
            }
            return new FqNumber(array);
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
        public static FqNumber DMA(FqNumber X, double A)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = DMA(X[i], A);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// 返回加权移动平均
        /// 用法: WMA(X, N) :X的N日加权移动平均.算法:Yn=(1*X1+2*X2+...+n* Xn)/(1+2+...+n)
        /// </summary>
        /// <param name="X"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static FqNumber WMA(FqNumber X, int N)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = WMA(X[i], N);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// 过滤连续出现的信号.
        /// 用法: FILTER(X, N) :X满足条件后,将其后N周期内的数据置为0,N为常量.
        /// 例如: FILTER(CLOSE>OPEN,5)查找阳线,5天内再次出现的阳线不被记录在内
        /// </summary>
        /// <param name="X"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static FqNumber FILTER(FqNumber X, int N)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = FILTER(X[i], N);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// 过滤连续出现的信号.
        /// 用法: FILTER(X, N) :X满足条件后,将其后N周期内的数据置为0,N为常量.
        /// 例如: FILTER(CLOSE>OPEN,5)查找阳线,5天内再次出现的阳线不被记录在内
        /// </summary>
        /// <param name="X"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static FqNumber FILTER(FqBoolean X, int N)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = FILTER(X[i], N);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// 反向过滤连续出现的信号.
        /// 用法: FILTERX(X, N) :X满足条件后,将其前N周期内的数据置为0,N为常量.
        /// 例如: FILTERX(CLOSE>OPEN,5)查找阳线,前5天内出现过的阳线不被记录在内
        /// </summary>
        /// <param name="X"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static FqNumber FILTERX(FqNumber X, int N)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = FILTERX(X[i], N);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// 反向过滤连续出现的信号.
        /// 用法: FILTERX(X, N) :X满足条件后,将其前N周期内的数据置为0,N为常量.
        /// 例如: FILTERX(CLOSE>OPEN,5)查找阳线,前5天内出现过的阳线不被记录在内
        /// </summary>
        /// <param name="X"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static FqNumber FILTERX(FqBoolean X, int N)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = FILTERX(X[i], N);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// 求高值名次.
        /// 用法: HOD(X, N) :求当前X数据是N周期内的第几个高值,N=0则从第一个有效值开始.
        /// 例如: HOD(HIGH,20)返回是20日的第几个高价
        /// </summary>
        /// <param name="X"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static FqNumber HOD(FqNumber X, int N)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = HOD(X[i], N);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// 求低值名次.
        /// 用法: LOD(X, N) :求当前X数据是N周期内的第几个低值,N=0则从第一个有效值开始.
        /// 例如: LOD(LOW,20)返回是20日的第几个低价
        /// </summary>
        /// <param name="X"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static FqNumber LOD(FqNumber X, int N)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = LOD(X[i], N);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// 求累乘.
        /// 用法: MULAR(X, N),统计N周期中X的乘积.N=0则从第一个有效值开始.
        /// 例如: MULAR(C/REF(C,1),0)表示统计从上市第一天以来的复利
        /// </summary>
        /// <param name="X"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static FqNumber MULAR(FqNumber X, int N)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = MULAR(X[i], N);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// 返回周期数内是否连涨.
        /// 用法: UPNDAY(CLOSE, M) 表示连涨M个周期,M为常量
        /// </summary>
        /// <param name="X"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static FqNumber UPNDAY(FqNumber X, int N)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = UPNDAY(X[i], N);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// 返回周期数内是否连跌.
        /// 用法: DOWNNDAY(CLOSE, M) 表示连跌M个周期,M为常量
        /// </summary>
        /// <param name="X"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static FqNumber DOWNNDAY(FqNumber X, int N)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = DOWNNDAY(X[i], N);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// 是否存在.
        /// 例如: EXIST(CLOSE>OPEN,10) 表示10日内存在着阳线,第2个参数为常量
        /// </summary>
        /// <param name="X"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static FqNumber EXIST(FqNumber X, int N)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = EXIST(X[i], N);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// 是否存在.
        /// 例如: EXIST(CLOSE>OPEN,10) 表示10日内存在着阳线,第2个参数为常量
        /// </summary>
        /// <param name="X"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static FqNumber EXIST(FqBoolean X, int N)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = EXIST(X[i], N);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// 一直存在.
        /// 例如: EVERY(CLOSE>OPEN, N) 表示N日内一直阳线(N应大于0, 小于总周期数, N支持变量)
        /// </summary>
        /// <param name="X"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static FqNumber EVERY(FqNumber X, int N)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = EVERY(X[i], N);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// 一直存在.
        /// 例如: EVERY(CLOSE>OPEN, N) 表示N日内一直阳线(N应大于0, 小于总周期数, N支持变量)
        /// </summary>
        /// <param name="X"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static FqNumber EVERY(FqBoolean X, int N)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = EVERY(X[i], N);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// AVEDEV(X,N) 返回平均绝对偏差
        /// </summary>
        /// <param name="X"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static FqNumber AVEDEV(FqNumber X, int N)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = AVEDEV(X[i], N);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// DEVSQ(X,N) 返回数据偏差平方和
        /// </summary>
        /// <param name="X"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static FqNumber DEVSQ(FqNumber X, int N)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = DEVSQ(X[i], N);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// FORCAST(X,N) 返回线性回归预测值,N支持变量
        /// </summary>
        /// <param name="X"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static FqNumber FORCAST(FqNumber X, int N)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = FORCAST(X[i], N);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// SLOPE(X,N) 返回线性回归斜率,N支持变量
        /// </summary>
        /// <param name="X"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static FqNumber SLOPE(FqNumber X, int N)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = SLOPE(X[i], N);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// STD(X,N) 返回估算标准差,N支持变量
        /// </summary>
        /// <param name="X"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static FqNumber STD(FqNumber X, int N)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = STD(X[i], N);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// STDP(X,N) 返回总体标准差,N支持变量
        /// </summary>
        /// <param name="X"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static FqNumber STDP(FqNumber X, int N)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = STDP(X[i], N);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// VAR(X,N) 返回估算样本方差,N支持变量
        /// </summary>
        /// <param name="X"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static FqNumber VAR(FqNumber X, int N)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = VAR(X[i], N);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// VARP(X,N) 返回总体样本方差,N支持变量
        /// </summary>
        /// <param name="X"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static FqNumber VARP(FqNumber X, int N)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = VARP(X[i], N);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// VALUEWHEN(COND,X)
        /// 当COND条件成立时,取X的当前值,否则取VALUEWHEN的上个值.
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <returns></returns>
        public static FqNumber VALUEWHEN(FqNumber X, double Y)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = VALUEWHEN(X[i], Y);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// VALUEWHEN(COND,X)
        /// 当COND条件成立时,取X的当前值,否则取VALUEWHEN的上个值.
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <returns></returns>
        public static FqNumber VALUEWHEN(FqBoolean X, double Y)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = VALUEWHEN(X[i], Y);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// VALUEWHEN(COND,X)
        /// 当COND条件成立时,取X的当前值,否则取VALUEWHEN的上个值.
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <returns></returns>
        public static FqNumber VALUEWHEN(FqNumber X, FqNumber Y)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = VALUEWHEN(X[i], Y[i]);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// VALUEWHEN(COND,X)
        /// 当COND条件成立时,取X的当前值,否则取VALUEWHEN的上个值.
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <returns></returns>
        public static FqNumber VALUEWHEN(FqBoolean X, FqNumber Y)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = VALUEWHEN(X[i], Y[i]);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// VALUEWHEN(COND,X)
        /// 当COND条件成立时,取X的当前值,否则取VALUEWHEN的上个值.
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <returns></returns>
        public static FqNumber VALUEWHEN(bool X, FqNumber Y)
        {
            var array = new TdxNumber[Y.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = VALUEWHEN(X, Y[i]);
            }
            return new FqNumber(array);
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
        public static FqNumber IF(FqNumber X, FqNumber Y, FqNumber Z)
        {
            var array = new TdxNumber[Y.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = IF(X[i], Y[i], Z[i]);
            }
            return new FqNumber(array);
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
        public static FqNumber IF(FqBoolean X, FqNumber Y, FqNumber Z)
        {
            var array = new TdxNumber[Y.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = IF(X[i], Y[i], Z[i]);
            }
            return new FqNumber(array);
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
        public static FqNumber IF(bool X, FqNumber Y, FqNumber Z)
        {
            return X ? Y : Z;
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
        public static FqNumber IF(FqNumber X, FqNumber Y, double Z)
        {
            var array = new TdxNumber[Y.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = IF(X[i], Y[i], Z);
            }
            return new FqNumber(array);
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
        public static FqNumber IF(FqBoolean X, FqNumber Y, double Z)
        {
            var array = new TdxNumber[Y.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = IF(X[i], Y[i], Z);
            }
            return new FqNumber(array);
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
        public static FqNumber IF(bool X, FqNumber Y, double Z)
        {
            if (X) return Y;
            var array = new TdxNumber[Y.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = IF(X, Y[i], Z);
            }
            return new FqNumber(array);
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
        public static FqNumber IF(FqNumber X, double Y, FqNumber Z)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = IF(X[i], Y, Z[i]);
            }
            return new FqNumber(array);
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
        public static FqNumber IF(FqBoolean X, double Y, FqNumber Z)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = IF(X[i], Y, Z[i]);
            }
            return new FqNumber(array);
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
        public static FqNumber IF(bool X, double Y, FqNumber Z)
        {
            if (X == false) return Z;
            var array = new TdxNumber[Z.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = IF(X, Y, Z[i]);
            }
            return new FqNumber(array);
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
        public static FqNumber IF(FqNumber X, double Y, double Z)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = IF(X[i], Y, Z);
            }
            return new FqNumber(array);
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
        public static FqNumber IF(FqBoolean X, double Y, double Z)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = IF(X[i], Y, Z);
            }
            return new FqNumber(array);
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
        public static FqNumber IFN(FqNumber X, FqNumber Y, FqNumber Z)
        {
            var array = new TdxNumber[Y.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = IFN(X[i], Y[i], Z[i]);
            }
            return new FqNumber(array);
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
        public static FqNumber IFN(FqBoolean X, FqNumber Y, FqNumber Z)
        {
            var array = new TdxNumber[Y.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = IFN(X[i], Y[i], Z[i]);
            }
            return new FqNumber(array);
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
        public static FqNumber IFN(bool X, FqNumber Y, FqNumber Z)
        {
            return X == false ? Y : Z;
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
        public static FqNumber IFN(FqNumber X, FqNumber Y, double Z)
        {
            var array = new TdxNumber[Y.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = IFN(X[i], Y[i], Z);
            }
            return new FqNumber(array);
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
        public static FqNumber IFN(FqBoolean X, FqNumber Y, double Z)
        {
            var array = new TdxNumber[Y.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = IFN(X[i], Y[i], Z);
            }
            return new FqNumber(array);
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
        public static FqNumber IFN(bool X, FqNumber Y, double Z)
        {
            if (X == false) return Y;
            var array = new TdxNumber[Y.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = IFN(X, Y[i], Z);
            }
            return new FqNumber(array);
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
        public static FqNumber IFN(FqNumber X, double Y, FqNumber Z)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = IFN(X[i], Y, Z[i]);
            }
            return new FqNumber(array);
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
        public static FqNumber IFN(FqBoolean X, double Y, FqNumber Z)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = IFN(X[i], Y, Z[i]);
            }
            return new FqNumber(array);
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
        public static FqNumber IFN(bool X, double Y, FqNumber Z)
        {
            if (X) return Z;
            var array = new TdxNumber[Z.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = IFN(X, Y, Z[i]);
            }
            return new FqNumber(array);
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
        public static FqNumber IFN(FqNumber X, double Y, double Z)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = IFN(X[i], Y, Z);
            }
            return new FqNumber(array);
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
        public static FqNumber IFN(FqBoolean X, double Y, double Z)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = IFN(X[i], Y, Z);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// RANGE(A,B,C):A在B和C范围之间,B &lt; A &lt; C
        /// 用法: RANGE(A, B, C)表示A大于B同时小于C时返回1,否则返回0
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="Z"></param>
        /// <returns></returns>
        public static FqNumber RANGE(FqNumber X, FqNumber Y, FqNumber Z)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = RANGE(X[i], Y[i], Z[i]);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// RANGE(A,B,C):A在B和C范围之间,B&lt;A&lt;C
        /// 用法: RANGE(A, B, C)表示A大于B同时小于C时返回1,否则返回0
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="Z"></param>
        /// <returns></returns>
        public static FqNumber RANGE(FqNumber X, FqNumber Y, double Z)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = RANGE(X[i], Y[i], Z);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// RANGE(A,B,C):A在B和C范围之间,B&lt;A&lt;C
        /// 用法: RANGE(A, B, C)表示A大于B同时小于C时返回1,否则返回0
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="Z"></param>
        /// <returns></returns>
        public static FqNumber RANGE(FqNumber X, double Y, FqNumber Z)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = RANGE(X[i], Y, Z[i]);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// RANGE(A,B,C):A在B和C范围之间,B&lt;A&lt;C
        /// 用法: RANGE(A, B, C)表示A大于B同时小于C时返回1,否则返回0
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="Z"></param>
        /// <returns></returns>
        public static FqNumber RANGE(FqNumber X, double Y, double Z)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = RANGE(X[i], Y, Z);
            }
            return new FqNumber(array);
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
        public static FqNumber BETWEEN(FqNumber X, FqNumber Y, FqNumber Z)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = BETWEEN(X[i], Y[i], Z[i]);
            }
            return new FqNumber(array);
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
        public static FqNumber BETWEEN(FqNumber X, FqNumber Y, double Z)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = BETWEEN(X[i], Y[i], Z);
            }
            return new FqNumber(array);
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
        public static FqNumber BETWEEN(FqNumber X, double Y, FqNumber Z)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = BETWEEN(X[i], Y, Z[i]);
            }
            return new FqNumber(array);
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
        public static FqNumber BETWEEN(FqNumber X, double Y, double Z)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = BETWEEN(X[i], Y, Z);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// 返回移动平均
        /// 用法: SMA(X, N, M) :X的N日移动平均,M为权重,如Y=(X* M+Y'*(N-M))/N
        /// </summary>
        /// <param name="X"></param>
        /// <param name="N"></param>
        /// <param name="M"></param>
        /// <returns></returns>
        public static FqNumber SMA(FqNumber X, FqNumber N, FqNumber M)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = SMA(X[i], N[i], M[i]);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// 返回移动平均
        /// 用法: SMA(X, N, M) :X的N日移动平均,M为权重,如Y=(X* M+Y'*(N-M))/N
        /// </summary>
        /// <param name="X"></param>
        /// <param name="N"></param>
        /// <param name="M"></param>
        /// <returns></returns>
        public static FqNumber SMA(FqNumber X, FqNumber N, double M)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = SMA(X[i], N[i], M);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// 返回移动平均
        /// 用法: SMA(X, N, M) :X的N日移动平均,M为权重,如Y=(X* M+Y'*(N-M))/N
        /// </summary>
        /// <param name="X"></param>
        /// <param name="N"></param>
        /// <param name="M"></param>
        /// <returns></returns>
        public static FqNumber SMA(FqNumber X, double N, FqNumber M)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = SMA(X[i], N, M[i]);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// 返回移动平均
        /// 用法: SMA(X, N, M) :X的N日移动平均,M为权重,如Y=(X* M+Y'*(N-M))/N
        /// </summary>
        /// <param name="X"></param>
        /// <param name="N"></param>
        /// <param name="M"></param>
        /// <returns></returns>
        public static FqNumber SMA(FqNumber X, double N, double M)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = SMA(X[i], N, M);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// 返回移动平均
        /// 用法: TMA(X, A, B),A和B必须小于1,算法 Y = (A * Y'+B*X),其中Y'表示上一周期Y值.初值为X
        /// </summary>
        /// <param name="X"></param>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static FqNumber TMA(FqNumber X, FqNumber A, FqNumber B)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = TMA(X[i], A[i], B[i]);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// 返回移动平均
        /// 用法: TMA(X, A, B),A和B必须小于1,算法 Y = (A * Y'+B*X),其中Y'表示上一周期Y值.初值为X
        /// </summary>
        /// <param name="X"></param>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static FqNumber TMA(FqNumber X, FqNumber A, double B)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = TMA(X[i], A[i], B);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// 返回移动平均
        /// 用法: TMA(X, A, B),A和B必须小于1,算法 Y = (A * Y'+B*X),其中Y'表示上一周期Y值.初值为X
        /// </summary>
        /// <param name="X"></param>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static FqNumber TMA(FqNumber X, double A, FqNumber B)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = TMA(X[i], A, B[i]);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// 返回移动平均
        /// 用法: TMA(X, A, B),A和B必须小于1,算法 Y = (A * Y'+B*X),其中Y'表示上一周期Y值.初值为X
        /// </summary>
        /// <param name="X"></param>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static FqNumber TMA(FqNumber X, double A, double B)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = TMA(X[i], A, B);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// 两条线维持一定周期后交叉.
        /// 用法:LONGCROSS(A, B, N)表示A在N周期内都小于B,本周期从下方向上穿过B时返回1,否则返回0
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static FqNumber LONGCROSS(FqNumber X, FqNumber Y, int N)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = LONGCROSS(X[i], Y[i], N);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// 两条线维持一定周期后交叉.
        /// 用法:LONGCROSS(A, B, N)表示A在N周期内都小于B,本周期从下方向上穿过B时返回1,否则返回0
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static FqNumber LONGCROSS(FqNumber X, double Y, int N)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = LONGCROSS(X[i], Y, N);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// 两条线维持一定周期后交叉.
        /// 用法:LONGCROSS(A, B, N)表示A在N周期内都小于B,本周期从下方向上穿过B时返回1,否则返回0
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static FqNumber LONGCROSS(double X, FqNumber Y, int N)
        {
            var array = new TdxNumber[Y.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = LONGCROSS(X, Y[i], N);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// 返回是否持续存在X>Y
        /// 用法: NDAY(CLOSE, OPEN,3) 表示连续3日收阳线
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static FqNumber NDAY(FqNumber X, FqNumber Y, int N)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = NDAY(X[i], Y[i], N);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// 返回是否持续存在X>Y
        /// 用法: NDAY(CLOSE, OPEN,3) 表示连续3日收阳线
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static FqNumber NDAY(FqNumber X, double Y, int N)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = NDAY(X[i], Y, N);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// 返回是否持续存在X>Y
        /// 用法: NDAY(CLOSE, OPEN,3) 表示连续3日收阳线
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static FqNumber NDAY(double X, FqNumber Y, int N)
        {
            var array = new TdxNumber[Y.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = NDAY(X, Y[i], N);
            }
            return new FqNumber(array);
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
        public static FqNumber EXISTR(FqNumber X, int N, int M)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = EXISTR(X[i], N, M);
            }
            return new FqNumber(array);
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
        public static FqNumber EXISTR(FqBoolean X, int N, int M)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = EXISTR(X[i], N, M);
            }
            return new FqNumber(array);
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
        public static FqNumber LAST(FqNumber X, int N, int M)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = LAST(X[i], N, M);
            }
            return new FqNumber(array);
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
        public static FqNumber LAST(FqBoolean X, int N, int M)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = LAST(X[i], N, M);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// COVAR(X,Y,N) 返回X和Y的N周期的协方差,N支持变量
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static FqNumber COVAR(FqNumber X, FqNumber Y, int N)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = COVAR(X[i], Y[i], N);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// RELATE(X,Y,N) 返回X和Y的N周期的相关系数,N支持变量
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static FqNumber RELATE(FqNumber X, FqNumber Y, int N)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = RELATE(X[i], Y[i], N);
            }
            return new FqNumber(array);
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
        public static FqNumber FINDHIGH(FqNumber X, int N, int M, int T)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = FINDHIGH(X[i], N, M, T);
            }
            return new FqNumber(array);
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
        public static FqNumber FINDLOW(FqNumber X, int N, int M, int T)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = FINDLOW(X[i], N, M, T);
            }
            return new FqNumber(array);
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
        public static FqNumber FINDHIGHBARS(FqNumber X, int N, int M, int T)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = FINDHIGHBARS(X[i], N, M, T);
            }
            return new FqNumber(array);
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
        public static FqNumber FINDLOWBARS(FqNumber X, int N, int M, int T)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = FINDLOWBARS(X[i], N, M, T);
            }
            return new FqNumber(array);
        }

        #region 未来函数

        /// <summary>
        /// 引用若干周期后的数据
        /// </summary>
        /// <param name="X"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static FqNumber REFV(FqNumber X, int N)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = REFV(X[i], N);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// 引用若干周期后的数据
        /// </summary>
        /// <param name="X"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static FqBoolean REFV(FqBoolean X, int N)
        {
            TdxBoolean[] array = new TdxBoolean[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = REFV(X[i], N);
            }
            return new FqBoolean(array);
        }

        /// <summary>
        /// 属于未来函数,之字转向.
        /// 用法: ZIGA(K, X),当价格变化超过X时转向,K表示0:开盘价,1:最高价,2:最低价,3:收盘价,其余:数组信息
        /// 例如: ZIGA(3,1.5)表示收盘价变化1.5元的ZIGA转向
        /// </summary>
        /// <param name="X"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static FqNumber ZIGA(FqNumber X, double N)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = ZIGA(X[i], N);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// 属于未来函数,之字转向.
        /// 用法: ZIG(K, N),当价格变化量超过N%时转向,K表示0:开盘价,1:最高价,2:最低价,3:收盘价,其余:数组信息
        /// 例如: ZIG(3,5)表示收盘价的5%的ZIG转向
        /// </summary>
        /// <param name="X"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static FqNumber ZIG(FqNumber X, double N)
        {
            var array = new TdxNumber[X.Length];
            for (int i = 0; i < array.Length; i++) {
                array[i] = ZIG(X[i], N);
            }
            return new FqNumber(array);
        }

        #endregion 未来函数
    }
}