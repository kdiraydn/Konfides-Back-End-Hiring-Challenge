using KonfidesCase.Business.Abstract;
using KonfidesCase.DataAccess.Abstract;
using KonfidesCase.Entities.Concrete;

namespace KonfidesCase.Business.Concrete;

public class CategoryManager : ICategoryManager
{
    private readonly IGenericRepository<Category> _genericRepository;

    public CategoryManager(IGenericRepository<Category> genericRepository)
    {
        _genericRepository = genericRepository;
    }


    public List<Category> GetAll()
    {
        return _genericRepository.GetAllAsync().Result;
    }

    public void Add(Category category)
    {
        var entity = _genericRepository.GetAsync(x => x.Name == category.Name).Result;
        if (entity.Id == 0)
        {
            _genericRepository.AddAsync(category).Wait();
        }
    }

    public void Update(Category category)
    {
        _genericRepository.UpdateAsync(category).Wait();
    }

    public void Delete(Category category)
    {
        _genericRepository.DeleteById(category.Id).Wait();
    }
}