using Newtonsoft.Json;
using System.Net;

namespace MoneyMe_Loan_FrontEnd.Shared
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task Post(string URL, object? param = null)
        {
            HttpResponseMessage? response = await _httpClient.PostAsJsonAsync(URL, param);
            if (response != null)
            {
                if (!response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    throw new Exception(string.Concat("StatusCode: ", response.StatusCode, " | URL: ", URL, " | Error: ", responseString));
                }
            }
        }

        public async Task<T?> Post<T>(string URL, object? param = null)
        {
            T? result;
            HttpResponseMessage? response = await _httpClient.PostAsJsonAsync(URL, param);
            if (response != null)
            {
                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<T?>(responseString);
                }
                else
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    throw new Exception(string.Concat("StatusCode: ", response.StatusCode, " | URL: ", URL, " | Error: ", responseString));
                }
            }
            else
            {
                result = default;
            }
            return result;
        }

        public async Task<(bool, string, string, byte[])> PostByteArray(string URL, object? param = null)
        {
            bool isSuccess = false;
            string errorMessage = "";
            string fileName = "";
            byte[]? fileByte = Array.Empty<byte>();
            HttpResponseMessage? response = await _httpClient.PostAsJsonAsync(URL, param);
            if (response != null)
            {
                if (response.IsSuccessStatusCode)
                {
                    isSuccess = true;
                    fileByte = await response.Content.ReadAsByteArrayAsync();
                    fileName = response.Content.Headers.ContentDisposition?.FileName?.Replace("\"", "") ?? "";
                }
                else if (response.StatusCode == HttpStatusCode.BadRequest)
                {
                    isSuccess = false;
                    errorMessage = await response.Content.ReadAsStringAsync();
                }
                else
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    throw new Exception(string.Concat("StatusCode: ", response.StatusCode, " | URL: ", URL, " | Error: ", responseString));
                }
            }
            return (isSuccess, errorMessage, fileName, fileByte);
        }

        public async Task<T?> Get<T>(string URL)
        {
            T? result;
            HttpResponseMessage? response = await _httpClient.GetAsync(URL);
            if (response != null)
            {
                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<T?>(responseString);
                }
                else
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    throw new Exception(string.Concat("StatusCode: ", response.StatusCode, " | URL: ", URL, " | Error: ", responseString));
                }
            }
            else
            {
                result = default;
            }
            return result;
        }

        public async Task<string?> GetString(string URL)
        {
            string? result;
            HttpResponseMessage? response = await _httpClient.GetAsync(URL);
            if (response != null)
            {
                if (response.IsSuccessStatusCode)
                {
                    result = await response.Content.ReadAsStringAsync();
                }
                else
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    throw new Exception(string.Concat("StatusCode: ", response.StatusCode, " | URL: ", URL, " | Error: ", responseString));
                }
            }
            else
            {
                result = default;
            }
            return result;
        }
    }
}
