using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolGood.TdxFormula.Internals.Models;

namespace ToolGood.TdxFormula.Internals
{
    public static class MyMath
    {
        private const int digits = 4;

        public static MyList Variable(double N, int length)
        {
            MyList result = new MyList(length);
            for (int i = 0; i < length; i++) {
                result.Add(N);
            }
            return result;
        }

        public static MyList IF(List<bool> X, List<double> TRUE, List<double> FALSE)
        {
            MyList result = new MyList(X.Count);
            for (int i = 0; i < X.Count; i++) {
                if (X[i]) {
                    result.Add(TRUE[i]);
                } else {
                    result.Add(FALSE[i]);
                }
            }
            return result;
        }
        public static MyList IF(List<bool> X, List<double> TRUE, double FALSE)
        {
            MyList result = new MyList(X.Count);
            for (int i = 0; i < X.Count; i++) {
                if (X[i]) {
                    result.Add(TRUE[i]);
                } else {
                    result.Add(FALSE);
                }
            }
            return result;
        }
        public static MyList IF(List<double> X, List<double> TRUE, double FALSE)
        {
            MyList result = new MyList(X.Count);
            for (int i = 0; i < X.Count; i++) {
                if (X[i] == 1) {
                    result.Add(TRUE[i]);
                } else {
                    result.Add(FALSE);
                }
            }
            return result;
        }
        public static MyList IF(List<double> X, List<double> TRUE, List<double> FALSE)
        {
            MyList result = new MyList(X.Count);
            for (int i = 0; i < X.Count; i++) {
                if (X[i] == 1) {
                    result.Add(TRUE[i]);
                } else {
                    result.Add(FALSE[i]);
                }
            }
            return result;
        }


        public static MyList BARSSINCEN(List<bool> X, int N)
        {
            var length = X.Count;
            MyList array = new MyList(length);
            for (int i = 0; i < length; i++) {
                array.Add(-1);
            }

            for (int i = 0; i < length; i++) {
                if (X[i] == false) { continue; }
                for (int j = 0; j < N; j++) {
                    if (i + j < length && array[i + j] < j) {
                        array[i + j] = j;
                    }
                }
            }
            return array;
        }
        public static MyList HHVBARS(List<double> X, int N)
        {
            var length = X.Count;
            N = MyMath.Max(N, 0);
            MyList array = new MyList(length);
            double max = -1;
            int index = -1;
            if (N <= 0) {
                for (int i = 0; i < length; i++) {
                    index++;
                    if (X[i] > max) {
                        max = X[i];
                        index = 0;
                    }
                    array.Add(index);
                }
                return array;
            }

            for (int i = 0; i < Math.Min(N, length); i++) {
                index++;
                if (X[i] > max) {
                    max = X[i];
                    index = 0;
                }
                array.Add(index);
            }
            for (int i = N; i < length; i++) {
                if (X[i] > max) {
                    max = X[i];
                    index = 0;
                } else if (X[i - N] == max) {
                    max = -1;
                    index = -1;
                    for (int j = i - N + 1; j <= i; j++) {
                        index++;
                        if (X[j] > max) {
                            max = X[j];
                            index = 0;
                        }
                    }
                } else {
                    index++;
                }
                array.Add(index);
            }
            return array;
        }

        public static MyList LLVBARS(List<double> X, int N)
        {
            var length = X.Count;
            N = MyMath.Max(N, 0);
            MyList array = new MyList(length);
            double min = double.MaxValue;
            int index = -1;
            if (N <= 0) {
                for (int i = 0; i < length; i++) {
                    index++;
                    if (X[i] < min) {
                        min = X[i];
                        index = 0;
                    }
                    array.Add(index);
                }
                return array;
            }

            for (int i = 0; i < Math.Min(N, length); i++) {
                index++;
                if (X[i] < min) {
                    min = X[i];
                    index = 0;
                }
                array.Add(index);
            }
            for (int i = N; i < length; i++) {
                if (X[i] < min) {
                    min = X[i];
                    index = 0;
                } else if (X[i - N] == min) {
                    min = double.MaxValue;
                    index = -1;
                    for (int j = i - N + 1; j <= i; j++) {
                        index++;
                        if (X[j] < min) {
                            min = X[j];
                            index = 0;
                        }
                    }
                } else {
                    index++;
                }
                array.Add(index);
            }
            return array;
        }
        public static MyList COUNT(List<bool> X, int N)
        {
            var length = X.Count;
            MyList array = new MyList(length);
            int index = 0;
            if (N <= 0) {
                for (int i = 0; i < length; i++) {
                    if (X[i]) index++;
                    array.Add(index);
                }
                return array;
            }
            for (int i = 0; i < Math.Min(N - 1, length); i++) {
                if (X[i]) index++;
                array.Add(index);
            }

            for (int i = N - 1; i < length; i++) {
                if (X[i]) index++;
                array.Add(index);
                if (X[i - N + 1]) index--;
            }
            return array;
        }
        public static MyList COUNT(List<double> X, int N)
        {
            var length = X.Count;
            MyList array = new MyList(length);
            int index = 0;
            if (N <= 0) {
                for (int i = 0; i < length; i++) {
                    if (X[i] == 1) index++;
                    array.Add(index);
                }
                return array;
            }
            for (int i = 0; i < Math.Min(N - 1, length); i++) {
                if (X[i] == 1) index++;
                array.Add(index);
            }

            for (int i = N - 1; i < length; i++) {
                if (X[i] == 1) index++;
                array.Add(index);
                if (X[i - N + 1] == 1) index--;
            }
            return array;
        }

