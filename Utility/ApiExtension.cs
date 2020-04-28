using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using static System.String;

namespace Utility
{
    public static class ApiExtension
    {
        public static async Task<T> ReadAsJsonAsync<T>(this HttpContent content)
        {
            var json = await content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<T>(json);
            return value;
        }
        public static async Task<T> GetAsync<T>(string baseAddress, string urlPathAndQuery,
            string token = default, IDictionary<string, string> headers = default)
        {
            var clientHandler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback =
                    (sender, cert, chain, sslPolicyErrors) => true
            };
            using (var client = new HttpClient(clientHandler))
            {
                client.BaseAddress = new Uri(baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                if (token != default)
                {
                    client.DefaultRequestHeaders.Add("Security-Token", token);
                }
                if (headers != default)
                {
                    foreach (var item in headers)
                    {
                        client.DefaultRequestHeaders.Add(item.Key, item.Value);
                    }
                }
                try
                {
                    var response = await client.GetAsync(urlPathAndQuery);
                    if (response.IsSuccessStatusCode)
                    {
                        var obj = await response.Content.ReadAsJsonAsync<T>();
                        return obj;
                    }
                }
                catch (Exception)
                {
                    return default;
                }
            }
            return default;
        }

        public static async Task<T> PostAsync<T, TParam>(string baseAddress, string urlPath,
            TParam param, string token = default, IDictionary<string, string> headers = default)
        {
            var clientHandler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback =
                (sender, cert, chain, sslPolicyErrors) => true
            };
            using (var client = new HttpClient(clientHandler))
            {
                client.BaseAddress = new Uri(baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                if (token != default)
                {
                    client.DefaultRequestHeaders.Add("Security-Token", token);
                }

                if (headers != default)
                {
                    foreach (var item in headers)
                    {
                        client.DefaultRequestHeaders.Add(item.Key, item.Value);
                    }
                }
                try
                {
                    var json = JsonConvert.SerializeObject(param);
                    var data = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(urlPath, data);
                    if (response.IsSuccessStatusCode)
                    {
                        var obj = await response.Content.ReadAsJsonAsync<T>();
                        return obj;
                    }
                }
                catch (Exception)
                {
                    return default;
                }
            }
            return default;
        }

        public static async Task<string> PostFormFileAsync(string baseAddress, string urlPath,
            IFormFile file, string token = default)
        {
            if (file == null || file.Length <= 0) return Empty;
            var clientHandler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback =
                    (sender, cert, chain, sslPolicyErrors) => true
            };
            using var client = new HttpClient(clientHandler);
            try
            {
                client.BaseAddress = new Uri(baseAddress);
                if (token != default)
                {
                    client.DefaultRequestHeaders.Add("Security-Token", token);
                }
                byte[] data;
                using (var br = new BinaryReader(file.OpenReadStream()))
                    data = br.ReadBytes((int)file.OpenReadStream().Length);
                var bytes = new ByteArrayContent(data);
                var multiContent = new MultipartFormDataContent
                    {
                        {bytes, "file", file.FileName}
                    };
                var response = await client.PostAsync(urlPath, multiContent);
                if (!response.IsSuccessStatusCode) return Empty;
                var obj = await response.Content.ReadAsStringAsync();
                return obj;
            }
            catch (Exception)
            {
                return Empty;
            }
        }
    }
}