using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace GeekMDSuite.Analytics.Helpers
{
    internal static class Reflection
    {
        public static string GetAssetFromExecutingAssembly(string fileName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var names = assembly.GetManifestResourceNames();
            var resourceStream = assembly.GetManifestResourceStream(names.First( n => n.Contains(fileName)));
            return new StreamReader(resourceStream, Encoding.UTF8).ReadToEnd();}
    }
}