using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace UISampleApp.Models
{
    public class RestClient
    {
        HttpClient client;
        //Get consumer
        public async Task<T> GetT<T>(string url)
        {
            client = new HttpClient();
            try
            {


                var response = await client.GetAsync(url);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    //Peticion correcta
                    var jsonStringResponse = await response.Content.ReadAsStringAsync();
                    return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(jsonStringResponse);
                }
                else
                    return default(T);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<T> GetAuth<T>(string url,string token)
        {
            client = new HttpClient();
            try
            {

                var cleanToken = token.Replace('"',' ');
                var cleanedToken = cleanToken.Trim();
                client.DefaultRequestHeaders.Clear();
                //var authHeader = new AuthenticationHeaderValue("Bearer",token);
                client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", string.Format("Bearer {0}",cleanedToken));
                //client.DefaultRequestHeaders.Add("APP_VERSION", "1.0.0");
                //client.DefaultRequestHeaders.Authorization = authHeader;
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
            client = new HttpClient();
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

        public async Task<string> PostTokenBody(string url,Object content,Type ez)
        {
            client = new HttpClient();
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
