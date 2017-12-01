namespace GeekMDSuite
{
    public class Name
    {
        public Name(string first, string middle, string last)
        {
            First = first;
            Middle = middle;
            Last = last;
        }

        public string First { get; }
        public string Middle { get; }
        public string Last { get; }
    }
}