using Microsoft.AspNetCore.Identity;
using Parcial3.Dal.Entities;
using Parcial3.Models;

namespace Parcial3.Helpers
{
	public interface IUserHelper
	{
		Task<User> GetUserAsync(string email);

		Task<IdentityResult> AddUserAsync(User user, string password);

		Task CheckRoleAsync(string roleName);

		Task AddUserToRoleAsync(User user, string roleName);

		Task<bool> IsUserInRoleAsync(User user, string roleName);

		Task<SignInResult> LoginAsync(LoginViewModel loginViewModel);

		Task LogoutAsync();
	}
}
