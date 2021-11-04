using System;
using System.Collections.Generic;

namespace DirectId.Domain.Comparer
{
    public class SortDescendingComparer<T> : IComparer<T> where T : IComparable<T>
    {
        public int Compare(T x, T y)
        {
            return y.CompareTo(x);
        }
    }
}
