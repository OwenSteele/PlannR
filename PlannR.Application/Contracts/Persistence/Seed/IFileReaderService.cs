using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlannR.Application.Contracts.Persistence.Seed
{
    public interface IFileReaderService
    {
        Task<IEnumerable<T>> GetJsonData<T>(string fileName);
    }
}
