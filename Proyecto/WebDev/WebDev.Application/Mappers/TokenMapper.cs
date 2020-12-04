using WebDev.Application.Models;
using WebDev.Services.Entities;

namespace WebDev.Application.Mappers
{
  public class TokenMapper
  {
    protected TokenMapper()
    {

    }

    public static TokenData ToEntity(TokenDto tokenDto)
    {
      return new TokenData
      {
        Token = tokenDto.Token,
        UserId = tokenDto.UserId,
        Name = tokenDto.Name
      };
    }

    public static TokenDto ToDto(TokenData tokenData)
    {
      return TokenDto.Build(
        token: tokenData.Token,
        userId: tokenData.UserId,
        name: tokenData.Name
      );
    }
  }
}