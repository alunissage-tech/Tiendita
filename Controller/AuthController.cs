using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Controller
{
    /// <summary>
    /// Handles authentication-related operations, such as user login and token management.
    /// </summary>
    public class AuthController
    {
        private static readonly HttpClient client = new HttpClient();
        private static string authToken;

        /// <summary>
        /// Authenticates the user by sending a POST request to the authentication endpoint.
        /// </summary>
        /// <param name="username">The username entered by the user.</param>
        /// <param name="password">The password entered by the user.</param>
        /// <returns>
        /// A task that represents the asynchronous operation, containing a tuple with a boolean value 
        /// indicating whether the authentication was successful, and a string containing an error message if any.
        /// </returns>
        public async Task<(bool isAuthenticated, string errorMessage)> AuthenticateUser(string username, string password)
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

                    authToken = tokenData.Token;
                    return (true, null);
                }
                else
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    return (false, $"Error: {response.StatusCode} - {errorContent}");
                }
            }
            catch (Exception ex)
            {
                return (false, $"Exception: {ex.Message}");
            }
        }

        /// <summary>
        /// Retrieves the stored authentication token.
        /// </summary>
        /// <returns>The JWT token as a string.</returns>
        public static string GetAuthToken()
        {
            return authToken;
        }

        /// <summary>
        /// Represents the response received from the authentication endpoint.
        /// </summary>
        private class TokenResponse
        {
            /// <summary>
            /// Gets or sets the JWT token.
            /// </summary>
            [JsonProperty("token")]
            public string Token { get; set; }
        }
    }
}