        public static MyList HHV(List<double> X, int N)
        {
            var length = X.Count;
            MyList array = new MyList(length);

            double max = -1;
            if (N <= 0) {
                for (int i = 0; i < length; i++) {
                    if (X[i] > max) max = X[i];
                    array.Add(max);
                }
                return array;
            }

            for (int i = 0; i < Math.Min(N, length); i++) {
                if (X[i] > max) max = X[i];
                array.Add(max);
            }
            for (int i = N; i < length; i++) {
                if (X[i] > max) {
                    max = X[i];
                } else if (X[i - N] == max) {
                    max = -1;
                    for (int j = i - N + 1; j <= i; j++) {
                        if (X[j] > max) max = X[j];
                    }
                }
                array.Add(max);
            }
            return array;
        }
        public static MyList LLV(List<double> X, int N)
        {
            var length = X.Count;
            MyList array = new MyList(length);
            double min = double.MaxValue;

            if (N <= 0) {
                for (int i = 0; i < length; i++) {
                    if (X[i] > min) min = X[i];
                    array.Add(min);
                }
                return array;
            }

            for (int i = 0; i < Math.Min(N, length); i++) {
                if (X[i] < min) min = X[i];
                array.Add(min);
            }
            for (int i = N; i < length; i++) {
                if (X[i] < min) {
                    min = X[i];
                } else if (X[i - N] == min) {
                    min = double.MaxValue;
                    for (int j = i - N + 1; j <= i; j++) {
                        if (X[j] < min) min = X[j];
                    }
                }
                array.Add(min);
            }
            return array;
        }
        public static MyList REF(List<double> X, int N)
        {
            var length = X.Count;
            MyList array = new MyList(length);
            for (int i = 0; i < Math.Min(N, length); i++) {
                array.Add(X[0]);
            }
            for (int i = N; i < length; i++) {
                array.Add(X[i - N]);
            }
            return array;
        }
        public static MyList MAX(double N, List<double> X)
        {
            return MAX(X, N);
        }

        public static MyList MAX(List<double> X, double N)
        {
            var length = X.Count;
            MyList array = new MyList(length);
            foreach (var item in X) {
                if (item > N) {
                    array.Add(item);
                } else {
                    array.Add(N);
                }
            }
            return array;
        }
        public static MyList MAX(List<double> X, List<double> N)
        {
            var length = X.Count;
            MyList array = new MyList(length);
            for (int i = 0; i < length; i++) {
                if (X[i] > N[i]) {
                    array.Add(X[i]);
                } else {
                    array.Add(N[i]);
                }
            }
            return array;
        }


        public static MyList ABS(List<double> X)
        {
            var length = X.Count;
            MyList array = new MyList(length);
            foreach (var item in X) {
                array.Add(Math.Abs(item));
            }
            return array;
        }


        public static MyList SMA(List<double> X, int N, int M = 1)
        {
            var length = X.Count;
            MyList array = new MyList(length);

            double Y = 0.0;
            for (int i = 0; i < length; i++) {
                Y = (X[i] * M + Y * (N - M)) / N;
                array.Add(Y);
            }
            return array;
        }

