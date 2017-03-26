using CrossOverApplication.Core.Domain.Entities.Identity;
using Microsoft.AspNetCore.Authentication;
using System.Collections.Generic;
using System.Security.Claims;

namespace CrossOverApplication.Core.Domain.Entities.Identity
{
    public class ApplicationExternalLoginInfo
    {

        public string LoginProvider { get; set; }

        public string ProviderKey { get; set; }

        public string DisplayName { get; set; }

        public ClaimsPrincipal Principal { get; set; }

        public IEnumerable<AuthenticationToken> AuthenticationTokens { get; set; }
    }
}
