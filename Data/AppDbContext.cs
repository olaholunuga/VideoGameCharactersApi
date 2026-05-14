using Microsoft.EntityFrameworkCore;
using NewApi.Models;

namespace NewApi.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Character> Characters { get; set; } = default!;
}