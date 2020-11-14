using System;
using System.Collections.Generic;
using System.Text;
using PrintMersion.Core.Entities;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Formatting;
using Newtonsoft.Json;


namespace PrintMersion.Infrastructure.ApiClient
{
    public static class ClientToken
    {
        public static async Task<string> GetToken(UserLogin login)
        {
            using (HttpClient _httpClient = new HttpClient())
            {
                var token = new { token = "" };   
                var responseMessage = await _httpClient.PostAsJsonAsync(@"https://printmersion.azurewebsites.net/api/token",login);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var cont = await responseMessage.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeAnonymousType(cont, token);
                    return data.token;

                }

                return null;
            }
        }

    }
}
