using APDPAssignment.Models;
using APDPAssignment.Services;
using Microsoft.AspNetCore.Mvc;

namespace APDPAssignment.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var account = _accountService.AuthenticateUser(username, password);
            if (account != null)
            {
                // Handle successful login (e.g., set authentication state, redirect)
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // Handle login failure
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View();
            }
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(string username, string password, string role)
        {
            var account = new Account
            {
                Username = username,
                Password = password
            };

            bool success = role switch
            {
                "Student" => _accountService.RegisterStudent(new Student { Account = account }),
                "Lecturer" => _accountService.RegisterLecturer(new Lecturer { Account = account }),
                "Admin" => _accountService.RegisterAdmin(new Admin { Account = account }),
                _ => false
            };

            if (success)
            {
                // Handle successful registration (e.g., redirect to login)
                return RedirectToAction("Login");
            }
            else
            {
                // Handle registration failure
                ModelState.AddModelError(string.Empty, "Registration failed.");
                return View();
            }
        }
    }
}
