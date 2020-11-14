using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PrintMersion.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Net.Http.Headers;
using PrintMersion.Core.Responses;
using Newtonsoft.Json;




namespace PrintMersion.Infrastructure.ApiClient
{
    public class ClientRepositoryBase<TEntity> : IRepository<TEntity>,IDisposable where TEntity : class,IEntity, new()
    {
       
        string _token;
        string _uri;
        Uri _UriApi;
        bool _tokenIsNesessary = true;
        IGlobal _global;

       



        public string Token { get { return _token; } set { Token = value; } }

       
        public ClientRepositoryBase(IGlobal global)
        {
            _global = global;


            _uri = _global.ApiUri;
            _token = _global.CurrentToken;



            _tokenIsNesessary = !string.IsNullOrEmpty(_global.CurrentToken);

            if (typeof(TEntity).Name.Contains("Dto"))
            {
                _UriApi = GetUriApi(_global.ApiUri, false);
            }
            else
            {
                _UriApi = GetUriApi(_global.ApiUri);
            }
        }

        public ClientRepositoryBase(string urlBase, string token = null)
        {

            _uri = urlBase;
            _token = token;

         

            _tokenIsNesessary = !string.IsNullOrEmpty(token);

            if (typeof(TEntity).Name.Contains("Dto") )
            {
                _UriApi = GetUriApi(urlBase, false);
            }
            else
            {
                _UriApi = GetUriApi(urlBase);
            }

        }

        

     



        public async Task<bool> Delete(int id)
        {


            using (HttpClient _httpClient = new HttpClient())
            {
                if (_tokenIsNesessary)
                {
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
                }
                var responseMessage = await _httpClient.DeleteAsync(_UriApi.AbsoluteUri + $@"/{id}");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var cont = await responseMessage.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<ApiResponse<bool>>(cont);
                    return data.Data;

                }
                else
                {
                    return false;
                }

                
            }
        }

        public async Task<IEnumerable<TEntity>> Get()
        {

            using (HttpClient _httpClient = new HttpClient())
            {
                if (_tokenIsNesessary)
                {
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
                }
                var responseMessage = await _httpClient.GetAsync(_UriApi.AbsoluteUri);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var cont = await responseMessage.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<ApiResponse<IEnumerable<TEntity>>>(cont);
                    return data.Data;

                }

                return null;
            }
          

           

            
        }

        public async Task<TEntity> Get(int id)
        {
            using (HttpClient _httpClient = new HttpClient())
            {
                if (_tokenIsNesessary)
                {
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
                }
                var responseMessage = await _httpClient.GetAsync(_UriApi.AbsoluteUri+$@"/{id}");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var cont = await responseMessage.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<ApiResponse<TEntity>>(cont);
                    return data.Data;

                }

                return null;
            }

        }

        public Task Patch(TEntity post)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Post(TEntity post)
        {
            using (HttpClient _httpClient = new HttpClient())
            {
                if (_tokenIsNesessary)
                {
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
                }

                var responseMessage = await _httpClient.PostAsJsonAsync(_UriApi.AbsoluteUri, post);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var cont = await responseMessage.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<ApiResponse<bool>>(cont);
                    return data.Data;

                }

                return false;
               
            }

        }

        public async Task<bool> Put(TEntity post)
        {
            using (HttpClient _httpClient = new HttpClient())
            {
                if (_tokenIsNesessary)
                {
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
                }
                var responseMessage = await _httpClient.PutAsJsonAsync(_UriApi.AbsoluteUri,post);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var cont = await responseMessage.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<ApiResponse<bool>>(cont);
                    return data.Data;

                }

                return false;
            }

        }

        internal Uri GetUriApi(string uriBase, bool IsLetterSNessesary = true)
        {

            string _uri = uriBase + @"/api/";

            

            string get = typeof(TEntity).Name;

            if (IsLetterSNessesary && !get.EndsWith("s"))
            {
                get = get + "s";
            }
            if (get.Contains("Dto"))
            {
              get = get.Replace("Dto", "sDto");
            }

            _uri += get;

            return new Uri(_uri);



        }

        #region IDisposable Support
        private bool disposedValue = false; // Para detectar llamadas redundantes

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _UriApi = null;
                    // TODO: elimine el estado administrado (objetos administrados).
                }

                // TODO: libere los recursos no administrados (objetos no administrados) y reemplace el siguiente finalizador.
                // TODO: configure los campos grandes en nulos.

                disposedValue = true;
            }
        }

        // TODO: reemplace un finalizador solo si el anterior Dispose(bool disposing) tiene código para liberar los recursos no administrados.
        // ~ClientRepositoryBase()
        // {
        //   // No cambie este código. Coloque el código de limpieza en el anterior Dispose(colocación de bool).
        //   Dispose(false);
        // }

        // Este código se agrega para implementar correctamente el patrón descartable.
        public void Dispose()
        {
            // No cambie este código. Coloque el código de limpieza en el anterior Dispose(colocación de bool).
            Dispose(true);
            // TODO: quite la marca de comentario de la siguiente línea si el finalizador se ha reemplazado antes.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
