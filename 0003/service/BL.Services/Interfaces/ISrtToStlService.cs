namespace BL.Services.Interfaces
{
    public interface ISrtToStlService
    {
        byte[] Convert(byte[] srtPlaylist, string playlistName, double framerate);
    }
}
