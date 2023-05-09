using KonfidesCase.Entities.Concrete;

namespace KonfidesCase.Business.Abstract;

public interface ICategoryManager
{
    List<Category> GetAll();
    void Add(Category category);
    void Update(Category category);
    void Delete(Category category);
}