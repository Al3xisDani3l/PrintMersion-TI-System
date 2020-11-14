using Newtonsoft.Json;
using PrintMersion.Core.Entities;
using PrintMersion.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Xunit;
using PrintMersion.Infrastructure.ApiClient;

namespace PrintMersion.UnitTest
{
  public  class ApiClientTest
    {

        const string urlBase = @"https://printmersion.azurewebsites.net";
        const string token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiYWgxMDc1IiwiVXNlciI6ImFoMTA3NSIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6IkFkbWluaXN0cmF0b3IiLCJuYmYiOjE2MDQ3NDQ2MDIsImV4cCI6MTYwNDc1NTQwMiwiaXNzIjoiaHR0cDovL3ByaW50bWVyc2lvbi5henVyZXdlYnNpdGVzLm5ldCIsImF1ZCI6Imh0dHA6Ly9wcmludG1lcnNpb24uYXp1cmV3ZWJzaXRlcy5uZXQifQ.bmbFeHoHCc81rKBTIHh8WCpr8lSytYM48GnzSAayI4Y";

        [Fact]
        public async void getTest()
        {
            var _client = new ClientRepositoryBase<UserDto>(urlBase);

            var res = await _client.Get();

            Assert.NotNull(res);
        }
        [Fact]
        public async void GetToken()
        {
            var log = new UserLogin() { UserName = "AH1075", Password = "hega230498" };
            var res = await ClientToken.GetToken(log);



            Assert.NotNull(res);
        }

        [Fact]
        public async void GetEntity()
        {
            var _client = new ClientRepositoryBase<User>(urlBase,token);

            var res = await _client.Get();

            Assert.NotNull(res);
        }

        [Fact]
        public async void Update()
        {

            var log = new UserLogin() { UserName = "AH1075", Password = "hega230498" };
            var res = await ClientToken.GetToken(log);

            var _client = new ClientRepositoryBase<User>(urlBase, res);

             var yo = await  _client.Get(1);

            yo.FirstName = "Leonardo gabriel";

            var result = await _client.Put(yo);

            Assert.True(result);


        }

    }
}
