using KonfidesCase.Business.Abstract;
using KonfidesCase.Entities.Concrete;

namespace CKonfidesCase.Web.Seed;

public class SeedData
{
    private readonly ICategoryManager _categoryManager;
    private readonly ICityManager _cityManager;

    public SeedData(ICategoryManager categoryManager, ICityManager cityManager)
    {
        _categoryManager = categoryManager;
        _cityManager = cityManager;
    }

    public void AddCategories()
    {
        _categoryManager.Add(new Category()
        {
            Name = "Spor"
        });
        _categoryManager.Add(new Category()
        {
            Name = "Konser"
        });
        _categoryManager.Add(new Category()
        {
            Name = "Tiyatro"
        });
        _categoryManager.Add(new Category()
        {
            Name = "Sinema"
        });
    }

    public void AddCities()
    {
        _cityManager.Add(new City()
        {
            Name = "İstanbul"
        });
        _cityManager.Add(new City()
        {
            Name = "Ankara"
        });
        _cityManager.Add(new City()
        {
            Name = "İzmir"
        });
        _cityManager.Add(new City()
        {
            Name = "Antalya"
        });
    }
}