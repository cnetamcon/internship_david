using AM.Stl.Models;

namespace AM.Stl.Protocol
{
    public class ProtocolStlTTI
    {
        public ProtocolStlTTI()
        {
        }

        public byte[] Build(StlSubtitleAModel subtitleMessage, double framerate)
        {
            var result = new byte[128];
            result[0] = 0x00;
            var subNumber = GetSubtitleNumber(subtitleMessage.Id);
            Array.Copy(subNumber, 0, result, 1, 2);
            result[3] = GetExtensionBlockNumber();
            result[4] = GetCumulativeStatus();

            var start = GetTime(subtitleMessage.StartTime, framerate);
            var finish = GetTime(subtitleMessage.FinishTime, framerate);

            Array.Copy(start, 0, result, 5, start.Length);
            Array.Copy(finish, 0, result, 9, finish.Length);

            result[13] = GetVerticalPosition();
            result[14] = GetJustificationCode();
            result[15] = GetCommentFlag();

            var field = GetField(subtitleMessage.Lines);

            if (field.Length + 16 > 128)
            {
                throw new Exception($"Subtitle line too large - {field.Length}. Max length {128 - 16}");
            }
            Array.Copy(field, 0, result, 16, field.Length);
            return result;
        }

        private byte[] GetField(List<StlSubtitleLineAModel> subtitles)
        {
            List<byte> result = new List<byte>();

            for (int i = 0; i < subtitles.Count; i++)
            {
                var message = subtitles[i];

                if (i == 0)
                {
                    result.AddRange(new byte[] { 0x0D, message.Color, 0x0B, 0x0B });
                }
                else
                {
                    result.AddRange(new byte[] { 0x0A, 0x0A, 0x8A, 0x0d, message.Color, 0x0B, 0x0B });
                }

                result.AddRange(message.Text);
            }

            result.AddRange(new byte[] { 0x0A, 0x0A, 0x8A });

            for (int i = result.Count; i < 112; i++)
            {
                result.Add(0x8F);
            }

            return result.ToArray();
        }

        private byte GetCommentFlag()
        {
            return 0x00;
        }

        private byte GetJustificationCode()
        {
            return 0x02;
        }

        private byte GetVerticalPosition()
        {
            return 0x14;
        }

        private byte[] GetTime(TimeSpan timeSpan, double framerate)
        {
            byte[] bytes = new byte[4];
            bytes[0] = (byte)timeSpan.Hours;
            bytes[1] = (byte)timeSpan.Minutes;
            bytes[2] = (byte)timeSpan.Seconds;
            bytes[3] = (byte)(timeSpan.Milliseconds / (1000 / framerate));

            return bytes;

        }

        private byte GetCumulativeStatus()
        {
            return 0x00;
        }

        private byte GetExtensionBlockNumber()
        {
            return 0xFF;
        }

        private byte[] GetSubtitleNumber(short id)
        {
            return BitConverter.GetBytes(id);
        }
    }
}
