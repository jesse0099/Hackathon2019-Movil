using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UISampleApp.Models;

namespace UISampleApp.Services
{
    public class RestServiceConsumer
    {
        
        /*Metodo generico para consumir verbos GET*/
        public async Task<Response> GetList<T>(string baseUrl,string prefix,string controller){

            HttpClient client = new HttpClient();

            try
            {
                client.BaseAddress = new Uri(baseUrl);
                var url = $"{prefix}{controller}";
                var response = await client.GetAsync(url);
                var answer = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode) {
                    return new Response
                    {
                        IsSuccesFull = false,
                        Message = answer,
                    };
                }

                var objects = JsonConvert.DeserializeObject<T>(answer);

                return new Response
                {
                    IsSuccesFull = true,
                    Result = objects,
                };

            }
            catch (Exception ex)
            {

                return new Response {
                    IsSuccesFull = false,
                    Message = ex.Message,
                };
            }       

        }


        /*Metodos para autenticacion y obtencion de informacion con token*/
        public async Task<T> GetAuth<T>(string url, string token)
        {
            HttpClient client = new HttpClient();
            try
            {

                var cleanToken = token.Replace('"', ' ');
                var cleanedToken = cleanToken.Trim();
                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", string.Format("Bearer {0}", cleanedToken));

                var response = await client.GetAsync(url);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var stringResponse = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(stringResponse);
                }
                else
                {
                    return default(T);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> PostToken(string url, Object content, Type ez)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = null;

            try
            {
                var json = JsonConvert.SerializeObject(Convert.ChangeType(content, ez));
                var contentString = new StringContent(json, Encoding.UTF8, "application/json");

                response = await client.PostAsync(url, contentString);

                if (response.IsSuccessStatusCode)
                {
                    var stringRespond = await response.Content.ReadAsStringAsync();
                    if (stringRespond != string.Empty)
                        return stringRespond;
                    else
                        return string.Empty;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return string.Empty;
        }

        public async Task<string> PostTokenBody(string url, Object content, Type ez)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = null;

            try
            {
                var json = JsonConvert.SerializeObject(Convert.ChangeType(content, ez));
                var contentString = new StringContent(json, Encoding.UTF8, "application/json");

                response = await client.PostAsync(url, contentString);

                if (response.IsSuccessStatusCode)
                {
                    var stringRespond = await response.Content.ReadAsStringAsync();
                    var jwtDynamic = JsonConvert.DeserializeObject<dynamic>(stringRespond);
                    var accessToken = jwtDynamic.Value<string>("access_token");
                    return accessToken;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return string.Empty;
        }

    }
}
