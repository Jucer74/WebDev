namespace WebDev.Services.Entities
{
  public class UserDto
  {
    public int id { get; set; }
    public string email { get; set; }
    public string name { get; set; }
    public string username { get; set; }
    public string password { get; set; }

    private UserDto()
    {

    }

    public static UserDto Build(int id, string email, string name, string username, string password)
    {
      return new UserDto
      {
        id = id,
        email = email,
        name = name,
        username = username,
        password = password
      };
    }
  }
}