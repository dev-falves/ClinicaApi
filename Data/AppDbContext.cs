using Microsoft.EntityFrameworkCore;
using ClinicaApi.Entities;

namespace ClinicaApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Convenio> Convenios { get; set; }
}
