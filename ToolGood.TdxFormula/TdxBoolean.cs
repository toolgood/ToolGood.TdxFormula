using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolGood.TdxFormula
{
    /// <summary>
    /// 布尔组
    /// </summary>
    public partial class TdxBoolean
    {
        /// <summary>
        /// 长度
        /// </summary>
        public int Length { get; private set; }
        /// <summary>
        /// 值
        /// </summary>
        public bool[] Values { get; private set; }
        /// <summary>
        /// 最后的值
        /// </summary>
        public bool LastValue { get { return Values[Length - 1]; } }


        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="value"></param>
        public TdxBoolean(bool[] value)
        {
            Values = value;
            Length = value.Length;
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="value"></param>
        public TdxBoolean(List<bool> value)
        {
            Values = value.ToArray();
            Length = value.Count;
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="length">长度</param>
        public TdxBoolean(bool value, int length)
        {
            Values = new bool[length];
            Array.Fill(Values, value);
            this.Length = length;
        }

        #region operator
        /// <summary>
        /// 隐性转换
        /// </summary>
        /// <param name="obj"></param>
        public static implicit operator TdxBoolean(bool[] obj)
        {
            return new TdxBoolean(obj);
        }
        /// <summary>
        /// 隐性转换
        /// </summary>
        /// <param name="obj"></param>
        public static implicit operator bool[](TdxBoolean obj)
        {
            return obj.Values;
        }
        /// <summary>
        /// 隐性转换
        /// </summary>
        /// <param name="obj"></param>
        public static implicit operator TdxBoolean(List<bool> obj)
        {
            return new TdxBoolean(obj);
        }
        #endregion

        #region this[int i]
        /// <summary>
        /// this[i]
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public bool this[int i] {
            [System.Diagnostics.DebuggerNonUserCode]
            get { return Values[i]; }
            [System.Diagnostics.DebuggerNonUserCode]
            set { Values[i] = value; }
        }

        #endregion

        #region operator &
        /// <summary>
        /// operator &amp;
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static bool[] operator &(TdxBoolean a, TdxBoolean b)
        {
            if (a.Length != b.Length) throw new Exception();
            bool[] temp = new bool[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = a[i] && b[i];
            }
            return temp;
        }
        /// <summary>
        /// operator &amp;
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static bool[] operator &(TdxBoolean a, bool[] b)
        {
            if (a.Length != b.Length) throw new Exception();
            bool[] temp = new bool[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = a[i] && b[i];
            }
            return temp;
        }
        /// <summary>
        /// operator &amp;
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static bool[] operator &(bool[] a, TdxBoolean b)
        {
            if (a.Length != b.Length) throw new Exception();
            bool[] temp = new bool[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = a[i] && b[i];
            }
            return temp;
        }
        /// <summary>
        /// operator &amp;
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static bool[] operator &(bool a, TdxBoolean b)
        {
            bool[] temp = new bool[b.Length];
            for (int i = 0; i < b.Length; i++) {
                temp[i] = a && b[i];
            }
            return temp;
        }

        /// <summary>
        /// operator &amp;
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static bool[] operator &(TdxBoolean a, bool b)
        {
            bool[] temp = new bool[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = a[i] & b;
            }
            return temp;
        }
        #endregion

        #region operator |
        /// <summary>
        /// operator |
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static bool[] operator |(TdxBoolean a, TdxBoolean b)
        {
            if (a.Length != b.Length) throw new Exception();
            bool[] temp = new bool[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = a[i] || b[i];
            }
            return temp;
        }
        /// <summary>
        /// operator |
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static bool[] operator |(TdxBoolean a, bool[] b)
        {
            if (a.Length != b.Length) throw new Exception();
            bool[] temp = new bool[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = a[i] || b[i];
            }
            return temp;
        }
        /// <summary>
        /// operator |
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static bool[] operator |(bool[] a, TdxBoolean b)
        {
            if (a.Length != b.Length) throw new Exception();
            bool[] temp = new bool[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = a[i] || b[i];
            }
            return temp;
        }
        /// <summary>
        /// operator |
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static bool[] operator |(bool a, TdxBoolean b)
        {
            bool[] temp = new bool[b.Length];
            for (int i = 0; i < b.Length; i++) {
                temp[i] = a || b[i];
            }
            return temp;
        }

        /// <summary>
        /// operator |
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static bool[] operator |(TdxBoolean a, bool b)
        {
            bool[] temp = new bool[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = a[i] | b;
            }
            return temp;
        }
        #endregion

        #region operator <
        /// <summary>
        /// operator &amp;lt;
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static TdxBoolean operator <(TdxBoolean a, double[] b)
        {
            if (a.Length < b.Length) throw new Exception();
            bool[] temp = new bool[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = (a[i] ? 1 : 0) < b[i];
            }
            return new TdxBoolean(temp);
        }
        /// <summary>
        /// operator &amp;lt;
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static TdxBoolean operator <(TdxBoolean a, double b)
        {
            bool[] temp = new bool[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = (a[i] ? 1 : 0) < b;
            }
            return new TdxBoolean(temp);
        }
        /// <summary>
        /// operator &amp;lt;
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static TdxBoolean operator <(double[] a, TdxBoolean b)
        {
            if (a.Length < b.Length) throw new Exception();
            bool[] temp = new bool[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = a[i] < (b[i] ? 1 : 0);
            }
            return new TdxBoolean(temp);
        }
        /// <summary>
        /// operator &amp;lt;
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static TdxBoolean operator <(double a, TdxBoolean b)
        {
            bool[] temp = new bool[b.Length];
            for (int i = 0; i < b.Length; i++) {
                temp[i] = a < (b[i] ? 1 : 0);
            }
            return new TdxBoolean(temp);
        }

        /// <summary>
        /// operator &amp;lt;
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static TdxBoolean operator <(TdxBoolean a, TdxBoolean b)
        {
            if (a.Length < b.Length) throw new Exception();
            bool[] temp = new bool[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = (a[i] ? 1 : 0) < (b[i] ? 1 : 0);
            }
            return new TdxBoolean(temp);
        }
        /// <summary>
        /// operator &amp;lt;
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static TdxBoolean operator <(TdxBoolean a, bool[] b)
        {
            if (a.Length < b.Length) throw new Exception();
            bool[] temp = new bool[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = (a[i] ? 1 : 0) < (b[i] ? 1 : 0);
            }
            return new TdxBoolean(temp);
        }
        /// <summary>
        /// operator &amp;lt;
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static TdxBoolean operator <(bool[] a, TdxBoolean b)
        {
            if (a.Length < b.Length) throw new Exception();
            bool[] temp = new bool[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = (a[i] ? 1 : 0) < (b[i] ? 1 : 0);
            }
            return new TdxBoolean(temp);
        }
        /// <summary>
        /// operator &amp;lt;
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static TdxBoolean operator <(bool a, TdxBoolean b)
        {
            bool[] temp = new bool[b.Length];
            for (int i = 0; i < b.Length; i++) {
                temp[i] = (a ? 1 : 0) < (b[i] ? 1 : 0);
            }
            return new TdxBoolean(temp);
        }

        /// <summary>
        /// operator &amp;lt;
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static TdxBoolean operator <(TdxBoolean a, bool b)
        {
            bool[] temp = new bool[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = (a[i] ? 1 : 0) < (b ? 1 : 0);
            }
            return new TdxBoolean(temp);
        }
        #endregion

        #region operator >
        /// <summary>
        /// operator >
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static TdxBoolean operator >(TdxBoolean a, double[] b)
        {
            if (a.Length > b.Length) throw new Exception();
            bool[] temp = new bool[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = (a[i] ? 1 : 0) > b[i];
            }
            return new TdxBoolean(temp);
        }
        /// <summary>
        /// operator >
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static TdxBoolean operator >(TdxBoolean a, double b)
        {
            bool[] temp = new bool[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = (a[i] ? 1 : 0) > b;
            }
            return new TdxBoolean(temp);
        }
        /// <summary>
        /// operator >
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static TdxBoolean operator >(double[] a, TdxBoolean b)
        {
            if (a.Length > b.Length) throw new Exception();
            bool[] temp = new bool[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = a[i] > (b[i] ? 1 : 0);
            }
            return new TdxBoolean(temp);
        }
        /// <summary>
        /// operator >
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static TdxBoolean operator >(double a, TdxBoolean b)
        {
            bool[] temp = new bool[b.Length];
            for (int i = 0; i < b.Length; i++) {
                temp[i] = a > (b[i] ? 1 : 0);
            }
            return new TdxBoolean(temp);
        }

        /// <summary>
        /// operator >
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static TdxBoolean operator >(TdxBoolean a, TdxBoolean b)
        {
            if (a.Length > b.Length) throw new Exception();
            bool[] temp = new bool[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = (a[i] ? 1 : 0) > (b[i] ? 1 : 0);
            }
            return new TdxBoolean(temp);
        }
        /// <summary>
        /// operator >
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static TdxBoolean operator >(TdxBoolean a, bool[] b)
        {
            if (a.Length > b.Length) throw new Exception();
            bool[] temp = new bool[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = (a[i] ? 1 : 0) > (b[i] ? 1 : 0);
            }
            return new TdxBoolean(temp);
        }
        /// <summary>
        /// operator >
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static TdxBoolean operator >(bool[] a, TdxBoolean b)
        {
            if (a.Length > b.Length) throw new Exception();
            bool[] temp = new bool[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = (a[i] ? 1 : 0) > (b[i] ? 1 : 0);
            }
            return new TdxBoolean(temp);
        }
        /// <summary>
        /// operator >
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static TdxBoolean operator >(bool a, TdxBoolean b)
        {
            bool[] temp = new bool[b.Length];
            for (int i = 0; i < b.Length; i++) {
                temp[i] = (a ? 1 : 0) > (b[i] ? 1 : 0);
            }
            return new TdxBoolean(temp);
        }

        /// <summary>
        /// operator >
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static TdxBoolean operator >(TdxBoolean a, bool b)
        {
            bool[] temp = new bool[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = (a[i] ? 1 : 0) > (b ? 1 : 0);
            }
            return new TdxBoolean(temp);
        }
        #endregion

        #region operator <=
        /// <summary>
        /// operator &amp;lt;=
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static TdxBoolean operator <=(TdxBoolean a, double[] b)
        {
            if (a.Length <= b.Length) throw new Exception();
            bool[] temp = new bool[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = (a[i] ? 1 : 0) <= b[i];
            }
            return new TdxBoolean(temp);
        }
        /// <summary>
        /// operator &amp;lt;=
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static TdxBoolean operator <=(TdxBoolean a, double b)
        {
            bool[] temp = new bool[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = (a[i] ? 1 : 0) <= b;
            }
            return new TdxBoolean(temp);
        }
        /// <summary>
        /// operator &amp;lt;=
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static TdxBoolean operator <=(double[] a, TdxBoolean b)
        {
            if (a.Length <= b.Length) throw new Exception();
            bool[] temp = new bool[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = a[i] <= (b[i] ? 1 : 0);
            }
            return new TdxBoolean(temp);
        }
        /// <summary>
        /// operator &amp;lt;=
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static TdxBoolean operator <=(double a, TdxBoolean b)
        {
            bool[] temp = new bool[b.Length];
            for (int i = 0; i < b.Length; i++) {
                temp[i] = a <= (b[i] ? 1 : 0);
            }
            return new TdxBoolean(temp);
        }

        /// <summary>
        /// operator &amp;lt;=
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static TdxBoolean operator <=(TdxBoolean a, TdxBoolean b)
        {
            if (a.Length <= b.Length) throw new Exception();
            bool[] temp = new bool[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = (a[i] ? 1 : 0) <= (b[i] ? 1 : 0);
            }
            return new TdxBoolean(temp);
        }
        /// <summary>
        /// operator &amp;lt;=
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static TdxBoolean operator <=(TdxBoolean a, bool[] b)
        {
            if (a.Length <= b.Length) throw new Exception();
            bool[] temp = new bool[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = (a[i] ? 1 : 0) <= (b[i] ? 1 : 0);
            }
            return new TdxBoolean(temp);
        }
        /// <summary>
        /// operator &amp;lt;=
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static TdxBoolean operator <=(bool[] a, TdxBoolean b)
        {
            if (a.Length <= b.Length) throw new Exception();
            bool[] temp = new bool[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = (a[i] ? 1 : 0) <= (b[i] ? 1 : 0);
            }
            return new TdxBoolean(temp);
        }
        /// <summary>
        /// operator &amp;lt;=
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static TdxBoolean operator <=(bool a, TdxBoolean b)
        {
            bool[] temp = new bool[b.Length];
            for (int i = 0; i < b.Length; i++) {
                temp[i] = (a ? 1 : 0) <= (b[i] ? 1 : 0);
            }
            return new TdxBoolean(temp);
        }

        /// <summary>
        /// operator &amp;lt;=
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static TdxBoolean operator <=(TdxBoolean a, bool b)
        {
            bool[] temp = new bool[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = (a[i] ? 1 : 0) <= (b ? 1 : 0);
            }
            return new TdxBoolean(temp);
        }
        #endregion

        #region operator >=
        /// <summary>
        /// operator >=
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static TdxBoolean operator >=(TdxBoolean a, double[] b)
        {
            if (a.Length >= b.Length) throw new Exception();
            bool[] temp = new bool[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = (a[i] ? 1 : 0) >= b[i];
            }
            return new TdxBoolean(temp);
        }
        /// <summary>
        /// operator >=
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static TdxBoolean operator >=(TdxBoolean a, double b)
        {
            bool[] temp = new bool[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = (a[i] ? 1 : 0) >= b;
            }
            return new TdxBoolean(temp);
        }
        /// <summary>
        /// operator >=
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static TdxBoolean operator >=(double[] a, TdxBoolean b)
        {
            if (a.Length >= b.Length) throw new Exception();
            bool[] temp = new bool[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = a[i] >= (b[i] ? 1 : 0);
            }
            return new TdxBoolean(temp);
        }
        /// <summary>
        /// operator >=
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static TdxBoolean operator >=(double a, TdxBoolean b)
        {
            bool[] temp = new bool[b.Length];
            for (int i = 0; i < b.Length; i++) {
                temp[i] = a >= (b[i] ? 1 : 0);
            }
            return new TdxBoolean(temp);
        }

        /// <summary>
        /// operator >=
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static TdxBoolean operator >=(TdxBoolean a, TdxBoolean b)
        {
            if (a.Length >= b.Length) throw new Exception();
            bool[] temp = new bool[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = (a[i]?1:0) >= (b[i] ? 1 : 0);
            }
            return new TdxBoolean(temp);
        }
        /// <summary>
        /// operator >=
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static TdxBoolean operator >=(TdxBoolean a, bool[] b)
        {
            if (a.Length >= b.Length) throw new Exception();
            bool[] temp = new bool[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = (a[i] ? 1 : 0) >= (b[i] ? 1 : 0);
            }
            return new TdxBoolean(temp);
        }
        /// <summary>
        /// operator >=
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static TdxBoolean operator >=(bool[] a, TdxBoolean b)
        {
            if (a.Length >= b.Length) throw new Exception();
            bool[] temp = new bool[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = (a[i] ? 1 : 0) >= (b[i] ? 1 : 0);
            }
            return new TdxBoolean(temp);
        }
        /// <summary>
        /// operator >=
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static TdxBoolean operator >=(bool a, TdxBoolean b)
        {
            bool[] temp = new bool[b.Length];
            for (int i = 0; i < b.Length; i++) {
                temp[i] = (a ? 1 : 0) >= (b[i] ? 1 : 0);
            }
            return new TdxBoolean(temp);
        }

        /// <summary>
        /// operator >=
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static TdxBoolean operator >=(TdxBoolean a, bool b)
        {
            bool[] temp = new bool[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = (a[i] ? 1 : 0) >= (b ? 1 : 0);
            }
            return new TdxBoolean(temp);
        }
        #endregion

        #region operator ==
        /// <summary>
        /// operator ==
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static TdxBoolean operator ==(TdxBoolean a, double[] b)
        {
            if (a.Length != b.Length) throw new Exception();
            bool[] temp = new bool[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = (a[i] ? 1 : 0) == b[i];
            }
            return new TdxBoolean(temp);
        }
        /// <summary>
        /// operator ==
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static TdxBoolean operator ==(TdxBoolean a, double b)
        {
            bool[] temp = new bool[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = (a[i] ? 1 : 0) == b;
            }
            return new TdxBoolean(temp);
        }
        /// <summary>
        /// operator ==
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static TdxBoolean operator ==(double[] a, TdxBoolean b)
        {
            if (a.Length != b.Length) throw new Exception();
            bool[] temp = new bool[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = a[i] == (b[i] ? 1 : 0);
            }
            return new TdxBoolean(temp);
        }
        /// <summary>
        /// operator ==
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static TdxBoolean operator ==(double a, TdxBoolean b)
        {
            bool[] temp = new bool[b.Length];
            for (int i = 0; i < b.Length; i++) {
                temp[i] = a == (b[i] ? 1 : 0);
            }
            return new TdxBoolean(temp);
        }

        /// <summary>
        /// operator ==
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static TdxBoolean operator ==(TdxBoolean a, TdxBoolean b)
        {
            if (a.Length != b.Length) throw new Exception();
            bool[] temp = new bool[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = a[i] == b[i];
            }
            return new TdxBoolean(temp);
        }
        /// <summary>
        /// operator ==
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static TdxBoolean operator ==(TdxBoolean a, bool[] b)
        {
            if (a.Length != b.Length) throw new Exception();
            bool[] temp = new bool[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = a[i] == b[i];
            }
            return new TdxBoolean(temp);
        }
        /// <summary>
        /// operator ==
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static TdxBoolean operator ==(bool[] a, TdxBoolean b)
        {
            if (a.Length != b.Length) throw new Exception();
            bool[] temp = new bool[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = a[i] == b[i];
            }
            return new TdxBoolean(temp);
        }
        /// <summary>
        /// operator ==
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static TdxBoolean operator ==(bool a, TdxBoolean b)
        {
            bool[] temp = new bool[b.Length];
            for (int i = 0; i < b.Length; i++) {
                temp[i] = a == b[i];
            }
            return new TdxBoolean(temp);
        }

        /// <summary>
        /// operator ==
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static TdxBoolean operator ==(TdxBoolean a, bool b)
        {
            bool[] temp = new bool[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = a[i] == b;
            }
            return new TdxBoolean(temp);
        }
        #endregion

        #region operator !=
        /// <summary>
        /// operator !=
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static TdxBoolean operator !=(TdxBoolean a, double[] b)
        {
            if (a.Length != b.Length) throw new Exception();
            bool[] temp = new bool[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = (a[i] ? 1 : 0) != b[i];
            }
            return new TdxBoolean(temp);
        }
        /// <summary>
        /// operator !=
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static TdxBoolean operator !=(TdxBoolean a, double b)
        {
            bool[] temp = new bool[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = (a[i] ? 1 : 0) != b;
            }
            return new TdxBoolean(temp);
        }
        /// <summary>
        /// operator !=
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static TdxBoolean operator !=(double[] a, TdxBoolean b)
        {
            if (a.Length != b.Length) throw new Exception();
            bool[] temp = new bool[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = a[i] != (b[i] ? 1 : 0);
            }
            return new TdxBoolean(temp);
        }
        /// <summary>
        /// operator !=
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static TdxBoolean operator !=(double a, TdxBoolean b)
        {
            bool[] temp = new bool[b.Length];
            for (int i = 0; i < b.Length; i++) {
                temp[i] = a != (b[i] ? 1 : 0);
            }
            return new TdxBoolean(temp);
        }

        /// <summary>
        /// operator !=
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static TdxBoolean operator !=(TdxBoolean a, TdxBoolean b)
        {
            if (a.Length != b.Length) throw new Exception();
            bool[] temp = new bool[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = a[i] != b[i];
            }
            return new TdxBoolean(temp);
        }
        /// <summary>
        /// operator !=
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static TdxBoolean operator !=(TdxBoolean a, bool[] b)
        {
            if (a.Length != b.Length) throw new Exception();
            bool[] temp = new bool[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = a[i] != b[i];
            }
            return new TdxBoolean(temp);
        }
        /// <summary>
        /// operator !=
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static TdxBoolean operator !=(bool[] a, TdxBoolean b)
        {
            if (a.Length != b.Length) throw new Exception();
            bool[] temp = new bool[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = a[i] != b[i];
            }
            return new TdxBoolean(temp);
        }
        /// <summary>
        /// operator !=
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static TdxBoolean operator !=(bool a, TdxBoolean b)
        {
            bool[] temp = new bool[b.Length];
            for (int i = 0; i < b.Length; i++) {
                temp[i] = a != b[i];
            }
            return new TdxBoolean(temp);
        }

        /// <summary>
        /// operator !=
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static TdxBoolean operator !=(TdxBoolean a, bool b)
        {
            bool[] temp = new bool[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = a[i] != b;
            }
            return new TdxBoolean(temp);
        }
        #endregion

        #region operator +
        /// <summary>
        /// operator +
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static TdxNumber operator +(TdxBoolean a, TdxBoolean b)
        {
            if (a.Length != b.Length) throw new Exception();
            double[] temp = new double[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = (a[i] ? 1 : 0) + (b[i] ? 1 : 0);
            }
            return new TdxNumber(temp);
        }
        /// <summary>
        /// operator +
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static TdxNumber operator +(TdxBoolean a, bool[] b)
        {
            if (a.Length != b.Length) throw new Exception();
            double[] temp = new double[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = (a[i] ? 1 : 0) + (b[i] ? 1 : 0);
            }
            return new TdxNumber(temp);
        }
        /// <summary>
        /// operator +
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static TdxNumber operator +(bool[] a, TdxBoolean b)
        {
            if (a.Length != b.Length) throw new Exception();
            double[] temp = new double[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = (a[i] ? 1 : 0) + (b[i] ? 1 : 0);
            }
            return new TdxNumber(temp);
        }
        /// <summary>
        /// operator +
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static TdxNumber operator +(TdxBoolean a, double[] b)
        {
            if (a.Length != b.Length) throw new Exception();
            double[] temp = new double[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = (a[i] ? 1 : 0) + b[i];
            }
            return new TdxNumber(temp);
        }
        /// <summary>
        /// operator +
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static TdxNumber operator +(double[] a, TdxBoolean b)
        {
            if (a.Length != b.Length) throw new Exception();
            double[] temp = new double[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = a[i] + (b[i] ? 1 : 0);
            }
            return new TdxNumber(temp);
        }
        /// <summary>
        /// operator +
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static TdxNumber operator +(TdxBoolean a, bool b)
        {
            double[] temp = new double[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = (a[i] ? 1 : 0) + (b ? 1 : 0);
            }
            return new TdxNumber(temp);
        }
        /// <summary>
        /// operator +
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static TdxNumber operator +(bool a, TdxBoolean b)
        {
            double[] temp = new double[b.Length];
            for (int i = 0; i < b.Length; i++) {
                temp[i] = (a ? 1 : 0) + (b[i] ? 1 : 0);
            }
            return new TdxNumber(temp);
        }
        /// <summary>
        /// operator +
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static TdxNumber operator +(TdxBoolean a, double b)
        {
            double[] temp = new double[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = (a[i] ? 1 : 0) + b;
            }
            return new TdxNumber(temp);
        }
        /// <summary>
        /// operator +
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static TdxNumber operator +(double a, TdxBoolean b)
        {
            double[] temp = new double[b.Length];
            for (int i = 0; i < b.Length; i++) {
                temp[i] = a + (b[i] ? 1 : 0);
            }
            return new TdxNumber(temp);
        }
        #endregion

        #region operator -
        /// <summary>
        /// operator -
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static TdxNumber operator -(TdxBoolean a, TdxBoolean b)
        {
            if (a.Length != b.Length) throw new Exception();
            double[] temp = new double[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = (a[i] ? 1 : 0) - (b[i] ? 1 : 0);
            }
            return new TdxNumber(temp);
        }
        /// <summary>
        /// operator -
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static TdxNumber operator -(TdxBoolean a, bool[] b)
        {
            if (a.Length != b.Length) throw new Exception();
            double[] temp = new double[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = (a[i] ? 1 : 0) - (b[i] ? 1 : 0);
            }
            return new TdxNumber(temp);
        }
        /// <summary>
        /// operator -
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static TdxNumber operator -(bool[] a, TdxBoolean b)
        {
            if (a.Length != b.Length) throw new Exception();
            double[] temp = new double[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = (a[i] ? 1 : 0) - (b[i] ? 1 : 0);
            }
            return new TdxNumber(temp);
        }
        /// <summary>
        /// operator -
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static TdxNumber operator -(TdxBoolean a, double[] b)
        {
            if (a.Length != b.Length) throw new Exception();
            double[] temp = new double[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = (a[i] ? 1 : 0) - b[i];
            }
            return new TdxNumber(temp);
        }
        /// <summary>
        /// operator -
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static TdxNumber operator -(double[] a, TdxBoolean b)
        {
            if (a.Length != b.Length) throw new Exception();
            double[] temp = new double[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = a[i] - (b[i] ? 1 : 0);
            }
            return new TdxNumber(temp);
        }
        /// <summary>
        /// operator -
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static TdxNumber operator -(TdxBoolean a, bool b)
        {
            double[] temp = new double[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = (a[i] ? 1 : 0) - (b ? 1 : 0);
            }
            return new TdxNumber(temp);
        }
        /// <summary>
        /// operator -
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static TdxNumber operator -(bool a, TdxBoolean b)
        {
            double[] temp = new double[b.Length];
            for (int i = 0; i < b.Length; i++) {
                temp[i] = (a ? 1 : 0) - (b[i] ? 1 : 0);
            }
            return new TdxNumber(temp);
        }
        /// <summary>
        /// operator -
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static TdxNumber operator -(TdxBoolean a, double b)
        {
            double[] temp = new double[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = (a[i] ? 1 : 0) - b;
            }
            return new TdxNumber(temp);
        }
        /// <summary>
        /// operator -
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static TdxNumber operator -(double a, TdxBoolean b)
        {
            double[] temp = new double[b.Length];
            for (int i = 0; i < b.Length; i++) {
                temp[i] = a - (b[i] ? 1 : 0);
            }
            return new TdxNumber(temp);
        }
        #endregion

        #region operator *
        /// <summary>
        /// operator *
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static TdxNumber operator *(TdxBoolean a, TdxBoolean b)
        {
            if (a.Length != b.Length) throw new Exception();
            double[] temp = new double[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = (a[i] ? 1 : 0) * (b[i] ? 1 : 0);
            }
            return new TdxNumber(temp);
        }
        /// <summary>
        /// operator *
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static TdxNumber operator *(TdxBoolean a, bool[] b)
        {
            if (a.Length != b.Length) throw new Exception();
            double[] temp = new double[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = (a[i] ? 1 : 0) * (b[i] ? 1 : 0);
            }
            return new TdxNumber(temp);
        }
        /// <summary>
        /// operator *
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static TdxNumber operator *(bool[] a, TdxBoolean b)
        {
            if (a.Length != b.Length) throw new Exception();
            double[] temp = new double[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = (a[i] ? 1 : 0) * (b[i] ? 1 : 0);
            }
            return new TdxNumber(temp);
        }
        /// <summary>
        /// operator *
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static TdxNumber operator *(TdxBoolean a, double[] b)
        {
            if (a.Length != b.Length) throw new Exception();
            double[] temp = new double[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = (a[i] ? 1 : 0) * b[i];
            }
            return new TdxNumber(temp);
        }
        /// <summary>
        /// operator *
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static TdxNumber operator *(double[] a, TdxBoolean b)
        {
            if (a.Length != b.Length) throw new Exception();
            double[] temp = new double[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = a[i] * (b[i] ? 1 : 0);
            }
            return new TdxNumber(temp);
        }
        /// <summary>
        /// operator *
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static TdxNumber operator *(TdxBoolean a, bool b)
        {
            double[] temp = new double[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = (a[i] ? 1 : 0) * (b ? 1 : 0);
            }
            return new TdxNumber(temp);
        }
        /// <summary>
        /// operator *
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static TdxNumber operator *(bool a, TdxBoolean b)
        {
            double[] temp = new double[b.Length];
            for (int i = 0; i < b.Length; i++) {
                temp[i] = (a ? 1 : 0) * (b[i] ? 1 : 0);
            }
            return new TdxNumber(temp);
        }
        /// <summary>
        /// operator *
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static TdxNumber operator *(TdxBoolean a, double b)
        {
            double[] temp = new double[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = (a[i] ? 1 : 0) * b;
            }
            return new TdxNumber(temp);
        }
        /// <summary>
        /// operator *
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static TdxNumber operator *(double a, TdxBoolean b)
        {
            double[] temp = new double[b.Length];
            for (int i = 0; i < b.Length; i++) {
                temp[i] = a * (b[i] ? 1 : 0);
            }
            return new TdxNumber(temp);
        }
        #endregion

        #region operator /
        /// <summary>
        /// operator *
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static TdxNumber operator /(TdxBoolean a, double[] b)
        {
            if (a.Length != b.Length) throw new Exception();
            double[] temp = new double[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = (a[i] ? 1 : 0) / b[i];
            }
            return new TdxNumber(temp);
        }
        /// <summary>
        /// operator *
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static TdxNumber operator /(TdxBoolean a, double b)
        {
            double[] temp = new double[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = (a[i] ? 1 : 0) / b;
            }
            return new TdxNumber(temp);
        }

        #endregion

        #region override
        /// <summary>
        /// ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"TdxBoolean len: {Length} last: {LastValue}";
        }

        /// <summary>
        /// Equals
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return obj is TdxBoolean number &&
                   Length == number.Length &&
                   EqualityComparer<bool[]>.Default.Equals(Values, number.Values);
        }
        /// <summary>
        /// GetHashCode
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(Length, Values);
        }
        #endregion
    }
}
