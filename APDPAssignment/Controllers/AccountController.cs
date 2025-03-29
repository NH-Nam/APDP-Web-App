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
        public IActionResult Login(string username, string password)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = _accountService.Login(username, password);
                    if (result)
                    {
                        var role = _accountService.GetUserRole(username);
                        if (role == "Admin")
                        {
                            return RedirectToAction("CourseManagement", "Course");
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
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
    }
}
