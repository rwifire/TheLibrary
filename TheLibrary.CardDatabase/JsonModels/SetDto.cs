namespace TheLibrary.CardDatabase.JsonModels;

public class SetDto
{
  public CardSetDto[] Cards { get; set; }
  public string Code { get; set; }
  public string KeyruneCode { get; set; }
  public string[] Languages { get; set; }
  public string Name { get; set; }
  public CardTokenDto[] Tokens { get; set; }
}