using KonfidesCase.Business.Abstract;
using KonfidesCase.DataAccess.Abstract;
using KonfidesCase.Entities.Concrete;

namespace KonfidesCase.Business.Concrete;

public class CityManager : ICityManager
{
    private readonly IGenericRepository<City> _genericRepository;

    public CityManager(IGenericRepository<City> genericRepository)
    {
        _genericRepository = genericRepository;
    }

    public List<City> GetAll()
    {
        return _genericRepository.GetAllAsync().Result;
    }

    public void Add(City city)
    {
        var entity = _genericRepository.GetAsync(x => x.Name == city.Name).Result;
        if (entity.Id == 0)
        {
            _genericRepository.AddAsync(city).Wait();
        }
    }

    public void Update(City city)
    {
        _genericRepository.UpdateAsync(city).Wait();
    }

    public void Delete(City city)
    {
        _genericRepository.DeleteById(city.Id).Wait();
    }
}