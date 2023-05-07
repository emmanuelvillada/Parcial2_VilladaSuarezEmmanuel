using Microsoft.AspNetCore.Mvc;
using Parcial3.Helpers;
using Parcial3.Models;

namespace Parcial3.Controllers
{
	public class AccountController : Controller
	{
		private readonly IUserHelper _userHelper;

		public AccountController(IUserHelper userHelper)
		{
			_userHelper = userHelper;
		}

		[HttpGet]
		public IActionResult Login()
		{
			if (User.Identity.IsAuthenticated)
			{
				return RedirectToAction("Index", "Home");
			}

			return View(new LoginViewModel());
		}

		[HttpPost]
		public async Task<IActionResult> Login(LoginViewModel loginViewModel)
		{
			if (ModelState.IsValid)
			{
				Microsoft.AspNetCore.Identity.SignInResult result = await _userHelper.LoginAsync(loginViewModel);
				if (result.Succeeded)
				{
					return RedirectToAction("Index", "Home");
				}

				ModelState.AddModelError(string.Empty, "Email o contraseña incorrectos.");
			}
			return View(loginViewModel);
		}

		public async Task<IActionResult> Logout()
		{
			await _userHelper.LogoutAsync();
			return RedirectToAction("Index", "Home");
		}

		public IActionResult Unauthorized()
		{
			return View();
		}
	}
}

