using KonfidesCase.Business.Abstract;
using KonfidesCase.DataAccess.Abstract;
using KonfidesCase.Entities.Concrete;

namespace KonfidesCase.Business.Concrete;

public class EventManager : IEventManager
{
    private readonly IGenericRepository<Event> _genericRepository;

    public EventManager(IGenericRepository<Event> genericRepository)
    {
        _genericRepository = genericRepository;
    }

    public List<Event> GetAll()
    {
        return _genericRepository.GetAllAsync().Result;
    }

    public void Add(Event entity)
    {
        _genericRepository.AddAsync(entity).Wait();
    }

    public void Update(Event entity)
    {
        _genericRepository.UpdateAsync(entity).Wait();
    }

    public void Delete(Event entity)
    {
        _genericRepository.DeleteById(entity.Id).Wait();
    }
}