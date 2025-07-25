# ToolGood.TdxFormula
===================
 
通达信函数库 麦语言 C#版


## 快速上手

``` cs

using ToolGood.TdxFormula;
using static ToolGood.TdxFormula.TdxMath;

....

        private static void KDJ(List<DbKDay> kday, int N, int M1, int M2)
        {
            TdxNumber CLOSE = kday.Select(q => q.Close).ToArray();
            TdxNumber HIGH = kday.Select(q => q.High).ToArray();
            TdxNumber LOW = kday.Select(q => q.Low).ToArray();

            var RSV = (CLOSE - LLV(LOW, N)) / (HHV(HIGH, N) - LLV(LOW, N)) * 100;
            var K = SMA(RSV, M1, 1);
            var D = SMA(K, M2, 1);
            var J = 3 * K - 2 * D;
        }
....

```