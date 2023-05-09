using KonfidesCase.Entities.Abstract;

namespace KonfidesCase.Entities.Concrete;

public class Category : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
}