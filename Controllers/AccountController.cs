using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OidcAspNetCore.Models;

namespace OidcAspNetCore.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return Challenge(OpenIdConnectDefaults.AuthenticationScheme);
            }

            return RedirectToAction("Index", "Home");
        }

        public IActionResult LogOut()
        {
            return new SignOutResult(
                new[]
                {
                      OpenIdConnectDefaults.AuthenticationScheme,
                      CookieAuthenticationDefaults.AuthenticationScheme,
                });
        }
    }
}