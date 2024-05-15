using System.Drawing;
using System.Net.Mime;
using fc24players.Models;
using Microsoft.EntityFrameworkCore;
using Version = fc24players.Models.Version;

namespace fc24players.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
    {
    }
    
    public DbSet<Player> Player { get; set; }
    public DbSet<Nationality> Nationality { get; set; }
    public DbSet<Accelerate> Accelerate { get; set; }
    public DbSet<Bodytype> Bodytype { get; set; }
    public DbSet<Card> Card { get; set; }
    public DbSet<Club> Club { get; set; }
    public DbSet<League> League { get; set; }
    public DbSet<PlayerAltpos> PlayerAltpos { get; set; }
    public DbSet<PlayerBodytype> PlayerBodytype { get; set; }
    public DbSet<Playstyle> Playstyle { get; set; }
    public DbSet<Position> Position { get; set; }
    public DbSet<Version> Version { get; set; }

}