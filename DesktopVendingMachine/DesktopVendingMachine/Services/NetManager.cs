using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using DesktopVendingMachine.Models;

namespace DesktopVendingMachine.Services
{
    public static class NetManager
    {
        public static string Url = "https://localhost:44343/";
        private static HttpClient httpClient = new HttpClient();

        public static async Task<T> Get<T>(string path)
        {
            var response = await httpClient.GetAsync(Url + path);
            var content = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<T>(content);
            return data;
        }

        public static async Task<HttpResponseMessage> Post<T>(string path, T data)
        {
            var jsData = JsonConvert.SerializeObject(data);
            var response = await httpClient.PostAsync(Url + path, new StringContent(jsData, Encoding.UTF8, "application/json"));
            return response;
        }
        public static async Task<HttpResponseMessage> Put<T>(string path, T data)
        {
            var jsData = JsonConvert.SerializeObject(data);
            var response = await httpClient.PutAsync(Url + path, new StringContent(jsData, Encoding.UTF8, "application/json"));
            return response;
        }

        public static async Task<HttpResponseMessage> Delete(string path)
        {
            var response = await httpClient.DeleteAsync(Url + path);
            return response;
        }

        public static async Task<T> ParseResponse<T>(HttpResponseMessage responseMessage)
        {
            var content = await responseMessage.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<T>(content);
            return data;
        }

        public static async Task<HttpResponseMessage> Authorization(string login, string password)
        {
            var jsData = JsonConvert.SerializeObject(new { login, password });
            var response = await httpClient.PostAsync(Url + "api/auth", new StringContent(jsData, Encoding.UTF8, "application/json"));
            var contetn = await response.Content.ReadAsStringAsync();
            var token = JsonConvert.DeserializeObject<GetToken>(contetn);
            if (response.IsSuccessStatusCode)
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.Token);
            return response;
        }


    }
}
