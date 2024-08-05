using AM.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace AM
{
    public class WindowsFileManager : IFileManager
    {
        public Task<IEnumerable<string>> GetDirectories(string path)
        {
            IEnumerable<string> result = Directory.GetDirectories(path);

            return Task.FromResult(result);
        }

        public Task<DateTime> GetFileCreationTime(string path)
        {
            return Task.FromResult(File.GetCreationTimeUtc(path));
        }

        public Task<IEnumerable<string>> GetFiles(string path)
        {
            IEnumerable<string> result = Directory.GetFiles(path);

            return Task.FromResult(result);
        }

        public Task RemoveDirectory(string path)
        {
            Directory.Delete(path, true);

            return Task.CompletedTask;
        }

        public Task RemoveFile(string path)
        {
            File.Delete(path);

            return Task.CompletedTask;
        }

        public async Task<byte[]> Read(string fullPath)
        {
            if (!File.Exists(fullPath))
            {
                throw new ArgumentException($"File '{fullPath}' is not found");
            }

            var bytes = await File.ReadAllBytesAsync(fullPath);
            return bytes;
        }

        public async Task Save(string fullPath, byte[] bytes, OverwriteStlFileEnum mode)
        {
            if (File.Exists(fullPath) && mode == OverwriteStlFileEnum.NotOverwrite)
            {
                throw new ArgumentException($"File '{fullPath}' already exist");
            }
            await File.WriteAllBytesAsync(fullPath, bytes);
        }
    }
}
