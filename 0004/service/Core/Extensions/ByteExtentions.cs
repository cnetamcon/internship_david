using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Core.Extensions
{
    public static class ByteExtensions
    {
        public static byte[] ToByteArray(this string bytes)
        {
            if (!string.IsNullOrEmpty(bytes))
            {
                string txt = bytes.ToLower()
                    .Replace("0x", "")
                    .Replace("-", "")
                    .Replace(" ", "")
                    .Replace(",", "");

                txt = txt.Length % 2 != 0 ? "0" + txt : txt;

                byte[] result = new byte[txt.Length / 2];

                for (int i = 0; i < txt.Length - 1; i += 2)
                {
                    var b = txt.Substring(i, 2);
                    result[i / 2] = byte.Parse(b, NumberStyles.HexNumber);
                }
                return result;
            }

            return new byte[0];
        }

        public static byte ToByte(this string b)
        {
            if (string.IsNullOrEmpty(b)) return 0x00;

            try
            {
                var txt = b.ToLower().Replace("0x", "");
                txt = txt.Length % 2 != 0 ? "0" + txt : txt;
                var result = byte.Parse(txt, NumberStyles.HexNumber);

                return result;
            }
            catch
            {
                return 0x00;
            }
        }

        /// <summary>
        /// Search a subarray in an array
        /// </summary>
        /// <returns>Index of the beginning of the found subarray. If subarray was not found return -1 </returns>
        public static int SearchPosition(this byte[] bytes, int startPosition, params byte[] search)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Convert a byte array to UTF8 string
        /// </summary>
        /// <returns>String in UTF8 format</returns>
        public static string ToUTF8(this byte[] bytes)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Convert the byte array to TimeSpan. Each byte is an ASCI character.
        /// </summary>
        /// <returns>TimeSpan value</returns>
        public static TimeSpan ToTimeSpan(this byte[] bytes)
        {
            var str = bytes.ToUTF8().Replace(",", ".");

            return TimeSpan.Parse(str);
        }

        /// <summary>
        /// Convert byte array to Int. Each byte is an ASCI character
        /// </summary>
        /// <returns>Converted int number</returns>
        public static int ToIntFromString(this byte[] bytes)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Replace each byte sequence from dictionary
        /// </summary>
        /// <param name="dictionary">Dictionary </param>
        /// <returns>Byte array where replaced all pairs from dictionary</returns>
        public static byte[] ReplacePairs(this byte[] bytes, Dictionary<byte[], byte[]> dictionary)
        {
            /* For example
             * bytes = A1 B2 C3 D4
             * dictionary = {{"C3","A0"}, {"B2", "11 11"}}
             * result is A1 11 11 A0 D4
            */

            throw new NotImplementedException();
        }

        /// <summary>
        /// Compare each byte in the two arrays
        /// </summary>
        /// <returns>True if each byte in array compare with byte in second array. And False in another case</returns>
        public static bool CompareArray(this byte[] bytes, byte[] compare)
        {
            throw new NotImplementedException();
        }
    }
}
