using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneTurniAgenti.Server.Services
{
    public class UserResolverService : IUserResolverService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly string _notAuthenticatedResponse = "NotAuthenticatedUser";

        public UserResolverService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }

        public string GetRole()
        {
            if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                var claim = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type.Contains("role"));
                return claim.Value;
            }

            return _notAuthenticatedResponse;
        }

        public string GetUsername()
        {
            if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                return _httpContextAccessor.HttpContext.User.Identity.Name;
            }

            return _notAuthenticatedResponse;
        }
    }
}