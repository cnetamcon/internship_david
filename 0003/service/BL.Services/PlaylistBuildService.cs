using BL.Services.Interfaces;
using Models;
using System;
using System.Threading.Tasks;

namespace BL.Services
{
    public class PlaylistBuildService : IPlaylistBuildService
    {
        public async Task Build(string srtPath, string stlPath,
            OverwriteStlFileEnum overwrite, double framerate)
        {
            // Read all bytes from srt file
            // Get name from the stlPath (without extension) it will be used for the playlistName
            // Convert SRT to STL with the ISrtToStlService
            // Store STL to the file

            throw new NotImplementedException();
        }
    }
}
