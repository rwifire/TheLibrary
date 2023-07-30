using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using TheLibrary.CardDatabase.Models;

namespace TheLibrary.CardDatabase;

public sealed class CardDbContext : DbContext, ICardDbContext
{
  private static bool _created = false;
  public DbSet<Card> Cards { get; set; } = null!;

  public CardDbContext()
  {
    if (!_created)
    {
      Database.EnsureDeleted();
      Database.EnsureCreated();
      _created = true;
    }
  }
  
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Card>()
      .HasKey(p => p.Uuid);
    modelBuilder.Entity<Card>()
      .HasOne(c => c.Identifiers);
    modelBuilder.Entity<Card>()
      .Property(p => p.ColorIdentity)
      .HasConversion(
        v => string.Join(',', v),
        v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList());
    modelBuilder.Entity<Card>()
      .Property(p => p.Finishes)
      .HasConversion(
        v => string.Join(',', v),
        v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList());
    modelBuilder.Entity<Card>()
      .Property(p => p.Types)
      .HasConversion(
        v => string.Join(',', v),
        v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList());
    
    modelBuilder.Entity<Set>()
      .HasKey(p => p.Code);
    modelBuilder.Entity<Set>()
      .HasMany(e => e.Cards)
      .WithOne(e => e.Set)
      .HasForeignKey(e => e.SetCode)
      .HasPrincipalKey(e => e.Code);
    modelBuilder.Entity<Set>()
      .HasMany(e => e.Tokens)
      .WithOne(e => e.Set)
      .HasForeignKey(e => e.SetCode)
      .HasPrincipalKey(e => e.Code);
    modelBuilder.Entity<Set>()
      .Property(p => p.Languages)
      .HasConversion(
        v => string.Join(',', v),
        v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList());

    modelBuilder.Entity<Token>()
      .HasKey(e => e.Uuid);
    modelBuilder.Entity<Card>()
      .HasOne(c => c.Identifiers);
    modelBuilder.Entity<Token>()
      .Property(p => p.ColorIdentity)
      .HasConversion(
        v => string.Join(',', v),
        v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList());
    modelBuilder.Entity<Token>()
      .Property(p => p.Finishes)
      .HasConversion(
        v => string.Join(',', v),
        v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList());
    modelBuilder.Entity<Token>()
      .Property(p => p.Types)
      .HasConversion(
        v => string.Join(',', v),
        v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList());
  }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    optionsBuilder.UseSqlite(@"Data Source=cards.db");
  }
  
  public void Commit()
  {
    SaveChanges();
  }
}

public interface ICardDbContext
{
  public DbSet<Card> Cards { get; }

  public void Commit();
}