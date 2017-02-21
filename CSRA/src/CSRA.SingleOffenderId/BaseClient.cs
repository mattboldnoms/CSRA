using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CSRA.SingleOffenderId
{
    public interface IBaseClient
    {
        Task<T> Get<T>(string uri);
        Task<T> Post<T>(string uri, object package);
        Task<T> Post<T>(string uri);
    }

    public class BaseClient : IBaseClient
    {
        private HttpClient client;
        private readonly string baseUri;
        private readonly string clientId;
        private readonly string clientSecret;
        private ISingleOffenderIdTokenStore tokenStore;

        private static readonly object lockObject = new object();

        public BaseClient(HttpClient client, string baseUri, string clientId, string clientSecret, ISingleOffenderIdTokenStore tokenStore)
        {
            this.client = client;
            this.baseUri = baseUri;
            this.clientId = clientId;
            this.clientSecret = clientSecret;
            this.tokenStore = tokenStore;
        }


        public async Task<T> Get<T>(string uri)
        {
            var fullUri = new Uri($"{baseUri}/{uri}");

            await this.SetAuthorizationToken();

            var response = await client.GetAsync(fullUri);

            return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
        }

        public async Task<T> Post<T>(string uri, object package)
        {
            var fullUri = new Uri($"{baseUri}/{uri}");
            HttpContent content = new StringContent(JsonConvert.SerializeObject(package));
            var response = await this.client.PostAsync(fullUri, content);
            return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
        }

        public async Task<T> Post<T>(string uri)
        {
            var fullUri = new Uri($"{baseUri}/{uri}");
            var response = await this.client.PostAsync(fullUri, new StringContent(""));
            return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
        }
  
        private async Task SetAuthorizationToken()
        {
            if (!this.tokenStore.IsTokenValid())
            {
                await GetAuthorizationToken();
            }

            var token = this.tokenStore.GetToken();

            if (token != null)
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.AccessToken);
            }
        }

        private async Task GetAuthorizationToken()
        {
            client.DefaultRequestHeaders.Clear();

            var tokenUri = $"{baseUri}/oauth/token?grant_type=client_credentials&client_id={clientId}&client_secret={clientSecret}";

            var response = await this.client.PostAsync(new Uri(tokenUri), new StringContent(""));

            var token = JsonConvert.DeserializeObject<SingleOffenderIdToken>(await response.Content.ReadAsStringAsync());

            this.tokenStore.SaveToken(token);
        }
    }
}
