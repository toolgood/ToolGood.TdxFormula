using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using ToolGood.TdxFormula.Internals;
using System.Threading.Tasks;


namespace ToolGood.TdxFormula
{
    /// <summary>
    /// 操作数
    /// </summary>
    public abstract class Operand : IDisposable
    {
        private const int digits = 4;
        public static readonly Operand True = Operand.Create(1);
        public static readonly Operand False = Operand.Create(0);

        public static readonly Operand One = Operand.Create(1);
        public static readonly Operand Zero = Operand.Create(0);

        /// <summary>
        /// 操作数类型
        /// </summary>
        public abstract OperandType Type { get; }
        /// <summary>
        /// 数字值
        /// </summary>
        public virtual double NumberValue => throw new NotImplementedException();
        /// <summary>
        /// int值
        /// </summary>
        public virtual int IntValue => throw new NotImplementedException();
        /// <summary>
        /// 布尔值
        /// </summary>
        public virtual bool BooleanValue => throw new NotImplementedException();
        /// <summary>
        /// 数组值
        /// </summary>
        public virtual MyList NumberArrayValue => throw new NotImplementedException();

        /// <summary>
        /// 布尔值
        /// </summary>
        public virtual List<bool> BooleanArrayValue => throw new NotImplementedException();

        public virtual int ArrayCount => -1;

        #region Create

        #region number
 
        /// <summary>
        /// 创建操作数
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Operand Create(int obj)
        {
            return new OperandNumber(obj);
        }
        /// <summary>
        /// 创建操作数
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Operand Create(long obj)
        {
            return new OperandNumber(obj);
        }
        /// <summary>
        /// 创建操作数
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Operand Create(double obj)
        {
            return new OperandNumber(obj);
        }
 
        #endregion

        public static Operand Create(MyList obj)
        {
            obj.IsReadOnly = true;
            return new OperandArray_Number(obj);
        }

        public static Operand Create(List<double> obj)
        {
            var array = new MyList(obj);
            array.IsReadOnly = true;
            return new OperandArray_Number(array);
        }
        public static Operand Create(double[] obj)
        {
            var array = new MyList(obj);
            array.IsReadOnly = true;
            return new OperandArray_Number(array);
        }
         
        /// <summary>
        /// 创建操作数
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Operand Create(ICollection<int> obj)
        {
            var array = new MyList(obj.Count);
            foreach (var item in obj) {
                array.Add((double)item);
            }
            array.IsReadOnly = true;
            return new OperandArray_Number(array);
        }
        /// <summary>
        /// 创建操作数
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Operand Create(ICollection<long> obj)
        {
            var array = new MyList(obj.Count);
            foreach (var item in obj) {
                array.Add((double)item);
            }
            array.IsReadOnly = true;
            return new OperandArray_Number(array);
        }
        #endregion

        public Operand ToNumber(int count, string errorMessage = null)
        {
            if (Type == OperandType.ARRARY_NUMBER) { return this; }

            List<double> array = new List<double>();
            if (Type == OperandType.NUMBER) {
                for (int i = 0; i < count; i++)
                    array.Add(this.NumberValue);
                return Create(array);
            }
            throw new Exception(errorMessage);
        }

        void IDisposable.Dispose() { }

