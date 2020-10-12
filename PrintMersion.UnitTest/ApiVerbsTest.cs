using System;
using Xunit;
using System.Reflection;
using PrintMersion.Core.Entities;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace PrintMersion.UnitTest
{
    public class ApiVerbsTest
    {
        static HttpClient client = new HttpClient();



        [Fact]
        public async Task  GetTest()
        {
            config();

            List<Administer> result;




          var response =  await client.GetAsync("api/administer");

            if (response.IsSuccessStatusCode)
            {
                var serialize = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<List<Administer>>(serialize);
               
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