        public static MyList SUM(List<double> X, int N)
        {
            var length = X.Count;
            MyList array = new MyList(length);
            double sum = 0;
            if (N <= 0) {
                for (int i = 0; i < length; i++) {
                    sum += X[i];
                    array.Add(sum);
                }
                return array;
            }
            for (int i = 0; i < Math.Min(N, length); i++) {
                sum += X[i];
                array.Add(sum);
            }

            for (int i = N; i < length; i++) {
                sum += X[i];
                sum -= X[i - N];
                array.Add(sum);
            }
            return array;
        }
        public static MyList SUMBARS(List<double> X, int N)
        {
            var length = X.Count;
            MyList array = new MyList(length);
            for (int i = length - 1; i >= 0; i--) {
                double sum = 0;
                int index = i;
                int count = 0;
                while (index >= 0 && sum < N) {
                    count++;
                    sum += X[index];
                    index--;
                }
                array.Add(count);
            }
            array.Reverse();
            return array;
        }
        public static MyList MA(List<double> X, int N)
        {
            var length = X.Count;
            MyList array = new MyList(length);
            double sum = 0;
            for (int i = 0; i < Math.Min(N, length); i++) {
                sum += X[i];
                array.Add(sum / (i + 1));
            }

            for (int i = N; i < length; i++) {
                sum += X[i];
                sum -= X[i - N];
                array.Add(sum / N);
            }
            return array;
        }
        public static MyList EMA(List<double> X, int N)
        {
            var length = X.Count;
            MyList array = new MyList(length);

            double Y = 0.0;
            for (int i = 0; i < length; i++) {
                Y = (X[i] * 2 + Y * (N - 1)) / (N + 1);
                array.Add(Y);
            }
            return array;
        }
        public static MyList MEMA(List<double> X, int N)
        {
            var length = X.Count;
            MyList array = new MyList(length);

            double Y = 0.0;
            for (int i = 0; i < length; i++) {
                Y = (X[i] + Y * (N - 1)) / N;
                array.Add(Y);
            }
            return array;
        }
        public static MyList DMA(List<double> X, double A)
        {
            var length = X.Count;
            if (A <= 0 || A >= 1) {
                throw new Exception("Function DMA parameter A(1) is Error");
            }

            MyList array = new MyList(length);

            double Y = 0.0;
            for (int i = 0; i < length; i++) {
                Y = A * X[i] + (1 - A) * Y;
                array.Add(Y);
            }
            return array;
        }
        public static MyList DMA(List<double> X, List<double> A)
        {
            var length = X.Count;

            MyList array = new MyList(length);
            array.Add(X[0]);
            double Y = X[0];
            for (int i = 1; i < length; i++) {
                Y = A[i] * X[i] + (1 - A[i]) * Y;
                array.Add(Y);
            }
            return array;
        }


        public static MyList WMA(List<double> X, int N)
        {
            var length = X.Count;
            MyList array = new MyList(length);
            var temp = 0;
            for (int i = 1; i <= N; i++) {
                array.Add(0);
                temp += i;
            }

            for (int i = N; i < length; i++) {
                double sum = 0;
                for (int j = 1; j <= N; j++) {
                    sum += X[i - N + j] * j;
                }
                array.Add(sum / temp);
            }
            return array;
        }
        public static MyList FILTER(List<bool> X, int N)
        {
            var length = X.Count;
            MyList array = new MyList(length);

            var skipCount = 0;
            for (int i = 0; i < length; i++) {
                if (skipCount > 0) {
                    array.Add(0);
                    skipCount--;
                    continue;
                }
                if (X[i]) {
                    array.Add(1);
                    skipCount = N;
                } else {
                    array.Add(0);
                }
            }
            return array;
        }
        public static MyList FILTERX(List<bool> X, int N)
        {
            var length = X.Count;
            MyList array = new MyList(length);

            var skipCount = 0;
            for (int i = length - 1; i >= 0; i--) {
                if (skipCount > 0) {
                    array.Add(0);
                    skipCount--;
                    continue;
                }
                if (X[i]) {
                    array.Add(1);
                    skipCount = N;
                } else {
                    array.Add(0);
                }
            }
            array.Reverse();
            return array;
        }
        public static MyList HOD(List<double> X, int N)
        {
            var length = X.Count;
            MyList array = new MyList(length);

            List<double> temp = new List<double>(Math.Min(400, N)); // 从大到小
            if (N == 0) {
                for (int i = 0; i < length; i++) {
                    var x = X[i];
                    var sort = MyMath.InsertArray_Max2Min(temp, x);
                    array.Add(sort);
                }
                return array;
            }
            for (int i = 0; i < Math.Min(N, length); i++) {
                var x = X[i];
                var sort = MyMath.InsertArray_Max2Min(temp, x);
                array.Add(sort);
            }
            for (int i = N; i < length; i++) {
                var x = X[i];
                temp.Remove(X[i - N]);
                var sort = MyMath.InsertArray_Max2Min(temp, x);
                array.Add(sort);
            }
            return array;
        }
        public static MyList LOD(List<double> X, int N)
        {
            var length = X.Count;
            MyList array = new MyList(length);
            List<double> temp = new List<double>(Math.Min(400, N)); // 从大到小

            if (N == 0) {
                for (int i = 0; i < length; i++) {
                    var x = X[i];
                    var sort = MyMath.InsertArray_Min2Max(temp, x);
                    array.Add(sort);
                }
                return array;
            }
            for (int i = 0; i < Math.Min(N, length); i++) {
                var x = X[i];
                var sort = MyMath.InsertArray_Min2Max(temp, x);
                array.Add(sort);
            }
            for (int i = N; i < length; i++) {
                var x = X[i];
                temp.Remove(X[i - N]);
                var sort = MyMath.InsertArray_Min2Max(temp, x);
                array.Add(sort);
            }
            return array;
        }
        public static MyList MULAR(List<double> X, int N)
        {
            var length = X.Count;

            MyList array = new MyList(length);
            double sum = 1;
            if (N == 0) {
                for (int i = 0; i < length; i++) {
                    sum *= X[i];
                    array.Add(sum);
                }
                return array;
            }
            for (int i = 0; i < Math.Min(N - 1, length); i++) {
                sum *= X[i];
                array.Add(sum);
            }

            for (int i = N - 1; i < length; i++) {
                sum *= X[i];
                array.Add(sum);
                sum /= X[i - N + 1];
            }
            return array;
        }
        public static MyList ZTPRICE(List<double> X, double N)
        {
            var length = X.Count;

            MyList array = new MyList(length);
            for (int i = 0; i < length; i++) {
                array.Add((double)X[i] * (1 + N));
            }
            return array;
        }
        public static MyList DTPRICE(List<double> X, double N)
        {
            var length = X.Count;

            MyList array = new MyList(length);
            for (int i = 0; i < length; i++) {
                array.Add((double)X[i] * (1 - N));
            }
            return array;
        }

