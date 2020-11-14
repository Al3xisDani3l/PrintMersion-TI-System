using Newtonsoft.Json;
using PrintMersion.Core.Entities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Xunit;

namespace PrintMersion.UnitTest
{
    public class ApiVerbsTest
    {
        static HttpClient client = new HttpClient();



        [Fact]
        public async Task GetTest()
        {
            config();

            List<User> result;




            var response = await client.GetAsync("api/administer");

            if (response.IsSuccessStatusCode)
            {
                var serialize = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<List<User>>(serialize);

            }

        }

        void config()
        {
            client.BaseAddress = new Uri("https://localhost:44319/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(("application/json")));
        }

    }
}
