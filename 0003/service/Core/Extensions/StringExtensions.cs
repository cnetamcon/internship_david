using System;
using System.Text;

namespace Core.Extensions
{
    public static class StringExtensions
    {
        public static string CharToString(this char[] arr)
        {
            if (arr == null) return "";

            StringBuilder sb = new StringBuilder();
            foreach (var c in arr)
            {
                sb.Append(c);
            }
            return sb.ToString();
        }

        public static string Print(this byte[] bytes)
        {
            return BitConverter.ToString(bytes, 0, bytes.Length);
        }
    }
}
