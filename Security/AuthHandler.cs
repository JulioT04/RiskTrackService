using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using Azure.Core;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Internal;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;
using RiskTrack.Data;

namespace Risktrack.Security {
    public class AuthHandler : AuthenticationHandler<AuthenticationSchemeOptions> {
        private readonly IUserRepo _userRepo;

        public AuthHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory loggerFactory,
        UrlEncoder encoder, Microsoft.AspNetCore.Authentication.ISystemClock clock, IUserRepo userRepo) : base(options, loggerFactory, encoder, clock)
        {
            _userRepo = userRepo;
        }
        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if(!Request.Headers.ContainsKey("Authorization"))
                return AuthenticateResult.Fail("Key is missing");
            
            bool result = false;

            try{
                var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                var creadentialBytes = Convert.FromBase64String(authHeader.Parameter);
                var credentials = Encoding.UTF8.GetString(creadentialBytes).Split(new[] {':'}, 2);
                var email = credentials[0];
                var password = credentials[1];
                result = _userRepo.IsUser(email, password);
            }
            catch{
                return AuthenticateResult.Fail("Something went wrong");
            }

            if(!result)
                return AuthenticateResult.Fail("Invalid User or password");

            var claims = new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, "id"),
                new Claim(ClaimTypes.Name, "user")
            };

            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);
            return AuthenticateResult.Success(ticket);
        }
    }
}   