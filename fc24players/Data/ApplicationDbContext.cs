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
    public DbSet<Nationality?> Nationality { get; set; }
    public DbSet<AcceleRate> Accelerate { get; set; }
    public DbSet<Bodytype> Bodytype { get; set; }
    public DbSet<Card> Card { get; set; }
    public DbSet<Club> Club { get; set; }
    public DbSet<League> League { get; set; }
    public DbSet<Playstyle> Playstyle { get; set; }
    public DbSet<Position> Position { get; set; }
    public DbSet<Version> Version { get; set; }
    
    public DbSet<CardBodytype> CardBodytype { get; set; }
    public DbSet<CardAltpos> CardAltpos { get; set; }
    public DbSet<CardPlaystyle> CardPlaystyle { get; set; }
    public DbSet<CardPlayStylePlus> CardPlayStylePlus { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<CardBodytype>()
            .HasKey(cb => new { cb.CardId, cb.BodytypeId });

        modelBuilder.Entity<CardBodytype>()
            .HasOne(cb => cb.Card)
            .WithMany(c => c.CardBodytype)
            .HasForeignKey(cb => cb.CardId);

        modelBuilder.Entity<CardBodytype>()
            .HasOne(cb => cb.Bodytype)
            .WithMany(b => b.Cards) 
            .HasForeignKey(cb => cb.BodytypeId);

        modelBuilder.Entity<CardAltpos>()
            .HasKey(cb => new { cb.CardId, cb.AltposId });

        modelBuilder.Entity<CardAltpos>()
            .HasOne(cb => cb.Card)
            .WithMany(c => c.CardAltPos)
            .HasForeignKey(cb => cb.CardId);

        modelBuilder.Entity<CardAltpos>()
            .HasOne(cb => cb.Altpos)
            .WithMany(b => b.CardAltpos) 
            .HasForeignKey(cb => cb.AltposId);

        modelBuilder.Entity<CardPlaystyle>()
            .HasKey(cb => new { cb.CardId, cb.PlaystyleId });

        modelBuilder.Entity<CardPlaystyle>()
            .HasOne(cb => cb.Card)
            .WithMany(c => c.CardPlaystyle)
            .HasForeignKey(cb => cb.CardId);

        modelBuilder.Entity<CardPlaystyle>()
            .HasOne(cb => cb.Playstyle)
            .WithMany(b => b.PlaystyleCards) 
            .HasForeignKey(cb => cb.PlaystyleId);
        
        modelBuilder.Entity<CardPlayStylePlus>()
            .HasKey(cb => new { cb.CardId, cb.PlaystyleId });

        modelBuilder.Entity<CardPlayStylePlus>()
            .HasOne(cb => cb.Card)
            .WithMany(c => c.CardPlayStylePlus)
            .HasForeignKey(cb => cb.CardId);

        modelBuilder.Entity<CardPlayStylePlus>()
            .HasOne(cb => cb.Playstyle)
            .WithMany(b => b.PlaystylePlusCards) 
            .HasForeignKey(cb => cb.PlaystyleId);
    }
    
}