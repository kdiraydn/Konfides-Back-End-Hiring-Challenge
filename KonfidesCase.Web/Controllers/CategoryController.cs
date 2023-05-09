using KonfidesCase.Business.Abstract;
using KonfidesCase.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CKonfidesCase.Web.Controllers;

public class CategoryController : Controller
{
    private readonly ICategoryManager _categoryManager;

    public CategoryController(ICategoryManager categoryManager)
    {
        _categoryManager = categoryManager;
    }

    public IActionResult Index()
    {
        var categories = _categoryManager.GetAll();
        return View(categories);
    }

    public IActionResult Add()
    {
        return View(new Category());
    }

    [HttpPost]
    public IActionResult Add(Category category)
    {
        _categoryManager.Add(category);
        return RedirectToAction("Index");
    }
    
    public IActionResult Update(int id)
    {
        var category = _categoryManager.GetAll().FirstOrDefault(x => x.Id == id);
        if (category == null)
        {
            return RedirectToAction("Index");
        }
        return View(category);
    }

    [HttpPost]
    public IActionResult Update(Category category)
    {
        _categoryManager.Update(category);
        return RedirectToAction("Index");
    }

    public IActionResult Delete(int id)
    {
        _categoryManager.Delete(new Category()
        {
            Id = id
        });
        return RedirectToAction("Index");
    }
}