        public override bool Equals(object obj)
        {
            if (obj is Operand operand) {
                if (operand.Type == Type) {
                    if (operand.Type == OperandType.NUMBER) {
                        return operand.NumberValue == NumberValue;
                    } else if (operand.Type == OperandType.ARRARY_NUMBER) {
                        var array = operand.NumberArrayValue;
                        var array2 = NumberArrayValue;
                        if (array.Count != array2.Count) {
                            return false;
                        }
                        for (int i = 0; i < array.Count; i++) {
                            var b = Math.Round(array[i] - array2[i], digits, MidpointRounding.AwayFromZero);
                            if (b != 0) {
                                return false;
                            }
                        }
                        return true;
                    }
                }
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }


        #region Operand
        #region number
        public static implicit operator Operand(Int16 obj)
        {
            return Operand.Create((int)obj);
        }
        public static implicit operator Operand(Int32 obj)
        {
            return Operand.Create(obj);
        }
        public static implicit operator Operand(Int64 obj)
        {
            return Operand.Create((double)obj);
        }
        public static implicit operator Operand(UInt16 obj)
        {
            return Operand.Create((double)obj);
        }
        public static implicit operator Operand(UInt32 obj)
        {
            return Operand.Create((double)obj);
        }
        public static implicit operator Operand(UInt64 obj)
        {
            return Operand.Create((double)obj);
        }

        public static implicit operator Operand(float obj)
        {
            return Operand.Create((double)obj);
        }
        public static implicit operator Operand(double obj)
        {
            return Operand.Create(obj);
        }
        public static implicit operator Operand(decimal obj)
        {
            return Operand.Create((double)obj);
        }
        #endregion

        public static implicit operator Operand(List<int> obj)
        {
            return Operand.Create(obj);
        }
        public static implicit operator Operand(List<long> obj)
        {
            return Operand.Create(obj);
        }
        public static implicit operator Operand(List<double> obj)
        {
            return Operand.Create(obj);
        }

        #endregion

        #region operator
        public static Operand operator *(Operand firstValue, Operand secondValue)
        {
            if (firstValue.Type == OperandType.NUMBER && secondValue.Type == OperandType.NUMBER) {
                return Operand.Create(firstValue.NumberValue * secondValue.NumberValue);
            }
            double[] array;
            if (firstValue.Type == OperandType.NUMBER) {
                var length = secondValue.ArrayCount;
                array = new double[length];
                Parallel.For(0, length, (i) => {
                    array[i] = firstValue.NumberValue * secondValue.NumberArrayValue[i];
                });
            } else if (secondValue.Type == OperandType.NUMBER) {
                var length = firstValue.ArrayCount;
                array = new double[length];
                Parallel.For(0, length, (i) => {
                    array[i] = firstValue.NumberArrayValue[i] * secondValue.NumberValue;
                });
            } else {
                Debug.Assert(firstValue.NumberArrayValue.Count == secondValue.NumberArrayValue.Count);
                var length = firstValue.NumberArrayValue.Count;
                array = new double[length];
                Parallel.For(0, length, (i) => {
                    array[i] = firstValue.NumberArrayValue[i] * secondValue.NumberArrayValue[i];
                });
            }
            return Create(array);
        }

        public static Operand operator /(Operand firstValue, Operand secondValue)
        {
            if (firstValue.Type == OperandType.NUMBER && secondValue.Type == OperandType.NUMBER) {
                return Operand.Create(firstValue.NumberValue / (secondValue.NumberValue == 0 ? 0.0001 : secondValue.NumberValue));
            }
            double[] array;
            if (firstValue.Type == OperandType.NUMBER) {
                var length = secondValue.ArrayCount;
                array = new double[length];
                Parallel.For(0, length, (i) => {
                    array[i] = firstValue.NumberValue / (secondValue.NumberArrayValue[i] == 0 ? 0.0001 : secondValue.NumberArrayValue[i]);
                });
            } else if (secondValue.Type == OperandType.NUMBER) {
                var length = firstValue.ArrayCount;
                array = new double[length];
                Parallel.For(0, length, (i) => {
                    array[i] = firstValue.NumberArrayValue[i] / (secondValue.NumberValue == 0 ? 0.0001 : secondValue.NumberValue);
                });
            } else {
                Debug.Assert(firstValue.NumberArrayValue.Count == secondValue.NumberArrayValue.Count);
                var length = firstValue.NumberArrayValue.Count;
                array = new double[length];
                Parallel.For(0, length, (i) => {
                    array[i] = firstValue.NumberArrayValue[i] / (secondValue.NumberArrayValue[i] == 0 ? 0.0001 : secondValue.NumberArrayValue[i]);
                });
            }
            return Create(array);
        }

        public static Operand operator +(Operand firstValue, Operand secondValue)
        {
            if (firstValue.Type == OperandType.NUMBER && secondValue.Type == OperandType.NUMBER) {
                return Operand.Create(firstValue.NumberValue + secondValue.NumberValue);
            }
            double[] array;
            if (firstValue.Type == OperandType.NUMBER) {
                var length = secondValue.ArrayCount;
                array = new double[length];
                Parallel.For(0, length, (i) => {
                    array[i] = firstValue.NumberValue + secondValue.NumberArrayValue[i];
                });
            } else if (secondValue.Type == OperandType.NUMBER) {
                var length = firstValue.ArrayCount;
                array = new double[length];
                Parallel.For(0, length, (i) => {
                    array[i] = firstValue.NumberArrayValue[i] + secondValue.NumberValue;
                });
            } else {
                Debug.Assert(firstValue.NumberArrayValue.Count == secondValue.NumberArrayValue.Count);
                var length = firstValue.NumberArrayValue.Count;
                array = new double[length];
                Parallel.For(0, length, (i) => {
                    array[i] = firstValue.NumberArrayValue[i] + secondValue.NumberArrayValue[i];
                });
            }
            return Create(array);
        }

        public static Operand operator -(Operand firstValue, Operand secondValue)
        {
            if (firstValue.Type == OperandType.NUMBER && secondValue.Type == OperandType.NUMBER) {
                return Operand.Create(firstValue.NumberValue - secondValue.NumberValue);
            }
            double[] array;
            if (firstValue.Type == OperandType.NUMBER) {
                var length = secondValue.ArrayCount;
                array = new double[length];
                Parallel.For(0, length, (i) => {
                    array[i] = firstValue.NumberValue - secondValue.NumberArrayValue[i];
                });
            } else if (secondValue.Type == OperandType.NUMBER) {
                var length = firstValue.ArrayCount;
                array = new double[length];
                Parallel.For(0, length, (i) => {
                    array[i] = firstValue.NumberArrayValue[i] - secondValue.NumberValue;
                });
            } else {
                Debug.Assert(firstValue.NumberArrayValue.Count == secondValue.NumberArrayValue.Count);
                var length = firstValue.NumberArrayValue.Count;
                array = new double[length];
                Parallel.For(0, length, (i) => {
                    array[i] = firstValue.NumberArrayValue[i] - secondValue.NumberArrayValue[i];
                });
            }
            return Create(array);
        }

        public static Operand operator >(Operand firstValue, Operand secondValue)
        {
            if (firstValue.Type == OperandType.NUMBER && secondValue.Type == OperandType.NUMBER) {
                var b = Math.Round(firstValue.NumberValue - secondValue.NumberValue, digits, MidpointRounding.AwayFromZero);
                return Operand.Create(b > 0 ? 1 : 0);
            }
            double[] array;
            if (firstValue.Type == OperandType.NUMBER) {
                var length = secondValue.ArrayCount;
                array = new double[length];
                Parallel.For(0, length, (i) => {
                    var b = Math.Round(firstValue.NumberValue - secondValue.NumberArrayValue[i], digits, MidpointRounding.AwayFromZero);
                    array[i] = b > 0 ? 1 : 0;
                });
            } else if (secondValue.Type == OperandType.NUMBER) {
                var length = firstValue.ArrayCount;
                array = new double[length];
                Parallel.For(0, length, (i) => {
                    var b = Math.Round(firstValue.NumberArrayValue[i] - secondValue.NumberValue, digits, MidpointRounding.AwayFromZero);
                    array[i] = b > 0 ? 1 : 0;
                });
            } else {
                Debug.Assert(firstValue.NumberArrayValue.Count == secondValue.NumberArrayValue.Count);
                var length = firstValue.NumberArrayValue.Count;
                array = new double[length];
                Parallel.For(0, length, (i) => {
                    var b = Math.Round(firstValue.NumberArrayValue[i] - secondValue.NumberArrayValue[i], digits, MidpointRounding.AwayFromZero);
                    array[i] = b > 0 ? 1 : 0;
                });
            }
            return Create(array);
        }
        public static Operand operator <(Operand firstValue, Operand secondValue)
        {
            if (firstValue.Type == OperandType.NUMBER && secondValue.Type == OperandType.NUMBER) {
                var b = Math.Round(firstValue.NumberValue - secondValue.NumberValue, digits, MidpointRounding.AwayFromZero);
                return Operand.Create(b < 0 ? 1 : 0);
            }
            double[] array;
            if (firstValue.Type == OperandType.NUMBER) {
                var length = secondValue.ArrayCount;
                array = new double[length];
                Parallel.For(0, length, (i) => {
                    var b = Math.Round(firstValue.NumberValue - secondValue.NumberArrayValue[i], digits, MidpointRounding.AwayFromZero);
                    array[i] = b < 0 ? 1 : 0;
                });
            } else if (secondValue.Type == OperandType.NUMBER) {
                var length = firstValue.ArrayCount;
                array = new double[length];
                Parallel.For(0, length, (i) => {
                    var b = Math.Round(firstValue.NumberArrayValue[i] - secondValue.NumberValue, digits, MidpointRounding.AwayFromZero);
                    array[i] = b < 0 ? 1 : 0;
                });
            } else {
                Debug.Assert(firstValue.NumberArrayValue.Count == secondValue.NumberArrayValue.Count);
                var length = firstValue.NumberArrayValue.Count;
                array = new double[length];
                Parallel.For(0, length, (i) => {
                    var b = Math.Round(firstValue.NumberArrayValue[i] - secondValue.NumberArrayValue[i], digits, MidpointRounding.AwayFromZero);
                    array[i] = b < 0 ? 1 : 0;
                });
            }
            return Create(array);
        }

        public static Operand operator >=(Operand firstValue, Operand secondValue)
        {
            if (firstValue.Type == OperandType.NUMBER && secondValue.Type == OperandType.NUMBER) {
                var b = Math.Round(firstValue.NumberValue - secondValue.NumberValue, digits, MidpointRounding.AwayFromZero);
                return Operand.Create(b >= 0 ? 1 : 0);
            }
            double[] array;
            if (firstValue.Type == OperandType.NUMBER) {
                var length = secondValue.ArrayCount;
                array = new double[length];
                Parallel.For(0, length, (i) => {
                    var b = Math.Round(firstValue.NumberValue - secondValue.NumberArrayValue[i], digits, MidpointRounding.AwayFromZero);
                    array[i] = b >= 0 ? 1 : 0;
                });
            } else if (secondValue.Type == OperandType.NUMBER) {
                var length = firstValue.ArrayCount;
                array = new double[length];
                Parallel.For(0, length, (i) => {
                    var b = Math.Round(firstValue.NumberArrayValue[i] - secondValue.NumberValue, digits, MidpointRounding.AwayFromZero);
                    array[i] = b >= 0 ? 1 : 0;
                });
            } else {
                Debug.Assert(firstValue.NumberArrayValue.Count == secondValue.NumberArrayValue.Count);
                var length = firstValue.NumberArrayValue.Count;
                array = new double[length];
                Parallel.For(0, length, (i) => {
                    var b = Math.Round(firstValue.NumberArrayValue[i] - secondValue.NumberArrayValue[i], digits, MidpointRounding.AwayFromZero);
                    array[i] = b >= 0 ? 1 : 0;
                });
            }
            return Create(array);
        }
        public static Operand operator <=(Operand firstValue, Operand secondValue)
        {
            if (firstValue.Type == OperandType.NUMBER && secondValue.Type == OperandType.NUMBER) {
                var b = Math.Round(firstValue.NumberValue - secondValue.NumberValue, digits, MidpointRounding.AwayFromZero);
                return Operand.Create(b <= 0 ? 1 : 0);
            }
            double[] array;
            if (firstValue.Type == OperandType.NUMBER) {
                var length = secondValue.ArrayCount;
                array = new double[length];
                Parallel.For(0, length, (i) => {
                    var b = Math.Round(firstValue.NumberValue - secondValue.NumberArrayValue[i], digits, MidpointRounding.AwayFromZero);
                    array[i] = b <= 0 ? 1 : 0;
                });
            } else if (secondValue.Type == OperandType.NUMBER) {
                var length = firstValue.ArrayCount;
                array = new double[length];
                Parallel.For(0, length, (i) => {
                    var b = Math.Round(firstValue.NumberArrayValue[i] - secondValue.NumberValue, digits, MidpointRounding.AwayFromZero);
                    array[i] = b <= 0 ? 1 : 0;
                });
            } else {
                Debug.Assert(firstValue.NumberArrayValue.Count == secondValue.NumberArrayValue.Count);
                var length = firstValue.NumberArrayValue.Count;
                array = new double[length];
                Parallel.For(0, length, (i) => {
                    var b = Math.Round(firstValue.NumberArrayValue[i] - secondValue.NumberArrayValue[i], digits, MidpointRounding.AwayFromZero);
                    array[i] = b <= 0 ? 1 : 0;
                });
            }
            return Create(array);
        }

        public static Operand operator ==(Operand firstValue, Operand secondValue)
        {
            if (firstValue.Type == OperandType.NUMBER && secondValue.Type == OperandType.NUMBER) {
                var b = Math.Round(firstValue.NumberValue - secondValue.NumberValue, digits, MidpointRounding.AwayFromZero);
                return Operand.Create(b == 0 ? 1 : 0);
            }
            double[] array;
            if (firstValue.Type == OperandType.NUMBER) {
                var length = secondValue.ArrayCount;
                array = new double[length];
                Parallel.For(0, length, (i) => {
                    var b = Math.Round(firstValue.NumberValue - secondValue.NumberArrayValue[i], digits, MidpointRounding.AwayFromZero);
                    array[i] = b == 0 ? 1 : 0;
                });
            } else if (secondValue.Type == OperandType.NUMBER) {
                var length = firstValue.ArrayCount;
                array = new double[length];
                Parallel.For(0, length, (i) => {
                    var b = Math.Round(firstValue.NumberArrayValue[i] - secondValue.NumberValue, digits, MidpointRounding.AwayFromZero);
                    array[i] = b == 0 ? 1 : 0;
                });
            } else {
                Debug.Assert(firstValue.NumberArrayValue.Count == secondValue.NumberArrayValue.Count);
                var length = firstValue.NumberArrayValue.Count;
                array = new double[length];
                Parallel.For(0, length, (i) => {
                    var b = Math.Round(firstValue.NumberArrayValue[i] - secondValue.NumberArrayValue[i], digits, MidpointRounding.AwayFromZero);
                    array[i] = b == 0 ? 1 : 0;
                });
            }
            return Create(array);
        }
        public static Operand operator !=(Operand firstValue, Operand secondValue)
        {
            if (firstValue.Type == OperandType.NUMBER && secondValue.Type == OperandType.NUMBER) {
                var b = Math.Round(firstValue.NumberValue - secondValue.NumberValue, digits, MidpointRounding.AwayFromZero);
                return Operand.Create(b != 0 ? 1 : 0);
            }
            double[] array;
            if (firstValue.Type == OperandType.NUMBER) {
                var length = secondValue.ArrayCount;
                array = new double[length];
                Parallel.For(0, length, (i) => {
                    var b = Math.Round(firstValue.NumberValue - secondValue.NumberArrayValue[i], digits, MidpointRounding.AwayFromZero);
                    array[i] = b != 0 ? 1 : 0;
                });
            } else if (secondValue.Type == OperandType.NUMBER) {
                var length = firstValue.ArrayCount;
                array = new double[length];
                Parallel.For(0, length, (i) => {
                    var b = Math.Round(firstValue.NumberArrayValue[i] - secondValue.NumberValue, digits, MidpointRounding.AwayFromZero);
                    array[i] = b != 0 ? 1 : 0;
                });
            } else {
                Debug.Assert(firstValue.NumberArrayValue.Count == secondValue.NumberArrayValue.Count);
                var length = firstValue.NumberArrayValue.Count;
                array = new double[length];
                Parallel.For(0, length, (i) => {
                    var b = Math.Round(firstValue.NumberArrayValue[i] - secondValue.NumberArrayValue[i], digits, MidpointRounding.AwayFromZero);
                    array[i] = b != 0 ? 1 : 0;
                });
            }
            return Create(array);
        }


        #endregion


    }
    abstract class Operand<T> : Operand
    {
        public T Value { get; private set; }
        public Operand(T obj)
        {
            Value = obj;
        }
    }

    class OperandNumber : Operand<double>
    {
        public OperandNumber(double obj) : base(obj) { }
        public override OperandType Type => OperandType.NUMBER;
        public override int IntValue => (int)Value;
        public override double NumberValue => Value;
        private bool? booleanValue;
        public override bool BooleanValue {
            get {
                if (booleanValue == null) {
                    booleanValue = Value == 0;
                }
                return booleanValue.Value;
            }
        }
    }

    class OperandArray_Number : Operand<MyList>
    {
        public OperandArray_Number(MyList obj) : base(obj) { }
        public override OperandType Type => OperandType.ARRARY_NUMBER;
        public override MyList NumberArrayValue => Value;
        public override int ArrayCount => Value.Count;

        private List<bool> booleanArrayValue;
        public override List<bool> BooleanArrayValue {
            get {
                if (booleanArrayValue == null) {
                    booleanArrayValue = new List<bool>();
                    foreach (var item in Value) {
                        booleanArrayValue.Add(item != 0);
                    }
                }
                return booleanArrayValue;
            }
        }

    }

}
