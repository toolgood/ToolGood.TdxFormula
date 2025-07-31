using System;
using System.Collections.Generic;

namespace ToolGood.TdxFormula
{
    /// <summary>
    /// 复权后数据
    /// </summary>
    public class FqBoolean
    {
        /// <summary>
        /// 值
        /// </summary>
        public TdxBoolean[] Values { get; private set; }

        /// <summary>
        /// 长度
        /// </summary>
        public int Length { get { return Values.Length; } }

        #region 构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="numbers"></param>
        public FqBoolean(List<TdxBoolean> numbers)
        {
            Values = numbers.ToArray();
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="numbers"></param>
        public FqBoolean(TdxBoolean[] numbers)
        {
            Values = numbers;
        }

        /// <summary>
        /// 构造
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="valueFunc"></param>
        /// <returns></returns>
        public static FqBoolean Create<T>(IEnumerable<IEnumerable<T>> list, Func<T, bool> valueFunc) where T : class
        {
            var array = new List<TdxBoolean>();
            foreach (var item in list) {
                List<bool> temps = new List<bool>();
                foreach (var it in item) {
                    temps.Add(valueFunc(it));
                }
                array.Add(temps);
            }
            return new FqBoolean(array);
        }

        /// <summary>
        /// 构造
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="groupFunc"></param>
        /// <param name="valueFunc"></param>
        /// <returns></returns>
        public static FqBoolean Create<T>(IEnumerable<T> list, Func<T, string> groupFunc, Func<T, bool> valueFunc) where T : class
        {
            Dictionary<string, List<T>> dict = new Dictionary<string, List<T>>();
            foreach (var item in list) {
                var group = groupFunc(item);
                if (dict.ContainsKey(group) == false) {
                    dict[group] = new List<T>();
                }
                dict[group].Add(item);
            }
            var array = new List<TdxBoolean>();
            foreach (var (_, item) in dict) {
                bool[] temps = new bool[item.Count];
                for (int j = 0; j < item.Count; j++) {
                    temps[j] = valueFunc(item[j]);
                }
                array.Add(temps);
            }
            return new FqBoolean(array);
        }

        #endregion 构造函数

        #region this[int i]

        /// <summary>
        ///
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public TdxBoolean this[int i] {
            [System.Diagnostics.DebuggerNonUserCode]
            get { return Values[i]; }
            [System.Diagnostics.DebuggerNonUserCode]
            set { Values[i] = value; }
        }

        #endregion this[int i]

        #region operator &

        /// <summary>
        /// operator &amp;
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static FqBoolean operator &(FqBoolean a, FqBoolean b)
        {
            if (a.Length != b.Length) throw new Exception();
            TdxBoolean[] temp = new TdxBoolean[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = a[i] & b[i];
            }
            return new FqBoolean(temp);
        }

        /// <summary>
        /// operator &amp;
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static FqBoolean operator &(FqBoolean a, bool b)
        {
            TdxBoolean[] temp = new TdxBoolean[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = a[i] & b;
            }
            return new FqBoolean(temp);
        }

        /// <summary>
        /// operator &amp;
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static FqBoolean operator &(bool a, FqBoolean b)
        {
            TdxBoolean[] temp = new TdxBoolean[b.Length];
            for (int i = 0; i < b.Length; i++) {
                temp[i] = a & b[i];
            }
            return new FqBoolean(temp);
        }

        #endregion operator &

        #region operator |

        /// <summary>
        /// operator |
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static FqBoolean operator |(FqBoolean a, FqBoolean b)
        {
            if (a.Length != b.Length) throw new Exception();
            TdxBoolean[] temp = new TdxBoolean[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = a[i] | b[i];
            }
            return new FqBoolean(temp);
        }

        /// <summary>
        /// operator |
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static FqBoolean operator |(FqBoolean a, bool b)
        {
            TdxBoolean[] temp = new TdxBoolean[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = a[i] | b;
            }
            return new FqBoolean(temp);
        }

        /// <summary>
        /// operator |
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static FqBoolean operator |(bool a, FqBoolean b)
        {
            TdxBoolean[] temp = new TdxBoolean[b.Length];
            for (int i = 0; i < b.Length; i++) {
                temp[i] = a | b[i];
            }
            return new FqBoolean(temp);
        }

        #endregion operator |

        #region operator >

        /// <summary>
        /// operator >
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static FqBoolean operator >(FqBoolean a, FqBoolean b)
        {
            if (a.Length != b.Length) throw new Exception();
            TdxBoolean[] temp = new TdxBoolean[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = a[i] > b[i];
            }
            return new FqBoolean(temp);
        }

        /// <summary>
        /// operator >
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static FqBoolean operator >(FqBoolean a, double b)
        {
            TdxBoolean[] temp = new TdxBoolean[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = a[i] > b;
            }
            return new FqBoolean(temp);
        }

        /// <summary>
        /// operator >
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static FqBoolean operator >(double a, FqBoolean b)
        {
            TdxBoolean[] temp = new TdxBoolean[b.Length];
            for (int i = 0; i < b.Length; i++) {
                temp[i] = a > b[i];
            }
            return new FqBoolean(temp);
        }

        /// <summary>
        /// operator >
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static FqBoolean operator >(FqBoolean a, bool b)
        {
            TdxBoolean[] temp = new TdxBoolean[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = a[i] > b;
            }
            return new FqBoolean(temp);
        }

        /// <summary>
        /// operator >
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static FqBoolean operator >(bool a, FqBoolean b)
        {
            TdxBoolean[] temp = new TdxBoolean[b.Length];
            for (int i = 0; i < b.Length; i++) {
                temp[i] = a > b[i];
            }
            return new FqBoolean(temp);
        }

        #endregion operator >

        #region operator <

        /// <summary>
        /// operator &lt;
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static FqBoolean operator <(FqBoolean a, FqBoolean b)
        {
            if (a.Length != b.Length) throw new Exception();
            TdxBoolean[] temp = new TdxBoolean[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = a[i] < b[i];
            }
            return new FqBoolean(temp);
        }

        /// <summary>
        /// operator &lt;
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static FqBoolean operator <(FqBoolean a, double b)
        {
            TdxBoolean[] temp = new TdxBoolean[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = a[i] < b;
            }
            return new FqBoolean(temp);
        }

        /// <summary>
        /// operator &lt;
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static FqBoolean operator <(double a, FqBoolean b)
        {
            TdxBoolean[] temp = new TdxBoolean[b.Length];
            for (int i = 0; i < b.Length; i++) {
                temp[i] = a < b[i];
            }
            return new FqBoolean(temp);
        }

        /// <summary>
        /// operator &lt;
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static FqBoolean operator <(FqBoolean a, bool b)
        {
            TdxBoolean[] temp = new TdxBoolean[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = a[i] < b;
            }
            return new FqBoolean(temp);
        }

        /// <summary>
        /// operator &lt;
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static FqBoolean operator <(bool a, FqBoolean b)
        {
            TdxBoolean[] temp = new TdxBoolean[b.Length];
            for (int i = 0; i < b.Length; i++) {
                temp[i] = a < b[i];
            }
            return new FqBoolean(temp);
        }

        #endregion operator <

        #region operator >=

        /// <summary>
        /// operator >=
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static FqBoolean operator >=(FqBoolean a, FqBoolean b)
        {
            if (a.Length != b.Length) throw new Exception();
            TdxBoolean[] temp = new TdxBoolean[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = a[i] >= b[i];
            }
            return new FqBoolean(temp);
        }

        /// <summary>
        /// operator >=
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static FqBoolean operator >=(FqBoolean a, double b)
        {
            TdxBoolean[] temp = new TdxBoolean[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = a[i] >= b;
            }
            return new FqBoolean(temp);
        }

        /// <summary>
        /// operator >=
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static FqBoolean operator >=(double a, FqBoolean b)
        {
            TdxBoolean[] temp = new TdxBoolean[b.Length];
            for (int i = 0; i < b.Length; i++) {
                temp[i] = a >= b[i];
            }
            return new FqBoolean(temp);
        }

        /// <summary>
        /// operator >=
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static FqBoolean operator >=(FqBoolean a, bool b)
        {
            TdxBoolean[] temp = new TdxBoolean[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = a[i] >= b;
            }
            return new FqBoolean(temp);
        }

        /// <summary>
        /// operator >=
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static FqBoolean operator >=(bool a, FqBoolean b)
        {
            TdxBoolean[] temp = new TdxBoolean[b.Length];
            for (int i = 0; i < b.Length; i++) {
                temp[i] = a >= b[i];
            }
            return new FqBoolean(temp);
        }

        #endregion operator >=

        #region operator <=

        /// <summary>
        /// operator &lt;=
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static FqBoolean operator <=(FqBoolean a, FqBoolean b)
        {
            if (a.Length != b.Length) throw new Exception();
            TdxBoolean[] temp = new TdxBoolean[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = a[i] <= b[i];
            }
            return new FqBoolean(temp);
        }

        /// <summary>
        /// operator &lt;=
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static FqBoolean operator <=(FqBoolean a, double b)
        {
            TdxBoolean[] temp = new TdxBoolean[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = a[i] <= b;
            }
            return new FqBoolean(temp);
        }

        /// <summary>
        /// operator &lt;=
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static FqBoolean operator <=(double a, FqBoolean b)
        {
            TdxBoolean[] temp = new TdxBoolean[b.Length];
            for (int i = 0; i < b.Length; i++) {
                temp[i] = a <= b[i];
            }
            return new FqBoolean(temp);
        }

        /// <summary>
        /// operator &lt;=
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static FqBoolean operator <=(FqBoolean a, bool b)
        {
            TdxBoolean[] temp = new TdxBoolean[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = a[i] <= b;
            }
            return new FqBoolean(temp);
        }

        /// <summary>
        /// operator &lt;=
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static FqBoolean operator <=(bool a, FqBoolean b)
        {
            TdxBoolean[] temp = new TdxBoolean[b.Length];
            for (int i = 0; i < b.Length; i++) {
                temp[i] = a <= b[i];
            }
            return new FqBoolean(temp);
        }

        #endregion operator <=

        #region operator ==

        /// <summary>
        /// operator ==
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static FqBoolean operator ==(FqBoolean a, FqBoolean b)
        {
            if (a.Length != b.Length) throw new Exception();
            TdxBoolean[] temp = new TdxBoolean[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = a[i] == b[i];
            }
            return new FqBoolean(temp);
        }

        /// <summary>
        /// operator ==
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static FqBoolean operator ==(FqBoolean a, double b)
        {
            TdxBoolean[] temp = new TdxBoolean[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = a[i] == b;
            }
            return new FqBoolean(temp);
        }

        /// <summary>
        /// operator ==
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static FqBoolean operator ==(double a, FqBoolean b)
        {
            TdxBoolean[] temp = new TdxBoolean[b.Length];
            for (int i = 0; i < b.Length; i++) {
                temp[i] = a == b[i];
            }
            return new FqBoolean(temp);
        }

        /// <summary>
        /// operator ==
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static FqBoolean operator ==(FqBoolean a, bool b)
        {
            TdxBoolean[] temp = new TdxBoolean[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = a[i] == b;
            }
            return new FqBoolean(temp);
        }

        /// <summary>
        /// operator ==
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static FqBoolean operator ==(bool a, FqBoolean b)
        {
            TdxBoolean[] temp = new TdxBoolean[b.Length];
            for (int i = 0; i < b.Length; i++) {
                temp[i] = a == b[i];
            }
            return new FqBoolean(temp);
        }

        #endregion operator ==

        #region operator !=

        /// <summary>
        /// operator ==
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static FqBoolean operator !=(FqBoolean a, FqBoolean b)
        {
            if (a.Length != b.Length) throw new Exception();
            TdxBoolean[] temp = new TdxBoolean[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = a[i] != b[i];
            }
            return new FqBoolean(temp);
        }

        /// <summary>
        /// operator !=
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static FqBoolean operator !=(FqBoolean a, double b)
        {
            TdxBoolean[] temp = new TdxBoolean[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = a[i] != b;
            }
            return new FqBoolean(temp);
        }

        /// <summary>
        /// operator !=
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static FqBoolean operator !=(double a, FqBoolean b)
        {
            TdxBoolean[] temp = new TdxBoolean[b.Length];
            for (int i = 0; i < b.Length; i++) {
                temp[i] = a != b[i];
            }
            return new FqBoolean(temp);
        }

        /// <summary>
        /// operator !=
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static FqBoolean operator !=(FqBoolean a, bool b)
        {
            TdxBoolean[] temp = new TdxBoolean[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = a[i] != b;
            }
            return new FqBoolean(temp);
        }

        /// <summary>
        /// operator !=
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static FqBoolean operator !=(bool a, FqBoolean b)
        {
            TdxBoolean[] temp = new TdxBoolean[b.Length];
            for (int i = 0; i < b.Length; i++) {
                temp[i] = a != b[i];
            }
            return new FqBoolean(temp);
        }

        #endregion operator !=

        #region operator +

        /// <summary>
        /// operator +
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static FqNumber operator +(FqBoolean a, FqBoolean b)
        {
            if (a.Length != b.Length) throw new Exception();
            TdxNumber[] temp = new TdxNumber[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = a[i] + b[i];
            }
            return new FqNumber(temp);
        }

        /// <summary>
        /// operator +
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static FqNumber operator +(FqBoolean a, double b)
        {
            TdxNumber[] temp = new TdxNumber[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = a[i] + b;
            }
            return new FqNumber(temp);
        }

        /// <summary>
        /// operator +
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static FqNumber operator +(double a, FqBoolean b)
        {
            TdxNumber[] temp = new TdxNumber[b.Length];
            for (int i = 0; i < b.Length; i++) {
                temp[i] = a + b[i];
            }
            return new FqNumber(temp);
        }

        /// <summary>
        /// operator +
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static FqNumber operator +(FqBoolean a, bool b)
        {
            TdxNumber[] temp = new TdxNumber[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = a[i] + b;
            }
            return new FqNumber(temp);
        }

        /// <summary>
        /// operator +
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static FqNumber operator +(bool a, FqBoolean b)
        {
            TdxNumber[] temp = new TdxNumber[b.Length];
            for (int i = 0; i < b.Length; i++) {
                temp[i] = a + b[i];
            }
            return new FqNumber(temp);
        }

        #endregion operator +

        #region operator -

        /// <summary>
        /// operator -
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static FqNumber operator -(FqBoolean a, FqBoolean b)
        {
            if (a.Length != b.Length) throw new Exception();
            TdxNumber[] temp = new TdxNumber[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = a[i] - b[i];
            }
            return new FqNumber(temp);
        }

        /// <summary>
        /// operator -
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static FqNumber operator -(FqBoolean a, double b)
        {
            TdxNumber[] temp = new TdxNumber[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = a[i] - b;
            }
            return new FqNumber(temp);
        }

        /// <summary>
        /// operator -
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static FqNumber operator -(double a, FqBoolean b)
        {
            TdxNumber[] temp = new TdxNumber[b.Length];
            for (int i = 0; i < b.Length; i++) {
                temp[i] = a - b[i];
            }
            return new FqNumber(temp);
        }

        /// <summary>
        /// operator -
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static FqNumber operator -(FqBoolean a, bool b)
        {
            TdxNumber[] temp = new TdxNumber[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = a[i] - b;
            }
            return new FqNumber(temp);
        }

        /// <summary>
        /// operator -
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static FqNumber operator -(bool a, FqBoolean b)
        {
            TdxNumber[] temp = new TdxNumber[b.Length];
            for (int i = 0; i < b.Length; i++) {
                temp[i] = a - b[i];
            }
            return new FqNumber(temp);
        }

        #endregion operator -

        #region operator *

        /// <summary>
        /// operator *
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static FqNumber operator *(FqBoolean a, FqBoolean b)
        {
            if (a.Length != b.Length) throw new Exception();
            TdxNumber[] temp = new TdxNumber[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = a[i] * b[i];
            }
            return new FqNumber(temp);
        }

        /// <summary>
        /// operator *
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static FqNumber operator *(FqBoolean a, double b)
        {
            TdxNumber[] temp = new TdxNumber[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = a[i] * b;
            }
            return new FqNumber(temp);
        }

        /// <summary>
        /// operator *
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static FqNumber operator *(double a, FqBoolean b)
        {
            TdxNumber[] temp = new TdxNumber[b.Length];
            for (int i = 0; i < b.Length; i++) {
                temp[i] = a * b[i];
            }
            return new FqNumber(temp);
        }

        /// <summary>
        /// operator *
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static FqNumber operator *(FqBoolean a, bool b)
        {
            TdxNumber[] temp = new TdxNumber[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = a[i] * b;
            }
            return new FqNumber(temp);
        }

        /// <summary>
        /// operator *
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static FqNumber operator *(bool a, FqBoolean b)
        {
            TdxNumber[] temp = new TdxNumber[b.Length];
            for (int i = 0; i < b.Length; i++) {
                temp[i] = a * b[i];
            }
            return new FqNumber(temp);
        }

        #endregion operator *

        #region operator /

        /// <summary>
        /// operator /
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static FqNumber operator /(FqBoolean a, double b)
        {
            TdxNumber[] temp = new TdxNumber[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = a[i] / b;
            }
            return new FqNumber(temp);
        }

        #endregion operator /

        #region operator %

        /// <summary>
        /// operator /
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static FqNumber operator %(FqBoolean a, double b)
        {
            TdxNumber[] temp = new TdxNumber[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = a[i] % b;
            }
            return new FqNumber(temp);
        }

        #endregion operator %

        #region override

        /// <summary>
        /// Equals
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return obj is FqBoolean number &&
                   Length == number.Length &&
                   EqualityComparer<TdxBoolean[]>.Default.Equals(Values, number.Values);
        }

        /// <summary>
        /// GetHashCode
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(Length, Values);
        }

        #endregion override
    }
}