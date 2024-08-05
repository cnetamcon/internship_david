using Models;
using System.Threading.Tasks;

namespace BL.Services.Interfaces
{
    public interface IPlaylistBuildService
    {
        Task Build(string srtPath, string stlPath,
            OverwriteStlFileEnum overwrite, double framerate);
    }
}
