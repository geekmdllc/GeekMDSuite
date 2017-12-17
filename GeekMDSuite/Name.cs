namespace GeekMDSuite
{
    public class Name
    {
        private Name(string first, string last, string middle = "")
        {
            First = first;
            Middle = middle;
            Last = last;
        }

        public string First { get; }
        public string Middle { get; }
        public string Last { get; }

        public static Name Create(string first, string last, string middle = "") => new Name(first, last, middle);

        public override string ToString()
        {
            return string.Format($"{First} {Last}");
        }
    }
}