        public static MyList UPNDAY(List<double> X, int N)
        {
            var length = X.Count;
            MyList array = new MyList(length);
            array.Add(0);
            var temp = 0;
            for (int i = 1; i < Math.Min(N, length); i++) {
                array.Add(0);
                if (X[i] > X[i - 1]) {
                    temp++;
                } else {
                    temp = 0;
                }
            }
            for (int i = N; i < length; i++) {
                if (X[i] > X[i - 1]) {
                    temp++;
                    if (temp >= N) {
                        array.Add(1);
                    } else {
                        array.Add(0);
                    }
                } else {
                    temp = 0;
                    array.Add(0);
                }
            }
            return array;
        }

        public static MyList DOWNNDAY(List<double> X, int N)
        {
            var length = X.Count;
            MyList array = new MyList(length);
            array.Add(0);
            var temp = 0;
            for (int i = 1; i < Math.Min(N, length); i++) {
                array.Add(0);
                if (X[i] < X[i - 1]) {
                    temp++;
                } else {
                    temp = 0;
                }
            }
            for (int i = N; i < length; i++) {
                if (X[i] < X[i - 1]) {
                    temp++;
                    if (temp >= N) {
                        array.Add(1);
                    } else {
                        array.Add(0);
                    }
                } else {
                    temp = 0;
                    array.Add(0);
                }
            }
            return array;
        }

        public static MyList NDAY(List<double> X, List<double> Y, int N)
        {
            var length = X.Count;
            MyList array = new MyList(length);
            var temp = 0;
            for (int i = 0; i < Math.Min(N, length); i++) {
                array.Add(0);
                if (X[i] > Y[i]) {
                    temp++;
                } else {
                    temp = 0;
                }
            }
            for (int i = N; i < length; i++) {
                if (X[i] > Y[i]) {
                    temp++;
                    if (temp >= N) {
                        array.Add(1);
                    } else {
                        array.Add(0);
                    }
                } else {
                    temp = 0;
                    array.Add(0);
                }

            }
            return array;
        }
        public static MyList EXIST(List<bool> X, int N)
        {
            var length = X.Count;
            MyList array = new MyList(length);
            for (int i = 0; i < length; i++) {
                bool b = false;
                for (int j = i; j >= MyMath.Max(i - N + 1, 0); j--) {
                    if (X[j]) {
                        b = true;
                        break;
                    }
                }
                array.Add(b ? 1 : 0);
            }
            return array;
        }
        public static MyList EVERY(List<bool> X, int N)
        {
            var length = X.Count;
            MyList array = new MyList(length);
            var temp = 0;
            for (int i = 0; i < Math.Min(N, length); i++) {
                array.Add(0);
                if (X[i]) {
                    temp++;
                } else {
                    temp = 0;
                }
            }
            for (int i = N; i < length; i++) {
                if (X[i]) {
                    temp++;
                    if (temp >= N) {
                        array.Add(1);
                    } else {
                        array.Add(0);
                    }
                } else {
                    temp = 0;
                    array.Add(0);
                }

            }
            return array;
        }

