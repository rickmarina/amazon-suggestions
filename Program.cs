using System.Text.Json;
using Microsoft.Extensions.DependencyInjection;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var serviceProvider = new ServiceCollection()
                        .AddHttpClient()
                        .AddSingleton<AmazonSuggestionsService>()
                        .BuildServiceProvider();

        var amazonService = serviceProvider.GetRequiredService<AmazonSuggestionsService>();

        var template = File.ReadAllText("json/template.json");
        var query = new QueryRequestModel(template);


        //Request and save it to db structure 
        List<SuggestionsDatabaseModel> suggestionsDB = new(); 

        string abc = "abcdefghijklmopqrstuvwxyz";
        foreach (var letter in abc)
        {
            query.SetPrefix(letter.ToString());

            var response = await amazonService.Request(query);

            if (response is not null)
            {
                SuggestionsDatabaseModel dbModel = new SuggestionsDatabaseModel() { 
                    prefix = letter.ToString(), 
                    suggestions = response.suggestions.Select(x=> x.value) 
                    };
                
                suggestionsDB.Add(dbModel);  
            }
        }

        System.Console.WriteLine(JsonSerializer.Serialize(suggestionsDB, new JsonSerializerOptions() { WriteIndented = true }));


    }
}
