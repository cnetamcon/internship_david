using AM.Srt.Interfaces;
using AM.Srt.Models;
using AM.Stl.Interfaces;
using AM.Stl.Models;
using BL.Services.Interfaces;
using Core.Interfaces.Mapping;
using Core.Settings.Interfaces;
using System.Collections.Generic;

namespace BL.Services
{
    public class SrtToStlService : ISrtToStlService
    {
        public byte[] Convert(byte[] srtPlaylist, string playlistName, double framerate)
        {
            // Get all managers and DataMapper from constructor
            // Parse the SRT models
            // Build an STL playlist and return

            throw new System.NotImplementedException();
        }
    }
}
