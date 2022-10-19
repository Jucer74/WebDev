namespace WebDev.Services.Entities
{
  public class TokenDto
  {
    public string Token { get; set; }
    public int UserId { get; set; }
    public string Name { get; set; }

    private TokenDto()
    {
    }

    public static TokenDto Build(string token, int userId, string name)
    {
      return new TokenDto
      {
        Token = token,
        UserId = userId,
        Name = name
      };
    }
  }
}