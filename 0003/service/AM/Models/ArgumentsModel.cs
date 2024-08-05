using Models;

namespace AM.Models
{
    public class ArgumentsModel
    {
        public bool HelpFlag { get; set; }
        public OverwriteStlFileEnum? OverwriteStl { get; set; }
        public double? Framerate { get; set; }
        public string PathSrt { get; set; }
        public string PathStl { get; set; }
    }
}
