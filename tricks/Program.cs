namespace tricks
{
    public class Product
    {
        public int Popularuty { get; set; }
        public int Price { get; set; }
        public string Name { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
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
