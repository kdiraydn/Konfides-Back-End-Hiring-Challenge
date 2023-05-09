using KonfidesCase.Entities.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KonfidesCase.DataAccess.Context;

public class ApplicationContext : IdentityDbContext<AppUser, AppRole, int>
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Event> Events { get; set; }
    
}