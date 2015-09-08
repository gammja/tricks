using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tricks
{
    public class Product
    {
        public int Popularuty { get; set; }
        public int Price { get; set; }
        public string Name { get; set; }
    }

    public static class PartialComparer
    {
        public  static int? Compare<T>(T first, T second)
        {
            return Compare(Comparer<T>.Default, first, second);
        }

        private static int? Compare<T>(Comparer<T> comparer, T first, T second)
        {
            int ret = comparer.Compare(first, second);
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

    public static class ParseHelper
    {
        public static int? TryParse(string data)
        {
            int ret;
            return int.TryParse(data, out ret) ? ret : new int?();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string firstName = null;
            string middleName = "TTT";
            string lastName = "AAA";

            var ret = ParseHelper.TryParse(firstName) ??
                      ParseHelper.TryParse(middleName) ??
                      ParseHelper.TryParse(lastName);
        }

        // without
        public int OldCompare(Product first, Product second)
        {
            int ret = second.Popularuty.CompareTo(first.Popularuty);
            if (ret != 0) return ret;

            ret = first.Price.CompareTo(second.Price);
            if (ret != 0) return ret;

            return first.Name.CompareTo(second.Name);
        }

        public int Compare(Product first, Product second)
        {
            return PartialComparer.ReferenceCompare(first, second) ??
                PartialComparer.Compare(second.Popularuty, second.Popularuty) ??
                PartialComparer.Compare(first.Price, second.Price) ??
                PartialComparer.Compare(first.Name, second.Name) ??
                0;
        }
    }
}
