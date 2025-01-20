using System.Text;
using System.Text.Unicode;

namespace AM.Stl.Models
{
    public class StlSubtitlePlaylistAModel
    {
        public string Title { get; set; } //string.IsNullOrEmpty(filename)? $"{id}_{DateTime.UtcNow.ToString("yyMMddHHmmss")}": filename;
        public int TtiCount { get => Subtitles.Count; } // total subtitles count
        public int TotalRowsCount { get => Subtitles.Sum(x => x.Lines.Count); } // total rows count
        public double Framerate { get; set; }

        public List<StlSubtitleAModel> Subtitles { get; set; }

        public TimeSpan GetFirstStart()
        {
            var result = Subtitles.Min(x => x.StartTime);

            return result;
        }
    }

    public class StlSubtitleAModel
    {
        public short Id { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan FinishTime { get; set; }

        public List<StlSubtitleLineAModel> Lines { get; set; }

    }

    public class StlSubtitleLineAModel
    {
        public byte Color { get; set; }
        public byte Number { get; set; }
        public byte[] Text { get; set; }
    }
}
