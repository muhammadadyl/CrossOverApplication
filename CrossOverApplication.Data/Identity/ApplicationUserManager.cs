using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CrossOverApplication.Core.Identity;
using CrossOverApplication.Data.Models.Identity;
using Microsoft.AspNetCore.Http.Authentication;
using CrossOverApplication.Core.Domain.Entities.Identity;
using CrossOverApplication.Data.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CrossOverApplication.Data.Identity
{
    // Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.

    public class ApplicationUserManager : IApplicationUserManager
    {
        private readonly UserManager<ApplicationIdentityUser> _userManager;
        private bool _disposed;
        public ApplicationUserManager(UserManager<ApplicationIdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public virtual async Task<ApplicationIdentityResult> AccessFailedAsync(ApplicationIdentityUser userId)
        {
            var identityResult = await _userManager.AccessFailedAsync(userId).ConfigureAwait(false);
            return identityResult.ToApplicationIdentityResult();
        }

        public virtual async Task<ApplicationIdentityResult> AddClaimAsync(ApplicationIdentityUser userId, Claim claim)
        {
            var identityResult = await _userManager.AddClaimAsync(userId, claim).ConfigureAwait(false);
            return identityResult.ToApplicationIdentityResult();
        }

        public virtual async Task<ApplicationIdentityResult> AddLoginAsync(ApplicationIdentityUser userId, ApplicationUserLoginInfo login)
        {
            var identityResult = await _userManager.AddLoginAsync(userId, login.ToUserLoginInfo()).ConfigureAwait(false);
            return identityResult.ToApplicationIdentityResult();
        }

        public virtual async Task<ApplicationIdentityResult> AddPasswordAsync(ApplicationIdentityUser userId, string password)
        {
            var identityResult = await _userManager.AddPasswordAsync(userId, password).ConfigureAwait(false);
            return identityResult.ToApplicationIdentityResult();
        }

        public virtual async Task<ApplicationIdentityResult> AddToRoleAsync(ApplicationIdentityUser userId, string role)
        {
            var identityResult = await _userManager.AddToRoleAsync(userId, role).ConfigureAwait(false);
            return identityResult.ToApplicationIdentityResult();
        }

        public virtual async Task<ApplicationIdentityResult> AddUserToRolesAsync(ApplicationIdentityUser userId, IList<string> roles)
        {
            var user = await FindByIdAsync(userId.Id).ConfigureAwait(false);
            if (user == null)
            {
                throw new InvalidOperationException("Invalid user Id");
            }

            var userRoles = await GetRolesAsync(userId).ConfigureAwait(false);
            // Add user to each role using UserRoleStore
            foreach (var role in roles.Where(role => !userRoles.Contains(role)))
            {
                await AddToRoleAsync(userId, role).ConfigureAwait(false);
            }

            // Call update once when all roles are added
            return await UpdateAsync(userId.Id).ConfigureAwait(false);
        }

        public virtual async Task<ApplicationIdentityResult> ChangePasswordAsync(ApplicationIdentityUser userId, string currentPassword, string newPassword)
        {
            var identityResult = await _userManager.ChangePasswordAsync(userId, currentPassword, newPassword).ConfigureAwait(false);
            return identityResult.ToApplicationIdentityResult();
        }

        public virtual async Task<ApplicationIdentityResult> ChangePhoneNumberAsync(ApplicationIdentityUser userId, string phoneNumber, string token)
        {
            var identityResult = await _userManager.ChangePhoneNumberAsync(userId, phoneNumber, token).ConfigureAwait(false);
            return identityResult.ToApplicationIdentityResult();
        }

        public virtual async Task<bool> CheckPasswordAsync(AppUser user, string password)
        {
            var applicationUser = user.ToApplicationUser();
            var flag = await _userManager.CheckPasswordAsync(applicationUser, password).ConfigureAwait(false);
            user.CopyApplicationIdentityUserProperties(applicationUser);
            return flag;
        }

        public virtual async Task<ApplicationIdentityResult> ConfirmEmailAsync(ApplicationIdentityUser userId,  string token)
        {
            var identityResult = await _userManager.ConfirmEmailAsync(userId, token).ConfigureAwait(false);
            return identityResult.ToApplicationIdentityResult();
        }

        public virtual async Task<ApplicationIdentityResult> CreateAsync(AppUser user)
        {
            var applicationUser = user.ToApplicationUser();
            var identityResult = await _userManager.CreateAsync(applicationUser).ConfigureAwait(false);
            user.CopyApplicationIdentityUserProperties(applicationUser);
            return identityResult.ToApplicationIdentityResult();
        }

        public virtual async Task<ApplicationIdentityResult> CreateAsync(AppUser user, string password)
        {
            var applicationUser = user.ToApplicationUser();
            var identityResult = await _userManager.CreateAsync(applicationUser, password).ConfigureAwait(false);
            user.CopyApplicationIdentityUserProperties(applicationUser);
            return identityResult.ToApplicationIdentityResult();
        }

        public virtual async Task<ApplicationIdentityResult> DeleteAsync(string userId)
        {
            var applicationUser = await _userManager.FindByIdAsync(userId);
            if (applicationUser == null)
            {
                return new ApplicationIdentityResult(new IdentityError[] { new IdentityError() { Code = "", Description = "Invalid user Id" } }, false);
            }
            var identityResult = await _userManager.DeleteAsync(applicationUser).ConfigureAwait(false);
            return identityResult.ToApplicationIdentityResult();
        }

        public virtual async Task<AppUser> FindAsync(ApplicationUserLoginInfo login)
        {
            var user = await _userManager.FindByLoginAsync(login.LoginProvider, login.ProviderKey).ConfigureAwait(false);
            return user.ToAppUser();
        }

        public virtual async Task<AppUser> FindByEmailAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email).ConfigureAwait(false);
            return user.ToAppUser();
        }

        public virtual async Task<AppUser> FindByIdAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId).ConfigureAwait(false);
            return user.ToAppUser();
        }

        public virtual async Task<AppUser> FindByNameAsync(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName).ConfigureAwait(false);
            return user.ToAppUser();
        }

        public virtual async Task<string> GenerateChangePhoneNumberTokenAsync(ApplicationIdentityUser userId, string phoneNumber)
        {
             return await _userManager.GenerateChangePhoneNumberTokenAsync(userId, phoneNumber).ConfigureAwait(false);
        }

        public virtual async Task<string> GenerateEmailConfirmationTokenAsync(ApplicationIdentityUser userId)
        {
            return await _userManager.GenerateEmailConfirmationTokenAsync(userId).ConfigureAwait(false);
        }

        public virtual async Task<string> GeneratePasswordResetTokenAsync(ApplicationIdentityUser userId)
        {
            return await _userManager.GeneratePasswordResetTokenAsync(userId).ConfigureAwait(false);
        }

        public virtual async Task<string> GenerateTwoFactorTokenAsync(ApplicationIdentityUser userId, string twoFactorProvider)
        {
            return await _userManager.GenerateTwoFactorTokenAsync(userId, twoFactorProvider).ConfigureAwait(false);
        }

        public virtual async Task<string> GenerateUserTokenAsync(ApplicationIdentityUser userId, string tokenProvider, string purpose)
        {
            return await _userManager.GenerateUserTokenAsync(userId, tokenProvider, purpose).ConfigureAwait(false);
        }

        public virtual async Task<int> GetAccessFailedCountAsync(ApplicationIdentityUser userId)
        {
            return await _userManager.GetAccessFailedCountAsync(userId).ConfigureAwait(false);
        }

        public virtual async Task<IList<Claim>> GetClaimsAsync(ApplicationIdentityUser userId)
        {
            return await _userManager.GetClaimsAsync(userId).ConfigureAwait(false);
        }

        public virtual async Task<string> GetEmailAsync(ApplicationIdentityUser userId)
        {
            return await _userManager.GetEmailAsync(userId).ConfigureAwait(false);
        }

        public virtual async Task<bool> GetLockoutEnabledAsync(ApplicationIdentityUser userId)
        {
            return await _userManager.GetLockoutEnabledAsync(userId).ConfigureAwait(false);
        }

        public virtual async Task<DateTimeOffset?> GetLockoutEndDateAsync(ApplicationIdentityUser userId)
        {
            return await _userManager.GetLockoutEndDateAsync(userId).ConfigureAwait(false);
        }

        public virtual async Task<IList<ApplicationUserLoginInfo>> GetLoginsAsync(ApplicationIdentityUser userId)
        {
            var list = await _userManager.GetLoginsAsync(userId).ConfigureAwait(false);
            return list.ToApplicationUserLoginInfoList();
        }

        public virtual async Task<string> GetPhoneNumberAsync(ApplicationIdentityUser userId)
        {
            return await _userManager.GetPhoneNumberAsync(userId).ConfigureAwait(false);
        }

        public virtual async Task<IList<string>> GetRolesAsync(ApplicationIdentityUser userId)
        {
             return await _userManager.GetRolesAsync(userId).ConfigureAwait(false);
        }

        public virtual async Task<string> GetSecurityStampAsync(ApplicationIdentityUser userId)
        {
            return await _userManager.GetSecurityStampAsync(userId).ConfigureAwait(false);
        }

        public virtual async Task<bool> GetTwoFactorEnabledAsync(ApplicationIdentityUser userId)
        {
            return await _userManager.GetTwoFactorEnabledAsync(userId).ConfigureAwait(false);
        }

        public virtual async Task<IList<string>> GetValidTwoFactorProvidersAsync(ApplicationIdentityUser userId)
        {
            return await _userManager.GetValidTwoFactorProvidersAsync(userId).ConfigureAwait(false);
        }

        public virtual async Task<bool> HasPasswordAsync(ApplicationIdentityUser userId)
        {
            return await _userManager.HasPasswordAsync(userId).ConfigureAwait(false);
        }

        public virtual async Task<bool> IsEmailConfirmedAsync(ApplicationIdentityUser userId)
        {
            return await _userManager.IsEmailConfirmedAsync(userId).ConfigureAwait(false);
        }

        public virtual async Task<bool> IsInRoleAsync(ApplicationIdentityUser userId, string role)
        {
            return await _userManager.IsInRoleAsync(userId,role).ConfigureAwait(false);
        }

        public virtual async Task<bool> IsLockedOutAsync(ApplicationIdentityUser userId)
        {
            return await _userManager.IsLockedOutAsync(userId).ConfigureAwait(false);
        }

        public virtual async Task<bool> IsPhoneNumberConfirmedAsync(ApplicationIdentityUser userId)
        {
            return await _userManager.IsPhoneNumberConfirmedAsync(userId).ConfigureAwait(false);
        }

        public virtual async Task<SignInStatus> PasswordSignIn(string userName, string password, bool isPersistent, bool shouldLockout)
        {
            var user = await FindByNameAsync(userName).ConfigureAwait(false);
            if (user == null)
            {
                return SignInStatus.Failure;
            }
            if (await IsLockedOutAsync(user.ToApplicationUser()).ConfigureAwait(false))
            {
                return SignInStatus.LockedOut;
            }
            if (shouldLockout)
            {
                // If lockout is requested, increment access failed count which might lock out the user
                await AccessFailedAsync(user.ToApplicationUser()).ConfigureAwait(false);
                if (await IsLockedOutAsync(user.ToApplicationUser()).ConfigureAwait(false))
                {
                    return SignInStatus.LockedOut;
                }
            }
            return SignInStatus.Failure;
        }

        public virtual async Task<ApplicationIdentityResult> RemoveClaimAsync(ApplicationIdentityUser userId, Claim claim)
        {
            var identityResult = await _userManager.RemoveClaimAsync(userId, claim).ConfigureAwait(false);
            return identityResult.ToApplicationIdentityResult();
        }

        public virtual async Task<ApplicationIdentityResult> RemoveFromRoleAsync(ApplicationIdentityUser userId, string role)
        {
            var identityResult = await _userManager.RemoveFromRoleAsync(userId, role).ConfigureAwait(false);
            return identityResult.ToApplicationIdentityResult();
        }

        public virtual async Task<ApplicationIdentityResult> RemoveLoginAsync(ApplicationIdentityUser userId,
            ApplicationUserLoginInfo login)
        {
            var identityResult = await _userManager.RemoveLoginAsync(userId, login.LoginProvider, login.ProviderKey).ConfigureAwait(false);
            return identityResult.ToApplicationIdentityResult();
        }

        public virtual async Task<ApplicationIdentityResult> RemovePasswordAsync(ApplicationIdentityUser userId)
        {
            var identityResult = await _userManager.RemovePasswordAsync(userId).ConfigureAwait(false);
            return identityResult.ToApplicationIdentityResult();
        }

        public virtual async Task<ApplicationIdentityResult> RemoveUserFromRolesAsync(ApplicationIdentityUser userId, IList<string> roles)
        {
            var user = await FindByIdAsync(userId.Id).ConfigureAwait(false);
            if (user == null)
            {
                throw new InvalidOperationException("Invalid user Id");
            }

            var userRoles = await GetRolesAsync(user.ToApplicationUser()).ConfigureAwait(false);
            // Remove user to each role using UserRoleStore
            foreach (var role in roles.Where(userRoles.Contains))
            {
                await RemoveFromRoleAsync(user.ToApplicationUser(), role).ConfigureAwait(false);
            }

            // Call update once when all roles are removed
            return await UpdateAsync(user.Id).ConfigureAwait(false);
        }

        public virtual async Task<ApplicationIdentityResult> ResetAccessFailedCountAsync(ApplicationIdentityUser userId)
        {
            var identityResult = await _userManager.ResetAccessFailedCountAsync(userId).ConfigureAwait(false);
            return identityResult.ToApplicationIdentityResult();
        }

        public virtual async Task<ApplicationIdentityResult> ResetPasswordAsync(ApplicationIdentityUser userId, string token,
            string newPassword)
        {
            var identityResult = await _userManager.ResetPasswordAsync(userId, token, newPassword).ConfigureAwait(false);
            return identityResult.ToApplicationIdentityResult();
        }

        public virtual async Task<ApplicationIdentityResult> SetEmailAsync(ApplicationIdentityUser userId, string email)
        {
            var identityResult = await _userManager.SetEmailAsync(userId, email).ConfigureAwait(false);
            return identityResult.ToApplicationIdentityResult();
        }

        public virtual async Task<ApplicationIdentityResult> SetLockoutEnabledAsync(ApplicationIdentityUser userId, bool enabled)
        {
            var identityResult = await _userManager.SetLockoutEnabledAsync(userId, enabled).ConfigureAwait(false);
            return identityResult.ToApplicationIdentityResult();
        }

        public virtual async Task<ApplicationIdentityResult> SetLockoutEndDateAsync(ApplicationIdentityUser userId,
            DateTimeOffset lockoutEnd)
        {
            var identityResult = await _userManager.SetLockoutEndDateAsync(userId, lockoutEnd).ConfigureAwait(false);
            return identityResult.ToApplicationIdentityResult();
        }

        public virtual async Task<ApplicationIdentityResult> SetPhoneNumberAsync(ApplicationIdentityUser userId, string phoneNumber)
        {
            var identityResult = await _userManager.SetPhoneNumberAsync(userId, phoneNumber).ConfigureAwait(false);
            return identityResult.ToApplicationIdentityResult();
        }

        public virtual async Task<ApplicationIdentityResult> SetTwoFactorEnabledAsync(ApplicationIdentityUser userId, bool enabled)
        {
            var identityResult = await _userManager.SetTwoFactorEnabledAsync(userId, enabled).ConfigureAwait(false);
            return identityResult.ToApplicationIdentityResult();
        }

        public virtual async Task<ApplicationIdentityResult> UpdateAsync(string userId)
        {
            var applicationUser = await _userManager.FindByIdAsync(userId).ConfigureAwait(false);
            if (applicationUser == null)
            {
                return new ApplicationIdentityResult(new IdentityError[] { new IdentityError() { Code = "", Description = "Invalid user Id" } }, false);
            }
            var identityResult = await _userManager.UpdateAsync(applicationUser).ConfigureAwait(false);
            return identityResult.ToApplicationIdentityResult();
        }

        public virtual async Task<ApplicationIdentityResult> UpdateSecurityStampAsync(ApplicationIdentityUser userId)
        {
            var identityResult = await _userManager.UpdateSecurityStampAsync(userId).ConfigureAwait(false);
            return identityResult.ToApplicationIdentityResult();
        }

        public virtual IEnumerable<AppUser> GetUsers()
        {
            return _userManager.Users.ToList().ToAppUserList();
        }

        public virtual async Task<IEnumerable<AppUser>> GetUsersAsync()
        {
            var users = await _userManager.Users.ToListAsync().ConfigureAwait(false);
            return users.ToAppUserList();
        }

        public virtual async Task<bool> VerifyChangePhoneNumberTokenAsync(ApplicationIdentityUser userId, string token,
            string phoneNumber)
        {
            return await _userManager.VerifyChangePhoneNumberTokenAsync(userId, token, phoneNumber).ConfigureAwait(false);
        }

        public virtual async Task<bool> VerifyTwoFactorTokenAsync(ApplicationIdentityUser userId, string twoFactorProvider, string token)
        {
            return await _userManager.VerifyTwoFactorTokenAsync(userId, twoFactorProvider, token).ConfigureAwait(false);
        }

        public virtual async Task<bool> VerifyUserTokenAsync(ApplicationIdentityUser userId, string tokenProvider, string purpose, string token)
        {
            return await _userManager.VerifyUserTokenAsync(userId, tokenProvider, purpose, token).ConfigureAwait(false);
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
                if (_userManager != null)
                {
                    _userManager.Dispose();
                }
            }
            _disposed = true;
        }
    }
}
