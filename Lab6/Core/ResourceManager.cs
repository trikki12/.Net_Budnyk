using System;
using System.IO;

namespace Core
{
    public class ResourceManager : IDisposable
    {
        private StreamWriter writer;
        private bool disposed = false;

        public ResourceManager(string filePath)
        {
            writer = new StreamWriter(filePath, true);
        }

        public void WriteLog(string message)
        {
            writer.WriteLine($"{DateTime.Now}: {message}");
        }

        public void Dispose()
        {
            if (!disposed)
            {
                writer.Close();
                writer.Dispose();
                disposed = true;
            }
        }
    }
}