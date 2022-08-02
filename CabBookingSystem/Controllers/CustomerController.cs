using CabBookingSystem.Models;
using CabBookingSystem.Service;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CabBookingSystem.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerservice;
        public CustomerController(ICustomerService customerservice)
        {
            _customerservice = customerservice;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Customer user)
        {
            var result = _customerservice.Register(user);
            if (result == 1)
            {
                return RedirectToAction("Login");
            }
            else
            {
                ViewBag.Message = "This Email already exists";
                return View();
            }

        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Customer user)
        {
            Customer result = _customerservice.Login(user);
            if (result != null)
            {
                HttpContext.Session.SetString("mobile",result.Mobile.ToString());
                
                var claims = new List<Claim>
                    {
                    new Claim(ClaimTypes.Name,result.Username),
                    new Claim(ClaimTypes.Role,"User")

                    };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                ClaimsPrincipal user1 = new ClaimsPrincipal(claimsIdentity);
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, user1, new AuthenticationProperties()
                {
                    IsPersistent = false,
                    //ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(60),
                    AllowRefresh = true
                }

                );

                return RedirectToAction("Index", "Cab");

            }
            ModelState.AddModelError(string.Empty, "Invalid username and password");

            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
