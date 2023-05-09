using CKonfidesCase.Web.Models;
using KonfidesCase.Business.Abstract;
using KonfidesCase.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CKonfidesCase.Web.Controllers;

public class EventController : Controller
{
    private readonly IEventManager _eventManager;
    private readonly ICityManager _cityManager;
    private readonly ICategoryManager _categoryManager;

    public EventController(IEventManager eventManager, ICityManager cityManager, ICategoryManager categoryManager)
    {
        _eventManager = eventManager;
        _cityManager = cityManager;
        _categoryManager = categoryManager;
    }

    public IActionResult Index()
    {
        var events = _eventManager.GetAll();
        return View(events);
    }

    public IActionResult Add()
    {
        return View(new EventDto()
        {
            Cities = _cityManager.GetAll(),
            Categories = _categoryManager.GetAll()
        });
    }

    [HttpPost]
    public IActionResult Add(EventDto entity)
    {
        var dbEntity = new Event
        {
            Name = entity.Name,
            Date = entity.Date,
            Description = entity.Description,
            CityId = entity.CityId,
            Address = entity.Address,
            Quota = entity.Quota,
            CategoryId = entity.CategoryId,
        };

        _eventManager.Add(dbEntity);
        return RedirectToAction("Index");
    }
}