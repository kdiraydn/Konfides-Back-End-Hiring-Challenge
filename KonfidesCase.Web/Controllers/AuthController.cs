using CKonfidesCase.Web.Models;
using KonfidesCase.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CKonfidesCase.Web.Controllers;

public class AuthController : Controller
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;

    public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public IActionResult Register()
    {
        return View(new UserDto());
    }

    [HttpPost]
    public IActionResult Register(UserDto userDto)
    {
        var user = new AppUser()
        {
            Email = userDto.Email,
            UserName = $"{userDto.Name}{userDto.Surname}",
            Name = userDto.Name,
            Surname = userDto.Surname
        };
        var isSuccess = _userManager.CreateAsync(user, userDto.Password).Result;
        if (isSuccess.Succeeded)
        {
            _signInManager.SignInAsync(user, true).Wait();
            return RedirectToAction("Index", "Home");
        }

        return View(userDto);
    }

    public IActionResult Login()
    {
        return View(new LoginDto());
    }

    [HttpPost]
    public IActionResult Login(LoginDto loginDto)
    {
        var isSuccess = _signInManager.PasswordSignInAsync(loginDto.UserName, loginDto.Password, true, false).Result;

        if (isSuccess.Succeeded)
        {
            return RedirectToAction("Index", "Home");
        }

        return View(loginDto);
    }

    public IActionResult Logout()
    {
        _signInManager.SignOutAsync().Wait();
        return RedirectToAction("Login", "Auth");
    }

    public IActionResult Profile()
    {
        if (User.Identity != null)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
            return View(user);    
        }
        
        return RedirectToAction("Login", "Auth");
    }
}