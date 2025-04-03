using APDPAssignment.Models;
using APDPAssignment.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace APDPAssignment.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        //public AccountController()
        //{
        //}

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(string username, string email, string password, string confirmPassword, string fullname, int role)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (password != confirmPassword)
                    {
                        ModelState.AddModelError("", "Passwords do not match.");
                        return View();
                    }

                    var result = _accountService.Register(username, email, password, fullname, role);
                    if (result)
                    {
                        return View("Login");
                    }
                    ModelState.AddModelError("", "Registration failed.");
                }
                return View();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "An error occurred: " + ex.Message);
                return View();
            }
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = _accountService.Login(username, password);
                    if (result)
                    {
                        var role = _accountService.GetUserRole(username);
                        var account = _accountService.GetAccountByUsername(username);

                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, username),
                            new Claim(ClaimTypes.NameIdentifier, account.AccountId.ToString()),
                            new Claim(ClaimTypes.Role, role)
                        };

                        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        var authProperties = new AuthenticationProperties();

                        await HttpContext.SignInAsync(
                            CookieAuthenticationDefaults.AuthenticationScheme,
                            new ClaimsPrincipal(claimsIdentity),
                            authProperties);

                        if (role == "Admin")
                        {
                            return RedirectToAction("CourseManagement", "Course");
                        }
                        else if (role == "Lecturer")
                        {
                            return RedirectToAction("CourseManagement", "Course");
                        }
                        else if (role == "Student")
                        {
                            return RedirectToAction("MyAcademicInfo", "Student");
                        }
                    }
                    ModelState.AddModelError("", "Login failed. Please check your username and password.");
                }
                return View();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "An error occurred: " + ex.Message);
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }
}
