
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Project1App.Entities;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    { }

    public ApplicationDbContext() { }

    public DbSet<Player> Players { get; set; }
    public DbSet<PlayerItems> PlayerItems { get; set; }

    public DbSet<Login> Logins { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // base.OnConfiguring(optionsBuilder);
        if (!optionsBuilder.IsConfigured)
        {
            // Using the Builder Design Pattern
            // We create an object of builder, and then use methods to build out the object to the type we want and then run a build method
            IConfigurationRoot configuration = new ConfigurationBuilder()
                                                .SetBasePath(Directory.GetCurrentDirectory())
                                                .AddJsonFile("appsettings.json")
                                                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            optionsBuilder.UseSqlServer(connectionString);

        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Player>().HasOne(p => p.PlayerItems).WithOne(pi => pi.Player).HasForeignKey<PlayerItems>(pi => pi.PlayerItemsID);
        modelBuilder.Entity<Player>().HasOne(p => p.Login).WithOne(l => l.Player).HasForeignKey<Login>(l => l.LoginID);
    }
}