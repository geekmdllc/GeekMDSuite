namespace GeekMDSuite
{
    public class Name
    {
        internal Name(string first, string last, string middle = "")
        {
            First = first;
            Middle = middle;
            Last = last;
        }

        public string First { get; }
        public string Middle { get; }
        public string Last { get; }

        public static Name Create(string first, string last, string middle = "") => new Name(first, last, middle);
    }
}