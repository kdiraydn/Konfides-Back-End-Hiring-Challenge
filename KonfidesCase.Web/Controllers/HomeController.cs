using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CKonfidesCase.Web.Models;
using KonfidesCase.Entities.Concrete;
using Microsoft.AspNetCore.Identity;

namespace CKonfidesCase.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly UserManager<AppUser> _userManager;
    private readonly RoleManager<AppRole> _roleManager;

    public HomeController(ILogger<HomeController> logger, UserManager<AppUser> userManager,
        RoleManager<AppRole> roleManager)
    {
        _logger = logger;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult AddData()
    {
        _roleManager.CreateAsync(new AppRole()
        {
            Name = "Admin"
        }).Wait();

        var user = new AppUser()
        {
            Email = "admin@hotmail.com",
            UserName = "AdminUser",
            Name = "Kadir",
            Surname = "Aydin",
        };

        _userManager.CreateAsync(user, "Admin123*").Wait();

        _userManager.AddToRoleAsync(user, "Admin").Wait();

        return Ok();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}