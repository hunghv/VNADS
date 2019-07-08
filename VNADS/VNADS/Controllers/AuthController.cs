using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Data.Entities;
using log4net.Core;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Services.Interfaces;
using VNADS.Models.AccountViewModels;

namespace VNADS.Controllers
{
    [Route("Account")]
    public class AuthController : Controller
    {
        private readonly IAccountManagerService _userService;
        private readonly IConfiguration _configuration;
        private readonly UserManager<UserProfile> _userManager;
        private readonly SignInManager<UserProfile> _signInManager;

        public AuthController(IAccountManagerService userService, IConfiguration configuration, UserManager<UserProfile> userManager, SignInManager<UserProfile> signInManager)
        {
            _userService = userService;
            _configuration = configuration;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [Route("Login")]
        public async Task<IActionResult> Index(string returnUrl)
        {
            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ViewData["ReturnUrl"] = NormalizeReturnUrl(returnUrl);
            return View();
        }

        [Route("Login")]
        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: true, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    var user = await _userManager.FindByEmailAsync(model.Email);
                    await LoginAsync(user);
                    return RedirectToLocal(returnUrl);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View(model);
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);

        }

        [Route("signin/{provider}")]
        public IActionResult SignIn(string provider, string returnUrl = null) =>
            Challenge(new AuthenticationProperties { RedirectUri = returnUrl ?? "/" }, provider);


        public virtual async Task<ActionResult> ExternalLoginCallback(string returnUrl, string remoteError = null)
        {
            returnUrl = NormalizeReturnUrl(returnUrl);

            //if (remoteError != null)
            //{
            //    _logger.Error("Remote Error in ExternalLoginCallback: " + remoteError);
            //    throw new UserFriendlyException(L("CouldNotCompleteLoginOperation"));
            //}

            //var externalLoginInfo = await _signInManager.GetExternalLoginInfoAsync();
            //if (externalLoginInfo == null)
            //{
            //    _logger.Warn("Could not get information from external login.");
            //    return RedirectToAction(nameof(Login));
            //}

            //await _signInManager.SignOutAsync();

            //var tenancyName = GetTenancyNameOrNull();

            //var loginResult = await _logInManager.LoginAsync(externalLoginInfo, tenancyName);

            //switch (loginResult.Result)
            //{
            //    case AbpLoginResultType.Success:
            //        await _signInManager.SignInAsync(loginResult.Identity, false);
            //        return Redirect(returnUrl);
            //    case AbpLoginResultType.UnknownExternalLogin:
            //        return await RegisterForExternalLogin(externalLoginInfo);
            //    default:
            //        throw _abpLoginResultTypeHelper.CreateExceptionForFailedLoginAttempt(
            //            loginResult.Result,
            //            externalLoginInfo.Principal.FindFirstValue(ClaimTypes.Email) ?? externalLoginInfo.ProviderKey,
            //            tenancyName
            //        );
            //}

            return Redirect(returnUrl);
        }

        [Route("Logout")]
        public async Task<IActionResult> Logout(string returnUrl)
        {

            ViewBag.ReturnUrl = returnUrl;

            if (!_configuration.GetValue<bool>("Account:ShowLogoutPrompt"))
            {
                return await Logout();
            }

            return View();
            //await _signInManager.SignOutAsync();
            //return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [Route("Logout")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            if (User.Identity.IsAuthenticated)
            {
                await _signInManager.SignOutAsync();
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("register")]
        public IActionResult Register(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = NormalizeReturnUrl(returnUrl);
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [Route("register")]
        public async Task<IActionResult> Register(RegisterViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = NormalizeReturnUrl(returnUrl);
            if (ModelState.IsValid)
            {
                var user = new UserProfile
                {
                    UserName = model.Email,
                    Email = model.Email,
                    DisplayName = model.Email,
                    TwoFactorEnabled = false,
                    Active = true,
                    DateOfBirth = DateTime.Now,
                };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: true);
                    return RedirectToLocal(NormalizeReturnUrl(returnUrl));
                }
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        #region Private Method
        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }
        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(NormalizeReturnUrl(returnUrl));
            }
            return RedirectToAction("Index", "Home");
        }
        private async Task LoginAsync(UserProfile user)
        {
            var authProperties = new AuthenticationProperties
            {
                AllowRefresh = true,
                ExpiresUtc = DateTimeOffset.Now.AddDays(1),
                IsPersistent = true,
            };

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.GivenName, user.FirstName?? "Teo"),
                new Claim(ClaimTypes.Surname, user.LastName??"Teo"),
                new Claim(ClaimTypes.DateOfBirth, user.DateOfBirth.ToString("o")??DateTime.Now.ToString(), ClaimValueTypes.DateTime)
            };
            var userIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            ClaimsPrincipal userPrincipal = new ClaimsPrincipal(userIdentity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, userPrincipal, authProperties);
        }

        private static bool IsUrlValid(string returnUrl)
        {
            return !string.IsNullOrWhiteSpace(returnUrl)
                   && Uri.IsWellFormedUriString(returnUrl, UriKind.Relative);
        }

        public ActionResult RedirectToAppHome()
        {
            return RedirectToAction("Index", "Home");
        }

        public string GetAppHomeUrl()
        {
            return Url.Action("Index", "Home");
        }
        private string NormalizeReturnUrl(string returnUrl, Func<string> defaultValueBuilder = null)
        {
            if (defaultValueBuilder == null)
            {
                defaultValueBuilder = GetAppHomeUrl;
            }

            if (string.IsNullOrEmpty(returnUrl))
            {
                return defaultValueBuilder();
            }

            if (Url.IsLocalUrl(returnUrl))
            {
                return returnUrl;
            }

            return defaultValueBuilder();
        }
        #endregion
    }
}