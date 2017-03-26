using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace CrossOverApplication.Core.Domain.Entities.Identity
{
    public class ApplicationIdentityResult
    {
        public IEnumerable<IdentityError> Errors
        {
            get;
            private set;
        }

        public bool Succeeded
        {
            get;
            private set;
        }

        public ApplicationIdentityResult(IEnumerable<IdentityError> errors, bool succeeded)
        {
            Errors = errors;
            Succeeded = succeeded;
        }
    }
}
