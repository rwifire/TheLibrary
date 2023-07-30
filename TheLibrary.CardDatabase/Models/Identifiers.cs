using System.ComponentModel.DataAnnotations;

namespace TheLibrary.CardDatabase.Models;

public class Identifiers
{
  [Key]
  public int Id { get; set; }
  public string CardKingdomId { get; set; }
  public string McmId { get; set; }
  public string McmMetaId { get; set; }
  public string MultiverseId { get; set; }
  public string ScryfallId { get; set; }
  public string ScryfalloracleId { get; set; }
  public string ScryfallIllustrationId { get; set; }
  public string TcgPlayerProductId { get; set; }
}