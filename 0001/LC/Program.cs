using Core.Managers;
using System;
using System.Diagnostics;

namespace LC
{
    internal class Program
    {
        static int Main(string[] args)
        {
            try
            {
                var str = args.Length > 0 ? args[0] : throw new ArgumentException();
                var stopwatch = new Stopwatch();
                var manager = new SubStringManager();

                stopwatch.Start();
                var result = manager.LongestSubstring(str);
                stopwatch.Stop();

                return (int)stopwatch.ElapsedTicks;
            }
            catch
            {
                return -1;
            }
        }
    }
}
