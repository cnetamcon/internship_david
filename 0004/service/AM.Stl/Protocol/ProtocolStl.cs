using System.Text;

namespace AM.Stl.Protocol
{
    public class ProtocolStl
    {
        private Encoding encoding = Encoding.UTF8;

        public byte[] GetCodePageNumber(CodePage codePage)
        {
            switch (codePage)
            {
                case CodePage.UnitedStages: return new byte[] { 0x34, 0x33, 0x37 };
                case CodePage.Multilingual: return new byte[] { 0x38, 0x35, 0x30 };
                case CodePage.Portugal: return new byte[] { 0x38, 0x36, 0x30 };
                case CodePage.CanadaFrench: return new byte[] { 0x38, 0x36, 0x33 };
                case CodePage.Nordic: return new byte[] { 0x38, 0x36, 0x35 };

                default: return new byte[] { 0x38, 0x35, 0x30 };
            }
        }

        public byte[] GetDiskFormatCode(int code = 25)
        {
            switch (code)
            {
                case 30: return encoding.GetBytes("STL30.01");
                case 25:
                default: return encoding.GetBytes("STL25.01");
            }
        }

        public byte[] GetTranslated(string value, int length = 32)
        {
            string str;
            if (value.Length > length)
            {
                str = value.Substring(0, length);
            }
            else
            {
                str = value.PadRight(length, ' ');
            }
            var bytes = encoding.GetBytes(str);
            return bytes;
        }

        public byte[] GetLanguageCode(string value)
        {
            var temp = encoding.GetBytes(value);
            return temp;
        }

        public byte GetDisplayStandartCode(int code = 1)
        {
            switch (code)
            {
                case 2: return 0x32;
                case 1: return 0x31;
                case 0: return 0x30;
                case -1:
                default: return 0x20;
            }
        }

        public byte[] GetCharacterCodeTable(CharacterCodeTable characterCodeTable)
        {
            switch (characterCodeTable)
            {
                case CharacterCodeTable.LatinCyrillic: return new byte[] { 0x30, 0x31 };
                case CharacterCodeTable.LatinArabic: return new byte[] { 0x30, 0x32 };
                case CharacterCodeTable.LatinGreek: return new byte[] { 0x30, 0x33 };
                case CharacterCodeTable.LatinHebrew: return new byte[] { 0x30, 0x34 };

                case CharacterCodeTable.Latin:
                default: return new byte[] { 0x30, 0x30 };
            }
        }

        public byte[] GetTotalNumber(int totalNumberOfText)
        {
            var str = totalNumberOfText.ToString("00000");
            var result = encoding.GetBytes(str);
            return result;
        }
        public byte[] GetTotalNumberOfGroups(int value)
        {
            var str = value.ToString("000");
            var result = encoding.GetBytes(str);
            return result;
        }
        public byte[] GetMaximumNumberOfDisplay(int value)
        {
            var str = value.ToString("00");
            var result = encoding.GetBytes(str);
            return result;
        }

        public byte[] GetRevisionNumber(int v)
        {
            return new byte[] { 0x20, 0x20 };
        }

        public byte[] GetDate()
        {
            var date = DateTime.UtcNow.ToString("yyMMdd");
            return encoding.GetBytes(date);
        }

        public byte GetTimeCodeStatus(int code)
        {
            switch (code)
            {

                case 1: return 0x31;
                case 2: return 0x32;
                case 3: return 0x33;
                case 4: return 0x34;
                case 5: return 0x35;
                case 6: return 0x36;
                case 7: return 0x37;
                case 8: return 0x38;
                case 9: return 0x39;
                case 0:
                default: return 0x30;
            }
        }
        public byte[] GetStartTime(TimeSpan time)
        {
            var temp = time.ToString(@"hhmmss") + "00";
            return encoding.GetBytes(temp);
        }
        public byte[] GetStartTime(TimeSpan? time)
        {
            if (time == null)
                time = new TimeSpan(0, 0, 0);
            var temp = time.Value.ToString(@"hhmmss") + "00";
            return encoding.GetBytes(temp);
        }
    }

    public enum CharacterCodeTable
    {
        Latin = 0,
        LatinCyrillic = 1,
        LatinArabic = 2,
        LatinGreek = 3,
        LatinHebrew = 4
    }

    public enum CodePage
    {
        UnitedStages = 437,
        Multilingual = 850,
        Portugal = 860,
        CanadaFrench = 864,
        Nordic = 865
    }
}
