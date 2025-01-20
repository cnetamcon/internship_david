using AM.Srt.Interfaces;
using AM.Srt.Models;
using Core.Logs;

namespace AM.Srt
{
    public class SrtManager : ISrtManager
    {
        public List<SrtSubtitlesAModel> Read(byte[] bytes)
        {
            Log.UI.Message($"Analysis of SRT file. Length {bytes.Length} b");
            // todo: Parse received bytes to List of SrtSubtitlesAModel
            // Restrictions
            // Search for the desired positions only in the array of bytes without converting to a string
            // To convert to int, TimeSpan and color use extension methods

            throw new NotImplementedException();
        }
    }
}