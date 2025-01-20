namespace AM.Srt.Models
{
    internal static class SrtConstants
    {
        /// <summary>
        /// Symbol \r 
        /// </summary>
        public const byte CR = 0X0D;

        /// <summary>
        ///  Symbol \n
        /// </summary>
        public const byte LF = 0X0A;

        /// <summary>
        /// Symbol '<'
        /// </summary>
        public const byte TAG_OPEN = 0x3C;

        /// <summary>
        /// Symbol '>'
        /// </summary>
        public const byte TAG_CLOSE = 0x3E;

        /// <summary>
        /// Symbol ' ' 
        /// </summary>
        public const byte SPACE = 0x20;

        /// <summary>
        /// Symbol '/' 
        /// </summary>
        public const byte SLASH = 0x2F;

        /// <summary>
        /// Symbols '-->'
        /// </summary>
        public static byte[] TIME_DELIMITER = new byte[] { 0x2D, 0x2D, 0x3E };

        /// <summary>
        /// Symbold '\r\b'
        /// </summary>
        public static byte[] LINE_DELIMITER = new byte[] { CR, LF };
    }
}
