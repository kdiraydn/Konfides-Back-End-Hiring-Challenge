using KonfidesCase.Business.Abstract;
using KonfidesCase.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CKonfidesCase.Web.Controllers;

public class CityController : Controller
{
    private readonly ICityManager _cityManager;

    public CityController(ICityManager cityManager)
    {
        _cityManager = cityManager;
    }

    public IActionResult Index()
    {
        var cities = _cityManager.GetAll();
        return View(cities);
    }
    
    public IActionResult Add()
    {
        return View(new City());
    }
    
    [HttpPost]
    public IActionResult Add(City city)
    {
        _cityManager.Add(city);
        return RedirectToAction("Index");
    }
    
    public IActionResult Update(int id)
    {
        var city = _cityManager.GetAll().FirstOrDefault(x => x.Id == id);
        if (city == null)
        {
            return RedirectToAction("Index");
        }
        return View(city);
    }

    [HttpPost]
    public IActionResult Update(City city)
    {
        _cityManager.Update(city);
        return RedirectToAction("Index");
    }
    
    public IActionResult Delete(int id)
    {
        _cityManager.Delete(new City()
        {
            Id = id
        });
        return RedirectToAction("Index");
    }
}