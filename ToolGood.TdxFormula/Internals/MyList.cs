using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToolGood.TdxFormula.Internals
{
	public sealed class MyList : List<double>  //, ICollection<double>
	{
		private const int digits = 4;
		public bool IsReadOnly = false;

		public MyList(int capacity) : base(capacity)
		{
		}

		public MyList(int N, int length) : base(new double[length])
		{
			if (N != 0) {
				for (int i = 0; i < length; i++) {
					Add(N);
				}
			}
		}
		public MyList(double[] array) : base(array)
		{

		}
		public MyList(List<double> array) : base(array)
		{

		}

		//public new void Add(double item)
		//{
		//    if (IsReadOnly) {
		//        throw new Exception();
		//    }
		//    base.Add(item);
		//}
		//public new void Insert(int index, double item)
		//{
		//    if (IsReadOnly) {
		//        throw new Exception();
		//    }
		//    base.Insert(index, item);
		//}



		#region operator + - * /
		public static MyList operator *(MyList firstValue, int N)
		{
			MyList result = new MyList(firstValue.Count);
			for (int i = 0; i < firstValue.Count; i++) {
				result.Add(firstValue[i] * N);
			}
			return result;
		}
		public static MyList operator /(MyList firstValue, int N)
		{
			MyList result = new MyList(firstValue.Count);
			for (int i = 0; i < firstValue.Count; i++) {
				if (N == 0) {
					result.Add(firstValue[i] / 0.01);
				} else {
					result.Add(firstValue[i] / N);
				}
			}
			return result;
		}
		public static MyList operator +(MyList firstValue, int N)
		{
			MyList result = new MyList(firstValue.Count);
			for (int i = 0; i < firstValue.Count; i++) {
				result.Add(firstValue[i] + N);
			}
			return result;
		}
		public static MyList operator -(MyList firstValue, int N)
		{
			MyList result = new MyList(firstValue.Count);
			for (int i = 0; i < firstValue.Count; i++) {
				result.Add(firstValue[i] + N);
			}
			return result;
		}

		public static MyList operator *(MyList firstValue, double N)
		{
			MyList result = new MyList(firstValue.Count);
			for (int i = 0; i < firstValue.Count; i++) {
				result.Add(firstValue[i] * N);
			}
			return result;
		}
		public static MyList operator /(MyList firstValue, double N)
		{
			MyList result = new MyList(firstValue.Count);
			for (int i = 0; i < firstValue.Count; i++) {
				if (N == 0) {
					result.Add(firstValue[i] / 0.01);
				} else {
					result.Add(firstValue[i] / N);
				}
			}
			return result;
		}
		public static MyList operator +(MyList firstValue, double N)
		{
			MyList result = new MyList(firstValue.Count);
			for (int i = 0; i < firstValue.Count; i++) {
				result.Add(firstValue[i] + N);
			}
			return result;
		}
		public static MyList operator -(MyList firstValue, double N)
		{
			MyList result = new MyList(firstValue.Count);
			for (int i = 0; i < firstValue.Count; i++) {
				result.Add(firstValue[i] + N);
			}
			return result;
		}

		public static MyList operator *(MyList firstValue, MyList secondValue)
		{
			MyList result = new MyList(firstValue.Count);
			for (int i = 0; i < firstValue.Count; i++) {
				result.Add(firstValue[i] * secondValue[i]);
			}
			return result;
		}
		public static MyList operator /(MyList firstValue, MyList secondValue)
		{
			MyList result = new MyList(firstValue.Count);
			for (int i = 0; i < firstValue.Count; i++) {
				if (secondValue[i] == 0) {
					result.Add(firstValue[i] / 0.01);
				} else {
					result.Add(firstValue[i] / secondValue[i]);
				}
			}
			return result;
		}
		public static MyList operator +(MyList firstValue, MyList secondValue)
		{
			MyList result = new MyList(firstValue.Count);
			for (int i = 0; i < firstValue.Count; i++) {
				result.Add(firstValue[i] + secondValue[i]);
			}
			return result;
		}
		public static MyList operator -(MyList firstValue, MyList secondValue)
		{
			MyList result = new MyList(firstValue.Count);
			for (int i = 0; i < firstValue.Count; i++) {
				result.Add(firstValue[i] - secondValue[i]);
			}
			return result;
		}

		public static MyList operator *(int N, MyList secondValue)
		{
			MyList result = new MyList(secondValue.Count);
			for (int i = 0; i < secondValue.Count; i++) {
				result.Add(N * secondValue[i]);
			}
			return result;
		}
		public static MyList operator /(int N, MyList secondValue)
		{
			MyList result = new MyList(secondValue.Count);
			for (int i = 0; i < secondValue.Count; i++) {
				if (secondValue[i] == 0) {
					result.Add(N / 0.01);
				} else {
					result.Add(N / secondValue[i]);
				}
			}
			return result;
		}
		public static MyList operator +(int N, MyList secondValue)
		{
			MyList result = new MyList(secondValue.Count);
			for (int i = 0; i < secondValue.Count; i++) {
				result.Add(N + secondValue[i]);
			}
			return result;
		}
		public static MyList operator -(int N, MyList secondValue)
		{
			MyList result = new MyList(secondValue.Count);
			for (int i = 0; i < secondValue.Count; i++) {
				result.Add(N - secondValue[i]);
			}
			return result;
		}

		public static MyList operator *(double N, MyList secondValue)
		{
			MyList result = new MyList(secondValue.Count);
			for (int i = 0; i < secondValue.Count; i++) {
				result.Add(N * secondValue[i]);
			}
			return result;
		}
		public static MyList operator /(double N, MyList secondValue)
		{
			MyList result = new MyList(secondValue.Count);
			for (int i = 0; i < secondValue.Count; i++) {
				if (secondValue[i] == 0) {
					result.Add(N / 0.01);
				} else {
					result.Add(N / secondValue[i]);
				}
			}
			return result;
		}
		public static MyList operator +(double N, MyList secondValue)
		{
			MyList result = new MyList(secondValue.Count);
			for (int i = 0; i < secondValue.Count; i++) {
				result.Add(N + secondValue[i]);
			}
			return result;
		}
		public static MyList operator -(double N, MyList secondValue)
		{
			MyList result = new MyList(secondValue.Count);
			for (int i = 0; i < secondValue.Count; i++) {
				result.Add(N - secondValue[i]);
			}
			return result;
		}


		#endregion

		#region operator > < >= <= == !=
		public static MyList operator >(MyList firstValue, MyList secondValue)
		{
			MyList result = new MyList(firstValue.Count);
			for (int i = 0; i < firstValue.Count; i++) {
				var b = Math.Round(firstValue[i] - secondValue[i], digits, MidpointRounding.AwayFromZero);
				result.Add(b > 0 ? 1 : 0);
			}
			return result;
		}
		public static MyList operator <(MyList firstValue, MyList secondValue)
		{
			MyList result = new MyList(firstValue.Count);
			for (int i = 0; i < firstValue.Count; i++) {
				var b = Math.Round(firstValue[i] - secondValue[i], digits, MidpointRounding.AwayFromZero);
				result.Add(b < 0 ? 1 : 0);
			}
			return result;
		}
		public static MyList operator >=(MyList firstValue, MyList secondValue)
		{
			MyList result = new MyList(firstValue.Count);
			for (int i = 0; i < firstValue.Count; i++) {
				var b = Math.Round(firstValue[i] - secondValue[i], digits, MidpointRounding.AwayFromZero);
				result.Add(b >= 0 ? 1 : 0);
			}
			return result;
		}
		public static MyList operator <=(MyList firstValue, MyList secondValue)
		{
			MyList result = new MyList(firstValue.Count);
			for (int i = 0; i < firstValue.Count; i++) {
				var b = Math.Round(firstValue[i] - secondValue[i], digits, MidpointRounding.AwayFromZero);
				result.Add(b <= 0 ? 1 : 0);
			}
			return result;
		}
		public static MyList operator ==(MyList firstValue, MyList secondValue)
		{
			MyList result = new MyList(firstValue.Count);
			for (int i = 0; i < firstValue.Count; i++) {
				var b = Math.Round(firstValue[i] - secondValue[i], digits, MidpointRounding.AwayFromZero);
				result.Add(b == 0 ? 1 : 0);
			}
			return result;
		}
		public static MyList operator !=(MyList firstValue, MyList secondValue)
		{
			MyList result = new MyList(firstValue.Count);
			for (int i = 0; i < firstValue.Count; i++) {
				var b = Math.Round(firstValue[i] - secondValue[i], digits, MidpointRounding.AwayFromZero);
				result.Add(b != 0 ? 1 : 0);
			}
			return result;
		}

		public static MyList operator >(MyList firstValue, int secondValue)
		{
			MyList result = new MyList(firstValue.Count);
			for (int i = 0; i < firstValue.Count; i++) {
				var b = Math.Round(firstValue[i] - secondValue, digits, MidpointRounding.AwayFromZero);
				result.Add(b > 0 ? 1 : 0);
			}
			return result;
		}
		public static MyList operator <(MyList firstValue, int secondValue)
		{
			MyList result = new MyList(firstValue.Count);
			for (int i = 0; i < firstValue.Count; i++) {
				var b = Math.Round(firstValue[i] - secondValue, digits, MidpointRounding.AwayFromZero);
				result.Add(b < 0 ? 1 : 0);
			}
			return result;
		}
		public static MyList operator >=(MyList firstValue, int secondValue)
		{
			MyList result = new MyList(firstValue.Count);
			for (int i = 0; i < firstValue.Count; i++) {
				var b = Math.Round(firstValue[i] - secondValue, digits, MidpointRounding.AwayFromZero);
				result.Add(b >= 0 ? 1 : 0);
			}
			return result;
		}
		public static MyList operator <=(MyList firstValue, int secondValue)
		{
			MyList result = new MyList(firstValue.Count);
			for (int i = 0; i < firstValue.Count; i++) {
				var b = Math.Round(firstValue[i] - secondValue, digits, MidpointRounding.AwayFromZero);
				result.Add(b <= 0 ? 1 : 0);
			}
			return result;
		}
		public static MyList operator ==(MyList firstValue, int secondValue)
		{
			MyList result = new MyList(firstValue.Count);
			for (int i = 0; i < firstValue.Count; i++) {
				var b = Math.Round(firstValue[i] - secondValue, digits, MidpointRounding.AwayFromZero);
				result.Add(b == 0 ? 1 : 0);
			}
			return result;
		}
		public static MyList operator !=(MyList firstValue, int secondValue)
		{
			MyList result = new MyList(firstValue.Count);
			for (int i = 0; i < firstValue.Count; i++) {
				var b = Math.Round(firstValue[i] - secondValue, digits, MidpointRounding.AwayFromZero);
				result.Add(b != 0 ? 1 : 0);
			}
			return result;
		}

		public static MyList operator >(MyList firstValue, double secondValue)
		{
			MyList result = new MyList(firstValue.Count);
			for (int i = 0; i < firstValue.Count; i++) {
				var b = Math.Round(firstValue[i] - secondValue, digits, MidpointRounding.AwayFromZero);
				result.Add(b > 0 ? 1 : 0);
			}
			return result;
		}
		public static MyList operator <(MyList firstValue, double secondValue)
		{
			MyList result = new MyList(firstValue.Count);
			for (int i = 0; i < firstValue.Count; i++) {
				var b = Math.Round(firstValue[i] - secondValue, digits, MidpointRounding.AwayFromZero);
				result.Add(b < 0 ? 1 : 0);
			}
			return result;
		}
		public static MyList operator >=(MyList firstValue, double secondValue)
		{
			MyList result = new MyList(firstValue.Count);
			for (int i = 0; i < firstValue.Count; i++) {
				var b = Math.Round(firstValue[i] - secondValue, digits, MidpointRounding.AwayFromZero);
				result.Add(b >= 0 ? 1 : 0);
			}
			return result;
		}
		public static MyList operator <=(MyList firstValue, double secondValue)
		{
			MyList result = new MyList(firstValue.Count);
			for (int i = 0; i < firstValue.Count; i++) {
				var b = Math.Round(firstValue[i] - secondValue, digits, MidpointRounding.AwayFromZero);
				result.Add(b <= 0 ? 1 : 0);
			}
			return result;
		}
		public static MyList operator ==(MyList firstValue, double secondValue)
		{
			MyList result = new MyList(firstValue.Count);
			for (int i = 0; i < firstValue.Count; i++) {
				var b = Math.Round(firstValue[i] - secondValue, digits, MidpointRounding.AwayFromZero);
				result.Add(b == 0 ? 1 : 0);
			}
			return result;
		}
		public static MyList operator !=(MyList firstValue, double secondValue)
		{
			MyList result = new MyList(firstValue.Count);
			for (int i = 0; i < firstValue.Count; i++) {
				var b = Math.Round(firstValue[i] - secondValue, digits, MidpointRounding.AwayFromZero);
				result.Add(b != 0 ? 1 : 0);
			}
			return result;
		}


		public static MyList operator >(int firstValue, MyList secondValue)
		{
			MyList result = new MyList(secondValue.Count);
			for (int i = 0; i < secondValue.Count; i++) {
				var b = Math.Round(firstValue - secondValue[i], digits, MidpointRounding.AwayFromZero);
				result.Add(b > 0 ? 1 : 0);
			}
			return result;
		}
		public static MyList operator <(int firstValue, MyList secondValue)
		{
			MyList result = new MyList(secondValue.Count);
			for (int i = 0; i < secondValue.Count; i++) {
				var b = Math.Round(firstValue - secondValue[i], digits, MidpointRounding.AwayFromZero);
				result.Add(b < 0 ? 1 : 0);
			}
			return result;
		}
		public static MyList operator >=(int firstValue, MyList secondValue)
		{
			MyList result = new MyList(secondValue.Count);
			for (int i = 0; i < secondValue.Count; i++) {
				var b = Math.Round(firstValue - secondValue[i], digits, MidpointRounding.AwayFromZero);
				result.Add(b >= 0 ? 1 : 0);
			}
			return result;
		}
		public static MyList operator <=(int firstValue, MyList secondValue)
		{
			MyList result = new MyList(secondValue.Count);
			for (int i = 0; i < secondValue.Count; i++) {
				var b = Math.Round(firstValue - secondValue[i], digits, MidpointRounding.AwayFromZero);
				result.Add(b <= 0 ? 1 : 0);
			}
			return result;
		}
		public static MyList operator ==(int firstValue, MyList secondValue)
		{
			MyList result = new MyList(secondValue.Count);
			for (int i = 0; i < secondValue.Count; i++) {
				var b = Math.Round(firstValue - secondValue[i], digits, MidpointRounding.AwayFromZero);
				result.Add(b == 0 ? 1 : 0);
			}
			return result;
		}
		public static MyList operator !=(int firstValue, MyList secondValue)
		{
			MyList result = new MyList(secondValue.Count);
			for (int i = 0; i < secondValue.Count; i++) {
				var b = Math.Round(firstValue - secondValue[i], digits, MidpointRounding.AwayFromZero);
				result.Add(b != 0 ? 1 : 0);
			}
			return result;
		}

		public static MyList operator >(double firstValue, MyList secondValue)
		{
			MyList result = new MyList(secondValue.Count);
			for (int i = 0; i < secondValue.Count; i++) {
				var b = Math.Round(firstValue - secondValue[i], digits, MidpointRounding.AwayFromZero);
				result.Add(b > 0 ? 1 : 0);
			}
			return result;
		}
		public static MyList operator <(double firstValue, MyList secondValue)
		{
			MyList result = new MyList(secondValue.Count);
			for (int i = 0; i < secondValue.Count; i++) {
				var b = Math.Round(firstValue - secondValue[i], digits, MidpointRounding.AwayFromZero);
				result.Add(b < 0 ? 1 : 0);
			}
			return result;
		}
		public static MyList operator >=(double firstValue, MyList secondValue)
		{
			MyList result = new MyList(secondValue.Count);
			for (int i = 0; i < secondValue.Count; i++) {
				var b = Math.Round(firstValue - secondValue[i], digits, MidpointRounding.AwayFromZero);
				result.Add(b >= 0 ? 1 : 0);
			}
			return result;
		}
		public static MyList operator <=(double firstValue, MyList secondValue)
		{
			MyList result = new MyList(secondValue.Count);
			for (int i = 0; i < secondValue.Count; i++) {
				var b = Math.Round(firstValue - secondValue[i], digits, MidpointRounding.AwayFromZero);
				result.Add(b <= 0 ? 1 : 0);
			}
			return result;
		}
		public static MyList operator ==(double firstValue, MyList secondValue)
		{
			MyList result = new MyList(secondValue.Count);
			for (int i = 0; i < secondValue.Count; i++) {
				var b = Math.Round(firstValue - secondValue[i], digits, MidpointRounding.AwayFromZero);
				result.Add(b == 0 ? 1 : 0);
			}
			return result;
		}
		public static MyList operator !=(double firstValue, MyList secondValue)
		{
			MyList result = new MyList(secondValue.Count);
			for (int i = 0; i < secondValue.Count; i++) {
				var b = Math.Round(firstValue - secondValue[i], digits, MidpointRounding.AwayFromZero);
				result.Add(b != 0 ? 1 : 0);
			}
			return result;
		}


		#endregion
	}


}
