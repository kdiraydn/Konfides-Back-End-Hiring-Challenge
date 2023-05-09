using KonfidesCase.Entities.Concrete;

namespace KonfidesCase.Business.Abstract;

public interface ICityManager
{
    List<City> GetAll();
    void Add(City city);
    void Update(City city);
    void Delete(City city);
}