namespace tricks.Tests
{
    public class Product
    {
        public int Popularuty { get; set; }
        public int Price { get; set; }
        public string Name { get; set; }

        protected bool Equals(Product other)
        {
            return Popularuty == other.Popularuty && Price == other.Price && string.Equals(Name, other.Name);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Product) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Popularuty;
                hashCode = (hashCode*397) ^ Price;
                hashCode = (hashCode*397) ^ (Name != null ? Name.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}