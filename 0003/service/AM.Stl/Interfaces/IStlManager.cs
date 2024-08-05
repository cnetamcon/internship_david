using AM.Stl.Models;

namespace AM.Stl.Interfaces
{
    public interface IStlManager
    {
        byte[] Build(StlSubtitlePlaylistAModel playlist);
    }
}
