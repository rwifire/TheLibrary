using System.ComponentModel.DataAnnotations;

namespace TheLibrary.CardDatabase.Models;

public class Set
{
  [Key]
  public string Code { get; set; }
  public List<Card> Cards { get; set; }
  public string KeyruneCode { get; set; }
  public List<string> Languages { get; set; }
  public string Name { get; set; }
  public List<Token> Tokens { get; set; }
}