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
    public class TdxNumber
    {
        private int length;
        private double[] vals;
        /// <summary>
        /// 长度
        /// </summary>
        public int Length => length;
        /// <summary>
        /// 值
        /// </summary>
        public double[] Values => vals;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="value"></param>
        public TdxNumber(double[] value)
        {
            vals = value;
            length = value.Length;
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="value"></param>
        public TdxNumber(List<double> value)
        {
            vals = value.ToArray();
            length = value.Count;
        }




        #region operator
        /// <summary>
        /// 隐性转换
        /// </summary>
        /// <param name="obj"></param>
        public static implicit operator double[](TdxNumber obj)
        {
            return obj.vals;
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
        #endregion

        #region this[int i]
        /// <summary>
        /// this[i]
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public double this[int i] { get { return vals[i]; } set { vals[i] = value; } }

        #endregion

        #region operator +
        /// <summary>
        /// operator +
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [System.Diagnostics.DebuggerNonUserCode]
        public static TdxNumber operator +(TdxNumber a, TdxNumber b)
        {
            if (a.length != b.length) throw new Exception();
            double[] temp = new double[a.length];
            for (int i = 0; i < a.length; i++) {
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
            double[] temp = new double[b.length];
            for (int i = 0; i < b.length; i++) {
                temp[i] = b[i] + a;
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
        public static TdxNumber operator +(int a, TdxNumber b)
        {
            double[] temp = new double[b.length];
            for (int i = 0; i < b.length; i++) {
                temp[i] = b[i] + a;
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
            double[] temp = new double[a.length];
            for (int i = 0; i < a.length; i++) {
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
        public static TdxNumber operator +(TdxNumber a, int b)
        {
            double[] temp = new double[a.length];
            for (int i = 0; i < a.length; i++) {
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
        public static TdxNumber operator +(TdxNumber a, bool[] b)
        {
            if (a.length != b.Length) throw new Exception();
            double[] temp = new double[a.length];
            for (int i = 0; i < a.length; i++) {
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
        public static TdxNumber operator +(bool[] a, TdxNumber b)
        {
            if (a.Length != b.length) throw new Exception();
            double[] temp = new double[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = (a[i] ? 1 : 0) + b[i];
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
            if (a.length != b.length) throw new Exception();
            double[] temp = new double[a.length];
            for (int i = 0; i < a.length; i++) {
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
            double[] temp = new double[b.length];
            for (int i = 0; i < b.length; i++) {
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
        public static TdxNumber operator -(int a, TdxNumber b)
        {
            double[] temp = new double[b.length];
            for (int i = 0; i < b.length; i++) {
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
        public static TdxNumber operator -(TdxNumber a, double b)
        {
            double[] temp = new double[a.length];
            for (int i = 0; i < a.length; i++) {
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
        public static TdxNumber operator -(TdxNumber a, int b)
        {
            double[] temp = new double[a.length];
            for (int i = 0; i < a.length; i++) {
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
        public static TdxNumber operator -(TdxNumber a, bool[] b)
        {
            if (a.length != b.Length) throw new Exception();
            double[] temp = new double[a.length];
            for (int i = 0; i < a.length; i++) {
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
        public static TdxNumber operator -(bool[] a, TdxNumber b)
        {
            if (a.Length != b.length) throw new Exception();
            double[] temp = new double[a.Length];
            for (int i = 0; i < a.Length; i++) {
                temp[i] = (a[i] ? 1 : 0) - b[i];
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
            if (a.length != b.length) throw new Exception();
            double[] temp = new double[a.length];
            for (int i = 0; i < a.length; i++) {
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
            double[] temp = new double[b.length];
            for (int i = 0; i < b.length; i++) {
                temp[i] = b[i] * a;
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
        public static TdxNumber operator *(int a, TdxNumber b)
        {
            double[] temp = new double[b.length];
            for (int i = 0; i < b.length; i++) {
                temp[i] = b[i] * a;
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
            double[] temp = new double[a.length];
            for (int i = 0; i < a.length; i++) {
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
        public static TdxNumber operator *(TdxNumber a, int b)
        {
            double[] temp = new double[a.length];
            for (int i = 0; i < a.length; i++) {
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
        public static TdxNumber operator *(TdxNumber a, bool[] b)
        {
            if (a.length != b.Length) throw new Exception();
            double[] temp = new double[a.length];
            for (int i = 0; i < a.length; i++) {
                if (b[i]) {
                    temp[i] = a[i];
                }
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
            if (a.Length != b.length) throw new Exception();
            double[] temp = new double[a.Length];
            for (int i = 0; i < a.Length; i++) {
                if (a[i]) {
                    temp[i] = b[i];
                }
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
            if (a.length != b.length) throw new Exception();
            double[] temp = new double[a.length];
            for (int i = 0; i < a.length; i++) {
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
            double[] temp = new double[b.length];
            for (int i = 0; i < b.length; i++) {
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
        public static TdxNumber operator /(int a, TdxNumber b)
        {
            double[] temp = new double[b.length];
            for (int i = 0; i < b.length; i++) {
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
        public static TdxNumber operator /(TdxNumber a, double b)
        {
            double[] temp = new double[a.length];
            for (int i = 0; i < a.length; i++) {
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
        public static TdxNumber operator /(TdxNumber a, int b)
        {
            double[] temp = new double[a.length];
            for (int i = 0; i < a.length; i++) {
                if (double.IsInfinity(a[i])) { temp[i] = double.NaN; continue; }
                if (b == 0) { temp[i] = double.NaN; continue; }
                temp[i] = a[i] / b;
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
            if (a.length != b.length) throw new Exception();
            double[] temp = new double[a.length];
            for (int i = 0; i < a.length; i++) {
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
            double[] temp = new double[b.length];
            for (int i = 0; i < b.length; i++) {
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
        public static TdxNumber operator %(int a, TdxNumber b)
        {
            double[] temp = new double[b.length];
            for (int i = 0; i < b.length; i++) {
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
        public static TdxNumber operator %(TdxNumber a, double b)
        {
            double[] temp = new double[a.length];
            for (int i = 0; i < a.length; i++) {
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
        public static TdxNumber operator %(TdxNumber a, int b)
        {
            double[] temp = new double[a.length];
            for (int i = 0; i < a.length; i++) {
                if (double.IsInfinity(a[i])) { temp[i] = double.NaN; continue; }
                if (b == 0) { temp[i] = double.NaN; continue; }
                temp[i] = a[i] % b;
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
        public static bool[] operator >(TdxNumber a, TdxNumber b)
        {
            if (a.length != b.length) throw new Exception();
            bool[] temp = new bool[a.length];
            for (int i = 0; i < a.length; i++) {
                temp[i] = a[i] > b[i];
            }
            return temp;
        }
        /// <summary>
        /// operator >
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static bool[] operator >(double a, TdxNumber b)
        {
            bool[] temp = new bool[b.length];
            for (int i = 0; i < b.length; i++) {
                temp[i] = a > b[i];
            }
            return temp;
        }
        /// <summary>
        /// operator >
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static bool[] operator >(int a, TdxNumber b)
        {
            bool[] temp = new bool[b.length];
            for (int i = 0; i < b.length; i++) {
                temp[i] = a > b[i];
            }
            return temp;
        }
        /// <summary>
        /// operator >
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static bool[] operator >(TdxNumber a, double b)
        {
            bool[] temp = new bool[a.length];
            for (int i = 0; i < a.length; i++) {
                temp[i] = a[i] > b;
            }
            return temp;
        }
        /// <summary>
        /// operator >
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static bool[] operator >(TdxNumber a, int b)
        {
            bool[] temp = new bool[a.length];
            for (int i = 0; i < a.length; i++) {

                temp[i] = a[i] > b;
            }
            return temp;
        }
        #endregion

        #region operator <
        /// <summary>
        /// operator &lt;
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static bool[] operator <(TdxNumber a, TdxNumber b)
        {
            if (a.length != b.length) throw new Exception();
            bool[] temp = new bool[a.length];
            for (int i = 0; i < a.length; i++) {
                temp[i] = a[i] < b[i];
            }
            return temp;
        }
        /// <summary>
        /// operator &lt;
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static bool[] operator <(double a, TdxNumber b)
        {
            bool[] temp = new bool[b.length];
            for (int i = 0; i < b.length; i++) {
                temp[i] = a < b[i];
            }
            return temp;
        }
        /// <summary>
        /// operator &lt;
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static bool[] operator <(int a, TdxNumber b)
        {
            bool[] temp = new bool[b.length];
            for (int i = 0; i < b.length; i++) {
                temp[i] = a > b[i];
            }
            return temp;
        }
        /// <summary>
        /// operator &lt;
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static bool[] operator <(TdxNumber a, double b)
        {
            bool[] temp = new bool[a.length];
            for (int i = 0; i < a.length; i++) {
                temp[i] = a[i] < b;
            }
            return temp;
        }
        /// <summary>
        /// operator &lt;
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static bool[] operator <(TdxNumber a, int b)
        {
            bool[] temp = new bool[a.length];
            for (int i = 0; i < a.length; i++) {
                temp[i] = a[i] < b;
            }
            return temp;
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
        public static bool[] operator >=(TdxNumber a, TdxNumber b)
        {
            if (a.length != b.length) throw new Exception();
            bool[] temp = new bool[a.length];
            for (int i = 0; i < a.length; i++) {
                temp[i] = a[i] >= b[i];
            }
            return temp;
        }
        /// <summary>
        /// operator >=
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static bool[] operator >=(double a, TdxNumber b)
        {
            bool[] temp = new bool[b.length];
            for (int i = 0; i < b.length; i++) {
                temp[i] = a >= b[i];
            }
            return temp;
        }
        /// <summary>
        /// operator >=
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static bool[] operator >=(int a, TdxNumber b)
        {
            bool[] temp = new bool[b.length];
            for (int i = 0; i < b.length; i++) {
                temp[i] = a >= b[i];
            }
            return temp;
        }
        /// <summary>
        /// operator >=
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static bool[] operator >=(TdxNumber a, double b)
        {
            bool[] temp = new bool[a.length];
            for (int i = 0; i < a.length; i++) {
                temp[i] = a[i] >= b;
            }
            return temp;
        }
        /// <summary>
        /// operator >=
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static bool[] operator >=(TdxNumber a, int b)
        {
            bool[] temp = new bool[a.length];
            for (int i = 0; i < a.length; i++) {
                temp[i] = a[i] >= b;
            }
            return temp;
        }
        #endregion

        #region operator <=
        /// <summary>
        /// operator &lt;=
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static bool[] operator <=(TdxNumber a, TdxNumber b)
        {
            if (a.length != b.length) throw new Exception();
            bool[] temp = new bool[a.length];
            for (int i = 0; i < a.length; i++) {
                temp[i] = a[i] <= b[i];
            }
            return temp;
        }
        /// <summary>
        /// operator &lt;=
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static bool[] operator <=(double a, TdxNumber b)
        {
            bool[] temp = new bool[b.length];
            for (int i = 0; i < b.length; i++) {
                temp[i] = a <= b[i];
            }
            return temp;
        }
        /// <summary>
        /// operator &lt;=
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static bool[] operator <=(int a, TdxNumber b)
        {
            bool[] temp = new bool[b.length];
            for (int i = 0; i < b.length; i++) {
                temp[i] = a <= b[i];
            }
            return temp;
        }
        /// <summary>
        /// operator &lt;=
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static bool[] operator <=(TdxNumber a, double b)
        {
            bool[] temp = new bool[a.length];
            for (int i = 0; i < a.length; i++) {
                temp[i] = a[i] <= b;
            }
            return temp;
        }
        /// <summary>
        /// operator &lt;=
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static bool[] operator <=(TdxNumber a, int b)
        {
            bool[] temp = new bool[a.length];
            for (int i = 0; i < a.length; i++) {
                temp[i] = a[i] <= b;
            }
            return temp;
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
        public static bool[] operator ==(TdxNumber a, TdxNumber b)
        {
            if (a.length != b.length) throw new Exception();
            bool[] temp = new bool[a.length];
            for (int i = 0; i < a.length; i++) {
                temp[i] = a[i] == b[i];
            }
            return temp;
        }
        /// <summary>
        /// operator ==
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static bool[] operator ==(double a, TdxNumber b)
        {
            bool[] temp = new bool[b.length];
            for (int i = 0; i < b.length; i++) {
                temp[i] = a == b[i];
            }
            return temp;
        }
        /// <summary>
        /// operator ==
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static bool[] operator ==(int a, TdxNumber b)
        {
            bool[] temp = new bool[b.length];
            for (int i = 0; i < b.length; i++) {
                temp[i] = a == b[i];
            }
            return temp;
        }
        /// <summary>
        /// operator ==
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static bool[] operator ==(TdxNumber a, double b)
        {
            bool[] temp = new bool[a.length];
            for (int i = 0; i < a.length; i++) {
                temp[i] = a[i] == b;
            }
            return temp;
        }
        /// <summary>
        /// operator ==
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static bool[] operator ==(TdxNumber a, int b)
        {
            bool[] temp = new bool[a.length];
            for (int i = 0; i < a.length; i++) {
                temp[i] = a[i] == b;
            }
            return temp;
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
        public static bool[] operator !=(TdxNumber a, TdxNumber b)
        {
            if (a.length != b.length) throw new Exception();
            bool[] temp = new bool[a.length];
            for (int i = 0; i < a.length; i++) {
                temp[i] = a[i] != b[i];
            }
            return temp;
        }
        /// <summary>
        /// operator !=
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static bool[] operator !=(double a, TdxNumber b)
        {
            bool[] temp = new bool[b.length];
            for (int i = 0; i < b.length; i++) {
                temp[i] = a != b[i];
            }
            return temp;
        }
        /// <summary>
        /// operator !=
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static bool[] operator !=(int a, TdxNumber b)
        {
            bool[] temp = new bool[b.length];
            for (int i = 0; i < b.length; i++) {
                temp[i] = a != b[i];
            }
            return temp;
        }
        /// <summary>
        /// operator !=
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static bool[] operator !=(TdxNumber a, double b)
        {
            bool[] temp = new bool[a.length];
            for (int i = 0; i < a.length; i++) {
                temp[i] = a[i] != b;
            }
            return temp;
        }
        /// <summary>
        /// operator !=
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerNonUserCode]
        public static bool[] operator !=(TdxNumber a, int b)
        {
            bool[] temp = new bool[a.length];
            for (int i = 0; i < a.length; i++) {
                temp[i] = a[i] != b;
            }
            return temp;
        }
        #endregion

        #region RunFun RunFun2
        [System.Diagnostics.DebuggerNonUserCode]
        internal TdxNumber RunFun(Func<double, double> fun)
        {
            double[] temp = new double[length];
            for (int i = 0; i < length; i++) {
                temp[i] = fun(vals[i]);
            }
            return new TdxNumber(temp);
        }
        [System.Diagnostics.DebuggerNonUserCode]
        internal TdxNumber RunFun(Func<double, int> fun)
        {
            double[] temp = new double[length];
            for (int i = 0; i < length; i++) {
                temp[i] = fun(vals[i]);
            }
            return new TdxNumber(temp);
        }
        [System.Diagnostics.DebuggerNonUserCode]
        internal TdxNumber RunFun2(Func<double, double, double> fun, double num)
        {
            double[] temp = new double[length];
            for (int i = 0; i < length; i++) {
                temp[i] = fun(vals[i], num);
            }
            return new TdxNumber(temp);
        }
        [System.Diagnostics.DebuggerNonUserCode]
        internal TdxNumber RunFun2(Func<double, double, double> fun, TdxNumber num)
        {
            double[] temp = new double[length];
            for (int i = 0; i < length; i++) {
                temp[i] = fun(vals[i], num.vals[i]);
            }
            return new TdxNumber(temp);
        }
        #endregion

        [System.Diagnostics.DebuggerNonUserCode]
        internal bool GetBoolean(int i)
        {
            return vals[i] != 0;
        }

        #region override
        /// <summary>
        /// ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"TdxNumber len: {length}";
        }

        /// <summary>
        /// Equals
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return obj is TdxNumber number &&
                   length == number.length &&
                   EqualityComparer<double[]>.Default.Equals(vals, number.vals);
        }
        /// <summary>
        /// GetHashCode
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(length, vals);
        } 
        #endregion
    }
}
