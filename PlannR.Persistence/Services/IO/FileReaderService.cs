using Newtonsoft.Json;
using PlannR.Application.Contracts.Persistence.Seed;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace PlannR.Persistence.Services.IO
{
    public class FileReaderService : IFileReaderService
    {
        private readonly string _folderPath;

        public FileReaderService()
        {
            _folderPath = AppDomain.CurrentDomain.BaseDirectory;
        }
        public async Task<IEnumerable<T>> GetJsonData<T>(string file)
        {
            var result = await File.ReadAllTextAsync($@"{_folderPath}{file}");
            return JsonConvert.DeserializeObject<IEnumerable<T>>(result);
        }
    }
}
