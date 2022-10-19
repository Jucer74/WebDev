using Newtonsoft.Json;
using RestSharp;
using System;
using System.Net;
using System.Threading.Tasks;
using WebDev.Services.Entities;

namespace WebDev.Services
{
  public class LoginService
  {
    private readonly RestClient _restClient;
    private string BaseUrl { get; }

    public LoginService(string baseUrl)
    {
      BaseUrl = baseUrl;
      _restClient = new RestClient();
    }

    public async Task<TokenDto> ValidUser(LoginDto login)
    {
      TokenDto tokenDtoResponse = null;

      // Assign the URL
      _restClient.BaseUrl = new Uri($"{BaseUrl}/login");

      // Wait until to get a response
      _restClient.Timeout = -1;

      // Assign the Method Type
      var request = new RestRequest(Method.POST);

      // Assign the Body
      var content = JsonConvert.SerializeObject(login);
      request.AddParameter("application/json", content, ParameterType.RequestBody);

      // Execute the Call
      IRestResponse response = await _restClient.ExecuteAsync(request);

      // Checking the response is successful or not which is sent using HttpClient
      if (response.StatusCode == HttpStatusCode.OK)
      {
        // Storing the content response recieved from web api
        var responseContent = response.Content;

        //Deserializing the response recieved from web api and storing into the Employee list
        tokenDtoResponse = JsonConvert.DeserializeObject<TokenDto>(responseContent);
      }

      return tokenDtoResponse;
    }
  }
}