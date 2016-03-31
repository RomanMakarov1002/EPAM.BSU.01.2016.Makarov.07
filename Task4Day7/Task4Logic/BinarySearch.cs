using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4Logic
{
    public static class BinarySearch
    {

        public static int Search<T>(T[] array, T value, Comparison<T> comparison)
        {            
            return Find(array, value, 0, array.Length - 1, comparison);
        }

        public static int Search<T>(T[] array, T value, IComparer<T> comparer)
        {
            return Find(array, value, 0, array.Length - 1, comparer.Compare);
        }

        private static int Find<T>(T[] array, T value, int left, int right, Comparison<T> comparison)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));
            if (value == null)
                throw new ArgumentNullException(nameof(value));
            if (right<0)
                throw new ArgumentException("Array is empty");
            
            if (comparison(value, array[left]) < 0)
                return -1;
            if (comparison(value, array[right]) > 0)
                return -1;
                
            int res= -1;
            int mid;
            while (left <= right)
            {
                mid = left + (right - left) / 2;
                int cmp = comparison(value, array[mid]);
                if (cmp == 0)
                {            
                    return mid;       
                }
                if (cmp < 0)
                    right = mid;
                if (cmp > 0)
                    left = mid+1;
                if (left == right && comparison(value, array[left]) != 0)
                    return -1;
            }
            return res;
        }      
    }
}
