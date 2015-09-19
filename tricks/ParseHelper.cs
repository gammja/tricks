namespace tricks
{
    public static class ParseHelper
    {
        public static int? TryParse(string data)
        {
            int ret;
            return int.TryParse(data, out ret) ? ret : new int?();
        }
    }
}