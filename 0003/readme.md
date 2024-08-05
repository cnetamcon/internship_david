# 1. Main goal of the project

Console application for converting a subtitle file from the .srt format to the .stl format and then saving STL to a file.

# 2. Implementation details

## 2.1 Command line arguments

At startup, the program can take several command line arguments.

* Main arguments
     * Path to the srt file - Full path to an SRT file. Set before specifying the path to save the stl file
     * Path to save the stl file - Full path where STL file will be saved. Set after specifying the path to the srt file

* Additional arguments
     * -r (optional) - Specifies to overwrite the file if a file with the same name arready exists
     * -fr (optional) - Framerate to convert milliseconds to frames
     * -h (optional) - Ignores all entered arguments and prints help text to the console to help the user

Arguments can be combined in any order, but the path to the srt file must be specified before the path to the stl file.

Examples:

     - tostl c:\srt_files\file1.srt c:\stl_files\file1.stl -r -fr 25
     - tostl c:\srt_files\file1.srt c:\stl_files\file1.stl -fr 25 -r
     - tostl -r -fr 25 c:\srt_files\file1.srt c:\stl_files\file1.stl
     - tostl c:\srt_files\file1.srt -r -fr 25 c:\stl_files\file1.stl
     - tostl ../../stt_files/file1.srt -r -fr 25 ../../stl_files/file1.stl
     - tostl stt_files/file1.srt -r -fr 25 stl_files/file1.st

## 2.2 Application settings

The application has the following settings files for configuring the application

* ApplicationSettings with parameters
     * framerate - Used if the 'fr' parameter is not given via command line arguments (allowed values: 25, 32, 35.8, 52.6 etc.)
     * overwrite_stl_file - Used if '-r' option is not given via command line arguments (allowed values: 0 - show error if file with the same name already exists. 1 - Overwrite file)

* SrtEncodingTable sith parameters:
     * pairs - Array of values to convert one character to another
         * from - The character to be replaced
         * to - The character to replace the 'from' character with

## 2.3 Parse an SRT file

ISrtManager, located in the AM.Srt class library project, takes as input an array of bytes, which is a srt file. At the output, we get a model that contains a collection of subtitles and each subtitle contains:

* Id : number
* Start : TimeSpan
* Finish : TimeSpan
* Lines[] : SubtitleSrtLine[]
     * Color : string
     * Text : byte[]

## 2.4 Build STL file