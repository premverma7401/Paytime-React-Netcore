using System.Security.Claims;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Paytime.Application.Interfaces;

namespace Infrastructure.Security
{
    public class UserAccessor : IUserAccessor
    {
        private readonly IHttpContextAccessor _http;
        public UserAccessor(IHttpContextAccessor http)
        {
            _http = http;
            UserId = _http.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public string UserId { get; }

        public string GetCurrentUser()
        {
            var username = _http.HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            return username;
        }
    }
}