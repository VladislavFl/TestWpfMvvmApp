using System.Net;
using System.Net.Http;
using System.Text;
using TestWpfMvvmApp.Model;
using TestWpfMvvmApp.Services.Interfaces;
using System.Text.Json;

namespace TestWpfMvvmApp.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient? _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://petstore.swagger.io/v2/user/");
        }

        public async Task<bool> LoginAsync(string username, string password)
        {
            var response = await _httpClient!.GetAsync($"login?username={username}&password={password}");

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                throw new Exception(response.StatusCode.ToString());
            }
        }

        public async Task<bool> LogoutAsync()
        {
            var response = await _httpClient!.GetAsync($"logout");

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                throw new Exception(response.StatusCode.ToString());
            }
        }

        public async Task<bool> RegisterAsync(User user)
        {
            var json = JsonSerializer.Serialize(user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient!.PostAsync("", content);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                throw new Exception(response.StatusCode.ToString());
            }
        }

        public async Task<User> GetUserDataAsync(string username)
        {
            var response = await _httpClient!.GetAsync($"{username}");

            if (response.StatusCode == HttpStatusCode.OK)
            {
                string json = await response.Content.ReadAsStringAsync();
                var user = JsonSerializer.Deserialize<User>(json);
                return user!;
            }
            else
            {
                throw new Exception(response.StatusCode.ToString());
            }
        }
    }
}
