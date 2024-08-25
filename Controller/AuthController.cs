using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Controller
{
    public class AuthController
    {
        private static readonly HttpClient client = new HttpClient();

        /// <summary>
        /// Authenticates the user by sending a POST request to the authentication endpoint.
        /// </summary>
        /// <param name="username">The username entered by the user.</param>
        /// <param name="password">The password entered by the user.</param>
        /// <returns>A task that represents the asynchronous operation, containing a boolean value indicating success or failure.</returns>
        public async Task<bool> AuthenticateUser(string username, string password)
        {
            var loginData = new
            {
                username = username,
                password = password
            };

            string json = JsonConvert.SerializeObject(loginData);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                HttpResponseMessage response = await client.PostAsync("https://tiendita-server.vercel.app/auth/login", content);

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    var tokenData = JsonConvert.DeserializeObject<TokenResponse>(responseContent);

                    // Here we can store the token in a secure place, e.g., in a field or a secure storage
                    // StoreToken(tokenData.Token); // Example placeholder function
                    return true; // Authentication successful
                }
                else
                {
                    return false; // Authentication failed
                }
            }
            catch (Exception ex)
            {
                // Log the exception or show a message
                // Example: Logger.LogError(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Class to deserialize the token response.
        /// </summary>
        private class TokenResponse
        {
            [JsonProperty("token")]
            public string Token { get; set; }
        }
    }
}