        public static MyList AVEDEV(List<double> X, int N)
        {
            var length = X.Count;
            MyList array = new MyList(length);
            List<double> temp = new List<double>(N);

            for (int i = 0; i < Math.Min(N - 1, length); i++) {
                temp.Add(X[i]);
                array.Add(0);
            }
            for (int i = N - 1; i < length; i++) {
                temp.Add(X[i]);
                double avg = temp.Average();
                double sum = 0;
                for (int j = 0; j < temp.Count; j++) {
                    sum += Math.Abs(temp[j] - avg);
                }
                array.Add(sum / temp.Count);

                temp.RemoveAt(0);
            }
            return array;
        }
        public static MyList DEVSQ(List<double> X, int N)
        {
            var length = X.Count;
            MyList array = new MyList(length);
            List<double> temp = new List<double>(N);

            for (int i = 0; i < Math.Min(N - 1, length); i++) {
                temp.Add(X[i]);
                array.Add(0);
            }
            for (int i = N - 1; i < length; i++) {
                temp.Add(X[i]);
                double avg = temp.Average();
                double sum = 0;
                for (int j = 0; j < temp.Count; j++) {
                    sum += (temp[j] - avg) * (temp[j] - avg);
                }
                array.Add(sum);

                temp.RemoveAt(0);
            }
            return array;
        }
        public static MyList FORCAST(List<double> X, int N)
        {
            var length = X.Count;
            MyList array = new MyList(length);
            double averagex = (N - 1) / 2.0;
            double denominator = 0;
            for (int i = 0; i < Math.Min(N, length); i++) {
                denominator += (i - averagex) * (i - averagex);
            }

            List<double> temp = new List<double>(N);

            for (int i = 0; i < Math.Min(N - 1, length); i++) {
                temp.Add(X[i]);
                array.Add(0);
            }
            for (int i = N - 1; i < length; i++) {
                temp.Add(X[i]);

                var t = MyMath.LinearRegression(temp, averagex, denominator);
                array.Add(t);

                temp.RemoveAt(0);
            }
            return array;
        }
        public static MyList SLOPE(List<double> X, int N)
        {
            var length = X.Count;
            MyList array = new MyList(length);
            double averagex = (N - 1) / 2.0;
            double denominator = 0;
            for (int i = 0; i < Math.Min(N, length); i++) {
                denominator += (i - averagex) * (i - averagex);
            }

            List<double> temp = new List<double>(N);

            for (int i = 0; i < Math.Min(N - 1, length); i++) {
                temp.Add(X[i]);
                array.Add(0);
            }
            for (int i = N - 1; i < length; i++) {
                temp.Add(X[i]);

                var t = MyMath.LinearRegressionCoefficient(temp, averagex, denominator);
                array.Add(t);

                temp.RemoveAt(0);
            }
            return array;
        }
        public static MyList STD(List<double> X, int N)
        {
            var length = X.Count;
            MyList array = new MyList(length);
            List<double> temp = new List<double>(N);

            for (int i = 0; i < Math.Min(N - 1, length); i++) {
                temp.Add(X[i]);
                array.Add(0);
            }
            for (int i = N - 1; i < length; i++) {
                temp.Add(X[i]);
                double avg = temp.Average();
                double sum = 0;
                for (int j = 0; j < temp.Count; j++) {
                    sum += (temp[j] - avg) * (temp[j] - avg);
                }
                array.Add(Math.Sqrt(sum / (temp.Count - 1)));
                temp.RemoveAt(0);
            }
            return array;
        }
        public static MyList STDP(List<double> X, int N)
        {
            var length = X.Count;
            MyList array = new MyList(length);
            List<double> temp = new List<double>(N);

            for (int i = 0; i < Math.Min(N - 1, length); i++) {
                temp.Add(X[i]);
                array.Add(0);
            }
            for (int i = N - 1; i < length; i++) {
                temp.Add(X[i]);
                double avg = temp.Average();
                double sum = 0;
                for (int j = 0; j < temp.Count; j++) {
                    sum += (temp[j] - avg) * (temp[j] - avg);
                }
                array.Add(Math.Sqrt(sum / temp.Count));
                temp.RemoveAt(0);
            }
            return array;
        }
        public static MyList STDDEV(List<double> X, int N)
        {
            var length = X.Count;
            MyList array = new MyList(length);
            List<double> temp = new List<double>(N);

            for (int i = 0; i < Math.Min(N - 1, length); i++) {
                temp.Add(X[i]);
                array.Add(0);
            }
            for (int i = N - 1; i < length; i++) {
                temp.Add(X[i]);
                double avg = temp.Average();
                double sum = 0;
                for (int j = 0; j < temp.Count; j++) {
                    sum += (temp[j] - avg) * (temp[j] - avg);
                }
                array.Add(Math.Sqrt(sum / (temp.Count - 1)) / temp.Count);
                temp.RemoveAt(0);
            }
            return array;
        }
        public static MyList VAR(List<double> X, int N)
        {
            var length = X.Count;
            MyList array = new MyList(length);
            List<double> temp = new List<double>(N);

            for (int i = 0; i < Math.Min(N - 1, length); i++) {
                temp.Add(X[i]);
                array.Add(0);
            }
            for (int i = N - 1; i < length; i++) {
                temp.Add(X[i]);

                double sum = 0;
                double sum2 = 0;
                for (int j = 0; j < temp.Count; j++) {
                    sum += temp[j] * temp[j];
                    sum2 += temp[j];
                }
                var t = (temp.Count * sum - sum2 * sum2) / temp.Count / (temp.Count - 1);
                array.Add(t);

                temp.RemoveAt(0);
            }
            return array;
        }
        public static MyList VARP(List<double> X, int N)
        {
            var length = X.Count;
            MyList array = new MyList(length);
            List<double> temp = new List<double>(N);

            for (int i = 0; i < Math.Min(N - 1, length); i++) {
                temp.Add(X[i]);
                array.Add(0);
            }
            for (int i = N - 1; i < length; i++) {
                temp.Add(X[i]);

                double sum = 0;
                double avg = temp.Average();
                for (int j = 0; j < temp.Count; j++) {
                    sum += (avg - temp[j]) * (avg - temp[j]);
                }
                var t = sum / temp.Count;
                array.Add(t);

                temp.RemoveAt(0);
            }
            return array;
        }
        public static MyList COVAR(List<double> X, List<double> Y, int N)
        {
            var length = X.Count;
            MyList array = new MyList(length);
            List<double> temp = new List<double>(N);
            List<double> temp2 = new List<double>(N);

            for (int i = 0; i < Math.Min(N - 1, length); i++) {
                temp.Add(X[i]);
                temp2.Add(Y[i]);
                array.Add(0);
            }
            for (int i = N - 1; i < length; i++) {
                temp.Add(X[i]);
                temp2.Add(Y[i]);


                double sum = 0;
                double avg = temp.Average();
                double avg2 = temp2.Average();
                for (int j = 0; j < temp.Count; j++) {
                    sum += (avg - temp[j]) * (avg2 - temp2[j]);
                }
                var t = sum / temp.Count;
                array.Add(t);

                temp.RemoveAt(0);
                temp2.RemoveAt(0);
            }
            return array;
        }
        public static MyList RELATE(List<double> X, List<double> Y, int N)
        {
            var length = X.Count;
            MyList array = new MyList(length);
            List<double> temp = new List<double>(N);
            List<double> temp2 = new List<double>(N);

            for (int i = 0; i < Math.Min(N - 1, length); i++) {
                temp.Add(X[i]);
                temp2.Add(Y[i]);
                array.Add(0);
            }
            for (int i = N - 1; i < length; i++) {
                temp.Add(X[i]);
                temp2.Add(Y[i]);

                double sum = 0;
                double sum2 = 0;
                double sum3 = 0;
                double avg = temp.Average();
                double avg2 = temp2.Average();
                for (int j = 0; j < temp.Count; j++) {
                    sum += (avg - temp[j]) * (avg2 - temp2[j]);
                    sum2 += (avg - temp[j]) * (avg - temp[j]);
                    sum3 += (avg2 - temp2[j]) * (avg2 - temp2[j]);
                }
                var t = sum / Math.Sqrt(sum2 * sum3);
                array.Add(t);

                temp.RemoveAt(0);
                temp2.RemoveAt(0);
            }
            return array;
        }





