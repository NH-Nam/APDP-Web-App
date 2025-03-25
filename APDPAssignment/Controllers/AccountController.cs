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
        public IActionResult Register(string username, string email, string password, string confirmPassword, string fullname, string role)
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
                        return RedirectToAction("Login", "Account");
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
    }
}
