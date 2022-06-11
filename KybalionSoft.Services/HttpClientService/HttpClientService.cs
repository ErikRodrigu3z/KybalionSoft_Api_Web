using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;

namespace KybalionSoft.Services.HttpClientService
{
    public class HttpClientService
    {
        private string URLService = "";

        public HttpClientService(string url)
        {
            URLService = url;
        }


        public async Task<string> PostAsync<T>(string Method, T Object, string accessToken = null)
        {
            try
            {
                using (var client = new HttpClient(CertificateValidation()))
                {
                    HttpConfiguration(client);

                    if (!string.IsNullOrEmpty(accessToken))
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);


                    string jsonparameters = JsonConvert.SerializeObject(Object);

                    var content = new StringContent(jsonparameters, System.Text.Encoding.UTF8, "application/json");

                    var result = await client.PostAsync(Method, content);
                    if (result.IsSuccessStatusCode)
                    {
                        var resultContent = await result.Content.ReadAsStringAsync();

                        return resultContent;
                    }
                }
                return string.Empty;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<string> PutAsync<T>(string Method, T Object, string accessToken = null)
        {
            try
            {
                using (var client = new HttpClient(CertificateValidation()))
                {
                    HttpConfiguration(client);

                    if (!string.IsNullOrEmpty(accessToken))
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);


                    string jsonparameters = JsonConvert.SerializeObject(Object);

                    var content = new StringContent(jsonparameters, System.Text.Encoding.UTF8, "application/json");

                    var result = await client.PutAsync(Method, content);
                    if (result.IsSuccessStatusCode)
                    {
                        var resultContent = await result.Content.ReadAsStringAsync();

                        return resultContent;
                    }
                }
                return string.Empty;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<string> DeleteAsync<T>(string Method, T Object, string accessToken = null)
        {
            try
            {
                using (var client = new HttpClient(CertificateValidation()))
                {
                    HttpConfiguration(client);

                    if (!string.IsNullOrEmpty(accessToken))
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);


                    string jsonparameters = JsonConvert.SerializeObject(Object);

                    var content = new StringContent(jsonparameters, System.Text.Encoding.UTF8, "application/json");

                    var result = await client.DeleteAsync(Method);
                    if (result.IsSuccessStatusCode)
                    {
                        var resultContent = await result.Content.ReadAsStringAsync();

                        return resultContent;
                    }
                }
                return string.Empty;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<T> Get<T>(string MethodWithParameters, string accessToken = null)
        {
            using (var client = new HttpClient(CertificateValidation()))
            {
                HttpConfiguration(client);

                if (!string.IsNullOrEmpty(accessToken))
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                var result = await client.GetAsync(MethodWithParameters);
                if (result.IsSuccessStatusCode)
                {
                    var resultContent = await result.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(resultContent);
                }
            }
            return default(T);
        }

        public async Task<List<T>> GetListAsync<T>(string MethodWithParameters, string accessToken = null)
        {
            using (var client = new HttpClient(CertificateValidation()))
            {

                HttpConfiguration(client);

                if (!string.IsNullOrEmpty(accessToken))
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                var result = await client.GetAsync(MethodWithParameters);
                if (result.IsSuccessStatusCode)
                {
                    var resultContent = await result.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<T>>(resultContent);
                }
            }

            return default(List<T>);
        }


        #region Methods
        public void HttpConfiguration(HttpClient client)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls | SecurityProtocolType.Tls13;
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

            client.BaseAddress = new Uri(URLService);
            client.Timeout = TimeSpan.FromMinutes(10);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public HttpClientHandler CertificateValidation()
        {
            var httpClientHandler = new HttpClientHandler();
            httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) =>
            {
                return true;
            };

            return httpClientHandler;
        }


        #endregion

    }
}
