using System.Linq;

namespace AES.Core.Tools
{
    public static class StringTools
    {
        public static string OnlyNumbers(this string str, string input)
        {
            return new string(input.Where(char.IsDigit).ToArray());
        }
    }
}
