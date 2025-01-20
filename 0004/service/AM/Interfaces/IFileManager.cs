using Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AM.Interfaces
{
    public interface IFileManager
    {
        Task<IEnumerable<string>> GetFiles(string path);
        Task<IEnumerable<string>> GetDirectories(string path);
        Task RemoveFile(string path);
        Task RemoveDirectory(string path);
        Task<DateTime> GetFileCreationTime(string path);
        Task<byte[]> Read(string fullPath);
        Task Save(string fullPath, byte[] bytes, OverwriteStlFileEnum mode);
    }
}
