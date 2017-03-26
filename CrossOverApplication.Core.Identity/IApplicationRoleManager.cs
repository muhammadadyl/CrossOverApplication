using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using CrossOverApplication.Core.Domain.Entities.Identity;

namespace CrossOverApplication.Core.Identity
{
    public interface IApplicationRoleManager :IDisposable
    {
        Task<ApplicationIdentityResult> CreateAsync(ApplicationRole role);
        Task<ApplicationIdentityResult> DeleteAsync(string roleId);
        Task<ApplicationRole> FindByIdAsync(string roleId);
        Task<ApplicationRole> FindByNameAsync(string roleName);
        IEnumerable<ApplicationRole> GetRoles();
        Task<IEnumerable<ApplicationRole>> GetRolesAsync();
        Task<bool> RoleExistsAsync(string roleName);
        Task<ApplicationIdentityResult> UpdateAsync(string roleId, string roleName);
    }
}