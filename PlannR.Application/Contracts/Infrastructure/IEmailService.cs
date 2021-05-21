using PlannR.Application.Models.Emailing;
using System.Threading.Tasks;

namespace PlannR.Application.Contracts.Infrastructure
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Email email);
    }
}
