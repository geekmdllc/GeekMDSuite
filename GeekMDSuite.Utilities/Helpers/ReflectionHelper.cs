using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace GeekMDSuite.Utilities.Helpers
{
    public static class ReflectionHelper
    {
        public static string LoadFileFromCallingAssembly(string fileName)
        {
            var callingAssembly = Assembly.GetCallingAssembly();
            var names = callingAssembly.GetManifestResourceNames();
            var resourceStream = callingAssembly.GetManifestResourceStream(names.First(n => n.Contains(fileName)));
            return new StreamReader(resourceStream, Encoding.UTF8).ReadToEnd();
        }
    }
}