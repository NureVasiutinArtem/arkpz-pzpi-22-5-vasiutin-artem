using light_show.Models;
using Microsoft.EntityFrameworkCore;
namespace light_show.Data;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Users> Users { get; set; }
    public DbSet<Effect> Effect { get; set; }
    public DbSet<Device> Device { get; set; }
    public DbSet<Template> Template { get; set; }
    public DbSet<TemplateEffect> TemplateEffect { get; set; }

    //public DbSet<Show> Shows { get; set; }
}





