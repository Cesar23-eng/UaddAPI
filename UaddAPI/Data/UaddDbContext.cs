using Microsoft.EntityFrameworkCore;
using UaddAPI.Models;

namespace UaddAPI.Data;

public class UaddDbContext : DbContext
{
    public UaddDbContext(DbContextOptions<UaddDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();
    public DbSet<NewsPost> NewsPosts => Set<NewsPost>();
}