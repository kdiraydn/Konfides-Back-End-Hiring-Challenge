using KonfidesCase.Entities.Concrete;

namespace CKonfidesCase.Web.Models;

public class EventDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; }
    public int CityId { get; set; }
    public string Address { get; set; }
    public int Quota { get; set; }
    public int CategoryId { get; set; }
    public List<City> Cities { get; set; }
    public List<Category> Categories { get; set; }
}