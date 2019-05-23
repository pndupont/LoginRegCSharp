using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LOGINREG.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace LOGINREG.Controllers
{
    public class HomeController : Controller
    {
        private HomeContext DBContext;
        public HomeController(HomeContext context)
        {
            DBContext = context;
        }
        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("register")]
        public IActionResult Register(User newUser)
        {
            if (ModelState.IsValid)
            {
                if (DBContext.Users.Any(u => u.Email == newUser.Email))
                {
                    ModelState.AddModelError("Email", "Email already in use");
                    return View("Index");
                }
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                newUser.Password = Hasher.HashPassword(newUser, newUser.Password);
                DBContext.Users.Add(newUser);
                DBContext.SaveChanges();
                HttpContext.Session.SetInt32("UserId", newUser.UserId);
                return RedirectToAction("Dashboard");
            }
            else
            {
                return View("Index");
            }
        }
        [HttpPost("login")]
        public IActionResult Login(LoginUser LogUser)
        {
            if(ModelState.IsValid)
            {
                User UserInDB = DBContext.Users.FirstOrDefault(u => u.Email == LogUser.LoginEmail);
                if (UserInDB == null)
                {
                    ModelState.AddModelError("LoginEmail", "Email address not use");
                    return View("Index");
                }
                var Hasher = new PasswordHasher<LoginUser>();
                var result = Hasher.VerifyHashedPassword(LogUser, UserInDB.Password, LogUser.LoginPassword);

                if(result == 0)
                {
                    ModelState.AddModelError("LoginPassword", "Password incorrect");
                    return View("Index");
                }
                HttpContext.Session.SetInt32("UserId", UserInDB.UserId);
                return RedirectToAction("Dashboard");
            }
            else
            {
                return View("Index");
            }
        }
        [HttpGet("Dashboard")]
        public IActionResult Dashboard()
        {
            if (HttpContext.Session.GetInt32("UserId") == null)
                {
                    HttpContext.Session.Clear();
                    return RedirectToAction("Index");
                }
            else
            {
                User DBUser = DBContext.Users.FirstOrDefault( u => u.UserId == HttpContext.Session.GetInt32("UserId"));
                return View("Dashboard", DBUser);
            }
        }
        [HttpGet("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
    