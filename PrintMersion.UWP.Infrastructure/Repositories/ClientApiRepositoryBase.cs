using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PrintMersion.Core.Interfaces;

using System.Net.Http;
using Newtonsoft.Json;
using System.Net;

namespace PrintMersion.UWP.Infrastructure.Repositories
{
    public class ClientApiRepositoryBase<TEntity> : IRepository<TEntity> where TEntity :class, IEntity,new()
    {

        HttpClient _httpClient;
        string _accessToken;
        string _servicesAddress;
        bool _letterSisNecesary;


        public ClientApiRepositoryBase(bool LetterSisNecesary = true)
        {
            _httpClient = new HttpClient();
            _letterSisNecesary = LetterSisNecesary;



        }

        public  ClientApiRepositoryBase(HttpClient httpClient,bool LetterSisNecesary = true)
        {
            _httpClient = httpClient;
            _letterSisNecesary = LetterSisNecesary;

        }

        public ClientApiRepositoryBase(string token,string serviceAddres, bool LetterSisNecesary = true)
        {
            _accessToken = token;
            _servicesAddress = serviceAddres;
            _letterSisNecesary = LetterSisNecesary;
        }

        public string AccessToken { get => _accessToken; set => _accessToken = value; }
        public string ServicesAddress { get => _servicesAddress; set => _servicesAddress = value; }

        public async Task<bool> Delete(int id)
        {

            return false;
        
        }

        public async Task<IEnumerable<TEntity>> Get()
        {
            IEnumerable<TEntity> result = null;
            try
            {
                _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + _accessToken);
                var data = await _httpClient.GetAsync(string.Concat(_servicesAddress, "routeName"));
                var jsonResponse = await data.Content.ReadAsStringAsync();
                if (jsonResponse != null)
                {
                    result = JsonConvert.DeserializeObject<IEnumerable<TEntity>>(jsonResponse);
                }

                return result;
            }
            catch (WebException exception)
            {

                return null;
            }
          

        }

        public Task<TEntity> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task Patch(TEntity post)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Post(TEntity post)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Put(TEntity post)
        {
            throw new NotImplementedException();
        }
    }
}
