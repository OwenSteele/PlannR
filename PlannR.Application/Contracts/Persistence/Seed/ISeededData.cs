using System.Threading.Tasks;

namespace PlannR.Application.Contracts.Persistence.Seed
{
    public interface ISeededData<T> where T : class
    {
        Task<T> GetJsonData(string folderPath);
    }
}
