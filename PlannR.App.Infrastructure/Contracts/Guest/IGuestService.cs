using System.Threading.Tasks;

namespace PlannR.App.Contracts.Guest
{
    public interface IGuestService
    {
        Task SetGuestLoginAsync();
        void SetGuestLogoutAsync();
    }
}