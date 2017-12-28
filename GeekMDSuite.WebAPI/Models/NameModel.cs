using System;

namespace GeekMDSuite.WebAPI.Models
{
    public class NameModel : IName 
    {
        public string First { get; set; }
        public string Middle { get; set; }
        public string Last { get; set; }

        public NameModel(IName name)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));
            First = name.First;
            Middle = name.Middle;
            Last = name.Last;
        }

        public NameModel()
        {
            
        }

        public override string ToString() => $"{First} {(string.IsNullOrEmpty(Middle) ? "" : Middle + " ")} {Last}";
    }
}