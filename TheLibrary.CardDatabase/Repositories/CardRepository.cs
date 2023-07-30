using TheLibrary.CardDatabase.Models;

namespace TheLibrary.CardDatabase.Repositories;

public class CardRepository
{
  private readonly ICardDbContext _context;

  public CardRepository(ICardDbContext context)
  {
    _context = context;
  }

  public async Task AddCard(Card card)
  {
    await _context.Cards.AddAsync(card);
  }

  public void Commit()
  {
    _context.Commit();
  }
}