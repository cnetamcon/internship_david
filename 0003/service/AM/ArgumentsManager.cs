using AM.Interfaces;
using AM.Models;
using Models;
using System;

namespace AM
{
    public class ArgumentsManager : IArgumentsManager
    {
        const string HELP = "-h";
        const string OVERWRITE = "-r";
        const string FRAMERATE = "-fr";

        public ArgumentsModel Parse(string[] args)
        {
            var result = new ArgumentsModel();
            result.OverwriteStl = OverwriteStlFileEnum.NotOverwrite;

            for (var i = 0; i < args.Length; i++)
            {
                var arg = args[i];

                if (arg == HELP)
                {
                    result.HelpFlag = true;
                    break;
                }
                else if (arg == OVERWRITE)
                {
                    result.OverwriteStl = OverwriteStlFileEnum.Overwrite;
                    /*if (i + 1 == args.Length)
                        throw new ArgumentException($"Incorrect value for parameter '{OVERWRITE}'");

                    if (byte.TryParse(args[++i], out byte value))
                    {
                        if (Enum.IsDefined(typeof(OverwriteStlFileEnum), value))
                        {
                            result.OverwriteStl = (OverwriteStlFileEnum)value;
                        }
                        else
                        {
                            throw new ArgumentException($"Incorrect value for parameter '{OVERWRITE}'");
                        }
                    }
                    else
                    {
                        throw new ArgumentException($"Incorrect value for parameter '{OVERWRITE}'");
                    }*/

                }
                else if (arg == FRAMERATE)
                {
                    if (i + 1 == args.Length)
                        throw new ArgumentException($"Incorrect value for parameter '{FRAMERATE}'");

                    if (double.TryParse(args[++i], out double value))
                    {
                        result.Framerate = value;
                    }
                    else
                    {
                        throw new ArgumentException($"Incorrect value for parameter '{FRAMERATE}'");
                    }

                }
                else if (string.IsNullOrEmpty(result.PathSrt))
                {
                    result.PathSrt = args[i];
                }
                else if (string.IsNullOrEmpty(result.PathStl))
                {
                    result.PathStl = args[i];
                }
            }

            return result;
        }
    }
}
