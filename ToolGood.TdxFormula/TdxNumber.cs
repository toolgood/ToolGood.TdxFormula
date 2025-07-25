using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ToolGood.TdxFormula
{
    /// <summary>
    /// 数字组
    /// </summary>
    public partial class TdxNumber
    {
        /// <summary>
        /// 长度
        /// </summary>
        public int Length { get; private set; }
        /// <summary>
        /// 值
        /// </summary>
        public double[] Values { get; private set; }
        /// <summary>
        /// 最后的值
        /// </summary>
        public double LastValue { get { return Values[Length - 1]; } }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="value"></param>
        public TdxNumber(double[] value)
        {
            Values = value;
            Length = value.Length;
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="value"></param>
        public TdxNumber(List<double> value)
        {
            Values = value.ToArray();
            Length = value.Count;
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="length">长度</param>
        public TdxNumber(double value, int length)
        {
            Values = new double[length];
            Array.Fill(Values, value);
            this.Length = length;
        }


        #region operator
        /// <summary>
        /// 隐性转换
        /// </summary>
        /// <param name="obj"></param>
        public static implicit operator double[](TdxNumber obj)
        {
            return obj.Values;
        }
        /// <summary>
        /// 隐性转换
        /// </summary>
        /// <param name="obj"></param>
        public static implicit operator TdxNumber(double[] obj)
        {
            return new TdxNumber(obj);
        }
        /// <summary>
        /// 隐性转换
        /// </summary>
        /// <param name="obj"></param>
        public static implicit operator TdxNumber(List<double> obj)
        {
            return new TdxNumber(obj);
        }
        /// <summary>
        /// 隐性转换
        /// </summary>
        /// <param name="obj"></param>
        public static implicit operator TdxNumber(bool[] obj)
        {
            double[] array = new double[obj.Length];
            for (int i = 0; i < obj.Length; i++) {
                array[i] = obj[i] ? 1 : 0;
            }
            return new TdxNumber(array);
        }
        /// <summary>
        /// 隐性转换
        /// </summary>
        /// <param name="obj"></param>
        public static implicit operator TdxNumber(List<bool> obj)
        {
            double[] array = new double[obj.Count];
            for (int i = 0; i < obj.Count; i++) {
                array[i] = obj[i] ? 1 : 0;
            }
            return new TdxNumber(array);
        }
        /// <summary>
        /// 隐性转换
        /// </summary>
        /// <param name="obj"></param>
        public static implicit operator TdxNumber(TdxBoolean obj)
        {
            double[] array = new double[obj.Length];
            for (int i = 0; i < obj.Length; i++) {
                array[i] = obj[i] ? 1 : 0;
            }
            return new TdxNumber(array);
        }
        #endregion

        #region this[int i]
        /// <summary>
        /// this[i]
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public double this[int i] {
            [System.Diagnostics.DebuggerNonUserCode]
            get { return Values[i]; }
            [System.Diagnostics.DebuggerNonUserCode]
            set { Values[i] = value; }
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
        public static TdxNumber operator +(TdxNumber a, TdxNumber b)
        {
            if (a.Length != b.Length) throw new Exception();
            double[] temp = new double[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = a[i] + b[i];
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
        public static TdxNumber operator +(TdxNumber a, double[] b)
        {
            if (a.Length != b.Length) throw new Exception();
            double[] temp = new double[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = a[i] + b[i];
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
        public static TdxNumber operator +(TdxNumber a, double b)
        {
            double[] temp = new double[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = a[i] + b;
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
        public static TdxNumber operator +(double[] a, TdxNumber b)
        {
            if (a.Length != b.Length) throw new Exception();
            double[] temp = new double[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = a[i] + b[i];
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
        public static TdxNumber operator +(double a, TdxNumber b)
        {
            double[] temp = new double[b.Length];
            for (int i = 0; i < b.Length; i++) {
                temp[i] = a + b[i];
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
        public static TdxNumber operator +(TdxNumber a, TdxBoolean b)
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
        public static TdxNumber operator +(TdxNumber a, bool[] b)
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
        public static TdxNumber operator +(TdxNumber a, bool b)
        {
            double[] temp = new double[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = a[i] + (b ? 1 : 0);
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
        public static TdxNumber operator +(TdxBoolean a, TdxNumber b)
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
        public static TdxNumber operator +(bool[] a, TdxNumber b)
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
        public static TdxNumber operator +(bool a, TdxNumber b)
        {
            double[] temp = new double[b.Length];
            for (int i = 0; i < b.Length; i++) {
                temp[i] = (a ? 1 : 0) + b[i];
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
        public static TdxNumber operator -(TdxNumber a, TdxNumber b)
        {
            if (a.Length != b.Length) throw new Exception();
            double[] temp = new double[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = a[i] - b[i];
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
        public static TdxNumber operator -(TdxNumber a, double[] b)
        {
            if (a.Length != b.Length) throw new Exception();
            double[] temp = new double[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = a[i] - b[i];
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
        public static TdxNumber operator -(TdxNumber a, double b)
        {
            double[] temp = new double[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = a[i] - b;
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
        public static TdxNumber operator -(double[] a, TdxNumber b)
        {
            if (a.Length != b.Length) throw new Exception();
            double[] temp = new double[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = a[i] - b[i];
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
        public static TdxNumber operator -(double a, TdxNumber b)
        {
            double[] temp = new double[b.Length];
            for (int i = 0; i < b.Length; i++) {
                temp[i] = a - b[i];
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
        public static TdxNumber operator -(TdxNumber a, TdxBoolean b)
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
        public static TdxNumber operator -(TdxNumber a, bool[] b)
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
        public static TdxNumber operator -(TdxNumber a, bool b)
        {
            double[] temp = new double[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = a[i] - (b ? 1 : 0);
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
        public static TdxNumber operator -(TdxBoolean a, TdxNumber b)
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
        public static TdxNumber operator -(bool[] a, TdxNumber b)
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
        public static TdxNumber operator -(bool a, TdxNumber b)
        {
            double[] temp = new double[b.Length];
            for (int i = 0; i < b.Length; i++) {
                temp[i] = (a ? 1 : 0) - b[i];
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
        public static TdxNumber operator *(TdxNumber a, TdxNumber b)
        {
            if (a.Length != b.Length) throw new Exception();
            double[] temp = new double[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = a[i] * b[i];
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
        public static TdxNumber operator *(TdxNumber a, double[] b)
        {
            if (a.Length != b.Length) throw new Exception();
            double[] temp = new double[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = a[i] * b[i];
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
        public static TdxNumber operator *(TdxNumber a, double b)
        {
            double[] temp = new double[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = a[i] * b;
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
        public static TdxNumber operator *(double[] a, TdxNumber b)
        {
            if (a.Length != b.Length) throw new Exception();
            double[] temp = new double[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = a[i] * b[i];
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
        public static TdxNumber operator *(double a, TdxNumber b)
        {
            double[] temp = new double[b.Length];
            for (int i = 0; i < b.Length; i++) {
                temp[i] = a * b[i];
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
        public static TdxNumber operator *(TdxNumber a, TdxBoolean b)
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
        public static TdxNumber operator *(TdxNumber a, bool[] b)
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
        public static TdxNumber operator *(TdxNumber a, bool b)
        {
            double[] temp = new double[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = a[i] * (b ? 1 : 0);
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
        public static TdxNumber operator *(TdxBoolean a, TdxNumber b)
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
        public static TdxNumber operator *(bool[] a, TdxNumber b)
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
        public static TdxNumber operator *(bool a, TdxNumber b)
        {
            double[] temp = new double[b.Length];
            for (int i = 0; i < b.Length; i++) {
                temp[i] = (a ? 1 : 0) * b[i];
            }
            return new TdxNumber(temp);
        }
        #endregion

        #region operator /
        /// <summary>
        /// operator /
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static TdxNumber operator /(TdxNumber a, TdxNumber b)
        {
            if (a.Length != b.Length) throw new Exception();
            double[] temp = new double[a.Length];
            for (int i = 0; i < a.Length; i++) {
                if (double.IsNaN(b[i])) { temp[i] = double.NaN; continue; }
                if (double.IsInfinity(b[i])) { temp[i] = double.NaN; continue; }
                if (double.IsInfinity(a[i])) { temp[i] = double.NaN; continue; }
                if (b[i] == 0) { temp[i] = double.NaN; continue; }
                temp[i] = a[i] / b[i];
            }
            return new TdxNumber(temp);
        }
        /// <summary>
        /// operator /
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static TdxNumber operator /(double[] a, TdxNumber b)
        {
            if (a.Length != b.Length) throw new Exception();
            double[] temp = new double[a.Length];
            for (int i = 0; i < a.Length; i++) {
                if (double.IsNaN(b[i])) { temp[i] = double.NaN; continue; }
                if (double.IsInfinity(b[i])) { temp[i] = double.NaN; continue; }
                if (double.IsInfinity(a[i])) { temp[i] = double.NaN; continue; }
                if (b[i] == 0) { temp[i] = double.NaN; continue; }
                temp[i] = a[i] / b[i];
            }
            return new TdxNumber(temp);
        }
        /// <summary>
        /// operator /
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static TdxNumber operator /(double a, TdxNumber b)
        {
            double[] temp = new double[b.Length];
            for (int i = 0; i < b.Length; i++) {
                if (double.IsNaN(b[i])) { temp[i] = double.NaN; continue; }
                if (double.IsInfinity(b[i])) { temp[i] = double.NaN; continue; }
                if (double.IsInfinity(a)) { temp[i] = double.NaN; continue; }
                if (b[i] == 0) { temp[i] = double.NaN; continue; }
                temp[i] = a / b[i];
            }
            return new TdxNumber(temp);
        }
        /// <summary>
        /// operator /
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static TdxNumber operator /(TdxNumber a, double[] b)
        {
            if (a.Length != b.Length) throw new Exception();
            double[] temp = new double[a.Length];
            for (int i = 0; i < a.Length; i++) {
                if (double.IsNaN(b[i])) { temp[i] = double.NaN; continue; }
                if (double.IsInfinity(b[i])) { temp[i] = double.NaN; continue; }
                if (double.IsInfinity(a[i])) { temp[i] = double.NaN; continue; }
                if (b[i] == 0) { temp[i] = double.NaN; continue; }
                temp[i] = a[i] / b[i];
            }
            return new TdxNumber(temp);
        }
        /// <summary>
        /// operator /
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static TdxNumber operator /(TdxNumber a, double b)
        {
            double[] temp = new double[a.Length];
            for (int i = 0; i < a.Length; i++) {
                if (double.IsNaN(b)) { temp[i] = double.NaN; continue; }
                if (double.IsInfinity(b)) { temp[i] = double.NaN; continue; }
                if (double.IsInfinity(a[i])) { temp[i] = double.NaN; continue; }
                if (b == 0) { temp[i] = double.NaN; continue; }
                temp[i] = a[i] / b;
            }
            return new TdxNumber(temp);
        }
        /// <summary>
        /// operator /
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static TdxNumber operator /(TdxBoolean a, TdxNumber b)
        {
            if (a.Length != b.Length) throw new Exception();
            double[] temp = new double[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = (a[i] ? 1 : 0) / b[i];
            }
            return new TdxNumber(temp);
        }
        /// <summary>
        /// operator /
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static TdxNumber operator /(bool[] a, TdxNumber b)
        {
            if (a.Length != b.Length) throw new Exception();
            double[] temp = new double[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = (a[i] ? 1 : 0) / b[i];
            }
            return new TdxNumber(temp);
        }
        /// <summary>
        /// operator /
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static TdxNumber operator /(bool a, TdxNumber b)
        {
            double[] temp = new double[b.Length];
            for (int i = 0; i < b.Length; i++) {
                temp[i] = (a ? 1 : 0) / b[i];
            }
            return new TdxNumber(temp);
        }
        #endregion

        #region operator %
        /// <summary>
        /// operator %
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static TdxNumber operator %(TdxNumber a, TdxNumber b)
        {
            if (a.Length != b.Length) throw new Exception();
            double[] temp = new double[a.Length];
            for (int i = 0; i < a.Length; i++) {
                if (double.IsNaN(b[i])) { temp[i] = double.NaN; continue; }
                if (double.IsInfinity(b[i])) { temp[i] = double.NaN; continue; }
                if (double.IsInfinity(a[i])) { temp[i] = double.NaN; continue; }
                if (b[i] == 0) { temp[i] = double.NaN; continue; }
                temp[i] = a[i] % b[i];
            }
            return new TdxNumber(temp);
        }
        /// <summary>
        /// operator %
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static TdxNumber operator %(double[] a, TdxNumber b)
        {
            if (a.Length != b.Length) throw new Exception();
            double[] temp = new double[a.Length];
            for (int i = 0; i < a.Length; i++) {
                if (double.IsNaN(b[i])) { temp[i] = double.NaN; continue; }
                if (double.IsInfinity(b[i])) { temp[i] = double.NaN; continue; }
                if (double.IsInfinity(a[i])) { temp[i] = double.NaN; continue; }
                if (b[i] == 0) { temp[i] = double.NaN; continue; }
                temp[i] = a[i] % b[i];
            }
            return new TdxNumber(temp);
        }
        /// <summary>
        /// operator %
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static TdxNumber operator %(double a, TdxNumber b)
        {
            double[] temp = new double[b.Length];
            for (int i = 0; i < b.Length; i++) {
                if (double.IsNaN(b[i])) { temp[i] = double.NaN; continue; }
                if (double.IsInfinity(b[i])) { temp[i] = double.NaN; continue; }
                if (double.IsInfinity(a)) { temp[i] = double.NaN; continue; }
                if (b[i] == 0) { temp[i] = double.NaN; continue; }
                temp[i] = a % b[i];
            }
            return new TdxNumber(temp);
        }
        /// <summary>
        /// operator %
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static TdxNumber operator %(TdxNumber a, double[] b)
        {
            if (a.Length != b.Length) throw new Exception();
            double[] temp = new double[a.Length];
            for (int i = 0; i < a.Length; i++) {
                if (double.IsNaN(b[i])) { temp[i] = double.NaN; continue; }
                if (double.IsInfinity(b[i])) { temp[i] = double.NaN; continue; }
                if (double.IsInfinity(a[i])) { temp[i] = double.NaN; continue; }
                if (b[i] == 0) { temp[i] = double.NaN; continue; }
                temp[i] = a[i] % b[i];
            }
            return new TdxNumber(temp);
        }
        /// <summary>
        /// operator %
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static TdxNumber operator %(TdxNumber a, double b)
        {
            double[] temp = new double[a.Length];
            for (int i = 0; i < a.Length; i++) {
                if (double.IsNaN(b)) { temp[i] = double.NaN; continue; }
                if (double.IsInfinity(b)) { temp[i] = double.NaN; continue; }
                if (double.IsInfinity(a[i])) { temp[i] = double.NaN; continue; }
                if (b == 0) { temp[i] = double.NaN; continue; }
                temp[i] = a[i] % b;
            }
            return new TdxNumber(temp);
        }
        /// <summary>
        /// operator %
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static TdxNumber operator %(TdxBoolean a, TdxNumber b)
        {
            if (a.Length != b.Length) throw new Exception();
            double[] temp = new double[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = (a[i] ? 1 : 0) % b[i];
            }
            return new TdxNumber(temp);
        }
        /// <summary>
        /// operator %
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static TdxNumber operator %(bool[] a, TdxNumber b)
        {
            if (a.Length != b.Length) throw new Exception();
            double[] temp = new double[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = (a[i] ? 1 : 0) % b[i];
            }
            return new TdxNumber(temp);
        }
        /// <summary>
        /// operator %
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static TdxNumber operator %(bool a, TdxNumber b)
        {
            double[] temp = new double[b.Length];
            for (int i = 0; i < b.Length; i++) {
                temp[i] = (a ? 1 : 0) % b[i];
            }
            return new TdxNumber(temp);
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
        public static TdxBoolean operator >(TdxNumber a, TdxNumber b)
        {
            if (a.Length != b.Length) throw new Exception();
            bool[] temp = new bool[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = a[i] > b[i];
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
        public static TdxBoolean operator >(double[] a, TdxNumber b)
        {
            if (a.Length != b.Length) throw new Exception();
            bool[] temp = new bool[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = a[i] > b[i];
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
        public static TdxBoolean operator >(double a, TdxNumber b)
        {
            bool[] temp = new bool[b.Length];
            for (int i = 0; i < b.Length; i++) {
                temp[i] = a > b[i];
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
        public static TdxBoolean operator >(TdxNumber a, double[] b)
        {
            if (a.Length != b.Length) throw new Exception();
            bool[] temp = new bool[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = a[i] > b[i];
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
        public static TdxBoolean operator >(TdxNumber a, double b)
        {
            bool[] temp = new bool[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = a[i] > b;
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
        public static TdxBoolean operator >(TdxNumber a, TdxBoolean b)
        {
            if (a.Length != b.Length) throw new Exception();
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
        public static TdxBoolean operator >(TdxNumber a, bool[] b)
        {
            if (a.Length != b.Length) throw new Exception();
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
        public static TdxBoolean operator >(TdxNumber a, bool b)
        {
            bool[] temp = new bool[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = a[i] > (b ? 1 : 0);
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
        public static TdxBoolean operator >(TdxBoolean a, TdxNumber b)
        {
            if (a.Length != b.Length) throw new Exception();
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
        public static TdxBoolean operator >(bool[] a, TdxNumber b)
        {
            if (a.Length != b.Length) throw new Exception();
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
        public static TdxBoolean operator >(bool a, TdxNumber b)
        {
            bool[] temp = new bool[b.Length];
            for (int i = 0; i < b.Length; i++) {
                temp[i] = (a ? 1 : 0) > b[i];
            }
            return new TdxBoolean(temp);
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
        public static TdxBoolean operator <(TdxNumber a, TdxNumber b)
        {
            if (a.Length != b.Length) throw new Exception();
            bool[] temp = new bool[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = a[i] < b[i];
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
        public static TdxBoolean operator <(double[] a, TdxNumber b)
        {
            if (a.Length != b.Length) throw new Exception();
            bool[] temp = new bool[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = a[i] < b[i];
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
        public static TdxBoolean operator <(double a, TdxNumber b)
        {
            bool[] temp = new bool[b.Length];
            for (int i = 0; i < b.Length; i++) {
                temp[i] = a < b[i];
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
        public static TdxBoolean operator <(TdxNumber a, double[] b)
        {
            if (a.Length != b.Length) throw new Exception();
            bool[] temp = new bool[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = a[i] < b[i];
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
        public static TdxBoolean operator <(TdxNumber a, double b)
        {
            bool[] temp = new bool[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = a[i] < b;
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
        public static TdxBoolean operator <(TdxNumber a, TdxBoolean b)
        {
            if (a.Length != b.Length) throw new Exception();
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
        public static TdxBoolean operator <(TdxNumber a, bool[] b)
        {
            if (a.Length != b.Length) throw new Exception();
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
        public static TdxBoolean operator <(TdxNumber a, bool b)
        {
            bool[] temp = new bool[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = a[i] < (b ? 1 : 0);
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
        public static TdxBoolean operator <(TdxBoolean a, TdxNumber b)
        {
            if (a.Length != b.Length) throw new Exception();
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
        public static TdxBoolean operator <(bool[] a, TdxNumber b)
        {
            if (a.Length != b.Length) throw new Exception();
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
        public static TdxBoolean operator <(bool a, TdxNumber b)
        {
            bool[] temp = new bool[b.Length];
            for (int i = 0; i < b.Length; i++) {
                temp[i] = (a ? 1 : 0) < b[i];
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
        public static TdxBoolean operator >=(TdxNumber a, TdxNumber b)
        {
            if (a.Length != b.Length) throw new Exception();
            bool[] temp = new bool[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = a[i] >= b[i];
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
        public static TdxBoolean operator >=(double[] a, TdxNumber b)
        {
            if (a.Length != b.Length) throw new Exception();
            bool[] temp = new bool[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = a[i] >= b[i];
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
        public static TdxBoolean operator >=(double a, TdxNumber b)
        {
            bool[] temp = new bool[b.Length];
            for (int i = 0; i < b.Length; i++) {
                temp[i] = a >= b[i];
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
        public static TdxBoolean operator >=(TdxNumber a, double[] b)
        {
            if (a.Length != b.Length) throw new Exception();
            bool[] temp = new bool[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = a[i] >= b[i];
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
        public static TdxBoolean operator >=(TdxNumber a, double b)
        {
            bool[] temp = new bool[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = a[i] >= b;
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
        public static TdxBoolean operator >=(TdxNumber a, TdxBoolean b)
        {
            if (a.Length != b.Length) throw new Exception();
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
        public static TdxBoolean operator >=(TdxNumber a, bool[] b)
        {
            if (a.Length != b.Length) throw new Exception();
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
        public static TdxBoolean operator >=(TdxNumber a, bool b)
        {
            bool[] temp = new bool[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = a[i] >= (b ? 1 : 0);
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
        public static TdxBoolean operator >=(TdxBoolean a, TdxNumber b)
        {
            if (a.Length != b.Length) throw new Exception();
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
        public static TdxBoolean operator >=(bool[] a, TdxNumber b)
        {
            if (a.Length != b.Length) throw new Exception();
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
        public static TdxBoolean operator >=(bool a, TdxNumber b)
        {
            bool[] temp = new bool[b.Length];
            for (int i = 0; i < b.Length; i++) {
                temp[i] = (a ? 1 : 0) >= b[i];
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
        public static TdxBoolean operator <=(TdxNumber a, TdxNumber b)
        {
            if (a.Length != b.Length) throw new Exception();
            bool[] temp = new bool[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = a[i] <= b[i];
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
        public static TdxBoolean operator <=(double[] a, TdxNumber b)
        {
            if (a.Length != b.Length) throw new Exception();
            bool[] temp = new bool[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = a[i] <= b[i];
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
        public static TdxBoolean operator <=(double a, TdxNumber b)
        {
            bool[] temp = new bool[b.Length];
            for (int i = 0; i < b.Length; i++) {
                temp[i] = a <= b[i];
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
        public static TdxBoolean operator <=(TdxNumber a, double[] b)
        {
            if (a.Length != b.Length) throw new Exception();
            bool[] temp = new bool[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = a[i] <= b[i];
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
        public static TdxBoolean operator <=(TdxNumber a, double b)
        {
            bool[] temp = new bool[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = a[i] <= b;
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
        public static TdxBoolean operator <=(TdxNumber a, TdxBoolean b)
        {
            if (a.Length != b.Length) throw new Exception();
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
        public static TdxBoolean operator <=(TdxNumber a, bool[] b)
        {
            if (a.Length != b.Length) throw new Exception();
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
        public static TdxBoolean operator <=(TdxNumber a, bool b)
        {
            bool[] temp = new bool[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = a[i] <= (b ? 1 : 0);
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
        public static TdxBoolean operator <=(TdxBoolean a, TdxNumber b)
        {
            if (a.Length != b.Length) throw new Exception();
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
        public static TdxBoolean operator <=(bool[] a, TdxNumber b)
        {
            if (a.Length != b.Length) throw new Exception();
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
        public static TdxBoolean operator <=(bool a, TdxNumber b)
        {
            bool[] temp = new bool[b.Length];
            for (int i = 0; i < b.Length; i++) {
                temp[i] = (a ? 1 : 0) <= b[i];
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
        public static TdxBoolean operator ==(TdxNumber a, TdxNumber b)
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
        public static TdxBoolean operator ==(double[] a, TdxNumber b)
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
        public static TdxBoolean operator ==(double a, TdxNumber b)
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
        public static TdxBoolean operator ==(TdxNumber a, double[] b)
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
        public static TdxBoolean operator ==(TdxNumber a, double b)
        {
            bool[] temp = new bool[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = a[i] == b;
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
        public static TdxBoolean operator ==(TdxNumber a, TdxBoolean b)
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
        public static TdxBoolean operator ==(TdxNumber a, bool[] b)
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
        public static TdxBoolean operator ==(TdxNumber a, bool b)
        {
            bool[] temp = new bool[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = a[i] == (b ? 1 : 0);
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
        public static TdxBoolean operator ==(TdxBoolean a, TdxNumber b)
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
        public static TdxBoolean operator ==(bool[] a, TdxNumber b)
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
        public static TdxBoolean operator ==(bool a, TdxNumber b)
        {
            bool[] temp = new bool[b.Length];
            for (int i = 0; i < b.Length; i++) {
                temp[i] = (a ? 1 : 0) == b[i];
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
        public static TdxBoolean operator !=(TdxNumber a, TdxNumber b)
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
        public static TdxBoolean operator !=(double[] a, TdxNumber b)
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
        public static TdxBoolean operator !=(double a, TdxNumber b)
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
        public static TdxBoolean operator !=(TdxNumber a, double[] b)
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
        public static TdxBoolean operator !=(TdxNumber a, double b)
        {
            bool[] temp = new bool[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = a[i] != b;
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
        public static TdxBoolean operator !=(TdxNumber a, TdxBoolean b)
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
        public static TdxBoolean operator !=(TdxNumber a, bool[] b)
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
        public static TdxBoolean operator !=(TdxNumber a, bool b)
        {
            bool[] temp = new bool[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = a[i] != (b ? 1 : 0);
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
        public static TdxBoolean operator !=(TdxBoolean a, TdxNumber b)
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
        public static TdxBoolean operator !=(bool[] a, TdxNumber b)
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
        public static TdxBoolean operator !=(bool a, TdxNumber b)
        {
            bool[] temp = new bool[b.Length];
            for (int i = 0; i < b.Length; i++) {
                temp[i] = (a ? 1 : 0) != b[i];
            }
            return new TdxBoolean(temp);
        }
        #endregion

        #region RunFun RunFun2
        [System.Diagnostics.DebuggerNonUserCode]
        internal TdxNumber RunFun(Func<double, double> fun)
        {
            double[] temp = new double[Length];
            for (int i = 0; i < Length; i++) {
                temp[i] = fun(Values[i]);
            }
            return new TdxNumber(temp);
        }
        [System.Diagnostics.DebuggerNonUserCode]
        internal TdxNumber RunFun(Func<double, int> fun)
        {
            double[] temp = new double[Length];
            for (int i = 0; i < Length; i++) {
                temp[i] = fun(Values[i]);
            }
            return new TdxNumber(temp);
        }
        [System.Diagnostics.DebuggerNonUserCode]
        internal TdxNumber RunFun2(Func<double, double, double> fun, double num)
        {
            double[] temp = new double[Length];
            for (int i = 0; i < Length; i++) {
                temp[i] = fun(Values[i], num);
            }
            return new TdxNumber(temp);
        }
        [System.Diagnostics.DebuggerNonUserCode]
        internal TdxNumber RunFun2(Func<double, double, double> fun, TdxNumber num)
        {
            double[] temp = new double[Length];
            for (int i = 0; i < Length; i++) {
                temp[i] = fun(Values[i], num.Values[i]);
            }
            return new TdxNumber(temp);
        }
        #endregion

        [System.Diagnostics.DebuggerNonUserCode]
        internal bool GetBoolean(int i)
        {
            return Values[i] != 0;
        }

        #region override
        /// <summary>
        /// ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"TdxNumber len: {Length} last: {LastValue}";
        }

        /// <summary>
        /// Equals
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return obj is TdxNumber number &&
                   Length == number.Length &&
                   EqualityComparer<double[]>.Default.Equals(Values, number.Values);
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
