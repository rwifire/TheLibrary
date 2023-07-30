using System.ComponentModel.DataAnnotations;
using System.Runtime.Versioning;

namespace TheLibrary.CardDatabase.Models;

public class Card
{
  [Key]
  public string Uuid { get; set; }
  
  public string AsciiName { get; set; }
  public Identifiers Identifiers { get; set; }
  public string Language { get; set; }
  public float ManaValue { get; set; }
  public string Name { get; set; }
  public string Number { get; set; }
  public string Rarity { get; set; }
  public string SetCode { get; set; }
  public Set Set { get; set; }
  public List<string> Types { get; set; }
  public List<string> ColorIdentity { get; set; }
  public List<string> Finishes { get; set; }
}