        public static List<SarModel> GetParabolicSar(List<double> High, List<double> Low, double S, double M)
        {
            int length = High.Count;
            List<SarModel> results = new List<SarModel>(length);

            double accelerationFactor = S;
            double extremePoint = High[0];
            double priorSar = Low[0];
            bool isRising = true;  // initial guess

            // roll through quotes
            for (int i = 0; i < length; i++) {

                SarModel r = new SarModel();
                results.Add(r);

                // skip first one
                if (i == 0) continue;

                // was rising
                if (isRising) {
                    double sar = priorSar + (accelerationFactor * (extremePoint - priorSar));

                    // SAR cannot be higher than last two lows
                    if (i >= 2) {
                        double minLastTwo = Math.Min(Low[i - 1], Low[i - 2]);
                        sar = Math.Min(sar, minLastTwo);
                    }

                    // turn down
                    if (Low[i] < sar) {
                        r.IsReversal = true;
                        r.Sar = extremePoint;

                        isRising = false;
                        accelerationFactor = S;
                        extremePoint = Low[i];
                    } else {
                        // continue rising
                        r.IsReversal = false;
                        r.Sar = sar;

                        // new high extreme point
                        if (High[i] > extremePoint) {
                            extremePoint = High[i];
                            accelerationFactor = Math.Min(accelerationFactor += S, M);
                        }
                    }
                } else {
                    // was falling
                    double sar = priorSar - (accelerationFactor * (priorSar - extremePoint));

                    // SAR cannot be lower than last two highs
                    if (i >= 2) {
                        double maxLastTwo = Math.Max(High[i - 1], High[i - 2]);
                        sar = Math.Max(sar, maxLastTwo);
                    }

                    // turn up
                    if (High[i] > sar) {
                        r.IsReversal = true;
                        r.Sar = extremePoint;

                        isRising = true;
                        accelerationFactor = S;
                        extremePoint = High[i];
                    } else {
                        // continue falling
                        r.IsReversal = false;
                        r.Sar = sar;

                        // new low extreme point
                        if (Low[i] < extremePoint) {
                            extremePoint = Low[i];
                            accelerationFactor = Math.Min(accelerationFactor += S, M);
                        }
                    }
                }

                priorSar = (double)r.Sar;
            }

            // remove first trend to reversal, since it is an invalid guess
            SarModel firstReversal = results.Where(x => x.IsReversal == true).FirstOrDefault();

            if (firstReversal != null) {
                int cutIndex = results.IndexOf(firstReversal);

                for (int d = 0; d <= cutIndex; d++) {
                    SarModel r = results[d];
                    r.Sar = null;
                    r.IsReversal = null;
                }
            }
            return results;
        }


