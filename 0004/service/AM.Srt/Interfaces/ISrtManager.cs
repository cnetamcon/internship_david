using AM.Srt.Models;

namespace AM.Srt.Interfaces
{
    public interface ISrtManager
    {
        List<SrtSubtitlesAModel> Read(byte[] bytes);
    }
}
