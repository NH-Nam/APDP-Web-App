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
        public IActionResult Register(string username, string email, string password, string confirmPassword, string role, string firstName, string lastName, string phoneNumber, DateTime dob, string gender)
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

                    var result = _accountService.Register(username, email, password, role, firstName, lastName, phoneNumber, dob, gender);
                    if (result)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    ModelState.AddModelError("", "Registration failed.");
                }
                return View();
            }
            catch (Exception ex)
            {
                return View();
            }
        }
    }
}
