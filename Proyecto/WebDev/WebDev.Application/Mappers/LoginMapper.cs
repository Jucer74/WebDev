using WebDev.Application.Models;
using WebDev.Services.Entities;

namespace WebDev.Application.Mappers
{
  public class LoginMapper
  {
    protected LoginMapper()
    {

    }

    public static Login ToEntity(LoginDto loginDto)
    {
      return new Login
      {
        Email = loginDto.email,
        Password = loginDto.password
      };
    }

    public static LoginDto ToDto(Login login)
    {
      return LoginDto.Build(
        email: login.Email,
        password: login.Password
      );
    }
  }
}