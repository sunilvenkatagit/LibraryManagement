using LibraryManagement.Application.Contracts.Identity;
using LibraryManagement.Application.Models.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LibraryManagement.Api.Controllers
{
    [Route("api/accounts")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AccountsController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("authenticate")]
        public async Task<ActionResult<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest authenticationRequest)
        {
            return Ok(await _authenticationService.AuthenticateAsync(authenticationRequest));
        }

        [HttpPost("register")]
        public async Task<ActionResult<RegistrationResponse>> AuthenticateAsync(RegistrationRequest registrationRequest)
        {
            return Ok(await _authenticationService.RegisterAysnc(registrationRequest));
        }
    }
}
