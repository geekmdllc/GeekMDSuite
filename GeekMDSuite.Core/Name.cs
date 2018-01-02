namespace GeekMDSuite.Core
{
    public class Name : IName
    {
        public Name()
        {
            
        }
        private Name(string first, string last, string middle = "")
        {
            First = first;
            Middle = middle;
            Last = last;
        }

        public string First { get; set; }
        public string Middle { get; set; }
        public string Last { get; set; }

        public static Name Build(string first, string last, string middle = "") => new Name(first, last, middle);

        public override string ToString() => string.Format($"{First}{(string.IsNullOrEmpty(Middle) ? "" : $" {Middle}")} {Last}");
    }
}