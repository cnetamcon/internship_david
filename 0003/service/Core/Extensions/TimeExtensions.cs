namespace Core.Extensions
{
    public static class TimeExtensions
    {
        public static int GetFramesFromMilliseconds(this int ms, double framerate)
        {
            var msf = 1000 / framerate;
            return (int)(ms / msf);
        }
        public static int GetFramesFromMilliseconds(this double ms, double framerate)
        {
            var msf = 1000 / framerate;
            return (int)(ms / msf);
        }
    }
}
