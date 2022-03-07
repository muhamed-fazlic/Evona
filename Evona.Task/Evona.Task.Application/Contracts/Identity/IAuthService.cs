using Evona.Task.Application.Models.Identity;
using System.Threading.Tasks;

namespace Evona.Task.Application.Contracts.Identity
{
    public interface IAuthService
    {
        Task<AuthResponse> Login(AuthRequest request);
        Task<RegistrationResponse> Register(RegistrationRequest request);
    }
}
