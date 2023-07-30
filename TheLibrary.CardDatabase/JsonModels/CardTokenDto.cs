namespace TheLibrary.CardDatabase.JsonModels;

public class CardTokenDto
{
  public string AsciiName { get; set; }
  public string[] ColorIdentity { get; set; }
  public string[] Finishes { get; set; }
  public IdentifiersDto Identifiers { get; set; }
  public string Language { get; set; }
  public float ManaValue { get; set; }
  public string Name { get; set; }
  public string Number { get; set; }
  public string SetCode { get; set; }
  public string[] Types { get; set; }
  public string Uuid { get; set; }
}