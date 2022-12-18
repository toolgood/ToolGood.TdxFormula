using System.Collections.Generic;
using System.Linq;

namespace ToolGood.TdxFormula
{
    public struct MyDictionary
    {
        private int[] keys;
        private double[] values;
        private double[] probabilitys;

        public MyDictionary(Dictionary<int, double> dict)
        {
            keys = dict.Keys.ToArray();//.OrderBy(k => k).ToArray();
            values = new double[keys.Length];
            probabilitys = new double[0];
            for (int i = 0; i < keys.Length; i++) {
                values[i] = dict[keys[i]];
            }
        }
        public MyDictionary(Dictionary<int, double> dict, double sum)
        {
            keys = dict.Keys.ToArray();//.OrderBy(k => k).ToArray();
            values = new double[keys.Length];
            probabilitys = new double[keys.Length];
            for (int i = 0; i < keys.Length; i++) {
                values[i] = dict[keys[i]];
                probabilitys[i] = values[i] / sum;
            }
        }

        public int[] Keys { get { return keys; } }

        public double GetTop10Proportion(int date)
        {
            if (keys.Length == 0) { return 0; }
            var index = BinarySearch2(keys, date);
            if (index > -1) {
                return values[index];
            }
            return 0;
        }

        public int GetChipN(double top)
        {
            if (keys.Length == 0) { return 0; }
            var index = BinarySearch2(values, top);
            if (index > -1) {
                return keys[index];
            }
            return keys[0];
        }

        public double Winner(int key)
        {
            if (keys.Length == 0) { return 0; }
            var index = BinarySearch2(keys, key);
            if (index > -1) {
                return probabilitys[index];
            }
            return 0.0;
        }
        private int BinarySearch2(int[] arr, int value)
        {
            int low = 1, high = arr.Length - 1;
            if (high == -1) { return -1; }
            if (value > arr[high]) { return high; }
            if (value < arr[0]) { return -1; }

            while (low <= high) {
                var mid = (low + high) / 2;
                if (value == arr[mid]) {
                    return mid;
                } else if (value > arr[mid]) {
                    low = mid + 1;
                } else if (value < arr[mid]) {
                    high = mid - 1;
                }
            }
            return low - 1;
        }
        private int BinarySearch2(double[] arr, double value)
        {
            int low = 1, high = arr.Length - 1;
            if (high == -1) { return -1; }
            if (value > arr[high]) { return high; }
            if (value < arr[0]) { return -1; }

            while (low <= high) {
                var mid = (low + high) / 2;
                if (value == arr[mid]) {
                    return mid;
                } else if (value > arr[mid]) {
                    low = mid + 1;
                } else if (value < arr[mid]) {
                    high = mid - 1;
                }
            }
            return low - 1;
        }






    }

}
