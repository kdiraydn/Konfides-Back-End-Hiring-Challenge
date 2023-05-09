using KonfidesCase.Entities.Abstract;

namespace KonfidesCase.Entities.Concrete;

public class Event : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; }
    
    public int CityId { get; set; }
    public virtual City City { get; set; }

    public string Address { get; set; }
    public int Quota { get; set; }

    public int CategoryId { get; set; }
    public virtual Category Category { get; set; }

    public int IsConfirm { get; set; }
}