using System.Net.Http.Headers;
using System.Text.Json;

namespace ShoppingApp.Extensions
{
    public static class HttpClientExtensions
    {
        public static async Task<T> ReadContentAs<T>(this HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
                throw new ApplicationException($"Something went wrong calling the API: {response.ReasonPhrase}");

            var dataString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return JsonSerializer.Deserialize<T>(dataString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public static async Task<HttpResponseMessage> PostAsJson<T>(this HttpClient client, string url, T data)
        {
            var dataString = JsonSerializer.Serialize(data);
            var content = new StringContent(dataString);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return await client.PostAsync(url, content);
        }

        public static async Task<HttpResponseMessage> PutAsJson<T>(this HttpClient client, string url, T data)
        {
            var dataString = JsonSerializer.Serialize(data);
            var content = new StringContent(dataString);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return await client.PutAsync(url, content);
        }
    }
}
