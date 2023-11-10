using System.Text.Json;
using System.Text.Json.Serialization;

internal class AmazonSuggestionsService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private const string URL = "https://completion.amazon.es/api/2017/suggestions";
    public AmazonSuggestionsService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<SuggestionsResponseModel?> Request(QueryRequestModel query)
    {

        using (var httpClient = _httpClientFactory.CreateClient())
        {
            var queryString = query.BuildQuery();

            var response = await httpClient.GetAsync($"{URL}{queryString}");

            response.EnsureSuccessStatusCode(); 

            var responseContent = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<SuggestionsResponseModel>(responseContent); 
            
        }

    }

}