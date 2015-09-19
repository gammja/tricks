using System.Collections.Generic;

namespace tricks
{
    public static class PartialComparer
    {
        public  static int? Compare<T>(T first, T second)
        {
            return Compare(Comparer<T>.Default, first, second);
        }

        private static int? Compare<T>(Comparer<T> comparer, T first, T second)
        {
            var ret = comparer.Compare(first, second);
            return ret == 0 ? new int?() : ret;
        }

        public static int? ReferenceCompare<T>(T first, T second) where T : class
        {
            return first == second ? 0
                 : first == null ? -1
                 : second == null ? 1
                 : new int?();
        }

        public static bool? ReferenceEquals<T>(T first, T second) where T : class
        {
            return first == second ? true
                 : first == null ? false
                 : second == null ? false
                 : new bool?();
        }
    }
}