using AM.Stl.Interfaces;
using AM.Stl.Models;
using AM.Stl.Protocol;

namespace AM.Stl
{
    public class StlManager : IStlManager
    {
        private ProtocolSTLGSI _headerBuilder;
        private ProtocolStlTTI _bodyBuilder;

        public StlManager()
        {
            _headerBuilder = new ProtocolSTLGSI();
            _bodyBuilder = new ProtocolStlTTI();
        }

        public byte[] Build(StlSubtitlePlaylistAModel playlist)
        {
            List<byte> bytes = new List<byte>();

            var temp = _headerBuilder.Build(playlist.Title,
              playlist.TtiCount,
              playlist.TotalRowsCount, 1, 50, 23,
              new TimeSpan(0, 0, 0),
              playlist.GetFirstStart());

            bytes.AddRange(temp);
            foreach (var subtitle in playlist.Subtitles)
            {
                bytes.AddRange(_bodyBuilder.Build(subtitle, playlist.Framerate));
            }

            return bytes.ToArray();
        }
    }
}