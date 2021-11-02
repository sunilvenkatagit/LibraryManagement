using LibraryManagement.Application.Models.Authentication;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Contracts.Identity
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request);
        Task<RegistrationResponse> RegisterAysnc(RegistrationRequest request);
    }
}
