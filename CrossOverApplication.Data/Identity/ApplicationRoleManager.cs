using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrossOverApplication.Data.Models.Identity;
using CrossOverApplication.Core.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using CrossOverApplication.Data.Extensions;
using CrossOverApplication.Core.Identity;
using Microsoft.EntityFrameworkCore;

namespace CrossOverApplication.Data.Identity
{
    // Configure the RoleManager used in the application. RoleManager is defined in the ASP.NET Identity core assembly
    public class ApplicationRoleManager : IApplicationRoleManager
    {
        private readonly RoleManager<ApplicationIdentityRole> _roleManager;
        private bool _disposed;

        public ApplicationRoleManager(RoleManager<ApplicationIdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public virtual async Task<ApplicationIdentityResult> CreateAsync(ApplicationRole role)
        {
            var identityRole = role.ToIdentityRole();
            var identityResult = await _roleManager.CreateAsync(identityRole).ConfigureAwait(false);
            role.CopyIdentityRoleProperties(identityRole);
            return identityResult.ToApplicationIdentityResult();
        }

        public virtual async Task<ApplicationIdentityResult> DeleteAsync(string roleId)
        {
            var identityRole = await _roleManager.FindByIdAsync(roleId);
            if (identityRole == null)
            {
                return new ApplicationIdentityResult(new IdentityError[] { new IdentityError() { Code = "", Description = "Invalid Role Id" } }, false);
            }
            var identityResult = await _roleManager.DeleteAsync(identityRole).ConfigureAwait(false);
            return identityResult.ToApplicationIdentityResult();
        }

        public virtual async Task<ApplicationRole> FindByIdAsync(string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId).ConfigureAwait(false);
            return role.ToApplicationRole();
        }

        public virtual async Task<ApplicationRole> FindByNameAsync(string roleName)
        {
            var role = await _roleManager.FindByNameAsync(roleName).ConfigureAwait(false);
            return role.ToApplicationRole();
        }

        public virtual IEnumerable<ApplicationRole> GetRoles()
        {
            return _roleManager.Roles.ToList().ToApplicationRoleList();
        }

        public virtual async Task<IEnumerable<ApplicationRole>> GetRolesAsync()
        {
            var applicationRoles = await _roleManager.Roles.ToListAsync().ConfigureAwait(false);
            return applicationRoles.ToApplicationRoleList();
        }

        public virtual async Task<bool> RoleExistsAsync(string roleName)
        {
            return await _roleManager.RoleExistsAsync(roleName).ConfigureAwait(false);
        }

        public virtual async Task<ApplicationIdentityResult> UpdateAsync(string roleId, string roleName)
        {
            var identityRole = await _roleManager.FindByIdAsync(roleId);
            if (identityRole == null)
            {
                return new ApplicationIdentityResult(new IdentityError[] { new IdentityError() { Code = "", Description = "Invalid Role Id" } }, false);
            }
            identityRole.Name = roleName;
            var identityResult = await _roleManager.UpdateAsync(identityRole).ConfigureAwait(false);
            return identityResult.ToApplicationIdentityResult();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                if (_roleManager != null)
                {
                    _roleManager.Dispose();
                }
            }
            _disposed = true;
        }
    }
}
