using AM.Interfaces;
using AM.Models;
using BL.Observers.Interfaces;
using BL.Services.Interfaces;
using Core.Logs;
using Core.Settings.Interfaces;
using Models;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Host
{
    public class Application
    {
        private readonly IObserversPool _observers;
        private readonly IArgumentsManager _argumentManager;
        private readonly IPlaylistBuildService _playlistBuildService;
        private readonly IAppSettingsManager _appSettingsManager;
        private readonly string[] _args;

        public Application(IObserversPool observersPool,
            IPlaylistBuildService playlistBuildService,
            IAppSettingsManager appSettingsManager,
            IArgumentsManager argumentManager)
        {
            _playlistBuildService = playlistBuildService;
            _argumentManager = argumentManager;
            _appSettingsManager = appSettingsManager;
            _observers = observersPool;
            _args = Environment.GetCommandLineArgs();
        }

        public async Task Start()
        {
            try
            {
                Log.Main.Success("Application start");
                Log.Main.Success($"Arguments: \r\n {string.Join("\r\n", _args)}");


                var arguments = GetArguments();

                if (arguments.HelpFlag)
                {
                    Log.UI.Success($"\r\nWelcome to the SRT to STL conversion program\r\n");
                    Log.UI.Message(@"Options:
* Main arguments. The two main parameters are the path to SRT and the path to STL files
     * Path to the srt file - Path to an SRT file. Set before specifying the path to save the stl file
     * Path to save the stl file - Path where STL file will be saved. Set after specifying the path to the srt file

* Additional arguments
     * -r (optional) - Specifies to overwrite the file if a file with the same name arready exists
     * -fr (optional) - Framerate to convert milliseconds to frames
     * -h (optional) - Ignores all entered arguments and prints help text");
                    Log.UI.Message(@"
Examples:
     tostl c:\srt_files\file1.srt c:\stl_files\file1.stl -r -fr 25
     tostl c:\srt_files\file1.srt c:\stl_files\file1.stl -fr 25 -r
     tostl -r -fr 25 c:\srt_files\file1.srt c:\stl_files\file1.stl
     tostl c:\srt_files\file1.srt -r -fr 25 c:\stl_files\file1.stl
     tostl ../../stt_files/file1.srt -r -fr 25 ../../stl_files/file1.stl
     tostl stt_files/file1.srt -r -fr 25 stl_files/file1.st\r\n");
                }
                else
                {
                    Log.UI.Message($"------------------------------------------------------");
                    Log.UI.Message($"Start SRT to STL conversion...");
                    Log.UI.Message($"------------------------------------------------------");
                    Log.UI.Message($"SRT source: '{arguments.PathSrt}'");
                    Log.UI.Message($"STL destination: '{arguments.PathStl}'");
                    Log.UI.Message($"Framerate: {arguments.Framerate}");
                    Log.UI.Message($"Overwriting STL file mode: {arguments.OverwriteStl}");
                    Log.UI.Message($"------------------------------------------------------");

                    var _stopwatch = new Stopwatch();
                    _stopwatch.Start();

                    await _playlistBuildService.Build(
                        arguments.PathSrt,
                        arguments.PathStl,
                        arguments.OverwriteStl.Value,
                        arguments.Framerate.Value);

                    _stopwatch.Stop();
                    Log.UI.Message($"Total time spent: {_stopwatch.Elapsed}");
                }
            }
            catch (Exception er)
            {
                Log.Current.Error(er);
                Log.UI.Error(er.Message);
            }
        }

        public async Task Stop()
        {
            try
            {
                Log.Main.Success("Application stop");
            }
            catch (Exception er)
            {
                Log.Current.Error(er);
            }
        }

        ~Application()
        {
            Log.Main.Success("Application stopped");
        }

        private ArgumentsModel GetArguments()
        {
            var arguments = _argumentManager.Parse(_args.Skip(1)
               .Take(_args.Length - 1)
               .ToArray());

            if (arguments.HelpFlag) return arguments;

            var settings = _appSettingsManager.Get();
            if (arguments.Framerate == null)
            {
                arguments.Framerate = settings.Framerate;
            }
            if (arguments.OverwriteStl == null)
            {
                arguments.OverwriteStl = Models.OverwriteStlFileEnum.NotOverwrite;
            }
            if (string.IsNullOrEmpty(arguments.PathSrt))
            {
                throw new ArgumentException("SRT path should be specified");
            }
            if (string.IsNullOrEmpty(arguments.PathStl))
            {
                throw new ArgumentException("STL path should be specified");
            }

            return arguments;
        }
    }
}
