using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannR.Persistence.Helpers
{
    public static class SeedHelper
    {
        public static List<TEntity> SeedData<TEntity>(string fileName)
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var fullPath = Path.Combine(currentDirectory, "Seed/Data", fileName);

            var result = new List<TEntity>();
            using (var reader = new StreamReader(fullPath))
            {
                var json = reader.ReadToEnd();
                result = JsonConvert.DeserializeObject<List<TEntity>>(json);
            }

            return result;
        }
    }
}