        public static MyList Ziga(List<double> k, double x)
        {
            var peers = ZigPeeka(k, x);

            MyList z = new MyList(0, k.Count);
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
            return z;
        }

        public static List<int> ZigPeeka(List<double> k, double x)
        {
            const int state_none = 0;
            const int state_up = 1;
            const int state_down = 2;

            var peers = new List<int>() { 0 };
            bool isFirst = true;
            var tempStart = k[0];
            var tempIndex = 0;
            var state = state_none;

            for (int i = 1; i < k.Count - 1; i++) {
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
            peers.Add(k.Count - 1);
            return peers;
        }

        public static MyList Zig(List<double> k, double x)
        {
            var peers = ZigPeek(k, x);

            MyList z = new MyList(0, k.Count);
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
            return z;
        }

        public static List<int> ZigPeek(List<double> k, double x)
        {
            const int state_none = 0;
            const int state_up = 1;
            const int state_down = 2;

            var peers = new List<int>() { 0 };
            bool isFirst = true;
            var tempStart = k[0];
            var tempIndex = 0;
            var state = state_none;

            for (int i = 1; i < k.Count - 1; i++) {
                if (isFirst) {
                    if (k[i] > tempStart && Math.Round(k[i] - tempStart * (1 + x), digits, MidpointRounding.AwayFromZero) >= 0) {
                        tempStart = k[i];
                        tempIndex = i;
                        state = state_up;
                        isFirst = false;

                    } else if (k[i] < tempStart && Math.Round(k[i] * (1 + x) - tempStart, digits, MidpointRounding.AwayFromZero) <= 0) {
                        tempStart = k[i];
                        tempIndex = i;
                        state = state_down;
                        isFirst = false;
                    }
                } else if (state == state_up) {
                    if (Math.Round(k[i] - tempStart, digits, MidpointRounding.AwayFromZero) > 0) {
                        tempStart = k[i];
                        tempIndex = i;
                    } else if (Math.Round(k[i] * (1 + x) - tempStart, digits, MidpointRounding.AwayFromZero) <= 0) {
                        peers.Add(tempIndex);
                        tempStart = k[i];
                        tempIndex = i;
                        state = state_down;
                    }
                } else if (state == state_down) {
                    if (Math.Round(k[i] - tempStart, digits, MidpointRounding.AwayFromZero) < 0) {
                        tempStart = k[i];
                        tempIndex = i;
                    } else if (Math.Round(k[i] - tempStart * (1 + x), digits, MidpointRounding.AwayFromZero) >= 0) {
                        peers.Add(tempIndex);
                        tempStart = k[i];
                        tempIndex = i;
                        state = state_up;
                    }
                }
            }
            peers.Add(tempIndex);
            peers.Add(k.Count - 1);
            return peers;
        }

        public static double LinearRegressionCoefficient(List<double> parray, double averagex, double denominator)
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

        public static double LinearRegression(List<double> parray, double averagex, double denominator)
        {
            //求出横纵坐标的平均值
            double averagey = parray.Average();

            //经验回归系数的分子
            double numerator = 0;
            for (int i = 0; i < parray.Count; i++) {
                numerator += (i - averagex) * (parray[i] - averagey);
            }
            //回归系数b（Regression Coefficient）
            double RCB = numerator / denominator;

            //回归系数a
            double RCA = averagey - RCB * averagex;
            return RCA + RCB * parray.Count();
        }

        public static int InsertArray_Max2Min(List<double> arr, double x)
        {
            int low = 0, high = arr.Count - 1;
            int mid;
            while (low <= high) {
                mid = low + (high - low) / 2;
                if (x > arr[mid]) {
                    high = mid - 1;
                } else { // 元素相同时，也插入在后面的位置                
                    low = mid + 1;
                }
            }
            arr.Insert(low, x);
            return low + 1;
        }
        public static int InsertArray_Min2Max(List<double> arr, double x)
        {
            int low = 0, high = arr.Count - 1;
            int mid;
            while (low <= high) {
                mid = low + (high - low) / 2;
                if (x < arr[mid]) {
                    high = mid - 1;
                } else { // 元素相同时，也插入在后面的位置                
                    low = mid + 1;
                }
            }
            arr.Insert(low, x);
            return low + 1;
        }
        public static int Max(params int[] array)
        {
            return array.Max();
        }
        public static double Max(params double[] array)
        {
            return array.Max();
        }
        public static double Min(params double[] array)
        {
            return array.Min();
        }
        public static Dictionary<int, double> CalcChip(Dictionary<int, double> oldCost, Dictionary<int, double> newCost, double oldaf, double newaf, double TurnoverRateT, double A = 1)
        {
            var diff = oldaf / newaf;
            if (diff > 1.03 || diff < 0.97) {
                oldCost = NewCost(oldCost, diff);
            }
            return CalcChip2(oldCost, newCost, TurnoverRateT, A);
        }
        private static Dictionary<int, double> NewCost(Dictionary<int, double> oldCost, double p)
        {
            Dictionary<int, double> result = new Dictionary<int, double>(oldCost.Count);
            Dictionary<int, int> result2 = new Dictionary<int, int>(oldCost.Count);
            foreach (var item in oldCost) {
                var key = (int)(item.Key * p + 0.5);
                if (result.TryGetValue(key, out double v)) {
                    result[key] = v + item.Value;
                    if (result2.TryGetValue(key, out int val)) {
                        result2[key] = val + 1;
                    } else {
                        result2[key] = 2;
                    }
                } else {
                    result[key] = item.Value;
                }
            }
            foreach (var item in result2) {
                result[item.Key] = result[item.Key] / item.Value;
            }
            return result;
        }

        public static Dictionary<int, double> CalcChip2(Dictionary<int, double> oldCost, Dictionary<int, double> newCost, double TurnoverRateT, double A = 1)
        {
            Dictionary<int, double> result = new Dictionary<int, double>(oldCost.Count + newCost.Count);
            var keys = oldCost.Keys;
            var TurnoverRateR = 1 - TurnoverRateT / 100.0 * A;
            foreach (var key in keys) {
                var value = Math.Round(oldCost[key] * TurnoverRateR, 2);
                if (value > 0) {
                    result[key] = value;
                }
            }

            foreach (var key in newCost.Keys) {
                if (result.TryGetValue(key, out double val)) {
                    result[key] = val + newCost[key];
                } else {
                    result[key] = newCost[key];
                }
            }
            return result;
        }



    }
}
