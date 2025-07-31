using System;
using System.Collections.Generic;

namespace ToolGood.TdxFormula
{
    /// <summary>
    /// 复权后数据
    /// </summary>
    public class FqNumber
    {
        /// <summary>
        /// 值
        /// </summary>
        public TdxNumber[] Values { get; private set; }

        /// <summary>
        /// 长度
        /// </summary>
        public int Length { get { return Values.Length; } }

        #region 构造函数

        /// <summary>
        ///
        /// </summary>
        /// <param name="numbers"></param>
        public FqNumber(List<TdxNumber> numbers)
        {
            Values = numbers.ToArray();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="numbers"></param>
        public FqNumber(TdxNumber[] numbers)
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
        public static FqNumber Create<T>(IEnumerable<IEnumerable<T>> list, Func<T, double> valueFunc) where T : class
        {
            var array = new List<TdxNumber>();
            foreach (var item in list) {
                List<double> temps = new List<double>();
                foreach (var it in item) {
                    temps.Add(valueFunc(it));
                }
                array.Add(temps);
            }
            return new FqNumber(array);
        }

        /// <summary>
        /// 构造
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="groupFunc"></param>
        /// <param name="valueFunc"></param>
        /// <returns></returns>
        public static FqNumber Create<T>(IEnumerable<T> list, Func<T, string> groupFunc, Func<T, double> valueFunc) where T : class
        {
            Dictionary<string, List<T>> dict = new Dictionary<string, List<T>>();
            foreach (var item in list) {
                var group = groupFunc(item);
                if (dict.ContainsKey(group) == false) {
                    dict[group] = new List<T>();
                }
                dict[group].Add(item);
            }
            var array = new List<TdxNumber>();
            foreach (var (_, item) in dict) {
                double[] temps = new double[item.Count];
                for (int j = 0; j < item.Count; j++) {
                    temps[j] = valueFunc(item[j]);
                }
                array.Add(temps);
            }
            return new FqNumber(array);
        }
        /// <summary>
        /// 构造
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="groupFunc"></param>
        /// <param name="valueFunc"></param>
        /// <returns></returns>
        public static FqNumber Create<T>(IEnumerable<T> list, Func<T, int> groupFunc, Func<T, double> valueFunc) where T : class
        {
            Dictionary<int, List<T>> dict = new Dictionary<int, List<T>>();
            foreach (var item in list) {
                var group = groupFunc(item);
                if (dict.ContainsKey(group) == false) {
                    dict[group] = new List<T>();
                }
                dict[group].Add(item);
            }
            var array = new List<TdxNumber>();
            foreach (var (_, item) in dict) {
                double[] temps = new double[item.Count];
                for (int j = 0; j < item.Count; j++) {
                    temps[j] = valueFunc(item[j]);
                }
                array.Add(temps);
            }
            return new FqNumber(array);
        }

        #endregion 构造函数

        #region this[int i]

        /// <summary>
        ///
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public TdxNumber this[int i] {
            [System.Diagnostics.DebuggerNonUserCode]
            get { return Values[i]; }
            [System.Diagnostics.DebuggerNonUserCode]
            set { Values[i] = value; }
        }

        #endregion this[int i]

        #region operator +

        /// <summary>
        /// operator +
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static FqNumber operator +(FqNumber a, FqNumber b)
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
        public static FqNumber operator +(FqNumber a, double b)
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
        public static FqNumber operator +(double a, FqNumber b)
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
        public static FqNumber operator +(FqNumber a, FqBoolean b)
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
        public static FqNumber operator +(FqNumber a, bool b)
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
        public static FqNumber operator +(FqBoolean a, FqNumber b)
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
        public static FqNumber operator +(bool a, FqNumber b)
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
        public static FqNumber operator -(FqNumber a, FqNumber b)
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
        public static FqNumber operator -(FqNumber a, double b)
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
        public static FqNumber operator -(double a, FqNumber b)
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
        public static FqNumber operator -(FqNumber a, FqBoolean b)
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
        public static FqNumber operator -(FqNumber a, bool b)
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
        public static FqNumber operator -(FqBoolean a, FqNumber b)
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
        public static FqNumber operator -(bool a, FqNumber b)
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
        public static FqNumber operator *(FqNumber a, FqNumber b)
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
        public static FqNumber operator *(FqNumber a, double b)
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
        public static FqNumber operator *(double a, FqNumber b)
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
        public static FqNumber operator *(FqNumber a, FqBoolean b)
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
        public static FqNumber operator *(FqNumber a, bool b)
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
        public static FqNumber operator *(FqBoolean a, FqNumber b)
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
        public static FqNumber operator *(bool a, FqNumber b)
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
        public static FqNumber operator /(FqNumber a, FqNumber b)
        {
            if (a.Length != b.Length) throw new Exception();
            TdxNumber[] temp = new TdxNumber[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = a[i] / b[i];
            }
            return new FqNumber(temp);
        }

        /// <summary>
        /// operator /
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static FqNumber operator /(FqNumber a, double b)
        {
            TdxNumber[] temp = new TdxNumber[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = a[i] / b;
            }
            return new FqNumber(temp);
        }

        /// <summary>
        /// operator /
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static FqNumber operator /(double a, FqNumber b)
        {
            TdxNumber[] temp = new TdxNumber[b.Length];
            for (int i = 0; i < b.Length; i++) {
                temp[i] = a / b[i];
            }
            return new FqNumber(temp);
        }

        /// <summary>
        /// operator /
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static FqNumber operator /(FqNumber a, FqBoolean b)
        {
            if (a.Length != b.Length) throw new Exception();
            TdxNumber[] temp = new TdxNumber[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = a[i] / b[i];
            }
            return new FqNumber(temp);
        }

        /// <summary>
        /// operator /
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static FqNumber operator /(FqBoolean a, FqNumber b)
        {
            if (a.Length != b.Length) throw new Exception();
            TdxNumber[] temp = new TdxNumber[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = a[i] / b[i];
            }
            return new FqNumber(temp);
        }

        /// <summary>
        /// operator /
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static FqNumber operator /(bool a, FqNumber b)
        {
            TdxNumber[] temp = new TdxNumber[b.Length];
            for (int i = 0; i < b.Length; i++) {
                temp[i] = a / b[i];
            }
            return new FqNumber(temp);
        }

        #endregion operator /

        #region operator %

        /// <summary>
        /// operator %
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static FqNumber operator %(FqNumber a, FqNumber b)
        {
            if (a.Length != b.Length) throw new Exception();
            TdxNumber[] temp = new TdxNumber[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = a[i] % b[i];
            }
            return new FqNumber(temp);
        }

        /// <summary>
        /// operator %
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static FqNumber operator %(FqNumber a, double b)
        {
            TdxNumber[] temp = new TdxNumber[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = a[i] % b;
            }
            return new FqNumber(temp);
        }

        /// <summary>
        /// operator %
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static FqNumber operator %(double a, FqNumber b)
        {
            TdxNumber[] temp = new TdxNumber[b.Length];
            for (int i = 0; i < b.Length; i++) {
                temp[i] = a % b[i];
            }
            return new FqNumber(temp);
        }

        /// <summary>
        /// operator %
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static FqNumber operator %(FqNumber a, FqBoolean b)
        {
            if (a.Length != b.Length) throw new Exception();
            TdxNumber[] temp = new TdxNumber[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = a[i] % b[i];
            }
            return new FqNumber(temp);
        }

        /// <summary>
        /// operator %
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static FqNumber operator %(FqBoolean a, FqNumber b)
        {
            if (a.Length != b.Length) throw new Exception();
            TdxNumber[] temp = new TdxNumber[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = a[i] % b[i];
            }
            return new FqNumber(temp);
        }

        /// <summary>
        /// operator %
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static FqNumber operator %(bool a, FqNumber b)
        {
            TdxNumber[] temp = new TdxNumber[b.Length];
            for (int i = 0; i < b.Length; i++) {
                temp[i] = a % b[i];
            }
            return new FqNumber(temp);
        }

        #endregion operator %

        #region operator >

        /// <summary>
        /// operator >
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static FqBoolean operator >(FqNumber a, FqNumber b)
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
        public static FqBoolean operator >(FqNumber a, double b)
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
        public static FqBoolean operator >(double a, FqNumber b)
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
        public static FqBoolean operator >(FqNumber a, FqBoolean b)
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
        public static FqBoolean operator >(FqNumber a, bool b)
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
        public static FqBoolean operator >(FqBoolean a, FqNumber b)
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
        public static FqBoolean operator >(bool a, FqNumber b)
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
        public static FqBoolean operator <(FqNumber a, FqNumber b)
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
        public static FqBoolean operator <(FqNumber a, double b)
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
        public static FqBoolean operator <(double a, FqNumber b)
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
        public static FqBoolean operator <(FqNumber a, FqBoolean b)
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
        public static FqBoolean operator <(FqNumber a, bool b)
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
        public static FqBoolean operator <(FqBoolean a, FqNumber b)
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
        public static FqBoolean operator <(bool a, FqNumber b)
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
        public static FqBoolean operator >=(FqNumber a, FqNumber b)
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
        public static FqBoolean operator >=(FqNumber a, double b)
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
        public static FqBoolean operator >=(double a, FqNumber b)
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
        public static FqBoolean operator >=(FqNumber a, FqBoolean b)
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
        public static FqBoolean operator >=(FqNumber a, bool b)
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
        public static FqBoolean operator >=(FqBoolean a, FqNumber b)
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
        public static FqBoolean operator >=(bool a, FqNumber b)
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
        public static FqBoolean operator <=(FqNumber a, FqNumber b)
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
        public static FqBoolean operator <=(FqNumber a, double b)
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
        public static FqBoolean operator <=(double a, FqNumber b)
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
        public static FqBoolean operator <=(FqNumber a, FqBoolean b)
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
        public static FqBoolean operator <=(FqNumber a, bool b)
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
        public static FqBoolean operator <=(FqBoolean a, FqNumber b)
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
        public static FqBoolean operator <=(bool a, FqNumber b)
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
        public static FqBoolean operator ==(FqNumber a, FqNumber b)
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
        public static FqBoolean operator ==(FqNumber a, double b)
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
        public static FqBoolean operator ==(double a, FqNumber b)
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
        public static FqBoolean operator ==(FqNumber a, FqBoolean b)
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
        public static FqBoolean operator ==(FqNumber a, bool b)
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
        public static FqBoolean operator ==(FqBoolean a, FqNumber b)
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
        public static FqBoolean operator ==(bool a, FqNumber b)
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
        /// operator !=
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static FqBoolean operator !=(FqNumber a, FqNumber b)
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
        public static FqBoolean operator !=(FqNumber a, double b)
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
        public static FqBoolean operator !=(double a, FqNumber b)
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
        public static FqBoolean operator !=(FqNumber a, FqBoolean b)
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
        public static FqBoolean operator !=(FqNumber a, bool b)
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
        public static FqBoolean operator !=(FqBoolean a, FqNumber b)
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
        public static FqBoolean operator !=(bool a, FqNumber b)
        {
            TdxBoolean[] temp = new TdxBoolean[b.Length];
            for (int i = 0; i < b.Length; i++) {
                temp[i] = a != b[i];
            }
            return new FqBoolean(temp);
        }

        #endregion operator !=

        #region override

        /// <summary>
        /// Equals
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return obj is FqNumber number &&
                   Length == number.Length &&
                   EqualityComparer<TdxNumber[]>.Default.Equals(Values, number.Values);
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