using KonfidesCase.Entities.Concrete;

namespace KonfidesCase.Business.Abstract;

public interface IEventManager
{
    List<Event> GetAll();
    void Add(Event entity);
    void Update(Event entity);
    void Delete(Event entity);
}