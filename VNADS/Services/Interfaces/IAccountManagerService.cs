using System.Threading.Tasks;
using Data.Entities;

namespace Services.Interfaces
{
    public interface IAccountManagerService
    {
        Task<(bool, UserProfile)> ValidateUserCredentialsAsync(string username, string password);
    }
}
