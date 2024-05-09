using System.Text.Json;
using System.Text;
using SalveVidaDoandoApp.Configurations;
using SalveVidaDoandoApp.Helper;

namespace SalveVidaDoandoApp.Services;
public class SendRequestService {

    private static readonly HttpClient _client = new(new HttpsClientHandlerService().GetPlatformMessageHandler());

    public static async Task<TResponse?> PostRequestAsync<TRequest, TResponse>(TRequest request, string urlEndpoint) {
        var jsonOptions = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, WriteIndented = false };

        var json = JsonSerializer.Serialize(request, jsonOptions);
        var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

        var fullUrl = $"{ConstantsHelper.BaseAddress}/{urlEndpoint.TrimStart('/')}";

        var response = await _client.PostAsync(fullUrl, httpContent);

        if (response.IsSuccessStatusCode) {
            // Deserialize response content asynchronously
            var responseBody = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<TResponse>(responseBody, jsonOptions);
        } 

        return default;
    }
}

